using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace Webservice
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        public class Product
        {
            public string hdfc_pms_case_id1 { get; set; }
            public string hdfc_verification_type_code { get; set; }
            public string hdfc_ref_no { get; set; }
            public string hdfc_applicantname { get; set; }
            public string hdfc_mobileno { get; set; }
            public string hdfc_caseresult { get; set; }
            public string hdfc_case_initiation_date { get; set; }
            public string hdfc_case_received_date { get; set; }
            public string hdfc_full_address { get; set; }
            public string hdfc_off_address2 { get; set; }
            public string hdfc_off_address3 { get; set; }
            public string hdfc_residence_address2 { get; set; }
            public string hdfc_residence_address3 { get; set; }
            public string hdfc_landmark { get; set; }
            public string hdfc_pincode { get; set; }
            public string hdfc_is_this_pincode_right_or_wrong { get; set; }
            public string hdfc_nationality { get; set; }
            public string hdfc_locality_type { get; set; }
            public string hdfc_neighbour_sign_board_sighted_remark { get; set; }
            public string hdfc_rv_tel { get; set; }
            public string hdfc_contact_person { get; set; }
            public string hdfc_designation { get; set; }
            public string hdfc_number_of_years_in_current_employment { get; set; }
            public string hdfc_third_party_invoice_issued_by { get; set; }
            public string hdfc_third_party_address { get; set; }
            public string hdfc_no_of_employees { get; set; }
            public string hdfc_business_activity { get; set; }
            public string hdfc_business_equipment_sighted { get; set; }
            public string hdfc_if_other_please_specify { get; set; }
            public string hdfc_standard_remark { get; set; }
            public string hdfc_1_st_attempt_date { get; set; }
            public string hdfc_1_st_attempt_time { get; set; }
            public string hdfc_1_st_attempt_remarks { get; set; }
            public string hdfc_1_st_attempt_substatus { get; set; }
            public string hdfc_2_nd_attempt_date { get; set; }
            public string hdfc_2_nd_attempt_time { get; set; }
            public string hdfc_2_nd_attempt_remarks { get; set; }
            public string hdfc_2_nd_attempt_substatus { get; set; }
            public string hdfc_3_rd_attempt_date { get; set; }
            public string hdfc_3_rd_attempt_time { get; set; }
            public string hdfc_3_rd_attempt_remarks { get; set; }
            public string hdfc_3_rd_attempt_substatus { get; set; }
            public string hdfc_constitutions { get; set; }
            public string hdfc_locating_address { get; set; }
            public string hdfc_nature_of_business { get; set; }
            public string hdfc_employee_type { get; set; }
            public string hdfc_supervisors_name { get; set; }
            public string hdfc_area_name { get; set; }
            public string hdfc_city_limit { get; set; }
            public string hdfc_status { get; set; }
            public string hdfc_area_locality_type { get; set; }
            public string hdfc_whether_visiting_card_obtained { get; set; }
            public string hdfc_reason_for_not_having_a_valid_address_business_proof { get; set; }
            public string hdfc_observations_of_employee_conducting_cpv_if_not_recommended { get; set; }
            public string hdfc_authorised_signatory_met_in_person { get; set; }
            public string hdfc_resi_landmark { get; set; }
            public string hdfc_area_of_residence { get; set; }
            public string hdfc_photocopy_of_pan_address_proof_collected { get; set; }
            public string hdfc_person_contacted { get; set; }
            public string hdfc_having_demat_account_with_other_institution { get; set; }
            public string hdfc_if_yes_then_name_of_the_dp { get; set; }
            public string hdfc_phone_res { get; set; }
            public string hdfc_if_office_are_business_activity_seen { get; set; }
            public string hdfc_attitute_of_the_contact_person { get; set; }
            public string hdfc_general_comments { get; set; }
            public string hdfc_bv_tel { get; set; }
            public string hdfc_off_name { get; set; }
            public string hdfc_if_others_please_provide_details { get; set; }
            public string hdfc_name_plate_sighted_at_society_door { get; set; }
            public string hdfc_branch_name { get; set; }
            public string hdfc_branch_code { get; set; }
            public string hdfc_if_yes_does_name_match_with_records { get; set; }
            public string hdfc_customer_met_in_person { get; set; }
            public string hdfc_if_no_reason { get; set; }
            public string hdfc_name_of_the_person_contacted_during_cpv { get; set; }
            public string hdfc_customer_contact_numbers_r { get; set; }
            public string hdfc_email { get; set; }
            public string hdfc_occuption { get; set; }
            public string hdfc_occupation_details { get; set; }
            public string hdfc_no_of_years_in_present_occupation { get; set; }
            public string hdfc_relationship_with_customer { get; set; }
            public string hdfc_staying_since_at_resi { get; set; }
            public string hdfc_any_other_details { get; set; }
            public string hdfc_do_neighbours_neighbouring_shops_or_office_know_the_customer { get; set; }
            public string hdfc_name_and_address_neighbours { get; set; }
            public string hdfc_name_of_agency_br_staff_conducting_cpv { get; set; }
            public string hdfc_area_of_premise_establishment { get; set; }
            public string hdfc_agency_employee_code { get; set; }
            public string hdfc_remarks { get; set; }
            public string hdfc_date_and_time_of_cpv_performed { get; set; }
            public string hdfc_date_of_visit { get; set; }
            public string hdfc_time_of_visit { get; set; }
            public string hdfc_reason_cpv { get; set; }
            public string hdfc_address_updation { get; set; }
            public string hdfc_additional_address { get; set; }
            public string hdfc_additional_information { get; set; }
            public string hdfc_verifiers_remarks { get; set; }
            public string hdfc_case_positive_negative { get; set; }
            public string hdfc_case_open_close { get; set; }
            public string hdfc_supervisor_remarks { get; set; }
        }

        [WebMethod]
        public string SaveData(string myjson) //save data to database
        {
            string mesg = "Completed";

            try
            {
                SqlConnection sqlConW = new SqlConnection(ConfigurationManager.ConnectionStrings["WestConnectionString"].ConnectionString);




                int result = 0;

                string splittedString = "[" + myjson.Split('[')[1].Split(']')[0] + "]";
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(splittedString, (typeof(DataTable)));



                dt = OrderingdtColumns(dt);

                SqlCommand cmd9 = new SqlCommand("PMS_APPLICATION_Res_RV_BV_Archieve", sqlConW);
                cmd9.CommandType = CommandType.StoredProcedure;
                cmd9.Parameters.AddWithValue("@ApplicationType_RV_BV", dt);
                sqlConW.Open();
                cmd9.ExecuteNonQuery();
                sqlConW.Close();

                List<string> SQLconn = new List<string>();
                SQLconn.Add("WestConnectionString");
                SQLconn.Add("EastConnectionString");
                SQLconn.Add("SouthConnectionString");
                SQLconn.Add("NorthConnectionString");
                SQLconn.Add("MumbaiConnectionString");

                foreach (var actualconn in SQLconn)
                {

                    SqlCommand cmd4 = new SqlCommand("PMS_APPLICATION_Res_RV_BV");
                    SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[actualconn].ConnectionString);
                    cmd4.Connection = sqlconnection;
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@ApplicationType_RV_BV", dt);
                    sqlconnection.Open();
                    result = cmd4.ExecuteNonQuery();
                    sqlconnection.Close();
                }


               

                // bvrv  table another table insert and delete records from bvrv table

                if (result > 0)
                {
                    foreach (var actualconn in SQLconn)
                    {

                        SqlCommand cmd11 = new SqlCommand("USP_InsertdatainCKYC");
                        SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[actualconn].ConnectionString);
                        cmd11.Connection = sqlconnection;
                        cmd11.CommandType = CommandType.StoredProcedure;
                        sqlconnection.Open();
                        cmd11.ExecuteNonQuery();
                        sqlconnection.Close();
                    }

                }


            }
            catch (Exception ex)
            {
                ErrorLogging(ex, myjson);

                mesg = "Fail";
            }

            return mesg ;
        }
        public static void ErrorLogging(Exception ex, string json)
        {
            string strPath = HttpContext.Current.Server.MapPath("~/Log.txt");
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("My JSON: " + json);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        private DataTable OrderingdtColumns(DataTable dataTable) // rv 94
        {


            SqlConnection sqlConW = new SqlConnection(ConfigurationManager.ConnectionStrings["WestConnectionString"].ConnectionString);


            SqlCommand cmd4 = new SqlCommand("Get_Json_RV_BV_Columns", sqlConW);
            cmd4.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd4);
            DataTable dtcolumns = new DataTable();
            adp.Fill(dtcolumns);
            if (dtcolumns != null && dtcolumns.Rows.Count > 0) // 100
            {

                int i = 0;
                foreach (DataRow row in dtcolumns.Rows)
                {
                    // if column not exists add it and set its order no.
                    if (!dataTable.Columns.Contains(Convert.ToString(row["Column_Name"])))
                    {
                        dataTable.Columns.Add(Convert.ToString(row["Column_Name"]));
                        dataTable.AcceptChanges();
                    }
                    dataTable.Columns[Convert.ToString(row["Column_Name"])].SetOrdinal(i);
                    i++;
                }
                dataTable.AcceptChanges();
            }
            return dataTable;
        }
    }
}

