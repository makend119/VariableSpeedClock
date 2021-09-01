<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows フォーム デザイナによって生成されたコード "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'この呼び出しは、Windows フォーム デザイナで必要です。
		InitializeComponent()
	End Sub
	'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows フォーム デザイナで必要です。
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents TxtLTime As System.Windows.Forms.TextBox
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents LblLTimeL As System.Windows.Forms.Label
    Public WithEvents LblRealTime As System.Windows.Forms.Label
    Public WithEvents LblLTime As System.Windows.Forms.Label
    Public WithEvents LblRealTimeL As System.Windows.Forms.Label
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblLTimeL = New System.Windows.Forms.Label()
        Me.LblRealTime = New System.Windows.Forms.Label()
        Me.LblLTime = New System.Windows.Forms.Label()
        Me.LblRealTimeL = New System.Windows.Forms.Label()
        Me.cMnuTS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsMiTSRead = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMiTSDisp = New System.Windows.Forms.ToolStripMenuItem()
        Me.TxtLTime = New System.Windows.Forms.TextBox()
        Me.TxtRTime = New System.Windows.Forms.TextBox()
        Me.TxtSpeed = New System.Windows.Forms.TextBox()
        Me.dgvTimeSchedule = New System.Windows.Forms.DataGridView()
        Me.clmRTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmLTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSpeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFlag = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colRplus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLPlus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMnuTSSet = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsMiTSRun = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMiTSExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnTmrSet = New System.Windows.Forms.Button()
        Me.btnTimeSchedule = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cDlgC = New System.Windows.Forms.ColorDialog()
        Me.cDlgFileOpen = New System.Windows.Forms.OpenFileDialog()
        Me.pbarTime = New System.Windows.Forms.ProgressBar()
        Me.cMnuTS.SuspendLayout()
        CType(Me.dgvTimeSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cMnuTSSet.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblLTimeL
        '
        Me.LblLTimeL.AutoSize = True
        Me.LblLTimeL.BackColor = System.Drawing.Color.White
        Me.LblLTimeL.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblLTimeL.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblLTimeL.ForeColor = System.Drawing.Color.Black
        Me.LblLTimeL.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LblLTimeL.Location = New System.Drawing.Point(0, 128)
        Me.LblLTimeL.Name = "LblLTimeL"
        Me.LblLTimeL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblLTimeL.Size = New System.Drawing.Size(426, 97)
        Me.LblLTimeL.TabIndex = 3
        Me.LblLTimeL.Text = "演習時刻"
        Me.LblLTimeL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.LblLTimeL, "ダブルクリックで終了")
        '
        'LblRealTime
        '
        Me.LblRealTime.AutoSize = True
        Me.LblRealTime.BackColor = System.Drawing.Color.White
        Me.LblRealTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblRealTime.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblRealTime.ForeColor = System.Drawing.Color.Blue
        Me.LblRealTime.Location = New System.Drawing.Point(306, 0)
        Me.LblRealTime.Name = "LblRealTime"
        Me.LblRealTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblRealTime.Size = New System.Drawing.Size(508, 97)
        Me.LblRealTime.TabIndex = 2
        Me.LblRealTime.Text = "13:30:00"
        Me.ToolTip1.SetToolTip(Me.LblRealTime, "ダブルクリックで表示色変更ウィンドウ表示")
        '
        'LblLTime
        '
        Me.LblLTime.AutoSize = True
        Me.LblLTime.BackColor = System.Drawing.Color.White
        Me.LblLTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblLTime.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 180.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblLTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblLTime.Location = New System.Drawing.Point(-23, 244)
        Me.LblLTime.Name = "LblLTime"
        Me.LblLTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblLTime.Size = New System.Drawing.Size(1276, 240)
        Me.LblLTime.TabIndex = 1
        Me.LblLTime.Text = "23:59:00"
        Me.ToolTip1.SetToolTip(Me.LblLTime, "ダブルクリックで表示色変更ウィンドウ表示")
        '
        'LblRealTimeL
        '
        Me.LblRealTimeL.AutoSize = True
        Me.LblRealTimeL.BackColor = System.Drawing.Color.White
        Me.LblRealTimeL.ContextMenuStrip = Me.cMnuTS
        Me.LblRealTimeL.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblRealTimeL.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblRealTimeL.ForeColor = System.Drawing.Color.Blue
        Me.LblRealTimeL.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LblRealTimeL.Location = New System.Drawing.Point(0, 0)
        Me.LblRealTimeL.Name = "LblRealTimeL"
        Me.LblRealTimeL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblRealTimeL.Size = New System.Drawing.Size(330, 97)
        Me.LblRealTimeL.TabIndex = 0
        Me.LblRealTimeL.Text = "実時刻"
        Me.LblRealTimeL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.LblRealTimeL, "ダブルクリックで基準時刻変更")
        '
        'cMnuTS
        '
        Me.cMnuTS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMiTSRead, Me.tsMiTSDisp})
        Me.cMnuTS.Name = "cMnuTS"
        Me.cMnuTS.ShowImageMargin = False
        Me.cMnuTS.Size = New System.Drawing.Size(174, 48)
        '
        'tsMiTSRead
        '
        Me.tsMiTSRead.Name = "tsMiTSRead"
        Me.tsMiTSRead.Size = New System.Drawing.Size(173, 22)
        Me.tsMiTSRead.Text = "時間スケジュール読み込み"
        '
        'tsMiTSDisp
        '
        Me.tsMiTSDisp.Name = "tsMiTSDisp"
        Me.tsMiTSDisp.Size = New System.Drawing.Size(173, 22)
        Me.tsMiTSDisp.Text = "時間スケジュール表示"
        '
        'TxtLTime
        '
        Me.TxtLTime.AcceptsReturn = True
        Me.TxtLTime.BackColor = System.Drawing.SystemColors.Window
        Me.TxtLTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtLTime.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtLTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtLTime.Location = New System.Drawing.Point(463, 167)
        Me.TxtLTime.MaxLength = 0
        Me.TxtLTime.Name = "TxtLTime"
        Me.TxtLTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtLTime.Size = New System.Drawing.Size(353, 34)
        Me.TxtLTime.TabIndex = 2
        Me.TxtLTime.Text = "2012/02/10 13:30:00"
        Me.ToolTip1.SetToolTip(Me.TxtLTime, "演習時刻の基準日時を代入")
        Me.TxtLTime.Visible = False
        '
        'TxtRTime
        '
        Me.TxtRTime.AcceptsReturn = True
        Me.TxtRTime.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRTime.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtRTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtRTime.Location = New System.Drawing.Point(463, 127)
        Me.TxtRTime.MaxLength = 0
        Me.TxtRTime.Name = "TxtRTime"
        Me.TxtRTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtRTime.Size = New System.Drawing.Size(353, 34)
        Me.TxtRTime.TabIndex = 1
        Me.TxtRTime.Text = "2012/02/10 13:30:00"
        Me.ToolTip1.SetToolTip(Me.TxtRTime, "実時刻の基準日時を代入")
        Me.TxtRTime.Visible = False
        '
        'TxtSpeed
        '
        Me.TxtSpeed.AcceptsReturn = True
        Me.TxtSpeed.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSpeed.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSpeed.Font = New System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtSpeed.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtSpeed.Location = New System.Drawing.Point(463, 207)
        Me.TxtSpeed.MaxLength = 0
        Me.TxtSpeed.Name = "TxtSpeed"
        Me.TxtSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtSpeed.Size = New System.Drawing.Size(148, 34)
        Me.TxtSpeed.TabIndex = 3
        Me.TxtSpeed.Text = "3"
        Me.ToolTip1.SetToolTip(Me.TxtSpeed, "速度の倍率を代入(小数点，分数可）")
        Me.TxtSpeed.Visible = False
        '
        'dgvTimeSchedule
        '
        Me.dgvTimeSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmRTime, Me.clmLTime, Me.clmSpeed, Me.clmFlag, Me.colRplus, Me.ColLPlus})
        Me.dgvTimeSchedule.ContextMenuStrip = Me.cMnuTSSet
        Me.dgvTimeSchedule.Location = New System.Drawing.Point(159, 262)
        Me.dgvTimeSchedule.Name = "dgvTimeSchedule"
        Me.dgvTimeSchedule.RowTemplate.Height = 21
        Me.dgvTimeSchedule.Size = New System.Drawing.Size(492, 127)
        Me.dgvTimeSchedule.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.dgvTimeSchedule, "時間スケジュール表を編集、ダブルクリックでタイマー再開")
        Me.dgvTimeSchedule.Visible = False
        '
        'clmRTime
        '
        Me.clmRTime.FillWeight = 150.0!
        Me.clmRTime.HeaderText = "実時刻"
        Me.clmRTime.Name = "clmRTime"
        Me.clmRTime.ToolTipText = "実時刻の基準を設定"
        Me.clmRTime.Width = 150
        '
        'clmLTime
        '
        Me.clmLTime.FillWeight = 150.0!
        Me.clmLTime.HeaderText = "演習時刻"
        Me.clmLTime.Name = "clmLTime"
        Me.clmLTime.ToolTipText = "演習時刻の基準を設定"
        Me.clmLTime.Width = 150
        '
        'clmSpeed
        '
        Me.clmSpeed.FillWeight = 90.0!
        Me.clmSpeed.HeaderText = "速度の倍率"
        Me.clmSpeed.Name = "clmSpeed"
        Me.clmSpeed.ToolTipText = "速度の倍率を設定"
        Me.clmSpeed.Width = 90
        '
        'clmFlag
        '
        Me.clmFlag.FillWeight = 40.0!
        Me.clmFlag.HeaderText = "Flag"
        Me.clmFlag.Name = "clmFlag"
        Me.clmFlag.ReadOnly = True
        Me.clmFlag.ToolTipText = "True：評価済み False：未評価"
        Me.clmFlag.Width = 40
        '
        'colRplus
        '
        Me.colRplus.FillWeight = 70.0!
        Me.colRplus.HeaderText = ""
        Me.colRplus.Name = "colRplus"
        Me.colRplus.ReadOnly = True
        Me.colRplus.ToolTipText = "実時刻がプラス標記の場合"
        Me.colRplus.Width = 70
        '
        'ColLPlus
        '
        Me.ColLPlus.FillWeight = 70.0!
        Me.ColLPlus.HeaderText = ""
        Me.ColLPlus.Name = "ColLPlus"
        Me.ColLPlus.ReadOnly = True
        Me.ColLPlus.ToolTipText = "演習時刻がプラス標記の場合"
        Me.ColLPlus.Width = 70
        '
        'cMnuTSSet
        '
        Me.cMnuTSSet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMiTSRun, Me.tsMiTSExit})
        Me.cMnuTSSet.Name = "cMnuTSSet"
        Me.cMnuTSSet.Size = New System.Drawing.Size(121, 48)
        '
        'tsMiTSRun
        '
        Me.tsMiTSRun.Name = "tsMiTSRun"
        Me.tsMiTSRun.Size = New System.Drawing.Size(120, 22)
        Me.tsMiTSRun.Text = "実行"
        '
        'tsMiTSExit
        '
        Me.tsMiTSExit.Name = "tsMiTSExit"
        Me.tsMiTSExit.Size = New System.Drawing.Size(120, 22)
        Me.tsMiTSExit.Text = "キャンセル"
        '
        'btnTmrSet
        '
        Me.btnTmrSet.Location = New System.Drawing.Point(725, 209)
        Me.btnTmrSet.Name = "btnTmrSet"
        Me.btnTmrSet.Size = New System.Drawing.Size(91, 31)
        Me.btnTmrSet.TabIndex = 6
        Me.btnTmrSet.Text = "Schedule Disp"
        Me.ToolTip1.SetToolTip(Me.btnTmrSet, "時間スケジュール表を表示")
        Me.btnTmrSet.UseVisualStyleBackColor = True
        Me.btnTmrSet.Visible = False
        '
        'btnTimeSchedule
        '
        Me.btnTimeSchedule.Location = New System.Drawing.Point(628, 209)
        Me.btnTimeSchedule.Name = "btnTimeSchedule"
        Me.btnTimeSchedule.Size = New System.Drawing.Size(91, 31)
        Me.btnTimeSchedule.TabIndex = 4
        Me.btnTimeSchedule.Text = "Time Schedule"
        Me.ToolTip1.SetToolTip(Me.btnTimeSchedule, "時間スケジュールを設定")
        Me.btnTimeSchedule.UseVisualStyleBackColor = True
        Me.btnTimeSchedule.Visible = False
        '
        'Timer1
        '
        '
        'cDlgFileOpen
        '
        Me.cDlgFileOpen.FileName = "OpenFileDialog1"
        '
        'pbarTime
        '
        Me.pbarTime.Location = New System.Drawing.Point(323, 100)
        Me.pbarTime.Name = "pbarTime"
        Me.pbarTime.Size = New System.Drawing.Size(402, 10)
        Me.pbarTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbarTime.TabIndex = 8
        Me.pbarTime.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(821, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.pbarTime)
        Me.Controls.Add(Me.btnTmrSet)
        Me.Controls.Add(Me.dgvTimeSchedule)
        Me.Controls.Add(Me.btnTimeSchedule)
        Me.Controls.Add(Me.TxtSpeed)
        Me.Controls.Add(Me.TxtRTime)
        Me.Controls.Add(Me.TxtLTime)
        Me.Controls.Add(Me.LblLTimeL)
        Me.Controls.Add(Me.LblRealTime)
        Me.Controls.Add(Me.LblLTime)
        Me.Controls.Add(Me.LblRealTimeL)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, 4)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolTip1.SetToolTip(Me, "ダブルクリックで背景色変更")
        Me.cMnuTS.ResumeLayout(False)
        CType(Me.dgvTimeSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cMnuTSSet.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cDlgC As System.Windows.Forms.ColorDialog
    Public WithEvents TxtRTime As System.Windows.Forms.TextBox
    Public WithEvents TxtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents cDlgFileOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgvTimeSchedule As System.Windows.Forms.DataGridView
    Friend WithEvents btnTmrSet As System.Windows.Forms.Button
    Friend WithEvents btnTimeSchedule As System.Windows.Forms.Button
    Friend WithEvents clmRTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmLTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSpeed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFlag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colRplus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLPlus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbarTime As System.Windows.Forms.ProgressBar
    Friend WithEvents cMnuTS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsMiTSRead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMiTSDisp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cMnuTSSet As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsMiTSRun As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMiTSExit As System.Windows.Forms.ToolStripMenuItem
#End Region
End Class