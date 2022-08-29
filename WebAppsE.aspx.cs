using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;


public partial class WebAppsE : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
    SqlCommand cm = new SqlCommand();

    DataSet ds = new DataSet();
    DataSet dsgen = new DataSet();
    DataSet dsnat = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsss = new DataSet();
    DataSet dssss = new DataSet();
    DataTable dt = new DataTable();
    DataSet bc = new DataSet();
    DataSet be = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Write(Session["BindClient"].ToString());
        //Response.Write(Session["BindENV"].ToString());

        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["IsAuthenticate"] != "1")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='WebApps.aspx';</script></script>");
        }
        else
        {
            
            if (!this.IsPostBack)
            {
                
                BindHTSE();
                BindHideTableRows();

            }
        }

    }

    

    protected void BindHTSE()
    {
        //string IDD = null;
        //ID = Session["ID"].ToString();
        if (Session["BindClient"] == null || Session["BindClient"].ToString() == "0")
        {
            Response.Redirect("Login.aspx");
        }       

        if (Session["Roleid"] == null)
        {
            Response.Redirect("Login.aspx");
        }


        BindClient.ReadOnly = true;
        BindClient.BackColor = System.Drawing.Color.DarkGray;

        Application.ReadOnly = true;
        Application.BackColor = System.Drawing.Color.DarkGray;

        SqlCommand cmd = new SqlCommand("Urls_EDIT", cn);

        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@ID", IDD);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Client", Session["BindClient"].ToString());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Application", Session["Application"].ToString());

        cmd.Parameters.Add("@Url1", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Url1"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Url2", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Url2"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Url3", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Url3"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 100);
        cmd.Parameters["@IsActive"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            //ID.Text = cmd.Parameters["@ID"].Value.ToString();
            Application.Text = cmd.Parameters["@Application"].Value.ToString();
            BindClient.Text = cmd.Parameters["@Client"].Value.ToString();

            Url1.Text = cmd.Parameters["@Url1"].Value.ToString();
            Url2.Text = cmd.Parameters["@Url2"].Value.ToString();
            Url3.Text = cmd.Parameters["@Url3"].Value.ToString();

            ActiveStatus.Text = cmd.Parameters["@IsActive"].Value.ToString();
            HeaderText.Text = cmd.Parameters["@HeaderText"].Value.ToString();

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTSE.aspx.cs";
            String Errorfunction = "BindHTSE";
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

    protected void Save_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("Urls_Update", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Application", Application.Text.ToString());
        cmd.Parameters.AddWithValue("@Client", BindClient.Text.ToString());
        cmd.Parameters.AddWithValue("@Url1", Url1.Text.ToString());
        cmd.Parameters.AddWithValue("@Url2", Url2.Text.ToString());
        cmd.Parameters.AddWithValue("@Url3", Url3.Text.ToString());
        cmd.Parameters.AddWithValue("@IsActive", ActiveStatus.Text.ToString());


        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='javascript:history.go(-2)'</script></script>");

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "HTSEdit.aspx.cs";
            String Errorfunction = "Save_Click";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmddd = new SqlCommand("Error_Insert", cn);
            cmddd.Connection = cn;
            cmddd.CommandType = CommandType.Text;
            cmddd.CommandType = CommandType.StoredProcedure;
            cmddd.Parameters.AddWithValue("@Exmessage", Exmessage);
            cmddd.Parameters.AddWithValue("@Errorpage", Errorpage);
            cmddd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
            cmddd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");
        }
        finally
        {
            cn.Close();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write(FAT_RD.Text);
    }

    protected void BindHideTableRows()
    {
        String Env = Session["BindENV"].ToString();        
           
            if (Env == "DEMO")
            {
                FATHide.Visible = true;
                UATHide.Visible = true;
                DemoEnable1.Visible = true;
                PRDHide.Visible = false;
                FatSitHide.Visible = false;
                PilotEnable.Visible = false;
                UATHide1.Visible = false;
                TriEnable.Visible = false;
            }
            else if (Env == "Training")
            {
                FATHide.Visible = true;
                UATHide.Visible = false;
                PRDHide.Visible = false;
                DemoEnable.Visible = false;
                PilotEnable.Visible = false;
                FatSitHide.Visible = false;
                TriEnable.Visible = true;
                
            }

            else if (Env == "PILOT")
            {
                FATHide.Visible = true;
                UATHide.Visible = false;
                PRDHide.Visible = false;
                FatSitHide.Visible = false;
                PilotEnable.Visible = true;
                DemoEnable.Visible = false;
                TriEnable.Visible = false;
            }

            else
            {
                TriEnable.Visible = false;
                DemoEnable.Visible = false;
                DemoEnable1.Visible = false;
                PilotEnable.Visible = false;
            }

    }



}