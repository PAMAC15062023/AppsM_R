using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Text;
using OfficeOpenXml;
using Ionic.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Text.RegularExpressions;

namespace RESDOT
{

    public partial class mysample : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            hdnIspostback.Value = "No";
            //  bool isPageRefreshed = false;
            if (!IsPostBack)
            {


                //lblMessage.Text = "auto page load  is happening";
                //ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                //Session["SessionId"] = ViewState["ViewStateId"].ToString();
                //  Session["sesfieldlist"] = "1";
                Session["iterations"] = 0;
                Session["sesfieldlist"] = "1";
                string menuname = Request.QueryString["menuname"];
                hdnMenuId.Value = Convert.ToString(Request.QueryString["menuid"]);
                // select f1,f2 from tbl_meuninfo where menu_id= hdnme
                getotherdetailsfromMenu();


                int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                string userid = Session["UserId"].ToString();
                int roleid = Convert.ToInt32(Session["Roleid"].ToString());
                //  if ((roleid == 3 || roleid == 2) && hdnMenuId.Value != "192")
                if ((roleid == 3) && hdnMenuId.Value != "192")
                {
                    getgridview_search("1");
                }
                string caseentry = Request.QueryString["caseentry"];

                hdnIspostback.Value = "Yes";
            }

            string caseentry1 = Request.QueryString["caseentry"];



            if (caseentry1 == "Y")
            {
                topfields_4(5);
                return;
            }
            int sesit = Convert.ToInt32(Session["iterations"]);

            if (sesit == 1)
            {

                string hr = Session["headrow"].ToString();
                string svl = Session["selval"].ToString();
                topfields_3(3, hr, svl);

            }
            if (sesit == 0)
            {

                topfields(2);

            }
            if (sesit == 2)
            {
                topfields(3);
            }
            if (sesit == 8)
            {
                AddNewEvent();
            }

            if (sesit == 9)
            {
                topfields_5(Convert.ToInt32(Session["fieldshowin"]), Convert.ToString(Session["selval"]), Convert.ToString(Session["headrow"]));
            }
        }


        protected void topfields(int field_show_in)
        {
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            int activityid = Convert.ToInt32(Session["ActivityId"].ToString());
            //string caseentry1 = Request.QueryString["caseentry"];

            //PlaceholderControls.Controls.Add

            ControlM.Controls.Add(new LiteralControl("<div class='box'>" +
                    "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
                    "</div>" + "</div>"));



            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            DataTable dt = new DataTable();


            //if (field_show_in == 9)
            //{


            //    string Values = string.Empty;
            //    string both = string.Empty;
            //    int ClientId = 0;
            //    int ProductId = 0;
            //    int VeriftypeId = 0;

            //    foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            //    {
            //        ID += ddl.ID.Substring(3) + ",";
            //        Values += "'" + ddl.SelectedValue + "'" + ",";
            //        both += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
            //    }

            //    List<string> frontendvaluelist = new List<string>();
            //    frontendvaluelist = both.Split(',').ToList();

            //    for (int k = 0; k < frontendvaluelist.Count - 1; k++)
            //    {
            //        List<string> value = frontendvaluelist[k].Split('=').ToList();

            //        if (value[0] == "client_id")
            //        {
            //            ClientId = Convert.ToInt32(value[1].Replace("'", ""));
            //        }
            //        if (value[0] == "product_id")
            //        {
            //            ProductId = Convert.ToInt32(value[1].Replace("'", ""));
            //        }
            //        if (value[0] == "veriftype_id")
            //        {
            //            VeriftypeId = Convert.ToInt32(value[1].Replace("'", ""));
            //        }
            //    }

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = sqlCon;
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.CommandText = "SP_get_caseentrydata";
            //    cmd.CommandTimeout = 0;
            //    cmd.Parameters.AddWithValue("@activity_id", activityid);
            //    cmd.Parameters.AddWithValue("@client_id", ClientId);
            //    cmd.Parameters.AddWithValue("@product_id", ProductId);
            //    cmd.Parameters.AddWithValue("@veriftype_id", VeriftypeId);
            //    cmd.Parameters.AddWithValue("@menuid", menuid);
            //    cmd.Parameters.AddWithValue("@field_show_in", 2);
            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);

            //}
            //else
            //{ 

            //if (field_show_in == 5)
            //{

            //    string Values = string.Empty;
            //    string both = string.Empty;
            //    int ClientId = 0;
            //    int ProductId = 0;
            //    int VeriftypeId = 0;

            //    foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            //    {
            //        ID += ddl.ID.Substring(3) + ",";
            //        Values += "'" + ddl.SelectedValue + "'" + ",";
            //        both += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
            //    }

            //    List<string> frontendvaluelist = new List<string>();
            //    frontendvaluelist = both.Split(',').ToList();

            //    for (int k = 0; k < frontendvaluelist.Count - 1; k++)
            //    {
            //        List<string> value = frontendvaluelist[k].Split('=').ToList();

            //        if (value[0] == "client_id")
            //        {
            //            ClientId = Convert.ToInt32(value[1].Replace("'", ""));
            //        }
            //        if (value[0] == "product_id")
            //        {
            //            ProductId = Convert.ToInt32(value[1].Replace("'", ""));
            //        }
            //        if (value[0] == "veriftype_id")
            //        {
            //            VeriftypeId = Convert.ToInt32(value[1].Replace("'", ""));
            //        }
            //    }

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = sqlCon;
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.CommandText = "SP_get_template_for_dataentry_1";
            //    cmd.CommandTimeout = 0;
            //    cmd.Parameters.AddWithValue("@activity_id", activityid);
            //    cmd.Parameters.AddWithValue("@client_id", ClientId);
            //    cmd.Parameters.AddWithValue("@product_id", ProductId);
            //    cmd.Parameters.AddWithValue("@veriftype_id", VeriftypeId);

            //    SqlDataAdapter sda = new SqlDataAdapter();
            //    sda.SelectCommand = cmd;
            //    sda.Fill(dt);
            //}
            //else
            //{
            FieldData fielddata = new FieldData();

            dt = fielddata.GetFieldData(menuid, activityid, field_show_in);
            //}
            //}
            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            String postback = "";
            string validation_req = "";
            string dependentval = "";
            string dependentfield = "";
            string dependentcheckfield = "";
            string WhereIfAny = "";
            string where = "";
            int tno = 0;
            string fieldval = "";

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int reccnt = 0;
                    PlaceholderControls.Controls.Add(new LiteralControl("<tr align='left'>")); //change on 11/03/2024
                    foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                        reccnt = reccnt + 1;
                        if (reccnt % 2 == 0)    //> 1
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr align='left'>"));
                        }

                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");

                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = dr["validation_req"].ToString();


                        postback = dr["Postback"].ToString();
                        dependentval = dr["dependent"].ToString();
                        dependentfield = dr["dependent_field"].ToString();
                        dependentcheckfield = dr["dependent_checkfield"].ToString();


                        WhereIfAny = dr["WhereIfAny"].ToString();

                        DataTable dt1 = new DataTable();

                        if (field_show_in == 3)
                        {

                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.Connection = sqlCon;
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.CommandText = "sp_getdataforMasters";
                            cmd1.CommandTimeout = 0;
                            cmd1.Parameters.AddWithValue("@menuid", menuid);
                            cmd1.Parameters.AddWithValue("@wherefield", Convert.ToString(ViewState["headerRowText"]));
                            cmd1.Parameters.AddWithValue("@wherefieldvalue", Convert.ToString(ViewState["selval"]));

                            SqlDataAdapter sda1 = new SqlDataAdapter();
                            sda1.SelectCommand = cmd1;
                            sda1.Fill(dt1);
                        }


                        {
                            if (inputtype == "INPUTBOX")
                            {


                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;

                                if (field_show_in != 3)
                                {
                                    fieldval = fieldidT.Text;
                                }
                                else
                                {
                                    fieldidT.Text = dt1.Rows[0][fieldName].ToString();// dr[fieldName].ToString();
                                }


                                //string fldt = fieldidT.ID;

                                //fieldval = fieldidT.Text;

                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldval = fieldidT.Text;
                                fieldidT.Attributes.Add("runat", "server");

                                //   fieldidT.Attributes.Add("onfocusout", "__doPostBack('','');");
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + fieldidT.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = fieldidT.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }

                                tno = tno + 1;
                            }

                            if (inputtype == "SELECT")
                            {
                                if (fieldName == "zone_id" || fieldName == "centre_id" || fieldName == "subcentre_id")
                                {
                                    if (hdnIspostback.Value == "Yes")
                                    {
                                        lblzonenew.Visible = true;
                                        ddAreas.Visible = true;
                                        Binddata("tbl_mst_cluster", ddAreas, fieldName, "ZONE", "ALL");

                                        tdzone.Visible = true;
                                    }
                                    lblcenterNew.Visible = true;
                                    ddlCenterNew.Visible = true;
                                    lblsubcenternew.Visible = true;
                                    ddlsubcenternew.Visible = true;

                                    tdcenter.Visible = true;
                                    tdsubcenter.Visible = true;
                                }
                                else
                                {
                                    if (fieldName == "fe-id") { fieldName = "empid"; }
                                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                    PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                    DropDownList ddArea = new DropDownList();
                                    ddArea.ID = "ddl" + fieldName;

                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                    PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                    ddArea.Attributes.Add("runat", "server");
                                    ddArea.Attributes.Add("AutoPostBack", "true"); //this is the problem
                                                                                   //      ddArea.Attributes.Add("onblur", "__doPostBack('','');");
                                    if (postback == "Y")
                                    //  if (fieldName=="zone_id"  || fieldName=="centre_id")
                                    {
                                        //  ddArea.Attributes.Add("onblur", "__doPostBack('','');");
                                        ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
                                        ddArea.SelectedIndexChanged += new System.EventHandler(ddArea_SelectedIndexChanged);

                                    }

                                    ddArea.Attributes.Add("SelectedIndex", "0");
                                    if (WhereIfAny == "" || WhereIfAny == null)
                                    {
                                        where = "ALL";
                                    }
                                    else
                                    {
                                        where = WhereIfAny;
                                    }
                                    if (validation_req == "1")
                                    {
                                        RequiredFieldValidator req = new RequiredFieldValidator();
                                        req.ID = "rfvDynamic" + ddArea.ID;
                                        req.Font.Bold = true;
                                        req.SetFocusOnError = true;
                                        req.ErrorMessage = "Required";
                                        req.ControlToValidate = ddArea.ID;
                                        PlaceholderControls.Controls.Add(req);

                                    }
                                    if (dependentval == "Y")
                                    //  if (fieldName == "centre_id" || fieldName == "subcentre_id")
                                    {  // dependent on field = "zone_id"
                                       // check with field = "centre_cluster_id"
                                        ddArea.Attributes.Add("fldnam", fieldName);
                                        ddArea.Attributes.Add("tabnam", tblName);
                                        ddArea.Attributes.Add("labnam", labelnames);

                                        ddArea.Attributes.Add("dependency", dependentval);
                                        ddArea.Attributes.Add("depfield", dependentfield);
                                        ddArea.Attributes.Add("checkfld", dependentcheckfield);


                                    }
                                    else
                                    {
                                        Binddata(tblName, ddArea, fieldName, labelnames, where);
                                    }

                                    PlaceholderControls.Controls.Add(ddArea);
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                }
                            }
                            if (inputtype == "LISTBOX")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                ListBox lstArea = new ListBox();
                                lstArea.ID = "lst" + fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(lstArea);


                                lstArea.SelectionMode = ListSelectionMode.Multiple;


                                Binddata1(tblName, lstArea, fieldName, labelnames);

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }



                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;
                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(fieldidT);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;
                                PlaceholderControls.Controls.Add(textArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font_size=10>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                FileUpload fileArea = new FileUpload();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                fileArea.ID = "fil" + fieldName;
                                PlaceholderControls.Controls.Add(fileArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }

                            if (inputtype == "BUTTON")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                                Button button = new Button();
                                button.ID = "btn" + fieldName;
                                button.Text = labelnames;
                                button.BackColor = Color.Blue;
                                button.ForeColor = Color.White; //add on 26/12/23
                                if (fieldName == "SampleDownload")
                                {
                                    button.Visible = false;
                                }



                                button.Click += new EventHandler(ButtonClickCommonEvent);


                                PlaceholderControls.Controls.Add(button); // here

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                            }

                        }
                    }


                }

                //string fieldlist = Session["sesfieldlist"].ToString();
                //getgridview_search(fieldlist);

            }
        }

        static bool isNumeric(string value)
        {

            value = value.Replace("'", "");


            bool isNumber = Regex.IsMatch(value, @"^\d+$");

            if (isNumber == true)
            {
                return true;
            }
            else
            {
                return false;
            }

            //if (Regex.IsMatch(value, @"^-?[1-9][0-9,\.]+$"))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        protected void topfields_4(int field_show_in)
        {
            int ClientId = 0;
            int Product_Id = 0;
            int VeriftypeId = 0;
            int ZoneId = 0;
            int caseforid = 0;
            int centreid = 0;
            int subcentreid = 0;
            string clientidtext = "";
            string Productidtext = "";
            string Veriftypeidtext = "";
            string ZoneIdtext = "";
            string caseforidtext = "";
            string centreidtext = "";
            string subcentreidtext = "";

            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);

            string updatevalue = Request.QueryString["updatevalue"];

            List<string> frontendvaluelist = new List<string>();
            frontendvaluelist = updatevalue.Split(',').ToList();

            for (int k = 0; k < frontendvaluelist.Count - 1; k++)
            {
                List<string> value = frontendvaluelist[k].Split('=').ToList();


                if (value[0] == "client_id")
                {
                    if (isNumeric(value[1]))
                    {
                        ClientId = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["ClientId"] = ClientId;
                    }
                    else
                    {
                        clientidtext = (value[1].Replace("'", ""));
                    }
                }
                if (value[0] == "product_id")
                {
                    if (isNumeric(value[1]))
                    {
                        Product_Id = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["ProductId"] = Product_Id;
                    }
                    else
                    {
                        Productidtext = (value[1].Replace("'", ""));
                    }
                }
                if (value[0] == "veriftype_id")
                {
                    if (isNumeric(value[1]))
                    {
                        VeriftypeId = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["VeriftypeId"] = VeriftypeId;
                    }
                    else
                    {
                        Veriftypeidtext = (value[1].Replace("'", ""));
                    }
                }

                if (value[0] == "zone_id")
                {
                    if (isNumeric(value[1]))
                    {
                        ZoneId = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["zoneid"] = ZoneId;
                    }
                    else
                    {
                        ZoneIdtext = (value[1].Replace("'", ""));
                    }
                }

                if (value[0] == "casefor_id")
                {
                    if (isNumeric(value[1]))
                    {
                        caseforid = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["caseforid"] = caseforid;
                    }
                    else
                    {
                        caseforidtext = (value[1].Replace("'", ""));
                    }
                }

                if (value[0] == "centre_id")
                {
                    if (isNumeric(value[1]))
                    {
                        centreid = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["centreid"] = centreid;
                    }
                    else
                    {
                        centreidtext = (value[1].Replace("'", ""));
                    }
                }

                if (value[0] == "subcentre_id")
                {
                    if (isNumeric(value[1]))
                    {
                        subcentreid = Convert.ToInt32(value[1].Replace("'", ""));
                        ViewState["subcentreid"] = subcentreid;
                    }
                    else
                    {
                        subcentreidtext = (value[1].Replace("'", ""));
                    }
                }

            }

            string menuname = Request.QueryString["menuname"];
            menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            //   int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
            int activityid = Convert.ToInt32(Session["ActivityId"].ToString());

            //PlaceholderControls.Controls.Add
            PlaceholderControls.Controls.Add(new LiteralControl("<div class='box'>" +
                    "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
                    "</div>" + "</div>"));
            string Values = string.Empty;
            string both = string.Empty;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            DataTable dt = new DataTable();



            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_get_caseentrydata";
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@activity_id", activityid);
            cmd.Parameters.AddWithValue("@client_id", ClientId);
            cmd.Parameters.AddWithValue("@product_id", Product_Id);
            cmd.Parameters.AddWithValue("@veriftype_id", VeriftypeId);
            cmd.Parameters.AddWithValue("@menuid", menuid);
            cmd.Parameters.AddWithValue("@field_show_in", 2);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);


            //   return;

            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            String postback = "";
            string validation_req = "";
            string dependentval = "";
            string dependentfield = "";
            string dependentcheckfield = "";
            string WhereIfAny = "";
            string where = "";
            int tno = 0;
            string fieldval = "";
            string fieldoptions = "";
            string global_template_id = "";
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int reccnt = 0;
                    PlaceholderControls.Controls.Add(new LiteralControl("<tr align='left'>"));
                    // adding values from previous screen
                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "zone"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + ZoneIdtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "center"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + centreidtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "subcenter"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + subcentreidtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "caseforid"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + caseforidtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "Client"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + clientidtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "Product"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + Productidtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "VerificationType"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + Veriftypeidtext.ToUpper()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + "TemplateID"));
                    PlaceholderControls.Controls.Add(new LiteralControl("<td  style='width: 100px'>" + dt.Rows[5]["global_template_id"].ToString()));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));



                    // adding values from previous screen

                    foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                        reccnt = reccnt + 1;
                        if (reccnt % 2 == 0)    //> 1
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr align='left'>"));
                        }

                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");

                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = dr["validation_req"].ToString();
                        fieldoptions = dr["field_options"].ToString();
                        global_template_id = dr["global_template_id"].ToString();
                        ViewState["global_template_id"] = global_template_id;

                        //if (field_show_in != 5  )
                        //{
                        //    postback = dr["Postback"].ToString();
                        //    dependentval = dr["dependent"].ToString();
                        //    dependentfield = dr["dependent_field"].ToString();
                        //    dependentcheckfield = dr["dependent_checkfield"].ToString();

                        //}

                        WhereIfAny = dr["WhereIfAny"].ToString();

                        {
                            if (inputtype == "INPUTBOX")
                            {


                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;

                                string fldt = fieldidT.ID;

                                fieldval = fieldidT.Text;

                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldval = fieldidT.Text;
                                fieldidT.Attributes.Add("runat", "server");

                                //   fieldidT.Attributes.Add("onfocusout", "__doPostBack('','');");
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + fieldidT.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = fieldidT.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }

                                tno = tno + 1;
                            }
                            if (inputtype == "SELECT")
                            {

                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;


                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(ddArea);
                                ddArea.Attributes.Add("runat", "server");
                                ddArea.Attributes.Add("AutoPostBack", "true");

                                if (postback == "Y")
                                {
                                    ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
                                    ddArea.SelectedIndexChanged += new System.EventHandler(ddArea_SelectedIndexChanged);
                                }

                                ddArea.Attributes.Add("SelectedIndex", "0");

                                if (WhereIfAny == "" || WhereIfAny == null)
                                {
                                    where = "ALL";
                                }
                                else
                                {
                                    where = WhereIfAny;
                                }

                                if (field_show_in == 5 || field_show_in == 4)
                                {
                                    if (dr["field_options"].ToString() != null && dr["field_options"].ToString() != "")
                                    {

                                        fieldoptions = dr["field_options"].ToString();

                                        List<string> fieldoptionslist = new List<string>();
                                        fieldoptionslist = fieldoptions.Split(',').ToList();

                                        DataTable tempTable = new DataTable();
                                        tempTable.Columns.Add("Drop");

                                        for (int k = 0; k < fieldoptionslist.Count; k++)
                                        {
                                            // string d = fieldoptionslist[k];
                                            tempTable.Rows.Add(fieldoptionslist[k]);
                                        }

                                        //    foreach (DataRow dtrow in fieldoptionslist)
                                        //{
                                        //    tempTable.Rows.Add(dr);
                                        //}

                                        // split the list 
                                        // ddArea.select
                                        // send the list into datatable dt


                                        ddArea.DataTextField = "Drop";
                                        ddArea.DataValueField = "Drop";
                                        ddArea.DataSource = tempTable;
                                        ddArea.DataBind();
                                        ddArea.Items.Insert(0, "--Select--");
                                        ddArea.SelectedIndex = 0;
                                        //ddArea.SelectedValue = fieldval;
                                    }
                                    else
                                    {
                                        Binddata(tblName, ddArea, fieldName, labelnames, where);
                                        ddArea.SelectedValue = fieldval;
                                        PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                    }
                                }
                                else
                                {
                                    Binddata(tblName, ddArea, fieldName, labelnames, where);
                                    ddArea.SelectedValue = fieldval;
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                }

                            }
                            if (inputtype == "LISTBOX")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                ListBox lstArea = new ListBox();
                                lstArea.ID = "lst" + fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(lstArea);


                                lstArea.SelectionMode = ListSelectionMode.Multiple;


                                Binddata1(tblName, lstArea, fieldName, labelnames);

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }



                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;
                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(fieldidT);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;
                                PlaceholderControls.Controls.Add(textArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font_size=10>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                FileUpload fileArea = new FileUpload();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                fileArea.ID = "fil" + fieldName;
                                PlaceholderControls.Controls.Add(fileArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }

                            if (inputtype == "BUTTON")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                                Button button = new Button();
                                button.ID = "btn" + fieldName;
                                button.Text = labelnames;
                                button.BackColor = Color.Blue;
                                button.ForeColor = Color.White; //add on 26/12/23
                                if (fieldName == "SampleDownload")
                                {
                                    button.Visible = false;
                                }



                                button.Click += new EventHandler(ButtonClickCommonEvent);


                                PlaceholderControls.Controls.Add(button); // here

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                            }

                        }
                    }
                }

                //string fieldlist = Session["sesfieldlist"].ToString();
                //getgridview_search(fieldlist);

            }
        }

        protected void topfields_5(int field_show_in, string case_id, string headerrowtext)
        {
            int ClientId = 0;
            int Product_Id = 0;
            int VeriftypeId = 0;
            int ZoneId = 0;
            int caseforid = 0;
            int centreid = 0;
            int subcentreid = 0;
            string clientidtext = "";
            string Productidtext = "";
            string Veriftypeidtext = "";
            string ZoneIdtext = "";
            string caseforidtext = "";
            string centreidtext = "";
            string subcentreidtext = "";

            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            Session["headrow"] = headerrowtext;
            Session["selval"] = case_id;
            Session["fieldshowin"] = field_show_in;

            string menuname = Request.QueryString["menuname"];
            menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            //   int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
            int activityid = Convert.ToInt32(Session["ActivityId"].ToString());

            //PlaceholderControls.Controls.Add

            //PlaceholderControls.Controls.Add(new LiteralControl("<div class='box'>" +  //comment on 22/02/2025
            //        "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
            //        "</div>" + "</div>"));

            string Values = string.Empty;
            string both = string.Empty;

            //SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();



            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.CommandText = "SP_get_template_for_dataentry";
            //cmd.CommandTimeout = 0;
            //cmd.Parameters.AddWithValue("@caseid", case_id);

            cmd.CommandText = "SP_get_caseentrydata_1";
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@caseId", case_id);
            cmd.Parameters.AddWithValue("@menuid", menuid);
            cmd.Parameters.AddWithValue("@field_show_in", 3);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);

            if (field_show_in == 5)
            {

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = sqlCon;
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.CommandText = "sp_getdatafromtblcases";
                cmd1.CommandTimeout = 0;
                cmd1.Parameters.AddWithValue("@caseId", case_id);
                cmd1.Parameters.AddWithValue("@menuid", menuid);
                cmd1.Parameters.AddWithValue("@field_show_in", 3);
              

                
                SqlDataAdapter sda1 = new SqlDataAdapter();
                sda1.SelectCommand = cmd1;
                sda1.Fill(dt1);
            }

            // send 3 variableas as above and call new sp 
            // dt1 = the above
            //

            //   return;

            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            String postback = "";
            string validation_req = "";
            string dependentval = "";
            string dependentfield = "";
            string dependentcheckfield = "";
            string WhereIfAny = "";
            string where = "";
            int tno = 0;
            string fieldval = "";
            string fieldoptions = "";
            string global_template_id = "";
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    int reccnt = 0;
                    PlaceholderControls.Controls.Add(new LiteralControl("<table >")); // style='width: 500px'  add on 22/02/2025


                    PlaceholderControls.Controls.Add(new LiteralControl("<tr align='left'>"));
                    // adding values from previous screen

                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 150px'>" + "Case ID "  ));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td><td  style='width: 100px'>" + case_id));
                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                  
                    PlaceholderControls.Controls.Add(new LiteralControl("</tr>")); //add on 21/02/2025
                    
                  

                    foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                        reccnt = reccnt + 1;
                      //  if (reccnt % 2 == 0)    //> 1
                      //  {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr>"));
                          
                         //   PlaceholderControls.Controls.Add(new LiteralControl("<tr align='left'>")); //change on 21/02/2025
                     //   }

                        //if (reccnt == 4)
                        //{
                        //    return;
                        //}

                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");

                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = dr["validation_req"].ToString();
                        fieldoptions = dr["field_options"].ToString();
                    
                        WhereIfAny = dr["WhereIfAny"].ToString();

                       // PlaceholderControls.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;")); //add on 21/02/2025
                        {
                            if (inputtype == "INPUTBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames + "&nbsp;&nbsp;&nbsp;"));
                            
                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;

                                string fldt = fieldidT.ID;
                                if (field_show_in != 5)
                                {
                                    fieldval = fieldidT.Text;
                                }
                                else
                                {
                          
                                    fieldidT.Text = (dt1.Rows[0][fieldName].ToString() ?? "") ;// dr[fieldName].ToString();
                                }

                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldval = fieldidT.Text;
                                fieldidT.Attributes.Add("runat", "server");

                                //   fieldidT.Attributes.Add("onfocusout", "__doPostBack('','');");
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                //PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025

                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + fieldidT.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = fieldidT.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }

                                tno = tno + 1;
                           
                            }
                            if (inputtype == "SELECT")
                            {

                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;


                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;")); //add on 21/02/2025
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(ddArea);
                                ddArea.Attributes.Add("runat", "server");
                                ddArea.Attributes.Add("AutoPostBack", "true");

                                if (postback == "Y")
                                {
                                    ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
                                    ddArea.SelectedIndexChanged += new System.EventHandler(ddArea_SelectedIndexChanged);
                                }

                                ddArea.Attributes.Add("SelectedIndex", "0");

                                if (WhereIfAny == "" || WhereIfAny == null)
                                {
                                    where = "ALL";
                                }
                                else
                                {
                                    where = WhereIfAny;
                                }

                                if (field_show_in == 5 || field_show_in == 4)
                                {
                                    if (dr["field_options"].ToString() != null && dr["field_options"].ToString() != "")
                                    {

                                        fieldoptions = dr["field_options"].ToString();

                                        List<string> fieldoptionslist = new List<string>();
                                        fieldoptionslist = fieldoptions.Split(',').ToList();

                                        DataTable tempTable = new DataTable();
                                        tempTable.Columns.Add("Drop");

                                        for (int k = 0; k < fieldoptionslist.Count; k++)
                                        {
                                            // string d = fieldoptionslist[k];
                                            tempTable.Rows.Add(fieldoptionslist[k]);
                                        }

                                        //    foreach (DataRow dtrow in fieldoptionslist)
                                        //{
                                        //    tempTable.Rows.Add(dr);
                                        //}

                                        // split the list 
                                        // ddArea.select
                                        // send the list into datatable dt


                                        ddArea.DataTextField = "Drop";
                                        ddArea.DataValueField = "Drop";
                                        ddArea.DataSource = tempTable;
                                        ddArea.DataBind();
                                        ddArea.Items.Insert(0, "--Select--");
                                        ddArea.SelectedIndex = 0;
                                        //ddArea.SelectedValue = fieldval;

                                        if (field_show_in != 5)
                                        {
                                            fieldval = ddArea.SelectedValue;
                                        }
                                        else
                                        {
                                            ddArea.SelectedValue = dt1.Rows[0][fieldName].ToString();// dr[fieldName].ToString();
                                        }
                                      //  PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                                    }
                                    else
                                    {
                                        Binddata(tblName, ddArea, fieldName, labelnames, where);
                                        ddArea.SelectedValue = fieldval;
                                        PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                       // PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                                    }
                                }
                                else
                                {
                                    Binddata(tblName, ddArea, fieldName, labelnames, where);
                                    ddArea.SelectedValue = fieldval;


                                    fieldval = ddArea.SelectedValue;






                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                }

                            }
                            if (inputtype == "LISTBOX")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                ListBox lstArea = new ListBox();
                                lstArea.ID = "lst" + fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(lstArea);


                                lstArea.SelectionMode = ListSelectionMode.Multiple;


                                Binddata1(tblName, lstArea, fieldName, labelnames);

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }



                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;
                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(fieldidT);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp")); //add on 21/02/2025
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;

                                if (field_show_in != 5)
                                {
                                    fieldval = textArea.Text;
                                }
                                else
                                {
                                    textArea.Text = dt1.Rows[0][fieldName].ToString();// dr[fieldName].ToString();
                                }


                                PlaceholderControls.Controls.Add(textArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                              //  PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                string fname = "";

                                if (dt1.Rows.Count > 0)
                                {
                                    fname = dt1.Rows[0][fieldName].ToString();// dr[fieldName].ToString();
                                }

                                if (fname == null || fname == "")
                                {

                                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font_size=10>"));
                                    PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                    PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                    FileUpload fileArea = new FileUpload();
                                    //  textArea.TextMode = TextBoxMode.MultiLine;
                                    fileArea.ID = "fil" + fieldName;
                                    PlaceholderControls.Controls.Add(fileArea);
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                }
                                else
                                {
                                    PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames));

                                    TextBox fieldidT = new TextBox();
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                    PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                    fieldidT.ID = "txt" + fieldName;

                                    PlaceholderControls.Controls.Add(fieldidT);
                                    fieldval = fieldidT.Text;
                                    fieldidT.Attributes.Add("runat", "server");

                                    //   fieldidT.Attributes.Add("onfocusout", "__doPostBack('','');");
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                    fieldidT.Text = dt1.Rows[0][fieldName].ToString();// dr[fieldName].ToString();
                                }
                            }

                            if (inputtype == "BUTTON")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("</td><td>"));
                                Button button = new Button();
                                button.ID = "btn" + fieldName;
                                button.Text = labelnames;
                                button.BackColor = Color.Blue;
                                button.ForeColor = Color.White; //add on 26/12/23
                                if (fieldName == "SampleDownload")
                                {
                                    button.Visible = false;
                                }



                                button.Click += new EventHandler(ButtonClickCommonEvent);


                                PlaceholderControls.Controls.Add(button); // here

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                               // PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                            }

                        }
                        
                    }
                    //return;

                }

                //PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("Verifier Remarks"));
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"+"&nbsp;&nbsp;&nbsp;"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                //TextBox textArea2 = new TextBox();
                //textArea2.TextMode = TextBoxMode.MultiLine;
                //textArea2.ID = "txA" + "field61";
                //PlaceholderControls.Controls.Add(textArea2);
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025

                //PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("Supervisor Remarks"));
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>" + "&nbsp;&nbsp;&nbsp;"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                //TextBox textArea3 = new TextBox();
                //textArea3.TextMode = TextBoxMode.MultiLine;
                //textArea3.ID = "txA" + "supervisor_remarks";
                //PlaceholderControls.Controls.Add(textArea3);
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                //PlaceholderControls.Controls.Add(new LiteralControl("</tr>"));


                //PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));

                //PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("PMT Add3"));
                //DropDownList ddArea2 = new DropDownList();
                //ddArea2.ID = "ddl" + "pmt_add3";
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>" + "&nbsp;&nbsp;&nbsp;"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                //PlaceholderControls.Controls.Add(ddArea2);
                //ddArea2.Attributes.Add("runat", "server");
                //ddArea2.Attributes.Add("AutoPostBack", "true");
                //ddArea2.Attributes.Add("SelectedIndex", "0");
                //Binddata("tbl_mst_PMT_Add", ddArea2, "PMT_ADD3", "PMT_ADD3", "ALL");
                //fieldval = ddArea2.SelectedValue;
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025

                //PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("Case Open / Close"));
                //DropDownList ddArea3 = new DropDownList();
                //ddArea3.ID = "ddl" + "case_status";
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>" + "&nbsp;&nbsp;&nbsp;"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                //PlaceholderControls.Controls.Add(ddArea3);
                //ddArea3.Attributes.Add("runat", "server");
                //ddArea3.Attributes.Add("AutoPostBack", "true");
                //ddArea3.Attributes.Add("SelectedIndex", "0");
                //Binddata("tbl_mst_caseStatus", ddArea3, "case_status", "case_status", "ALL");
                //fieldval = ddArea3.SelectedValue;
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                //PlaceholderControls.Controls.Add(new LiteralControl("</tr>"));


                //PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("Supervisor Status"));
                //DropDownList ddArea4 = new DropDownList();
                //ddArea4.ID = "ddl" + "field35";
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>" + "&nbsp;&nbsp;&nbsp;"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                //PlaceholderControls.Controls.Add(ddArea4);
                //ddArea4.Attributes.Add("runat", "server");
                //ddArea4.Attributes.Add("AutoPostBack", "true");
                //ddArea4.Attributes.Add("SelectedIndex", "0");
                //Binddata("tbl_mst_SupervisorStatus", ddArea4, "ID", "Supervisor_Status", "ALL");
                //fieldval = ddArea4.SelectedValue;
                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                //PlaceholderControls.Controls.Add(new LiteralControl("<br/>")); //add on 21/02/2025
                //PlaceholderControls.Controls.Add(new LiteralControl("</tr>"));


                // PlaceholderControls.Controls.Add(new LiteralControl("</table>")); //add on 22/02/2025

                //Session["iterations"] = 9;  //comment on 19/03/2025 by ramaki sir
                //Session["fieldshowin"] = 4; //comment on 19/03/2025 by ramaki sir

                //string fieldlist = Session["sesfieldlist"].ToString();
                //getgridview_search(fieldlist);

            }
        }

        protected void topfields_3(int field_show_in, string headerRowText, string selval) // to bestring headerRowText written
        {
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
            Session["headrow"] = headerRowText;
            Session["selval"] = selval;
            string postback = "";


            PlaceholderControls.Controls.Add(new LiteralControl("<div class='box'>"));
            //+
            //        "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
            //        "</div>" + "</div>"));


            DataTable dt = new DataTable();

            if (field_show_in == 4 || field_show_in == 5) // this is to get dynamic form
            {
                //int roleid = Convert.ToInt32(Session["Roleid"]);
                //Session["sesfieldlist"] = fieldlist;
                //string fields1 = Session["sesfieldlist"].ToString();
                //string userid = Session["UserId"].ToString();


                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                // call here the sp 
                if (sqlCon.State == ConnectionState.Closed)
                {
                    //string menuname = Request.QueryString["menuname"];
                    //int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    //int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);



                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (field_show_in == 4)
                    {
                        //       PlaceholderControls.Controls.Add(new LiteralControl("<div class='box'>" +
                        //"<div class='box-header with-border'>" + "<h2 class='box-title'>" + "CaseID " + selval + "<br>" +
                        //"</div>" + "</div>"));

                        cmd.CommandText = "SP_get_template_for_dataentry";
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@caseid", selval);

                    }
                    else
                    {
                        string Values = string.Empty;
                        string both = string.Empty;
                        int ClientId = 0;
                        int ProductId = 0;
                        int VeriftypeId = 0;

                        foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
                        {
                            ID += ddl.ID.Substring(3) + ",";
                            if (ddl.SelectedValue == "--Select--")
                            {
                                ddl.SelectedValue = "";
                            }
                            Values += "'" + ddl.SelectedValue + "'" + ",";
                            both += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
                        }

                        ClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
                        ProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
                        VeriftypeId = Convert.ToInt32(Request.QueryString["VeriftypeId"]);

                        List<string> frontendvaluelist = new List<string>();
                        frontendvaluelist = both.Split(',').ToList();

                        for (int k = 0; k < frontendvaluelist.Count - 1; k++)
                        {
                            List<string> value = frontendvaluelist[k].Split('=').ToList();

                            if (value[0] == "client_id")
                            {
                                ClientId = Convert.ToInt32(value[1].Replace("'", ""));
                            }
                            if (value[0] == "product_id")
                            {
                                ProductId = Convert.ToInt32(value[1].Replace("'", ""));
                            }
                            if (value[0] == "veriftype_id")
                            {
                                VeriftypeId = Convert.ToInt32(value[1].Replace("'", ""));
                            }
                        }

                        cmd.CommandText = "SP_get_template_for_dataentry_1";
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@activity_id", activityid);
                        cmd.Parameters.AddWithValue("@client_id", ClientId);
                        cmd.Parameters.AddWithValue("@product_id", ProductId);
                        cmd.Parameters.AddWithValue("@veriftype_id", VeriftypeId);
                    }


                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();
                    // DataTable dt = new DataTable();
                    sda.Fill(dt);
                }

            }

            else
            {
                FieldData fielddata = new FieldData();

                dt = fielddata.GetFieldData(menuid, activityid, field_show_in);
            }

            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            int tno = 0;
            string fieldval = "";
            int validation_req = 0;
            string WhereIfAny = "";
            string where = "";
            string fieldoptions = "";

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int reccnt = 1;
                    // PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));

                    foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                        reccnt = reccnt + 1;
                        if (reccnt % 2 == 0)    //> 1
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));
                        }

                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");

                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = Int32.Parse(dr["validation_req"].ToString());
                        WhereIfAny = dr["WhereIfAny"].ToString();


                        if (field_show_in != 5)
                        {
                            if (inputtype != "BUTTON")
                            {
                                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                                SqlCommand sqlCom = new SqlCommand();
                                sqlCom.Connection = sqlCon1;
                                sqlCom.CommandType = CommandType.StoredProcedure;
                                sqlCom.CommandText = "SP_geteditdata";
                                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                                SqlParameter menu = new SqlParameter();
                                menu.SqlDbType = SqlDbType.VarChar;
                                menu.Value = menuid;
                                menu.ParameterName = "@menuid";
                                sqlCom.Parameters.Add(menu);

                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = activityid;
                                activity.ParameterName = "@activityid";
                                sqlCom.Parameters.Add(activity);

                                SqlParameter fldname = new SqlParameter();
                                fldname.SqlDbType = SqlDbType.VarChar;
                                fldname.Value = fieldName;
                                fldname.ParameterName = "@fldname";
                                sqlCom.Parameters.Add(fldname);

                                SqlParameter headertext = new SqlParameter();
                                headertext.SqlDbType = SqlDbType.VarChar;
                                headertext.Value = headerRowText;
                                headertext.ParameterName = "@headerRowText";
                                sqlCom.Parameters.Add(headertext);

                                SqlParameter selev = new SqlParameter();
                                selev.SqlDbType = SqlDbType.VarChar;
                                selev.Value = selval;
                                selev.ParameterName = "@selval";
                                sqlCom.Parameters.Add(selev);

                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                if (ds != null && ds.Tables.Count > 0)
                                {
                                    fieldval = ds.Tables[0].Rows[0][fieldName].ToString();
                                    string str = "field" + reccnt;


                                    Session[str] = "txt" + fieldName + '-' + fieldval;

                                    string fl1 = Session[str].ToString();
                                }
                            }

                        }
                        {



                            if (inputtype == "INPUTBOX")
                            {
                                //labelnames = fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font-size='medium'>" + "<b>" + labelnames + "</b>"));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;
                                fieldval = fieldidT.Text;


                                // fieldidT.Text = fieldval;

                                string fldt = fieldidT.ID;


                                PlaceholderControls.Controls.Add(fieldidT);

                                fieldidT.Attributes.Add("runat", "server");
                                //   fieldidT.Attributes.Add("onfocusout", "__doPostBack('','');");
                                fieldval = fieldidT.Text;

                                if (validation_req == 1)
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + fieldidT.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = fieldidT.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }
                                if (fieldtype == "INT")
                                {
                                    fieldidT.Attributes.Add("onkeypress", "return isNumber(event);");


                                }
                                fieldidT.Attributes.Add("maxlength", maxlength);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                                tno = tno + 1;
                                
                            }

                            if (inputtype == "SELECT")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;


                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(ddArea);
                                ddArea.Attributes.Add("runat", "server");
                                ddArea.Attributes.Add("AutoPostBack", "true");

                                if (postback == "Y")
                                {
                                    ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
                                    ddArea.SelectedIndexChanged += new System.EventHandler(ddArea_SelectedIndexChanged);
                                }

                                ddArea.Attributes.Add("SelectedIndex", "0");

                                if (WhereIfAny == "" || WhereIfAny == null)
                                {
                                    where = "ALL";
                                }
                                else
                                {
                                    where = WhereIfAny;
                                }

                                if (field_show_in == 5 || field_show_in == 4)
                                {
                                    if (dr["field_options"].ToString() != null && dr["field_options"].ToString() != "")
                                    {

                                        fieldoptions = dr["field_options"].ToString();

                                        List<string> fieldoptionslist = new List<string>();
                                        fieldoptionslist = fieldoptions.Split(',').ToList();

                                        DataTable tempTable = new DataTable();
                                        tempTable.Columns.Add("Drop");

                                        for (int k = 0; k < fieldoptionslist.Count; k++)
                                        {
                                            // string d = fieldoptionslist[k];
                                            tempTable.Rows.Add(fieldoptionslist[k]);
                                        }

                                        //    foreach (DataRow dtrow in fieldoptionslist)
                                        //{
                                        //    tempTable.Rows.Add(dr);
                                        //}

                                        // split the list 
                                        // ddArea.select
                                        // send the list into datatable dt


                                        ddArea.DataTextField = "Drop";
                                        ddArea.DataValueField = "Drop";
                                        ddArea.DataSource = tempTable;
                                        ddArea.DataBind();
                                        // ddArea.Items.Insert(0, "--Select--");
                                        //ddArea.SelectedIndex = 0;
                                        //ddArea.SelectedValue = fieldval;
                                    }
                                    else
                                    {
                                        Binddata(tblName, ddArea, fieldName, labelnames, where);
                                        ddArea.SelectedValue = fieldval;
                                        PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                    }

                                }
                                else
                                {
                                    Binddata(tblName, ddArea, fieldName, labelnames, where);
                                    ddArea.SelectedValue = fieldval;
                                    PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                }


                            }
                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;

                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;
                                PlaceholderControls.Controls.Add(textArea);
                                textArea.Text = fieldval;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                FileUpload fileArea = new FileUpload();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                fileArea.ID = "fil" + fieldName;
                                PlaceholderControls.Controls.Add(fileArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                        }
                        if (inputtype == "BUTTON")
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("<tr><td>"));
                            Button button = new Button();
                            button.ID = "btn" + fieldName;
                            button.Text = labelnames;
                            button.BackColor = Color.Blue;
                            button.ForeColor = Color.White; //add on 26/12/23
                            button.Width = 50;
                            //if (button.Text=="save")
                            //{
                            button.Click += new EventHandler(ButtonClickCommonEvent);
                            PlaceholderControls.Controls.Add(button); // here
                            PlaceholderControls.Controls.Add(new LiteralControl("</td></tr>"));

                            PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                        }


                    }

                }
                //string fieldlist = Session["sesfieldlist"].ToString();

                //getgridview_search(fieldlist);

            }
        }
        void getgridview_search(string fieldlist)
        {
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);

            string ReportYesNo = Convert.ToString(Session["ReportYesNo"]);
            fieldlist = fieldlist.Replace("subcentre_id", "subcenter_id");

            int roleid = Convert.ToInt32(Session["Roleid"]);
            Session["sesfieldlist"] = fieldlist;
            string fields1 = Session["sesfieldlist"].ToString();

            //string userid = Session["UserId"].ToString();
            string userid = Session["empslno"].ToString();

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            if (sqlCon.State == ConnectionState.Closed)
            {
                string menuname = Request.QueryString["menuname"];
                menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);


                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.StoredProcedure;
                if (roleid == 3 && hdnMenuId.Value != "192")  //Convert.ToInt32(Session["Roleid"].ToString());
                {
                    cmd.CommandText = "[SP_getgridvalue_search_mobile]";
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@menuid", menuid);
                    cmd.Parameters.AddWithValue("@activityID", activityid);
                    cmd.Parameters.AddWithValue("@fieldlist", fieldlist);
                }
                else if (ReportYesNo == "Yes")
                {
                    cmd.CommandText = "SP_getgridvalue_search_Reports";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@menuname", menuname.Trim());
                    cmd.Parameters.AddWithValue("@fieldlist", fieldlist);
                }
                else
                {
                    cmd.CommandText = "SP_getgridvalue_search";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@menuid", menuid);
                    cmd.Parameters.AddWithValue("@activityID", activityid);
                    cmd.Parameters.AddWithValue("@fieldlist", fieldlist);
                }




                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                int SqlRow = 0;
                SqlRow = cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                sda.Fill(dt);



                if (dt.Rows.Count > 0)
                {
                    //lblMessage.Text = " I am here";
                    ViewState["dt"] = dt;


                    if (roleid == 3)
                    {
                        Converting();
                    }
                    else
                    {
                        if (menuid == 5 || menuid == 6)
                        {
                            //dt.Columns.Add("Excel", Type.GetType("System.Boolean"));
                            //dt.Columns.Add("PDF", Type.GetType("System.Boolean"));

                            grv1.DataSource = dt;
                            grv1.DataBind();

                            //foreach (GridViewRow row in grv1.Rows)
                            //{
                            //    //check box is the first control on the last cell.
                            //    CheckBox check = row.Cells[row.Cells.Count - 2].Controls[0] as CheckBox;
                            //    check.ID = "chkexcel";
                            //    Session["chkexcel"] = check;
                            //    check.Enabled = true;
                            //    CheckBox check1 = row.Cells[row.Cells.Count - 1].Controls[0] as CheckBox;
                            //    check1.Enabled = true;
                            //}

                        }
                        else
                        {
                            grv1.DataSource = dt;
                            grv1.DataBind();
                        }

                        if (menuid < 24 || menuid == 36 || menuid == 35 || menuid == 37
                            || menuid == 120)
                        {
                            //  grv1.Columns[0].Visible = false;
                            grv1.Columns[0].Visible = true;
                            grv1.Columns[1].Visible = false;
                            grv1.Columns[2].Visible = false;
                            grv1.Columns[3].Visible = false;
                            grv1.Columns[4].Visible = false;

                        }
                        else
                        {
                            grv1.Columns[0].Visible = true;
                            grv1.Columns[1].Visible = false;
                            grv1.Columns[2].Visible = false;
                            grv1.Columns[3].Visible = false;
                            grv1.Columns[4].Visible = true;
                        }
                        if (menuid == 5 || menuid == 6)
                        {
                            //  grv1.Columns[0].Visible = false;
                            grv1.Columns[0].Visible = false;
                            grv1.Columns[1].Visible = true;
                            grv1.Columns[2].Visible = true;
                            grv1.Columns[3].Visible = true;
                            grv1.Columns[4].Visible = false;

                        }
                        if (menuid == 32)
                        {
                            grv1.Columns[0].Visible = true;
                            grv1.Columns[1].Visible = false;
                            grv1.Columns[2].Visible = false;
                            grv1.Columns[3].Visible = false;
                            grv1.Columns[4].Visible = false;

                        }
                        if (ReportYesNo == "Yes")
                        {
                            grv1.Columns[0].Visible = false;
                            grv1.Columns[1].Visible = false;
                            grv1.Columns[2].Visible = false;
                            grv1.Columns[3].Visible = false;
                            grv1.Columns[4].Visible = false;
                        }
                        //if (menuid == 5)
                        //{
                        //    //CheckBox chkSelect = (CheckBox)grv1.Rows[1].FindControl("chkSelect");
                        //    //chkSelect.Visible = false;
                        //    grv1.Columns[0].Visible = false;
                        //}
                    }
                }
                else
                {
                    lblMessage.Text = "No record found";

                    grv1.DataSource = null;
                    grv1.DataBind();
                }

            }

            if (hdnMenuId.Value == "19")
            {
                PlaceholderControls.Controls.Clear();
                topfields(2);
            }
        }

        protected void Converting()
        {
            DataTable dt = (DataTable)ViewState["dt"];

            DataTable dt2 = new DataTable();
            //for (int i = 0; i <= dt.Rows.Count; i++)
            //{
            dt2.Columns.Add();
            // dt2.Columns.Add();
            //}
            int rc = 0;
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt2.Rows.Add();
                    dt2.Rows[rc][0] = (dt.Columns[i].ColumnName);
                    if (dt2.Rows[rc][0].ToString() == "client_id")
                    { dt2.Rows[rc][0] = "Client Name"; }
                    dt2.Rows.Add();
                    dt2.Rows[rc + 1][0] = dt.Rows[r][i];
                    rc = dt2.Rows.Count;

                }
            }
            //   BindGrid(dt2, true);
            grv1.PageSize = 500;
            grv1.DataSource = dt2;
            grv1.DataBind();

            grv1.GridLines = GridLines.None;
            //  grv1.Rows[0].Height = 40;


            foreach (GridViewRow item in grv1.Rows)
            {
                if (item.RowIndex % 2 == 0)
                {
                    item.Cells[5].Text = "<b>" + item.Cells[5].Text + "</b>";
                    grv1.Rows[item.RowIndex].Height = 40;
                }
                // else
                //{
                //    item.Cells[5].Text = "&nbsp&nbsp&nbsp&nbsp" + item.Cells[5].Text;
                //}
            }



            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            if (menuid == 189 || menuid == 192)
            {
                grv1.Columns[1].Visible = false;
                grv1.Columns[2].Visible = false;
                grv1.Columns[3].Visible = false;
            }
            else
            {
                grv1.Columns[1].Visible = false;
                grv1.Columns[2].Visible = false;
                grv1.Columns[3].Visible = false;
                grv1.Columns[4].Visible = false;

            }
            grv1.HeaderRow.Visible = false;
            grv1.Font.Size = 14;
            int ccnt = grv1.Columns.Count;
            //  grv1.Columns[3].ItemStyle.Width = 300;

            //*
            //     grv1.Attributes["AllowPaging"] = "False";
            int numcol = dt.Columns.Count;
            int numrows = dt2.Rows.Count;
            int numcol1 = numcol + numcol;
            //       int ind = ((grv1.PageIndex)  *20) +1;
            // int inds = (ind * 20) + 1;
            //if (ind == 0) 
            //{
            CheckBox chkSelect = (CheckBox)grv1.Rows[1].FindControl("chkSelect");
            chkSelect.Visible = false;
            LinkButton IP = (LinkButton)grv1.Rows[1].FindControl("lnkWIP");
            IP.Visible = false;
            //}
            //else
            //{

            //    CheckBox chkSelect = (CheckBox)grv1.Rows[1].FindControl("chkSelect");
            //}

            //06/02/2024 Comt on
            for (int it = 2; it <= numrows - 1; it++)
            {
                if (it == 500)
                {
                    return;
                }
                chkSelect = (CheckBox)grv1.Rows[it].FindControl("chkSelect");
                chkSelect.Visible = false;
                IP = (LinkButton)grv1.Rows[it].FindControl("lnkWIP");
                IP.Visible = false;
                if (it == numcol1 - 1)
                {
                    // chkSelect.Visible = true;
                    it = it + 1;
                    numcol1 = numcol1 + numcol1;
                }

            }
            chkSelect.Visible = false;

        }

        //protected void BindGrid(DataTable dt, bool rotate)
        //{
        //    grv1.ShowHeader = !rotate;
        //    grv1.DataSource = dt;
        //    grv1.DataBind();
        //    if (rotate)
        //    {
        //        foreach (GridViewRow row in grv1.Rows)
        //        {
        //           // row.Cells[0].CssClass = "header";
        //        }
        //    }
        //}
        protected void ButtonClickCommonEvent(object sender, EventArgs e) // general
        {
            int MenuId = Convert.ToInt32(hdnMenuId.Value);
            string menuname = Request.QueryString["menuname"];
            string actres = "";

            Button btn = (Button)sender;
            actres = btn.Text;

            switch (actres)
            {
                case "Search":
                    searchevent();
                    break;

                case "Import":
                    lblMessage.Text = actres + "  button clicked";
                    importevent(MenuId);
                    Session["elapsedtime"] = "14.55";
                    break;
                case "SampleDownload":
                    lblMessage.Text = actres + "  button clicked";
                    importeventSampleDownloadevent();
                    Session["elapsedtime"] = "14.55";
                    break;
                case "FormatDownload":
                    importeventSampleDownloadevent();
                    break;

                case "ManualAssign":
                    checkboxclick();
                    // fullname - null
                    searchevent();
                    break;
                case "AssignQCcase":
                    checkboxclick();
                    break;
                case "AutoAssign":
                    FEAutoAssign();
                    searchevent();
                    break;

                case "REASSIGN":
                    ReDoevent(actres);
                    searchevent();
                    break;

                case "Accept_cases":
                    Acceptcasesevent();
                    break;

                case "Save":
                    if (hdnMenuId.Value == "19")
                    {
                        checkboxclick();
                    }
                    else if (Convert.ToInt32(hdnMenuId.Value) > 43 && Convert.ToInt32(hdnMenuId.Value) < 92)
                    {
                        SaveMaster();
                    }
                    else if (Convert.ToInt32(hdnMenuId.Value) > 123 && Convert.ToInt32(hdnMenuId.Value) < 145)
                    {
                        SaveMaster();
                    }
                    else if (hdnMenuId.Value == "99" || hdnMenuId.Value == "100")
                    {
                        importFEPayOut();
                    }
                    else
                    {
                        saveevent();
                    }
                    lblMessage.Text = "  Record Saved successfully ";
                    Session["iterations"] = 0;
                    searchevent();
                  //  PlaceholderControls.Controls.Clear();
                    break;
                case "ADD":
                    Response.Redirect("caseentrybase.aspx?menuid=25&menuname=CaseEntry", true);
                    break;

                case "AddNew":
                    AddNewEvent();
                    break;

                case "Cancel":
                    int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                    Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid=13", false);
                    break;
                case "Export":
                    lblMessage.Text = actres + "  button clicked";

                    string ReportYesNo = Convert.ToString(Session["ReportYesNo"]);

                    if (ReportYesNo == "Yes")
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = (DataTable)ViewState["dt"];
                        importeventExportToExcel(dt1, menuname);
                    }
                    else
                    {
                        Exportevent(MenuId);
                    }
                    Session["elapsedtime"] = "14.55";
                    searchevent();
                    break;

                case "NEXT":
                    lblMessage.Text = actres + "  button clicked";
                    NEXTevent();
                    Session["iterations"] = 0;
                    Session["elapsedtime"] = "14.55";
                    break;
                case "ReDo":
                    ReDoevent(actres);
                    searchevent();
                    break;
                case "MoveCase":
                    MoveCaseEvent();
                    searchevent();
                    break;
                case "QualityCheck":
                    QualityCheckEvent();
                    searchevent();
                    break;
                case "DELETE":
                    CaseDelete();
                    searchevent();
                    break;
                case "RestoreSelectedCases":
                    RestoreSelectedCases();
                    searchevent();
                    break;
                default:


                    lblMessage.Text = actres + "  button clicked";
                    break;
            }
            return;



        }
        protected void Acceptcasesevent()
        {

            string user_id = Session["empslno"].ToString(); // Session["UserId"].ToString();

            int field_show_in = 0;
            string selval = null;
            string selfield = null;
            int numboxchecked = 0;

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)

            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                // LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnkWIP");

                if (chkSelect.Checked == true)
                {

                    //  PlaceholderControls.Controls.Clear();
                    //string headerRowText = grv1.HeaderRow.Cells[5].Text;
                    //selfield = grv1.Rows[i].Cells[5].Text.Trim();
                    //selval = grv1.Rows[i].Cells[6].Text.Trim();

                    string headerRowText = grv1.HeaderRow.Cells[5].Text; //changes by ramaki sir on 26/03/2025
                    selfield = grv1.Rows[i].Cells[5].Text.Trim(); //changes by ramaki sir on 26/03/2025
                    selval = grv1.Rows[i + 1].Cells[5].Text.Trim(); //changes by ramaki sir on 26/03/2025

                    lblMessage.Text += "selected " + selfield + " - " + selval + "";
                    numboxchecked = 1;
                    grv1.Attributes["PageSize"] = "100";
                    string case_id = selval;

                    // update tbl_cases AND insert into tbl_case_history
                    // fe_assign table inst is not required
                    // values required for sp - 


                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                    if (sqlCon.State == ConnectionState.Closed)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = sqlCon;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_Accept_case_Mobile";
                        cmd.CommandTimeout = 0;


                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@case_id", case_id);
                        cmd.Parameters.AddWithValue("@Assisgn_status", "Accepted");
                        cmd.Parameters.AddWithValue("@case_status", "Accepted");
                        cmd.Parameters.AddWithValue("@action", "Accepted");



                        SqlDataAdapter sda = new SqlDataAdapter();
                        sda.SelectCommand = cmd;

                        int SqlRow = 0;
                        SqlRow = cmd.ExecuteNonQuery();

                    }

                    if (numboxchecked == 0)
                    {
                        lblMessage.Text = "Please select one record from the grid";
                    }
                    else
                    {

                        grv1.Visible = true;


                    }
                }
            }

            getgridview_search("1");
        }
        protected void saveevent() // to be written
        {
            int sesit = Convert.ToInt32(Session["iterations"]);
            //  NEXTevent();
            //topfields_4(5);
            string message = "";
            lblMessage.Text = "";
            string updatevalue = "";




            int Client_id = Convert.ToInt32(ViewState["ClientId"]);
            int productid = Convert.ToInt32(ViewState["ProductId"]);
            int veriftypeid = Convert.ToInt32(ViewState["VeriftypeId"]);
            int caseforid = Convert.ToInt32(ViewState["caseforid"]);
            int zoneid = Convert.ToInt32(ViewState["zoneid"]);
            int centreid = Convert.ToInt32(ViewState["centreid"]);
            int subcentreid = Convert.ToInt32(ViewState["subcentreid"]);


            if (hdnMenuId.Value != "19")
            {
                if (sesit != 9)
                {

                    lblMessage.Text += "Client_id" + ",";
                    message += "'" + Client_id + "'" + ",";
                    updatevalue += "Client_id" + "=" + "'" + Client_id + "'" + ",";


                    lblMessage.Text += "product_id" + ",";
                    message += "'" + productid + "'" + ",";
                    updatevalue += "product_id" + "=" + "'" + productid + "'" + ",";


                    lblMessage.Text += "veriftype_id" + ",";
                    message += "'" + veriftypeid + "'" + ",";
                    updatevalue += "veriftype_id" + "=" + "'" + veriftypeid + "'" + ",";


                    lblMessage.Text += "casefor_id" + ",";
                    message += "'" + caseforid + "'" + ",";
                    updatevalue += "casefor_id" + "=" + "'" + caseforid + "'" + ",";


                    lblMessage.Text += "zone_id" + ",";
                    message += "'" + zoneid + "'" + ",";
                    updatevalue += "zone_id" + "=" + "'" + zoneid + "'" + ",";


                    lblMessage.Text += "centre_id" + ",";
                    message += "'" + centreid + "'" + ",";
                    updatevalue += "centre_id" + "=" + "'" + centreid + "'" + ",";

                    lblMessage.Text += "subcentre_id" + ",";
                    message += "'" + subcentreid + "'" + ",";
                    updatevalue += "subcenter_id" + "=" + "'" + subcentreid + "'" + ",";
                }

            }

            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";
                updatevalue += textBox.ID.Substring(3) + "=" + "'" + textBox.Text + "'" + ",";

            }


            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {

                if (ddl.SelectedValue != "--Select--")
                {
                    lblMessage.Text += ddl.ID.Substring(3) + ",";
                    message += "'" + ddl.SelectedValue + "'" + ",";
                    updatevalue += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
                }
            }



            foreach (CheckBox chk in PlaceholderControls.Controls.OfType<CheckBox>())
            {
                lblMessage.Text += chk.ID.Substring(3) + ",";
                message += "'" + chk.Checked + "'" + ",";
                updatevalue += chk.ID.Substring(3) + "=" + "'" + chk.Checked + "'" + ",";
            }


            foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
            {
                lblMessage.Text += fup.ID.Substring(3) + ",";
                message += "'" + fup.FileName + "'" + ",";
                updatevalue += fup.ID.Substring(3) + "=" + "'" + fup.FileName + "'" + ",";


                string strname = fup.FileName.ToString();

                if (strname != "")
                {
                    fup.PostedFile.SaveAs(Server.MapPath("~/UploadedImages/") + strname);
                }
            }
            //      lblMessage.Text = ddl1.SelectedValue;

            foreach (Button btn in PlaceholderControls.Controls.OfType<Button>())
            {
                btn.Visible = false;

            }

            // ==================================
            string hr = "";
            string svl = "";
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            int activityid = Convert.ToInt32(Session["ActivityId"].ToString());
            String valforupdate = "";
            String tosendtosql = "";
            String valtosendtosql = "";

            if (menuid == 19 || menuid == 27 || menuid == 189 || menuid == 39)
            {
                sesit = 1;
            }

            if (sesit == 1)
            {
                hr = Session["headrow"].ToString();
                svl = Session["selval"].ToString();

                valforupdate = updatevalue.TrimEnd(',');

                string hrv = hr + "='" + svl + "'";

                valforupdate = valforupdate.Replace(hrv, "");

                valforupdate = valforupdate.TrimEnd(',');
                // VUPD - IF FIST ITEM IS CASE_ID - DO ELSE DONT

                bool result = valforupdate.Contains("case_id");
                if (result == true)
                {
                    valforupdate = valforupdate.Substring(valforupdate.IndexOf(',') + 1);
                }
                valforupdate = valforupdate.TrimStart(',');
                valtosendtosql = valforupdate;
                tosendtosql = "x";
            }
            else
            {
                hr = "0";
                svl = "0";
                tosendtosql = lblMessage.Text.TrimEnd(',');
                //  int indval = tosendtosql.IndexOf(',') + 1;
                // if first field is case id the second line should be used
                //  tosendtosql = tosendtosql.Substring(tosendtosql.IndexOf(',') + 1);
                valtosendtosql = message.TrimEnd(',');
                //   valtosendtosql = valtosendtosql.Substring(valtosendtosql.IndexOf(',') + 1);

                tosendtosql = tosendtosql + ", activity_id,country_id,template_id";
                valtosendtosql = valtosendtosql + "," + Convert.ToString(Session["ActivityId"]) + ",11," + Convert.ToString(ViewState["global_template_id"]);
            }


            //if (sesit == 1)
            //{
            //    string[] values = valtosendtosql.Split(',');
            //    valtosendtosql = "";
            //    string finalValue = string.Empty;

            //    for (int i = 1; i < values.Length; i++)
            //    {
            //        valtosendtosql += "'" + values[i] + "'" + ",";
            //    }

            //    valtosendtosql = valtosendtosql.TrimEnd(',');
            //}

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            tosendtosql = tosendtosql.Replace("case_for_fe_vendor", "casefor_id").Replace("subcentre_id", "subcenter_id");

            valtosendtosql = valtosendtosql.Replace("case_for_fe_vendor", "casefor_id").Replace("subcentre_id", "subcenter_id");




            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_save";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@menuid", menuid);
                    cmd.Parameters.AddWithValue("@activityID", activityid);
                    cmd.Parameters.AddWithValue("@headrow", hr);
                    cmd.Parameters.AddWithValue("@selval", svl);
                    cmd.Parameters.AddWithValue("@sessit", sesit);
                    cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                    cmd.Parameters.AddWithValue("@fieldlist", tosendtosql);

                    if (hdnMenuId.Value == "189")
                    {
                        valtosendtosql = valtosendtosql + ",case_status =" + "'" + "Close" + "'";
                        valtosendtosql = valtosendtosql + ",fe_submit_date =" + "'" +
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        valtosendtosql = valtosendtosql + ",assign_status =" + "'" + "Verified" + "'";
                    }

                    // DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss")

                    cmd.Parameters.AddWithValue("@fieldvalue", valtosendtosql);
                    cmd.Parameters.AddWithValue("@countryid", Convert.ToString(Session["CountryID"]));


                    sqlCon.Open();
                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();
                    sqlCon.Close();

                }
                Session["iterations"] = 0;
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void searchevent()
        {
            lblMessage.Text = "button1 clicked  SEARCH ";

            string message = "";
            string forsearch = "";
            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    //textBox.Text = "x";
                }
                else
                {

                    if (textBox.ID.Contains("dat"))
                    {
                        textBox.Text = Convert.ToDateTime(textBox.Text).ToString("yyyy-MM-dd");
                    }
                    forsearch += textBox.ID.Substring(3) + ",";
                    forsearch += "'" + textBox.Text + "'" + ",";
                }
            }

            if (ddAreas.SelectedValue == "--Select--" || ddAreas.SelectedValue == "")
            {
                ddAreas.SelectedValue = null;
            }
            else
            {
                forsearch += "zone_id" + ",";
                forsearch += "'" + ddAreas.SelectedValue + "'" + ",";
            }

            if (ddlCenterNew.SelectedValue == "--Select--" || ddlCenterNew.SelectedValue == "")
            {
                ddlCenterNew.SelectedValue = null;
            }
            else
            {
                forsearch += "centre_id" + ",";
                forsearch += "'" + ddlCenterNew.SelectedValue + "'" + ",";
            }

            if (ddlsubcenternew.SelectedValue == "--Select--" || ddlsubcenternew.SelectedValue == "")
            {
                ddlsubcenternew.SelectedValue = null;
            }
            else
            {
                forsearch += "subcentre_id" + ",";
                forsearch += "'" + ddlsubcenternew.SelectedValue + "'" + ",";
            }

            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                lblMessage.Text += ddl.ID.Substring(3) + ",";
                message += "'" + ddl.SelectedValue + "'" + ",";
                if (ddl.SelectedValue == "--Select--" || ddl.SelectedValue == "")
                {
                    ddl.SelectedValue = null;
                }
                else
                {
                    forsearch += ddl.ID.Substring(3) + ",";
                    forsearch += "'" + ddl.SelectedValue + "'" + ",";
                }
            }

            foreach (ListBox lst in PlaceholderControls.Controls.OfType<ListBox>())
            {
                //lblMessage.Text += lst.ID.Substring(3) + ",";
                //message += "'" + lst.SelectedValue + "'" + ",";
                if (lst.SelectedValue == "--Select--")
                {
                    lst.SelectedValue = null;
                }
                else
                {
                    foreach (System.Web.UI.WebControls.ListItem item in lst.Items)
                    {
                        if (item.Selected)
                        {
                            forsearch += lst.ID.Substring(3) + ",";
                            forsearch += "'" + item.Value + "'" + ",";
                        }

                    }

                    //forsearch += lst.ID.Substring(3) + ",";
                    //forsearch += "'" + lst.SelectedValue + "'" + ",";
                }
            }

            foreach (CheckBox chk in PlaceholderControls.Controls.OfType<CheckBox>())
            {
                lblMessage.Text += chk.ID.Substring(3) + ",";
                message += "'" + chk.Checked + "'" + ",";
                forsearch += chk.ID.Substring(3) + ",";
                forsearch += "'" + chk.Checked + "'" + ",";
            }


            string toforsearch = forsearch;
            toforsearch = toforsearch.TrimEnd(',');

            Session["sesfieldlist"] = toforsearch;
            string fields = Session["sesfieldlist"].ToString();
            if (fields == "")
            {
                lblMessage.Text = "Please select atlast one field in filter";
                return;

            }

            getgridview_search(toforsearch);



            // Search griddata from gridview

        }
        protected void importeventSampleDownloadevent()
        {
            try
            {

                lblMessage.Text = "button1 clicked  ff ";
                // take to sampledownload button
                //{
                int templ_id = Convert.ToInt32(Session["templ_id"]);
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.CommandText = "SP_gettemplatefields";
                //cmd.Parameters.AddWithValue("@template_id", templ_id);
                cmd.Parameters.AddWithValue("@template_id", templ_id);
                cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                importeventExportToExcel(dt, "SampleData");

                // create excel and download to browser's download location
                // }
                //take to sampledownload button
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void importevent(int menuid)
        {

            string FileUploadName = "";

            foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
            {
                FileUploadName = fup.FileName;
            }

            if (FileUploadName != "" && FileUploadName != null)
            {
                importeventDataImport(FileUploadName);
            }
        }

        protected void importeventDataImport(string xslFileUploadFileName)
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            int TemplateColumnCount = 0;
            int TemplateID = 0;
            int NoOfCases = 0;
            int ClientId = 0;

            int menuid = Convert.ToInt32(hdnMenuId.Value);


            DateTime ReceivedDate = DateTime.Now;
            string Receivedtime = string.Empty;

            try
            {
                lblMessage.Text = "";
                //Upload and save the file
                string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(xslFileUploadFileName);
                string fileName = Path.GetFileNameWithoutExtension(excelPath);
                string fileExtension = Path.GetExtension(excelPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                string newxlsfilename = "Res_" + datetime + fileExtension;

                newxlsfilename = excelPath.Replace(Path.GetFileName(xslFileUploadFileName), newxlsfilename);
                //if (fileName.ToUpper().StartsWith("INVOICE MANAGEMENT"))
                //{
                if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                {

                    foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
                    {
                        fup.SaveAs(newxlsfilename);
                    }

                    ImportExcel ie = new ImportExcel();
                    DataTable dt = new DataTable();
                    DataSet ds = ie.ExcelDataReader(newxlsfilename);

                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }

                    if (dt != null && dt.Rows.Count > 0)
                    {

                        //foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
                        //{
                        //    if (ddl.ID.Substring(3) == "importtemplateassign_template_id")
                        //    {
                        //        Session["TemplateId"] = ddl.SelectedValue;
                        //    }
                        //}



                        string ID = string.Empty;
                        string Values = string.Empty;
                        string both = string.Empty;

                        foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
                        {
                            ID += textBox.ID.Substring(3) + ",";
                            Values += "'" + textBox.Text + "'" + ",";
                            both += textBox.ID.Substring(3) + "=" + "'" + textBox.Text + "'" + ",";

                        }

                        foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
                        {
                            ID += ddl.ID.Substring(3) + ",";
                            Values += "'" + ddl.SelectedValue + "'" + ",";
                            both += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
                        }



                        if (menuid == 2 || menuid == 3 || menuid == 4)
                        {
                            ID = ID.Replace("importtemplateassign_template_id", "template_id").Replace("APIName_id", "field341").Replace("casetype_id", "field342").Replace("casefor_id", "field343").Replace("Received_time", "field344").Replace("veriftype_id", "field345").Replace("center_id", "centre_id").Replace("subcenter_id", "subcentre_id");
                        }

                        List<string> frontendvaluelist = new List<string>();
                        frontendvaluelist = both.Split(',').ToList();

                        for (int k = 0; k < frontendvaluelist.Count - 1; k++)
                        {
                            List<string> value = frontendvaluelist[k].Split('=').ToList();

                            if (value[0] == "Template_id")  //"importtemplateassign_template_id")
                            {
                                TemplateID = Convert.ToInt32(value[1].Replace("'", ""));
                            }
                            if (value[0] == "client_id")
                            {
                                ClientId = Convert.ToInt32(value[1].Replace("'", ""));
                            }
                            if (value[0] == "Received_Date")
                            {
                                ReceivedDate = Convert.ToDateTime(value[1].Replace("'", ""));
                            }
                            if (value[0] == "Received_Time")
                            {
                                Receivedtime = Convert.ToString(value[1].Replace("'", ""));
                            }
                        }



                        int sesit = Convert.ToInt32(Session["iterations"]);


                        string hr = "";
                        string svl = "";
                        string valforupdate = "";
                        string tosendtosql = "";
                        string valtosendtosql = "";

                        if (sesit == 1)
                        {
                            hr = Session["headrow"].ToString();
                            svl = Session["selval"].ToString();

                            valforupdate = both.TrimEnd(',');

                            string hrv = hr + "='" + svl + "'";

                            valforupdate = valforupdate.Replace(hrv, "");

                            valforupdate = valforupdate.TrimEnd(',');
                            //valforupdate = valforupdate.Substring(valforupdate.IndexOf(',') + 1);
                            valforupdate = valforupdate.TrimStart(',');
                            valtosendtosql = valforupdate;
                            tosendtosql = "x";
                        }
                        else
                        {
                            hr = "0";
                            svl = "0";
                            tosendtosql = ID.TrimEnd(',');
                            tosendtosql = tosendtosql.Substring(tosendtosql.IndexOf(',') + 1);
                            valtosendtosql = Values.TrimEnd(',');
                            valtosendtosql = valtosendtosql.Substring(valtosendtosql.IndexOf(',') + 1);

                            valforupdate = both.TrimEnd(',');
                        }


                        //TemplateID = 513;// Removed this after Testing

                        // TemplateID = Convert.ToInt32(Session["TemplateId"]);

                        if (TemplateID != 0)
                        {
                            TemplateColumnCount = ImportevenGetTemplateColumnCount(TemplateID);
                        }
                        else
                        {
                            lblMessage.Text = "incorrect Template ID";

                            return;
                        }

                        // Validating if all columns exists in format
                        int colCount = dt.Columns.Count;

                        if (colCount != TemplateColumnCount)
                        {
                            lblMessage.Text = "Uploaded Excel and Template Column Count Mismatch";

                            return;
                        }

                        List<string> Columns = importeventreturnColumns(TemplateID);  // 18

                        int i = 0;
                        foreach (var col in Columns)
                        {
                            if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                            {
                                lblMessage.Text = Columns[i] + "!=" + Convert.ToString(dt.Columns[i].ColumnName)
                                  + "  Uploaded Excel Not As Per Standard Format Column Name Mismatch";

                                return;
                            }
                            i++;
                        }

                        //dt.Columns.Add("UserName").DefaultValue = Session["UserName"];
                        //DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                        //newColumn.DefaultValue = Convert.ToString(Session["UserID"]);
                        //dt.Columns.Add(newColumn);


                        DataColumn newColumn2 = new DataColumn("Error", typeof(System.String));
                        newColumn2.DefaultValue = "Success";
                        dt.Columns.Add(newColumn2);

                        dt.AcceptChanges();

                        string fields = "";



                        StringBuilder sb = new StringBuilder();

                        colCount = dt.Columns.Count;

                        int Result = 0;

                        // This SP Use for Create Temp Table In DataBase
                        SqlCommand cmd = new SqlCommand("SP_CreateTempTable", sqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TemplateId", TemplateID);
                        cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                        sqlCon.Open();
                        Result = cmd.ExecuteNonQuery();
                        sqlCon.Close();

                        string Colname = string.Empty;

                        //By This Loop Insert one by One Data into Temp Table For Import and Multiple Import
                        if (menuid == 2 || menuid == 4)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {

                                string strColumn = "";
                                sb = new StringBuilder();
                                for (int j = 0; j < colCount; j++)
                                {
                                    Colname += dt.Columns[j].ColumnName + ",";

                                    string dc = Convert.ToString(dr[j]);
                                    strColumn += "'" + dc + "',";
                                }

                                sb.Append("(" + strColumn.TrimEnd(',') + "),");
                                sb.Remove(sb.Length - 1, 1);
                                fields = Convert.ToString(sb);





                                SqlCommand cmd2 = new SqlCommand("SP_InsertUpdateDataInTempTable", sqlCon);
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.AddWithValue("@fields", fields);
                                cmd2.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                                cmd2.Parameters.AddWithValue("@ClientId", ClientId);
                                cmd2.Parameters.AddWithValue("@MenuId", menuid);
                                cmd2.Parameters.AddWithValue("@Colname", Colname);

                                sqlCon.Open();
                                Result = cmd2.ExecuteNonQuery();
                                sqlCon.Close();
                            }
                        }
                        else if (menuid == 3)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                string strColumn = "";
                                sb = new StringBuilder();
                                for (int j = 0; j < colCount; j++)
                                {
                                    string dc = Convert.ToString(dr[j]);
                                    strColumn += "'" + dc + "',";
                                }

                                sb.Append("(" + strColumn.TrimEnd(',') + "),");
                                sb.Remove(sb.Length - 1, 1);
                                fields = Convert.ToString(sb);

                                SqlCommand cmd2 = new SqlCommand("SP_InsertUpdateDataInTempTable_ForPartialDuplicate", sqlCon);
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.AddWithValue("@fields", fields);
                                cmd2.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                                cmd2.Parameters.AddWithValue("@ClientId", ClientId);
                                cmd2.Parameters.AddWithValue("@MenuId", menuid);

                                sqlCon.Open();
                                Result = cmd2.ExecuteNonQuery();
                                sqlCon.Close();
                            }
                        }


                        tosendtosql = tosendtosql.Replace("subcentre_id", "subcenter_id");

                        //This SP Use to insert into Final Table and Generate Excel
                        SqlCommand cmd3 = new SqlCommand("SP_InsertFinalTable", sqlCon);
                        cmd3.CommandType = CommandType.StoredProcedure;
                        cmd3.Parameters.AddWithValue("@TemplateId", TemplateID);
                        cmd3.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                        cmd3.Parameters.AddWithValue("@MenuId", menuid);
                        cmd3.Parameters.AddWithValue("@activityid", Convert.ToInt32(Session["ActivityId"]));
                        cmd3.Parameters.AddWithValue("@countryid", Convert.ToInt32(Session["CountryID"]));
                        cmd3.Parameters.AddWithValue("@BSTColumnName", tosendtosql);
                        cmd3.Parameters.AddWithValue("@BSTColumnValues", valtosendtosql);
                        cmd3.Parameters.AddWithValue("@valueforupdate", valforupdate);
                        SqlDataAdapter dp1 = new SqlDataAdapter(cmd3);
                        DataSet ds1 = new DataSet();
                        dp1.Fill(ds1);

                        if (ds1 != null)
                        {
                            NoOfCases = Convert.ToInt32(ds1.Tables[1].Rows[0]["Totalcount"]);

                            if (NoOfCases > 0)
                            {
                                importeventInsetDataIntotblcasedata(TemplateID, 0, ReceivedDate, Receivedtime, NoOfCases);
                            }
                            // select case_id from tbl_cases where case_status='Open' 
                            //if not exists( select ase_id from tbl_case_hisotry where case _id in 
                            //select case_id from tbl_cases where case_status = 'Open')
                            // case_id open - 15
                            // case_id open 100 // case history 
                            importeventExportToExcel(ds1.Tables[0], "ImportData");
                        }


                        //string field_name = GetColumnName(TemplateID);
                        //field_name = field_name.Replace("('", "");
                        //field_name = field_name.Replace("')", "");

                        //if (Result > 0)
                        //{

                        //    lblMessage.Text = "Imported Successfully";
                        //}
                        //else
                        //{
                        //    lblMessage.Text = "No Records Found to Import, Kindly check the Excel !";
                        //    lblMessage.ForeColor = System.Drawing.Color.Red;
                        //    return;
                        //}

                        if (File.Exists(newxlsfilename))
                        {
                            File.Delete(newxlsfilename);
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid File Extension, Only .xls and .xlsx file are allowed !";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected int ImportevenGetTemplateColumnCount(int TemplateID)
        {
            int totalcount = 0;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand("SP_GetTemplateColumnCount", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TemplateId", TemplateID);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dp.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                totalcount = Convert.ToInt32(ds.Tables[0].Rows[0]["TemplateColumnCount"].ToString());
            }

            return totalcount;
        }

        private List<string> importeventreturnColumns(int TemplateID)
        {
            List<string> column = new List<string>();

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand("SP_GetTemplateColumn", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TemplateId", TemplateID);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    column.Add(dt.Rows[i]["field_label"].ToString());
                }
            }

            return column;
        }

        protected void importeventInsetDataIntotblcasedata(int templateid, int casetype, DateTime receiveddate, string receivedtime, int noofcases)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                int Result = 0;

                SqlCommand cmd = new SqlCommand("SP_InsetDataInto_tblcasedata", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TemplateId", templateid);
                cmd.Parameters.AddWithValue("@casetype", 0);
                cmd.Parameters.AddWithValue("@receiveddate", receiveddate);
                cmd.Parameters.AddWithValue("@receivedtime", receivedtime);
                cmd.Parameters.AddWithValue("@noofcases", noofcases);
                cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                sqlCon.Open();
                Result = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void importeventExportToExcel(DataTable dt, string Fname)
        {
            string currentDateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string filename = Fname + "_" + currentDateTime + "_" + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }

        // ===========================================


        void Binddata(String tblName1, DropDownList ddl, String fieldname, String labelname, string where)
        {
            try
            {
                //if (where!="ALL")
                //{
                //    //lblMessage.Text = "where value not all";
                //}

                labelname = labelname.Replace("Verification_type", "veriftype_name").Replace("subcenter_id", "subcentre_id");

                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon1;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_binddata";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                SqlParameter tbl = new SqlParameter();
                tbl.SqlDbType = SqlDbType.VarChar;
                tbl.Value = tblName1;
                tbl.ParameterName = "@tblname";
                sqlCom.Parameters.Add(tbl);

                SqlParameter fldname = new SqlParameter();
                fldname.SqlDbType = SqlDbType.VarChar;
                fldname.Value = fieldname;
                fldname.ParameterName = "@fldname";
                sqlCom.Parameters.Add(fldname);

                SqlParameter lblname = new SqlParameter();
                lblname.SqlDbType = SqlDbType.VarChar;
                lblname.Value = labelname;
                lblname.ParameterName = "@lblname";
                sqlCom.Parameters.Add(lblname);

                SqlParameter wherei = new SqlParameter();
                wherei.SqlDbType = SqlDbType.VarChar;
                wherei.Value = where;
                wherei.ParameterName = "@where";
                sqlCom.Parameters.Add(wherei);

                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {


                    ddl.DataTextField = "DTF";
                    ddl.DataValueField = "DTV";
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataBind();
                    ddl.Items.Insert(0, "--Select--");
                    ddl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        void Binddata1(String tblName1, ListBox ddl, String fieldname, String labelname)
        {
            try
            {
                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon1;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_binddata";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                SqlParameter tbl = new SqlParameter();
                tbl.SqlDbType = SqlDbType.VarChar;
                tbl.Value = tblName1;
                tbl.ParameterName = "@tblname";
                sqlCom.Parameters.Add(tbl);

                SqlParameter fldname = new SqlParameter();
                fldname.SqlDbType = SqlDbType.VarChar;
                fldname.Value = fieldname;
                fldname.ParameterName = "@fldname";
                sqlCom.Parameters.Add(fldname);

                SqlParameter lblname = new SqlParameter();
                lblname.SqlDbType = SqlDbType.VarChar;
                lblname.Value = labelname;
                lblname.ParameterName = "@lblname";
                sqlCom.Parameters.Add(lblname);

                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {


                    ddl.DataTextField = "DTF";
                    ddl.DataValueField = "DTV";
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataBind();
                    ddl.Items.Insert(0, "--Select--");
                    ddl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMessage.Text = "Pagechanged";
            grv1.PageIndex = e.NewPageIndex;

            string fieldlist = Session["sesfieldlist"].ToString();
            getgridview_search(fieldlist);

        }

        protected void checkboxclick()
        {
            int ClientID = 0; int FEID = 0;
            int Result = 0;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                // lblMessage.Text += ddl.ID + ","; 
                if (ddl.ID == "ddlclient_id")
                {

                    if (ddl.SelectedValue == "--Select--" || ddl.SelectedValue == "")
                    {
                        lblMessage.Text = "Please select client id";
                        return;
                    }
                    else
                    {
                        //lblMessage.Text += ddl.ID + ",";
                        //lblMessage.Text += ddl.SelectedValue.ToString();
                        ClientID = Convert.ToInt32(ddl.SelectedValue);
                    }
                }
                if (ddl.ID == "ddlempslno")
                {

                    if (ddl.SelectedValue == "--Select--" || ddl.SelectedValue == "")
                    {
                        lblMessage.Text = "Please select an employee";
                        return;
                    }
                    else
                    {
                        //lblMessage.Text += ddl.ID + ",";
                        //lblMessage.Text += ddl.SelectedValue.ToString();
                        FEID = Convert.ToInt32(ddl.SelectedValue);
                        ddl.SelectedValue = null;
                    }
                }
            }

            Session["iterations"] = 1;

            lblMessage.Text = "";
            int field_show_in = 0;

            string selval = null;
            string caselist = "";
            int numboxchecked = 0;
            string selected = string.Empty;

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {
                    //for (int a = 0; a < grv1.HeaderRow.Cells.Count; a++)
                    //{
                    string headerName = grv1.HeaderRow.Cells[5].Text;
                    selval = grv1.Rows[i].Cells[5].Text.Trim();

                    Session["headrow"] = headerName;
                    Session["selval"] = selval;

                    lblMessage.Text += "Case " + selval + "selected";
                    caselist += selval + ',';

                    string hr = Session["headrow"].ToString();
                    string svl = Session["selval"].ToString();

                    numboxchecked = 1;



                    //if (headerName == "case_id")
                    //{
                    //    selval = grv1.Rows[i].Cells[a].Text.Trim();
                    //    lblMessage.Text += "Case " + selval + "selected";
                    //    caselist += selval + ',';
                    //}
                    // }

                    //string headerRowText = grv1.HeaderRow.Cells[2].Text; Yasir 09/01/2024                    
                    numboxchecked = 1;
                    field_show_in = 3;

                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                selected = caselist;
                // for each case selected - we have to update tbl_cases fields: 
                // insert into history - required fields for the case concerned
                // refresh grv1
                grv1.Visible = true;
            }


            selected = selected.Remove(selected.Length - 1);

            List<string> frontendvaluelist = new List<string>();
            frontendvaluelist = selected.Split(',').ToList();
            // save event();

            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);

            if (menuid == 19)
            {
                saveevent();
            }
            else
            {

                for (int k = 0; k < frontendvaluelist.Count; k++)
                {
                    string caseid = frontendvaluelist[k];
                    string Userid = Convert.ToString(Session["UserID"]);
                    string SP = "";
                    if (hdnMenuId.Value == "36")
                    {
                        SP = "SP_InsertFEAssignment_QC";

                    }
                    else
                    {
                        SP = "SP_InsertFEAssignmentManualAssign";
                    }

                    SqlCommand cmd2 = new SqlCommand(SP, sqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@FEID", FEID);
                    cmd2.Parameters.AddWithValue("@CaseID", frontendvaluelist[k]);
                    cmd2.Parameters.AddWithValue("@ClientID", ClientID);
                    cmd2.Parameters.AddWithValue("@UerId", Convert.ToString(Session["empslno"]));
                    cmd2.Parameters.AddWithValue("@EMP_Name", Convert.ToString(Session["fullName"]));

                    sqlCon.Open();
                    Result = cmd2.ExecuteNonQuery();
                    sqlCon.Close();

                    if (Result > 0)
                    {
                        lblMessage.Text += "FE Assignment Done for " + caseid;
                    }
                    else
                    {
                        lblMessage.Text += "FE Assignment failed as qc assigned to same FE  for " + caseid;
                    }
                }

                if (Result > 0)
                {
                   //
                }
            }
        }
        protected void lnkWIP_Click(object sender, EventArgs e)
        {
            

            // Session["iterations"] = 1;

            lblMessage.Text = "";
            int field_show_in = 0;
            //     grv1.Visible = false;

            //PlaceholderControls.Controls.Clear();

            string selval = null;
            //try
            //{
            int numboxchecked = 0;
            for (int i = 0; i <= grv1.Rows.Count - 1; i++)

            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                // LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnkWIP");

                if (chkSelect.Checked == true)
                {
                    numboxchecked = numboxchecked + 1;
                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
                return;
            }
            else if (numboxchecked > 1)
            {
                lblMessage.Text = "Please select only one record from the grid";
                return;
            }

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)

            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                // LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnkWIP");

                if (chkSelect.Checked == true)
                {
                    PlaceholderControls.Controls.Clear();
                    string headerRowText = grv1.HeaderRow.Cells[5].Text;
                    selval = grv1.Rows[i].Cells[5].Text.Trim();
                    numboxchecked = numboxchecked + 1;

                    if (Convert.ToInt32(hdnMenuId.Value) > 43 && Convert.ToInt32(hdnMenuId.Value) < 92)
                    {
                        ViewState["headerRowText"] = headerRowText;
                        ViewState["selval"] = selval;

                        field_show_in = 3;

                        topfields(field_show_in);
                    }
                    else if (Convert.ToInt32(hdnMenuId.Value) > 123 && Convert.ToInt32(hdnMenuId.Value) < 145)
                    {
                        ViewState["headerRowText"] = headerRowText;
                        ViewState["selval"] = selval;

                        field_show_in = 3;

                        topfields(field_show_in);

                        Session["iterations"] = 2;
                    }
                    else
                    {
                        //lblMessage.Text = selval;
                        field_show_in = 3;
                        int roleid = Convert.ToInt32(Session["Roleid"].ToString());
                        if (roleid == 3)
                        {
                            headerRowText = grv1.Rows[i].Cells[5].Text.Trim();
                            selval = grv1.Rows[i].Cells[6].Text.Trim();

                        }

                        int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                        if (menuid == 189 || menuid == 29) // accepted cases of mobile
                        {
                            field_show_in = 4;

                        }
                      topfields_5(5, selval, headerRowText);
                        grv1.Visible = false;
                       //topfields_3(field_show_in, headerRowText, selval);

                        //break; //comment on 19/03/2025
                    }
                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                //grv1.Visible = true;
              //  lblMessage.Text = "Pending to show dynamic screen ";
            }

        }

        private void ddArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "selected index change";
            DropDownList ddl1 = (DropDownList)sender;
            string ddl_name = ddl1.ID;

            // ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
            if (ddl_name == "ddlTemplate_id")
            {
                String templ_id = ddl1.SelectedValue;
                Session["templ_id"] = templ_id;
                //      lblMessage.Text = ddl1.SelectedValue;
                foreach (Button btn in PlaceholderControls.Controls.OfType<Button>())
                {
                    btn.Visible = true;

                }
                // ddl1.Focus();

                return;
            }

            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                string depend = ddl.Attributes["dependency"];
                string ddlattr = ddl.Attributes["onfocusout"];                   // ["onblur"];
                string depfield = ddl.Attributes["depfield"];
                string checkfld = ddl.Attributes["checkfld"];
                string fldnam = ddl.Attributes["fldnam"];
                string tabnam = ddl.Attributes["tabnam"];
                string labnam = ddl.Attributes["labnam"];
                string ddlname = "ddl" + depfield;
                string ddlnam = ddl.ID;
                if (ddlattr != null)
                {
                    ddlnam = ddl.ID;
                    Session[ddlnam] = ddl.SelectedValue;

                }

                Session[ddlnam] = ddl.SelectedValue;
                if (ddlnam == "ddlclient_id")
                {
                    Session["clientid"] = ddl.SelectedValue; ;
                }
                int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                //if (ddlname == "importtemplatedesign_name" && menuid == 2)  //(for imports)
                //{
                //    lblMessage.Text = "Now create template fields";
                //}
                if (depend == "Y")
                {
                    string tblName = tabnam; // "tbl_mst_centre";
                    string fieldName = fldnam;
                    string labelnames = labnam; // "Centre_name";
                    ddlname = "ddl" + depfield;
                    String where = checkfld + " = " + Session[ddlname].ToString();

                    if (ddlname == "ddlproduct_id" && (menuid == 2 || menuid == 3 || menuid == 4
                         || menuid == 8))  //(for imports and exports)
                    {
                        string client_id = Session["clientid"].ToString();
                        where = where + " and client_id = " + client_id;
                        //        where = where + " and importtemplateassign_client_id = 41";
                    }

                    if (ddl.SelectedValue == "")
                    {
                        Binddata(tblName, ddl, fieldName, labelnames, where);
                    }
                    // lblMessage.Text = "selected is " + Session["ddlzone_id"].ToString();

                }


            }
        }
        protected void FEAutoAssign()
        {
            int ClientID = 0; int FEID = 0;
            int Result = 0;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                // lblMessage.Text += ddl.ID + ","; 
                if (ddl.ID == "ddlclient_id")
                {

                    if (ddl.SelectedValue == "--Select--" || ddl.SelectedValue == "")
                    {
                        lblMessage.Text = "Please select client id";
                        return;
                    }
                    else
                    {
                        //lblMessage.Text += ddl.ID + ",";
                        //lblMessage.Text += ddl.SelectedValue.ToString();
                        ClientID = Convert.ToInt32(ddl.SelectedValue);
                    }
                }
                if (ddl.ID == "ddlempslno")
                {

                    if (ddl.SelectedValue == "--Select--" || ddl.SelectedValue == "")
                    {
                        lblMessage.Text = "Please select an employee";
                        return;
                    }
                    else
                    {
                        //lblMessage.Text += ddl.ID + ",";
                        //lblMessage.Text += ddl.SelectedValue.ToString();
                        FEID = Convert.ToInt32(ddl.SelectedValue);
                    }
                }
            }

            Session["iterations"] = 1;

            lblMessage.Text = "";

            SqlCommand cmd3 = new SqlCommand("SP_GetCaseID_ByFEID_ForAutoAssign", sqlCon);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@FEID", FEID);
            SqlDataAdapter dp1 = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            dp1.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    SqlCommand cmd2 = new SqlCommand("SP_InsertFEAssignment_AutoAssign", sqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@FEID", FEID);
                    cmd2.Parameters.AddWithValue("@CaseID", Convert.ToInt32(dr["case_id"]));
                    cmd2.Parameters.AddWithValue("@ClientID", ClientID);
                    cmd2.Parameters.AddWithValue("@UerId", Convert.ToString(Session["UserID"]));

                    sqlCon.Open();
                    Result = cmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                if (Result > 0)
                {
                    lblMessage.Text = "FE Assignment Done";
                }
            }
            else
            {
                lblMessage.Text = "No Case Found to assign, Please select another FE";
            }
        }

        protected void Exportevent(int menuid)
        {


            int numboxchecked = 0;
            string selected = string.Empty;
            lblMessage.Text = "";
            int field_show_in = 0;
            string message = string.Empty;
            string updatevalue = string.Empty;

            string selval = null;
            string pdfselval = null;
            string caselist = "";
            string pdfcaselist = "";
            string doccaselist = "";


            string Userid = Convert.ToString(Session["UserID"]);
            string Datetime = DateTime.Now.ToString("dd/MM/yyyy_HH");
            //string folderName = "ExportFile\\" + "DataFile_" + Userid + "_" + Datetime;

            string folderName = "ExportFile\\";



            string OriginalDirectoryPath = folderName;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            // string excelchk = Convert.ToString(ViewState["chkexcel"]);
            // newmethod exportexcel


            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {

                //  CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                //CheckBox check1 = (CheckBox)Session["chkexcel"] ;

                //string chkid = check1.ID;

                CheckBox checkExcel = (CheckBox)grv1.Rows[i].FindControl("chkexcel");
                CheckBox checkPDF = (CheckBox)grv1.Rows[i].FindControl("chkPDF");
                CheckBox checkDOC = (CheckBox)grv1.Rows[i].FindControl("chkDOC");


                if (checkExcel.Checked == true)
                {
                    string headerName = grv1.HeaderRow.Cells[5].Text;
                    selval = grv1.Rows[i].Cells[5].Text.Trim();

                    Session["headrow"] = headerName;
                    Session["selval"] = selval;

                    lblMessage.Text += "Case " + selval + "selected";
                    caselist += selval + ',';

                    string hr = Session["headrow"].ToString();
                    string svl = Session["selval"].ToString();

                    numboxchecked = 1;
                    // begin  excelpara

                    List<string> CaseIdList = new List<string>();
                    CaseIdList = caselist.Split(',').ToList();

                    for (int k = 0; k < CaseIdList.Count - 1; k++)
                    {

                        folderName = folderName + CaseIdList[k] + ".xlsx";

                        // if not exist  - go below eelse exit to next case 
                        bool FileExists = File.Exists(Server.MapPath(folderName));

                        if (!FileExists)
                        {

                            sqlCon.Open();
                            SqlCommand cmd2 = new SqlCommand("SP_getexportdata", sqlCon);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@case_id", CaseIdList[k]);
                            cmd2.Parameters.AddWithValue("@menuid", hdnMenuId.Value);
                            cmd2.Parameters.AddWithValue("@userId", Convert.ToInt32(Session["empslno"]));

                            SqlDataReader reader = cmd2.ExecuteReader();

                            //SqlDataAdapter dp = new SqlDataAdapter(cmd2);
                            //DataTable dt = new DataTable();
                            //dp.Fill(dt);

                            // Create Excel package
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                // Add a worksheet
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                                // Add column headers
                                for (int x = 0; x < reader.FieldCount; x++)
                                {
                                    worksheet.Cells[1, x + 1].Value = reader.GetName(x);
                                }

                                // Add data rows
                                int row = 2;
                                while (reader.Read())
                                {
                                    for (int x = 0; x < reader.FieldCount; x++)
                                    {
                                        worksheet.Cells[row, x + 1].Value = reader[x];
                                    }
                                    row++;
                                }

                                // Save the Excel package to a file
                                //package.SaveAs(new System.IO.FileInfo(folderName));

                                package.SaveAs(new System.IO.FileInfo(Server.MapPath(folderName)));
                            }
                            sqlCon.Close();

                            folderName = OriginalDirectoryPath;
                        }
                        else
                        {
                            folderName = OriginalDirectoryPath;
                        }
                    }



                    field_show_in = 3;
                }

                // end  excelpara
                if (checkPDF.Checked == true)
                {


                    string headerName = grv1.HeaderRow.Cells[5].Text;
                    pdfselval = grv1.Rows[i].Cells[5].Text.Trim();

                    Session["headrow"] = headerName;
                    Session["pdfselval"] = pdfselval;

                    lblMessage.Text += "Case " + pdfselval + "selected";
                    pdfcaselist += pdfselval + ',';

                    string hr = Session["headrow"].ToString();
                    string svl = Session["pdfselval"].ToString();

                    numboxchecked = 1;
                    // PDFpara for buidlingand saving pdf

                    List<string> CaseIdList = new List<string>();
                    CaseIdList = selected.Split(',').ToList();

                    lblMessage.Text = pdfcaselist;

                    //for (int k = 0; k < CaseIdList.Count - 1; k++)
                    //{

                    //    folderName = folderName + CaseIdList[k] + ".pdf";

                    //    // if not exist  - go below eelse exit to next case 
                    //    bool FileExists = File.Exists(Server.MapPath(folderName));
                    //    if (!FileExists)
                    //    {
                    //        //generate pdf and save it in folder

                    //        SqlCommand cmd2 = new SqlCommand("SP_getexportdata", sqlCon);
                    //        cmd2.CommandType = CommandType.StoredProcedure;
                    //        cmd2.Parameters.AddWithValue("@case_id", CaseIdList[k]);
                    //        SqlDataReader reader = cmd2.ExecuteReader();
                    //        SqlDataAdapter dp = new SqlDataAdapter(cmd2);
                    //        DataTable dt = new DataTable();
                    //        dp.Fill(dt);

                    //        for (int b = 0; b < dt.Rows.Count; b++)
                    //        {
                    //            string myfile = dt.Rows[i][0] + "_" + DateTime.Now.ToString("ddMMyyyyHHms") + ".pdf";
                    //            DataRow[] dr = dt.Select("Id=" + dt.Rows[b][0]);
                    //            File.WriteAllBytes(Server.MapPath(folderName), ExportToPDF(folderName, dr.CopyToDataTable()));
                    //        }


                    //    }
                    //    else
                    //    {
                    //        folderName = OriginalDirectoryPath;
                    //    }
                    //}

                }
                //PDFpara

            }

            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                ExporteventDownloadFiles(caselist, pdfcaselist);  // copy these files from this folder to temp folder and prepare zip
                grv1.Visible = true;
            }




            // and download to local and delete temp zip

            // for each case selected - we have to update tbl_cases fields: 
            // insert into history - required fields for the case concerned
            // refresh grv1
        }
        protected void ExporteventDownloadFiles(string CaseList, string pdfcaselist)
        {
            string FilePath = string.Empty;
            string Ziptempfolder = string.Empty;

            using (ZipFile zip = new ZipFile())
            {

                Ziptempfolder = "ExportFile\\Ziptempfolder";

                bool folderExists = Directory.Exists(Server.MapPath(Ziptempfolder));

                if (!folderExists)
                {
                    Directory.CreateDirectory(Server.MapPath(Ziptempfolder));
                }

                List<string> CaseIdList = new List<string>();
                CaseIdList = CaseList.Split(',').ToList();

                for (int k = 0; k < CaseIdList.Count - 1; k++)
                {
                    string ZiptempfolderFile = "ExportFile\\Ziptempfolder\\" + CaseIdList[k] + ".xlsx";

                    FilePath = "ExportFile\\" + CaseIdList[k] + ".xlsx";

                    System.IO.File.Copy(Server.MapPath(FilePath), Server.MapPath(ZiptempfolderFile));

                    //File.Copy(Server.MapPath(FilePath), Server.MapPath(Ziptempfolder));
                }


                if (pdfcaselist != "")
                {
                    List<string> PDFCaseList = new List<string>();
                    PDFCaseList = pdfcaselist.Split(',').ToList();

                    for (int k = 0; k < PDFCaseList.Count - 1; k++)
                    {
                        string ZiptempfolderFile = "ExportFile\\Ziptempfolder\\" + PDFCaseList[k] + ".pdf";

                        FilePath = "ExportFile\\" + PDFCaseList[k] + ".pdf";

                        System.IO.File.Copy(Server.MapPath(FilePath), Server.MapPath(ZiptempfolderFile));

                        //File.Copy(Server.MapPath(FilePath), Server.MapPath(Ziptempfolder));
                    }
                }

                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectory(Server.MapPath(Ziptempfolder));
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                System.IO.Directory.Delete(Server.MapPath(Ziptempfolder), true);
                // update tbl_cases; insert into casehitory;
                getgridview_search(Convert.ToString(Session["sesfieldlist"]));
                //     Response.Redirect("Mysample.aspx?menuid=" + "6" + "&menuname= " + "SendToClient" + "&Activityid= " + "13", true);
                Response.End();
            }
        }
        protected void NEXTevent()
        {
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            int field_show_in = 0;
            string headerRowText = "";
            string selval = "";

            if (menuid == 25) // accepted cases of mobile
            {
                field_show_in = 5;

            }
            topfields(5);

            // topfields_3(field_show_in, headerRowText, selval);

        }
        //protected void OnReportClick()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.AddRange(new DataColumn[3] {
        //    new DataColumn("Id"),
        //    new DataColumn("Name"),
        //    new DataColumn("Country") });
        //    dt.Rows.Add(1, "John Hammond", "United States");
        //    dt.Rows.Add(2, "Mudassar Khan", "India");
        //    dt.Rows.Add(3, "Suzanne Mathews", "France");
        //    dt.Rows.Add(4, "Robert Schidner", "Russia");

        //    if (!Directory.Exists(Server.MapPath("~/Files")))
        //    {
        //        Directory.CreateDirectory(Server.MapPath("~/Files"));
        //    }

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string myfile = dt.Rows[i][0] + "_" + DateTime.Now.ToString("ddMMyyyyHHms") + ".pdf";
        //        DataRow[] dr = dt.Select("Id=" + dt.Rows[i][0]);
        //        File.WriteAllBytes(Server.MapPath("~/Files/" + myfile), ExportToPDF(myfile, dr.CopyToDataTable()));
        //    }
        //}

        protected byte[] ExportToPDF(string myfile, DataTable dt)
        {
            GridView GridView1 = new GridView();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            byte[] bytes;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        GridView1.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();
                        bytes = memoryStream.ToArray();
                        memoryStream.Close();
                    }
                }
            }

            return bytes;
        }


        protected void ReDoevent(string Buttonname)
        {

            try
            {

                lblMessage.Text = "";
                string selval = null;
                int numboxchecked = 0;
                string selected = string.Empty;

                for (int i = 0; i <= grv1.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                    if (chkSelect.Checked == true)
                    {
                        string headerName = grv1.HeaderRow.Cells[5].Text;
                        selval = grv1.Rows[i].Cells[5].Text.Trim();

                        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                        SqlCommand cmd = new SqlCommand();
                        sqlCon.Open();

                        cmd.Connection = sqlCon;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.CommandText = "SP_ReDo";
                        cmd.Parameters.AddWithValue("@caseId", selval);
                        cmd.Parameters.AddWithValue("@UserId", Convert.ToString(Session["empslno"]));
                        cmd.Parameters.AddWithValue("@CaesStatus", Buttonname);
                        SqlDataAdapter sda = new SqlDataAdapter();
                        sda.SelectCommand = cmd;

                        int SqlRow = 0;
                        SqlRow = cmd.ExecuteNonQuery();
                        sqlCon.Close();




                        numboxchecked = 1;


                    }
                }
                if (numboxchecked == 0)
                {
                    lblMessage.Text = "Please select one record from the grid";
                }



            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void MoveCaseEvent()
        {
            try
            {
                // checkbox  clicked
                // case ids found
                //for each case - find ouot what is the value of casefor_fe_vendor ( 1 or 2 )
                // update each case with - 1 if 2 and 2 if 1)
                // insert into case history

                int numboxchecked = 0;

                for (int i = 0; i <= grv1.Rows.Count - 1; i++)
                {
                    CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                    if (chkSelect.Checked == true)
                    {
                        string Caseid = grv1.Rows[i].Cells[5].Text.Trim();
                        string CaseStatus = grv1.Rows[i].Cells[14].Text.Trim();
                        string CaseforFeVendor = grv1.Rows[i].Cells[18].Text.Trim();

                        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);


                        SqlCommand cmd2 = new SqlCommand("SP_MoveCases_FE_Vendor", sqlCon);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@CaseID", Caseid);
                        cmd2.Parameters.AddWithValue("@FEVendor", CaseforFeVendor);
                        cmd2.Parameters.AddWithValue("@CaseStatus", CaseStatus);
                        cmd2.Parameters.AddWithValue("@EMP_ID", Convert.ToString(Session["empslno"]));
                        cmd2.Parameters.AddWithValue("@EMP_Name", Convert.ToString(Session["fullName"]));

                        sqlCon.Open();
                        int Result = cmd2.ExecuteNonQuery();
                        sqlCon.Close();

                        numboxchecked = 1;
                    }
                }

                if (numboxchecked == 0)
                {
                    lblMessage.Text = "Please select one record from the grid";
                }
                else
                {
                    getgridview_search("1");
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void QualityCheckEvent()
        {
            // what is the value of qc_type  and qc_reason
            // if any one of this null or 'select' return with message please fill

            string message = "";
            string qc_reason = "";
            string qc_type = "";

            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";

                if (textBox.ID.Substring(3) == "qc_reason")
                {
                    if (textBox.Text is null || textBox.Text == "")
                    {
                        lblMessage.Text = "please fill qc reason";
                        return;
                    }
                    else
                    {
                        qc_reason = textBox.Text;
                    }
                }
            }

            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {

                if (ddl.SelectedValue != "--Select--")
                {
                    lblMessage.Text += ddl.ID.Substring(3) + ",";
                    message += "'" + ddl.SelectedValue + "'" + ",";
                    if (ddl.ID.Substring(3) + "," == "qc_type")
                    {
                        if (ddl.SelectedValue is null)
                            lblMessage.Text = "please fill qc type";
                        return;
                    }
                    else
                    {
                        qc_type = ddl.SelectedValue;
                    }
                }
            }


            string selval = null;
            string caselist = "";
            int numboxchecked = 0;
            string selected = string.Empty;

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked == true)
                {
                    string headerName = grv1.HeaderRow.Cells[5].Text;
                    selval = grv1.Rows[i].Cells[5].Text.Trim();

                    Session["headrow"] = headerName;
                    Session["selval"] = selval;

                    lblMessage.Text += "Case " + selval + "selected";
                    caselist += selval + ',';

                    string hr = Session["headrow"].ToString();
                    string svl = Session["selval"].ToString();
                    numboxchecked = 1;


                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                selected = caselist;
                grv1.Visible = true;
            }


            selected = selected.Remove(selected.Length - 1);

            int Result = 0;

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            List<string> frontendvaluelist = new List<string>();
            frontendvaluelist = selected.Split(',').ToList();

            for (int k = 0; k < frontendvaluelist.Count; k++)
            {
                string caseid = frontendvaluelist[k];

                SqlCommand cmd2 = new SqlCommand("SP_InsertQualityCheck", sqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@CaseID", frontendvaluelist[k]);
                cmd2.Parameters.AddWithValue("@EmpSlno", Convert.ToString(Session["empslno"]));
                cmd2.Parameters.AddWithValue("@EMP_Name", Convert.ToString(Session["fullName"]));

                sqlCon.Open();
                Result = cmd2.ExecuteNonQuery();
                sqlCon.Close();
            }

            if (Result > 0)
            {
                lblMessage.Text = "QC Done";

                getgridview_search("1");
            }

        }
        protected void AddNewEvent()
        {

            PlaceholderControls.Controls.Clear();

            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            String postback = "";
            string validation_req = "";
            string dependentval = "";
            string dependentfield = "";
            string dependentcheckfield = "";
            string WhereIfAny = "";
            string where = "";
            int tno = 0;
            string fieldval = "";


            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                DataTable dt = new DataTable();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = sqlCon;
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.CommandText = "SP_getMasterData";
                cmd1.CommandTimeout = 0;
                cmd1.Parameters.AddWithValue("@menuid", Convert.ToInt32(hdnMenuId.Value));

                SqlDataAdapter sda1 = new SqlDataAdapter();
                sda1.SelectCommand = cmd1;
                sda1.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int reccnt = 0;
                        PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));
                        foreach (DataRow dr in dt.Rows) // do something for each field
                        {
                            reccnt = reccnt + 1;
                            if (reccnt % 2 == 0)    //> 1
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));
                            }

                            inputtype = dr["input_type"].ToString().ToUpper();
                            labelnames = dr["label_name"].ToString();
                            labelnames = labelnames.Replace(" ", "");

                            fieldids = dr["fields_id"].ToString();

                            string maxlength = dr["input_maxLength"].ToString();
                            num = Int32.Parse(dr["input_maxLength"].ToString());
                            tblName = dr["select_table"].ToString();
                            fieldName = dr["field_Name"].ToString();
                            fieldtype = dr["field_type"].ToString();
                            //validation_req = dr["validation_req"].ToString();

                            validation_req = "0";

                            if (inputtype == "INPUTBOX")
                            {


                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;


                                string fldt = fieldidT.ID;

                                fieldval = fieldidT.Text;

                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldval = fieldidT.Text;
                                fieldidT.Attributes.Add("runat", "server");
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + fieldidT.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = fieldidT.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }

                                tno = tno + 1;
                            }
                            if (inputtype == "SELECT")
                            {

                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                ddArea.Attributes.Add("runat", "server");
                                ddArea.Attributes.Add("AutoPostBack", "true");

                                if (postback == "Y")
                                {
                                    ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
                                    ddArea.SelectedIndexChanged += new System.EventHandler(ddArea_SelectedIndexChanged);

                                }

                                ddArea.Attributes.Add("SelectedIndex", "0");
                                if (WhereIfAny == "" || WhereIfAny == null)
                                {
                                    where = "ALL";
                                }
                                else
                                {
                                    where = WhereIfAny;
                                }
                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + ddArea.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = ddArea.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }
                                if (dependentval == "Y")
                                {
                                    ddArea.Attributes.Add("fldnam", fieldName);
                                    ddArea.Attributes.Add("tabnam", tblName);
                                    ddArea.Attributes.Add("labnam", labelnames);

                                    ddArea.Attributes.Add("dependency", dependentval);
                                    ddArea.Attributes.Add("depfield", dependentfield);
                                    ddArea.Attributes.Add("checkfld", dependentcheckfield);


                                }
                                else
                                {
                                    Binddata(tblName, ddArea, fieldName, labelnames, where);
                                }

                                PlaceholderControls.Controls.Add(ddArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }

                        }

                        PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));
                        PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                        Button button = new Button();
                        button.ID = "btn" + "Save";
                        button.Text = "Save";
                        button.BackColor = Color.Blue;
                        button.ForeColor = Color.White;
                        button.Click += new EventHandler(ButtonClickCommonEvent);
                        PlaceholderControls.Controls.Add(button);
                        PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                        PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                        PlaceholderControls.Controls.Add(new LiteralControl("</tr>"));

                    }
                    //PlaceholderControls.Controls.Clear();
                    Session["iterations"] = 8;
                    //Session["fieldshowin"] = 4;
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void SaveMaster()
        {
            int sesit = 0;
            string message = "";
            lblMessage.Text = "";
            string updatevalue = "";
            //int Client_id = Convert.ToInt32(ViewState["ClientId"]);
            //int productid = Convert.ToInt32(ViewState["ProductId"]);
            //int veriftypeid = Convert.ToInt32(ViewState["VeriftypeId"]);
            //int caseforid = Convert.ToInt32(ViewState["caseforid"]);
            //int zoneid = Convert.ToInt32(ViewState["zoneid"]);
            //int centreid = Convert.ToInt32(ViewState["centreid"]);
            //int subcentreid = Convert.ToInt32(ViewState["subcentreid"]);


            //if (hdnMenuId.Value != "19")
            //{
            //    if (sesit != 9)
            //    {

            //        lblMessage.Text += "Client_id" + ",";
            //        message += "'" + Client_id + "'" + ",";
            //        updatevalue += "Client_id" + "=" + "'" + Client_id + "'" + ",";


            //        lblMessage.Text += "product_id" + ",";
            //        message += "'" + productid + "'" + ",";
            //        updatevalue += "product_id" + "=" + "'" + productid + "'" + ",";


            //        lblMessage.Text += "veriftype_id" + ",";
            //        message += "'" + veriftypeid + "'" + ",";
            //        updatevalue += "veriftype_id" + "=" + "'" + veriftypeid + "'" + ",";


            //        lblMessage.Text += "casefor_id" + ",";
            //        message += "'" + caseforid + "'" + ",";
            //        updatevalue += "casefor_id" + "=" + "'" + caseforid + "'" + ",";


            //        lblMessage.Text += "zone_id" + ",";
            //        message += "'" + zoneid + "'" + ",";
            //        updatevalue += "zone_id" + "=" + "'" + zoneid + "'" + ",";


            //        lblMessage.Text += "centre_id" + ",";
            //        message += "'" + centreid + "'" + ",";
            //        updatevalue += "centre_id" + "=" + "'" + centreid + "'" + ",";

            //        lblMessage.Text += "subcentre_id" + ",";
            //        message += "'" + subcentreid + "'" + ",";
            //        updatevalue += "subcenter_id" + "=" + "'" + subcentreid + "'" + ",";
            //    }

            //}

            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";
                updatevalue += textBox.ID.Substring(3) + "=" + "'" + textBox.Text + "'" + ",";

            }


            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {

                if (ddl.SelectedValue != "--Select--")
                {
                    lblMessage.Text += ddl.ID.Substring(3) + ",";
                    message += "'" + ddl.SelectedValue + "'" + ",";
                    updatevalue += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
                }
            }



            foreach (CheckBox chk in PlaceholderControls.Controls.OfType<CheckBox>())
            {
                lblMessage.Text += chk.ID.Substring(3) + ",";
                message += "'" + chk.Checked + "'" + ",";
                updatevalue += chk.ID.Substring(3) + "=" + "'" + chk.Checked + "'" + ",";
            }


            foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
            {
                lblMessage.Text += fup.ID.Substring(3) + ",";
                message += "'" + fup.FileName + "'" + ",";
                updatevalue += fup.ID.Substring(3) + "=" + "'" + fup.FileName + "'" + ",";


                string strname = fup.FileName.ToString();

                if (strname != "")
                {
                    fup.PostedFile.SaveAs(Server.MapPath("~/UploadedImages/") + strname);
                }
            }
            //      lblMessage.Text = ddl1.SelectedValue;

            foreach (Button btn in PlaceholderControls.Controls.OfType<Button>())
            {
                btn.Visible = false;

            }

            // ==================================
            string hr = "";
            int svl = 0;
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);

            int activityid = Convert.ToInt32(Session["ActivityId"].ToString());

            int selval = Convert.ToInt32(ViewState["selval"]);
            string headerRowText = Convert.ToString(ViewState["headerRowText"]);

            String valforupdate = "";
            String tosendtosql = "";
            String valtosendtosql = "";

            if (selval != 0)
            {
                sesit = 1;
            }

            if (sesit == 1)
            {
                hr = Convert.ToString(ViewState["headerRowText"]);
                svl = Convert.ToInt32(ViewState["selval"]);

                valforupdate = updatevalue.TrimEnd(',');

                string hrv = hr + "='" + svl + "'";

                valforupdate = valforupdate.Replace(hrv, "");

                valforupdate = valforupdate.TrimEnd(',');

                bool result = valforupdate.Contains("case_id");
                if (result == true)
                {
                    valforupdate = valforupdate.Substring(valforupdate.IndexOf(',') + 1);
                }
                valforupdate = valforupdate.TrimStart(',');
                valtosendtosql = valforupdate;
                tosendtosql = "x";
            }
            else
            {
                hr = "0";
                svl = 0;
                tosendtosql = lblMessage.Text.TrimEnd(',');
                //  int indval = tosendtosql.IndexOf(',') + 1;
                // if first field is case id the second line should be used
                //  tosendtosql = tosendtosql.Substring(tosendtosql.IndexOf(',') + 1);
                valtosendtosql = message.TrimEnd(',');
                //   valtosendtosql = valtosendtosql.Substring(valtosendtosql.IndexOf(',') + 1);

                //tosendtosql = tosendtosql + ", activity_id,country_id,template_id";
                //valtosendtosql = valtosendtosql + "," + Convert.ToString(Session["ActivityId"]) + ",11," + Convert.ToString(ViewState["global_template_id"]);
            }


            //if (sesit == 1)
            //{
            //    string[] values = valtosendtosql.Split(',');
            //    valtosendtosql = "";
            //    string finalValue = string.Empty;

            //    for (int i = 1; i < values.Length; i++)
            //    {
            //        valtosendtosql += "'" + values[i] + "'" + ",";
            //    }

            //    valtosendtosql = valtosendtosql.TrimEnd(',');
            //}

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            //tosendtosql = tosendtosql.Replace("case_for_fe_vendor", "casefor_id").Replace("subcentre_id", "subcenter_id");

            //valtosendtosql = valtosendtosql.Replace("case_for_fe_vendor", "casefor_id").Replace("subcentre_id", "subcenter_id");




            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_SaveMaster";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@menuid", menuid);
                    cmd.Parameters.AddWithValue("@activityid", activityid);
                    cmd.Parameters.AddWithValue("@headrow", hr);
                    cmd.Parameters.AddWithValue("@selval", svl);
                    cmd.Parameters.AddWithValue("@sessit", sesit);
                    cmd.Parameters.AddWithValue("@userid", Convert.ToString(Session["empslno"]));
                    cmd.Parameters.AddWithValue("@fieldlist", tosendtosql);
                    cmd.Parameters.AddWithValue("@fieldvalue", valtosendtosql);


                    sqlCon.Open();
                    int SqlRow = 0;
                    SqlRow = cmd.ExecuteNonQuery();
                    sqlCon.Close();

                }
                Session["iterations"] = 0;
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void getotherdetailsfromMenu()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_getotherdetailsfromMenu";
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@menuid", Convert.ToInt32(hdnMenuId.Value));
            DataSet ds = new DataSet();
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            dp.Fill(ds);

            if (ds != null)
            {
                Session["assignverificationYesNo"] = ds.Tables[0].Rows[0]["assign_verification_YesNo"].ToString();
                Session["ReportYesNo"] = ds.Tables[0].Rows[0]["Report_YesNo"].ToString();
            }
        }
        protected void importFEPayOut()
        {
            try
            {
                string FileUploadName = "";
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                int TemplateColumnCount = 8;
                int Result = 0;

                int menuid = Convert.ToInt32(hdnMenuId.Value);


                DateTime ReceivedDate = DateTime.Now;
                string Receivedtime = string.Empty;

                foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
                {
                    FileUploadName = fup.FileName;
                }
                if (FileUploadName != "" && FileUploadName != null)
                {
                    lblMessage.Text = "";

                    string excelPath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(FileUploadName);
                    string fileName = Path.GetFileNameWithoutExtension(excelPath);
                    string fileExtension = Path.GetExtension(excelPath);

                    string datetime = DateTime.Now.ToString("yyyy-MM-dd HH mm ss");

                    string newxlsfilename = "PO_" + datetime + fileExtension;

                    newxlsfilename = excelPath.Replace(Path.GetFileName(FileUploadName), newxlsfilename);

                    if (fileExtension.ToUpper() == ".XLS" || fileExtension.ToUpper() == ".XLSX")
                    {

                        foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
                        {
                            fup.SaveAs(newxlsfilename);
                        }

                        ImportExcel ie = new ImportExcel();
                        DataTable dt = new DataTable();
                        DataSet ds = ie.ExcelDataReader(newxlsfilename);

                        if (ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int colCount = dt.Columns.Count;

                            if (colCount != TemplateColumnCount)
                            {
                                lblMessage.Text = "Uploaded Excel and Template Column Count Mismatch";

                                return;
                            }

                            string[] Columns = { "Case ID", "Incentive", "BOCL Amount", "Penality", "BOCL Client rate", "Remarks", "Invoice", "Voucher Status" };

                            int i = 0;
                            foreach (var col in Columns)
                            {
                                if (Columns[i] != Convert.ToString(dt.Columns[i].ColumnName))
                                {
                                    lblMessage.Text = Columns[i] + "!=" + Convert.ToString(dt.Columns[i].ColumnName)
                                      + "  Uploaded Excel Not As Per Standard Format Column Name Mismatch";

                                    return;
                                }
                                i++;
                            }


                            DataColumn newColumn = new DataColumn("CreatedBy", typeof(System.String));
                            newColumn.DefaultValue = Convert.ToString(Session["empslno"]);
                            dt.Columns.Add(newColumn);

                            dt.AcceptChanges();

                            foreach (DataRow row in dt.Rows)
                            {
                                SqlCommand cmd = new SqlCommand("SP_insert_fe_payout_casewise", sqlCon);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@menuid", Convert.ToInt32(hdnMenuId.Value));
                                cmd.Parameters.AddWithValue("@CaseID", Convert.ToString(row["Case ID"]).Normalize());
                                cmd.Parameters.AddWithValue("@Incentive", Convert.ToString(row["Incentive"]).Normalize());
                                cmd.Parameters.AddWithValue("@BOCLAmount", Convert.ToString(row["BOCL Amount"]).Normalize());
                                cmd.Parameters.AddWithValue("@Penality", Convert.ToString(row["Penality"]).Normalize());
                                cmd.Parameters.AddWithValue("@BOCLClientRate ", Convert.ToString(row["BOCL Client rate"]).Normalize());
                                cmd.Parameters.AddWithValue("@Remarks", Convert.ToString(row["Remarks"]).Normalize());
                                cmd.Parameters.AddWithValue("@Invoice", Convert.ToString(row["Invoice"]).Normalize());
                                cmd.Parameters.AddWithValue("@VoucherStatus", Convert.ToString(row["Voucher Status"]).Normalize());
                                cmd.Parameters.AddWithValue("@employeeid", Convert.ToString(row["CreatedBy"]).Normalize());

                                sqlCon.Open();
                                Result = cmd.ExecuteNonQuery();
                                sqlCon.Close();
                            }
                            if (Result > 0)
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Error:" + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void CaseDelete()
        {

            string selval = "";
            int numboxchecked = 0;

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {
                    string headerName = grv1.HeaderRow.Cells[5].Text;
                    selval = grv1.Rows[i].Cells[5].Text.Trim();


                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    SqlCommand cmd2 = new SqlCommand("SP_Delete", sqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Caseid", selval);
                    cmd2.Parameters.AddWithValue("@empslno", Convert.ToString(Session["empslno"]));
                    cmd2.Parameters.AddWithValue("@fullName", Convert.ToString(Session["fullName"]));

                    sqlCon.Open();
                    int Result = cmd2.ExecuteNonQuery();
                    sqlCon.Close();

                    if (Result > 0)
                    {
                        //lblMessage.Text += "FE Assignment Done for " + selval;
                    }


                    numboxchecked = 1;

                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                //getgridview_search("1");
                grv1.Visible = true;
            }
        }
        protected void RestoreSelectedCases()
        {
            string selval = "";
            int numboxchecked = 0;

            for (int i = 0; i <= grv1.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                if (chkSelect.Checked == true)
                {
                    string headerName = grv1.HeaderRow.Cells[5].Text;
                    selval = grv1.Rows[i].Cells[5].Text.Trim();


                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    SqlCommand cmd2 = new SqlCommand("SP_Restore", sqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Caseid", selval);
                    cmd2.Parameters.AddWithValue("@empslno", Convert.ToString(Session["empslno"]));
                    cmd2.Parameters.AddWithValue("@fullName", Convert.ToString(Session["fullName"]));

                    sqlCon.Open();
                    int Result = cmd2.ExecuteNonQuery();
                    sqlCon.Close();

                    if (Result > 0)
                    {
                        //lblMessage.Text += "FE Assignment Done for " + selval;
                    }


                    numboxchecked = 1;

                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                // getgridview_search("1");
                grv1.Visible = true;
            }
        }

        protected void ddAreas_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Binddata("tbl_mst_centre", ddlCenterNew, "centre_id", "centre_name", "ALL");


            if (ddAreas.SelectedValue != "--Select--")
            {
                string where = "centre_cluster_id = " + ddAreas.SelectedValue;

                Binddata("tbl_mst_centre", ddlCenterNew, "centre_id", "centre_name", where);
            }
            else
            {
                ddlCenterNew.DataSource = null;
                ddlCenterNew.DataBind();

                ddlsubcenternew.DataSource = null;
                ddlsubcenternew.DataBind();
            }
        }

        protected void ddlCenterNew_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Binddata("tbl_mst_subcentre", ddlsubcenternew, "subcentre_id", "subcentre_name", "ALL");

            if (ddAreas.SelectedValue != "--Select--" && ddlCenterNew.SelectedValue != "--Select--")
            {
                string where = "subcentre_cluster_id = " + ddAreas.SelectedValue + " and subcentre_centre_id = " + ddlCenterNew.SelectedValue;

                Binddata("tbl_mst_subcentre", ddlsubcenternew, "subcentre_id", "subcentre_name", where);
            }
            else
            {
                ddlsubcenternew.DataSource = null;
                ddlsubcenternew.DataBind();
            }
        }

       
    }
}












