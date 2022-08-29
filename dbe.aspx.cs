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


public partial class dbe : System.Web.UI.Page
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


    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Write(Session["ID"].ToString());

        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["IsAuthenticate"] != "1")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='dbs.aspx';</script></script>");
        }
        else
        {

            if (!this.IsPostBack)
            {
                BindENV1();
                BindENVLists1();
                BindHTSE();
                
                BindHideTableRows();
               

            }
        }

    }



    protected void BindSession()
    {
        Session["dbsENV"].ToString(); ;
        Session["dbsENVList"].ToString(); ;
        Session["dbsStatus"].ToString(); ;
        Session["dbsVersion"].ToString(); ;
        Session["dbsSearch"].ToString(); ;
    }

    protected void BindENV1()
    {
        try
        {
            cn.Open();            
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ENVName_DBs, cn);
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

    protected void BindENVLists1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ENVLists, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(bel);
            BindENVLists.DataSource = bel;
            BindENVLists.DataTextField = "ENVListName";
            BindENVLists.DataValueField = "ENVListName";
            BindENVLists.DataBind();
            BindENVLists.Items.Insert(0, new ListItem(""));

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindENVList1";
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

        if (Session["DB_ID"] == null || Session["DB_ID"] == "")
        {
            IDT.Visible = false;
            IDD = "";
            DMS.Text = "";
            Central.Text = "";
            RT60.Text = "";
            Selfie.Text = "";
            Delete.Visible = false;
        }
        else
        {
            ID.ReadOnly = true;
            ID.BackColor = System.Drawing.Color.DarkGray;
            IDD = Session["DB_ID"].ToString();
        }

       



        SqlCommand cmd = new SqlCommand("[DBS_EDIT]", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", IDD);

        cmd.Parameters.Add("@ENV", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@ENV"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@DMS", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@DMS"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Central", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Central"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@RT60", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@RT60"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Selfie", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Selfie"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Version", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Version"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Server", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Server"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 1000000);
        cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();

            
            BindENV.Text = cmd.Parameters["@ENV"].Value.ToString();
            DMS.Text = cmd.Parameters["@DMS"].Value.ToString();

            Central.Text = cmd.Parameters["@Central"].Value.ToString();
            RT60.Text = cmd.Parameters["@RT60"].Value.ToString();
            Selfie.Text = cmd.Parameters["@Selfie"].Value.ToString();
            Version.Text = cmd.Parameters["@Version"].Value.ToString();
            BindENVLists.Text = cmd.Parameters["@Server"].Value.ToString();
            Status.Text = cmd.Parameters["@Status"].Value.ToString();
            
            HeaderText.Text = cmd.Parameters["@HeaderText"].Value.ToString();

            if (Session["DuplicateTicket"] == "Yes")
            {
                ID.Text = "";
            }
            else 
            { 
                ID.Text = cmd.Parameters["@ID"].Value.ToString(); 
            }
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
        if (DMS.Text == "" && Central.Text == "" && RT60.Text == "" && Selfie.Text == "")
        {
            Mandatory.Visible = true;
        }
        else
        {

        SqlCommand cmd = new SqlCommand("DBS_UPDATE", cn);        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Userid", Session["ID"].ToString());
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text.ToString());
        cmd.Parameters.AddWithValue("@DMS", DMS.Text.ToString());
        cmd.Parameters.AddWithValue("@Central", Central.Text.ToString());
        cmd.Parameters.AddWithValue("@RT60", RT60.Text.ToString());
        cmd.Parameters.AddWithValue("@Selfie", Selfie.Text.ToString());
        cmd.Parameters.AddWithValue("@Version", Version.Text.ToString());
        cmd.Parameters.AddWithValue("@Server", BindENVLists.Text.ToString());
        cmd.Parameters.AddWithValue("@Status", Status.Text.ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
                BindSession();
                Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='dbs.aspx'</script></script>");

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

    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("DBS_DELETE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            BindSession();
            Response.Write("<script language='javascript'>alert('Record Deleted Sucessfully');location.href='dbs.aspx'</script>");
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

    protected void Cancel_Click(object sender, EventArgs e)
    {
        BindSession();
        Response.Redirect("dbs.aspx"); 

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