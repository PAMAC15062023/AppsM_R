using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class PC_Adminvisible : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //BindLocation();
        }
    }



    protected void btnreport_Click(object sender, EventArgs e)
    {


        Object SaveUSERInfo = (Object)Session["UserInfo"];
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (ddlreport.SelectedValue == "ALL")
        {

            try
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@intType", 1);
                adp.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ALL.xls"));
                Response.ContentType = "application/ms-excel";

                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
        else if (ddlreport.SelectedValue == "OS-Licence")
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@intType", 6);
                adp.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "OSLicence.xls"));
                Response.ContentType = "application/ms-excel";

                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }

        else if (ddlreport.SelectedValue == "OS-No Licence")
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@intType", 8);
                adp.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "OS-NO-Licence.xls"));
                Response.ContentType = "application/ms-excel";

                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
        else if (ddlreport.SelectedValue == "Office Licence")
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@intType", 10);
                adp.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "OS-NO-Licence.xls"));
                Response.ContentType = "application/ms-excel";

                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }

        else if (ddlreport.SelectedValue == "Office No Licence")
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@intType", 9);
                adp.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "OS-NO-Licence.xls"));
                Response.ContentType = "application/ms-excel";

                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
        else
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("spGetverifyDetails", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "VerifiedReport.xls"));
                Response.ContentType = "application/ms-excel";

                string str = string.Empty;
                foreach (DataColumn dtcol in dt.Columns)
                {
                    Response.Write(str + dtcol.ColumnName);
                    str = "\t";
                }
                Response.Write("\n");
                foreach (DataRow dr in dt.Rows)
                {
                    str = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Response.Write(str + Convert.ToString(dr[j]));
                        str = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetmachindDetails();
    }


    public void GetmachindDetails()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        try
        {
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Machine_Name", txtmachinename.Text);
            cmd.Parameters.AddWithValue("@intType", 2);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnedit_click(object sender, ImageClickEventArgs e)
    {


        try
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    //CheckBox c = (CheckBox)row.FindControl("CheckBox1");
                    hdnmachinename.Value = (row.Cells[0]).Text;


                    Server.Transfer("EditRecord.aspx?Machine_Name=" + hdnmachinename.Value);




                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlreport.SelectedValue == "0")
        {
            btnreport.Visible = false;

        }
        else
        {

            btnreport.Visible = true;
        }
    }

    //public void BindLocation()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];
    //    //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //    CCommon objConn = new CCommon();
    //    SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    try
    //    {

    //        sqlcon.Open();
    //        SqlCommand cmd = new SqlCommand("spMonitor", sqlcon);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@intType", 11);
    //        DataTable dt = new DataTable();
    //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
    //        adp.Fill(dt);
    //        ddllocation.DataSource = dt;

    //        ddllocation.DataTextField = "BranchName";
    //        ddllocation.DataValueField = "BranchId";
    //        ddllocation.DataBind();
    //        ddllocation.Items.Insert(0, new ListItem("--Select--", "0"));

    //    }
    //    catch (Exception ex)
    //    {

    //        throw;
    //    }
    //}
    
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}