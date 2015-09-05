<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevertNamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransformationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPPERCASEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowercaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProperCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppendTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrependTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tsslCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslPath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lsvFiles = New System.Windows.Forms.ListView()
        Me.chNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chOriginal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNew = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtEdit = New System.Windows.Forms.TextBox()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectNameOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMain.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.RenameToolStripMenuItem, Me.TransformationsToolStripMenuItem})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(519, 24)
        Me.msMain.TabIndex = 0
        Me.msMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddFilesToolStripMenuItem, Me.AddDirectoryToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'AddFilesToolStripMenuItem
        '
        Me.AddFilesToolStripMenuItem.Name = "AddFilesToolStripMenuItem"
        Me.AddFilesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AddFilesToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AddFilesToolStripMenuItem.Text = "Add &Files"
        '
        'AddDirectoryToolStripMenuItem
        '
        Me.AddDirectoryToolStripMenuItem.Name = "AddDirectoryToolStripMenuItem"
        Me.AddDirectoryToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.AddDirectoryToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AddDirectoryToolStripMenuItem.Text = "Add &Directory"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(186, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.SelectAllToolStripMenuItem, Me.SetNameToolStripMenuItem, Me.ToolStripMenuItem2, Me.ClearListToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SelectAllToolStripMenuItem.Text = "&Select All"
        '
        'SetNameToolStripMenuItem
        '
        Me.SetNameToolStripMenuItem.Name = "SetNameToolStripMenuItem"
        Me.SetNameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SetNameToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SetNameToolStripMenuItem.Text = "Set &Name"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(141, 6)
        '
        'ClearListToolStripMenuItem
        '
        Me.ClearListToolStripMenuItem.Name = "ClearListToolStripMenuItem"
        Me.ClearListToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ClearListToolStripMenuItem.Text = "Clear &List"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenameFilesToolStripMenuItem, Me.RevertNamesToolStripMenuItem, Me.ToolStripMenuItem3, Me.SelectNameOnlyToolStripMenuItem})
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.RenameToolStripMenuItem.Text = "&Rename"
        '
        'RenameFilesToolStripMenuItem
        '
        Me.RenameFilesToolStripMenuItem.Name = "RenameFilesToolStripMenuItem"
        Me.RenameFilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RenameFilesToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RenameFilesToolStripMenuItem.Text = "&Rename Files"
        '
        'RevertNamesToolStripMenuItem
        '
        Me.RevertNamesToolStripMenuItem.Name = "RevertNamesToolStripMenuItem"
        Me.RevertNamesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.RevertNamesToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RevertNamesToolStripMenuItem.Text = "Re&vert Names"
        '
        'TransformationsToolStripMenuItem
        '
        Me.TransformationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeCaseToolStripMenuItem, Me.AppendTextToolStripMenuItem, Me.PrependTextToolStripMenuItem, Me.ReplaceToolStripMenuItem})
        Me.TransformationsToolStripMenuItem.Name = "TransformationsToolStripMenuItem"
        Me.TransformationsToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.TransformationsToolStripMenuItem.Text = "&Transformations"
        '
        'ChangeCaseToolStripMenuItem
        '
        Me.ChangeCaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UPPERCASEToolStripMenuItem, Me.LowercaseToolStripMenuItem, Me.ProperCaseToolStripMenuItem})
        Me.ChangeCaseToolStripMenuItem.Name = "ChangeCaseToolStripMenuItem"
        Me.ChangeCaseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ChangeCaseToolStripMenuItem.Text = "&Change Case"
        '
        'UPPERCASEToolStripMenuItem
        '
        Me.UPPERCASEToolStripMenuItem.Name = "UPPERCASEToolStripMenuItem"
        Me.UPPERCASEToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.UPPERCASEToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.UPPERCASEToolStripMenuItem.Text = "&UPPERCASE"
        '
        'LowercaseToolStripMenuItem
        '
        Me.LowercaseToolStripMenuItem.Name = "LowercaseToolStripMenuItem"
        Me.LowercaseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LowercaseToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.LowercaseToolStripMenuItem.Text = "&lowercase"
        '
        'ProperCaseToolStripMenuItem
        '
        Me.ProperCaseToolStripMenuItem.Name = "ProperCaseToolStripMenuItem"
        Me.ProperCaseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ProperCaseToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ProperCaseToolStripMenuItem.Text = "&Proper Case"
        '
        'AppendTextToolStripMenuItem
        '
        Me.AppendTextToolStripMenuItem.Name = "AppendTextToolStripMenuItem"
        Me.AppendTextToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AppendTextToolStripMenuItem.Text = "&Append Text"
        '
        'PrependTextToolStripMenuItem
        '
        Me.PrependTextToolStripMenuItem.Name = "PrependTextToolStripMenuItem"
        Me.PrependTextToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrependTextToolStripMenuItem.Text = "&Prepend Text"
        '
        'ReplaceToolStripMenuItem
        '
        Me.ReplaceToolStripMenuItem.Enabled = False
        Me.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem"
        Me.ReplaceToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ReplaceToolStripMenuItem.Text = "&Replace"
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslCount, Me.tsslPath})
        Me.ssStatus.Location = New System.Drawing.Point(0, 240)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(519, 22)
        Me.ssStatus.TabIndex = 2
        '
        'tsslCount
        '
        Me.tsslCount.Name = "tsslCount"
        Me.tsslCount.Size = New System.Drawing.Size(52, 17)
        Me.tsslCount.Text = "Count: 0"
        '
        'tsslPath
        '
        Me.tsslPath.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.tsslPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslPath.Name = "tsslPath"
        Me.tsslPath.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.tsslPath.Size = New System.Drawing.Size(455, 17)
        Me.tsslPath.Spring = True
        Me.tsslPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lsvFiles
        '
        Me.lsvFiles.AllowColumnReorder = True
        Me.lsvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNumber, Me.chOriginal, Me.chNew})
        Me.lsvFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvFiles.FullRowSelect = True
        Me.lsvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvFiles.HideSelection = False
        Me.lsvFiles.LabelWrap = False
        Me.lsvFiles.Location = New System.Drawing.Point(0, 24)
        Me.lsvFiles.Name = "lsvFiles"
        Me.lsvFiles.ShowGroups = False
        Me.lsvFiles.ShowItemToolTips = True
        Me.lsvFiles.Size = New System.Drawing.Size(519, 216)
        Me.lsvFiles.TabIndex = 3
        Me.lsvFiles.UseCompatibleStateImageBehavior = False
        Me.lsvFiles.View = System.Windows.Forms.View.Details
        '
        'chNumber
        '
        Me.chNumber.Text = "Number"
        Me.chNumber.Width = 25
        '
        'chOriginal
        '
        Me.chOriginal.Text = "Original"
        Me.chOriginal.Width = 245
        '
        'chNew
        '
        Me.chNew.Text = "New"
        Me.chNew.Width = 245
        '
        'txtEdit
        '
        Me.txtEdit.Location = New System.Drawing.Point(191, -2)
        Me.txtEdit.MaxLength = 255
        Me.txtEdit.Name = "txtEdit"
        Me.txtEdit.Size = New System.Drawing.Size(100, 20)
        Me.txtEdit.TabIndex = 4
        Me.txtEdit.Visible = False
        Me.txtEdit.WordWrap = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(169, 6)
        '
        'SelectNameOnlyToolStripMenuItem
        '
        Me.SelectNameOnlyToolStripMenuItem.Checked = True
        Me.SelectNameOnlyToolStripMenuItem.CheckOnClick = True
        Me.SelectNameOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SelectNameOnlyToolStripMenuItem.Name = "SelectNameOnlyToolStripMenuItem"
        Me.SelectNameOnlyToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SelectNameOnlyToolStripMenuItem.Text = "Select Name Only"
        Me.SelectNameOnlyToolStripMenuItem.ToolTipText = "When renaming a file, only the name will be highlighted (not the extension)"
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 262)
        Me.Controls.Add(Me.lsvFiles)
        Me.Controls.Add(Me.txtEdit)
        Me.Controls.Add(Me.msMain)
        Me.Controls.Add(Me.ssStatus)
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmMain"
        Me.Text = "Bulk Rename"
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevertNamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslPath As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lsvFiles As System.Windows.Forms.ListView
    Friend WithEvents chNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents chOriginal As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNew As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClearListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEdit As System.Windows.Forms.TextBox
    Friend WithEvents TransformationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeCaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPPERCASEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LowercaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProperCaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrependTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectNameOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
