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


public partial class RTE : System.Web.UI.Page
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
    


    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Write(Session["ID"].ToString());

        


        if (!this.Page.User.Identity.IsAuthenticated)
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
                BindENV1();
                BindApplicationList();
                BindApplicationListV1();

                BindClient1();
                BindHTSE();
                BindHideTableRows();
                //cancel2.Visible = false;

                if (Session["RT_ID"] == null || Session["RT_ID"] == "")
            {
                
                DEMOV2Hide.Visible = false;
                FATHide.Visible = false;
                    SITHide.Visible = false;
                    UATHide.Visible = false;
                    TReason.Visible = false;
                    PRDHide.Visible = false;
                TRIHide.Visible = false;
                SAASPILOTHide.Visible = false;
                SAASDEMOHide.Visible = false;

                TApplication.Visible = false;
                TVersion.Visible = false;
                TJira.Visible = false;
                TAD.Visible = false;
                TConfigChange.Visible = false;
                TRollback.Visible = false;
                Save.Visible = false;
                }

            }

        }

    }

    protected void BindSession()
    {
        Session["BindENV"].ToString(); ;
        Session["Application"].ToString();
        Session["ReleasePending"].ToString();
        Session["JiraSearch"].ToString();
    }

    protected void BindApplicationList()
    {


        try
        {
            cn.Open();


            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ApplicationList, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dsgen);
            Application.DataSource = dsgen;
            Application.DataTextField = "ApplicationName";
            Application.DataValueField = "ApplicationName";
            Application.DataBind();
            Application.Items.Insert(0, new ListItem(""));


        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindApplicationList";
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

    protected void BindApplicationListV1()
    {
        try
        {
            cn.Open();

            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ApplicationListV1, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(alv1);
            ApplicationV1.DataSource = alv1;
            ApplicationV1.DataTextField = "ApplicationName";
            ApplicationV1.DataValueField = "ApplicationName";
            ApplicationV1.DataBind();
            ApplicationV1.Items.Insert(0, new ListItem(""));




        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindApplicationListV1";
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

    protected void BindClient1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ClientMaster, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(bc);
            BindClient.DataSource = bc;
            BindClient.DataTextField = "ClientName";
            BindClient.DataValueField = "ClientName";
            BindClient.DataBind();

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

    protected void BindHTSE()
    {



        string RTID = null;
        //ID = Session["ID"].ToString();
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



            if (Session["RT_ID"] == null || Session["RT_ID"] == "")
            {
                RTID = "0";
                TID.Visible = false;
                Delete.Visible = false;
            }
            else
            {
                ID.ReadOnly = true;
                ID.BackColor = System.Drawing.Color.DarkGray;


                //BindENV.Attributes.Add("disabled", "disabled");
                //BindENV.BackColor = System.Drawing.Color.DarkGray;

                RTID = Session["RT_ID"].ToString();
            }



            SqlCommand cmd = new SqlCommand("[ReleaseTracker_EDIT]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", RTID);

            cmd.Parameters.Add("@Application", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Application"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@ENV", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@ENV"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Version", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Version"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@FATSIT", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@FATSIT"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@DEV", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@DEV"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@SIT", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@SIT"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@UAT", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@UAT"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@PRD", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@PRD"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@TRI", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@TRI"].Direction = ParameterDirection.Output;


            cmd.Parameters.Add("@DEMOV2", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@DEMOV2"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@DEMO", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@DEMO"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@PILOT", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@PILOT"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@AppDependency", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@AppDependency"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Jira", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Jira"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Reason"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Rollback", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Rollback"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Config", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@Config"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 1000000);
            cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();


                BindENV.Text = cmd.Parameters["@ENV"].Value.ToString();
                Application.Text = cmd.Parameters["@Application"].Value.ToString();
                ApplicationV1.Text = cmd.Parameters["@Application"].Value.ToString();
                Version.Text = cmd.Parameters["@Version"].Value.ToString();

                SITFAT.Text = cmd.Parameters["@FATSIT"].Value.ToString();
                DEV.Text = cmd.Parameters["@DEV"].Value.ToString();
                SIT.Text = cmd.Parameters["@SIT"].Value.ToString();
                UAT.Text = cmd.Parameters["@UAT"].Value.ToString();
                PRD.Text = cmd.Parameters["@PRD"].Value.ToString();
                TRI.Text = cmd.Parameters["@TRI"].Value.ToString();

                DEMOV2.Text = cmd.Parameters["@DEMOV2"].Value.ToString();
                DEMO.Text = cmd.Parameters["@DEMO"].Value.ToString();
                PILOT.Text = cmd.Parameters["@PILOT"].Value.ToString();
                
                AppDependency.Text = cmd.Parameters["@AppDependency"].Value.ToString();
                Reason.Text = cmd.Parameters["@Reason"].Value.ToString();
                Rollback.Text = cmd.Parameters["@Rollback"].Value.ToString();
                Config.Text = cmd.Parameters["@Config"].Value.ToString();
                Jira.Text = cmd.Parameters["@Jira"].Value.ToString();
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
    }

    protected void Save_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("ReleaseTracker_UPDATE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());
        if (BindENV.Text == "SAAS")
        {
            cmd.Parameters.AddWithValue("@Application", ApplicationV1.Text.ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@Application", Application.Text.ToString());
        }
        cmd.Parameters.AddWithValue("@Version", Version.Text.ToString());
        cmd.Parameters.AddWithValue("@Client", BindClient.Text.ToString());
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text.ToString());

        if ((SITFAT.Text == ""))
        {

            cmd.Parameters.Add("@SITFAT", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@SITFAT", SITFAT.Text);
        }

        if ((DEV.Text == ""))
        {

            cmd.Parameters.Add("@DEV", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@DEV", DEV.Text);
        }

        if ((SIT.Text == ""))
        {

            cmd.Parameters.Add("@SIT", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@SIT", SIT.Text);
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

        if ((TRI.Text == ""))
        {

            cmd.Parameters.Add("@TRI", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@TRI", TRI.Text);
        }

        //Xnapp2.0

        if ((DEMOV2.Text == ""))
        {

            cmd.Parameters.Add("@DEMOV2", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@DEMOV2", DEMOV2.Text);
        }



        if ((DEMO.Text == ""))
        {

            cmd.Parameters.Add("@DEMO", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@DEMO", DEMO.Text);
        }

        if ((PILOT.Text == ""))
        {

            cmd.Parameters.Add("@PILOT", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters.AddWithValue("@PILOT", PILOT.Text);
        }

        cmd.Parameters.AddWithValue("@AppDependency", AppDependency.Text.ToString());
        cmd.Parameters.AddWithValue("@Reason", Reason.Text.ToString());
        cmd.Parameters.AddWithValue("@Config", Config.Text.ToString());
        cmd.Parameters.AddWithValue("@Rollback", Rollback.Text.ToString());
        cmd.Parameters.AddWithValue("@Jira", Jira.Text.ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            BindSession();
            Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='rt.aspx'</script></script>");
            //if (Session["RT_ID"] == null || Session["RT_ID"] == "")
            //{
                
            //    //Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='javascript:history.go(-2)'</script></script>");
            //    Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='rt.aspx'</script></script>");
            //}
            //else
            //{
            //    Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='rt.aspx'</script></script>");
            //}
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
        Response.Write(SITFAT.Text);
    }

    protected void BindHideTableRows()
    {
        TApplication.Visible = true;
        TVersion.Visible = true;
        TJira.Visible = true;
        TAD.Visible = true;
        TConfigChange.Visible = true;
        TRollback.Visible = true;
        Save.Visible = true;
        

        if (BindENV.Text == "SAAS")
        {
            ApplicationV1.Visible = true;
            Application.Visible = false;
            
        }
        else
        {
            ApplicationV1.Visible = false;
            Application.Visible = true;
        }


        //if (BindENV.Text == "SAASV2")
        //{


        //    DEMOV2Hide.Visible = false;
        //    FATHide.Visible = true;
        //    UATHide.Visible = true;
        //    PRDHide.Visible = true;
        //    TRIHide.Visible = false;
        //    SAASPILOTHide.Visible = false;
        //    SAASDEMOHide.Visible = false;
        //    FATHide.Visible = false;
        //    DEVHide.Visible = false;
        //}

        if (BindENV.Text == "HCCB")
        {
            DEMOV2Hide.Visible = false;
            SITHide.Visible = true;
            FATHide.Visible = true;
            UATHide.Visible = true;
            PRDHide.Visible = true;
            TRIHide.Visible = false;
            SAASPILOTHide.Visible = false;
            SAASDEMOHide.Visible = false;
            DEVHide.Visible = false;
        }

        //else if (BindENV.Text == "SAAS")
        //{
        //    DEMOV2Hide.Visible = false;
        //    FATHide.Visible = true;
        //    UATHide.Visible = true;
        //    PRDHide.Visible = true;
        //    TRIHide.Visible = false;
        //    SAASPILOTHide.Visible = false;
        //    SAASDEMOHide.Visible = false;
        //    FATHide.Visible = false;
        //    DEVHide.Visible = false;
        //}

        //else if (BindENV.Text == "CCI")
        //{
        //    FATHide.Visible = false;
        //    UATHide.Visible = true;
        //    PRDHide.Visible = true;
        //    SAASDEMOHide.Visible = false;
        //    TRIHide.Visible = false;
        //    DEMOV2Hide.Visible = false;
        //    SAASPILOTHide.Visible = false;
        //    DEVHide.Visible = false;
        //}

        else if (BindENV.Text == "Training")
        {
            FATHide.Visible = false;
            UATHide.Visible = false;
            PRDHide.Visible = false;
            SAASDEMOHide.Visible = false;
            TRIHide.Visible = true;
            DEMOV2Hide.Visible = false;
            SAASPILOTHide.Visible = false;
            SITHide.Visible = false;
            DEVHide.Visible = false;
        }

        else if (BindENV.Text == "DEMO")
        {
            FATHide.Visible = false;
            UATHide.Visible = false;
            PRDHide.Visible = false;
            SAASDEMOHide.Visible = true;
            TRIHide.Visible = false;
            DEMOV2Hide.Visible = false;
            SAASPILOTHide.Visible = false;
            SITHide.Visible = false;
            DEVHide.Visible = false;
        }

        else if (BindENV.Text == "DEMOV2")
        {
            FATHide.Visible = false;
            UATHide.Visible = false;
            PRDHide.Visible = false;
            SAASDEMOHide.Visible = false;
            TRIHide.Visible = false;
            DEMOV2Hide.Visible = true;
            SAASPILOTHide.Visible = false;
            SITHide.Visible = false;
            DEVHide.Visible = false;
        }

        else if (BindENV.Text.Contains("UMP"))
        {
            FATHide.Visible = false;
            DEVHide.Visible = true;
            SITHide.Visible = true;
            UATHide.Visible = true;
            PRDHide.Visible = true;
            SAASDEMOHide.Visible = false;
            TRIHide.Visible = false;
            DEMOV2Hide.Visible = false;
            SAASPILOTHide.Visible = false;
        }

        else
        {
            FATHide.Visible = false;
            SITHide.Visible = true;
            UATHide.Visible = true;
            PRDHide.Visible = true;
            SAASDEMOHide.Visible = false;
            TRIHide.Visible = false;
            DEMOV2Hide.Visible = false;
            SAASPILOTHide.Visible = false;
            FATHide.Visible = false;
            DEVHide.Visible = false;
        }
    }

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindApplicationList();
        BindHideTableRows();
        //BindENV.Attributes.Add("disabled", "disabled");
        //BindENV.BackColor = System.Drawing.Color.DarkGray;
        //cancel2.Visible = true;
        //cancel1.Visible = false;
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("[ReleaseTracker_DELETE]", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text.ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            BindSession();
            Response.Write("<script language='javascript'>alert('Record Deleted Sucessfully');location.href='rt.aspx'</script></script>");
            //Response.Write("<script language='javascript'>alert('Record Deleted Sucessfully');location.href='javascript:history.go(-2)'</script>");
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



    protected void cancel1_Click(object sender, EventArgs e)
    {
        BindSession();
        Response.Redirect("rt.aspx");
    }
}