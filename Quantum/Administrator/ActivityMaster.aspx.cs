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
using System.Data.OleDb;


public partial class ActivityMaster : System.Web.UI.Page
{
    private string strSelected;
    CCommon con = new CCommon();
    string strallreadyunchecked = "";
    string strAllreadyChecked = "";
    HiddenField hidRefiD;
    CheckBox chkCentreId;
   
    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();

        sdsgvActivityMaster.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCentremaster.ConnectionString = objConn.ConnectionString;  //Sir


        OleDbConnection sqlconn = new OleDbConnection(con.ConnectionString);
        String strActivityID = "";
        CActivityMaster objCA = new CActivityMaster();
        try
        {
            String strCentreID = "";
            lblMsg.Text = "";
           
            if (Request.QueryString["ACTIVITY_ID"] != null && Request.QueryString["ACTIVITY_ID"] != "")
            {
                lblMsg.Text = "Edit";
                if (!IsPostBack)
                {
                    strActivityID = Request.QueryString["ACTIVITY_ID"];
                    sdsCentremaster.SelectCommand = "select  distinct cm.Centre_Id, cm.Centre_Name, Centre_Code," +
                                                  " cv.Centre_Id as keycolumn from centre_master CM left join " +
                                                  " ce_ac_pr_ct_vw cv on cm.Centre_Id = cv.Centre_Id and " +
                                                  " cv.Activity_Id = '" + strActivityID + "' ";
                    objCA.ActivityID = strActivityID;
                    HiddenField1.Value = strActivityID;
                    objCA.GetActivity();

                    txtActivityName.Text = objCA.ActivityName;
                    txtActivityCode.Enabled = false;
                    valActivityCode.Enabled = false;
                    foreach (GridViewRow row in gvCompany.Rows)
                    {
                        hidRefiD = (HiddenField)row.FindControl("HiddenCentreID");
                        chkCentreId = (CheckBox)row.FindControl("chkHierId");
                        if (!chkCentreId.Checked)
                        {
                            strallreadyunchecked = strallreadyunchecked + hidRefiD.Value + ',';
                        }
                        else
                        {
                            strAllreadyChecked = strAllreadyChecked + hidRefiD.Value + ',';
                        }
                    }
                     hidallredyuncheacked.Value = strallreadyunchecked;
                     hidAllReadyChecked.Value = strAllreadyChecked;
                }
            }

        }
        catch (Exception exp)
        {
 
        }
        sdsCentremaster.SelectCommand = "select  distinct cm.Centre_Id, cm.Centre_Name, Centre_Code, cv.Centre_Id as keycolumn from centre_master CM left join ce_ac_pr_ct_vw cv on cm.Centre_Id = cv.Centre_Id and cv.Activity_Id = '" + strActivityID + "'";
        sdsCentremaster.DataBind();

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string selected = "";
        string strSelecteCentreId = "";
        string strunselectedCentreID = "";
        string strcentreID = "";
        string strCentre = "";
        string strCentre1 = "";
        string strKeyColumn = "";
        HiddenField hidkeycolumn;
        
        HiddenField hidCentreId1;
        
        string strRefid="";
        if (Request.QueryString["ACTIVITY_ID"] != null && Request.QueryString["ACTIVITY_ID"] != "")
        {
            CActivityMaster objCM = new CActivityMaster();
          
            OleDbDataReader dr;
            String Sql = "";
            Sql = "select HIER_ID from company_hierarchy_master chm inner join activity_master cl on( cl.activity_id=chm.ref_id) where chm.type='AC' and cl.activity_id =" + HiddenField1.Value.ToString();
            dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, Sql);

            while (dr.Read())
            {
                selected = selected + Convert.ToInt32(dr[0]) + ",";

            }
            dr.Close();

            objCM.SelectedID = selected;

            objCM.ActivityID = HiddenField1.Value;
            objCM.ActivityName = txtActivityName.Text;

        


            string chk = "";

            Session["str"] = chk;
            foreach (GridViewRow row in gvCompany.Rows)
            {
                hidkeycolumn = (HiddenField)row.FindControl("hidHierId");
                chkCentreId = (CheckBox)row.FindControl("chkHierId");
                hidRefiD = (HiddenField)row.FindControl("HiddenCentreID");
               
                if (chkCentreId.Checked)
                {
                    strSelecteCentreId = strSelecteCentreId + hidRefiD.Value + ",";

                    strKeyColumn = strKeyColumn + hidkeycolumn.Value + ",";
                   
                    chk = "true";
                    Session["str"] = chk;
                    if (hidkeycolumn.Value == "")
                    {
                        strRefid = strRefid + hidRefiD.Value + ",";


                    }

                }
                else
                {
                     strunselectedCentreID = strunselectedCentreID + hidRefiD.Value + ",";
                                        
                       strRefid = strRefid + hidRefiD.Value + ",";
                    
                }


               
            }

            objCM.keycolumn = strKeyColumn;
            string[] unselected = strunselectedCentreID.Split(',');
            string[] Allreadyunchecked = hidallredyuncheacked.Value.Split(',');
            string strforDelete = "";
            ViewState["str1"] = "";
            foreach(string str in unselected)
            {
                if (str != "")
                {

                    foreach (string str1 in Allreadyunchecked)
                    {
                         ViewState["str1"] = str1;
                        if (str1 != "")
                        {
                            if (str == str1)
                            {
                                break;
                            }
                            
                               
                            
                        }                       
                   }
                   if (ViewState["str1"].ToString()!=str)
                       strforDelete = strforDelete + str + ',';    
                }


            }

            string[] selectedcentreID = strSelecteCentreId.Split(',');

            string[] AllreadyChecked = hidAllReadyChecked.Value.Split(',');
            string strforchange = "";
            ViewState["str2"] = "";

            foreach (string str in selectedcentreID)
            {
                if (str != "")
                {

                    foreach (string str1 in AllreadyChecked)
                    {
                        ViewState["str2"] = str1;
                        if (str1 != "")
                        {
                            if (str == str1)
                            {
                                break;
                            }



                        }
                    }
                    if (ViewState["str2"].ToString() != str)
                        strforchange = strforchange + str + ',';
                }


            }
          

           try
           {

              

               if (strforchange != "")
               {
                   objCM.ChangeActivty(strforchange);
                   lblMsg.Visible = true;

                   lblMsg.Text = objCM.Massage;
               }

               if (strforDelete != "")
               {
                   objCM.DeletActivity(strforDelete);

                   lblMsg.Text = objCM.Massage;
               }

             
           }
            catch(Exception ex)
             {

            }
                 objCM.UpdateActivity();
                
                Session["msg3"] = lblMsg.Text;
               Response.Redirect("ActivityViewMaster.aspx");
        }
        else
        {
            CActivityMaster objCM = new CActivityMaster();
            objCM.ActivityName = txtActivityName.Text.Trim();
            objCM.SelectedID = getSelected();
            string selected1 = "";
            foreach (GridViewRow row in gvCompany.Rows)
            {
                hidCentreId1 = (HiddenField)row.FindControl("HiddenCentreID");
                chkCentreId = (CheckBox)row.FindControl("chkHierId");
                if (chkCentreId.Checked)
                    strSelecteCentreId = strSelecteCentreId + hidCentreId1.Value + ",";
            }
            string[] selectedcentreID = strSelecteCentreId.Split(',');
            foreach (string str in selectedcentreID)
            {
                if (str != "")
                {
                    string sql = "select  distinct cm.Centre_Id from centre_master CM left join ce_ac_pr_ct_vw cv on cm.Centre_Id = cv.Centre_Id where cm.centre_id=" + "'" + str.ToString() + "'";

                    objCM.CentreID = OleDbHelper.ExecuteScalar(con.ConnectionString, CommandType.Text, sql).ToString();

                    string sql2 = "select hier_id from company_hierarchy_master co inner join centre_master cl on (co.ref_id=cl.centre_id) where  type='CE' and centre_id=" +str.ToString();
                    OleDbDataReader dr;
                    dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sql2);


                    while (dr.Read())
                    {
                        selected1 = selected1 + Convert.ToInt32(dr[0]) + ",";

                    }

                }
                
            }
            objCM.CentreHierID = selected1.TrimEnd(',');

            bool chkbox = false;
            foreach (GridViewRow gvRow in gvCompany.Rows)
            {
                
                if (((CheckBox)gvRow.FindControl("chkHierId")).Checked == true)
                {
                    chkbox = true;
                    break;

                }
                
            }
            if (chkbox)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Activity Added Successfully";
                Session["msg3"] = lblMsg.Text;
                objCM.InsertActivityMaster();
                Response.Redirect("ActivityViewMaster.aspx");
            }
            else 
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please Select Rows ";
            }  
           
        }

        txtActivityName.Text = "";
        txtActivityCode.Text = "";
      
        foreach (GridViewRow gvRow in gvCompany.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkHierId")).Checked = false;
        }
        

    }

    private string getSelected()
    {
        strSelected = "";
        // strUpdate = "";
        CheckBox chk;
        HiddenField hid;
        foreach (GridViewRow gvRow in gvCompany.Rows)
        {
            chk = (CheckBox)gvRow.FindControl("chkHierId");

            hid = (HiddenField)gvRow.FindControl("hidHierId");
            if (chk.Checked == true)
            {
                strSelected = strSelected + hid.Value + ",";
            }
          
        }
        return strSelected;
    }
    protected void btncalcel_Click(object sender, EventArgs e)
    {
        txtActivityName.Text = "";
        txtActivityCode.Text = "";
        lblMsg.Text = "";
        valActivityCode.Enabled = true;
        txtActivityCode.Enabled = true;
        foreach (GridViewRow gvRow in gvCompany.Rows)
        {
            ((CheckBox)gvRow.FindControl("chkHierId")).Checked = false;
        }
        Session["msg3"] = null;
        Response.Redirect("ActivityViewMaster.aspx");

    }
   
    protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Request.QueryString["ACTIVITY_ID"] != null && Request.QueryString["ACTIVITY_ID"] != "")
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hf = (HiddenField)e.Row.FindControl("hidHierId");
                if (hf.Value != "")
                {
                    CheckBox chk =(CheckBox)e.Row.FindControl("chkHierId");
                    chk.Checked = true;
                }
            }
        }
    }


    protected void gvCompany_DataBound(object sender, EventArgs e)
    {
        CheckBox cbHeader = ((CheckBox)(gvCompany.HeaderRow.FindControl("HeaderLevelCheckBox")));
        cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
        foreach (GridViewRow gvr in gvCompany.Rows)
        {
            // Get a programmatic reference to the CheckBox control
            CheckBox cb = ((CheckBox)(gvr.FindControl("chkHierID")));
            ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
        }
    }
}
