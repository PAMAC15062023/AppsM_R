using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Configuration.Assemblies;

public partial class QueryBuilder_Productivity_MIS_DEO_FE : System.Web.UI.Page
{
    public string CenterId = "";
    public string ClientId = "";
    C_QuerryBuilder_MIS_FE obj = new C_QuerryBuilder_MIS_FE();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        SqlDataSourceFE.ConnectionString = objConn.ConnectionString;  //Sir
        SqlDataSourceDE.ConnectionString = objConn.ConnectionString;  //Sir
        SqlDataSourceDE_ALLCentre.ConnectionString = objConn.ConnectionString;  //Sir
        SqlDataSourceFE_AllCentre.ConnectionString = objConn.ConnectionString;  //Sir

        lblMsg.Text = "";
        DataTable dtCentre = new DataTable();  
        if (!IsPostBack)
        {
            //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
            //Created By    :  Gargi Srivastava
            //Created On    :  23-Nov-2007
            Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
            //End Of Code
            try
            {
                string UserId = Session["UserId"].ToString();
                dtCentre = obj.GetCenter(UserId);
                //ViewState["ClientId"] = ClientId;
                ddlCentre.DataSource = dtCentre;
                ddlCentre.DataTextField = "CENTRE_NAME";
                ddlCentre.DataValueField = "CENTRE_ID";
                ddlCentre.DataBind();
           /*-----------Binding ddlFE from DEO Of ALL Centres------------*/
                ddlFE.DataSource = SqlDataSourceDE_ALLCentre;
                ddlFE.DataTextField = "NAME";
                ddlFE.DataValueField = "USER_ID";
                ddlFE.DataBind();
           /*--------------------------END-------------------------------*/
           
            /*---------------------Binding ddlClient to ALL CLIENT--------*/
                string strCentreId = "";
                for (int i = 0; i < dtCentre.Rows.Count; i++)
                {
                    strCentreId = strCentreId + dtCentre.Rows[i]["CENTRE_ID"] + ',';
                }
                strCentreId = strCentreId.TrimEnd(',');
                DataTable dtClient = new DataTable();
                dtClient = obj.GetClient(strCentreId);
                ddlClient.DataSource = dtClient;
                ddlClient.DataTextField = "CLIENT_NAME";
                ddlClient.DataValueField = "CLIENT_ID";
                ddlClient.DataBind();
                /*-------------------------------------------------------*/

            }
            catch(Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = ex.Message.ToString();
            }
        }
    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strCentreId="";
        DataTable dtClient = new DataTable();
        dtClient = obj.GetClient(ddlCentre.SelectedValue);
        ddlClient.DataSource = dtClient;
        ddlClient.DataTextField = "CLIENT_NAME";
        ddlClient.DataValueField = "CLIENT_ID";
        ddlClient.DataBind();
        
        if (rbFE.Checked == true)
        {
            ddlFE.DataSource = SqlDataSourceFE;
            ddlFE.DataTextField = "NAME";
            ddlFE.DataValueField = "USER_ID";
            ddlFE.DataBind();
        }
        if (rbDEO.Checked == true)
        {
            ddlFE.DataSource = SqlDataSourceDE;
            ddlFE.DataTextField = "NAME";
            ddlFE.DataValueField = "USER_ID";
            ddlFE.DataBind();
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        CCommon ObjCmn = new CCommon();
        CProductiveMIS_FE ObjProduct = new CProductiveMIS_FE();
        try
        {
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            ObjProduct.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);
            ObjProduct.ToDate = ObjCmn.string_mm_dd_yy(ToDate);

            string Fdate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string Tdate = ToDate;
            string ddlID = "";

            //obj.FromDate = txtFromDate.Text;
            //ObjProduct.FromDate = txtFromDate.Text;
            //string TDate = txtToDate.Text;
            ////string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            //obj.ToDate = txtToDate.Text;
            //ObjProduct.ToDate = txtToDate.Text;

            //string ToDate = "";
            //string Fdate = txtFromDate.Text;
            //string Tdate = ToDate;
            //string ddlID = "";

            //if (ddlFE.SelectedValue == "0")
            //{
            //    for (int cnt = 1; cnt < ddlFE.Items.Count; cnt++)
            //    {
            //        if (ddlID == "")
            //        {
            //            ddlID = ddlFE.Items[cnt].Value;
            //        }
            //        else
            //        {
            //            ddlID = ddlID + ',' + ddlFE.Items[cnt].Value;
            //        }
            //    }
            //}
            //else
            //{
                ddlID = ddlFE.SelectedValue;
           // }

            ViewState["UserId"] = ddlID;
            /*Getting All Client Id according to Centre*/

            //if (ddlClient.SelectedValue == "0")
            //{
            //    //C_QueryBuilderTAT objTat = new C_QueryBuilderTAT();
            //    //ClientId = objTat.GetClientId(ddlCentre.SelectedValue);
            //    for (int i = 1; i < ddlClient.Items.Count; i++)
            //    {
            //        ClientId = ClientId + ddlClient.Items[i].Value + ',';
            //    }
            //    ClientId = ClientId.TrimEnd(',');
            //}
            //else
            //{
                ClientId = ddlClient.SelectedValue;
            //}
            ViewState["ClientId"] = ClientId;

            //if (ddlCentre.SelectedValue == "0")
            //{
            //    for (int i = 1; i < ddlCentre.Items.Count; i++)
            //    {
            //        CenterId = CenterId + ddlCentre.Items[i].Value + ',';
            //    }
            //    CenterId = CenterId.TrimEnd(',');
            //}
            //else
            //{
                CenterId = ddlCentre.SelectedValue;

           //}
            DataTable dt = new DataTable();
            if (rbDEO.Checked == true)
            {
                //----Added by kamal Matekar

                if (ddlFE.SelectedValue == "0")
                {
                    for (int cnt = 1; cnt < ddlFE.Items.Count; cnt++)
                    {
                        if (ddlID == "")
                        {
                            ddlID = ddlFE.Items[cnt].Value;
                        }
                        else
                        {
                            ddlID = ddlID + ',' + ddlFE.Items[cnt].Value;
                        }
                    }
                }
                else
                {
                    ddlID = ddlFE.SelectedValue;
                }

                ViewState["UserId"] = ddlID;
                /*Getting All Client Id according to Centre*/

                if (ddlClient.SelectedValue == "0")
                {
                    //C_QueryBuilderTAT objTat = new C_QueryBuilderTAT();
                    //ClientId = objTat.GetClientId(ddlCentre.SelectedValue);
                    for (int i = 1; i < ddlClient.Items.Count; i++)
                    {
                        ClientId = ClientId + ddlClient.Items[i].Value + ',';
                    }
                    ClientId = ClientId.TrimEnd(',');
                }
                else
                {
                    ClientId = ddlClient.SelectedValue;
                }
                ViewState["ClientId"] = ClientId;

                if (ddlCentre.SelectedValue == "0")
                {
                    for (int i = 1; i < ddlCentre.Items.Count; i++)
                    {
                        CenterId = CenterId + ddlCentre.Items[i].Value + ',';
                    }
                    CenterId = CenterId.TrimEnd(',');
                }
                else
                {
                    CenterId = ddlCentre.SelectedValue;

                }

                ///------Ended by kamal Matekar


                tblFor_FE.Visible = false;
                dt = obj.rpt_ProductivityMIS(CenterId, ClientId, ddlID);
                if (dt.Rows.Count > 0)
                {
                    tbl.Visible = true;
                    lblMsg.Visible = false;
                    gvMIS_FE_DEO.DataSource = dt;
                    gvMIS_FE_DEO.DataBind();

                    lblFE.Text = ddlFE.SelectedItem.Text;
                    lblFromDate.Text = txtFromDate.Text;
                    lblToDate.Text = txtToDate.Text;
                    lblCentre.Text = ddlCentre.SelectedItem.Text;
                    lblClient.Text = ddlClient.SelectedItem.Text;
                    gvExport.DataSource = dt;
                    gvExport.DataBind();
                }
                else
                {
                    tbl.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "No Record to Display ";
                    gvMIS_FE_DEO.DataSource = "";
                    gvMIS_FE_DEO.DataBind();

                }
            }
            /*For FE.*/
            if (rbFE.Checked == true)
            {
                tbl.Visible = false;
                DataTable dtFE_ProductiveMIS = new DataTable();
                //dtFE_ProductiveMIS = ObjProduct.FEProductiveMIS(CenterId, ClientId, ddlID,"'12/01/2007'","'12/31/2007'");

                dtFE_ProductiveMIS = ObjProduct.FEProductiveMIS_1(CenterId, ClientId, ddlID);

                if (dtFE_ProductiveMIS.Rows.Count > 0)
                {
                    tblFor_FE.Visible = true;
                    gvFE.DataSource = dtFE_ProductiveMIS;
                    gvFE.DataBind();
                }
                else
                {
                    tblFor_FE.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "No Record to Display ";
                }


            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

    }
    protected void ddlClient_DataBound(object sender, EventArgs e)
    {
        //ddlClient.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        tblExport.Visible = true;
        string attachment = "attachment; filename=Productive MIS Of DEO.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();   
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //gvExport.RenderControl(htw);
        gvExport.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void rbFE_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlCentre.SelectedValue != "0")
        {
            ddlFE.DataSource = SqlDataSourceFE;
            ddlFE.DataTextField = "NAME";
            ddlFE.DataValueField = "USER_ID";
            ddlFE.DataBind();
        }
        else
        {
            ddlFE.DataSource = SqlDataSourceFE_AllCentre;
            ddlFE.DataTextField = "NAME";
            ddlFE.DataValueField = "USER_ID";
            ddlFE.DataBind();
        }
    }
    protected void rbDEO_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlCentre.SelectedValue != "0")
        {
            ddlFE.DataSource = SqlDataSourceDE;
            ddlFE.DataTextField = "NAME";
            ddlFE.DataValueField = "USER_ID";
            ddlFE.DataBind();
        }
        else
        {
            ddlFE.DataSource = SqlDataSourceDE_ALLCentre;
            ddlFE.DataTextField = "NAME";
            ddlFE.DataValueField = "USER_ID";
            ddlFE.DataBind();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Productivity_MIS_DEO_FE.aspx");
    }
    protected void btnExportFE_Click(object sender, EventArgs e)
    {
        //tblExport.Visible = true;
        string attachment = "attachment; filename=Productive MIS Of FE.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //gvExport.RenderControl(htw);
        gvFE.GridLines = GridLines.Both;
        gvFE.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
}
