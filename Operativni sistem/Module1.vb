Imports System.Data.OleDb

Module Module1
    Public acsconn As New OleDbConnection
    'The
    'e
    Public acsdr As OleDbDataReader
    '\
    Public acsda As New OleDbDataAdapter
    Sub connect()
        acsconn.ConnectionString = "provider=microsoft.ace.oledb..12.0; data source = |datadirectory|\database1.accdb;"
        acsconn.Open()
        If acsconn.State = ConnectionState.Open Then
            MsgBox("Connected")
        End If
    End Sub
End Module
