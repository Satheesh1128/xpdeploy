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


public partial class DevOpse : System.Web.UI.Page
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

        //Response.Write(Session["ID"].ToString());

        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["IsAuthenticate"] != "1")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='devops.aspx';</script></script>");
        }
        else if (Session["BindENV"] == null || Session["Application"] == null || Session["Roleid"] == null)
        {
            //FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("Login.aspx");
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

        //if (Session["BindENV"] == null || Session["BindENV"].ToString() == "0" || Session["Application"] == null)
        //{
        //    //FormsAuthentication.RedirectToLoginPage();
        //    Response.Redirect("Login.aspx");
        //}

        //else if (Session["Roleid"] == null)
        //{
        //    //FormsAuthentication.RedirectToLoginPage();
        //    Response.Redirect("Login.aspx");
        //}
        //else
        //{

            BindENV.ReadOnly = true;
            BindENV.BackColor = System.Drawing.Color.DarkGray;
            Application.ReadOnly = true;
            Application.BackColor = System.Drawing.Color.DarkGray;

            SqlCommand cmd = new SqlCommand("[CodeDeploy_EDIT]", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ENV", Session["BindENV"].ToString());
            cmd.Parameters.AddWithValue("@Application", Session["Application"].ToString());

            cmd.Parameters.Add("@CodeDeployName", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@CodeDeployName"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@CodePipelineName", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@CodePipelineName"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@S3", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@S3"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@App_Spec", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@App_Spec"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 100);
            cmd.Parameters["@IsActive"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                BindENV.Text = cmd.Parameters["@ENV"].Value.ToString();
                Application.Text = cmd.Parameters["@Application"].Value.ToString();
                CodeDeployName.Text = cmd.Parameters["@CodeDeployName"].Value.ToString();
                CodePipelineName.Text = cmd.Parameters["@CodePipelineName"].Value.ToString();
                S3.Text = cmd.Parameters["@S3"].Value.ToString();
                App_Spec.Text = cmd.Parameters["@App_Spec"].Value.ToString();
                BindActiveStatus.Text = cmd.Parameters["@IsActive"].Value.ToString();
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
        SqlCommand cmd = new SqlCommand("CodeDeploy_UPDATE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Application", Application.Text.ToString());        
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text.ToString());
        cmd.Parameters.AddWithValue("@CodeDeployName", CodeDeployName.Text.ToString());
        cmd.Parameters.AddWithValue("@CodePipelineName", CodePipelineName.Text.ToString());
        cmd.Parameters.AddWithValue("@S3", S3.Text.ToString());
        cmd.Parameters.AddWithValue("@App_Spec", App_Spec.Text.ToString());
        cmd.Parameters.AddWithValue("@IsActive", BindActiveStatus.Text.ToString());

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
    }

    protected void BindHideTableRows()
    {        
    }

    protected void BindActiveStatus_SelectedIndexChanged(object sender, EventArgs e)
    {      
    }

}