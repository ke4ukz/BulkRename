Public Class frmProgress

#Const NOTHREAD = False
#Const SLOWDOWN = False

    Dim WorkThread As Threading.Thread = Nothing

    Private Delegate Sub AddLineCallback(ByVal ToAdd As String)
    Private Delegate Sub SetStatusCallback(ByVal Status As String)
    Private Delegate Sub SetProgressCallback(ByVal Progress As Integer)
    Private Delegate Sub FinishedRenamingCallback()

    Private Filenames As New Dictionary(Of String, String)

    Private Sub AddLine(ByVal ToAdd As String)
        If txtProgress.InvokeRequired Then
            Dim D As New AddLineCallback(AddressOf AddLine)
            Me.Invoke(D, {ToAdd})
        Else
            txtProgress.AppendText(ToAdd)
            txtProgress.AppendText(ControlChars.CrLf)
            txtProgress.SelectionStart = Len(txtProgress.Text)
            txtProgress.ScrollToCaret()
        End If
    End Sub

    Private Sub SetStatus(ByVal Status As String)
        If lblStatus.InvokeRequired Then
            Dim D As New SetStatusCallback(AddressOf SetStatus)
            Me.Invoke(D, {Status})
        Else
            lblStatus.Text = Status
        End If
    End Sub

    Private Sub SetProgress(ByVal Progress As Integer)
#If SLOWDOWN Then
        Threading.Thread.Sleep(200)
#End If
        If pgbProgress.InvokeRequired Then
            Dim D As New SetProgressCallback(AddressOf SetProgress)
            Me.Invoke(D, {Progress})
        Else
            pgbProgress.Value = Progress
        End If
    End Sub

    Private Sub StartRenaming()
        Try
            SetProgress(pgbProgress.Minimum)
            AddLine("Starting renaming process: " & Now.ToShortTimeString)

            If Filenames.Count = 0 Then
                AddLine("No files to rename")
                Exit Sub
            End If

            AddLine("Checking for duplicate filenames...")
            SetStatus("Checking for duplicate filenames...")

            If Not CheckForDuplicates() Then
                AddLine("No duplicates")
            Else
                AddLine("Duplicates found! Aborting!")
                FinishedRenaming()
                Exit Sub
            End If

            SetStatus("Renaming files...")
            AddLine("Renaming files...")
            RenameFiles()
        Catch ex As Threading.ThreadAbortException
            Exit Sub
        Catch ex As Exception
            AddLine("An error occured: " & ex.Message)
        End Try
        FinishedRenaming()
    End Sub

    Private Function CheckForDuplicates() As Boolean
        Dim P As Integer = 0
        For X As Integer = 0 To Filenames.Count - 1
            For Y As Integer = X + 1 To Filenames.Count
                'Console.WriteLine(WorkThread.ThreadState)
                If Filenames.Values(X) = Filenames.Values(Y) Then 'Duplicate found
                    Return True
                End If
            Next
            P += 1
            SetProgress(CInt(50 * P / Filenames.Count))
        Next
        Return False
    End Function

    Private Sub RenameFiles()
        Dim P As Integer = Filenames.Count
        For Each K As KeyValuePair(Of String, String) In Filenames
            Dim FromFile As String, ToFile As String
            FromFile = K.Key
            ToFile = K.Value
            If My.Computer.FileSystem.GetName(FromFile) <> ToFile Then
                AddLine("Renaming '" & FromFile & "' to '" & ToFile & "'...")
                Try
                    My.Computer.FileSystem.RenameFile(FromFile, ToFile)
                Catch ex As Exception
                    AddLine("Error: " & ex.Message)
                End Try
            Else
                AddLine("Skipping '" & FromFile & "' because the destination name is the same")
            End If
            P += 1
            SetProgress(CInt(50 * P / Filenames.Count))
        Next
    End Sub

    Private Sub FinishedRenaming()
        If Me.InvokeRequired Then
            Dim D As New FinishedRenamingCallback(AddressOf FinishedRenaming)
            Me.Invoke(D)
        Else
            pgbProgress.Value = pgbProgress.Maximum
            AddLine("Finished")
            lblStatus.Text = "Finished"
            cmdCancel.Text = "&Close"
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub

    Private Sub frmProgress_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WorkThread IsNot Nothing Then
            WorkThread.Abort() 'Stop the worker
            WorkThread.Join() 'Wait for it to finish
            WorkThread = Nothing
        End If
    End Sub

    Private Sub frmProgress_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim FromName As String, ToName As String

        cmdCancel.Text = "&Cancel"
        txtProgress.Text = ""
        Filenames.Clear()
        lblStatus.Text = "Building file list..."
        AddLine("Building file list...")
        pgbProgress.Value = 0
        For Each L As ListViewItem In frmMain.lsvFiles.Items
            Try
                FromName = My.Computer.FileSystem.CombinePath(CStr(L.Tag), L.SubItems(1).Text)
            Catch ex As Exception
                AddLine("Error with source filename '" & L.SubItems(1).Text & "'")
                Continue For
            End Try

            Try
                ToName = My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(CStr(L.Tag), L.SubItems(2).Text))
            Catch ex As Exception
                AddLine("Error with destination filename '" & L.SubItems(2).Text & "'")
                Continue For
            End Try
            Filenames.Add(FromName, ToName)
        Next

        Dim TS As New Threading.ThreadStart(AddressOf StartRenaming)

#If Not NOTHREAD Then
        WorkThread = New Threading.Thread(TS)
        WorkThread.Start()
#Else
        StartRenaming()
#End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class