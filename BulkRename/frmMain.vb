Public Class frmMain

    Private DragMouseDown As Boolean = False, DragStarted As Boolean = False

    ''' <summary>
    ''' Creates and adds a ListViewItem to lsvFiles based on a passed file name
    ''' </summary>
    ''' <param name="Path">(String) Path to the file to add</param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal Path As String)
        Dim Filename As String, ParentPath As String
        Filename = My.Computer.FileSystem.GetName(Path)
        ParentPath = My.Computer.FileSystem.GetParentPath(Path)
        Dim L As ListViewItem = lsvFiles.Items.Add((lsvFiles.Items.Count + 1).ToString)
        L.Tag = ParentPath
        L.SubItems.Add(Filename)
        L.SubItems.Add(Filename)

        tsslCount.Text = "Count: " & lsvFiles.Items.Count.ToString
    End Sub

    ''' <summary>
    ''' Deletes a ListViewItem from lsvFiles and updates the status bar
    ''' </summary>
    ''' <param name="ToDelete">(ListViewItem) Item to delete</param>
    ''' <remarks></remarks>
    Private Sub DeleteItem(ByVal ToDelete As ListViewItem)
        lsvFiles.Items.Remove(ToDelete)
        tsslPath.Text = ""
        tsslCount.Text = "Count: " & lsvFiles.Items.Count.ToString
    End Sub

    ''' <summary>
    ''' Tests if a point is within the boundaries of a ListViewSubItem
    ''' </summary>
    ''' <param name="SubItem">(ListViewSubItem) Item to test the boundaries of</param>
    ''' <param name="HitPoint">(Point) Coordinates to test if they are inside the boundries of SubItem</param>
    ''' <returns>(Boolean) True if HitPoint is within SubItem, false otherwise</returns>
    ''' <remarks></remarks>
    Private Function SubItemHitTest(ByVal SubItem As ListViewItem.ListViewSubItem, ByVal HitPoint As Point) As Boolean
        Return (HitPoint.X >= SubItem.Bounds.Left) And _
            (HitPoint.X <= SubItem.Bounds.Right) And _
            (HitPoint.Y >= SubItem.Bounds.Top) And _
            (HitPoint.Y <= SubItem.Bounds.Bottom)
    End Function

    ''' <summary>
    ''' Shows the edit textbox over the specified listview item's subitem
    ''' </summary>
    ''' <param name="SubItem">(ListViewItem.ListViewSubItem) Subitem to position the textbox over</param>
    ''' <remarks></remarks>
    Private Sub ShowEditBox(ByVal SubItem As ListViewItem.ListViewSubItem)
        txtEdit.Bounds = SubItem.Bounds
        txtEdit.Text = SubItem.Text
        If SelectNameOnlyToolStripMenuItem.Checked = True Then
            Dim DotAt = txtEdit.Text.LastIndexOf("."c)
            If DotAt > 0 Then
                txtEdit.SelectionStart = 0
                txtEdit.SelectionLength = DotAt
            Else
                txtEdit.SelectAll()
            End If
        Else
            txtEdit.SelectAll()
        End If
            txtEdit.Visible = True
            txtEdit.Focus()
    End Sub

    ''' <summary>
    ''' Appends a number to a filename, keeping the extension
    ''' </summary>
    ''' <param name="Filename">(String) Filename to inject the number into</param>
    ''' <param name="Number">(Integer) Number to inject into the filename</param>
    ''' <param name="Digits">[Optional] (Integer) Number of digits to pad the number into (defaults to 1)</param>
    ''' <returns>(String) Returns the filename with the number injected and the filename preserved</returns>
    ''' <remarks></remarks>
    Private Function MakeNumberedFile(ByVal Filename As String, ByVal Number As Integer, Optional ByVal Digits As Integer = 1) As String
        Dim Basename As String, Extension As String, CopyNumber As String
        Dim DotAt As Integer
        DotAt = Filename.LastIndexOf("."c)
        If DotAt > 0 Then
            Basename = Filename.Substring(0, DotAt)
            Extension = Filename.Substring(DotAt)
        Else
            Basename = Filename
            Extension = ""
        End If

        CopyNumber = Number.ToString
        If CopyNumber.Length < Digits Then
            CopyNumber.PadLeft(Digits, "0"c)
        End If
        Return Basename & " (" & CopyNumber & ")" & Extension
    End Function

    ''' <summary>
    ''' Saves settings to My.Settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveSettings()
        Dim Cols As New System.Collections.Specialized.StringCollection
        Dim OldWindowState As System.Windows.Forms.FormWindowState = Me.WindowState
        For Each C As ColumnHeader In lsvFiles.Columns
            Cols.Add(C.Text & "," & C.DisplayIndex.ToString & "," & C.Width.ToString)
        Next
        My.Settings.Columns = Cols

        My.Settings.WindowState = Me.WindowState
        Me.WindowState = FormWindowState.Normal
        My.Settings.WindowSize = Me.Size
        Me.WindowState = OldWindowState

        My.Settings.SelectNameOnly = SelectNameOnlyToolStripMenuItem.Checked

    End Sub

    ''' <summary>
    ''' Loads settings from My.Settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSettings()
        Me.Size = My.Settings.WindowSize
        Me.WindowState = CType(My.Settings.WindowState, System.Windows.Forms.FormWindowState)
        SelectNameOnlyToolStripMenuItem.Checked = My.Settings.SelectNameOnly

        For Each S As String In My.Settings.Columns
            Dim Parts() As String = Split(S, ",")
            If Parts.Length = 3 Then
                If Parts(0) = "Number" Then
                    chNumber.DisplayIndex = CInt(Val(Parts(1)))
                    chNumber.Width = CInt(Val(Parts(2)))
                ElseIf Parts(0) = "Original" Then
                    chOriginal.DisplayIndex = CInt(Val(Parts(1)))
                    chOriginal.Width = CInt(Val(Parts(2)))
                ElseIf Parts(0) = "New" Then
                    chNew.DisplayIndex = CInt(Val(Parts(1)))
                    chNew.Width = CInt(Val(Parts(2)))
                End If
            End If
        Next
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFilesToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .CheckFileExists = True
            .CheckPathExists = True
            .DereferenceLinks = True
            .Filter = "All Files|*.*"
            .Multiselect = True
            .ShowHelp = False
            .ShowReadOnly = False
            .SupportMultiDottedExtensions = True
            .Title = "Add Files"
            .ValidateNames = True
        End With
        If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each S As String In OFD.FileNames
                AddItem(S)
            Next
        End If
    End Sub

    Private Sub lsvFiles_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lsvFiles.ItemSelectionChanged
        If lsvFiles.SelectedItems.Count = 1 Then
            'Only one file selected, show the name
            tsslPath.Text = CStr(e.Item.Tag)
        Else
            'More than one item, show a placeholder string
            tsslPath.Text = "(multiple files selected)"
        End If
    End Sub

    Private Sub AddDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDirectoryToolStripMenuItem.Click
        Dim FBD As New FolderBrowserDialog
        With FBD
            .Description = "Select Folder"
            .ShowNewFolderButton = False
        End With
        If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim FilesList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            Try
                FilesList = My.Computer.FileSystem.GetFiles(FBD.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly)
            Catch ex As Exception
                MsgBox("Error getting files: " & ex.Message, MsgBoxStyle.Exclamation, "Error Getting Files")
                Exit Sub
            End Try
            For Each S As String In FilesList
                AddItem(S)
            Next
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If lsvFiles.SelectedItems Is Nothing OrElse lsvFiles.SelectedItems.Count = 0 Then Exit Sub
        For Each L As ListViewItem In lsvFiles.SelectedItems
            DeleteItem(L)
        Next
    End Sub

    Private Sub RevertNamesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevertNamesToolStripMenuItem.Click
        If lsvFiles.Items Is Nothing OrElse lsvFiles.Items.Count = 0 Then Exit Sub
        For Each L As ListViewItem In lsvFiles.Items
            L.SubItems(2).Text = L.SubItems(1).Text
        Next
    End Sub

    Private Sub ClearListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearListToolStripMenuItem.Click
        If lsvFiles.Items Is Nothing OrElse lsvFiles.Items.Count = 0 Then Exit Sub
        If MsgBox("Are you sure you want to clear the list?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Clear List?") = MsgBoxResult.Yes Then
            lsvFiles.Items.Clear()
            DeleteToolStripMenuItem.Enabled = False
            ChangeCaseToolStripMenuItem.Enabled = False
            tsslCount.Text = "Count: 0"
            tsslPath.Text = ""
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        If lsvFiles.Items Is Nothing OrElse lsvFiles.Items.Count = 0 Then Exit Sub

        lsvFiles.SelectedIndices.Clear()
        For Each L As ListViewItem In lsvFiles.Items
            lsvFiles.SelectedIndices.Add(L.Index)
        Next
    End Sub

    Private Sub lsvFiles_KeyDown(sender As Object, e As KeyEventArgs) Handles lsvFiles.KeyDown
        If (e.Modifiers = Keys.None) And (e.KeyCode = Keys.Delete) Then
            DeleteToolStripMenuItem.PerformClick()
            e.Handled = True
            e.SuppressKeyPress = True
        ElseIf (e.Modifiers = Keys.Control) And (e.KeyCode = Keys.A) Then
            SelectAllToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub lsvFiles_MouseClick(sender As Object, e As MouseEventArgs) Handles lsvFiles.MouseClick
        Dim CurSubItem As ListViewItem.ListViewSubItem = lsvFiles.SelectedItems(0).SubItems(2)
        If lsvFiles.SelectedItems.Count > 0 Then
            If SubItemHitTest(CurSubItem, e.Location) Then
                ShowEditBox(CurSubItem)
            End If
        End If
    End Sub

    Private Sub txtEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEdit.KeyDown
        If e.Modifiers = Keys.None Then
            If e.KeyCode = Keys.Escape Then
                txtEdit.CausesValidation = False
                e.Handled = True
            ElseIf (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Return) Or (e.KeyCode = Keys.Tab) Then
                txtEdit.CausesValidation = True
                e.Handled = True
            End If
        End If

        If e.Handled Then
            e.SuppressKeyPress = True
            lsvFiles.Focus()
        End If
    End Sub

    Private Sub txtEdit_Leave(sender As Object, e As EventArgs) Handles txtEdit.Leave
        'Hide the control when it loses focus
        txtEdit.Visible = False
    End Sub

    Private Sub frmMain_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim Filenames() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If Filenames Is Nothing OrElse Filenames.Count = 0 Then Exit Sub
            For Each S As String In Filenames
                If Not CBool(My.Computer.FileSystem.GetFileInfo(S).Attributes And IO.FileAttributes.Directory) Then
                    AddItem(S)
                Else
                    For Each Filename As String In My.Computer.FileSystem.GetFiles(S, FileIO.SearchOption.SearchTopLevelOnly)
                        AddItem(Filename)
                    Next
                End If

            Next
        End If
    End Sub

    Private Sub frmMain_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        SaveSettings()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEdit.Parent = lsvFiles 'Set the edit textbox to be a child of the listview so that it will be positioned correctly
        LoadSettings()
    End Sub

    Private Sub txtEdit_Validated(sender As Object, e As EventArgs) Handles txtEdit.Validated
        'Set the subitem text to the textbox text
        If lsvFiles.SelectedItems Is Nothing Then Exit Sub
        If lsvFiles.SelectedItems.Count = 0 Then
            Exit Sub
        ElseIf lsvFiles.SelectedItems.Count = 1 Then
            lsvFiles.SelectedItems(0).SubItems(2).Text = txtEdit.Text
        Else
            lsvFiles.SelectedItems(0).SubItems(2).Text = txtEdit.Text
            For I As Integer = 1 To lsvFiles.SelectedItems.Count - 1
                lsvFiles.SelectedItems(I).SubItems(2).Text = MakeNumberedFile(txtEdit.Text, I)
            Next
        End If
    End Sub

    Private Sub SetNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetNameToolStripMenuItem.Click
        If lsvFiles.FocusedItem IsNot Nothing Then ShowEditBox(lsvFiles.FocusedItem.SubItems(2))
    End Sub

    Private Sub RenameFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameFilesToolStripMenuItem.Click
        If lsvFiles.Items Is Nothing OrElse lsvFiles.Items.Count = 0 Then Exit Sub
        lsvFiles.Focus() 'Set focus to make sure the last edit was saved
        frmProgress.ShowDialog(Me)
    End Sub

    Private Sub UPPERCASEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPPERCASEToolStripMenuItem.Click
        If lsvFiles.SelectedItems Is Nothing OrElse lsvFiles.SelectedItems.Count = 0 Then Exit Sub
        For Each L As ListViewItem In lsvFiles.SelectedItems
            L.SubItems(2).Text = L.SubItems(2).Text.ToUpper()
        Next
    End Sub

    Private Sub LowercaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowercaseToolStripMenuItem.Click
        If lsvFiles.SelectedItems Is Nothing OrElse lsvFiles.SelectedItems.Count = 0 Then Exit Sub
        For Each L As ListViewItem In lsvFiles.SelectedItems
            L.SubItems(2).Text = L.SubItems(2).Text.ToLower()
        Next
    End Sub

    Private Sub ProperCaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProperCaseToolStripMenuItem.Click
        If lsvFiles.SelectedItems Is Nothing OrElse lsvFiles.SelectedItems.Count = 0 Then Exit Sub
        For Each L As ListViewItem In lsvFiles.SelectedItems
            Dim Parts() As String = Split(L.SubItems(2).Text.ToLower(), " ")
            For I As Integer = 0 To Parts.Count - 1
                Parts(I) = Parts(I).Substring(0, 1).ToUpper & Parts(I).Substring(1)
            Next

            L.SubItems(2).Text = Join(Parts, " ")
        Next
    End Sub

    Private Sub lsvFiles_MouseDown(sender As Object, e As MouseEventArgs) Handles lsvFiles.MouseDown
        DragMouseDown = True
    End Sub

    Private Sub lsvFiles_MouseMove(sender As Object, e As MouseEventArgs) Handles lsvFiles.MouseMove
        If DragMouseDown AndAlso Not DragStarted Then
            If lsvFiles.SelectedItems IsNot Nothing AndAlso lsvFiles.SelectedItems.Count > 0 Then
                Dim Filenames(lsvFiles.SelectedItems.Count - 1) As String
                For I As Integer = 0 To lsvFiles.SelectedItems.Count - 1
                    Filenames(I) = My.Computer.FileSystem.CombinePath(CStr(lsvFiles.SelectedItems(I).Tag), lsvFiles.SelectedItems(I).SubItems(2).Text)
                    'Console.WriteLine("{0}: ""{1}""", I, Filenames(I))
                Next
                Dim DragData As New DataObject(DataFormats.FileDrop, Filenames)
                lsvFiles.DoDragDrop(DragData, DragDropEffects.All)
            End If
        End If
    End Sub

    Private Sub lsvFiles_MouseUp(sender As Object, e As MouseEventArgs) Handles lsvFiles.MouseUp
        DragMouseDown = False
        DragStarted = False
    End Sub

    Private Sub AppendTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppendTextToolStripMenuItem.Click
        If lsvFiles.SelectedItems Is Nothing OrElse lsvFiles.SelectedItems.Count = 0 Then Exit Sub
        Dim ToAppend As String = InputBox("Text to append to filenames", "Append Text")
        If ToAppend = "" Then Exit Sub
        For Each L As ListViewItem In lsvFiles.SelectedItems
            L.SubItems(2).Text = L.SubItems(2).Text & ToAppend
        Next
    End Sub

    Private Sub PrependTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrependTextToolStripMenuItem.Click
        If lsvFiles.SelectedItems Is Nothing OrElse lsvFiles.SelectedItems.Count = 0 Then Exit Sub
        Dim ToPrepend As String = InputBox("Text to prepend to filenames", "Prepend Text")
        If ToPrepend = "" Then Exit Sub
        For Each L As ListViewItem In lsvFiles.SelectedItems
            L.SubItems(2).Text = ToPrepend & L.SubItems(2).Text
        Next
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceToolStripMenuItem.Click
        'Show the find/replace window, do the work, blah blah blah
    End Sub
End Class
