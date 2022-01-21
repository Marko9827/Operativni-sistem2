Public Class Form11
#Region " Global Variables "
    Dim Point As New System.Drawing.Point()
    Dim X, Y As Integer
#End Region

#Region " GUI "
    Private Sub Form_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            Point = Control.MousePosition
            Point.X = Point.X - (X)
            Point.Y = Point.Y - (Y)
            Me.Location = Point
        End If
    End Sub

    Private Sub Form_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub
#End Region

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button7.Hide()

        Me.TransparencyKey = Color.FromArgb(224, 224, 224)
        PreikaziPlayerToolStripMenuItem.Enabled = False
        Label2.Hide()
        Button12.Hide()
        Label3.Hide()
        Panel1.Hide()
        Button11.Enabled = False
        Button11.Hide()
        Button14.Hide()

    End Sub

    
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog2.ShowDialog()



        AxWindowsMediaPlayer1.URL = OpenFileDialog2.FileName
        PictureBox1.Show()
        Button12.Hide()
        Label2.Hide()
        Form2.Label18.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

   

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        OpenFileDialog1.ShowDialog()

        PictureBox1.Hide()
        'sababs
       
        'asasbas
        AxWindowsMediaPlayer1.URL = OpenFileDialog1.FileName

        Button11.Enabled = True
        Label3.Show()
        My.Computer.Audio.Stop()
        Form2.Label17.Hide()
        Form2.Label15.Text = ""
        Form2.Label18.Hide()
        Timer4.Start()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        AxWindowsMediaPlayer1.settings.volume = TrackBar1.Value
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        WindowState = FormWindowState.Maximized
        Button1.Hide()
        Button7.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WindowState = FormWindowState.Normal
        Button7.Hide()
        Button1.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        My.Computer.Audio.Stop()
        Form2.Label17.Hide()
        Form2.Label15.Text = ""
        Form2.Label18.Hide()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AxWindowsMediaPlayer1.Ctlcontrols.previous()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AxWindowsMediaPlayer1.Ctlcontrols.next()

    End Sub

    Private Sub PozadinaPlayeraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PozadinaPlayeraToolStripMenuItem.Click
        Form6.Show()
    End Sub

    Private Sub PrikaziPozadinuPlayeraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrikaziPozadinuPlayeraToolStripMenuItem.Click
        PictureBox1.Hide()
        AxWindowsMediaPlayer1.Hide()
        PrikaziPozadinuPlayeraToolStripMenuItem.Enabled = False
        PreikaziPlayerToolStripMenuItem.Enabled = True
       



    End Sub

    Private Sub PreikaziPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreikaziPlayerToolStripMenuItem.Click
        PictureBox1.Show()
        AxWindowsMediaPlayer1.Show()
        PreikaziPlayerToolStripMenuItem.Enabled = False
        PrikaziPozadinuPlayeraToolStripMenuItem.Enabled = True



        Button11.Show()
        Label2.Show()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        PictureBox1.Hide()
        AxWindowsMediaPlayer1.Show()
        Label2.Hide()
        Label3.Hide()


        Button11.Hide()

        Button12.Hide()

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Label2.Hide()
        Label3.Show()

        Button12.Hide()
        Button11.Show()


    End Sub

   
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Panel1.Show()
        Button13.Hide()
        PictureBox1.Show()
        Button14.Show()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Panel1.Hide()
        Button13.Show()
        Button14.Hide()
        PictureBox1.Show()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        My.Computer.Audio.Play(My.Resources.Dado_Polumenta___Hipnotisan__OFFICIAL_HD_VIDEO_SPOT_, AudioPlayMode.Background)
        PictureBox1.Show()
        Form2.Label17.Show()
        Form2.Label15.Text = "Dado Polumenta - Hipnotisan"
        Timer2.Start()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()
        Form2.Label18.Show()

    End Sub


    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        My.Computer.Audio.Stop()
        Form2.Label17.Hide()
        Form2.Label15.Text = ""
        Form2.Label18.Hide()
        Timer4.Start()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Form2.Label18.Text = "ililili"
        Form2.Label18.Show()
        Timer4.Stop()
        Timer3.Start()
        Timer2.Stop()

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Form2.Label18.Show()
        Form2.Label18.Text = "lililil"
        Timer2.Start()
        Timer3.Stop()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Timer2.Stop()
        Timer3.Stop()
        Form2.Label18.Hide()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        My.Computer.Audio.Stop()
        Form2.Label17.Hide()
        Form2.Label15.Text = ""
        Form2.Label18.Hide()
        Timer4.Start()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        My.Computer.Audio.Play(My.Resources.forest1, AudioPlayMode.Background)
        PictureBox1.Show()
        Form2.Label17.Show()
        Form2.Label15.Text = "Harmonija šume"
        Timer2.Start()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()
        Form2.Label18.Show()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        My.Computer.Audio.Stop()
        Form2.Label17.Hide()
        Form2.Label15.Text = ""
        Form2.Label18.Hide()
        Timer4.Start()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        My.Computer.Audio.Play(My.Resources.VB_NET____Workspace_OS___VB_OS___2013_HD______Update_Video___, AudioPlayMode.Background)
        PictureBox1.Show()
        Form2.Label17.Show()
        Form2.Label15.Text = "Zvuk'1"
        Timer2.Start()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Panel1.Hide()
        Button14.Hide()
        Button13.Show()
        Form2.Label18.Show()
    End Sub

    Private Sub ZaključajEkranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZaključajEkranToolStripMenuItem.Click
        Form8.Show()
        Form2.Hide()

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            AxWindowsMediaPlayer1.URL = TextBox1.Text
            PictureBox1.Hide()
        End If
    End Sub

    Private Sub OčistiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OčistiToolStripMenuItem.Click
        TextBox1.Clear()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub RotirajVideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RotirajVideoToolStripMenuItem.Click
        Me.PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        AxWindowsMediaPlayer1.URL = "http://streaming.prva.ha.rs/dosije/dosije-talac_prva.rs.mp4"
        PictureBox1.Hide()
        Panel1.Hide()

    End Sub
End Class