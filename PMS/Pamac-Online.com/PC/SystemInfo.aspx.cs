using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class PC_SystemInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Locationmaster();

        }
    }

    public void Locationmaster()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
        try
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("spLocatioBind", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
           
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            monitorddl.DataSource = dt;
            monitorddl.DataTextField = "locationname";
           

            monitorddl.DataBind();
            monitorddl.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (txtmonitor.Text != "" || txtmachine.Text != "")
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intType", 2);
                cmd.Parameters.AddWithValue("@Machine_Name", txtmachine.Text.ToString());
                cmd.Parameters.AddWithValue("@Monitor_Pamac_Id", txtmonitor.Text.ToString());

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
        else if (txtmonitor.Text == "" && txtmachine.Text == "" && monitorddl.SelectedItem.Text.ToString() != "--All--")
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intType", 3);
                cmd.Parameters.AddWithValue("@locationname", monitorddl.SelectedItem.ToString());

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

        else if (txtmonitor.Text == "" && txtmachine.Text == "" && monitorddl.SelectedValue == "0")
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("spMonitor", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intType",1);
            

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
       
        
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.BackColor = System.Drawing.Color.DarkRed;
        e.Row.ForeColor = System.Drawing.Color.White;
    }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=Report.xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 10;// 10;
        tblCell1.Text = "<br><font size='3' bold='true' color='blue'><b>--SYSTEM REPORT--</b>";


        //tblCell1.Text = "<b><font size='3' color='blue'>PAMAC FINSERVE PVT. LTD., Branch-" + ddlBranchList.SelectedItem.Text + " </font></span></b> <br/>" +
        //                "<b><font size='2' color='blue'>" + lblReportHeader.Text + "  From" + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 5;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();

        GridView1.EnableViewState = false;
        GridView1.GridLines = GridLines.Both;
        GridView1.RenderControl(htw);

        string style = @"<style> TD { mso-number-format:\@; } </style> ";
        Response.Write(style);

        Response.Write(sw.ToString());

        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnexport_Click1(object sender, EventArgs e)
    {

        Generate_ExcelFile();

    }

    protected void btnVerfication_click(object sender, ImageClickEventArgs e)
    {

        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox c = (CheckBox)row.FindControl("CheckBox1");
                hdnmachinename.Value = (row.Cells[1]).Text;

                if (c.Checked)
                {
                    Server.Transfer("VerificationForm.aspx?Machine_Name=" + hdnmachinename.Value);

                }
                else
                {

                    lblMessage.Text = "Please select the checkbox";
                    lblMessage.Visible = true;

                }

            }
        }


    }


    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        string verify = e.Row.Cells[0].Text;

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (verify.ToString() == "Verified")
                {

                    ImageButton imgBtn = (ImageButton)e.Row.FindControl("btnVerfication");
                    imgBtn.Visible = false;
                    CheckBox chk = e.Row.FindControl("CheckBox1") as CheckBox;
                    chk.Visible = false;


                }
            }



        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


}

