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


public partial class ConsumersE : System.Web.UI.Page
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
        if (Session["Server"] == null || Session["Application"].ToString() == null)
        {
            Response.Redirect("Login.aspx");
        }       

        if (Session["Roleid"] == null)
        {
            Response.Redirect("Login.aspx");
        }


        ENV.ReadOnly = true;
        ENV.BackColor = System.Drawing.Color.DarkGray;

        Application.ReadOnly = true;
        Application.BackColor = System.Drawing.Color.DarkGray;

        SqlCommand cmd = new SqlCommand("Consumers_EDIT", cn);        

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Server", Session["Server"].ToString());
        cmd.Parameters.AddWithValue("@Application", Session["Application"].ToString());

        cmd.Parameters.Add("@HCCBAPP2", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBAPP2"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HCCBAPP3", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBAPP3"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HCCBAPP4", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBAPP4"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HCCBAPP5", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBAPP5"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HCCBAPP6", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBAPP6"].Direction = ParameterDirection.Output;


        cmd.Parameters.Add("@SAASAPP4", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASAPP4"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SAASAPP5", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASAPP5"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SAASAPP6", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASAPP6"].Direction = ParameterDirection.Output;


        cmd.Parameters.Add("@HCCBFAT", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBFAT"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HCCBUAT", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HCCBUAT"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SAASSIT", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASSIT"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SAASUAT", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASUAT"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SITV2APP", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SITV2APP"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@UATV2APP", SqlDbType.NVarChar, 100);
        cmd.Parameters["@UATV2APP"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@PRDV2APP1", SqlDbType.NVarChar, 100);
        cmd.Parameters["@PRDV2APP1"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SAASPILOT", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASPILOT"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@SAASDEMO", SqlDbType.NVarChar, 100);
        cmd.Parameters["@SAASDEMO"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@DEMOV2", SqlDbType.NVarChar, 100);
        cmd.Parameters["@DEMOV2"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@TRAINING", SqlDbType.NVarChar, 100);
        cmd.Parameters["@TRAINING"].Direction = ParameterDirection.Output;

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
            ENV.Text = cmd.Parameters["@Server"].Value.ToString();


            HCCBAPP2.Text = cmd.Parameters["@HCCBAPP2"].Value.ToString();
            HCCBAPP3.Text = cmd.Parameters["@HCCBAPP3"].Value.ToString();
            HCCBAPP4.Text = cmd.Parameters["@HCCBAPP4"].Value.ToString();
            HCCBAPP5.Text = cmd.Parameters["@HCCBAPP5"].Value.ToString();
            HCCBAPP6.Text = cmd.Parameters["@HCCBAPP6"].Value.ToString();

            SAASAPP4.Text = cmd.Parameters["@SAASAPP4"].Value.ToString();
            SAASAPP5.Text = cmd.Parameters["@SAASAPP5"].Value.ToString();
            SAASAPP6.Text = cmd.Parameters["@SAASAPP6"].Value.ToString();

            HCCBFAT.Text = cmd.Parameters["@HCCBFAT"].Value.ToString();
            HCCBUAT.Text = cmd.Parameters["@HCCBUAT"].Value.ToString();
            TRAINING.Text = cmd.Parameters["@TRAINING"].Value.ToString();

            SITV2APP.Text = cmd.Parameters["@SITV2APP"].Value.ToString();
            UATV2APP.Text = cmd.Parameters["@UATV2APP"].Value.ToString();
            PRDV2APP1.Text = cmd.Parameters["@PRDV2APP1"].Value.ToString();

            DEMOV2.Text = cmd.Parameters["@DEMOV2"].Value.ToString();

            SAASSIT.Text = cmd.Parameters["@SAASSIT"].Value.ToString();
            SAASUAT.Text = cmd.Parameters["@SAASUAT"].Value.ToString();
            SAASDEMO.Text = cmd.Parameters["@SAASDEMO"].Value.ToString();
            SAASPILOT.Text = cmd.Parameters["@SAASPILOT"].Value.ToString();

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

        SqlCommand cmd = new SqlCommand("Consumers_UPDATE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Application", Application.Text.ToString());
        cmd.Parameters.AddWithValue("@Server", ENV.Text.ToString());

        cmd.Parameters.AddWithValue("@HCCBAPP2", HCCBAPP2.Text.ToString());
        cmd.Parameters.AddWithValue("@HCCBAPP3", HCCBAPP3.Text.ToString());
        cmd.Parameters.AddWithValue("@HCCBAPP4", HCCBAPP4.Text.ToString());
        cmd.Parameters.AddWithValue("@HCCBAPP5", HCCBAPP5.Text.ToString());
        cmd.Parameters.AddWithValue("@HCCBAPP6", HCCBAPP6.Text.ToString());

        cmd.Parameters.AddWithValue("@SAASAPP4", SAASAPP4.Text.ToString());
        cmd.Parameters.AddWithValue("@SAASAPP5", SAASAPP5.Text.ToString());
        cmd.Parameters.AddWithValue("@SAASAPP6", SAASAPP6.Text.ToString());

        cmd.Parameters.AddWithValue("@HCCBFAT", HCCBFAT.Text.ToString());
        cmd.Parameters.AddWithValue("@HCCBUAT", HCCBUAT.Text.ToString());
        cmd.Parameters.AddWithValue("@TRAINING", TRAINING.Text.ToString());

        
        cmd.Parameters.AddWithValue("@SITV2APP", SITV2APP.Text.ToString());
        cmd.Parameters.AddWithValue("@UATV2APP", UATV2APP.Text.ToString());
        cmd.Parameters.AddWithValue("@DEMOV2", DEMOV2.Text.ToString());

        cmd.Parameters.AddWithValue("@PRDV2APP1", PRDV2APP1.Text.ToString());

        cmd.Parameters.AddWithValue("@SAASSIT", SAASSIT.Text.ToString());
        cmd.Parameters.AddWithValue("@SAASUAT", SAASUAT.Text.ToString());
        cmd.Parameters.AddWithValue("@SAASDEMO", SAASDEMO.Text.ToString());
        cmd.Parameters.AddWithValue("@SAASPILOT", SAASPILOT.Text.ToString());

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
        String Env = Session["Server"].ToString();
        if (Env == "HCCBPRD")
        {
            HCCBAPP2Hide.Visible = true;
            HCCBAPP3Hide.Visible = true;
            HCCBAPP4Hide.Visible = true;
            HCCBAPP5Hide.Visible = true;
            HCCBAPP6Hide.Visible = true;

            HCCBFATHide.Visible = false;
            HCCBUATHide.Visible = false;
            TRAININGHide.Visible = false; 

            SAASAPP4Hide.Visible = false;
            SAASAPP5Hide.Visible = false;
            SAASAPP6Hide.Visible = false;

            SAASSITHide.Visible = false;
            SAASUATHide.Visible = false;
            SAASPILOTHide.Visible = false;
            SAASDEMOHide.Visible = false;

            V2PRDHide.Visible = false;

            SITV2APPHide.Visible = false;
            UATV2APPHide.Visible = false;
            DEMOV2Hide.Visible = false;

            

        }

        if (Env == "HCCBNONPRD")
        {
            HCCBAPP2Hide.Visible = false;
            HCCBAPP3Hide.Visible = false;
            HCCBAPP4Hide.Visible = false;
            HCCBAPP5Hide.Visible = false;
            HCCBAPP6Hide.Visible = false;

            HCCBFATHide.Visible = true;
            HCCBUATHide.Visible = true;
            TRAININGHide.Visible = true;

            SAASAPP4Hide.Visible = false;
            SAASAPP5Hide.Visible = false;
            SAASAPP6Hide.Visible = false;

            SAASSITHide.Visible = false;
            SAASUATHide.Visible = false;
            SAASPILOTHide.Visible = false;
            SAASDEMOHide.Visible = false;

            V2PRDHide.Visible = false;

            SITV2APPHide.Visible = false;
            UATV2APPHide.Visible = false;
            DEMOV2Hide.Visible = false;
        }

        if (Env == "SAASPRD")
        {
            HCCBAPP2Hide.Visible = false;
            HCCBAPP3Hide.Visible = false;
            HCCBAPP4Hide.Visible = false;
            HCCBAPP5Hide.Visible = false;
            HCCBAPP6Hide.Visible = false;

            HCCBFATHide.Visible = false;
            HCCBUATHide.Visible = false;
            TRAININGHide.Visible = false;

            SAASAPP4Hide.Visible = true;
            SAASAPP5Hide.Visible = true;
            SAASAPP6Hide.Visible = true;

            SAASSITHide.Visible = false;
            SAASUATHide.Visible = false;
            SAASPILOTHide.Visible = false;
            SAASDEMOHide.Visible = false;

            V2PRDHide.Visible = false;

            SITV2APPHide.Visible = false;
            UATV2APPHide.Visible = false;
            DEMOV2Hide.Visible = false;
        }

        if (Env == "SAASNONPRD")
        {
            HCCBAPP2Hide.Visible = false;
            HCCBAPP3Hide.Visible = false;
            HCCBAPP4Hide.Visible = false;
            HCCBAPP5Hide.Visible = false;
            HCCBAPP6Hide.Visible = false;

            HCCBFATHide.Visible = false;
            HCCBUATHide.Visible = false;
            TRAININGHide.Visible = false;

            SAASAPP4Hide.Visible = false;
            SAASAPP5Hide.Visible = false;
            SAASAPP6Hide.Visible = false;

            SAASSITHide.Visible = true;
            SAASUATHide.Visible = true;
            SAASPILOTHide.Visible = true;
            SAASDEMOHide.Visible = true;

            V2PRDHide.Visible = false;

            SITV2APPHide.Visible = false;
            UATV2APPHide.Visible = false;
            DEMOV2Hide.Visible = false;
        }

        if (Env == "V2PRD")
        {
            HCCBAPP2Hide.Visible = false;
            HCCBAPP3Hide.Visible = false;
            HCCBAPP4Hide.Visible = false;
            HCCBAPP5Hide.Visible = false;
            HCCBAPP6Hide.Visible = false;

            HCCBFATHide.Visible = false;
            HCCBUATHide.Visible = false;
            TRAININGHide.Visible = false;

            SAASAPP4Hide.Visible = false;
            SAASAPP5Hide.Visible = false;
            SAASAPP6Hide.Visible = false;

            SAASSITHide.Visible = false;
            SAASUATHide.Visible = false;
            SAASPILOTHide.Visible = false;
            SAASDEMOHide.Visible = false;

            V2PRDHide.Visible = true;

            SITV2APPHide.Visible = false;
            UATV2APPHide.Visible = false;
            DEMOV2Hide.Visible = false;
        }

        if (Env == "V2NONPRD")
        {
            HCCBAPP2Hide.Visible = false;
            HCCBAPP3Hide.Visible = false;
            HCCBAPP4Hide.Visible = false;
            HCCBAPP5Hide.Visible = false;
            HCCBAPP6Hide.Visible = false;

            HCCBFATHide.Visible = false;
            HCCBUATHide.Visible = false;
            TRAININGHide.Visible = false;

            SAASAPP4Hide.Visible = false;
            SAASAPP5Hide.Visible = false;
            SAASAPP6Hide.Visible = false;

            SAASSITHide.Visible = false;
            SAASUATHide.Visible = false;
            SAASPILOTHide.Visible = false;
            SAASDEMOHide.Visible = false;

            V2PRDHide.Visible = false;

            SITV2APPHide.Visible = true;
            UATV2APPHide.Visible = true;
            DEMOV2Hide.Visible = true;
        }        
    }



}