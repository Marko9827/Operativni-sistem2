Public Class Form10
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
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()

    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        Button2.Hide()
        Label4.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Hide()
        Button2.Show()
        AxWindowsMediaPlayer1.Ctlcontrols.pause()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Hide()
        Button1.Show()
        AxWindowsMediaPlayer1.Ctlcontrols.play()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        WindowState = FormWindowState.Maximized
        Label3.hide()
        Label4.Show()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        WindowState = FormWindowState.Normal
        Label4.Hide()
        Label3.Show()

    End Sub
End Class