using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfo
{
	public UserInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public struct structUSERInfo
    {
        public string UserId;
        public string UserName;
        public int RoleId;
        public string RoleName;
        public int DesignationID;
        public string ClientName; 
    } 
}
