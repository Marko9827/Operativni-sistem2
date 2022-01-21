Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Navigate(ComboBox1.Text)
        ComboBox1.Items.Add(ComboBox1.Text)
        Timer1.Start()
        Button7.Hide()
        Button8.Hide()
        Panel2.Hide()
        AxWebBrowser1.Hide()
        AxWebBrowser1.Stop()
        WebBrowser1.Show()
    End Sub

    Private Sub comboBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            WebBrowser1.Navigate(ComboBox1.Text)
            ComboBox1.Items.Add(ComboBox1.Text)
            Timer1.Start()
        End If
    End Sub

    Private Sub KopirajToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KopirajToolStripMenuItem.Click


    End Sub

    Private Sub NalepiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NalepiToolStripMenuItem.Click
      
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        WebBrowser1.Stop()

        Form2.Button10.Hide()

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Button10.Show()
        Panel1.Hide()
        ProgressBar1.Hide()
        AxWebBrowser1.Hide()
        Button8.Hide()
        Button7.Hide()
        Panel2.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim t As New TabPage
        Dim newtab As New Form4
        newtab.Show()
        newtab.TopLevel = False
        newtab.Dock = DockStyle.Fill
        t.Controls.Add(newtab)
        Form5.TabControl1.TabPages.Add(t)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Form5.TabControl1.TabCount = 1 Then
            Dim t As New TabPage
            Dim newtab As New Form4
            newtab.Show()
            newtab.Dock = DockStyle.Fill
            newtab.TopLevel = False
            t.Controls.Add(newtab)
            Form5.TabControl1.TabPages.Add(t)
            Form5.TabControl1.SelectedTab.Dispose()
        Else
            Form5.TabControl1.SelectedTab.Dispose()
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Form5.TabControl1.SelectedTab.Text = WebBrowser1.DocumentTitle
        Dim web_request As System.Net.HttpWebRequest = System.Net.WebRequest.Create("http://" & WebBrowser1.Document.Url.Host.ToString & "/favicon.ico")
        Dim web_respone As System.Net.HttpWebResponse = web_request.GetResponse
        Dim web_stream As System.IO.Stream = web_respone.GetResponseStream
        Dim image As Image = image.FromStream(web_stream)
        Form5.ImageList1.Images.Add(image)
        Form5.TabControl1.SelectedTab.ImageIndex = Form5.ImageList1.Images.Count - 1
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WebBrowser1.Navigate("https://www.google.rs/search?site=b&source=hp&q=" + TextBox2.Text)
        Button7.Hide()
        Button8.Hide()
        Panel2.Hide()
        AxWebBrowser1.Hide()
        AxWebBrowser1.Stop()
        WebBrowser1.Show()
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            WebBrowser1.Navigate("https://www.google.rs/search?site=b&source=hp&q=" + TextBox2.Text)
        End If
    End Sub

    Private Sub GoogleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleToolStripMenuItem.Click
        WebBrowser1.Navigate("https://plus.google.com/u/0/app/basic/stream?cbp=rmdfuwr8hm0l&authkey=CJjB_Mu_yLTEgwE&sview=11&cid=5&soc-app=115&soc-platform=1")
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacebookToolStripMenuItem.Click
        WebBrowser1.Navigate("http://wwww.facebook.com")
    End Sub

    Private Sub YoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubeToolStripMenuItem.Click
        WebBrowser1.Navigate("http://m.youtube.com")
    End Sub

  
   

    Private Sub WebIstorijaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebIstorijaToolStripMenuItem.Click
        Panel1.Show()

    End Sub

    Private Sub WebBrowser1_DocumentTitleChanged1(sender As Object, e As EventArgs) Handles WebBrowser1.DocumentTitleChanged
        ComboBox1.Text = WebBrowser1.Url.ToString
        ListBox1.Items.Add(ComboBox1.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Hide()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListBox1.ClearSelected()


    End Sub

    Private Sub WebBrowser1_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged
        Try
            ProgressBar1.Show()
            ProgressBar1.Maximum = e.MaximumProgress
            ProgressBar1.Value = e.CurrentProgress
           
        Catch ex As Exception
            ProgressBar1.Hide()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 0 Then

        Else
            If Not ProgressBar1.Value = 0 Then
                If ProgressBar1.Value = ProgressBar1.Maximum Then

                    ProgressBar1.Value = ProgressBar1.Maximum
                End If
            End If
        End If
    End Sub

    Private Sub WebBrowser1_NewWindow(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow
        'Dim t As New TabPage
        'Dim newtab As New Form4
        'newtab.Show()
        'newtab.Dock = DockStyle.Fill
        'newtab.WebBrowser1.RegisterBrowser = True
        'e.ppDisp = newtab.WebBrowser1.Application
        'newtab.Visible = True
        'newtab.TopLevel = False
        't.Controls.Add(newtab)
        'Form2.TabControl1.TabPages.Add(t)

    End Sub


    Private Sub KpyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KpyToolStripMenuItem.Click
        WebBrowser1.GoBack()

    End Sub

    Private Sub NapredToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NapredToolStripMenuItem.Click
        WebBrowser1.GoForward()

    End Sub

    Private Sub PočetnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PočetnaToolStripMenuItem.Click
        WebBrowser1.Navigate("http://www.google.rs")
    End Sub

    Private Sub KopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KopyToolStripMenuItem.Click
     
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panel2.Hide()
        Button8.Hide()
        Button7.Show()

        '▼ 
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        '▲ 
        Panel2.Show()
        Button7.Hide()
        Button8.Show()
    
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        AxWebBrowser1.Navigate("http://www.facebook.com")
        Button11.BackColor = Color.Blue
        Button10.BackColor = Color.Black

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AxWebBrowser1.Navigate("http://m.facebook.com")
    End Sub

    Private Sub FacebokAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacebokAppToolStripMenuItem.Click
        Button7.Show()
        WebBrowser1.Hide()
        AxWebBrowser1.Show()
        AxWebBrowser1.Navigate("http://www.facebook.com")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Button7.Hide()
        Button8.Hide()
        Panel2.Hide()
        AxWebBrowser1.Hide()
        AxWebBrowser1.Stop()
        WebBrowser1.Show()

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        WindowState = FormWindowState.Normal
    End Sub
End Class