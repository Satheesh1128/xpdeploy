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


public partial class ITAE : System.Web.UI.Page
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
    DataSet onr = new DataSet();
    DataSet itcs = new DataSet();
    DataSet itts = new DataSet();
    DataSet itrc = new DataSet();
    


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
                BindENV1();
                BindOwner1();
                BindCurrentStatus();
                BindTicketStatus();
                BindReleaseChange();
                BindData();

            }

        }

    }

    protected void BindOwner1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.hccbusers, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(onr);
            Owner.DataSource = onr;
            Owner.DataTextField = "Name";
            Owner.DataValueField = "Name";
            Owner.DataBind();
            Owner.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindOwner1";
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

    protected void BindCurrentStatus()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ITCurrentStatus, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(itcs);
            CurrentStatus.DataSource = itcs;
            CurrentStatus.DataTextField = "Status";
            CurrentStatus.DataValueField = "Status";
            CurrentStatus.DataBind();
            CurrentStatus.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindCurrentStatus";
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

    protected void BindTicketStatus()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ITTicketStatus, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(itts);
            TicketStatus.DataSource = itts;
            TicketStatus.DataTextField = "Status";
            TicketStatus.DataValueField = "Status";
            TicketStatus.DataBind();
            TicketStatus.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindTicketStatus";
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

    protected void BindReleaseChange()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ITReleaseChange, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(itrc);
            ReleaseChange.DataSource = itrc;
            ReleaseChange.DataTextField = "Status";
            ReleaseChange.DataValueField = "Status";
            ReleaseChange.DataBind();
            ReleaseChange.Items.Insert(0, new ListItem(""));
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindReleaseChange";
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
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ENVName, cn);
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

    protected void BindData()
    {
        string ITID = null;

        if (Session["ID"] == null || Session["ID"].ToString() == "0")
        {
            Response.Redirect("Login.aspx");
        }
        else if (Session["Roleid"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Session["IT_ID"] == null || Session["IT_ID"] == "")
            {
                ITID = "0";
                TID.Visible = false;
                Delete.Visible = false;
            }
            else
            {
                ID.ReadOnly = true;
                ID.BackColor = System.Drawing.Color.DarkGray;


                BindENV.Attributes.Add("disabled", "disabled");
                BindENV.BackColor = System.Drawing.Color.DarkGray;

                ITID = Session["IT_ID"].ToString();
            }



            SqlCommand cmd = new SqlCommand("IssueTracker_EDIT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ITID);

            cmd.Parameters.Add("@CurrentStatus", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@CurrentStatus"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@TicketStatus", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@TicketStatus"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@ENV", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@ENV"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@IssueSummary", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@IssueSummary"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@ReportedDate", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@ReportedDate"].Direction = ParameterDirection.Output;
            
            cmd.Parameters.Add("@FATSIT", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@FATSIT"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@UAT", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@UAT"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@PRD", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@PRD"].Direction = ParameterDirection.Output;            

            cmd.Parameters.Add("@ReleaseChange", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@ReleaseChange"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@DevJira", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@DevJira"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@DeployJira", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@DeployJira"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Owner", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Owner"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                ID.Text = cmd.Parameters["@ID"].Value.ToString();
                BindENV.Text = cmd.Parameters["@ENV"].Value.ToString();
                CurrentStatus.Text = cmd.Parameters["@CurrentStatus"].Value.ToString();
                TicketStatus.Text = cmd.Parameters["@TicketStatus"].Value.ToString();
                IssueSummary.Text = cmd.Parameters["@IssueSummary"].Value.ToString();

                ReportedDate.Text = cmd.Parameters["@ReportedDate"].Value.ToString();
                SITFAT.Text = cmd.Parameters["@FATSIT"].Value.ToString();
                UAT.Text = cmd.Parameters["@UAT"].Value.ToString();
                PRD.Text = cmd.Parameters["@PRD"].Value.ToString();
                
                ReleaseChange.Text = cmd.Parameters["@ReleaseChange"].Value.ToString();
                Owner.Text = cmd.Parameters["@Owner"].Value.ToString();
                DevJira.Text = cmd.Parameters["@DevJira"].Value.ToString();
                DeployJira.Text = cmd.Parameters["@DeployJira"].Value.ToString();
                HeaderText.Text = cmd.Parameters["@HeaderText"].Value.ToString();
                 
            }
            catch (Exception ex)
            {
                String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTSE.aspx.cs";
                String Errorfunction = "BindData";
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
    }

    protected void Save_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("IssueTracker_Update", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text.ToString());
        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus.Text.ToString());        
        cmd.Parameters.AddWithValue("@IssueSummary", IssueSummary.Text.ToString());
        cmd.Parameters.AddWithValue("@TicketStatus", @TicketStatus.Text.ToString());

        if ((ReportedDate.Text == ""))
        {

            cmd.Parameters.Add("@ReportedDate", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@ReportedDate", ReportedDate.Text);
        }


        if ((SITFAT.Text == ""))
        {

            cmd.Parameters.Add("@SITFAT", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@SITFAT", SITFAT.Text);
        }

        if ((UAT.Text == ""))
        {

            cmd.Parameters.Add("@UAT", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@UAT", UAT.Text);
        }

        if ((PRD.Text == ""))
        {

            cmd.Parameters.Add("@PRD", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@PRD", PRD.Text);
        }

        cmd.Parameters.AddWithValue("@ReleaseChange", ReleaseChange.Text.ToString());
        cmd.Parameters.AddWithValue("@DevJira", DevJira.Text.ToString());
        cmd.Parameters.AddWithValue("@DeployJira", DeployJira.Text.ToString());
        cmd.Parameters.AddWithValue("@Owner", Owner.Text.ToString());
        

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            if (Session["IT_ID"] == null || Session["IT_ID"] == "")
            {
                Response.Write("<script language='javascript'>alert('Data Inserted Sucessfully');location.href='javascript:history.go(-2)'</script></script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='javascript:history.go(-2)'</script></script>");
            }
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
        SqlCommand cmd = new SqlCommand("IssueTracker_DELETE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());

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

}