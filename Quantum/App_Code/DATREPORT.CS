using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections;

/// <summary>

/// Summary description for DAT_ENTRY
/// </summary>
/// 
public class DATREPORT
{
    CCommon con = new CCommon();
    DataSet ds = new DataSet();


    private string sFromDt;
    public string FromDt
    {
        get { return sFromDt; }
        set { sFromDt = value; }
    }

    private string SToDt;
    public string ToDt
    {
        get { return SToDt; }
        set { SToDt = value; }
    }


    public DATREPORT()
    {
       
    }

    public OleDbDataReader Fill_RoleDropDown(string strFillDropDown)
    {
        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strFillDropDown);
        return dr;
    }

    public OleDbDataReader Fill_Centre()
    {
        OleDbDataReader dr;
        string sqlStr = "";
        sqlStr = " select  centre_id,centre_name from centre_master order by centre_name ";
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sqlStr);
        return dr;
    }

    public OleDbDataReader Fill_CentrewithClusterID(string strFillDependentDropDown)
    {
        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strFillDependentDropDown);
        return dr;
    }
    
    public OleDbDataReader Fill_Sub_Centre(String Centreid)
    {
        OleDbDataReader Subcentredr;
        string sqlStr = "";
        sqlStr = " select subcentreid,subcentrename from subcentremaster where centreid=" + Centreid + " order by subcentrename ";
        Subcentredr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, sqlStr);
        return Subcentredr;
    }

    public string ShowSubCenterData(string SubcenterId)
    {
        OleDbDataReader subcenterDr;
        string strRetID = "";
        string strSubCenter = "";

        strSubCenter += " select subcentreid,subcentrename from subcentremaster where subcentreid in (select subcentre_id from employee_master where emp_id='" + SubcenterId + "') ";
        subcenterDr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strSubCenter);

        if (subcenterDr.HasRows)
        {
            while (subcenterDr.Read())
            {
                strRetID = subcenterDr["SubCentreId"].ToString() + ',' + subcenterDr["subcentrename"].ToString();
            }
        }

        return strRetID;

    }
    public string ShowClusterData(string UserId)
    {
        OleDbDataReader subcenterDr;
        string strRetID = "";
        string strSubCenter = "";

        strSubCenter += "select Cluster_id from Centre_master where centre_id in (select centre_id from employee_master where emp_id='" + UserId + "') ";
        subcenterDr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strSubCenter);

        if (subcenterDr.HasRows)
        {
            while (subcenterDr.Read())
            {
                strRetID = subcenterDr["Cluster_id"].ToString();
            }
        }

        return strRetID;

    }

    public OleDbDataReader ShowEmployeedata(string Centreid, String Subcentreid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strOrderclause = " ORDER BY a.FULLNAME ";

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        strEmp += " select distinct a.emp_code,a.fullname,b.centre_name,c.subcentrename, ";
        strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
        strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('A')) as ABSENT,";
        strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
        strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('P')) as PRESENT";
        strEmp += " from employee_master a,";
        strEmp += " centre_master b,subcentremaster c where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
        strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
        strEmp += " and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
        return Empdr;
    }

    public OleDbDataReader ShowEmplSalaryStatus(string Centreid, String Subcentreid, String ReportType)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strOrderclause = " ORDER BY a.FULLNAME ";

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        if (ReportType == "With Data")
        {
            strEmp += " select distinct a.emp_code,a.fullname,b.centre_name,c.subcentrename,a.suvidha_ac,'' as Category,a.unit,a.company_id,'' as  ARemark,'' as SPAllowance ,";

            strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
            strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('A')) as ABSENT,";
            strEmp += " (select count(*) from datily_attendance d where a.emp_id=d.emp_id ";
            strEmp += " and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and d.attendance in('P')) as PRESENT,";

            strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
            strEmp += " 0 as  Deduction,'' as Dremarks,e.department ";
            strEmp += " from employee_master a,";
            strEmp += " centre_master b,subcentremaster c,department_master e where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
            strEmp += " and e.dept_id=a.department_id  " + strCentre + "   and upper(a.APPROVED_BY_HOHR)='Y' " + strSubcentre + " ";
            strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null)  " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            return Empdr;
        }
        else
        {
            strEmp += " select distinct a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";
            strEmp += " 0 as ABSENT,";
            strEmp += " 0 as PRESENT,";

            strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
            strEmp += " '' as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master a,";
            strEmp += " centre_master b,subcentremaster c where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
            strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
            strEmp += " " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            return Empdr;
        }
    }
    
    //public OleDbDataReader ShowRolewiseEmplSalaryStatus(string Centreid, String Subcentreid, String ReportType, String Clusterid)
    //{
    //    OleDbDataReader Empdr;
    //    string strEmp = "";
    //    string strSubcentre = "";
    //    string strCentre = "";
    //    string strCluster = "";
    //    string strOrderclause = " ORDER BY Emp_Mst.emp_code desc";

    //    if (Clusterid != "")
    //    {
    //       strCluster = " and Cent_Mst.cluster_id= " + Clusterid + " ";
    //    }

    //    if (Centreid != "")
    //    {

    //        strCentre = " and Emp_Mst.centre_id=" + Centreid + " ";
    //    }
    //    else
    //    {
    //    }

    //    if (Subcentreid != "")
    //    {
    //        strSubcentre = " and Emp_Mst.subcentre_id=" + Subcentreid + " ";
    //    }


    //    if (ReportType == "Client Report")
    //    {

    //        strEmp += " select Emp_Mst.fullname,Emp_Mst.emp_code,centre_name,subcentrename,CTC As department, ";
    //        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
    //        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
    //        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " left outer join centre_master Cent_Mst";           
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join datily_attendance Dat_Att";
    //        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        strEmp += "  Inner join TSfSalaryInfo TSI on Emp_Mst.emp_id=TSI.emp_id";
    //        strEmp += " where 1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  " + strOrderclause + "  ";
    //        //strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
           
    //    }
    //    else
    //    {
    //        strEmp += " select fullname,emp_code,centre_name,subcentrename,department,";
    //        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
    //        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
    //        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join datily_attendance Dat_Att";
    //        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        strEmp += " where  " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);


    //    }
    //    return Empdr;
        
    //}

    //add by Rani

    public OleDbDataReader ShowRolewiseEmplSalaryStatus(string Centreid, String Subcentreid, String ReportType, String Clusterid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strCluster = "";
        string strOrderclause = " ORDER BY Emp_Mst.emp_code desc";

        if (Clusterid != "")
        {
            strCluster = " and Cent_Mst.cluster_id= " + Clusterid + " ";
        }

        if (Centreid != "")
        {

            strCentre = " and Emp_Mst.centre_id=" + Centreid + " ";
        }
        else
        {
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and Emp_Mst.subcentre_id=" + Subcentreid + " ";
        }



        if (ReportType == "Client Report")
        {

            strEmp += " select Emp_Mst.fullname,Emp_Mst.emp_code,centre_name,subcentrename,department As department, ";
            strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
            strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
            strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' when 'L' then 'L'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
            strEmp += " left outer join datily_attendance Dat_Att";
            strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            //strEmp += "  Inner join TSfSalaryInfo TSI on Emp_Mst.emp_id=TSI.emp_id";
            strEmp += " where 1=1 ";// +strCluster + "  " + strCentre + " " + strSubcentre + " ";
            // strEmp += " and (dol>= '" + FromDt + "' or dol is null) and LD.Login_Datetime between '" + FromDt + "'  and  '" + ToDt + "'  " + strOrderclause + "  ";
            strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "' " + strOrderclause + "  "; //and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
            //strEmp += " select Emp_Mst.fullname,Emp_Mst.emp_code,centre_name,subcentrename,department As department, ";
            //strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
            //strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
            //strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
            //strEmp += " from employee_master Emp_Mst";
            //strEmp += " left outer join centre_master Cent_Mst";
            //strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            //strEmp += " left Outer join subcentremaster Sub_Mst";
            //strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
            //strEmp += " left outer join datily_attendance Dat_Att";
            //strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
            //strEmp += " left outer join department_master Dep_Mst";
            //strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            ////strEmp += "  Inner join TSfSalaryInfo TSI on Emp_Mst.emp_id=TSI.emp_id";
            //strEmp += " where 1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
            //// strEmp += " and (dol>= '" + FromDt + "' or dol is null) and LD.Login_Datetime between '" + FromDt + "'  and  '" + ToDt + "'  " + strOrderclause + "  ";
            //strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "' and   " + strOrderclause + "  "; //and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        }
        else if (ReportType == "Password Updation Report")
        {
            int Todate = Convert.ToInt16(ToDt.Substring(0, 2)) + 1;
            int i = ToDt.Length;
            string month = ToDt.Substring(2, 9);
            strEmp += " select  Emp_Mst.Emp_Code as [Emp_Code], ";
            strEmp += " Emp_Mst.FullName as [Emp Name],";
            strEmp += " Cent_Mst.Centre_Name as [Location],";
            strEmp += " Sub_Mst.subcentrename as [Sub Location],";
            strEmp += " Dep_Mst.department as [Department Name],";
            strEmp += " convert(varchar(10), CONVERT(datetime,Um.Last_Reset_date,106), 103) +' '+ right(convert(varchar(32), Um.Last_Reset_date,100),8)  as [Password Change Date] ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " inner join  user_master Um  ";
            strEmp += " on Emp_Mst.Emp_id = Um.UserId";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";

            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            strEmp += " where  1=1 ";// +strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and Um.Last_Reset_date between '" + FromDt + "'  and  '" + Todate + month + "' ORDER BY Um.Last_Reset_date desc ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);


        }

        else if (ReportType == "Login Tracker")
        {
            int Todate = Convert.ToInt16(ToDt.Substring(0, 2)) + 1;
            int i = ToDt.Length;
            string month = ToDt.Substring(2, 9);
            strEmp += " select  Emp_Mst.Emp_Code as [Emp_Code],";
            strEmp += " Emp_Mst.FullName as [Emp Name],";
            strEmp += " Cent_Mst.Centre_Name as [Location],";
            strEmp += " Sub_Mst.subcentrename as [Sub Location],";
            strEmp += " Dep_Mst.Department as [Department Name],";
            strEmp += " convert(varchar(10), CONVERT(datetime,LD.Login_Datetime,106), 103) +' '+ right(convert(varchar(32), LD.Login_Datetime,100),8)  as [Login Date & Time] ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " inner join LOGIN_DETAIL LD ";
            strEmp += " on Emp_Mst.Emp_Id=LD.Login_Id  ";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            strEmp += " where  1=1 ";// +strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and LD.Login_Datetime between '" + FromDt + "'  and  '" + Todate + month + "' order by  LD.Login_Datetime desc ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        }

        else
        {
            strEmp += " select fullname,emp_code,centre_name,subcentrename,department,";
            strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
            strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
            strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
            strEmp += " left outer join datily_attendance Dat_Att";
            strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            strEmp += " where  1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);


        }
        return Empdr;

    }



    //public OleDbDataReader ShowRolewiseEmplSalaryStatus_Client(string Centreid, String Subcentreid, String ReportType, String Clusterid)
    //{
    //    OleDbDataReader Empdr;
    //    string strEmp = "";
    //    string strSubcentre = "";
    //    string strCentre = "";
    //    string strCluster = "";
    //    string strOrderclause = " ORDER BY Emp_Mst.emp_code,Sub_Mst.Centreid ";

    //    if (Clusterid != "")
    //    {
    //        strCluster = " and Cent_Mst.cluster_id= " + Clusterid + " ";
    //    }

    //    if (Centreid != "")
    //    {

    //        strCentre = " and Emp_Mst.centre_id=" + Centreid + " ";
    //    }
    //    else
    //    {
    //    }

    //    if (Subcentreid != "")
    //    {
    //        strSubcentre = " and Emp_Mst.subcentre_id=" + Subcentreid + " ";
    //    }

        
    //    if (ReportType == "Client Report")
    //    {
          
    //        strEmp += " select Distinct fullname,emp_code,centre_name,subcentrename,department,";
    //        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
    //        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
    //        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join datily_attendance Dat_Att";
    //        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        //strEmp += " where 1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " where (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

    //    }
    //    else
    //    {
    //        strEmp += " select fullname,emp_code,centre_name,subcentrename,department,";
    //        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
    //        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
    //        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join datily_attendance Dat_Att";
    //        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        strEmp += " where  " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

    

    //    }
    //    return Empdr;

    //}

    //add by Rani

    //public OleDbDataReader ShowRolewiseEmplSalaryStatus_Client(string Centreid, String Subcentreid, String ReportType, String Clusterid )
    //{
    //    OleDbDataReader Empdr;
    //    string strEmp = "";
    //    string strSubcentre = "";
    //    string strCentre = "";
    //    string strCluster = "";
    //    string strOrderclause = " ORDER BY Emp_Mst.emp_code,Sub_Mst.Centreid ";

    //    if (Clusterid != "")
    //    {
    //        strCluster = " and Cent_Mst.cluster_id= " + Clusterid + " ";
    //    }

    //    if (Centreid != "")
    //    {

    //        strCentre = " and Emp_Mst.centre_id=" + Centreid + " ";
    //    }
    //    else
    //    {
    //    }

    //    if (Subcentreid != "")
    //    {
    //        strSubcentre = " and Emp_Mst.subcentre_id=" + Subcentreid + " ";
    //    }


    //    if (ReportType == "Client Report")
    //    {

    //        strEmp += " select Distinct fullname,emp_code,centre_name,subcentrename,department,";
    //        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
    //        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
    //        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' when 'L' then 'L' end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join datily_attendance Dat_Att";
    //        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        //strEmp += " where 1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " where (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'";
    //        //strEmp+= " and rm_empcode=(select  Emp_code from employee_master where emp_id= "+ +")";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

    //    }
    //    else if (ReportType == "Password Updation Report")
    //    {
    //        int Todate = Convert.ToInt16(ToDt.Substring(0, 2)) + 1;
    //        int i = ToDt.Length;
    //        string month = ToDt.Substring(2, 9);
    //        strEmp += " select  Emp_Mst.Emp_Code as [Emp_Code], ";
    //        strEmp += " Emp_Mst.FullName as [Emp Name],";
    //        strEmp += " Cent_Mst.Centre_Name as [Location],";
    //        strEmp += " Sub_Mst.subcentrename as [Sub Location],";
    //        strEmp += " Dep_Mst.department as [Department Name],";
    //        strEmp += " convert(varchar(10), CONVERT(datetime,Um.Last_Reset_date,106), 103) +' '+ right(convert(varchar(32), Um.Last_Reset_date,100),8)  as [Password Change Date] ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " inner join  user_master Um  ";
    //        strEmp += " on Emp_Mst.Emp_id = Um.UserId";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";

    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        strEmp += " where  1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " and Um.Last_Reset_date between '" + FromDt + "'  and  '" + Todate + month + "' ORDER BY Um.Last_Reset_date desc ";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);


    //    }

    //    else if (ReportType == "Login Tracker")
    //    {
    //        int Todate = Convert.ToInt16(ToDt.Substring(0, 2)) + 1;
    //        int i = ToDt.Length;
    //        string month = ToDt.Substring(2, 9);
    //        strEmp += " select  Emp_Mst.Emp_Code as [Emp_Code],";
    //        strEmp += " Emp_Mst.FullName as [Emp Name],";
    //        strEmp += " Cent_Mst.Centre_Name as [Location],";
    //        strEmp += " Sub_Mst.subcentrename as [Sub Location],";
    //        strEmp += " Dep_Mst.Department as [Department Name],";
    //        strEmp += " convert(varchar(10), CONVERT(datetime,LD.Login_Datetime,106), 103) +' '+ right(convert(varchar(32), LD.Login_Datetime,100),8)  as [Login Date & Time] ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " inner join LOGIN_DETAIL LD ";
    //        strEmp += " on Emp_Mst.Emp_Id=LD.Login_Id  ";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        strEmp += " where  1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " and LD.Login_Datetime between '" + FromDt + "'  and  '" + Todate + month + "' order by  LD.Login_Datetime desc ";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

    //    }
    //    else
    //    {
    //        strEmp += " select fullname,emp_code,centre_name,subcentrename,department,";
    //        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
    //        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
    //        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
    //        strEmp += " from employee_master Emp_Mst";
    //        strEmp += " left outer join centre_master Cent_Mst";
    //        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
    //        strEmp += " left Outer join subcentremaster Sub_Mst";
    //        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
    //        strEmp += " left outer join datily_attendance Dat_Att";
    //        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
    //        strEmp += " left outer join department_master Dep_Mst";
    //        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
    //        strEmp += " where  " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
    //        strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
    //        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);



    //    }
    //    return Empdr;

    //}
    /// <summary>
    /// added on 25 march 2015 for rm and rsm report filtering 
    /// </summary>
    /// <param name="Centreid"></param>
    /// <param name="Subcentreid"></param>
    /// <param name="ReportType"></param>
    /// <param name="Clusterid"></param>
    /// <param name="RmempId"></param>
    /// <param name="RsmempId"></param>
    /// <returns></returns>

    public OleDbDataReader ShowRolewiseEmplSalaryStatus_Client(string Centreid, String Subcentreid, String ReportType, String Clusterid, string RmempId, string RsmempId)
    {
        OleDbDataReader Empdr = null;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        string strCluster = "";
        string strRmempid = "";
        string strRsmempid = "";

        string strOrderclause = " ORDER BY Emp_Mst.emp_code,Sub_Mst.Centreid ";

        if (Clusterid != "")
        {
            strCluster = " and Cent_Mst.cluster_id= " + Clusterid + " ";
        }

        if (Centreid != "")
        {

            strCentre = " and Emp_Mst.centre_id=" + Centreid + " ";
        }
        else
        {
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and Emp_Mst.subcentre_id=" + Subcentreid + " ";
        }
        if (RmempId != "")
        {
            strRmempid = " and Emp_Mst.Rm_empcode =(select Emp_code from employee_master where emp_id = " + RmempId + ")";
        }
        else if (RsmempId != null)
        {
            strRsmempid = " and Emp_Mst.RSm_empcode =(select Emp_code from employee_master where emp_id = " + RsmempId + ")";
        }


        if (ReportType == "Client Report")
        {
            if (RmempId != "")
            {
                strEmp += " select Distinct fullname,emp_code,centre_name,subcentrename,department,";
                strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
                strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
                strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' when 'L' then 'L' end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
                strEmp += " from employee_master Emp_Mst";
                strEmp += " left outer join centre_master Cent_Mst";
                strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
                strEmp += " left Outer join subcentremaster Sub_Mst";
                strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
                strEmp += " left outer join datily_attendance Dat_Att";
                strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
                strEmp += " left outer join department_master Dep_Mst";
                strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
                //strEmp += " where 1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
                strEmp += " where (dol>= '" + FromDt + "' or dol is null)  " + strRmempid + " and date between '" + FromDt + "'  and  '" + ToDt + "'";
                //strEmp+= " and rm_empcode=(select  Emp_code from employee_master where emp_id= "+ +")";
                Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            }
            else if (RsmempId != null)
            {
                strEmp += " select Distinct fullname,emp_code,centre_name,subcentrename,department,";
                strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
                strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
                strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' when 'L' then 'L' end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
                strEmp += " from employee_master Emp_Mst";
                strEmp += " left outer join centre_master Cent_Mst";
                strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
                strEmp += " left Outer join subcentremaster Sub_Mst";
                strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
                strEmp += " left outer join datily_attendance Dat_Att";
                strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
                strEmp += " left outer join department_master Dep_Mst";
                strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
                //strEmp += " where 1=1 " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
                strEmp += " where (dol>= '" + FromDt + "' or dol is null)  " + strRsmempid + " and date between '" + FromDt + "'  and  '" + ToDt + "'";
                //strEmp+= " and rm_empcode=(select  Emp_code from employee_master where emp_id= "+ +")";
                Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
            }

        }
        else if (ReportType == "Password Updation Report")
        {
            int Todate = Convert.ToInt16(ToDt.Substring(0, 2)) + 1;
            int i = ToDt.Length;
            string month = ToDt.Substring(2, 9);
            strEmp += " select  Emp_Mst.Emp_Code as [Emp_Code], ";
            strEmp += " Emp_Mst.FullName as [Emp Name],";
            strEmp += " Cent_Mst.Centre_Name as [Location],";
            strEmp += " Sub_Mst.subcentrename as [Sub Location],";
            strEmp += " Dep_Mst.department as [Department Name],";
            strEmp += " convert(varchar(10), CONVERT(datetime,Um.Last_Reset_date,106), 103) +' '+ right(convert(varchar(32), Um.Last_Reset_date,100),8)  as [Password Change Date] ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " inner join  user_master Um  ";
            strEmp += " on Emp_Mst.Emp_id = Um.UserId";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";

            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            strEmp += " where  1=1 ";// +strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and Um.Last_Reset_date between '" + FromDt + "'  and  '" + Todate + month + "' ORDER BY Um.Last_Reset_date desc ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);


        }

        else if (ReportType == "Login Tracker")
        {
            int Todate = Convert.ToInt16(ToDt.Substring(0, 2)) + 1;
            int i = ToDt.Length;
            string month = ToDt.Substring(2, 9);
            strEmp += " select  Emp_Mst.Emp_Code as [Emp_Code],";
            strEmp += " Emp_Mst.FullName as [Emp Name],";
            strEmp += " Cent_Mst.Centre_Name as [Location],";
            strEmp += " Sub_Mst.subcentrename as [Sub Location],";
            strEmp += " Dep_Mst.Department as [Department Name],";
            strEmp += " convert(varchar(10), CONVERT(datetime,LD.Login_Datetime,106), 103) +' '+ right(convert(varchar(32), LD.Login_Datetime,100),8)  as [Login Date & Time] ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " inner join LOGIN_DETAIL LD ";
            strEmp += " on Emp_Mst.Emp_Id=LD.Login_Id  ";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            strEmp += " where  1=1 ";// +strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and LD.Login_Datetime between '" + FromDt + "'  and  '" + Todate + month + "' order by  LD.Login_Datetime desc ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        }
        else
        {
            strEmp += " select fullname,emp_code,centre_name,subcentrename,department,";
            strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
            strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '' then null End As 'Category',";
            strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks ";
            strEmp += " from employee_master Emp_Mst";
            strEmp += " left outer join centre_master Cent_Mst";
            strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
            strEmp += " left Outer join subcentremaster Sub_Mst";
            strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
            strEmp += " left outer join datily_attendance Dat_Att";
            strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
            strEmp += " left outer join department_master Dep_Mst";
            strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
            strEmp += " where  " + strCluster + "  " + strCentre + " " + strSubcentre + " ";
            strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);



        }
        return Empdr;

    }
    
    public OleDbDataReader ShowAttendanceCountReport(string Centreid, String Subcentreid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        //string strCluster = "";
        string strOrderclause = " ORDER BY Emp_Mst.emp_code,Sub_Mst.Centreid Desc";
        //" ORDER BY a.emp_code,c.Centreid ";

        //if (Clusterid != "")
        //{
        //strCluster = " and b.cluster_id= " + Clusterid + " ";
        //}

        if (Centreid != "")
        {
            strCentre = " Emp_Mst.centre_id=" + Centreid + " ";
        }
        //" and a.centre_id=" + Centreid + " ";
        else
        {
            //strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            //strSubcentre = " and a.subcentre_id=" + Subcentreid + " "
            strSubcentre = " and Emp_Mst.subcentre_id=" + Subcentreid + " ";
        }

        //if (ReportType == "With Data")
        //{
        //////////strEmp += " select e.department,substring(datename(dw,d.date),1,3) + ' '+ cast(day(d.date) as varchar) as Att_Date,a.emp_code,a.fullname,b.centre_name ,c.subcentrename ,a.suvidha_ac,'' as Category,'' as  ARemark, ";
        //////////strEmp += " case d.attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' else 'left' end as 'status',";
        //////////strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
        //////////strEmp += " 0 as  Deduction,'' as Dremarks ";
        //////////strEmp += " from employee_master a,";
        //////////strEmp += " centre_master b,subcentremaster c ,datily_attendance d,department_master e,COMPANY_MASTER g  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid  ";
        //////////strEmp += "  AND  a.emp_id=d.emp_id  "  + strCentre + " " + strSubcentre + " ";
        //////////strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) and a.department_id=e.dept_id  and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        //////////Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        strEmp += " select fullname,emp_code,centre_name,subcentrename,department,";
        strEmp += " substring(datename(dw,date),1,3) + ' '+ cast(day(date) as varchar) as Att_Date,";
        strEmp += " Case Isnull(EMP_TYPE,'') when 'P' then 'Professional' when 'Professional' then 'Professional' when 'S' then 'Salaried' when 'Salaried' then 'Salaried' when '--Select--' then NULL End As 'Category',";
        strEmp += " case attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A'  end as 'status',suvidha_ac,'' as  ARemark,DOL, 0 as  SpAllowance,0 as OTDAYS,  0 as  Deduction,'' as Dremarks, ";
        strEmp += " Isnull(unit,NULL) AS 'Units',Activity_name As 'Activity',Designation,Type_of_qualification As 'Qualification',Convert(varchar,DOJ,103) As 'Date of Join' ";
        strEmp += " from employee_master Emp_Mst";
        strEmp += " left outer join centre_master Cent_Mst";
        strEmp += " On Emp_Mst.centre_id=Cent_Mst.centre_id";
        strEmp += " left Outer join subcentremaster Sub_Mst";
        strEmp += " On Emp_Mst.subcentre_id=Sub_Mst.subcentreid";
        strEmp += " left outer join datily_attendance Dat_Att";
        strEmp += " On Emp_Mst.emp_id=Dat_Att.emp_id";
        strEmp += " left outer join department_master Dep_Mst";
        strEmp += " On Emp_Mst.department_id=Dep_Mst.dept_id";
        strEmp += " left outer join activity_master Act_Mst On Emp_Mst.Activity_id=Act_Mst.Activity_id";
        strEmp += " left outer join designation_master Desi_Mst On Emp_Mst.designation_id=Desi_Mst.designation_id";
        strEmp += " left outer join EMPLOYEE_EDUCATION_QUALIFICATION Emp_Qul On Emp_Mst.Emp_id=Emp_Qul.Emp_id";
        strEmp += " where " + strCentre + " " + strSubcentre + " ";
        strEmp += " and (dol>= '" + FromDt + "' or dol is null) and date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
        //            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);            
        //}
        //else
        //{
        //    strEmp += " select e.department,a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";
        //    strEmp += " ''as 'status',";
        //    strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
        //    strEmp += " '' as  Deduction,'' as Dremarks ";
        //    strEmp += " from employee_master a,";
        //    strEmp += " centre_master b,subcentremaster c ,department_master e  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
        //    strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
        //    strEmp += " and a.department_id=e.dept_id  " + strOrderclause + "  ";
        //    Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        //}
        return Empdr;
    }

    public OleDbDataReader ShowAttendanceDumpReport(string Centreid, String Subcentreid)
    {
        OleDbDataReader Empdr;
        string strEmp = "";
        string strSubcentre = "";
        string strCentre = "";
        //string strCluster = "";
        string strOrderclause = " ORDER BY a.emp_code,c.Centreid ";

        //if (Clusterid != "")
        //{
        //    strCluster = " and b.cluster_id= " + Clusterid + " ";
        //}

        if (Centreid != "")
        {
            strCentre = " and a.centre_id=" + Centreid + " ";
        }
        else
        {
            //            strOrderclause = " ORDER BY B.centre_name ASC,a.FULLNAME";
        }

        if (Subcentreid != "")
        {
            strSubcentre = " and a.subcentre_id=" + Subcentreid + " ";
        }

        //if (ReportType == "With Data")
        //{
        strEmp += " select e.department,substring(datename(dw,d.date),1,3) + ' '+ cast(day(d.date) as varchar) as Att_Date,a.emp_code,a.fullname,b.centre_name ,c.subcentrename ,a.suvidha_ac,'' as Category,'' as  ARemark, ";
        strEmp += " case d.attendance when 'A' then 'A' when 'P' then 'P' when 'U' then 'A' else 'left' end as 'status',";
        strEmp += " 0 as  SpAllowance,0 as OTDAYS, ";
        strEmp += " 0 as  Deduction,'' as Dremarks ";
        strEmp += " from employee_master a,";
        strEmp += " centre_master b,subcentremaster c ,datily_attendance d,department_master e,COMPANY_MASTER g  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid  ";
        strEmp += "  AND  a.emp_id=d.emp_id  " + strCentre + " " + strSubcentre + " ";
        strEmp += " and (a.dol>= '" + FromDt + "' or a.dol is null) and a.department_id=e.dept_id  and d.date between '" + FromDt + "'  and  '" + ToDt + "'  and upper(a.APPROVED_BY_HOHR)='Y' " + strOrderclause + "  ";
        Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);
        //            Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);            
        //}
        //else
        //{
        //    strEmp += " select e.department,a.emp_code,a.fullname,b.centre_name,c.subcentrename,'' as suvidha_ac,'' as Category,'' as unit,'' as company_id,'' as  ARemark, ";
        //    strEmp += " ''as 'status',";
        //    strEmp += " '' as  SpAllowance,'' as OTDAYS, ";
        //    strEmp += " '' as  Deduction,'' as Dremarks ";
        //    strEmp += " from employee_master a,";
        //    strEmp += " centre_master b,subcentremaster c ,department_master e  where a.centre_id=b.centre_id and a.subcentre_id=c.subcentreid";
        //    strEmp += "  and (a.dol>= '" + FromDt + "' or a.dol is null) " + strCentre + " " + strSubcentre + " ";
        //    strEmp += " and a.department_id=e.dept_id  " + strOrderclause + "  ";
        //    Empdr = OleDbHelper.ExecuteReader(con.ConnectionString, CommandType.Text, strEmp);

        //}
        return Empdr;
    }
    
}
