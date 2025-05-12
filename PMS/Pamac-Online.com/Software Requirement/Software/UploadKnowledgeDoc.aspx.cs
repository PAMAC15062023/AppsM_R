using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Software_Requirement_Software_UploadKnowledgeDoc : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            GetFileDetails();

            lblMessage.Text = "";

            EditFile.Visible = false;
            NewFile.Visible = false;
        }
    }
    public void GetFileDetails()
    {
        hdnFileID.Value = "0";
        txtTopic.Text = "";
        txtTopic.Enabled = true;

        foreach (GridViewRow item in grdlos.Rows)
        {
            CheckBox checkBox = (CheckBox)item.FindControl("chkbox");
            if (checkBox.Checked)
            {
                checkBox.Checked = false;
            }
        }

      

        SqlCommand cmd = new SqlCommand("USP_GetKnowledgeDocFilesDetails", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables.Count > 0)
        {
            grdlos.DataSource = ds;
            grdlos.DataBind();
        }
        else
        {
            grdlos.EmptyDataText = "No Data";
            grdlos.DataBind();
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        hdnFileID.Value = "0";
        NewFile.Visible = true;
        lblMessage.Text = "";
        lblmsg.Text = "";
        txtTopic.Text = "";
        txtTopic.Enabled = true;
        EditFile.Visible = false;

        foreach (GridViewRow item in grdlos.Rows)
        {
            CheckBox checkBox = (CheckBox)item.FindControl("chkbox");
            if (checkBox.Checked)
            {
                checkBox.Checked = false;
            }
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        NewFile.Visible = true;
        lblMessage.Text = "";
        lblmsg.Text = "";
        txtTopic.Text = "";
        txtTopic.Enabled = false;
        EditFile.Visible = true;
        hdnFileID.Value = "0";
        foreach (GridViewRow item in grdlos.Rows)
        {
            CheckBox checkBox = (CheckBox)item.FindControl("chkbox");
            if (checkBox.Checked)
            {
                checkBox.Checked = false;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Software Requirement/Knowledge Management/", true);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";


        string folderPathLatest = Server.MapPath("~/Software Requirement/Software/KnowledgeMgmtDocs/Latest/");

        string folderPathArchive = Server.MapPath("~/Software Requirement/Software/KnowledgeMgmtDocs/Archive/");

        string fileName = txtTopic.Text.Trim() + "_" + fuUpload.FileName;


        string strDateTime = DateTime.Now.ToString("yyyyMMddHHmm");
        int FileID = Convert.ToInt32(hdnFileID.Value);


        SqlCommand cmd = new SqlCommand("USP_KnowledgeDocFileUpload", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", FileID);
        cmd.Parameters.AddWithValue("@Topic", txtTopic.Text.Trim());
        cmd.Parameters.AddWithValue("@LatestFileName", fileName);
        cmd.Parameters.AddWithValue("@LatestFilePath", folderPathLatest);
        cmd.Parameters.AddWithValue("@strDateTime", strDateTime);
        cmd.Parameters.AddWithValue("@ArchiveFilePath", folderPathArchive);
        cmd.Parameters.Add("@outPut", SqlDbType.VarChar, 1000);
        cmd.Parameters["@outPut"].Direction = ParameterDirection.Output;
        sqlcon.Open();
        cmd.ExecuteNonQuery();
        string result = Convert.ToString(cmd.Parameters["@outPut"].Value);
        sqlcon.Close();

        if (result != "FILEEXISTS")
        {

            //Archive old file 
            if (FileID != 0)
            {
                if (File.Exists(folderPathLatest + result))
                {
                    string[] fileNameArr = result.Split('.');
                    File.Move(folderPathLatest + result, folderPathArchive + fileNameArr[0] + "_" + strDateTime + "." + fileNameArr[1]);
                }
            }

            //New File
            fuUpload.SaveAs(folderPathLatest + fileName);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = Path.GetFileName(fuUpload.FileName) + " has been uploaded.";

            GetFileDetails();
        }
        else
        {
            lblmsg.ForeColor = System.Drawing.Color.Maroon;
            lblmsg.Text = "TOPIC ALREADY EXISTS.PLEASE ENTER ANOTHER TOPIC OR SELECT FILE TO EDIT.";
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        hdnFileID.Value = "0";
        txtTopic.Text = "";
        txtTopic.Enabled = true;
        lblMessage.Text = "";
        lblmsg.Text = "";


        foreach (GridViewRow item in grdlos.Rows)
        {
            CheckBox checkBox = (CheckBox)item.FindControl("chkbox");
            if (checkBox.Checked)
            {
                checkBox.Checked = false;
            }
        }
    }

    protected void chkbox_CheckedChanged(object sender, EventArgs e)
    {
        int rowid = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

        CheckBox chkbox = (CheckBox)grdlos.Rows[rowid].FindControl("chkbox");

        foreach (GridViewRow rw in grdlos.Rows)
        {
            CheckBox chkBx = (CheckBox)rw.FindControl("chkbox");

            if (chkBx != chkbox)
            {
                chkBx.Checked = false;
            }
            else
            {
                chkBx.Checked = true;
            }
        }

        hdnFileID.Value = grdlos.Rows[rowid].Cells[2].Text;
        txtTopic.Text = grdlos.Rows[rowid].Cells[3].Text;
        txtTopic.Enabled = false;
    }
}