Imports System.Data
Imports System.Data.OleDb.OleDbCommand
Imports vb = Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Web

Partial Class CPA_PD_CPA_SendDateNull
    Inherits System.Web.UI.Page

    Dim sqlcon, connstr As New OleDbConnection
    Dim sqlcmd, sqlcmd1 As OleDbCommand
    Dim sqlad As OleDbDataAdapter
    Dim sqlds As New DataSet
    'Dim sa As New [abc]
    Dim aa, bb As String
    Dim objconn As New CCommon()

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try

            txtAppName.Enabled = False
            If txtCaseId.Text <> "" Then
                sqlcmd = New OleDbCommand("select ref_no, isnull(first_name,'')+ ' '+isnull(middle_name,'')+' '+isnull(last_name,'') as Name from CPA_PD_Case_Details where case_id='" & txtCaseId.Text & "' and Client_id='" & Session("ClientID").ToString() & "'", sqlcon)
                sqlcmd.ExecuteNonQuery()
                sqlad = New OleDbDataAdapter(sqlcmd)
                sqlad.Fill(sqlds, "CPA_PD_Case_Details")
                txtRefNo.Text = sqlds.Tables("CPA_PD_Case_Details").Rows(0)(0).ToString
                txtAppName.Text = sqlds.Tables("CPA_PD_Case_Details").Rows(0)(1).ToString
            ElseIf txtRefNo.Text <> "" Then
                sqlcmd = New OleDbCommand("select case_id, isnull(first_name,'')+ ' '+isnull(middle_name,'')+' '+isnull(last_name,'') as Name from CPA_PD_Case_Details where ref_no='" & txtRefNo.Text & "' and Client_id='" & Session("ClientID").ToString() & "'", sqlcon)
                sqlcmd.ExecuteNonQuery()
                sqlad = New OleDbDataAdapter(sqlcmd)
                sqlad.Fill(sqlds, "CPA_PD_Case_Details")
                txtCaseId.Text = sqlds.Tables("CPA_PD_Case_Details").Rows(0)(0).ToString
                txtAppName.Text = sqlds.Tables("CPA_PD_Case_Details").Rows(0)(1).ToString
            End If
            'End If
        Catch ex As Exception
            lblMessage.Visible = True
            lblMessage.Text = (ex.Message)
        End Try
    End Sub

    Protected Sub btnReopen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReopen.Click
        Try
            If txtCaseId.Text = "" Then
                lblMessage.Text = "Please Enter Case ID."
                lblMessage.Visible = True
                Exit Sub
                'ElseIf txtRefNo.Text = "" Then
                '    lblMessage.Text = "Please Enter Ref No."
                '    lblMessage.Visible = True
                '    Exit Sub
            End If

            sqlcmd = New OleDbCommand("select send_datetime from CPA_PD_Case_Details where case_id='" & txtCaseId.Text & "'", sqlcon)
            sqlcmd.ExecuteNonQuery()
            sqlad = New OleDbDataAdapter(sqlcmd)
            sqlds.Tables.Clear()
            sqlad.Fill(sqlds, "abc")
            aa = sqlds.Tables("abc").Rows(0)(0).ToString
            'bb = sqlds.Tables("abc").Rows(0)(1).ToString

            If aa = "" Then
                lblMessage.Text = "This case ID already Reopen"
                lblMessage.Visible = True
                Exit Sub
            Else
                sqlcmd1 = New OleDbCommand("Update CPA_PD_Case_Details set send_datetime=null, is_case_complete=null where case_id='" & txtCaseId.Text & "'", sqlcon)
                sqlcmd1.ExecuteNonQuery()

                lblMessage.Text = "Send date updated succesfully"
                lblMessage.Visible = True
                txtCaseId.Text = ""
                txtRefNo.Text = ""
                txtAppName.Text = ""
            End If
            txtCaseId.Text = ""
            txtRefNo.Text = ""
            txtAppName.Text = ""
        Catch ex As Exception
            lblMessage.Text = (ex.Message)
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAppName.Enabled = False

        sqlcon = New OleDbConnection
        sqlcon.ConnectionString = objconn.ConnectionString()
        sqlcon.Open()
        lblMessage.Visible = False
    End Sub
End Class
