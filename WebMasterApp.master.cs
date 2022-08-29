using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Security;

public partial class WebMasterApp : System.Web.UI.MasterPage
{
    SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //string RoleID = null;
        //if (Session["Roleid"] == "3")
        //{
            
        //}

        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else 
        {
            if (!this.IsPostBack)
            {
                BindGrid();
            }
        }

        
        //BindAddress();
    }
    protected void BindAddress()
    {
        SqlCommand cmd = new SqlCommand("ContactDetails_Select", cn);
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 30);
        cmd.Parameters["@Email"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@EmailDescription", SqlDbType.NVarChar, 200);
        cmd.Parameters["@EmailDescription"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@PhNo", SqlDbType.NVarChar, 30);
        cmd.Parameters["@PhNo"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@PhNoDes", SqlDbType.NVarChar, 200);
        cmd.Parameters["@PhNoDes"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Add", SqlDbType.NVarChar, 200);
        cmd.Parameters["@Add"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@AddDes", SqlDbType.NVarChar, 2000);
        cmd.Parameters["@AddDes"].Direction = ParameterDirection.Output;

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            
            //EmailDescription.Text = cmd.Parameters["@EmailDescription"].Value.ToString();            
            //PhNoDes.Text = cmd.Parameters["@PhNoDes"].Value.ToString();            
            //AddDes.Text = cmd.Parameters["@AddDes"].Value.ToString();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "Contact.aspx.cs";
            String Errorfunction = "BindGrid";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmdd = new SqlCommand("Error_Insert", cn);
            cmdd.Connection = cn;
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@Exmessage", Exmessage);
            cmdd.Parameters.AddWithValue("@Errorpage", Errorpage);
            cmdd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
            cmdd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");
        }
        finally
        {
            cn.Close();
        }
    }

    protected void BindGrid()
    {


        SqlCommand cmd = new SqlCommand("MENU_Select", cn);
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandType = CommandType.StoredProcedure;
        if (Session["Roleid"] == null)
        {
            Response.Redirect("Login.aspx");
        }


        cmd.Parameters.AddWithValue("@webmaster", "App");
        cmd.Parameters.AddWithValue("@ParentMenuName1", "M1");
        cmd.Parameters.AddWithValue("@ParentMenuName2", "M2");
        cmd.Parameters.AddWithValue("@ParentMenuName3", "M3");
        cmd.Parameters.AddWithValue("@ParentMenuName4", "M4");
        cmd.Parameters.AddWithValue("@Roleid", Session["Roleid"]);

        cmd.Parameters.Add("@PSM1", SqlDbType.NVarChar, 100000);
        cmd.Parameters["@PSM1"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@PSM2", SqlDbType.NVarChar, 100000);
        cmd.Parameters["@PSM2"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@PSM3", SqlDbType.NVarChar, 100000);
        cmd.Parameters["@PSM3"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@PSM4", SqlDbType.NVarChar, 100000);
        cmd.Parameters["@PSM4"].Direction = ParameterDirection.Output;

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            PSM1.InnerHtml = cmd.Parameters["@PSM1"].Value.ToString();
            PSM2.InnerHtml = cmd.Parameters["@PSM2"].Value.ToString();
            PSM3.InnerHtml = cmd.Parameters["@PSM3"].Value.ToString();
            PSM4.InnerHtml = cmd.Parameters["@PSM4"].Value.ToString();

            //MenuHeader.InnerHtml = cmd.Parameters["@MenuHeader"].Value.ToString();
            //MenuHeader1.InnerHtml = cmd.Parameters["@MenuHeader1"].Value.ToString();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "Default.aspx.cs";
            String Errorfunction = "BindGrid";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmdd = new SqlCommand("Error_Insert", cn);
            cmdd.Connection = cn;
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@Exmessage", Exmessage);
            cmdd.Parameters.AddWithValue("@Errorpage", Errorpage);
            cmdd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
            cmdd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");
        }
        finally
        {
            cn.Close();

        }
    }

    protected void Logout_Click(object sender, EventArgs e)

    {
        

    }
}
