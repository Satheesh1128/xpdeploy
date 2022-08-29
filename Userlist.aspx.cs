﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.IO;
using ClosedXML.Excel;
using System.Security.Authentication;

public partial class userlist : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsss = new DataSet();
    DataSet dssss = new DataSet();
    DataSet dssec = new DataSet();
    DataSet dsmed = new DataSet();
    DataSet dsgen = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {

            if (!this.IsPostBack)
            {
                if (Session["ID"] == null || Session["ID"].ToString() == "0" || Session["Roleid"] == null)
                {
                    FormsAuthentication.RedirectToLoginPage();
                     
                }
                else
                {
                    BindStatus1();
                    BindRole();
                    BindHtmlTable();
                }
            }
        }

    }

    protected void BindRole()
    {
        try
        {
                cn.Open();            
                SqlCommand cm = new SqlCommand("SELECT RoleName FROM RoleMaster", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dss);
                BindRoleMaster.DataSource = dss;
                BindRoleMaster.DataTextField = "RoleName";
                BindRoleMaster.DataValueField = "RoleName";
                BindRoleMaster.DataBind();
                BindRoleMaster.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "ins.aspx.cs";
            String Errorfunction = "BindRole";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmd = new SqlCommand("Error_Insert", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Exmessage", Exmessage);
            cmd.Parameters.AddWithValue("@Errorpage", Errorpage);
            cmd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");
        }
        finally
        {
            cn.Close();
        }
    } 

    protected void BindHtmlTable()
    {
        //Populating a DataTable from database.
        DataTable dt = this.GetData();

        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        //Table start.
        html.Append("<table id =DynamicTable class=TableClass>");

        html.Append("<tr>");

        //html.Append("<th text-align: center colspan=20>");
        ////html.Append(Header.Text);        
        //html.Append("</th>");

        html.Append("</tr>");

        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");

        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }

        //Table end.
        html.Append("</table>");

        //Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    private DataTable GetData()
    {
        try
        {
            String Action = "SelectData";

            SqlCommand cmd = new SqlCommand("Users_SELECT", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleId", Session["Roleid"].ToString());
            cmd.Parameters.AddWithValue("@UserName", Session["username"]);
            cmd.Parameters.AddWithValue("@SearchUserName", Search.Text);
            cmd.Parameters.AddWithValue("@ActiveStatus", BindStatus.Text);
            cmd.Parameters.AddWithValue("@RoleName", BindRoleMaster.Text);
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.Parameters.Add("@Header", SqlDbType.NVarChar, 10000);
            cmd.Parameters["@Header"].Direction = ParameterDirection.Output;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            Header.Text = cmd.Parameters["@Header"].Value.ToString();
            
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HM.aspx.cs";
            String Errorfunction = "GetData";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmd = new SqlCommand("Error_Insert", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Exmessage", Exmessage);
            cmd.Parameters.AddWithValue("@Errorpage", Errorpage);
            cmd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");
        }

        return dt;
    }

    protected void BindStatus1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("SELECT Description FROM ActiveStatus", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dsgen);
            BindStatus.DataSource = dsgen;
            BindStatus.DataTextField = "Description";
            BindStatus.DataValueField = "Description";
            BindStatus.DataBind();
            //BindStatus.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindStatus1";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmd = new SqlCommand("Error_Insert", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Exmessage", Exmessage);
            cmd.Parameters.AddWithValue("@Errorpage", Errorpage);
            cmd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");
        }
        finally
        {
            cn.Close();
        }
    }

    protected void BindRoleMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
 
        BindHtmlTable();
    }

    protected void BindStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Search_TextChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        CurrentEventName.Text = "Add";

        if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            BindRolePermission();
        }
    }

    protected void Edit_Click(object sender, EventArgs e)
    {

        //Session["UserM_ID"] = TextBox1.Text;
        //Response.Redirect("UserM.aspx");

        CurrentEventName.Text = "Edit";

        if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            BindRolePermission();
        }
    }

    protected void Refresh_Click(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void GoAppsAddEdit()
    {
        Session["UserM_ID"] = TextBox1.Text;
        String SessionID = TextBox1.Text;

        Session["IsAuthenticate"] = "1";
        String reponsepage = "Userlist.aspx";
        String reponsegopage = "UserM.aspx";



        if (SessionID == "" && CurrentEventName.Text == "Add")
        {
            Response.Redirect(reponsegopage);
        }
        else if (SessionID != "" && CurrentEventName.Text == "Add")
        {
            SessionID = "";
            Response.Redirect(reponsegopage);
        }
        else if (SessionID == "" && CurrentEventName.Text == "Edit")
        {
            Response.Write("<script language='javascript'>alert('Pl Select a row to Edit');location.href='" + reponsepage + "';</script></script>");
        }
        else
        {
            Response.Redirect(reponsegopage);
        }
    }

    protected void BindRolePermission()
    {
        String ScreenModule = "User";
        SqlCommand cmd = new SqlCommand(CommonClass.RolePermission.RoleAction(CommonClass.RoleAction.SP), cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Module", ScreenModule);
        cmd.Parameters.AddWithValue("@RoleId", Session["Roleid"]);

        cmd.Parameters.AddWithValue("@ActionSave", CommonClass.RolePermission.RoleAction(CommonClass.RoleAction.Save));
        cmd.Parameters.AddWithValue("@ActionAdd", CommonClass.RolePermission.RoleAction(CommonClass.RoleAction.Add));
        cmd.Parameters.AddWithValue("@ActionEdit", CommonClass.RolePermission.RoleAction(CommonClass.RoleAction.Edit));
        cmd.Parameters.AddWithValue("@ActionDelete", CommonClass.RolePermission.RoleAction(CommonClass.RoleAction.Delete));


        cmd.Parameters.Add("@Save", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Save"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Add", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Add"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Edit", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Edit"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Delete", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Delete"].Direction = ParameterDirection.Output;

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

        String DataSave = cmd.Parameters["@Save"].Value.ToString();
        String DataAdd = cmd.Parameters["@Add"].Value.ToString();
        String DataEdit = cmd.Parameters["@Edit"].Value.ToString();
        String DataDelete = cmd.Parameters["@Delete"].Value.ToString();

        String reponsepage = "Userlist.aspx";

        if (DataSave == "0" && DataAdd == "0" && DataEdit == "0" && DataDelete == "0")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='" + reponsepage + "';</script></script>");
        }

        else if (DataSave == "0" && CurrentEventName.Text == "Save")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='" + reponsepage + "';</script></script>");
        }

        else if (DataAdd == "0" && CurrentEventName.Text == "Add")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='" + reponsepage + "';</script></script>");
        }

        else if (DataEdit == "0" && CurrentEventName.Text == "Edit")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='" + reponsepage + "';</script></script>");
        }
        else if (DataDelete == "0" && CurrentEventName.Text == "Delete")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='" + reponsepage + "';</script></script>");
        }
        else
        {
            GoAppsAddEdit();
        }

    }
}




