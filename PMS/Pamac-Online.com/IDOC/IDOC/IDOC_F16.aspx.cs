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
using System.Data.SqlClient;

public partial class CPV_IDOC_IDOC_F16 : System.Web.UI.Page
{    
    CIDocVerification objIDocVer = new CIDocVerification();
    CCommon objcon = new CCommon();
    bool IsValid1 = true;
    bool valtextArea = true;

    //add by kanchan on 23/9/2014
    object o1;
    object o2;
    object o4;


    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        SdsStatus.ConnectionString = objConn.ConnectionString;  //Sir

        txtAmount.Focus() ;
        if (Convert.ToInt32( Request.QueryString["VerTypeId"]) == 8)
        {
            lblF16.Visible = true;
            lblss.Visible = false;            
            pnlform16.Visible = true;

            
        }
        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 11)
        {
            lblsc.Visible = true;
            lblF16.Visible = false;
            lblss.Visible = false;            
            pnlform16.Visible = false;
          
        }
        if (Convert.ToInt32(Request.QueryString["VerTypeId"]) == 5)
        {
            lblss.Visible = true;
            lblsc.Visible = false;
            lblF16.Visible = false;
            pnlform16.Visible = false;     
            
        }

        if (hdnSupID.Value != "")
        {           
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }
      
        if (!IsPostBack)
        {
            GetSupervisorList();
            Get_Areaname();
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");

            if (Session["isAdd"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");

            if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
            {
                if (Request.QueryString["Op"].ToString() == "search")
                {
                    EnableFalse();
                }               
                if (Request.QueryString["Op"].ToString() == "View")
                {
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    
                }                
            }
            
            if ((Context.Request.QueryString["CaseID"] != null) && (Context.Request.QueryString["CaseID"] != ""))
            {                
                string sCaseId = Request.QueryString["CaseID"].ToString();
                string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                lblmsg.Text="";
                Session["CaseID"] = sCaseId;


                //Add By : Kanchan
                //add Date : 23/09/2014

                IDOC_F16_Sql1();


                IDOC_F16_Sql2();


                IDOC_F16_Sql3();




                //comment by kanchan on 23/9/2014

                ////string sql1 = "select distinct fullname,emp_id from fe_vw fv inner join CPV_IDOC_FE_CASE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + Request.QueryString["CaseID"].ToString() + "' and cifcm.VERIFICATION_TYPE_ID='" + sVerifyTypeId + "' order by fv.fullname";
                ////string sql2 = "select OFF_NAME from cpv_idoc_case_details where case_id="+Request.QueryString["CaseID"].ToString();
                ////o2 = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql2).ToString();
                ////if (o2 == null)
                ////{
                ////    txtCompanyName.Text = "";
                ////}
                ////else
                ////{
                ////    txtCompanyName.Text = o2.ToString();
                ////}
               
               
                 
                ////o1 = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql1);
                 
                ////if (o1 == null)
                ////{
                ////    txtFEName.Text = "";
                ////}
                ////else
                ////{
                ////    txtFEName.Text = o1.ToString();
                ////}
                ////string sSql3 = "select DATE_TIME from CPV_IDOC_FE_CASE_MAPPING where case_id='" + Request.QueryString["CaseID"] + "'and VERIFICATION_TYPE_ID='" + Request.QueryString["VerTypeId"] + "'";
                ////txtVeriDate.Text = Convert.ToDateTime(OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sSql3).ToString()).ToString("dd/MM/yyyy");
               
                
                
                if (sCaseId != "")
                {

                    //comment by kanchan on 23/9/2014

                    ////OleDbDataReader oledbRead;
                    ////oledbRead = objIDocVer.GetIDOCsCaseDetail(sCaseId);
                    ////if (oledbRead.Read() == true)
                    ////{
                    ////    txtApplicantName.Text = oledbRead["FULL NAME"].ToString();
                    ////    txtRefNo.Text = oledbRead["REF_NO"].ToString();
                    ////    txtRecDate.Text = Convert.ToDateTime(oledbRead["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm:tt");
                    ////}

                   

                    DataSet ds33 = new DataSet();

                    ds33 = objIDocVer.GetIDOCsCaseDetail(sCaseId);//kanchan on 23/9/2014
                    if (ds33.Tables[0].Rows.Count > 0)
                    {
                        txtApplicantName.Text = ds33.Tables[0].Rows[0]["FULL NAME"].ToString();
                        txtRefNo.Text = ds33.Tables[0].Rows[0]["REF_NO"].ToString();
                        txtRecDate.Text = Convert.ToDateTime(ds33.Tables[0].Rows[0]["RECD_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm:tt");
                    }


                    //comment by kanchan on 23/9/2014
                    ////object o;
                    ////string sql = "select count(*) from cpv_idoc_verification where case_id='" + Request.QueryString["CaseID"] + " 'and verification_type_id='"+ Request.QueryString["VerTypeId"].ToString() + "'";
                    ////o = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql);

                    //add by kanchan on 23/9/2014
                    using (SqlConnection con = new SqlConnection(objcon.AppConnectionString))
                    {
                        try
                        {

                            SqlCommand command = new SqlCommand("sp_IDOC_F16_Sql4", con);
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@case_id", Request.QueryString["CaseID"]);
                            command.Parameters.AddWithValue("@verification_type_id", Request.QueryString["VerTypeId"].ToString());

                            con.Open();

                            o4 = command.ExecuteScalar();

                            con.Close();
                        }
                        catch
                        {
                        }

                    }


                    if(Convert.ToInt32(o4)!=0)
                    {
                        if (Session["isEdit"].ToString() != "1")

                            Response.Redirect("NoAccess.aspx");


                        ////OleDbDataReader dr_A;  comment by kanchan on 23/9/2014
                   
                        string sCaseIDa = Request.QueryString["CaseID"].ToString();
                        string sVerificationIDa = Request.QueryString["VerTypeId"].ToString();

                        ////dr_A = objIDocVer.GetFEAreaName(sCaseIDa, sVerificationIDa); //comment by kanchan on 23/9/2014

                        DataSet ds3 = new DataSet();
                        ds3 = objIDocVer.GetFEAreaName(sCaseIDa, sVerificationIDa);//kanchan on 23/9/2014

                        //comment on 23/9/2014
                        ////if (dr_A.Read() == true)
                        ////{
                        ////    if (dr_A["PincodeArea_Name"].ToString() == "")
                        ////    {
                        ////    }
                         ////else
                         ////   {
                         ////       btnPincode.Visible = false;
                         ////       txtAreapincode.Visible = false;
                         ////       ddlAreaname.Visible = true;
                         ////       ddlAreaname.SelectedItem.Text = dr_A["PincodeArea_Name"].ToString();
                         ////   }

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            if (ds3.Tables[0].Rows[0]["PincodeArea_Name"].ToString() == "")
                            {
                            }
                            else
                            {
                                btnPincode.Visible = true;
                                txtAreapincode.Visible = true;
                                ddlAreaname.Visible = true;
                               // ddlAreaname.SelectedItem.Text = ds3.Tables[0].Rows[0]["PincodeArea_Name"].ToString();

                            }                          

                        }
                        //comment by kanchan on 23/9/2014

                        ////OleDbDataReader dr;
                        ////string sCaseID = Request.QueryString["CaseID"].ToString();
                        ////string sVerificationID =Request.QueryString["VerTypeId"].ToString();
                        ////dr=objIDocVer.GetIdocVerification(sCaseID,sVerificationID);
                        ////if (dr.Read() == true)
                        ////{
                        ////    txtAmount.Text = dr["TOTAL_INCOME"].ToString();
                        ////    ddlOTSSD.SelectedValue = dr["Overwriting"].ToString();
                        ////    ddlCPC.SelectedValue = dr["Pan_correct"].ToString();
                        ////    ddlCTC.SelectedValue = dr["Tan_correcT"].ToString();
                        ////    ddlOCC.SelectedValue = dr["computation_correct"].ToString();
                        ////    ddlICC.SelectedValue = dr["Calculation_correct"].ToString();
                        ////    ddlTCC.SelectedValue = dr["Tax_cal_correct"].ToString();
                        ////    ddlTDS.SelectedValue = dr["Tax_payble_correct"].ToString();
                        ////    ddlOK.SelectedValue = dr["OK_field_verification"].ToString();
                        ////    ddlSpellMistake.SelectedValue = dr["IS_spelling_mistake"].ToString();
                        ////    txtOtherObservation.Text = dr["Other_observation"].ToString();
                        ////    txtPersonContacted.Text = dr["Person_contacted"].ToString();
                        ////    txtDepartment.Text = dr["Cont_Designation_dept"].ToString();
                        ////    txtApplicantDesi.Text = dr["APP_DESIGNATION"].ToString();
                        ////    txtApplicantDepart.Text = dr["APP_DEPARTMENT"].ToString();
                        ////    string sTmp =Convert.ToString( dr["APP_YEAR_IN_SERVICE"]);

                        DataSet ds23 = new DataSet();
                        string sCaseID = Request.QueryString["CaseID"].ToString();
                        string sVerificationID = Request.QueryString["VerTypeId"].ToString();
                        ds23 = objIDocVer.GetIdocVerification(sCaseID, sVerificationID);//diss done

                        if (ds23.Tables[0].Rows.Count > 0)
                        {
                            txtAmount.Text = ds23.Tables[0].Rows[0]["TOTAL_INCOME"].ToString();
                            ddlOTSSD.SelectedValue = ds23.Tables[0].Rows[0]["Overwriting"].ToString();
                            ddlCPC.SelectedValue = ds23.Tables[0].Rows[0]["Pan_correct"].ToString();
                            ddlCTC.SelectedValue = ds23.Tables[0].Rows[0]["Tan_correcT"].ToString();
                            ddlOCC.SelectedValue = ds23.Tables[0].Rows[0]["computation_correct"].ToString();
                            ddlICC.SelectedValue = ds23.Tables[0].Rows[0]["Calculation_correct"].ToString();
                            ddlTCC.SelectedValue = ds23.Tables[0].Rows[0]["Tax_cal_correct"].ToString();
                            ddlTDS.SelectedValue = ds23.Tables[0].Rows[0]["Tax_payble_correct"].ToString();
                            ddlOK.SelectedValue = ds23.Tables[0].Rows[0]["OK_field_verification"].ToString();
                            ddlSpellMistake.SelectedValue = ds23.Tables[0].Rows[0]["IS_spelling_mistake"].ToString();
                            txtOtherObservation.Text = ds23.Tables[0].Rows[0]["Other_observation"].ToString();

                            txtPersonContacted.Text = ds23.Tables[0].Rows[0]["Person_contacted"].ToString();
                            txtDepartment.Text = ds23.Tables[0].Rows[0]["Cont_Designation_dept"].ToString();
                            txtApplicantDesi.Text = ds23.Tables[0].Rows[0]["APP_DESIGNATION"].ToString();
                            txtApplicantDepart.Text = ds23.Tables[0].Rows[0]["APP_DEPARTMENT"].ToString();
                            string sTmp = ds23.Tables[0].Rows[0]["APP_YEAR_IN_SERVICE"].ToString();


                            if (sTmp != "")
                            {
                                string[] arrTimeAtCurrY_M = sTmp.Split('.');
                                txtApplicantYSerOrg.Text = arrTimeAtCurrY_M[0].ToString();
                                if (arrTimeAtCurrY_M.Length > 1)
                                    txtMonth.Text = arrTimeAtCurrY_M[1].ToString();
                            }

                            //comment by kanchan on 23/9/2014

                    ////        txtAMIncome.Text = dr["MONTH_INCOME"].ToString();
                    ////        txtEmpOrg.Text = dr["NO_OF_EMP_SEEN"].ToString();
                    ////        txtTypeOfIndustry.Text = dr["TYPE_OF_INDUSTRY"].ToString();
                    ////        ddlSealOrg.SelectedValue = dr["ORGANIZATION_SEAL"].ToString();
                    ////        ddlSIAuthority.SelectedValue = dr["AUTHORITY_SIGNATURE"].ToString();
                    ////        ddlSFOrg.SelectedValue = dr["DOCUMENT_AS_PER_STANDARD"].ToString();
                    ////        ddlSSCDate.SelectedValue = dr["DATE_ON_DOC"].ToString();
                    ////        ddlSSSAmount.SelectedValue = dr["AMOUNT_ON_DOC"].ToString();
                    ////        ddlAppOffCorrect.SelectedValue = dr["APP_ADDRESS_CORRECT"].ToString();
                    ////        ddlBusinessActivitySeen.SelectedValue = dr["BUSSINESS_ACTIVITY_SEEN"].ToString();
                    ////        txtStock.Text = dr["STOCK_SIGHTED"].ToString();
                    ////        txtNoEmployess.Text =  dr["NO_of_Employee"].ToString();
                    ////        ddlNameBoard.SelectedValue = dr["NAME_BOARD_SEEN"].ToString();
                    ////        txtFRemarks.Text = dr["FE_REMARK"].ToString();
                    ////        txtTeleRemark.Text = dr["TELE_REMARK"].ToString();

                    ////        txtVeriDate.Text = dr["FE_VISIT_DATE"].ToString();
                    ////        ddlStatus.SelectedValue = dr["CASE_STATUS_ID"].ToString();
                    ////        ddlSalary.SelectedValue = dr["Gross_salary_Momthly_Annual_Income"].ToString();
                    ////        ddlSupervisorName.SelectedValue = dr["Supervisor_sign"].ToString();
                    ////    }
                    ////    dr.Close();
                    ////}

                            //add by kanchan on 23/9/2014

                            txtAMIncome.Text = ds23.Tables[0].Rows[0]["MONTH_INCOME"].ToString();
                            txtEmpOrg.Text = ds23.Tables[0].Rows[0]["NO_OF_EMP_SEEN"].ToString();
                            txtTypeOfIndustry.Text = ds23.Tables[0].Rows[0]["TYPE_OF_INDUSTRY"].ToString();

                            ddlSealOrg.SelectedValue = ds23.Tables[0].Rows[0]["ORGANIZATION_SEAL"].ToString();
                            ddlSIAuthority.SelectedValue = ds23.Tables[0].Rows[0]["AUTHORITY_SIGNATURE"].ToString();
                            ddlSFOrg.SelectedValue = ds23.Tables[0].Rows[0]["DOCUMENT_AS_PER_STANDARD"].ToString();

                            ddlSSCDate.SelectedValue = ds23.Tables[0].Rows[0]["DATE_ON_DOC"].ToString();
                            ddlSSSAmount.SelectedValue = ds23.Tables[0].Rows[0]["AMOUNT_ON_DOC"].ToString();
                            ddlAppOffCorrect.SelectedValue = ds23.Tables[0].Rows[0]["APP_ADDRESS_CORRECT"].ToString();

                            ddlBusinessActivitySeen.SelectedValue = ds23.Tables[0].Rows[0]["BUSSINESS_ACTIVITY_SEEN"].ToString();
                            txtStock.Text = ds23.Tables[0].Rows[0]["STOCK_SIGHTED"].ToString();
                            txtNoEmployess.Text = ds23.Tables[0].Rows[0]["NO_of_Employee"].ToString();
                            ddlNameBoard.SelectedValue = ds23.Tables[0].Rows[0]["NAME_BOARD_SEEN"].ToString();
                            txtFRemarks.Text = ds23.Tables[0].Rows[0]["FE_REMARK"].ToString();
                            txtTeleRemark.Text = ds23.Tables[0].Rows[0]["TELE_REMARK"].ToString();

                            txtVeriDate.Text = ds23.Tables[0].Rows[0]["FE_VISIT_DATE"].ToString();
                            ddlStatus.SelectedValue = ds23.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString();
                            ddlSalary.SelectedValue = ds23.Tables[0].Rows[0]["Gross_salary_Momthly_Annual_Income"].ToString();
                            ddlSupervisorName.SelectedValue = ds23.Tables[0].Rows[0]["Supervisor_sign"].ToString();

                        }

                    }

                    //----comp----//


                    //comment by kanchan on 23/9/2014
                    ////OleDbDataReader dr1;
                    ////string sCaseID1 = Request.QueryString["CaseID"].ToString();
                    ////string sVerificationID1 = Request.QueryString["VerTypeId"].ToString();
                    ////dr1 = objIDocVer.GetIdocVeriAttempt(sCaseID1, sVerificationID1);
                    ////int i = 0;                                  


                   ////while(dr1.Read())
                   //// {
                   ////     string strTemp = dr1["ATTEMPT_DATE_TIME"].ToString();
                   ////     string[] arrAttempt=strTemp.Split(' ');
                   ////     if (i == 0)
                   ////     {
                   ////         if (arrAttempt[0].ToString() != "")
                   ////         {
                   ////             txtDate1.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                   ////             txtTime1.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                   ////             ddlTimeType1.SelectedValue = arrAttempt[2].ToString();
                   ////             txtTelNo1.Text = dr1["TELEPHONE_NO"].ToString();
                   ////             txtRemarks1.Text = dr1["Remark"].ToString();
                   ////         }
                   ////     }                   

                   ////     if (i == 1)
                   ////     {
                   ////         if (arrAttempt[0].ToString() != "")
                   ////         {
                   ////             txtDate2.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                   ////             txtTime2.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                   ////             ddlTimeType2.SelectedValue = arrAttempt[2].ToString();
                   ////             txtTelNo2.Text = dr1["TELEPHONE_NO"].ToString();
                   ////             txtRemarks2.Text = dr1["Remark"].ToString();
                   ////         }
                   ////     }
                   ////     if (i == 2)
                   ////     {
                   ////         if (arrAttempt[0].ToString() != "")
                   ////         {
                   ////             txtDate3.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                   ////             txtTime3.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                   ////             ddlTimeType3.SelectedValue = arrAttempt[2].ToString();
                   ////             txtTelNo3.Text = dr1["TELEPHONE_NO"].ToString();
                   ////             txtRemarks3.Text = dr1["Remark"].ToString();
                   ////         }
                   ////     }
                   ////     if (i == 3)
                   ////     {
                   ////         if (arrAttempt[0].ToString() != "")
                   ////         {
                   ////             txtDate4.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                   ////             txtTime4.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                   ////             ddlTimeType4.SelectedValue = arrAttempt[2].ToString();
                   ////             txtTelNo4.Text = dr1["TELEPHONE_NO"].ToString();
                   ////             txtRemarks4.Text = dr1["Remark"].ToString();
                   ////         }
                   ////     }
                   ////     if (i == 4)
                   ////     {
                   ////         if (arrAttempt[0].ToString() != "")
                   ////         {
                   ////             txtDate5.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                   ////             txtTime5.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                   ////             ddlTimeType5.SelectedValue = arrAttempt[2].ToString();
                   ////             txtTelNo5.Text = dr1["TELEPHONE_NO"].ToString();
                   ////             txtRemarks5.Text = dr1["Remark"].ToString();
                   ////         }
                   ////     }
                   ////     i++;
                   //// }


                    //add by kanchan on 23/9/2014
                    DataSet myds1 = new DataSet();
                    string sCaseID1 = Request.QueryString["CaseID"].ToString();
                    string sVerificationID1 = Request.QueryString["VerTypeId"].ToString();
                    myds1 = objIDocVer.GetIdocVeriAttempt(sCaseID1, sVerificationID1);//kanchan
                    int i = 0;

                    while (myds1.Tables[0].Rows.Count > 0)
                    {
                        string strTemp = myds1.Tables[0].Rows[0]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttempt = strTemp.Split(' ');
                        if (i == 0)
                        {
                            if (arrAttempt[0].ToString() != "")
                            {
                                txtDate1.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                                txtTime1.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                                ddlTimeType1.SelectedValue = arrAttempt[2].ToString();
                                txtTelNo1.Text = myds1.Tables[0].Rows[0]["TELEPHONE_NO"].ToString();
                                txtRemarks1.Text = myds1.Tables[0].Rows[0]["Remark"].ToString();
                            }
                        }

                        if (i == 1)
                        {
                            if (arrAttempt[0].ToString() != "")
                            {
                                txtDate2.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                                txtTime2.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                                ddlTimeType2.SelectedValue = arrAttempt[2].ToString();
                                txtTelNo2.Text = myds1.Tables[0].Rows[0]["TELEPHONE_NO"].ToString();
                                txtRemarks2.Text = myds1.Tables[0].Rows[0]["Remark"].ToString();
                            }
                        }


                        if (i == 2)
                        {
                            if (arrAttempt[0].ToString() != "")
                            {
                                txtDate3.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                                txtTime3.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                                ddlTimeType3.SelectedValue = arrAttempt[2].ToString();
                                txtTelNo3.Text = myds1.Tables[0].Rows[0]["TELEPHONE_NO"].ToString();
                                txtRemarks3.Text = myds1.Tables[0].Rows[0]["Remark"].ToString();
                            }
                        }


                        if (i == 3)
                        {
                            if (arrAttempt[0].ToString() != "")
                            {
                                txtDate4.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                                txtTime4.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                                ddlTimeType4.SelectedValue = arrAttempt[2].ToString();
                                txtTelNo4.Text = myds1.Tables[0].Rows[0]["TELEPHONE_NO"].ToString();
                                txtRemarks4.Text = myds1.Tables[0].Rows[0]["Remark"].ToString();
                            }
                        }


                        if (i == 4)
                        {
                            if (arrAttempt[0].ToString() != "")
                            {
                                txtDate5.Text = Convert.ToDateTime(arrAttempt[0].ToString()).ToString("dd/MM/yyyy");
                                txtTime5.Text = Convert.ToDateTime(arrAttempt[1].ToString()).ToString("hh:mm");
                                ddlTimeType5.SelectedValue = arrAttempt[2].ToString();
                                txtTelNo5.Text = myds1.Tables[0].Rows[0]["TELEPHONE_NO"].ToString();
                                txtRemarks5.Text = myds1.Tables[0].Rows[0]["Remark"].ToString();
                            }
                        }

                        i++;
                    }



                }

            }
        }
    }
    private void Get_Areaname()
    {
        string sCaseId1 = Request.QueryString["CaseID"].ToString();


        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_IDOC_Bv";

        SqlParameter AreaID = new SqlParameter();
        AreaID.SqlDbType = SqlDbType.VarChar;
        AreaID.Value = sCaseId1;
        AreaID.ParameterName = "@Case_id";
        cmd.Parameters.Add(AreaID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();

        if (dt.Rows.Count > 1)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, "-Select-");
            ddlAreaname.SelectedIndex = 0;
        }

        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

          

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAreaname.SelectedIndex = 0;
        }
    }

    private void GetSupervisorList()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_EmployeeNameListSUP";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlSupervisorName.DataTextField = "FullName";
            ddlSupervisorName.DataValueField = "EMP_ID";
            ddlSupervisorName.DataSource = dt;
            ddlSupervisorName.DataBind();

            ddlSupervisorName.Items.Insert(0, "--Select--");
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        try
        {
            if (ddlAreaname.SelectedValue.ToString() !="0")
            {
            Isvalid();
            textAreaValidation();
            if (valtextArea)
            {
                if (IsValid1)
                {

                    objIDocVer.ApplicantName = txtApplicantName.Text.Trim();
                    if (txtAmount.Text.Trim() != "")
                    {
                        objIDocVer.TotalIncome = Convert.ToDecimal(txtAmount.Text.Trim().ToString());
                    }
                    else
                    {

                    }
                    if (ddlOTSSD.SelectedIndex != 0)
                    {
                        objIDocVer.OverWritingTempring = ddlOTSSD.SelectedValue;
                    }
                    if (ddlCPC.SelectedIndex != 0)
                    {
                        objIDocVer.PanCorrect = ddlCPC.SelectedValue;
                    }
                    if (ddlCTC.SelectedIndex != 0)
                    {
                        objIDocVer.TanCorrect = ddlCTC.SelectedValue;
                    }
                    if (ddlICC.SelectedIndex != 0)
                    {
                        objIDocVer.IncomeCalculationCorrect = ddlICC.SelectedValue;
                    }
                    if (ddlOCC.SelectedIndex != 0)
                    {
                        objIDocVer.OverallComputationCorrect = ddlOCC.SelectedValue;
                    }
                    if (ddlTCC.SelectedIndex != 0)
                    {
                        objIDocVer.TaxCalculationCorrect = ddlTCC.SelectedValue;
                    }
                    if (ddlTDS.SelectedIndex != 0)
                    {
                        objIDocVer.F16PaybleISCorrect = ddlTDS.SelectedValue;
                    }
                    if (ddlOK.SelectedIndex != 0)
                    {
                        objIDocVer.OkSendForVerification = ddlOK.SelectedValue;
                    }
                    if (ddlSpellMistake.SelectedIndex != 0)
                    {
                        objIDocVer.SpellMistake = ddlSpellMistake.SelectedValue;
                    }
                    if (txtOtherObservation.Text.Trim() != "")
                    {
                        objIDocVer.OtherVerification = txtOtherObservation.Text.Trim();
                    }
                    if (txtPersonContacted.Text.Trim() != "")
                    {
                        objIDocVer.NameOfPersonContacted = txtPersonContacted.Text.Trim();
                    }
                    if (txtDepartment.Text.Trim() != "")
                    {
                        objIDocVer.Cont_DesignationDepartment = txtDepartment.Text.Trim();
                    }
                    if (txtApplicantDesi.Text.Trim() != "")
                    {
                        objIDocVer.ApplicantDesignation = txtApplicantDesi.Text.Trim();
                    }
                    if (txtApplicantDepart.Text.Trim() != "")
                    {
                        objIDocVer.ApplicationDepartment = txtApplicantDepart.Text.Trim();
                    }
                    if (txtApplicantYSerOrg.Text.Trim() != "")
                    {
                        objIDocVer.ApplicantYearService = Convert.ToDecimal(txtApplicantYSerOrg.Text.Trim() + "." + txtMonth.Text.Trim());
                    }
                    else
                    {

                    }
                    if (txtAMIncome.Text.Trim() != "")
                    {
                        objIDocVer.ApplicantGrossAnnualMonthlyIncome = Convert.ToDecimal(txtAMIncome.Text.Trim());
                    }
                    else
                    {

                    }
                    if (txtEmpOrg.Text.Trim() != "")
                    {
                        objIDocVer.NumberOfEmployeeinOrg = Convert.ToInt32(txtEmpOrg.Text.Trim());
                    }
                    if (txtNoEmployess.Text.Trim() != "")
                    {
                        objIDocVer.NoEmployess = txtNoEmployess.Text.Trim();
                    }
                    else
                    {

                    }
                    if (txtTypeOfIndustry.Text.Trim() != "")
                    {
                        objIDocVer.TypeOfOrg = txtTypeOfIndustry.Text.Trim();
                    }
                    if (ddlSealOrg.SelectedIndex != 0)
                    {
                        objIDocVer.SealOfOrg = ddlSealOrg.SelectedValue.Trim();
                    }
                    if (ddlSIAuthority.SelectedIndex != 0)
                    {
                        objIDocVer.SigOfIssAuth = ddlSIAuthority.SelectedValue.Trim();
                    }
                    if (ddlSIAuthority.SelectedIndex != 0)
                    {
                        objIDocVer.StanForOrg = ddlSFOrg.SelectedValue.Trim();
                    }
                    if (ddlSSCDate.SelectedIndex != 0)
                    {
                        objIDocVer.DtSSSPSC = ddlSSCDate.SelectedValue;
                    }
                    if (ddlSSSAmount.SelectedIndex != 0)
                    {
                        objIDocVer.AmtSSSPSC = ddlSSSAmount.SelectedValue;
                    }
                    if (ddlAppOffCorrect.SelectedIndex != 0)
                    {
                        objIDocVer.AppOffCorrect = ddlAppOffCorrect.SelectedValue;

                    }
                    if (ddlBusinessActivitySeen.SelectedIndex != 0)
                    {
                        objIDocVer.BusinessActivitySeen = ddlBusinessActivitySeen.SelectedValue;
                    }
                    if (txtStock.Text.Trim() != "")
                    {
                        objIDocVer.Stock = txtStock.Text.Trim();
                    }
                    if (ddlNameBoard.SelectedIndex != 0)
                    {
                        objIDocVer.NameBoard = ddlNameBoard.SelectedValue;
                    }
                    if (txtFRemarks.Text.Trim() != "")
                    {
                        objIDocVer.FERemarks = txtFRemarks.Text.Trim();
                    }
                    if (txtTeleRemark.Text.Trim() != "")
                    {
                        objIDocVer.TeleRemarks = txtTeleRemark.Text.Trim();
                    }
                    objIDocVer.CaseID = Request.QueryString["CaseID"].ToString().Trim();
                    
                    if (txtVeriDate.Text != "")
                    {
                        objIDocVer.VeriDate = txtVeriDate.Text.Trim();
                    }

                    objIDocVer.Supervisor_sign = ddlSupervisorName.SelectedValue;

                    if (ddlAreaname.SelectedValue.ToString() == "0")
                    {
                        objIDocVer.AreaID = txtAreapincode.Text.Trim();
                    }
                    else
                    {
                        objIDocVer.AreaID = ddlAreaname.SelectedValue.ToString();
                    }


                    objIDocVer.CaseStatusID = ddlStatus.SelectedValue;
                    objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
                    objIDocVer.Salary = ddlSalary.SelectedValue.Trim();
                    objIDocVer.AddedBy = Session["UserId"].ToString();
                    objIDocVer.ModifyBy = Session["UserId"].ToString();
                    objIDocVer.AddedOn = DateTime.Now;
                    objIDocVer.ModifyOn = DateTime.Now;
                    //Added by hemangi kambli on 01/10/2007 
                    if (hdnTransStart.Value != "")
                        objIDocVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                    objIDocVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
                    objIDocVer.CentreId = Session["CentreId"].ToString();
                    objIDocVer.ProductId = Session["ProductId"].ToString();
                    objIDocVer.ClientId = Session["ClientId"].ToString();
                    objIDocVer.UserId = Session["UserId"].ToString();
                    ///------------------------------------------------------

                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();


                    object o;

                    ////string sql = "select count(*) from cpv_idoc_verification where case_id='" + sCaseId.Trim() + "' and verification_type_id='" + sVerifyTypeId.Trim() + "'";
                    ////o = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql);


                    //add by: kanchan
                    //add date : 23/09/2014

                    SqlConnection con = new SqlConnection(objcon.AppConnectionString);


                    SqlCommand command = new SqlCommand("sp_IDOC_F16_SaveSelect", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@case_id", sCaseId);
                    command.Parameters.AddWithValue("@verification_type_id", sVerifyTypeId);

                    con.Open();

                    o = command.ExecuteScalar();

                    con.Close();

                    //--comp----//

                    if (Convert.ToInt32(o) == 0)
                    {
                        InsertTeleCallLog();//kanchan on 23/9/2014
                        lblmsg.Text = "Record inserted successfully" + objIDocVer.InsertIDocForm16();//kanchan on 23/9/2014
                        iCount = 1;
                    }
                    else
                    {
                        InsertTeleCallLog();//kanchan on 23/9/2014
                        lblmsg.Text = "Record updated successfully" + objIDocVer.UpdateIdocVerification(sCaseId, sVerifyTypeId);//kanchan on 23/9/2014
                        iCount = 1;
                    }
                   
                }
            }
        }
        else
        {
            lblareaerror.Text = "Area Name IS Mandatory";
        }

        }
        catch (Exception ex)
        {
            lblmsg.Visible=true;
            lblmsg.Text = "Error while generating report: " + ex.Message; 
                        
        }
        if (iCount == 1)
        {
            Response.Redirect("IDOC_VerificationView.aspx?Msg=" + lblmsg.Text);
        }
        
    }

    protected void ddlStatus_DataBound(object sender, EventArgs e)
    {
    }
    //comment by kanchan on 23/9/2014
    
    ////private void InsertTeleCallLog()
    ////{       
    ////    try
    ////    {
    ////                object o;
    ////                string sql = "select count(*) from cpv_idoc_veri_attempts where case_id=" + Request.QueryString["CaseID"];
    ////                o = OleDbHelper.ExecuteScalar(objcon.ConnectionString, CommandType.Text, sql);
    ////                if (Convert.ToInt32(o)==0)
    ////                {
    ////                    insert();
    ////                }
    ////                else
    ////                {
    ////                    string sCaseID = Request.QueryString["CaseID"].ToString();
    ////                    string sVerificationID = Request.QueryString["VerTypeId"].ToString();
    ////                    objIDocVer.updateVeriAttempt(sCaseID, sVerificationID);
    ////                    insert();
                        
                        
                      
    ////                }

    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

    ////    }
    ////}


    //add by : kanchan
    //add date :23/09/2014
    private void InsertTeleCallLog()//diss done
    {


        try
        {
            object o;

            SqlConnection con = new SqlConnection(objcon.AppConnectionString);


            SqlCommand command = new SqlCommand("sp_IDOC_F16_InsertTeleCallLog", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@case_id", Request.QueryString["CaseID"]);

            con.Open();

            o = command.ExecuteScalar();

            con.Close();

            if (Convert.ToInt32(o) == 0)
            {
                insert();//kanchan 23/9/2014
            }
            else
            {
                string sCaseID = Request.QueryString["CaseID"].ToString();
                string sVerificationID = Request.QueryString["VerTypeId"].ToString();
                objIDocVer.updateVeriAttempt(sCaseID, sVerificationID);//diss done but not yet check 23/9/2014
                insert();//kanchan



            }

        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

        }
    }
    //-----comp-----//


    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        if (Context.Request.QueryString["Op"] != null && Context.Request.QueryString["Op"] != "")
        {
            if (Request.QueryString["Op"].ToString() == "search")
            {
                string sCaseId = Request.QueryString["CaseID"].ToString();
                string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                string sName = Request.QueryString["Name"].ToString();
                string sDOB = Request.QueryString["DOB"].ToString();
                string sVerificationTypeId = Request.QueryString["VerificationTypeId"].ToString();
                Response.Redirect("IDOC_DeDupSearch.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyTypeId + "&Name=" + sName + "&VerificationTypeId=" + sVerificationTypeId + "&DOB=" + sDOB + "&Op=search");
            }
           
        }
        else
            Response.Redirect("IDOC_VerificationView.aspx");
    }
    //comment by kanchan on 23/9/2014
    ////public void insert()
    ////{
        
    ////    if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() != "")
    ////    {                
    ////        objIDocVer.AttempDateTime =objcon.strDate(txtDate1.Text.Trim()) + " " + txtTime1.Text.Trim() + " " + ddlTimeType1.SelectedItem.Text.Trim();
    ////        objIDocVer.TellPhoneRemark = txtRemarks1.Text.Trim();

    ////        objIDocVer.TellNo = txtTelNo1.Text.Trim();
    ////        objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();

    ////       object o= objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo1.Text, txtRemarks1.Text);

    ////       if (Convert.ToInt32(o) == 0)
    ////       {
    ////           objIDocVer.InsertTeleLog();
    ////       }
    ////        lblmsg.Text = "Record inserted successfully";

    ////    }
      

    ////    if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() != "")
    ////    {
                           
    ////            objIDocVer.AttempDateTime =objcon.strDate(txtDate2.Text.Trim()) + " " + txtTime2.Text.Trim() + " " + ddlTimeType2.SelectedItem.Text.Trim();
    ////            objIDocVer.TellPhoneRemark = txtRemarks2.Text.Trim();
    ////            objIDocVer.TellNo = txtTelNo2.Text.Trim();
    ////            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
    ////      object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo2.Text, txtRemarks2.Text);

    ////        if (Convert.ToInt32(o) == 0)
    ////        {
    ////            objIDocVer.InsertTeleLog();
    ////        }
    ////        lblmsg.Text = "Record inserted successfully";



    ////    }
       
    ////    if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() != "")
    ////    {
            
    ////        objIDocVer.AttempDateTime =objcon.strDate(txtDate3.Text.Trim()) + " " + txtTime3.Text.Trim()+ " " + ddlTimeType3.SelectedItem.Text.Trim();
    ////        objIDocVer.TellPhoneRemark = txtRemarks3.Text.Trim();
    ////        objIDocVer.TellNo = txtTelNo3.Text.Trim();
    ////        objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();



    ////        object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo3.Text, txtRemarks3.Text);

    ////        if (Convert.ToInt32(o) == 0)
    ////        {
    ////            objIDocVer.InsertTeleLog();
    ////        }
    ////        lblmsg.Text = "Record inserted successfully";



    ////    }
        
    ////    if (txtDate4.Text.Trim() != "" && txtTime4.Text.Trim() != "")
    ////    {
            
    ////        objIDocVer.AttempDateTime =objcon.strDate(txtDate4.Text.Trim()) + " " + txtTime4.Text.Trim() + " " + ddlTimeType4.SelectedItem.Text.Trim();
    ////        objIDocVer.TellPhoneRemark = txtRemarks4.Text.Trim();
    ////        objIDocVer.TellNo = txtTelNo4.Text.Trim();
    ////        objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();

    ////        object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo4.Text, txtRemarks4.Text);

    ////        if (Convert.ToInt32(o) == 0)
    ////        {
    ////            objIDocVer.InsertTeleLog();
    ////        }
    ////        lblmsg.Text = "Record inserted successfully";



    ////    }
       
    ////    if (txtDate5.Text.Trim() != "" && txtTime5.Text.Trim() != "")
    ////    {
            
    ////        objIDocVer.AttempDateTime =objcon.strDate(txtDate5.Text.Trim()) + " " + txtTime5.Text.Trim() + " " + ddlTimeType5.SelectedItem.Text.Trim();
    ////        objIDocVer.TellPhoneRemark = txtRemarks5.Text.Trim();
    ////        objIDocVer.TellNo = txtTelNo5.Text.Trim();
    ////        objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();

    ////        object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo5.Text, txtRemarks5.Text);

    ////        if (Convert.ToInt32(o) == 0)
    ////        {
    ////            objIDocVer.InsertTeleLog();
    ////        }
    ////        lblmsg.Text = "Record inserted successfully";



    ////    }
       
    ////}



    //add by:kanchan
    //add date :23/9/2014
    public void insert()//diss done
    {

        if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() != "")
        {


            objIDocVer.AttempDateTime = objcon.strDate(txtDate1.Text.Trim()) + " " + txtTime1.Text.Trim() + " " + ddlTimeType1.SelectedItem.Text.Trim();
            objIDocVer.TellPhoneRemark = txtRemarks1.Text.Trim();

            objIDocVer.TellNo = txtTelNo1.Text.Trim();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();

            //kanchan on 23/9/2014
            object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo1.Text, txtRemarks1.Text);//diss done

            if (Convert.ToInt32(o) == 0)
            {
                //kanchan on 23/9/2014
                objIDocVer.InsertTeleLog();//diss done but not yet check
            }
            lblmsg.Text = "Record inserted successfully";

        }


        if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() != "")
        {

            //valdate2.Enabled = true;
            //valtellnumer2.Enabled = true;
            //valtime2.Enabled = true;
            objIDocVer.AttempDateTime = objcon.strDate(txtDate2.Text.Trim()) + " " + txtTime2.Text.Trim() + " " + ddlTimeType2.SelectedItem.Text.Trim();
            objIDocVer.TellPhoneRemark = txtRemarks2.Text.Trim();
            objIDocVer.TellNo = txtTelNo2.Text.Trim();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();




            object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo2.Text, txtRemarks2.Text);//done but not yet check

            if (Convert.ToInt32(o) == 0)
            {
                objIDocVer.InsertTeleLog();//done
            }
            lblmsg.Text = "Record inserted successfully";



        }

        if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() != "")
        {
            //valdate3.Enabled = true;
            //telnumber3.Enabled = true;
            //valtime3.Enabled = true;
            objIDocVer.AttempDateTime = objcon.strDate(txtDate3.Text.Trim()) + " " + txtTime3.Text.Trim() + " " + ddlTimeType3.SelectedItem.Text.Trim();
            objIDocVer.TellPhoneRemark = txtRemarks3.Text.Trim();
            objIDocVer.TellNo = txtTelNo3.Text.Trim();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();



            object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo3.Text, txtRemarks3.Text);//done

            if (Convert.ToInt32(o) == 0)
            {
                objIDocVer.InsertTeleLog();//diss done
            }
            lblmsg.Text = "Record inserted successfully";



        }

        if (txtDate4.Text.Trim() != "" && txtTime4.Text.Trim() != "")
        {
            //valdate4.Enabled = true;
            //valtellnumber4.Enabled = true;
            //valtime4.Enabled = true;
            objIDocVer.AttempDateTime = objcon.strDate(txtDate4.Text.Trim()) + " " + txtTime4.Text.Trim() + " " + ddlTimeType4.SelectedItem.Text.Trim();
            objIDocVer.TellPhoneRemark = txtRemarks4.Text.Trim();
            objIDocVer.TellNo = txtTelNo4.Text.Trim();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();

            object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo4.Text, txtRemarks4.Text);//done

            if (Convert.ToInt32(o) == 0)
            {
                objIDocVer.InsertTeleLog();//diss done
            }
            lblmsg.Text = "Record inserted successfully";



        }

        if (txtDate5.Text.Trim() != "" && txtTime5.Text.Trim() != "")
        {
            objIDocVer.AttempDateTime = objcon.strDate(txtDate5.Text.Trim()) + " " + txtTime5.Text.Trim() + " " + ddlTimeType5.SelectedItem.Text.Trim();
            objIDocVer.TellPhoneRemark = txtRemarks5.Text.Trim();
            objIDocVer.TellNo = txtTelNo5.Text.Trim();
            objIDocVer.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();

            object o = objIDocVer.getveriAttemptRecord(Request.QueryString["CaseID"], objIDocVer.AttempDateTime.ToString(), objIDocVer.VerificationTypeId.ToString(), txtTelNo5.Text, txtRemarks5.Text);//done

            if (Convert.ToInt32(o) == 0)
            {
                objIDocVer.InsertTeleLog();//diss done
            }
            lblmsg.Text = "Record inserted successfully";



        }

    }


    //----comp---//
    public void Isvalid()
    {

        if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() == "" || txtDate1.Text.Trim()== "" && txtTime1.Text.Trim() != "")
        {
            IsValid1 = false;
            lblmsg.Visible = true;
            lblmsg.Text = "Please enter time or date in first call";
        }

        if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() == "" || txtDate2.Text.Trim() == "" && txtTime2.Text.Trim() != "")
        {
            IsValid1 = false;
            lblmsg.Visible = true;
            lblmsg.Text = "Please enter time or date in second call";
        }

        if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() == "" || txtDate3.Text.Trim() == "" && txtTime3.Text.Trim() != "")
        {
            IsValid1 = false;
            lblmsg.Visible = true;
            lblmsg.Text = "Please enter time or date in third call";
        }

        if (txtDate4.Text.Trim() != "" && txtTime4.Text.Trim() == "" || txtDate4.Text.Trim() == "" && txtTime4.Text.Trim() != "")
        {
            IsValid1 = false;
            lblmsg.Visible = true;
            lblmsg.Text = "Please enter time or date in fourth call";
        }

        if (txtDate5.Text.Trim() != "" && txtTime5.Text.Trim() == "" || txtDate5.Text.Trim() == "" && txtTime5.Text.Trim() != "")
        {
            IsValid1 = false;
            lblmsg.Visible = true;
            lblmsg.Text = "Please enter time or date in fifth call";
        }      
        

    }
    public void textAreaValidation()
    {
        if (txtOtherObservation.Text.Length > 255 ||  txtTeleRemark.Text.Length > 2000 || txtRemarks1.Text.Length > 255 || txtRemarks2.Text.Length > 255 || txtRemarks3.Text.Length > 255 || txtRemarks4.Text.Length > 255 || txtRemarks5.Text.Length > 255)
        {
            valtextArea = false;
            lblmsg.Visible = true;
            lblmsg.Text = " Text area length should not be greater than to 255  ";
        }
        if (txtFRemarks.Text.Length > 2000)
        {
            valtextArea = false;
            lblmsg.Visible = true;
            lblmsg.Text = " Text area length should not be greater than to 600 ";
        }
    }
    public void EnableFalse()
    {
        txtAmount.ReadOnly = true;
        ddlOTSSD.Enabled = false;
        ddlCPC.Enabled = false;
        ddlCTC.Enabled=false;
        ddlTDS.Enabled=false;
        ddlOCC.Enabled=false;
        ddlICC.Enabled=false;
        ddlTCC.Enabled=false;
        ddlOK.Enabled=false;
        ddlSpellMistake.Enabled=false;
        txtOtherObservation.ReadOnly = true;
        txtPersonContacted.ReadOnly=true;
        txtDepartment.ReadOnly=true;
        txtApplicantDesi.ReadOnly=true;
        txtApplicantDepart.ReadOnly=true;
        txtApplicantYSerOrg.ReadOnly=true;
        txtMonth.ReadOnly=true;
        txtAMIncome.ReadOnly=true;
        txtEmpOrg.ReadOnly=true;
        txtTypeOfIndustry.ReadOnly=true;
        ddlSealOrg.Enabled=false;
        ddlSIAuthority.Enabled=false;
        ddlSFOrg.Enabled=false;
        ddlSSCDate.Enabled=false;
        ddlSSSAmount.Enabled=false;
        ddlAppOffCorrect.Enabled = false;
        ddlBusinessActivitySeen.Enabled=false;
        txtNoEmployess.ReadOnly=true;
        txtStock.ReadOnly=true;
        ddlNameBoard.Enabled=false;
        txtFRemarks.ReadOnly=true;
        txtDate1.ReadOnly = true;
        txtDate2.ReadOnly = true;
        txtDate3.ReadOnly = true;
        txtDate4.ReadOnly = true;
        txtDate5.ReadOnly = true;
        txtTime1.ReadOnly = true;
        txtTime2.ReadOnly = true;
        txtTime3.ReadOnly = true;
        txtTime4.ReadOnly = true;
        txtTime5.ReadOnly = true;
        ddlTimeType1.Enabled = false;
        ddlTimeType2.Enabled = false;
        ddlTimeType3.Enabled = false;
        ddlTimeType4.Enabled = false;
        ddlTimeType5.Enabled = false;
        txtTelNo1.ReadOnly = true;
        txtTelNo1.ReadOnly = true;
        txtTelNo2.ReadOnly = true;
        txtTelNo3.ReadOnly = true;
        txtTelNo4.ReadOnly = true;
        txtTelNo5.ReadOnly = true;
        txtRemarks1.ReadOnly = true;
        txtRemarks2.ReadOnly = true;
        txtRemarks3.ReadOnly = true;
        txtRemarks4.ReadOnly = true;
        txtRemarks5.ReadOnly = true;
        txtTeleRemark.ReadOnly=true;
        txtVeriDate.ReadOnly=true;
        ddlStatus.Enabled=false;
        txtFEName.ReadOnly=true;
        btnSave.Enabled = false;
    }

    protected void cvSelectddlSupervisorName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Please select Supervisor Name";
        }
    }

    protected void btnPincode_Click(object sender, EventArgs e)
    {
        Getdata();
    }

    private void Getdata()
    {
        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_name";
        cmd.CommandTimeout = 0;

        SqlParameter Pincode = new SqlParameter();
        Pincode.SqlDbType = SqlDbType.VarChar;
        Pincode.Value = txtAreapincode.Text.Trim();
        Pincode.ParameterName = "@Pincode_no";
        cmd.Parameters.Add(Pincode);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void ddlSupervisorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
    }


       //add by: kanchan
       //add date: 23/9/2014
    protected void IDOC_F16_Sql1()
    {
        using (SqlConnection con = new SqlConnection(objcon.AppConnectionString))
        {

            string sCaseId = Request.QueryString["CaseID"].ToString();
            string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();

            SqlCommand command = new SqlCommand("sp_IDOC_F16_Sql1", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@case_id", Request.QueryString["CaseID"].ToString());
            command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerifyTypeId);

            con.Open();

            o1 = command.ExecuteScalar();

            con.Close();

            if (o1 == null)
            {
                txtFEName.Text = "";
            }
            else
            {
                txtFEName.Text = o1.ToString();
            }

        }
    }
//----comp----//

    //add by: kanchan
    //add date :23/9/2014
    protected void IDOC_F16_Sql2()
    {
        using (SqlConnection con1 = new SqlConnection(objcon.AppConnectionString))
        {

            SqlCommand command1 = new SqlCommand("sp_IDOC_F16_Sql2", con1);
            command1.CommandType = CommandType.StoredProcedure;

            command1.Parameters.AddWithValue("@case_id", Request.QueryString["CaseID"].ToString());
            con1.Open();

            o2 = command1.ExecuteScalar();

            con1.Close();
            if (o2 == null)
            {
                txtCompanyName.Text = "";
            }
            else
            {
                txtCompanyName.Text = o2.ToString();
            }
        }


    }
    //------comp------//

    //add by: kanchan
    //add date :23/9/2014

    protected void IDOC_F16_Sql3()
    {

        using (SqlConnection con1 = new SqlConnection(objcon.AppConnectionString))
        {


            SqlCommand command1 = new SqlCommand("sp_IDOC_F16_Sql3", con1);
            command1.CommandType = CommandType.StoredProcedure;

            command1.Parameters.AddWithValue("@case_id", Request.QueryString["CaseID"]);
            command1.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", Request.QueryString["VerTypeId"]);
            con1.Open();

            txtVeriDate.Text = Convert.ToDateTime(command1.ExecuteScalar().ToString()).ToString("dd/MM/yyyy");

            con1.Close();
        }


    }

    //-----comp---//


}
