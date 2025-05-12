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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing;


public partial class FE_FE_Dedup_Search : System.Web.UI.Page
{
    String strXlsSheet = "";
    OleDbConnection connection;

    CCommon objConn = new CCommon();
    SqlDataSource sdsTest = new SqlDataSource();
    string Cluster;

    protected void Page_Load(object sender, EventArgs e)
    {
        SDSCases.ConnectionString = objConn.ConnectionString;  //Sir
        SDSViewCases.ConnectionString = objConn.ConnectionString;

        txtFromDate.Focus();
        Cluster = Session["ClusterID"].ToString();

    }

    private void GetAutoDedup(Color clrGridBg)
    {
        CCommon objconn = new CCommon();
        connection = new OleDbConnection(objconn.ConnectionString);

        string strSqlDedup = " Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                             " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                             " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_CC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And (OFF_ADD_LINE_1 not like '%''%' or Res_Add_line_1 not like '%''%') and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_RL_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And (OFF_ADD_LINE_1 not like '%''%' or Res_Add_line_1 not like '%''%') and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " ADD_LINE_1,ADD_LINE_2, ADD_LINE_3, MobileNo, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,OffPh As Off_phone, OFF_ADD_LINE_3  " + " from CPV_EBC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And (OFF_ADD_LINE_1 not like '%''%'  And ADD_LINE_1 not like '%''%') and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_KYC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And (OFF_ADD_LINE_1 not like '%''%'  And Res_Add_line_1 not like '%''%')  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " +
                            " from CPV_IDOC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And (OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%')  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";


        OleDbDataReader dr = OleDbHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["MumbaiConnectionString"].ToString(), CommandType.Text, strSqlDedup);

        while (dr.Read())
        {

            sdsTest.ConnectionString = ConfigurationManager.ConnectionStrings["MumbaiConnectionString"].ToString();
            sdsTest.ProviderName = ConfigurationManager.ConnectionStrings["MumbaiConnectionString"].ProviderName;
                 
            sdsTest.SelectCommand = "SELECT Distinct Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                                        " FROM CPV_CC_CASE_DETAILS CD Left Outer JOIN" +
                                        " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " +
                                        " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";

            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }



            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "  and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2   ";

            // Search In RL
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                    " FROM CPV_RL_CASE_DETAILS CD Left Outer  JOIN" +
                                    " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In KYC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,cd.REF_NO As REF_NO,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                   " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                   " FROM CPV_KYC_CASE_DETAILS CD Left Outer  JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                   " Left Outer  join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                   " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                   " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";


            // Search In IDOC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_IDOC_CASE_DETAILS CD Left Outer  JOIN" +
                                     " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                     " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In EBC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo As Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_EBC_CASE_DETAILS CD Left Outer  JOIN" +
                                     " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";


            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or MobileNo='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";



            if (dr["OFF_ADD_LINE_1"].ToString() != "")
            {
                // Office Search
                //Office Search In CC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All  SELECT  Distinct Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                            " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                            " FROM CPV_CC_CASE_DETAILS CD Left Outer  JOIN" +
                            " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                            " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                            " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2   ";



                //Office Search In RL
                sdsTest.SelectCommand = sdsTest.SelectCommand + "  Union All SELECT Distinct  Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                        " FROM CPV_RL_CASE_DETAILS CD Left Outer  JOIN" +
                                        " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }
                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                //Office Search In KYC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,cd.REF_NO As REF_NO,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                       " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                       " FROM CPV_KYC_CASE_DETAILS CD Left Outer  JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                       " Left Outer  join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                       " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                       " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

                //Office Search In IDOC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                         " FROM CPV_IDOC_CASE_DETAILS CD Left Outer  JOIN" +
                                         " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                         " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                // Office Search In EBC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,cd.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo,  CSM.STATUS_NAME " +
                                         " FROM CPV_EBC_CASE_DETAILS CD Left Outer JOIN" +
                                         " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')  ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or offph='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

            }

            
            Label lblCriteria = new Label();

            if (dr["Full_Name"].ToString() == "")
            {
                lblCriteria.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            }
            else
            {
                lblCriteria.Text = dr["Full_Name"].ToString();

            }
            lblCriteria.CssClass = "label";

            Label lblSpace = new Label();
            lblSpace.Text = "";
            lblSpace.CssClass = "label";

            lblSpace.Height = 50;
            lblCriteria.Height = 24;

            GridView gvTest = new GridView();
            gvTest.Width = 950;
            gvTest.SkinID = "gridviewNoSort";
            gvTest.CellSpacing = 1;
            gvTest.BackColor = clrGridBg;
            gvTest.CellPadding = 1;
            if (clrGridBg == Color.Black)
                gvTest.GridLines = GridLines.None;
            else
                gvTest.GridLines = GridLines.Both;

            gvTest.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            gvTest.RowStyle.VerticalAlign = VerticalAlign.Top;
            gvTest.AutoGenerateColumns = false;
            gvTest.EnableViewState = false;

            gvTest.RowStyle.CssClass = "GridRow";
            gvTest.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTest.PagerStyle.CssClass = "Class1";
            gvTest.HeaderStyle.CssClass = "GridHeader";
            gvTest.AlternatingRowStyle.CssClass = "GridAlternate";

            gvTest.AllowPaging = false;
            gvTest.AllowSorting = false;

            BoundField bfClientName = new BoundField();
            BoundField bfRefNo = new BoundField();
            BoundField bfVerification_code = new BoundField();
            BoundField bfCustomerName = new BoundField();
            BoundField bfAdd1 = new BoundField();
            BoundField bfMobile = new BoundField();
            BoundField bfAdd2 = new BoundField();
            BoundField bfRecDate = new BoundField();
            BoundField bfCaseStatus = new BoundField();
            BoundField bfDedupRemark = new BoundField();

            bfClientName.HeaderText = "Client Name";
            bfRefNo.HeaderText = "Ref No";
            bfVerification_code.HeaderText = "Verification code";
            bfCustomerName.HeaderText = "Customer Name";
            bfAdd1.HeaderText = "ResAddress";
            bfMobile.HeaderText = "Mobile";
            bfAdd2.HeaderText = "OffAddress";
            bfRecDate.HeaderText = "Case Reeived Date";
            bfCaseStatus.HeaderText = "Case Status";
            bfDedupRemark.HeaderText = "Dedup Remark";
            bfRecDate.DataFormatString = "{0:dd-MMM-yyyy}";
            bfRecDate.HtmlEncode = false;

            bfClientName.DataField = "Client_name";
            bfRefNo.DataField = "Ref_No";
            bfVerification_code.DataField = "Verification_code";
            bfCustomerName.DataField = "Full_Name";
            bfAdd1.DataField = "ResAddress";
            bfMobile.DataField = "Mobile";
            bfAdd2.DataField = "OffAddress";
            bfRecDate.DataField = "CASE_REC_DATETIME";
            bfCaseStatus.DataField = "STATUS_NAME";
            bfDedupRemark.DataField = "DECLINED_REASON";

            gvTest.Columns.Add(bfClientName);
            gvTest.Columns.Add(bfRefNo);
            gvTest.Columns.Add(bfVerification_code);
            gvTest.Columns.Add(bfCustomerName);
            gvTest.Columns.Add(bfAdd1);
            gvTest.Columns.Add(bfMobile);
            gvTest.Columns.Add(bfAdd2);
            gvTest.Columns.Add(bfRecDate);
            gvTest.Columns.Add(bfCaseStatus);
            gvTest.Columns.Add(bfDedupRemark);

            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.Text = "Client Name: " +
                             dr["Client_name"].ToString() + " " +
                             "<br/>Customer Name: " + lblCriteria.Text +
                             "<br/>Residence Address: " +
                             dr["RES_ADD_LINE_1"].ToString() + " " + dr["RES_ADD_LINE_2"].ToString() + " " + dr["RES_ADD_LINE_3"].ToString() + " " +
                             "<br/>Mobile No: " +
                             dr["Mobile"].ToString() + " " +
                             "<br/>Office Address: " +
                            dr["OFF_ADD_LINE_1"].ToString() + " " + dr["OFF_ADD_LINE_2"].ToString() + " " + dr["OFF_ADD_LINE_3"].ToString();

            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            gvTest.DataSource = sdsTest;
            gvTest.DataBind();
            if (gvTest.Rows.Count != 0)
            {
                plhDedupe.Controls.Add(tblSpace);
                plhDedupe.Controls.Add(sdsTest);
                plhDedupe.Controls.Add(gvTest);
            }

        }
        dr.Close();
    }

    private void SouthGetAutoDedup(Color clrGridBg)
    {
        CCommon objconn = new CCommon();
        connection = new OleDbConnection(objconn.ConnectionString);

        string strSqlDedup = " Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                             " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                             " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_CC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_RL_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " ADD_LINE_1,ADD_LINE_2, ADD_LINE_3, MobileNo, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,OffPh As Off_phone, OFF_ADD_LINE_3  " + " from CPV_EBC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And ADD_LINE_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_KYC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " +
                            " from CPV_IDOC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";


        OleDbDataReader dr = OleDbHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["SouthConnectionString"].ToString(), CommandType.Text, strSqlDedup);

        while (dr.Read())
        {

            sdsTest.ConnectionString = ConfigurationManager.ConnectionStrings["SouthConnectionString"].ToString();
            sdsTest.ProviderName = ConfigurationManager.ConnectionStrings["SouthConnectionString"].ProviderName;

            // Search In CC
            sdsTest.SelectCommand = "SELECT  Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                                    " FROM CPV_CC_CASE_DETAILS CD INNER JOIN" +
                                    " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                    " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                    " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }



            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "  and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2   ";

            // Search In RL
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                    " FROM CPV_RL_CASE_DETAILS CD INNER JOIN" +
                                    " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                    " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                    " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In KYC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                   " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                   " FROM CPV_KYC_CASE_DETAILS CD INNER JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                   " Inner join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                   " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                   " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                   " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                   " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                   " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";


            // Search In IDOC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN" +
                                     " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                     " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                     " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                     " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                     " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In EBC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo As Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_EBC_CASE_DETAILS CD INNER JOIN" +
                                     " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                     " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                     " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                     " and (CD.ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";


            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or MobileNo='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";



            if (dr["OFF_ADD_LINE_1"].ToString() != "")
            {
                // Office Search
                //Office Search In CC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All  SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                            " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                            " FROM CPV_CC_CASE_DETAILS CD INNER JOIN" +
                            " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                            " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                            " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                            " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                            " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                            " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2   ";



                //Office Search In RL
                sdsTest.SelectCommand = sdsTest.SelectCommand + "  Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                        " FROM CPV_RL_CASE_DETAILS CD INNER JOIN" +
                                        " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                        " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                        " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }
                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                //Office Search In KYC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                       " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                       " FROM CPV_KYC_CASE_DETAILS CD INNER JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                       " Inner join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                       " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                       " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                       " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                       " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                       " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

                //Office Search In IDOC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                         " FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN" +
                                         " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                         " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                         " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                         " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                         " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                // Office Search In EBC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo,  CSM.STATUS_NAME " +
                                         " FROM CPV_EBC_CASE_DETAILS CD INNER JOIN" +
                                         " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                         " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                         " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                         " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')  ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or offph='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

            }




            Label lblCriteria = new Label();
            lblCriteria.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            lblCriteria.CssClass = "label";

            Label lblSpace = new Label();
            lblSpace.Text = "";
            lblSpace.CssClass = "label";

            lblSpace.Height = 50;
            lblCriteria.Height = 24;

            GridView gvTest = new GridView();
            gvTest.Width = 950;
            gvTest.SkinID = "gridviewNoSort";
            gvTest.CellSpacing = 1;
            gvTest.BackColor = clrGridBg;
            gvTest.CellPadding = 1;
            if (clrGridBg == Color.Black)
                gvTest.GridLines = GridLines.None;
            else
                gvTest.GridLines = GridLines.Both;

            gvTest.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            gvTest.RowStyle.VerticalAlign = VerticalAlign.Top;
            gvTest.AutoGenerateColumns = false;
            gvTest.EnableViewState = false;

            gvTest.RowStyle.CssClass = "GridRow";
            gvTest.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTest.PagerStyle.CssClass = "Class1";
            gvTest.HeaderStyle.CssClass = "GridHeader";
            gvTest.AlternatingRowStyle.CssClass = "GridAlternate";

            gvTest.AllowPaging = false;
            gvTest.AllowSorting = false;

            BoundField bfClientName = new BoundField();
            BoundField bfRefNo = new BoundField();
            BoundField bfVerification_code = new BoundField();
            BoundField bfCustomerName = new BoundField();
            BoundField bfAdd1 = new BoundField();
            BoundField bfMobile = new BoundField();
            BoundField bfAdd2 = new BoundField();
            BoundField bfRecDate = new BoundField();
            BoundField bfCaseStatus = new BoundField();
            BoundField bfDedupRemark = new BoundField();

            bfClientName.HeaderText = "Client Name";
            bfRefNo.HeaderText = "Ref No";
            bfVerification_code.HeaderText = "Verification code";
            bfCustomerName.HeaderText = "Customer Name";
            bfAdd1.HeaderText = "ResAddress";
            bfMobile.HeaderText = "Mobile";
            bfAdd2.HeaderText = "OffAddress";
            bfRecDate.HeaderText = "Case Reeived Date";
            bfCaseStatus.HeaderText = "Case Status";
            bfDedupRemark.HeaderText = "Dedup Remark";
            bfRecDate.DataFormatString = "{0:dd-MMM-yyyy}";
            bfRecDate.HtmlEncode = false;

            bfClientName.DataField = "Client_name";
            bfRefNo.DataField = "Ref_No";
            bfVerification_code.DataField = "Verification_code";
            bfCustomerName.DataField = "Full_Name";
            bfAdd1.DataField = "ResAddress";
            bfMobile.DataField = "Mobile";
            bfAdd2.DataField = "OffAddress";
            bfRecDate.DataField = "CASE_REC_DATETIME";
            bfCaseStatus.DataField = "STATUS_NAME";
            bfDedupRemark.DataField = "DECLINED_REASON";

            gvTest.Columns.Add(bfClientName);
            gvTest.Columns.Add(bfRefNo);
            gvTest.Columns.Add(bfVerification_code);
            gvTest.Columns.Add(bfCustomerName);
            gvTest.Columns.Add(bfAdd1);
            gvTest.Columns.Add(bfMobile);
            gvTest.Columns.Add(bfAdd2);
            gvTest.Columns.Add(bfRecDate);
            gvTest.Columns.Add(bfCaseStatus);
            gvTest.Columns.Add(bfDedupRemark);

            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.Text = "Client Name: " +
                             dr["Client_name"].ToString() + " " +
                             "<br/>Customer Name: " + lblCriteria.Text +
                             "<br/>Residence Address: " +
                             dr["RES_ADD_LINE_1"].ToString() + " " + dr["RES_ADD_LINE_2"].ToString() + " " + dr["RES_ADD_LINE_3"].ToString() + " " +
                             "<br/>Mobile No: " +
                             dr["Mobile"].ToString() + " " +
                             "<br/>Office Address: " +
                            dr["OFF_ADD_LINE_1"].ToString() + " " + dr["OFF_ADD_LINE_2"].ToString() + " " + dr["OFF_ADD_LINE_3"].ToString();

            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            gvTest.DataSource = sdsTest;
            gvTest.DataBind();
            if (gvTest.Rows.Count != 0)
            {
                plhDedupe.Controls.Add(tblSpace);
                plhDedupe.Controls.Add(sdsTest);
                plhDedupe.Controls.Add(gvTest);
            }

        }
        dr.Close();
    }

    private void NorthGetAutoDedup(Color clrGridBg)
    {
        CCommon objconn = new CCommon();
        connection = new OleDbConnection(objconn.ConnectionString);

        string strSqlDedup = " Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                             " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                             " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_CC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_RL_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " ADD_LINE_1,ADD_LINE_2, ADD_LINE_3, MobileNo, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,OffPh As Off_phone, OFF_ADD_LINE_3  " + " from CPV_EBC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And ADD_LINE_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_KYC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " +
                            " from CPV_IDOC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";



        OleDbDataReader dr = OleDbHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["NorthConnectionString"].ToString(), CommandType.Text, strSqlDedup);

        while (dr.Read())
        {

            sdsTest.ConnectionString = ConfigurationManager.ConnectionStrings["NorthConnectionString"].ToString();
            sdsTest.ProviderName = ConfigurationManager.ConnectionStrings["NorthConnectionString"].ProviderName;

            // Search In CC
            sdsTest.SelectCommand = "SELECT  Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                                    " FROM CPV_CC_CASE_DETAILS CD INNER JOIN" +
                                    " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                    " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                    " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }



            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "  and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2   ";

            // Search In RL
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                    " FROM CPV_RL_CASE_DETAILS CD INNER JOIN" +
                                    " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                    " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                    " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In KYC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                   " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                   " FROM CPV_KYC_CASE_DETAILS CD INNER JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                   " Inner join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                   " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                   " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                   " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                   " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                   " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";


            // Search In IDOC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN" +
                                     " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                     " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                     " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                     " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                     " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In EBC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo As Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_EBC_CASE_DETAILS CD INNER JOIN" +
                                     " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                     " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                     " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                     " and (CD.ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";


            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or MobileNo='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";



            if (dr["OFF_ADD_LINE_1"].ToString() != "")
            {
                // Office Search
                //Office Search In CC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All  SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                            " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                            " FROM CPV_CC_CASE_DETAILS CD INNER JOIN" +
                            " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                            " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                            " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                            " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                            " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                            " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2   ";



                //Office Search In RL
                sdsTest.SelectCommand = sdsTest.SelectCommand + "  Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                        " FROM CPV_RL_CASE_DETAILS CD INNER JOIN" +
                                        " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                        " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                        " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }
                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                //Office Search In KYC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                       " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                       " FROM CPV_KYC_CASE_DETAILS CD INNER JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                       " Inner join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                       " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                       " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                       " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                       " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                       " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

                //Office Search In IDOC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                         " FROM CPV_IDOC_CASE_DETAILS CD INNER JOIN" +
                                         " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  INNER JOIN " +
                                         " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                         " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                         " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                         " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                // Office Search In EBC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT   Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo,  CSM.STATUS_NAME " +
                                         " FROM CPV_EBC_CASE_DETAILS CD INNER JOIN" +
                                         " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                         " and (CD.CASE_REC_DATETIME < '" + txtFromDate.Text + "' " +
                                         " or CD.CASE_REC_DATETIME >= '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "')" +
                                         " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')  ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or offph='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

            }




            Label lblCriteria = new Label();
            lblCriteria.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            lblCriteria.CssClass = "label";

            Label lblSpace = new Label();
            lblSpace.Text = "";
            lblSpace.CssClass = "label";

            lblSpace.Height = 50;
            lblCriteria.Height = 24;

            GridView gvTest = new GridView();
            gvTest.Width = 950;
            gvTest.SkinID = "gridviewNoSort";
            gvTest.CellSpacing = 1;
            gvTest.BackColor = clrGridBg;
            gvTest.CellPadding = 1;
            if (clrGridBg == Color.Black)
                gvTest.GridLines = GridLines.None;
            else
                gvTest.GridLines = GridLines.Both;

            gvTest.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            gvTest.RowStyle.VerticalAlign = VerticalAlign.Top;
            gvTest.AutoGenerateColumns = false;
            gvTest.EnableViewState = false;

            gvTest.RowStyle.CssClass = "GridRow";
            gvTest.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTest.PagerStyle.CssClass = "Class1";
            gvTest.HeaderStyle.CssClass = "GridHeader";
            gvTest.AlternatingRowStyle.CssClass = "GridAlternate";

            gvTest.AllowPaging = false;
            gvTest.AllowSorting = false;

            BoundField bfClientName = new BoundField();
            BoundField bfRefNo = new BoundField();
            BoundField bfVerification_code = new BoundField();
            BoundField bfCustomerName = new BoundField();
            BoundField bfAdd1 = new BoundField();
            BoundField bfMobile = new BoundField();
            BoundField bfAdd2 = new BoundField();
            BoundField bfRecDate = new BoundField();
            BoundField bfCaseStatus = new BoundField();
            BoundField bfDedupRemark = new BoundField();

            bfClientName.HeaderText = "Client Name";
            bfRefNo.HeaderText = "Ref No";
            bfVerification_code.HeaderText = "Verification code";
            bfCustomerName.HeaderText = "Customer Name";
            bfAdd1.HeaderText = "ResAddress";
            bfMobile.HeaderText = "Mobile";
            bfAdd2.HeaderText = "OffAddress";
            bfRecDate.HeaderText = "Case Reeived Date";
            bfCaseStatus.HeaderText = "Case Status";
            bfDedupRemark.HeaderText = "Dedup Remark";
            bfRecDate.DataFormatString = "{0:dd-MMM-yyyy}";
            bfRecDate.HtmlEncode = false;

            bfClientName.DataField = "Client_name";
            bfRefNo.DataField = "Ref_No";
            bfVerification_code.DataField = "Verification_code";
            bfCustomerName.DataField = "Full_Name";
            bfAdd1.DataField = "ResAddress";
            bfMobile.DataField = "Mobile";
            bfAdd2.DataField = "OffAddress";
            bfRecDate.DataField = "CASE_REC_DATETIME";
            bfCaseStatus.DataField = "STATUS_NAME";
            bfDedupRemark.DataField = "DECLINED_REASON";

            gvTest.Columns.Add(bfClientName);
            gvTest.Columns.Add(bfRefNo);
            gvTest.Columns.Add(bfVerification_code);
            gvTest.Columns.Add(bfCustomerName);
            gvTest.Columns.Add(bfAdd1);
            gvTest.Columns.Add(bfMobile);
            gvTest.Columns.Add(bfAdd2);
            gvTest.Columns.Add(bfRecDate);
            gvTest.Columns.Add(bfCaseStatus);
            gvTest.Columns.Add(bfDedupRemark);

            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.Text = "Client Name: " +
                             dr["Client_name"].ToString() + " " +
                             "<br/>Customer Name: " + lblCriteria.Text +
                             "<br/>Residence Address: " +
                             dr["RES_ADD_LINE_1"].ToString() + " " + dr["RES_ADD_LINE_2"].ToString() + " " + dr["RES_ADD_LINE_3"].ToString() + " " +
                             "<br/>Mobile No: " +
                             dr["Mobile"].ToString() + " " +
                             "<br/>Office Address: " +
                            dr["OFF_ADD_LINE_1"].ToString() + " " + dr["OFF_ADD_LINE_2"].ToString() + " " + dr["OFF_ADD_LINE_3"].ToString();

            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            gvTest.DataSource = sdsTest;
            gvTest.DataBind();
            if (gvTest.Rows.Count != 0)
            {
                plhDedupe.Controls.Add(tblSpace);
                plhDedupe.Controls.Add(sdsTest);
                plhDedupe.Controls.Add(gvTest);
            }

        }
        dr.Close();
    }

    private void WestGetAutoDedup(Color clrGridBg)
    {
     
        CCommon objconn = new CCommon();
        connection = new OleDbConnection(objconn.ConnectionString);

        string strSqlDedup = " Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                             " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                             " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_CC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_RL_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " ADD_LINE_1,ADD_LINE_2, ADD_LINE_3, MobileNo, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,OffPh As Off_phone, OFF_ADD_LINE_3  " + " from CPV_EBC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And ADD_LINE_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_KYC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " +
                            " from CPV_IDOC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";



        OleDbDataReader dr = OleDbHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["WESTConnectionString"].ToString(), CommandType.Text, strSqlDedup);

        while (dr.Read())
        {

            sdsTest.ConnectionString = ConfigurationManager.ConnectionStrings["WESTConnectionString"].ToString();
            sdsTest.ProviderName = ConfigurationManager.ConnectionStrings["WESTConnectionString"].ProviderName;

            // Search In CC
            sdsTest.SelectCommand = "SELECT Distinct Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                                        " FROM CPV_CC_CASE_DETAILS CD Left Outer JOIN" +
                                        " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " +
                                        " and Res_Add_line_1 not like '%''%' and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";

            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }



            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "  and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2   ";

            // Search In RL
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                    " FROM CPV_RL_CASE_DETAILS CD Left Outer  JOIN" +
                                    " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In KYC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.Ref_No As Ref_No,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                   " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                   " FROM CPV_KYC_CASE_DETAILS CD Left Outer  JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                   " Left Outer  join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                   " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                   " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";


            // Search In IDOC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_IDOC_CASE_DETAILS CD Left Outer  JOIN" +
                                     " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                     " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In EBC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo As Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_EBC_CASE_DETAILS CD Left Outer  JOIN" +
                                     " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";


            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or MobileNo='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";



            if (dr["OFF_ADD_LINE_1"].ToString() != "")
            {
                // Office Search
                //Office Search In CC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All  SELECT  Distinct Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                            " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                            " FROM CPV_CC_CASE_DETAILS CD Left Outer  JOIN" +
                            " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                            " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                            " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2   ";



                //Office Search In RL
                sdsTest.SelectCommand = sdsTest.SelectCommand + "  Union All SELECT Distinct  Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                        " FROM CPV_RL_CASE_DETAILS CD Left Outer  JOIN" +
                                        " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }
                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                //Office Search In KYC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.Ref_No As Ref_No,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                       " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                       " FROM CPV_KYC_CASE_DETAILS CD Left Outer  JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                       " Left Outer  join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                       " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                       " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

                //Office Search In IDOC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                         " FROM CPV_IDOC_CASE_DETAILS CD Left Outer  JOIN" +
                                         " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                         " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                // Office Search In EBC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,CD.Ref_No As Ref_No,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo,  CSM.STATUS_NAME " +
                                         " FROM CPV_EBC_CASE_DETAILS CD Left Outer JOIN" +
                                         " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')  ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or offph='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

            }




            Label lblCriteria = new Label();

            if (dr["Full_Name"].ToString() == "")
            {
                lblCriteria.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            }
            else
            {
                lblCriteria.Text = dr["Full_Name"].ToString();

            }
            lblCriteria.CssClass = "label";

            Label lblSpace = new Label();
            lblSpace.Text = "";
            lblSpace.CssClass = "label";

            lblSpace.Height = 50;
            lblCriteria.Height = 24;

            GridView gvTest = new GridView();
            gvTest.Width = 950;
            gvTest.SkinID = "gridviewNoSort";
            gvTest.CellSpacing = 1;
            gvTest.BackColor = clrGridBg;
            gvTest.CellPadding = 1;
            if (clrGridBg == Color.Black)
                gvTest.GridLines = GridLines.None;
            else
                gvTest.GridLines = GridLines.Both;

            gvTest.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            gvTest.RowStyle.VerticalAlign = VerticalAlign.Top;
            gvTest.AutoGenerateColumns = false;
            gvTest.EnableViewState = false;

            gvTest.RowStyle.CssClass = "GridRow";
            gvTest.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTest.PagerStyle.CssClass = "Class1";
            gvTest.HeaderStyle.CssClass = "GridHeader";
            gvTest.AlternatingRowStyle.CssClass = "GridAlternate";

            gvTest.AllowPaging = false;
            gvTest.AllowSorting = false;

            BoundField bfClientName = new BoundField();
            BoundField bfRefNo = new BoundField();
            BoundField bfVerification_code = new BoundField();
            BoundField bfCustomerName = new BoundField();
            BoundField bfAdd1 = new BoundField();
            BoundField bfMobile = new BoundField();
            BoundField bfAdd2 = new BoundField();
            BoundField bfRecDate = new BoundField();
            BoundField bfCaseStatus = new BoundField();
            BoundField bfDedupRemark = new BoundField();

            bfClientName.HeaderText = "Client Name";
            bfRefNo.HeaderText = "Ref No";
            bfVerification_code.HeaderText = "Verification code";
            bfCustomerName.HeaderText = "Customer Name";
            bfAdd1.HeaderText = "ResAddress";
            bfMobile.HeaderText = "Mobile";
            bfAdd2.HeaderText = "OffAddress";
            bfRecDate.HeaderText = "Case Reeived Date";
            bfCaseStatus.HeaderText = "Case Status";
            bfDedupRemark.HeaderText = "Dedup Remark";
            bfRecDate.DataFormatString = "{0:dd-MMM-yyyy}";
            bfRecDate.HtmlEncode = false;

            bfClientName.DataField = "Client_name";
            bfRefNo.DataField = "Ref_No";
            bfVerification_code.DataField = "Verification_code";
            bfCustomerName.DataField = "Full_Name";
            bfAdd1.DataField = "ResAddress";
            bfMobile.DataField = "Mobile";
            bfAdd2.DataField = "OffAddress";
            bfRecDate.DataField = "CASE_REC_DATETIME";
            bfCaseStatus.DataField = "STATUS_NAME";
            bfDedupRemark.DataField = "DECLINED_REASON";

            gvTest.Columns.Add(bfClientName);
            gvTest.Columns.Add(bfRefNo);
            gvTest.Columns.Add(bfVerification_code);
            gvTest.Columns.Add(bfCustomerName);
            gvTest.Columns.Add(bfAdd1);
            gvTest.Columns.Add(bfMobile);
            gvTest.Columns.Add(bfAdd2);
            gvTest.Columns.Add(bfRecDate);
            gvTest.Columns.Add(bfCaseStatus);
            gvTest.Columns.Add(bfDedupRemark);

            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.Text = "Client Name: " +
                             dr["Client_name"].ToString() + " " +
                             "<br/>Customer Name: " + lblCriteria.Text +
                             "<br/>Residence Address: " +
                             dr["RES_ADD_LINE_1"].ToString() + " " + dr["RES_ADD_LINE_2"].ToString() + " " + dr["RES_ADD_LINE_3"].ToString() + " " +
                             "<br/>Mobile No: " +
                             dr["Mobile"].ToString() + " " +
                             "<br/>Office Address: " +
                            dr["OFF_ADD_LINE_1"].ToString() + " " + dr["OFF_ADD_LINE_2"].ToString() + " " + dr["OFF_ADD_LINE_3"].ToString();

            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            gvTest.DataSource = sdsTest;
            gvTest.DataBind();
            if (gvTest.Rows.Count != 0)
            {
                plhDedupe.Controls.Add(tblSpace);
                plhDedupe.Controls.Add(sdsTest);
                plhDedupe.Controls.Add(gvTest);
            }

        }
        dr.Close();


     }

    private void EastGetAutoDedup(Color clrGridBg)
    {

        CCommon objconn = new CCommon();
        connection = new OleDbConnection(objconn.ConnectionString);

        string strSqlDedup = " Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                             " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                             " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_CC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_RL_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " ADD_LINE_1,ADD_LINE_2, ADD_LINE_3, MobileNo, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,OffPh As Off_phone, OFF_ADD_LINE_3  " + " from CPV_EBC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And ADD_LINE_1 not like '%''%' and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " + " from CPV_KYC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                             " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%'  And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'" +

                            " Union All Select Distinct Case_Id, CCCD.CLIENT_ID,Client_name, CCCD.REF_NO As REF_NO,DOB, CASE_REC_DATETIME, FIRST_NAME, MIDDLE_NAME, LAST_NAME, FULL_NAME," +
                            " RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, Mobile, " +
                            " OFF_ADD_LINE_1, OFF_ADD_LINE_2,Off_phone, OFF_ADD_LINE_3  " +
                            " from CPV_IDOC_CASE_DETAILS  CCCD Inner join Client_master CM on CCCD.client_id=CM.Client_id where Centre_id  ='" + Session["CentreID"].ToString() + "'  And CASE_REC_DATETIME >= '" + txtFromDate.Text + "'" +
                            " And FIRST_NAME not like '%''%' And OFF_ADD_LINE_1 not like '%''%' And Res_Add_line_1 not like '%''%'  and CASE_REC_DATETIME < '" + Convert.ToDateTime(txtToDate.Text).AddDays(1.0).ToString("dd-MMM-yyyy") + "'";



        OleDbDataReader dr = OleDbHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["EastConnectionString"].ToString(), CommandType.Text, strSqlDedup);

        while (dr.Read())
        {

            sdsTest.ConnectionString = ConfigurationManager.ConnectionStrings["EastConnectionString"].ToString();
            sdsTest.ProviderName = ConfigurationManager.ConnectionStrings["EastConnectionString"].ProviderName;

            // Search In CC
            sdsTest.SelectCommand = "SELECT Distinct Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                                        " FROM CPV_CC_CASE_DETAILS CD Left Outer JOIN" +
                                        " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " +
                                       " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";

            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }



            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "  and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2   ";

            // Search In RL
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                    " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                    " FROM CPV_RL_CASE_DETAILS CD Left Outer  JOIN" +
                                    " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                    " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                    " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In KYC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.REF_NO As REF_NO,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                   " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                   " FROM CPV_KYC_CASE_DETAILS CD Left Outer  JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                   " Left Outer  join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                   " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                   " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";


            // Search In IDOC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_IDOC_CASE_DETAILS CD Left Outer  JOIN" +
                                     " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                     " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.RES_ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";
            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Mobile='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CVD.CASE_STATUS_ID = 2";

            // Search In EBC
            sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                     " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                     " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                     " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo As Mobile, CSM.STATUS_NAME " +
                                     " FROM CPV_EBC_CASE_DETAILS CD Left Outer  JOIN" +
                                     " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                     " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                    " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                    " and  '" + txtFromDate.Text + "') " + " and (CD.ADD_LINE_1 Like('%" + dr["RES_ADD_LINE_1"].ToString() + "%')";


            if (dr["Mobile"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or MobileNo='" + dr["Mobile"].ToString() + "'";
            }
            if (dr["DOB"].ToString() != "")
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
            }
            else
            {
                sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

            }
            if (ckhSoundex.Checked == true)
                sdsTest.SelectCommand = sdsTest.SelectCommand + "";
            else
            {
                if (dr["FIRST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                if (dr["MIDDLE_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                if (dr["LAST_NAME"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                if (dr["Full_Name"].ToString() != "")
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

            }
            if (rdbNegative.Checked)
                sdsTest.SelectCommand = sdsTest.SelectCommand +
                               " and CD.CASE_STATUS_ID = 2";



            if (dr["OFF_ADD_LINE_1"].ToString() != "")
            {
                // Office Search
                //Office Search In CC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All  SELECT  Distinct Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                            " CD.CASE_REC_DATETIME, CVD.DECLINED_REASON,Mobile,CSM.STATUS_NAME " +
                            " FROM CPV_CC_CASE_DETAILS CD Left Outer  JOIN" +
                            " CPV_CC_VERI_DETAILS CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                            " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                            " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2   ";



                //Office Search In RL
                sdsTest.SelectCommand = sdsTest.SelectCommand + "  Union All SELECT Distinct  Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                        " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                        " FROM CPV_RL_CASE_DETAILS CD Left Outer  JOIN" +
                                        " CPV_RL_VERIFICATION_REF CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                        " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                        " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }
                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                //Office Search In KYC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.REF_NO As REF_NO,Verification_Type_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                    " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                    " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                       " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                       " FROM CPV_KYC_CASE_DETAILS CD Left Outer  JOIN CPV_KYC_CASE_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID " +
                                       " Left Outer  join Verification_type_master VTM on VTM.verification_type_id=CVD.verification_type_id  INNER JOIN " +
                                       " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                       " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";

                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

                //Office Search In IDOC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT  Distinct Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME,ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.RES_ADD_LINE_1 + ' ', '') + ISNULL(cd.RES_ADD_LINE_2 + ' ', '') + ISNULL(cd.RES_ADD_LINE_3 + ' ', '')+ ISNULL(cd.RES_CITY + ' ', '')+ ISNULL(cd.RES_PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_NAME + ' ', '') + ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '')+ ISNULL(cd.OFF_CITY + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,Mobile,  CSM.STATUS_NAME " +
                                         " FROM CPV_IDOC_CASE_DETAILS CD Left Outer  JOIN" +
                                         " CPV_IDOC_VERIFICATION CVD ON CD.CASE_ID = CVD.CASE_ID  Left Outer  JOIN " +
                                         " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%') ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or Off_phone='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CVD.CASE_STATUS_ID = 2";

                // Office Search In EBC
                sdsTest.SelectCommand = sdsTest.SelectCommand + " Union All SELECT Distinct  Client_name,CD.REF_NO As REF_NO,Verification_code,CD.TITLE, CD.FIRST_NAME, CD.MIDDLE_NAME, CD.LAST_NAME, ISNULL(cd.FIRST_NAME + ' ', '')+ ISNULL(cd.MIDDLE_NAME + ' ', '')+ ISNULL(cd.LAST_NAME + ' ', '') As FULL_NAME, " +
                                         " ISNULL(cd.ADD_LINE_1 + ' ', '') + ISNULL(cd.ADD_LINE_2 + ' ', '') + ISNULL(cd.ADD_LINE_3 + ' ', '')+ ISNULL(cd.CITY + ' ', '')+ ISNULL(cd.PIN_CODE + ' ', '') As ResAddress , " +
                                         " ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') As OffAddress , " +
                                         " CD.CASE_REC_DATETIME, '' As DECLINED_REASON,MobileNo,  CSM.STATUS_NAME " +
                                         " FROM CPV_EBC_CASE_DETAILS CD Left Outer JOIN" +
                                         " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID Inner join Client_master cm on  cd.client_id=cm.client_id where " +
                                         " Centre_id  ='" + Session["CentreID"].ToString() + "'" +
                                        " And (CD.CASE_REC_DATETIME Between '" + Convert.ToDateTime(txtFromDate.Text).AddDays(-100).ToString("dd-MMM-yyyy") + "'" +
                                        " and  '" + txtFromDate.Text + "') " + " And (CD.OFF_ADD_LINE_1 Like('%" + dr["OFF_ADD_LINE_1"].ToString() + "%')  ";


                if (dr["Off_phone"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or offph='" + dr["Off_phone"].ToString() + "' ";
                }
                if (dr["DOB"].ToString() != "")
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + " Or DOB='" + dr["DOB"].ToString() + "') ";
                }
                else
                {
                    sdsTest.SelectCommand = sdsTest.SelectCommand + ")";

                }

                if (ckhSoundex.Checked == true)
                    sdsTest.SelectCommand = sdsTest.SelectCommand + "";
                else
                {
                    if (dr["FIRST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and FIRST_NAME Like('%" + dr["FIRST_NAME"].ToString() + "%') ";
                    if (dr["MIDDLE_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and MIDDLE_NAME Like('%" + dr["MIDDLE_NAME"].ToString() + "%')";
                    if (dr["LAST_NAME"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and LAST_NAME Like('%" + dr["LAST_NAME"].ToString() + "%')";
                    if (dr["Full_Name"].ToString() != "")
                        sdsTest.SelectCommand = sdsTest.SelectCommand + " and Full_Name Like('%" + dr["Full_Name"].ToString() + "%')";

                }
                if (rdbNegative.Checked)
                    sdsTest.SelectCommand = sdsTest.SelectCommand +
                                   " and CD.CASE_STATUS_ID = 2";

            }




            Label lblCriteria = new Label();

            if (dr["Full_Name"].ToString() == "")
            {
                lblCriteria.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
            }
            else
            {
                lblCriteria.Text = dr["Full_Name"].ToString();

            }
            lblCriteria.CssClass = "label";

            Label lblSpace = new Label();
            lblSpace.Text = "";
            lblSpace.CssClass = "label";

            lblSpace.Height = 50;
            lblCriteria.Height = 24;

            GridView gvTest = new GridView();
            gvTest.Width = 950;
            gvTest.SkinID = "gridviewNoSort";
            gvTest.CellSpacing = 1;
            gvTest.BackColor = clrGridBg;
            gvTest.CellPadding = 1;
            if (clrGridBg == Color.Black)
                gvTest.GridLines = GridLines.None;
            else
                gvTest.GridLines = GridLines.Both;

            gvTest.RowStyle.HorizontalAlign = HorizontalAlign.Left;
            gvTest.RowStyle.VerticalAlign = VerticalAlign.Top;
            gvTest.AutoGenerateColumns = false;
            gvTest.EnableViewState = false;

            gvTest.RowStyle.CssClass = "GridRow";
            gvTest.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            gvTest.PagerStyle.CssClass = "Class1";
            gvTest.HeaderStyle.CssClass = "GridHeader";
            gvTest.AlternatingRowStyle.CssClass = "GridAlternate";

            gvTest.AllowPaging = false;
            gvTest.AllowSorting = false;

            BoundField bfClientName = new BoundField();
            BoundField bfRefNo = new BoundField();
            BoundField bfVerification_code = new BoundField();
            BoundField bfCustomerName = new BoundField();
            BoundField bfAdd1 = new BoundField();
            BoundField bfMobile = new BoundField();
            BoundField bfAdd2 = new BoundField();
            BoundField bfRecDate = new BoundField();
            BoundField bfCaseStatus = new BoundField();
            BoundField bfDedupRemark = new BoundField();

            bfClientName.HeaderText = "Client Name";
            bfRefNo.HeaderText = "Ref No";
            bfVerification_code.HeaderText = "Verification code";
            bfCustomerName.HeaderText = "Customer Name";
            bfAdd1.HeaderText = "ResAddress";
            bfMobile.HeaderText = "Mobile";
            bfAdd2.HeaderText = "OffAddress";
            bfRecDate.HeaderText = "Case Reeived Date";
            bfCaseStatus.HeaderText = "Case Status";
            bfDedupRemark.HeaderText = "Dedup Remark";
            bfRecDate.DataFormatString = "{0:dd-MMM-yyyy}";
            bfRecDate.HtmlEncode = false;

            bfClientName.DataField = "Client_name";
            bfRefNo.DataField = "Ref_No";
            bfVerification_code.DataField = "Verification_code";
            bfCustomerName.DataField = "Full_Name";
            bfAdd1.DataField = "ResAddress";
            bfMobile.DataField = "Mobile";
            bfAdd2.DataField = "OffAddress";
            bfRecDate.DataField = "CASE_REC_DATETIME";
            bfCaseStatus.DataField = "STATUS_NAME";
            bfDedupRemark.DataField = "DECLINED_REASON";

            gvTest.Columns.Add(bfClientName);
            gvTest.Columns.Add(bfRefNo);
            gvTest.Columns.Add(bfVerification_code);
            gvTest.Columns.Add(bfCustomerName);
            gvTest.Columns.Add(bfAdd1);
            gvTest.Columns.Add(bfMobile);
            gvTest.Columns.Add(bfAdd2);
            gvTest.Columns.Add(bfRecDate);
            gvTest.Columns.Add(bfCaseStatus);
            gvTest.Columns.Add(bfDedupRemark);

            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.Text = "Client Name: " +
                             dr["Client_name"].ToString() + " " +
                             "<br/>Customer Name: " + lblCriteria.Text +
                             "<br/>Residence Address: " +
                             dr["RES_ADD_LINE_1"].ToString() + " " + dr["RES_ADD_LINE_2"].ToString() + " " + dr["RES_ADD_LINE_3"].ToString() + " " +
                             "<br/>Mobile No: " +
                             dr["Mobile"].ToString() + " " +
                             "<br/>Office Address: " +
                            dr["OFF_ADD_LINE_1"].ToString() + " " + dr["OFF_ADD_LINE_2"].ToString() + " " + dr["OFF_ADD_LINE_3"].ToString();

            tblCell1.CssClass = "label";

            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);

            tblRow.Height = 20;

            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            gvTest.DataSource = sdsTest;
            gvTest.DataBind();
            if (gvTest.Rows.Count != 0)
            {
                plhDedupe.Controls.Add(tblSpace);
                plhDedupe.Controls.Add(sdsTest);
                plhDedupe.Controls.Add(gvTest);
            }

        }
        dr.Close();


     }

    protected void btnDedupeSearch_Click(object sender, EventArgs e)
    {
        if (Cluster == "1015")
        {
            NorthGetAutoDedup(Color.Wheat);
        }
        else if (Cluster == "1014")
        {
            EastGetAutoDedup(Color.Wheat);
        }
        else if (Cluster == "1013")
        {
            SouthGetAutoDedup(Color.Wheat);
        }
        else if (Cluster == "1011")
        {
            GetAutoDedup(Color.Wheat);
        }
        else if (Cluster == "1016")
        {
            GetAutoDedup(Color.Wheat);
        }
        else
        {
            WestGetAutoDedup(Color.Wheat);
        }

        btnDedupeSearch.Focus();

    }


    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        ExportExcel();

    }

    private void ExportExcel()
    {
        Response.ClearContent();

        GetAutoDedup(Color.White);
        if (plhDedupe.Controls.Count == 0)
        {
            lblMsg.Text = "No data found for exporting to excel.";
        }
        else
        {
            string attachment = "attachment; filename=DedupSearch.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            plhDedupe.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    
}
