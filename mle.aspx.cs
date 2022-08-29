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


public partial class mle : System.Web.UI.Page
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
    DataSet bel = new DataSet();
    DataSet bs = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["IsAuthenticate"] != "1")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='ml.aspx';</script></script>");
        }
        else
        {

            if (!this.IsPostBack)
            {
                BindENV1();
                BindServer1();
                BindHTSE();
                //ActiveStatus1();
                BindHideTableRows();
               

            }
        }

    }

    protected void ActiveStatus1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("select Description from ActiveStatus ", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dssss);
            ActiveStatus.DataSource = dssss;
            ActiveStatus.DataTextField = "Description";
            ActiveStatus.DataValueField = "Description";
            ActiveStatus.DataBind();
            ActiveStatus.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTSE.aspx.cs";
            String Errorfunction = "ActiveStatus1";
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

    protected void BindENV1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ENVName_ml, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(be);
            BindENV.DataSource = be;
            BindENV.DataTextField = "ENVName";
            BindENV.DataValueField = "ENVName";
            BindENV.DataBind();
            BindENV.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindENV1";
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

    protected void BindServer1()
    {
        try
        {
            cn.Open();
            //SqlCommand cm = new SqlCommand("SELECT ServerName FROM ServerMaster SM INNER JOIN ENVMaster EM WITH(NOLOCK) ON SM.EnvId = EM.ID WHERE ENVName = '" + BindENV.Text + "' ORDER BY SM.ID DESC", cn);
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ServerName, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(bs);
            BindServer.DataSource = bs;
            BindServer.DataTextField = "ServerName";
            BindServer.DataValueField = "ServerName";
            BindServer.DataBind();
            BindServer.Items.Insert(0, new ListItem(""));

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindServer1";
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



    protected void BindHTSE()
    {
        string IDD = null;
        //ID = Session["ID"].ToString();

        if (Session["ID"] == null || Session["ID"].ToString() == "0")
        {
            Response.Redirect("Login.aspx");
        }

        
        if (Session["Roleid"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (Session["cm_ID"] == null || Session["cm_ID"].ToString() == "")
        {
            IDT.Visible = false;
            IDD = "";
            Delete.Visible = false;
        }
        else
        {
            ID.ReadOnly = true;
            ID.BackColor = System.Drawing.Color.DarkGray;
            IDD = Session["cm_ID"].ToString();
        }
        if(Session["Masterselect"] == "Environments")
        {
            ENVT.Visible = false;
            ClientsT.Visible = false;
            ServerNameTTB.Visible = false;
            ServerNameTDD.Visible = false;
            ServerListT.Visible = false;
        }
        else if (Session["Masterselect"] == "Clients")
        {
            ENVTTB.Visible = false;
            ServerNameTTB.Visible = false;
            ServerNameTDD.Visible = false;
            ServerListT.Visible = false;
        }
        else if (Session["Masterselect"] == "Servers")
        {
            ENVT.Visible = false;
            ENVTTB.Visible = false;
            ClientsT.Visible = false;
            ServerNameTDD.Visible = false;
            ServerListT.Visible = false;
        }
        else if (Session["Masterselect"] == "ServerList")
        {
            ENVTTB.Visible = false;
            ENVT.Visible = true;
            ClientsT.Visible = false;
            ServerNameTTB.Visible = false;
        }
        else
        {

        }





        SqlCommand cmd = new SqlCommand("Masters_EDIT", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", IDD);
        cmd.Parameters.AddWithValue("@Masterselect", Session["Masterselect"].ToString());

        cmd.Parameters.Add("@ENV", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@ENV"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Clients", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Clients"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Server", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Server"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@ActiveStatus", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@ActiveStatus"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Serverlist", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Serverlist"].Direction = ParameterDirection.Output;

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();

            ID.Text = cmd.Parameters["@ID"].Value.ToString();
            BindENV.Text = cmd.Parameters["@ENV"].Value.ToString();
            ENVTB.Text = cmd.Parameters["@ENV"].Value.ToString();
            Clients.Text = cmd.Parameters["@Clients"].Value.ToString();            
            HeaderText.Text = cmd.Parameters["@HeaderText"].Value.ToString();
            BindServer.Text = cmd.Parameters["@Server"].Value.ToString();
            ServerName.Text = cmd.Parameters["@Server"].Value.ToString();
            ServerList.Text = cmd.Parameters["@Serverlist"].Value.ToString();
            ActiveStatus.Text = cmd.Parameters["@ActiveStatus"].Value.ToString();

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


        SqlCommand cmd = new SqlCommand("Masters_UPDATE", cn);        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Userid", Session["ID"].ToString());
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());
        cmd.Parameters.AddWithValue("@Masterselect", Session["Masterselect"].ToString());
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text.ToString());
        cmd.Parameters.AddWithValue("@ENVTB", ENVTB.Text.ToString());
        cmd.Parameters.AddWithValue("@Clients", Clients.Text.ToString());
        cmd.Parameters.AddWithValue("@ServerName", ServerName.Text.ToString());
        cmd.Parameters.AddWithValue("@ServerNameDD", BindServer.Text.ToString());
        cmd.Parameters.AddWithValue("@ServerListName", ServerList.Text.ToString());
        cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus.Text.ToString());

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

    protected void Delete_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Masters_DELETE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());
        cmd.Parameters.AddWithValue("@Masterselect", Session["Masterselect"].ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Record Deleted Sucessfully');location.href='javascript:history.go(-2)'</script>");
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTSE.aspx.cs";
            String Errorfunction = "Delete_Click";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write(SITFAT.Text);
    }

    protected void BindHideTableRows()
    {
        

      
    }

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindENVLists1();
        BindHideTableRows();
    }
    
    
}