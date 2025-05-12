using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class HR_HR_Hr_UploadFile : System.Web.UI.Page
{
    CHR_UploadFiles objHRUploadFiles = new CHR_UploadFiles();
    CCommon objconn = new CCommon();
    OleDbConnection sqlconn = new OleDbConnection();
    string filename_Attachment;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnBatchUpload.Visible = false;
            tblLable.Visible = false;
            PnlBISUpload.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        lblMessage.Text = "";
        lblEmpCode.Text = "";
        lblEmpName.Text = "";
        lblClusterName.Text = "";
        lblCentreName.Text = "";
        lblSubCentreName.Text = "";
        PropertySet();
        
        
        if ((txtEmpCode.Text.Trim() != "") && (txtEmployeeName.Text.Trim() == ""))
        {
            btnBatchUpload.Visible = true;
            tblLable.Visible = true;
            FillUploadGrid();
            Searchemp_code();
            gvUpload.Visible = true;
            GetLableValues(objHRUploadFiles.EmpCode);
            gvCheckSelect.Visible = false;
            PnlBISUpload.Visible = true;
        }

        else if ((txtEmpCode.Text.Trim() != "") && (txtEmployeeName.Text.Trim() != ""))
        {
            btnBatchUpload.Visible = true;
            tblLable.Visible = true;
            FillUploadGrid();
            
            GetLableValues(objHRUploadFiles.EmpCode);
            gvUpload.Visible = true;
            gvCheckSelect.Visible = false;
            PnlBISUpload.Visible = true;
        }
        else 
        {
            gvCheckSelect.Visible = true;
            tblLable.Visible = false;
            FillSelectionGrid();
            gvUpload.Visible = false;
            btnBatchUpload.Visible = false;
            PnlBISUpload.Visible = true;
        }
        LinkViewVisibility();
       
    }
    private void FillSelectionGrid()
    {
        //DataTable dtNew = new DataTable();
        //DataRow dr;
        DataTable dt = new DataTable();
        //PropertySet();
        dt = objHRUploadFiles.GetUploadSelection();
        //dtNew.Columns.Add("#");
        //dtNew.Columns.Add("EMP Code");
        //dtNew.Columns.Add("Name");
        //dtNew.Columns.Add("Date of Joining");
        //dtNew.Columns.Add("Designation");
        //dtNew.Columns.Add("Department");
        //dtNew.Columns.Add("Unit");
        //dtNew.Columns.Add("Cluster Name");
        //dtNew.Columns.Add("Centre Name");
        //dtNew.Columns.Add("Sub-Centre Name");
        //dtNew.Columns.Add("Kit Received Date");

        if (dt.Rows.Count > 0)
        {
            //int j = 1;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dr = dtNew.NewRow();
            //    dr[0] = j.ToString() + i;

            //    dr[1] = dt.Rows[i]["EMP Code"].ToString();
            //    dr[2] = dt.Rows[i]["Name"].ToString();
            //    dr[3] = dt.Rows[i]["Date of Joining"].ToString();
            //    dr[4] = dt.Rows[i]["Designation"].ToString();
            //    dr[5] = dt.Rows[i]["Department"].ToString();
            //    dr[6] = dt.Rows[i]["Unit"].ToString();
            //    dr[7] = dt.Rows[i]["Cluster Name"].ToString();
            //    dr[8] = dt.Rows[i]["Centre Name"].ToString();
            //    dr[9] = dt.Rows[i]["Sub-Centre Name"].ToString();
            //    dr[10] = dt.Rows[i]["Kit Received Date"].ToString();

            //    dtNew.Rows.Add(dr);
            gvCheckSelect.DataSource = dt;
            gvCheckSelect.DataBind();

        }
        else
        {
            gvCheckSelect.DataSource = null;

            gvCheckSelect.DataBind();
            btnBatchUpload.Visible = false;
            lblMessage.Text = "No Records Found!";
        }

    }
    private void FillUploadGrid()
    {
        //DataTable dtNew = new DataTable();
        //DataRow dr;
        DataTable dt = new DataTable();
        
        dt = objHRUploadFiles.GetUploadSearch();
        //dtNew.Columns.Add("#");
        //dtNew.Columns.Add("EMP Code");
        //dtNew.Columns.Add("Name");
        //dtNew.Columns.Add("Date of Joining");
        //dtNew.Columns.Add("Designation");
        //dtNew.Columns.Add("Department");
        //dtNew.Columns.Add("Unit");
        //dtNew.Columns.Add("Cluster Name");
        //dtNew.Columns.Add("Centre Name");
        //dtNew.Columns.Add("Sub-Centre Name");
        //dtNew.Columns.Add("Kit Received Date");

        if (dt.Rows.Count > 0)
        {
            //int j = 1;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dr = dtNew.NewRow();
            //    dr[0] = j.ToString() + i;

            //    dr[1] = dt.Rows[i]["EMP Code"].ToString();
            //    dr[2] = dt.Rows[i]["Name"].ToString();
            //    dr[3] = dt.Rows[i]["Date of Joining"].ToString();
            //    dr[4] = dt.Rows[i]["Designation"].ToString();
            //    dr[5] = dt.Rows[i]["Department"].ToString();
            //    dr[6] = dt.Rows[i]["Unit"].ToString();
            //    dr[7] = dt.Rows[i]["Cluster Name"].ToString();
            //    dr[8] = dt.Rows[i]["Centre Name"].ToString();
            //    dr[9] = dt.Rows[i]["Sub-Centre Name"].ToString();
            //    dr[10] = dt.Rows[i]["Kit Received Date"].ToString();

            //    dtNew.Rows.Add(dr);
            gvUpload.DataSource=dt;
            gvUpload.DataBind();

            }
        else
        {
            gvUpload.DataSource = null;
            
            gvUpload.DataBind();
            btnBatchUpload.Visible = false;
            tblLable.Visible = false;
            lblMessage.Text = "No Records Found!";
        }
       
    }
    private void PropertySet()
    {
        try
        {
            if (txtEmpCode.Text == "")
            {
                objHRUploadFiles.EmpCode = null;
            }
            else
            {
                objHRUploadFiles.EmpCode = txtEmpCode.Text.Trim();
                hdnEmpCode.Value = txtEmpCode.Text.Trim();
            }
            if (txtEmployeeName.Text == "")
            {
                objHRUploadFiles.EmpName = null;
            }
            else
            {
                objHRUploadFiles.EmpName = txtEmployeeName.Text.Trim().Replace(' ','%');
            }
           
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error while retreiving records:Property Set " + ex.Message;
        }
    }

    private void CheckSelectedEmp()
    {
        if (gvCheckSelect.Rows.Count > 0)
        {

            for (int i = 0; i < gvCheckSelect.Rows.Count; i++)
            {
                GridViewRow dgRow = gvCheckSelect.Rows[i];
                RadioButton rdoSelect = (RadioButton)dgRow.Cells[0].FindControl("rdoSelect");
                if (rdoSelect.Checked == true)
                {
                    objHRUploadFiles.EmpCode = gvCheckSelect.DataKeys[i]["Employee Code"].ToString();
                    hdnEmpCode.Value = objHRUploadFiles.EmpCode;
                    tblLable.Visible = true;
                    GetLableValues(objHRUploadFiles.EmpCode);


                }
               
            }
        }
        else
        {
            PropertySet();
            tblLable.Visible = true;
            GetLableValues(objHRUploadFiles.EmpCode);
        }
        
               
    }
    private void BatchUploadFile()
    {
        if (gvUpload.Rows.Count > 0)
        {
            for (int i = 0; i < gvUpload.Rows.Count; i++)
            {
                FileUpload FileUploadC = new FileUpload();




                FileUploadC = (FileUpload)gvUpload.Rows[i].FindControl("FileUpload1");
                
                if (FileUploadC.HasFile == true)
                {
                    string strFile = FileUploadC.FileName.ToString();
                    string strFileContentType = FileUploadC.PostedFile.ContentType.ToString();
                    string[] strArrayFileContentType = strFileContentType.Split('/');
                    string[] strArrayFile = strFile.Split('.');
                    //for (int j = 0; j < strArrayFile.Length; j++)
                    //{
                    
                    string strFileType = "";
                    string strFileNameWithEmpCode = "";
                   
                    if (strArrayFile[1] != null && strArrayFile[1].ToString() != "")
                    {
                        
                        if (i == 0)
                        {
                            //if ((strArrayFile[1].ToString() == "bmp") || (strArrayFile[1].ToString() == "gif") || (strArrayFile[1].ToString() == "jpeg") || (strArrayFile[1].ToString() == "jpg") || (strArrayFile[1].ToString() == "png") || (strArrayFile[1].ToString() == "psd") || (strArrayFile[1].ToString() == "psp") || (strArrayFile[1].ToString() == "tif"))
                            //{
                            if (strArrayFileContentType[0] == "image")
                            {

                                //gvUpload.DataKeys[i]["UploadFilePath"].ToString();
                                //string strFilePath = Server.MapPath("Upload") + "\\" + strFile;
                                string strFilePath = Server.MapPath("EmployeePhoto") + "\\" + gvUpload.DataKeys[i]["Employee Code"] + "." + strArrayFile[1].ToString();
                                strFileNameWithEmpCode = gvUpload.DataKeys[i]["Employee Code"] + "." + strArrayFile[1].ToString();
                                DeleteEmployeePhoto(gvUpload.DataKeys[i]["UploadFilePath"].ToString());
                                //string strQuery = "Update Employee_Master set PHOTO_PATH='" + strFile + "' where EMP_ID=" + Convert.ToInt32(gvUpload.DataKeys[i]["ID"]);
                                //OleDbCommand sqlCmd = new OleDbCommand(strQuery, sqlconn);
                                //sqlconn.Open();
                                //int j = (int)sqlCmd.ExecuteNonQuery();
                                //sqlconn.Close();

                                objHRUploadFiles.UploadEmpMaster(strFileNameWithEmpCode, Convert.ToInt32(gvUpload.DataKeys[i]["ID"]));
                                if (FileUploadC.HasFile)
                                    FileUploadC.PostedFile.SaveAs(strFilePath);
                                
                            }
                            else
                            {
                                hidMessage.Value = "Please Select an Image File to Upload the Potograph.";
                            }
                        }
                        //else
                        //{
                        //    lblMessage.Text = "Please Select Valid File Format for Upload...";
                        //}


                        else
                        {
                            if (i >= 1)
                            {

                                //string strFilePath = Server.MapPath("Upload") + "\\" + strFile;
                                string strFilePath = Server.MapPath("EmployeeDocument") + "\\" + gvUpload.DataKeys[i]["Employee Code"] + strArrayFile[0].ToString() + "." + strArrayFile[1].ToString();
                                strFileNameWithEmpCode = gvUpload.DataKeys[i]["Employee Code"] + strArrayFile[0].ToString() + "." + strArrayFile[1].ToString();
                                DeleteEmployeeDocument(gvUpload.DataKeys[i]["UploadFilePath"].ToString());
                                //string strQuery = "Update EMPLOYEE_EDUCATION_QUALIFICATION set File_Path='" + strFile + "' where EMP_ID=" + Convert.ToInt32(gvUpload.DataKeys[i]["ID"]) + " and Education_Qualification_Id=" + Convert.ToInt32(gvUpload.DataKeys[i]["Education_Qualification_Id"]);
                                //SqlCommand sqlCmd = new SqlCommand(strQuery, sqlconn);
                                //sqlconn.Open();
                                //int j = (int)sqlCmd.ExecuteNonQuery();
                                //sqlconn.Close();

                                objHRUploadFiles.UploadEmpQualification(strFileNameWithEmpCode, Convert.ToInt32(gvUpload.DataKeys[i]["ID"]), Convert.ToInt32(gvUpload.DataKeys[i]["Education_Qualification_Id"]), "Yes");
                                FileUploadC.PostedFile.SaveAs(strFilePath);
                               
                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
        }


                   

}
         
     

    private struct GridPosition
    {
        public const int ID = 0;
        public const int EMPLOYEECODE = 1;
        public const int NAME = 2;
        public const int DOCTYPE = 3;
        public const int EDUCATIONQUALIFICATIONID = 4;
        public const int DOCUMENTNAME = 5;
        public const int FILENAME = 6;
        public const int VIEWFILE = 7;


    }
    
    protected void btnBatchUpload_Click(object sender, EventArgs e)
    {
        hidMessage.Value = "";
        BatchUploadFile();

        CheckSelectedEmp();
        objHRUploadFiles.EmpCode=hdnEmpCode.Value;
        FillUploadGrid();

        LinkViewVisibility();
        lblMessage.Text = "";
        if (hidMessage.Value != "")
        {
            lblMessage.Text = hidMessage.Value;
        }
        else
        {
            lblMessage.Text = "File Uploaded Successfully!";
        }
        
    }
    protected void rdoSelect_CheckedChanged(object sender, EventArgs e)
    {

        RadioButton chk = (RadioButton)sender;
        hdnId.Value = chk.ClientID;


        foreach (GridViewRow row in gvCheckSelect.Rows)
        {
            RadioButton chk1 = (RadioButton)(row.FindControl("rdoSelect"));
           // HiddenField hdn = (HiddenField)(row.FindControl("hdnProfileId"));
            if (hdnId.Value == chk1.ClientID)
            {
                chk1.Checked = true;
                //Session["AuthenticatinProfileId"] = hdn.Value;
            }
            else
            {
                chk1.Checked = false;
            }
        }


        gvUpload.Visible = true;
        btnBatchUpload.Visible = true;
        CheckSelectedEmp();
        lblMessage.Text = "";
        FillUploadGrid();
        PnlBISUpload.Visible = true;
        grdGrid.Visible = false;
        LinkViewVisibility();
       
    }
    private void GetLableValues(string empCode)
    {
       
        OleDbDataReader oledbDRGet;

        oledbDRGet = objHRUploadFiles.GetRecordsofLable(empCode);
        if (oledbDRGet.Read())
        {
            if (!(oledbDRGet["Employee Code"].ToString().Trim().Length.Equals(0)))
                lblEmpCode.Text = oledbDRGet["Employee Code"].ToString();

            if (!(oledbDRGet["Name"].ToString().Trim().Length.Equals(0)))
                lblEmpName.Text = oledbDRGet["Name"].ToString();

            if (!(oledbDRGet["Cluster Name"].ToString().Trim().Length.Equals(0)))
                lblClusterName.Text = oledbDRGet["Cluster Name"].ToString();

            if (!(oledbDRGet["Centre Name"].ToString().Trim().Length.Equals(0)))
                lblCentreName.Text = oledbDRGet["Centre Name"].ToString();

            if (!(oledbDRGet["Subcentre Name"].ToString().Trim().Length.Equals(0)))
                lblSubCentreName.Text = oledbDRGet["Subcentre Name"].ToString();

        }
        else
        oledbDRGet.Close();
        oledbDRGet.Dispose();
    }

    private void LinkViewVisibility()
    {
        for (int i = 0; i < gvUpload.Rows.Count; i++)
        {
            if (gvUpload.DataKeys[i]["UploadFilePath"].ToString() != null && (gvUpload.DataKeys[i]["UploadFilePath"].ToString()) != "")
            {
                GridViewRow gvRow = gvUpload.Rows[i];
                HyperLink lnkViewPhoto = (HyperLink)gvRow.Cells[GridPosition.VIEWFILE].FindControl("lnkViewPhoto");
                HyperLink lnkViewDocument = (HyperLink)gvRow.Cells[GridPosition.VIEWFILE].FindControl("lnkViewDocument");
                if (i == 0)
                {
                    lnkViewPhoto.Visible = true;
                }
                else if (i >= 1)
                {
                    lnkViewDocument.Visible = true;
                }
            }
        }
    }


    protected void gvUpload_DataBound(object sender, EventArgs e)
    {
        Session["RowCount"] = gvUpload.Rows.Count;
    }
    protected void gvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {

            string queryArgument = e.CommandArgument.ToString();
       
            string empID="";
            string qID="";
            string textFileName = "";
            string DocumentName ="";
           string empCode="";
           string[] arrQuery = queryArgument.Split('*');
           // for (int i = 0; i < arrQuery.Length-1; i++)
             // {
                //  if (arrQuery[0].Length > 0)
                // {
                     empCode = arrQuery[0].ToString();
                // }
                 //if (arrQuery[1].Length > 0)
                 //{
                     empID = arrQuery[1].ToString();
                // }
               // if (arrQuery[2].Length > 0)
                // {
                     qID = arrQuery[2].ToString();
                // }
                 //if (arrQuery[3].Length > 0)
                // {
                     DocumentName = arrQuery[3].ToString();
                // }
                //if (arrQuery[4].Length > 0)
                //{
                    textFileName = arrQuery[4].ToString();
                //}
             //}
                     if ((textFileName == "") || (textFileName == null))
                     {
                         this.Page.ClientScript.RegisterStartupScript(this.GetType(),"","<script language=javascript>alert('File does not exists !')</script>");
                     }
                     else
                     {
                         
                         if (DocumentName == "Photograph")
                         {


                             DeleteEmployeePhoto(textFileName);
                             objHRUploadFiles.UploadEmpMaster("", Convert.ToInt32(empID));
                         }


                         else
                         {

                             DeleteEmployeeDocument(textFileName);
                             objHRUploadFiles.UploadEmpQualification("", Convert.ToInt32(empID), Convert.ToInt32(qID),"No");

                         }
                         lblMessage.Text = "File Deteted Successfully.";
                         objHRUploadFiles.EmpCode = empCode;
                         FillUploadGrid();
                         LinkViewVisibility();
                         
                     }

             
        

    }
    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");

        //    if ((e.Row.Cells[6].Text == "") || (e.Row.Cells[6].Text == null))
        //    {
        //        lbDelete.Attributes.Add("onclick", "javascript:return " +
        //                   "confirm('The File does not Exist')");
        //    }
        //    else
        //    {

        //        lbDelete.Attributes.Add("onclick", "javascript:return " +
        //                      "confirm('Are you sure you want to delete this record')");
        //    }
        //}
    }

    private void DeleteEmployeePhoto(string fileName)
    {
        try
        {
            FileInfo TheFile = new FileInfo(MapPath("EmployeePhoto" + "//" + fileName));
            if (TheFile.Exists)
            {
                File.Delete(MapPath("EmployeePhoto" + "//" + fileName));
            }
            //else
            //{
            //    throw new FileNotFoundException();
            //}
        }
        //catch (FileNotFoundException ex)
        //{
        //    lblMessage.Text += ex.Message;
        //}
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
    }

    private void DeleteEmployeeDocument(string fileName)
    {
        try
        {
            FileInfo TheFile = new FileInfo(MapPath("EmployeeDocument" + "//" + fileName));
            if (TheFile.Exists)
            {
                File.Delete(MapPath("EmployeeDocument" + "//" + fileName));
            }
            //else
            //{
            //    throw new FileNotFoundException();
            //}
        }
        //catch (FileNotFoundException ex)
        //{
        //    lblMessage.Text += ex.Message;
        //}
        catch (Exception ex)
        {
            lblMessage.Text += ex.Message;
        }
    }


    //added by abhijeet//


    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                }
            }
            if (forceDownload)

                Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            }
            if (type != "")

                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attached Document Found...!!!";
        }
    }

    protected void grdGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkdownload = (LinkButton)e.Row.FindControl("lnkdownload");
            //LinkButton lnkdownload2 = (LinkButton)e.Row.FindControl("lnkdownload2");
            //LinkButton lnkdownload3 = (LinkButton)e.Row.FindControl("lnkdownload3");


            if (lnkdownload.CommandArgument == "")
            {
                lnkdownload.Enabled = false;
                lnkdownload.ToolTip = "No Attachment Found...!!!";
            }
            //if (lnkdownload2.CommandArgument == "")
            //{
            //    lnkdownload2.Enabled = false;
            //    lnkdownload2.ToolTip = "No Attachment Found...!!!";
            //}
            //if (lnkdownload3.CommandArgument == "")
            //{
            //    lnkdownload3.Enabled = false;
            //    lnkdownload3.ToolTip = "No Attachment Found...!!!";
            //}
        }
    }








    private string UploadAttachment_OnServer1()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string strPath = Server.MapPath("EmployeeDocument//");

                strPath = strPath.Trim();
                filename_Attachment = (FileUpload1.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;



                FileUpload1.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return "";
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "HR_SaveUploadData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter emp_id = new SqlParameter();
            emp_id.SqlDbType = SqlDbType.VarChar;
            emp_id.Value = hdnempid.Value;
            emp_id.ParameterName = "@Emp_Id";
            sqlcmd.Parameters.Add(emp_id);

            SqlParameter filepath = new SqlParameter();
            filepath.SqlDbType = SqlDbType.VarChar;
            filepath.Value = UploadAttachment_OnServer1();
            filepath.ParameterName = "@File_Path";
            sqlcmd.Parameters.Add(filepath);


            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            lblMessage.Visible = true;
            lblMessage.Text = "Data Updated Successfuly !!!!!!!";
            //  clearcontrol();

            sqlCon.Close();



        }
        catch
        {



        }


        //CheckSelectedEmp();
        ////Search();
        //lblMessage.Text = "";
        //FillUploadGrid();


        Search12();
        grdGrid.Visible = true;
    }


    private void Search()
    {
        string abc;
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);
        try
        {
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getdata_upload";
            cmd.CommandTimeout = 0;

            SqlParameter emp_code = new SqlParameter();
            emp_code.SqlDbType = SqlDbType.VarChar;
            emp_code.Value = hdnEmpCode.Value;
            emp_code.ParameterName = "@emp_code";
            cmd.Parameters.Add(emp_code);

            Label l1 = new Label();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l1.Text = dr.GetValue(0).ToString();
                //abc = dr.ToString();
            }


            hdnempid.Value = l1.Text;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //DataTable dt = new DataTable();
            //da.Fill(dt);





            sqlCon.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    lblMessage.Text = "";
            //    lblMessage.Text = "Total Count Is :";

            //    //GrdView.DataSource = dt;
            //    //GrdView.DataBind();

            //}
            //else
            //{
            //    //lblmsg.Text = "";
            //    //lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

            //    //GrdView.DataSource = null;
            //    //GrdView.DataBind();
            //}
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }


    private void Searchemp_code()
    {
        string abc;
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);
        try
        {
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getdata_upload";
            cmd.CommandTimeout = 0;

            SqlParameter emp_code = new SqlParameter();
            emp_code.SqlDbType = SqlDbType.VarChar;
            emp_code.Value = txtEmpCode.Text.ToString();
            emp_code.ParameterName = "@emp_code";
            cmd.Parameters.Add(emp_code);

            Label l1 = new Label();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l1.Text = dr.GetValue(0).ToString();
                //abc = dr.ToString();
            }


            hdnempid.Value = l1.Text;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //DataTable dt = new DataTable();
            //da.Fill(dt);





            sqlCon.Close();

            //if (dt.Rows.Count > 0)
            //{
            //    lblMessage.Text = "";
            //    lblMessage.Text = "Total Count Is :";

            //    //GrdView.DataSource = dt;
            //    //GrdView.DataBind();

            //}
            //else
            //{
            //    //lblmsg.Text = "";
            //    //lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

            //    //GrdView.DataSource = null;
            //    //GrdView.DataBind();
            //}
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }


    private void Search12()
    {
        string abc;
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);
        try
        {
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getdata_upload12";
            cmd.CommandTimeout = 0;

            SqlParameter emp_id = new SqlParameter();
            emp_id.SqlDbType = SqlDbType.VarChar;
            emp_id.Value = hdnempid.Value;
            emp_id.ParameterName = "@emp_id";
            cmd.Parameters.Add(emp_id);

            //Label l1 = new Label();
            //SqlDataReader dr;
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    l1.Text = dr.GetValue(0).ToString();
            //    //abc = dr.ToString();
            //}


            //hdnempid.Value = l1.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);





            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "";
                lblMessage.Text = "BIS Uploading Successfully Done...";

                grdGrid.DataSource = dt;
                grdGrid.DataBind();

            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Total Count Is :" + dt.Rows.Count;

                grdGrid.DataSource = null;
                grdGrid.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }




    //ended by abhijeet//

    
}
