using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class BGC_BGC_BGC_LabelPrinting : System.Web.UI.Page
{


    //CCreditCardGenerateLabel generateclass = new CCreditCardGenerateLabel();
    BGC generateclass = new BGC();

    DataSet ds = new DataSet();
    //CCreditCardGenerateLabel CardGenerateLabel = new CCreditCardGenerateLabel();
    BGC CardGenerateLabel = new BGC();
    CCommon objCmn = new CCommon();
    string Message = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        txtfrom.Focus();
        if (Request.QueryString["FromDt"] != null)
        {
            txtfrom.Text = Convert.ToDateTime(Request.QueryString["FromDt"]).ToString("dd/MM/yyyy");
        }
        if (Request.QueryString["ToDt"] != null)
        {
            txtto.Text = Convert.ToDateTime(Request.QueryString["ToDt"]).ToString("dd/MM/yyyy");
        }
       
        if (Request.QueryString["Message"] != null)
        {
            Message = Request.QueryString["Message"];
            lblMsg.Text = Message;
        }
        else
        {
            lblMsg.Text = "";
        }

        if (Session.Count == 0)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {

            string activityid = Session["ActivityId"].ToString();
            //ds = CardGenerateLabel.GetVerificationType_EBC(activityid);
            ds = CardGenerateLabel.GetVerificationType_BGC(activityid);
            ddlverify.DataTextField = "VERIFICATION_TYPE_CODE";
            ddlverify.DataValueField = "VERIFICATION_TYPE_ID";
            ddlverify.DataSource = ds;
            ddlverify.DataBind();
        }

        //}
                
    }
    protected void ddlverify_DataBound(object sender, EventArgs e)
    {
        ddlverify.Items.Insert(0, new ListItem("--Select verification type--", "0"));
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {

        try
        {

            bool CompareDate = CardGenerateLabel.FunctioncompareDate(txtfrom.Text, txtto.Text);
            if (CompareDate == true)
            {
                string from = "";
                string to = "";
            
                GV.DataSource = "";

                ViewState["FromDate"] = txtfrom.Text;
                ViewState["ToDate"] = txtto.Text;

                string CentreId = Session["CentreId"].ToString();
                string strClient_ID = Session["ClientId"].ToString();
                string strProduct_ID = Session["ProductId"].ToString();
                generateclass.Fromdate = objCmn.strDate(txtfrom.Text);

                string Tdate = txtto.Text;
                generateclass.Todate = Convert.ToDateTime(objCmn.strDate(Tdate)).AddDays(1.0).ToString("dd-MMM-yyyy");
                      
                //ds = generateclass.getGridValue_EBC(CentreId, strClient_ID);

               ds = generateclass.getGridValue_BGC(CentreId, strClient_ID); 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GV.DataSource = ds;
                    GV.DataBind();
                }
                else
                {
                    GV.DataSource = "";
                    GV.DataBind();
                    lblMsg.Text = "Record not found.";
                }

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "From date should be less than To Date.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while generating report: " + ex.Message;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            bool CompareDate = CardGenerateLabel.FunctioncompareDate(txtfrom.Text, txtto.Text);
            if (CompareDate == true)
            {
                Session["VerificationId"] = ddlverify.SelectedValue;
                Session["Verification_Type"] = ddlverify.SelectedItem.Text;
                Session["fromdate"] = objCmn.strDate(txtfrom.Text);
                Session["todate"] = objCmn.strDate(txtto.Text);
                Response.Redirect("BGC_GenerateLabel.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "From date should be less than To Date.";
            }

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while generating report: " + ex.Message;
        }

     

    }
}
