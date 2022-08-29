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


public partial class AppsE : System.Web.UI.Page
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
    DataSet alv1 = new DataSet();
    DataSet ac1 = new DataSet();
    DataSet ac2 = new DataSet();
    DataSet au = new DataSet();
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["ID"] == null || Session["ID"].ToString() == "0")
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["IsAuthenticate"] != "1")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='Apps.aspx';</script></script>");
        }
        else
        {
            if (!this.IsPostBack)
            {
                
                BindAppCategor1();                
                //BindAppCategor2();
                BindHTSE();
                BindUser1();
            }
        }

    }

    protected void BindUser1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.adminusers, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(au);
            Responsible.DataSource = au;
            Responsible.DataTextField = "UserName";
            Responsible.DataValueField = "UserName";
            Responsible.DataBind();

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindClient1";
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

    protected void BindAppCategor1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("SELECT * FROM AppCategory1 ORDER BY Category1ID", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ac1);
            Category1.DataSource = ac1;
            Category1.DataTextField = "CategoryName";
            Category1.DataValueField = "CategoryName";
            Category1.DataBind();
            Category1.Items.Insert(0, new ListItem(""));

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindAppCategor1";
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

    protected void BindAppCategor2()
    {
        
            if(Category1.Text=="")
            {
                Category2.Text = "";
                
            }
            else
            {
                SqlCommand cm = new SqlCommand("SELECT * FROM AppCategory2 A INNER JOIN AppCategory1 B WITH(NOLOCK) ON B.Category1ID = A.Category1ID WHERE B.CategoryName = '" + Category1.Text + "'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ac2);
                Category2.DataSource = ac2;
                Category2.DataTextField = "CategoryName";
                Category2.DataValueField = "CategoryName";
                Category2.DataBind();
                Category2.Items.Insert(0, new ListItem(""));
            }
    }

    protected void BindHTSE()
    {
        string RTID = null;    
        if (Session["Apps_ID"] == null || Session["Apps_ID"] == "")
            {
                RTID = "0";
                TID.Visible = false;
                Delete.Visible = false;
            }
            else
            {
                ID.ReadOnly = true;
                ID.BackColor = System.Drawing.Color.DarkGray;
                RTID = Session["Apps_ID"].ToString();
            }
        
            SqlCommand cmd = new SqlCommand("ApplicationList_EDIT", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", RTID);

            cmd.Parameters.Add("@Application", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Application"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Category1", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Category1"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Category2", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Category2"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Version", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Version"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Responsible", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Responsible"].Direction = ParameterDirection.Output;            

            cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                ID.Text = cmd.Parameters["@ID"].Value.ToString();
                Application.Text = cmd.Parameters["@Application"].Value.ToString();
                Category1.Text = cmd.Parameters["@Category1"].Value.ToString();
                Category2.Text = cmd.Parameters["@Category2"].Value.ToString();
                Version.Text = cmd.Parameters["@Version"].Value.ToString();
                Responsible.Text = cmd.Parameters["@Responsible"].Value.ToString();
                HeaderText.Text = cmd.Parameters["@HeaderText"].Value.ToString();
                

                BindAppCategor2();

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

    protected void BindHideTableRows()
    {
        
    }

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        BindHideTableRows();
    }

    protected void Category1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAppCategor2();
    }

    protected void Save_Click(object sender, EventArgs e)
    {


        SqlCommand cmd = new SqlCommand("ApplicationList_Add", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());
        cmd.Parameters.AddWithValue("@Application", Application.Text.ToString());
        cmd.Parameters.AddWithValue("@Category1", Category1.Text.ToString());
        cmd.Parameters.AddWithValue("@Category2", Category2.Text.ToString());
        cmd.Parameters.AddWithValue("@Version", Version.Text.ToString());
        cmd.Parameters.AddWithValue("@Responsible", Responsible.Text.ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='Apps.aspx'</script></script>");

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
        SqlCommand cmd = new SqlCommand("ApplicationList_DELETE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Record Deleted Sucessfully');location.href='Apps.aspx'</script>");
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
        Response.Redirect("Apps.aspx");
    }

}