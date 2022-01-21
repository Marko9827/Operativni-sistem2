Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Public Class Form2
   
    Inherits System.Windows.Forms.Form

    Const WM_CAP_START = &H400S
    Const WS_CHILD = &H40000000
    Const WS_VISIBLE = &H10000000
    Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Const WM_CAP_EDIT_COPY = WM_CAP_START + 30
    Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Const WM_CAP_FILE_SAVEAS = WM_CAP_START + 23
    Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50
    Const SWP_NOMOVE = &H2S
    Const SWP_NOSIZE = 1
    Const SWP_NOZORDER = &H4S
    Const HWND_BOTTOM = 1
    '--The capGetDriverDescription function retrieves the version 
    ' description of the capture driver--
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" _
    (ByVal wDriverIndex As Short, _
    ByVal lpszName As String, ByVal cbName As Integer, _
    ByVal lpszVer As String, _
    ByVal cbVer As Integer) As Boolean

    '--The capCreateCaptureWindow function creates a capture window--
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
    (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
    ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
    ByVal nHeight As Short, ByVal hWnd As Integer, _
    ByVal nID As Integer) As Integer

    '--This function sends the specified message to a window or windows--
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    (ByVal hwnd As Integer, ByVal Msg As Integer, _
    ByVal wParam As Integer, _
    <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    '--Sets the position of the window relative to the screen buffer--
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" _
    (ByVal hwnd As Integer, _
    ByVal hWndInsertAfter As Integer, ByVal x As Integer, _
    ByVal y As Integer, _
    ByVal cx As Integer, ByVal cy As Integer, _
    ByVal wFlags As Integer) As Integer

    '--This function destroys the specified window--
    Declare Function DestroyWindow Lib "user32" _
    (ByVal hndw As Integer) As Boolean

    '---used to identify the video source---
    Dim CamSource As Integer

    '---used as a window handle---
    Dim hWnd As Integer

    Private Sub cameraSource()
        Dim DriverName As String = Space(80)
        Dim DriverVersion As String = Space(80)
        For i As Integer = 0 To 9
            If capGetDriverDescriptionA(i, DriverName, 80, _
            DriverVersion, 80) Then
                ListBox1.Items.Add(DriverName.Trim)
            End If
        Next
    End Sub

    Private Sub previewCamera(ByVal pbCtrl As PictureBox)
        hWnd = capCreateCaptureWindowA(CamSource, _
        WS_VISIBLE Or WS_CHILD, 0, 0, 0, _
        0, pbCtrl.Handle.ToInt32, 0)
        If SendMessage( _
        hWnd, WM_CAP_DRIVER_CONNECT, _
        CamSource, 0) Then
            '---set the preview scale---
            SendMessage(hWnd, WM_CAP_SET_SCALE, True, 0)
            '---set the preview rate (ms)---
            SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0)
            '---start previewing the image---
            SendMessage(hWnd, WM_CAP_SET_PREVIEW, True, 0)
            '---resize window to fit in PictureBox control---
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, _
            pbCtrl.Width, pbCtrl.Height, _
            SWP_NOMOVE Or SWP_NOZORDER)
        Else
            '--error connecting to video source---
            DestroyWindow(hWnd)
        End If
    End Sub

    Private Sub stopPreviewCamera()
        SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, CamSource, 0)
        DestroyWindow(hWnd)
    End Sub
    Dim panloc As New Point(0, 0)
    Dim curloc As New Point(0, 0)
    Dim SAPI
    Private Sub setpositions()
        panloc = Panel7.Location
        curloc = System.Windows.Forms.Cursor.Position
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Form1.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = TimeOfDay
        Label3.Text = My.Computer.Name

    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Label1.Visible = False
        previewCamera(PictureBox5)
        Button24.Enabled = True
        Button23.Enabled = False
        Button25.Enabled = True
    End Sub
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        stopPreviewCamera()
        Button23.Enabled = True
        Button24.Enabled = False
    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Button26.Enabled = True
        Button25.Enabled = False
        SendMessage(hWnd, WM_CAP_SEQUENCE, 0, 0)
    End Sub
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Dim save As Integer
        save = MsgBox("Do you want to save your recording video", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Recording Video")
        If (save = MsgBoxResult.Yes) Then
            Dim saveName As New SaveFileDialog
            saveName.Filter = "Avi file(*.avi)|*.avi"
            If saveName.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' SendMessage(hWnd, WM_CAP_FILE_SAVEAS, 0, "C:\RecordedVideo.avi")
                SendMessage(hWnd, WM_CAP_FILE_SAVEAS, 0, saveName.FileName)
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Button25.Enabled = True
        Button26.Enabled = False
    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CamSource = ListBox1.SelectedIndex
        previewCamera(PictureBox5)
        Button23.Enabled = False
        Button24.Enabled = True
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cameraSource()
        Button23.Enabled = False '4
        Button24.Enabled = False '1
        Button25.Enabled = False '2
        Button26.Enabled = False '3
        PictureBox5.Hide()
        Button23.Hide()
        Button24.Hide()
        Button25.Hide()
        Button26.Hide()
        ListBox1.Hide()
        Button28.Hide()
        Timer5.Interval = "1"
        Label17.Hide()
        Label18.Hide()

        'ostalo :D
        Button18.Hide()
        MonthCalendar1.Hide()
        Button20.Hide()
        MonthCalendar1.Hide()
        Panel6.Hide()

        Panel2.Hide()
        Button4.Show()
        Button5.Show()
        Timer1.Start()
        Button7.Hide()
        Button9.Hide()
        Button10.Hide()
        Panel5.Hide()
        Label9.Hide()
        Panel8.Hide()
        Panel7.Hide()

        Label10.Text = (MonthCalendar1.MinDate = Date.Today)

        MonthCalendar1.BackColor = Color.BlueViolet

        Me.BackColor = Color.FromArgb(224, 224, 224)
        Me.TransparencyKey = Color.FromArgb(224, 224, 224)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Show()
        Button7.Show()
        Button2.Hide()

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        CamSource = ListBox1.SelectedIndex
        '---preview the selected video source
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub IskljuciToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form1.Close()

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label3.Text = My.Computer.Name

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Close()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
        Panel2.Hide()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form3.Show()

        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form3.Show()
        Button9.Show()
        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

        Panel5.Hide()
        Button9.Hide()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.Show()
        Button10.Show()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form5.Show()
        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Minecraft.Show()
        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
    End Sub

    Private Sub CreateFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateFolderToolStripMenuItem.Click

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Form6.Show()
        Panel2.Hide()
        Button2.Show()
        Button7.Hide()
        Button12.BackColor = Color.Transparent
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form8.Show()
        Panel2.Hide()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Form5.Show()
        Form4.WebBrowser1.Navigate("http://www.google.com")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Form5.Show()
        Form4.WebBrowser1.Navigate("http://www.facebook.com")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Form10.Show()

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Button18.Show()
        Form10.Show()
        Panel2.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Panel5.Hide()
        Label9.Hide()

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub


    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Digitron.Show()

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Button20.Show()

        Panel6.Show()

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Button20.Hide()
        MonthCalendar1.Hide()
        Panel6.Hide()

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Label10.Text = MonthCalendar1.SelectionStart

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Panel2.Show()
        Button12.BackColor = Color.Red

    End Sub






    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Form11.Show()

    End Sub


    Private Sub NoviFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoviFolderToolStripMenuItem.Click
        Panel7.Show()




    End Sub

    Private Sub IzbToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IzbToolStripMenuItem.Click
        Panel7.Hide()

    End Sub

    Private Sub Panel7_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel7.MouseDown
        Timer5.Enabled = True
        Timer5.Start()
        setpositions()
    End Sub

    Private Sub Panel7_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel7.MouseUp
        Timer5.Stop()
        setpositions()
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Panel7.Location = panloc - curloc + System.Windows.Forms.Cursor.Position
        setpositions()
    End Sub


    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        My.Computer.Audio.Stop()
        Label18.Hide()
        Label17.Hide()
        Label15.Text = ""
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak(TextBox2.Text)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        PictureBox5.Hide()
        Button23.Hide()
        Button24.Hide()
        Button25.Hide()
        Button26.Hide()
        ListBox1.Hide()
        Button28.Hide()
        stopPreviewCamera()
        Button4.Enabled = True
        Button1.Enabled = False
    End Sub


    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        PictureBox5.Show()
        Button23.Show()
        Button24.Show()
        Button25.Show()
        Button26.Show()
        ListBox1.Show()
    End Sub


    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Form15.Show()

    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick

    End Sub
End Class