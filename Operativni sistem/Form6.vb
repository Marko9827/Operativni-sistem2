Public Class Form6
    Dim fadeout As Boolean

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dlg As ColorDialog = New ColorDialog
            dlg.Color = Label1.ForeColor
            dlg.Color = Label2.ForeColor
            dlg.Color = Label3.ForeColor
            dlg.Color = Label4.ForeColor
            dlg.Color = Label5.ForeColor
            dlg.Color = GroupBox1.ForeColor

            If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Label1.ForeColor = dlg.Color
                Label2.ForeColor = dlg.Color

                Label3.ForeColor = dlg.Color
                Label4.ForeColor = dlg.Color
                Label5.ForeColor = dlg.Color
                GroupBox1.ForeColor = dlg.Color
            End If

        Catch ex As Exception : End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form2.BackgroundImage = My.Resources._246225
        Form8.BackgroundImage = My.Resources._246225
        Form2.PictureBox2.Image = My.Resources._246225
        Form2.Panel5.Show()
        Form2.Label9.Show()

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Form2.BackgroundImage = My.Resources.computer_wallpaper_hd
        Form8.BackgroundImage = My.Resources.computer_wallpaper_hd
        Form2.PictureBox2.Image = My.Resources.computer_wallpaper_hd
        Form11.BackgroundImage = My.Resources.computer_wallpaper_hd
        Form2.Panel5.Show()
        Form2.Label9.Show()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Form2.BackgroundImage = My.Resources.blue_hands_earth_digital_art_roots_1680x1050_wallpaper_www_wall321_com_21
        Form8.BackgroundImage = My.Resources.blue_hands_earth_digital_art_roots_1680x1050_wallpaper_www_wall321_com_21
        Form2.PictureBox2.Image = My.Resources.blue_hands_earth_digital_art_roots_1680x1050_wallpaper_www_wall321_com_21
        Form2.Panel5.Show()
        Form2.Label9.Show()
        Form11.BackgroundImage = My.Resources.blue_hands_earth_digital_art_roots_1680x1050_wallpaper_www_wall321_com_21
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form2.BackgroundImage = My.Resources._207228
        Form8.BackgroundImage = My.Resources._207228
        Form2.BackgroundImage = My.Resources._207228
        Form2.Panel5.Show()
        Form2.Label9.Show()
        Form11.BackgroundImage = My.Resources._207228
        Form2.PictureBox2.Image = My.Resources._207228
        Form2.Panel5.Show()
        Form2.Label9.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form2.BackgroundImage = My.Resources._52107708
        Form8.BackgroundImage = My.Resources._52107708
        Form2.BackgroundImage = My.Resources._52107708
        Form2.Panel5.Show()
        Form2.Label9.Show()
        Form2.PictureBox2.Image = My.Resources._52107708
        Form11.BackgroundImage = My.Resources._52107708

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Form2.BackgroundImage = My.Resources._14___1
        Form8.BackgroundImage = My.Resources._14___1
        Form2.BackgroundImage = My.Resources._14___1
        Form2.Panel5.Show()
        Form2.Label9.Show()
        Form11.BackgroundImage = My.Resources._14___1
        Form2.PictureBox2.Image = My.Resources._14___1

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If fadeout = True Then
            End
        Else

        End If
    End Sub

    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
       
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label3.Text = TimeOfDay

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Form2.BackgroundImage = My.Resources.P30_05_30_09_11
        Form8.BackgroundImage = My.Resources.P30_05_30_09_11
        Form11.BackgroundImage = My.Resources.P30_05_30_09_11
        Form2.PictureBox2.Image = My.Resources.P30_05_30_09_11
        Form2.Panel5.Show()
        Form2.Label9.Show()

    End Sub

  

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Label7.Text = MonthCalendar1.SelectionStart
        Form2.Label10.Text = MonthCalendar1.SelectionStart
        Form8.Label2.Text = MonthCalendar1.SelectionStart
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Do While Panel1.Width < 881
            Panel1.Width = Panel1.Width + 1
        Loop
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Do While Panel1.Width > 74
            Panel1.Width = Panel1.Width - 1
        Loop
    End Sub
End Class

'Try
'Dim dlg As ColorDialog = New ColorDialog
'dlg.Color = RichTextBox1.ForeColor
'If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
'RichTextBox1.ForeColor = dlg.Color
'End If