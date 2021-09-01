Option Strict Off
Option Explicit On
Option Compare Binary

Imports Microsoft.Win32
Imports str = Microsoft.VisualBasic.Strings
Imports VB = Microsoft.VisualBasic

Friend Class Form1
    Inherits System.Windows.Forms.Form
    '// const ///////////////////////////////////////////////////////////////////
    '// type ////////////////////////////////////////////////////////////////////
    '// module //////////////////////////////////////////////////////////////////
    '�������g��Assembly���擾
    '// dim /////////////////////////////////////////////////////////////////////
    Private objMutex As System.Threading.Mutex  '�d���N���m�F�p
    Dim rTimeFormat As String = "hh:nn"     '�������\���t�H�[�}�b�g
    Dim lTimeFormat As String = "hh:nn"     '���K�����\���t�H�[�}�b�g

    Dim rTm As Date                 '������
    Dim lTm As Date                 '���K����
    Dim spdP As Double              '�{���i���q�j
    Dim spdPd As Double             '�{���i����j

    Dim tsFlg As Boolean = False    '�������X�g�g�p True�F���� False�F���Ȃ�
    Dim tsIdx As Integer = -1       '���Ɏg�p����s�i-1�F�g�p�ł���s�������Ȃ����ꍇ�j
    Dim tsDate As Date              '���̊����
    Dim tspDate As Date             '

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �{���̕����W�L����
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ChgspdP(ByVal s As String) As Boolean
        spdP = 1.0
        spdPd = 1.0
        If IsNumeric(s) Then
            spdP = CDbl(s)
            ChgspdP = True
        Else
            Dim sts As String, ste As String
            Dim l As Int16
            l = str.InStr(s, "/")
            If l <> 0 Then
                sts = str.Left(s, l - 1)
                ste = str.Mid(s, l + 1)
                If IsNumeric(sts) And IsNumeric(ste) Then
                    spdP = CDbl(sts)
                    spdPd = CDbl(ste)
                    ChgspdP = True
                Else
                    ChgspdP = False
                End If
            Else
                ChgspdP = False
            End If
        End If
    End Function

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �{���̕����W�L�`�F�b�N
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ChkspdP(ByVal s As String) As Boolean
        If s = "" Then
            ChkspdP = False
        ElseIf IsNumeric(s) Then
            ChkspdP = True
        Else
            Dim sts As String, ste As String
            Dim l As Int16
            l = str.InStr(s, "/")
            If l <> 0 Then
                sts = str.Left(s, l - 1)
                ste = str.Mid(s, l + 1)
                If IsNumeric(sts) And IsNumeric(ste) Then
                    ChkspdP = True
                Else
                    ChkspdP = False
                End If
            Else
                ChkspdP = False
            End If
        End If
    End Function

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �F�ݒ�t�H�[�}�b�g�`�F�b�N
    ''' </summary>
    ''' <param name="c"></param>
    ''' <param name="dc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetColor(ByVal c As String, ByVal dc As System.Drawing.Color) As System.Drawing.Color
        Dim cc As String
        If IsNumeric(c) Then
            cc = str.Right("000000" & Hex(c), 6)
            cc = Mid(cc, 5, 2) & Mid(cc, 3, 2) & str.Left(cc, 2)
            SetColor = ColorTranslator.FromWin32(cc)
        ElseIf str.Left(c, 2) = "0x" & IsNumeric("&h" & Mid(c, 3)) Then     '0xRRGGBB -> aabbggrr
            cc = str.Right("000000" & Mid(c, 3), 6)
            cc = Mid(cc, 5, 2) & Mid(cc, 3, 2) & str.Left(cc, 2)
            SetColor = ColorTranslator.FromWin32("&h" & cc)
        ElseIf c <> "" Then
            SetColor = Color.FromName(c)
        Else
            SetColor = dc
        End If
    End Function

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' aabbggrr -> 0xRRGGBB�ϊ�
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ChgColor(ByVal c As String) As String
        If IsNumeric("&h" & c) Then     'aabbggrr -> 0xRRGGBB
            ChgColor = "0x" & UCase(Mid(c, 7, 2) & Mid(c, 5, 2) & Mid(c, 3, 2))
        Else
            ChgColor = c
        End If
    End Function

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �w�i�F�ݒ�
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub Form1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.DoubleClick
        Timer1.Enabled = False
        'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
        With cDlgC
            '.Title = "�w�i�F�ύX"
            .Color = Me.BackColor
            .ShowDialog()
            Me.BackColor = .Color
            LblLTime.BackColor = .Color
            LblLTimeL.BackColor = .Color
            LblRealTime.BackColor = .Color
            LblRealTimeL.BackColor = .Color
        End With
        Timer1.Enabled = True
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���K�����\���F�ύX
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub LblLTime_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LblLTime.DoubleClick
        Timer1.Enabled = False
        'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
        With cDlgC
            .Color = LblLTime.ForeColor
            '.Title = "���K�����\���F�ύX"
            .ShowDialog()
            LblLTime.ForeColor = .Color
            LblLTimeL.ForeColor = .Color
        End With
        Timer1.Enabled = True
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �������\���F�ύX
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub LblRealTime_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LblRealTime.DoubleClick
        Timer1.Enabled = False
        'UPGRADE_WARNING: CommonDialog �ϐ��̓A�b�v�O���[�h����܂���ł��� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"' ���N���b�N���Ă��������B
        With cDlgC
            .Color = LblRealTime.ForeColor
            '.Title = "�������\���F�ύX"
            .ShowDialog()
            LblRealTime.ForeColor = .Color
            LblRealTimeL.ForeColor = .Color
        End With
        Timer1.Enabled = True
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objMutex.Close()
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim l As Int16

        objMutex = New System.Threading.Mutex(False, "Variable Speed Clock")
        If objMutex.WaitOne(0, False) = False Then
            MessageBox.Show("���ɋN�����Ă��܂��B")
            Me.Close()
        End If
        tsDate = Now
        Dim key As RegistryKey = Registry.CurrentUser
        'key = key.OpenSubKey("software\VariableSpeedClock")
        key = key.CreateSubKey("software\VariableSpeedClock")

        On Error Resume Next

        Dim dtWidth As String = CType(key.GetValue("FormWidth"), String)
        Dim dtHeight As String = CType(key.GetValue("FormHeight"), String)
        If IsNumeric(dtWidth) Then Me.Width = CDbl(dtWidth)
        If IsNumeric(dtHeight) Then Me.Height = CDbl(dtHeight)

        Dim dtrTimeFormat As String = CType(key.GetValue("rTimeFormat"), String)
        If dtrTimeFormat <> "" Then
            rTimeFormat = dtrTimeFormat
        End If
        Dim dtlTimeFormat As String = CType(key.GetValue("lTimeFormat"), String)
        If dtlTimeFormat <> "" Then
            lTimeFormat = dtlTimeFormat
        End If

        Dim dtLRTLeft As String = CType(key.GetValue("lrtLeft"), String)
        Dim dtLRTTop As String = CType(key.GetValue("lrtTop"), String)
        If IsNumeric(dtLRTLeft) Then LblRealTime.Left = CDbl(dtLRTLeft)
        If IsNumeric(dtLRTTop) Then LblRealTime.Top = CDbl(dtLRTTop)

        Dim dtLRTFont As String = CType(key.GetValue("lrtFont"), String)
        If dtLRTFont <> "" Then
            l = InStr(dtLRTFont, ",")
            LblRealTime.Font = New Font(Mid(dtLRTFont, 1, l - 1), Mid(dtLRTFont, l + 1))
        End If
        Dim dtLRTlLeft As String = CType(key.GetValue("lrtlLeft"), String)
        Dim dtLRTlTop As String = CType(key.GetValue("lrtlTop"), String)
        If IsNumeric(dtLRTlLeft) Then LblRealTimeL.Left = CDbl(dtLRTlLeft)
        If IsNumeric(dtLRTlTop) Then LblRealTimeL.Top = CDbl(dtLRTlTop)
        Dim dtLRTlFont As String = CType(key.GetValue("lrtlFont"), String)
        If dtLRTlFont <> "" Then
            l = InStr(dtLRTlFont, ",")
            LblRealTimeL.Font = New Font(Mid(dtLRTlFont, 1, l - 1), Mid(dtLRTlFont, l + 1))
        End If

        Dim dtLLTLeft As String = CType(key.GetValue("lltLeft"), String)
        Dim dtLLTTop As String = CType(key.GetValue("lltTop"), String)
        If IsNumeric(dtLLTLeft) Then LblLTime.Left = CDbl(dtLLTLeft)
        If IsNumeric(dtLLTTop) Then LblLTime.Top = CDbl(dtLLTTop)
        Dim dtLLTFont As String = CType(key.GetValue("lltFont"), String)
        If dtLLTFont <> "" Then
            l = InStr(dtLLTFont, ",")
            LblLTime.Font = New Font(Mid(dtLLTFont, 1, l - 1), Mid(dtLLTFont, l + 1))
        End If
        Dim dtLLTlLeft As String = CType(key.GetValue("lltlLeft"), String)
        Dim dtLLTlTop As String = CType(key.GetValue("lltlTop"), String)
        If IsNumeric(dtLLTlLeft) Then LblLTimeL.Left = CDbl(dtLLTlLeft)
        If IsNumeric(dtLLTlTop) Then LblLTimeL.Top = CDbl(dtLLTlTop)
        Dim dtLLTlFont As String = CType(key.GetValue("lltlFont"), String)
        If dtLLTlFont <> "" Then
            l = InStr(dtLLTlFont, ",")
            LblLTimeL.Font = New Font(Mid(dtLLTlFont, 1, l - 1), Mid(dtLLTlFont, l + 1))
        End If

        Dim dtBc As String = CType(key.GetValue("BackColor"), String)
        'If IsNumeric(dtBc) Then
        '    Me.BackColor = ColorTranslator.FromWin32(dtBc)
        'ElseIf IsNumeric("&h" & Mid(dtBc, 3)) Then
        '    Me.BackColor = ColorTranslator.FromWin32("&h" & Mid(dtBc, 3))
        'ElseIf dtBc <> "" Then
        '    Me.BackColor = Color.FromName(dtBc)
        'Else
        '    Me.BackColor = System.Drawing.Color.White
        'End If
        Me.BackColor = SetColor(dtBc, System.Drawing.Color.White)
        Dim dtrTm As String = CType(key.GetValue("rTime"), String)
        If IsDate(dtrTm) Then
            rTm = CDate(dtrTm)
        Else
            rTm = CDate("2018/04/01 13:30:00")
        End If
        Dim dtlTm As String = CType(key.GetValue("lTime"), String)
        If IsDate(dtlTm) Then
            lTm = CDate(dtlTm)
        Else
            lTm = rTm
        End If
        Dim dtspdP As String = CType(key.GetValue("Speed"), String)
        If ChkspdP(dtspdP) Then
            TxtSpeed.Text = CStr(dtspdP)
        End If
        'spdP = CDbl(TxtSpeed.Text)
        ChgspdP(TxtSpeed.Text)
        Dim dtColRTL As String = CType(key.GetValue("RTimeColor"), String)
        'If IsNumeric(dtColRTL) Then
        '    LblRealTime.ForeColor = ColorTranslator.FromWin32(dtColRTL)
        'ElseIf IsNumeric("&h" & Mid(dtColRTL, 3)) Then
        '    LblRealTime.ForeColor = ColorTranslator.FromWin32("&h" & Mid(dtColRTL, 3))
        'ElseIf dtColRTL <> "" Then
        '    LblRealTime.ForeColor = Color.FromName(dtColRTL)
        'Else
        '    LblRealTime.ForeColor = System.Drawing.Color.Blue
        'End If
        LblRealTime.ForeColor = SetColor(dtColRTL, System.Drawing.Color.Blue)
        LblRealTimeL.ForeColor = LblRealTime.ForeColor
        LblRealTime.BackColor = Me.BackColor
        LblRealTimeL.BackColor = LblRealTime.BackColor
        Dim dtColLTL As String = CType(key.GetValue("LTimeColor"), String)
        'If IsNumeric(dtColLTL) Then
        '    LblLTime.ForeColor = ColorTranslator.FromWin32(dtColLTL)
        'ElseIf IsNumeric("&h" & Mid(dtColLTL, 3)) Then
        '    LblLTime.ForeColor = ColorTranslator.FromWin32("&h" & Mid(dtColLTL, 3))
        'ElseIf dtColLTL <> "" Then
        '    LblLTime.ForeColor = Color.FromName(dtColLTL)
        'Else
        '    LblLTime.ForeColor = System.Drawing.Color.Black
        'End If
        LblLTime.ForeColor = SetColor(dtColLTL, System.Drawing.Color.Black)
        LblLTimeL.ForeColor = LblLTime.ForeColor
        LblLTime.BackColor = Me.BackColor
        LblLTimeL.BackColor = LblLTime.BackColor

        Dim dtRealTimeL As String = CType(key.GetValue("rLabelText"), String)
        If dtRealTimeL <> "" Then
            LblRealTimeL.Text = dtRealTimeL
        End If
        Dim dtlLTimeL As String = CType(key.GetValue("lLabelText"), String)
        If dtlLTimeL <> "" Then
            LblLTimeL.Text = dtlLTimeL
        End If

        With pbarTime
            .Left = LblRealTime.Left
            .Top = LblRealTime.Top + LblRealTime.Height
            .Width = LblRealTime.Width
        End With


        key.Close()
        'rTm = CDate(Format(Now, "yyyy/mm/dd hh:nn" & ":00"))
        TxtRTime.Text = CStr(rTm)
        'lTm = rTm
        TxtLTime.Text = CStr(lTm)

        On Error GoTo 0
        Timer1.Enabled = True

        Dim asm As System.Reflection.Assembly = _
            System.Reflection.Assembly.GetExecutingAssembly()
        '�o�[�W�����̎擾
        Dim ver As System.Version = asm.GetName().Version
        '���ʂ̕\��
        ToolTip1.SetToolTip(LblLTimeL, "�_�u���N���b�N�ŏI���FVer." & ver.ToString)
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �v���O�����I������
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub LblLTimeL_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LblLTimeL.DoubleClick
        Select Case MsgBox("�v���O�������I�����܂�." & vbCrLf _
                           & "�@�p�����[�^�ۑ���I������ꍇ��[�͂�]" _
                           & vbCrLf & "�@�ۑ������I������ꍇ��[������]" _
                           & vbCrLf & "�@�I�������𒆒f����ꍇ��[�L�����Z��]", MsgBoxStyle.YesNoCancel, "�I���m�F")
            Case MsgBoxResult.Yes
                Timer1.Enabled = False
                Dim key As RegistryKey = Registry.CurrentUser
                key = key.CreateSubKey("software\VariableSpeedClock")

                key.SetValue("rTimeFormat", rTimeFormat)
                key.SetValue("lTimeFormat", lTimeFormat)

                'key.SetValue("BackColor", Me.BackColor.Name)
                'key.SetValue("RTimeColor", LblRealTime.ForeColor.Name)
                'key.SetValue("LTimeColor", LblLTime.ForeColor.Name)
                key.SetValue("BackColor", ChgColor(Me.BackColor.Name))
                key.SetValue("RTimeColor", ChgColor(LblRealTime.ForeColor.Name))
                key.SetValue("LTimeColor", ChgColor(LblLTime.ForeColor.Name))

                key.SetValue("rTime", TxtRTime.Text)
                key.SetValue("lTime", TxtLTime.Text)
                key.SetValue("Speed", TxtSpeed.Text.ToString)

                key.SetValue("FormWidth", CStr(Me.Width))
                key.SetValue("FormHeight", CStr(Me.Height))
                key.SetValue("lrtLeft", CStr(LblRealTime.Left))
                key.SetValue("lrtTop", CStr(LblRealTime.Top))
                key.SetValue("lrtFont", CStr(LblRealTime.Font.Name) & "," & CStr(LblRealTime.Font.Size))
                key.SetValue("lrtlLeft", CStr(LblRealTimeL.Left))
                key.SetValue("lrtlTop", CStr(LblRealTimeL.Top))
                key.SetValue("lrtlFont", CStr(LblRealTimeL.Font.Name) & "," & CStr(LblRealTimeL.Font.Size))
                key.SetValue("lltLeft", CStr(LblLTime.Left))
                key.SetValue("lltTop", CStr(LblLTime.Top))
                key.SetValue("lltFont", CStr(LblLTime.Font.Name) & "," & CStr(LblLTime.Font.Size))
                key.SetValue("lltlLeft", CStr(LblLTimeL.Left))
                key.SetValue("lltlTop", CStr(LblLTimeL.Top))
                key.SetValue("lltlFont", CStr(LblLTimeL.Font.Name) & "," & CStr(LblLTimeL.Font.Size))

                key.SetValue("rLabelText", LblRealTimeL.Text)
                key.SetValue("lLabelText", LblLTimeL.Text)

                key.Close()
                Me.Close()
                End
            Case MsgBoxResult.No
                Timer1.Enabled = False
                Me.Close()
                End
        End Select
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���荞�ݏ���
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim ntm As Date
        Dim lltm As Date

        ntm = Now
        LblRealTime.Text = VB6.Format(ntm, rTimeFormat)

        If tsIdx > -1 Then
            If ntm >= tsDate Then
                With dgvTimeSchedule
                    TxtRTime.Text = .Rows(tsIdx).Cells(0).Value
                    TxtLTime.Text = .Rows(tsIdx).Cells(1).Value
                    TxtSpeed.Text = .Rows(tsIdx).Cells(2).Value
                    rTm = CDate(TxtRTime.Text)
                    lTm = CDate(TxtLTime.Text)
                    ChgspdP(TxtSpeed.Text)
                    .Rows(tsIdx).Cells(3).Value = "True"
                    pbarTime.Value = 0
                    If tsIdx >= .RowCount - 2 Then
                        tsIdx = -1
                        pbarTime.Visible = False
                        'tsFlg = False
                    Else
                        For r As Long = tsIdx + 1 To .RowCount - 2
                            If IsDate(.Rows(r).Cells(0).Value) _
                              And IsDate(.Rows(r).Cells(1).Value) _
                              And ChkspdP(.Rows(r).Cells(2).Value) _
                              And CBool(.Rows(r).Cells(3).Value) = False Then
                                tsIdx = r
                                tsDate = CDate(.Rows(tsIdx).Cells(0).Value)
                                Exit For
                            End If
                        Next
                    End If
                End With
            End If
        End If

        If ntm >= rTm Then
            lltm = System.DateTime.FromOADate(lTm.ToOADate + System.DateTime.FromOADate(ntm.ToOADate - rTm.ToOADate).ToOADate * spdP / spdPd)
        Else
            lltm = System.DateTime.FromOADate(lTm.ToOADate - System.DateTime.FromOADate(rTm.ToOADate - ntm.ToOADate).ToOADate * spdP / spdPd)
        End If
        LblLTime.Text = VB6.Format(lltm, lTimeFormat)
        If tsIdx > -1 Then
            Dim d As Long
            If tsDate.ToOADate <> rTm.ToOADate Then
                d = Math.Abs(ntm.ToOADate - rTm.ToOADate) / Math.Abs(tsDate.ToOADate - rTm.ToOADate) * pbarTime.Maximum
            Else
                d = pbarTime.Maximum - Math.Abs(ntm.ToOADate - tspDate.ToOADate) / Math.Abs(rTm.ToOADate - tspDate.ToOADate) * pbarTime.Maximum
            End If
            If d >= pbarTime.Minimum And pbarTime.Maximum >= d Then
                pbarTime.Value = d
                Debug.Print(pbarTime.Value)
                System.Windows.Forms.Application.DoEvents()
            End If
        Else
            If pbarTime.Visible Then pbarTime.Visible = False
        End If
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �����A�{���ݒ�
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub LblRealTimeL_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LblRealTimeL.DoubleClick
        Timer1.Enabled = False
        With TxtLTime
            .Tag = .Text
            .Visible = True
        End With
        With TxtRTime
            .Tag = .Text
            .Visible = True
        End With
        With TxtSpeed
            .Tag = .Text
            .Visible = True
        End With
        btnTimeSchedule.Visible = True
        btnTmrSet.Visible = IIf(tsFlg, True, False)
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �����A�{���ݒ�I��
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetAther()
        If TxtRTime.Visible = False And TxtSpeed.Visible = False Then Timer1.Enabled = True
        dgvTimeSchedule.Visible = False
        btnTimeSchedule.Visible = False
        btnTmrSet.Visible = False
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���K��������
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub TxtLTime_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtLTime.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            If IsDate(TxtLTime.Text) Then
                lTm = CDate(TxtLTime.Text)
            Else
                TxtLTime.Text = TxtLTime.Tag
            End If
            TxtLTime.Visible = False
            KeyCode = 0
            ResetAther()
        ElseIf KeyCode = System.Windows.Forms.Keys.Escape Then
            TxtLTime.Text = TxtLTime.Tag
            TxtLTime.Visible = False
            KeyCode = 0
            ResetAther()
        End If
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ����������
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub TxtRTime_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtRTime.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            If IsDate(TxtRTime.Text) Then
                rTm = CDate(TxtRTime.Text)
            Else
                TxtRTime.Text = TxtRTime.Tag
            End If
            TxtRTime.Visible = False
            KeyCode = 0
            ResetAther()
        ElseIf KeyCode = System.Windows.Forms.Keys.Escape Then
            TxtRTime.Text = TxtRTime.Tag
            TxtRTime.Visible = False
            KeyCode = 0
            ResetAther()
        End If
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �{������
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub TxtSpeed_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtSpeed.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            If ChkspdP(TxtSpeed.Text) = False Then
                TxtSpeed.Text = TxtSpeed.Tag
            End If
            TxtSpeed.Visible = False
            KeyCode = 0
            ResetAther()
        ElseIf KeyCode = System.Windows.Forms.Keys.Escape Then
            TxtSpeed.Text = TxtSpeed.Tag
            TxtSpeed.Visible = False
            KeyCode = 0
            ResetAther()
        Else
        End If
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[���t�@�C���ǂݍ���
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TimeScheduleOpen()
        Timer1.Enabled = False
        Dim rf As DialogResult
        With cDlgFileOpen
            .Multiselect = False
            .Filter = "���ԊǗ��t�@�C��(*.tsf)|*.tsf|�S�Ẵt�@�C��(*.*)|*.*"
            .FilterIndex = 1
            .FileName = ""
            .AddExtension = True
            .DefaultExt = "tsf"
            rf = .ShowDialog()
        End With
        If rf = Windows.Forms.DialogResult.OK Then
            With dgvTimeSchedule
                .MultiSelect = True
                .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
                .ReadOnly = False
                For Each c As DataGridViewColumn In .Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = False
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .DefaultCellStyle.BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
                If .Rows.Count > 0 Then
                    For r As Long = 0 To .Rows.Count - 2
                        .Rows.RemoveAt(0)
                    Next
                End If

                '.RowCount = 0
                .Visible = True
                Dim rt As Date, lt As Date
                Dim sr As System.IO.StreamReader = Nothing
                Dim ss() As String
                Try
                    sr = New System.IO.StreamReader(cDlgFileOpen.FileName, System.Text.Encoding.GetEncoding("Shift_JIS"))
                    Dim strl As String = ""
                    Dim cflg As Boolean = False
                    Dim crt As Date, clt As Date
                    Dim cidx As Integer
                    Dim r As Integer
                    Do Until sr.EndOfStream
                        strl = sr.ReadLine
                        strl = Trim(strl)
                        'If strl = "" Then Exit Do '�󔒍s�ŋ����I��
                        ss = Split(strl, ",")
                        If .RowCount > 0 Then
                            ReDim Preserve ss(5)
                            If InStr(ss(0), "+") > 0 Then
                                ss(4) = ss(0)
                                ss(0) = CalcDate(rt, ss(0))
                            End If
                            If InStr(ss(1), "+") > 0 Then
                                ss(5) = ss(1)
                                ss(1) = CalcDate(rt, ss(1))
                            End If
                        End If


                        rt = IIf(IsDate(ss(0)), CDate(ss(0)), Nothing)
                        lt = IIf(IsDate(ss(1)), CDate(ss(1)), Nothing)
                        '.Rows.Add(rTimeFormat.ToString, lTimeFormat.ToString, cnt.ToString)
                        ss(3) = IIf(rt = Nothing Or lt = Nothing Or ChkspdP(ss(2)) = False, "True", "False")
                        .Rows.Add(ss)
                        r = .RowCount - 2
                        If ss(4) <> "" Then _
                            dgvTimeSchedule(0, r).Style.Font _
                              = New Font(dgvTimeSchedule.Font, dgvTimeSchedule.Font.Style Or FontStyle.Bold)
                        If ss(5) <> "" Then _
                            dgvTimeSchedule(1, r).Style.Font _
                              = New Font(dgvTimeSchedule.Font, dgvTimeSchedule.Font.Style Or FontStyle.Bold)
                        If rt = Nothing Then _
                            dgvTimeSchedule(0, r).Style.ForeColor = Color.Red
                        If lt = Nothing Then _
                            dgvTimeSchedule(1, r).Style.ForeColor = Color.Red
                        If rt <> Nothing And lt <> Nothing Then
                            If cflg Then
                                Dim dd As Double
                                dd = (lt.ToOADate - clt.ToOADate) / (rt.ToOADate - crt.ToOADate)
                                .Rows(cidx).Cells(2).Value = dd.ToString
                                dgvTimeSchedule(2, cidx).Style.Font _
                                  = New Font(dgvTimeSchedule.Font, dgvTimeSchedule.Font.Style Or FontStyle.Bold)
                                cflg = False
                            End If
                            crt = rt
                            clt = lt
                            cidx = r
                        End If
                        cflg = IIf(ss(2) = "", True, False)
                    Loop
                    dgvTimeScheduleInit()
                    btnTimeSchedule.Visible = False
                    'btnTmrSet.Visible = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    btnTimeSchedule.Visible = False
                    'btnTmrSet.Visible = False
                    .Visible = False
                Finally
                    If sr IsNot Nothing Then
                        sr.Close()
                        sr.Dispose()
                    End If
                End Try
            End With
        End If
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �v���X�W�L����
    ''' </summary>
    ''' <param name="sdt"></param>
    ''' <param name="p"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalcDate(ByVal sdt As Date, ByVal p As String) As Date
        Dim l As Long = InStr(p, "+")
        If l > 0 Then
            p = Trim(Mid(p, l + 1))
            l = InStr(p, " ")
            Dim dd As Long
            If l > 0 Then
                dd = CLng(str.Left(p, l - 1))
            Else
                dd = 0
            End If
            If l > 0 Then p = Trim(Mid(p, l + 1))
            l = InStr(p, ":")
            Dim hh As Long
            If l > 0 Then
                hh = CLng(str.Left(p, l - 1))
            Else
                hh = CLng(p)
            End If
            Dim mm As Long
            If l > 0 Then
                mm = CLng(Mid(p, l + 1))
            Else
                mm = 0
            End If
            sdt = sdt.AddDays(dd)
            sdt = sdt.AddHours(hh)
            sdt = sdt.AddMinutes(mm)
        Else
            If IsDate(p) Then sdt = CDate(p)
        End If
        CalcDate = sdt
    End Function

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' �����X�P�W���[���ꗗ�\������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvTimeScheduleInit()
        Dim dtnow As Date = Now
        Dim rdt As Date
        Dim rr As Long

        TxtLTime.Tag = TxtLTime.Text
        TxtRTime.Tag = TxtRTime.Text
        TxtSpeed.Tag = TxtSpeed.Text
        With dgvTimeSchedule
            tsIdx = -1
            tsFlg = False
            rr = -1
            For r As Long = .RowCount - 2 To 0 Step -1
                'If CBool(.Rows(r).Cells(3).Value) = False Then
                If IsDate(.Rows(r).Cells(0).Value) _
                  And IsDate(.Rows(r).Cells(1).Value) _
                  And ChkspdP(.Rows(r).Cells(2).Value) Then
                    rdt = CDate(.Rows(r).Cells(0).Value)
                    If dtnow >= rdt Then
                        If tsFlg = False Then
                            TxtRTime.Text = .Rows(r).Cells(0).Value
                            TxtLTime.Text = .Rows(r).Cells(1).Value
                            TxtSpeed.Text = .Rows(r).Cells(2).Value
                            tsFlg = True
                            If rr >= 0 Then
                                tsIdx = rr
                                tsDate = CDate(.Rows(tsIdx).Cells(0).Value)
                            End If
                        End If
                        .Rows(r).Cells(3).Value = "True"
                    Else
                        rr = r
                        If r = 0 And dtnow < rdt Then
                            TxtRTime.Text = .Rows(r).Cells(0).Value
                            TxtLTime.Text = .Rows(r).Cells(1).Value
                            TxtSpeed.Text = .Rows(r).Cells(2).Value
                            tsFlg = True
                            If rr >= 0 Then
                                tsIdx = rr
                                tsDate = CDate(.Rows(tsIdx).Cells(0).Value)
                            End If
                        End If
                    End If
                Else
                    .Rows(r).Cells(3).Value = "True"
                End If
                'End If
            Next


            If rr = -1 Then tsFlg = False
            pbarTime.Visible = tsFlg
            rTm = CDate(TxtRTime.Text)
            lTm = CDate(TxtLTime.Text)
            ChgspdP(TxtSpeed.Text)
        End With
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    '''  �����X�P�W���[���ꗗ�\�`�F�b�N
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChkdgvTimeSchedule()
        Dim dtnow As Date = Now
        Dim rdt As Date
        Dim rr As Long

        With dgvTimeSchedule
            tsIdx = -1
            tsFlg = False
            rr = -1
            For r As Long = .RowCount - 2 To 0 Step -1
                If CBool(.Rows(r).Cells(3).Value) = False Then
                    If IsDate(.Rows(r).Cells(0).Value) _
                      And IsDate(.Rows(r).Cells(1).Value) _
                      And ChkspdP(.Rows(r).Cells(2).Value) Then
                        rdt = CDate(.Rows(r).Cells(0).Value)
                        If dtnow >= rdt Then
                            If tsFlg = False Then
                                TxtRTime.Text = .Rows(r).Cells(0).Value
                                TxtLTime.Text = .Rows(r).Cells(1).Value
                                TxtSpeed.Text = .Rows(r).Cells(2).Value
                                tsFlg = True
                                If rr >= 0 Then
                                    tsIdx = rr
                                    tsDate = CDate(.Rows(tsIdx).Cells(0).Value)
                                End If
                            End If
                            .Rows(r).Cells(3).Value = "True"
                        Else
                            rr = r
                        End If
                    Else
                        .Rows(r).Cells(3).Value = "True"
                    End If
                End If
            Next
            If rr = -1 Then tsFlg = False
            lTm = CDate(TxtLTime.Text)
            rTm = CDate(TxtRTime.Text)
            ChgspdP(TxtSpeed.Text)
        End With
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[���t�@�C���ǂݍ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTimeSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeSchedule.Click
        TimeScheduleOpen()
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[���t�@�C���ǂݍ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsMiTSRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsMiTSRead.Click
        TimeScheduleOpen()
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[�����s
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TimeScheduleRun()
        TxtRTime.Visible = False
        TxtLTime.Visible = False
        TxtSpeed.Visible = False
        btnTimeSchedule.Visible = False
        btnTmrSet.Visible = False
        dgvTimeScheduleInit()
        dgvTimeSchedule.Visible = False
        'pbarTime.Visible = True
        tspDate = Now
        Timer1.Enabled = True
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[�����s
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsMiTSRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMiTSRun.Click
        TimeScheduleRun()
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[�����s
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvTimeSchedule_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTimeSchedule.CellDoubleClick
        TimeScheduleRun()
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[���\��\��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsMiTSDisp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsMiTSDisp.Click
        dgvTimeSchedule.Visible = True
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[���\��\��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTmrSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTmrSet.Click
        dgvTimeSchedule.Visible = True
    End Sub

    '////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' ���ԃX�P�W���[���\�����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsMiTSExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsMiTSExit.Click
        TxtLTime.Text = TxtLTime.Tag
        TxtRTime.Text = TxtRTime.Tag
        TxtSpeed.Text = TxtSpeed.Tag
        lTm = CDate(TxtLTime.Text)
        rTm = CDate(TxtRTime.Text)
        ChkspdP(TxtSpeed.Text)
        ResetAther()
        'dgvTimeSchedule.Visible = False
    End Sub






    Private Sub LblLTimeL_Click(sender As Object, e As EventArgs) Handles LblLTimeL.Click

    End Sub
End Class