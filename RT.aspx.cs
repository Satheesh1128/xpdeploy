
using System;
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

public partial class RT : System.Web.UI.Page
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
    DataSet dsgen1 = new DataSet();
    DataSet bc = new DataSet();
    DataSet be = new DataSet();
    DataSet alv1 = new DataSet();

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
                //BindENV.Text = Session["BindENV"].ToString();
                //Application.Text = Session["Application"].ToString();
                //ReleasePending.Text = Session["ReleasePending"].ToString();
                //JiraSearch.Text = Session["JiraSearch"].ToString();


                if (Session["BindENV"].ToString() == "0" || Session["Application"].ToString() == "0" || Session["ReleasePending"].ToString() == "0" || Session["JiraSearch"].ToString() == "0")
                {
                    
                }
                else if(Session["Application"].ToString() == "")

                {
                    BindENV.Text = Session["BindENV"].ToString();
                    ReleasePending.Text = Session["ReleasePending"].ToString();
                    JiraSearch.Text = Session["JiraSearch"].ToString();
                }
                else
                {
                    BindENV.Text = Session["BindENV"].ToString();
                    Application.Text = Session["Application"].ToString();
                    ReleasePending.Text = Session["ReleasePending"].ToString();
                    JiraSearch.Text = Session["JiraSearch"].ToString();
                }
                





                BindENV1();
                BindApplicationList();
                BindApplicationListV1();
                ApplicationV1.Visible = false;
                BindClient1();
                BindHtmlTable();



            }
            else
            {
                //BindHtmlTable();
            }


            //if (!IsPostBack)
            //{
            //    BindENV1();

            //}
            //else
            //{
            //    BindHtmlTable();
            //}


        }
    }

    protected void BindSession()
    {
        Session["BindENV"] = BindENV.Text;
        Session["Application"] = Application.Text;
        Session["ReleasePending"] = ReleasePending.Text;
        Session["JiraSearch"] = JiraSearch.Text;
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

    protected void BindHtmlTable()
    {
        //Populating a DataTable from database.
        DataTable dt = this.GetData();

        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        //Table start.
        html.Append("<table id =DynamicTable class=TableClass>");

        html.Append("<tr ID=tablerow1 runat=server");

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
            SqlCommand cmd = new SqlCommand("ReleaseTracker_SELECT", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.Parameters.AddWithValue("@Client", BindClient.Text);
            cmd.Parameters.AddWithValue("@ENV", BindENV.Text);

            if (BindENV.Text == "SAAS")
            {
                cmd.Parameters.AddWithValue("@Application", ApplicationV1.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Application", Application.Text);
            }

            cmd.Parameters.AddWithValue("@ReleasePending", ReleasePending.Text);
            cmd.Parameters.AddWithValue("@JiraSearch", JiraSearch.Text);
            cmd.Parameters.Add("@Header", SqlDbType.NVarChar, 1000000000);
            cmd.Parameters["@Header"].Direction = ParameterDirection.Output;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            cn.Open();
            cmd.ExecuteNonQuery();
            Header.Text = cmd.Parameters["@Header"].Value.ToString();
            cn.Close();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HM.aspx.cs";
            String Errorfunction = "GetData";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");

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
        }
        return dt;
    }

    protected void Export_ExcelData(object sender, EventArgs e)
    {
        ExportExcel();
    }

    protected void ExportExcel()
    {
        SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        String Action = "ExportData";

        SqlCommand cmd = new SqlCommand("ReleaseTracker_SELECT", cn);
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@Client", BindClient.Text);
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text);
        cmd.Parameters.AddWithValue("@Application", Application.Text);
        cmd.Parameters.AddWithValue("@ReleasePending", ReleasePending.Text);
        cmd.Parameters.AddWithValue("@JiraSearch", JiraSearch.Text);
        cmd.Parameters.Add("@Header", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Header"].Direction = ParameterDirection.Output;
        sda.SelectCommand = cmd;
        sda.Fill(ds);
        //sda.Fill(dt);
        cn.Open();
        cmd.ExecuteNonQuery();
        //Header.Text = cmd.Parameters["@Header"].Value.ToString();
        cn.Close();

        cmd.Connection = cn;
        //sda.SelectCommand = cmd;
        //DataSet ds = new DataSet();
        //sda.Fill(ds);

        //Set Name of DataTables.
        ds.Tables[0].TableName = "MasterData";
        //ds.Tables[1].TableName = "Employees";

        XLWorkbook wb = new XLWorkbook();

        foreach (DataTable dt in ds.Tables)
        {
            //Add DataTable as Worksheet.
            wb.Worksheets.Add(dt);
        }
        //Export the Excel file.
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=ReleaseTracker_" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".xlsx");
        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }

    protected void Refresh_Click(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void BindClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (BindENV.Text == "SAAS")
        {
            Application.Visible = false;
            ApplicationV1.Visible = true;
            BindApplicationList();
        }
        else
        {
            Application.Visible = true;
            ApplicationV1.Visible = false;
            BindApplicationListV1();
        }


        if (BindENV.Text == "Training" || BindENV.Text == "DEMO" || BindENV.Text == "DEMOV2")
        {
            ReleasePending.Visible = false;
        }
        else
        {
            ReleasePending.Visible = true;
        }
        //BindApplicationList();
        BindHtmlTable();
    }

    protected void Application_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void ApplicationV1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void ReleasePending_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void JiraSearch_TextChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        CurrentEventName.Text = "Add";
        BindSession();

        if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            BindRolePermission();
        }
    }

    protected void Duplicate_Click(object sender, EventArgs e)
    {
        CurrentEventName.Text = "Duplicate";
        BindSession();

        if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        //else if (TextBox1.Text == "")
        //{
        //    Response.Write("<script language='javascript'>alert('Place click on the row that you want to Duplicate');location.href='javascript:history.go(-1)'</script>");
        //}
        else
        {            
            Session["DuplicateTicket"] = "Yes";
            //Session["BindClient"] = BindClient.Text;
            //Session["Application"] = Application.Text;
            BindRolePermission();
        }
    }

    

        protected void Edit_Click(object sender, EventArgs e)
    {
        CurrentEventName.Text = "Edit";
        Session["DuplicateTicket"] = "No";

        BindSession();

        //if (TextBox1.Text == "")
        //{
        //    Response.Write("<script language='javascript'>alert('Place click on the row that you want to Edit');location.href='javascript:history.go(-1)'</script>");
        //}
        if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            //Session["RT_ID"] = TextBox1.Text;
            //Session["DuplicateTicket"] = "No";
            //Session["BindClient"] = BindClient.Text;
            //Session["Application"] = Application.Text;
            //Response.Redirect("RTE.aspx");
            BindRolePermission();
        }
    }

    protected void GoAppsAddEdit()
    {
        Session["RT_ID"] = TextBox1.Text;
        String SessionID = TextBox1.Text;

        Session["IsAuthenticate"] = "1";
        String reponsepage = "rt.aspx";
        String reponsegopage = "rte.aspx";



        if (SessionID == "" && (CurrentEventName.Text == "Add" || CurrentEventName.Text == "Duplicate"))
        {
            if (CurrentEventName.Text == "Duplicate")
            {
                Response.Write("<script language='javascript'>alert('Pl Select a row to Duplicate');location.href='" + reponsepage + "';</script></script>");
            }
            else
            {
                Response.Redirect(reponsegopage);
            }            
        }
        else if (SessionID != "" && (CurrentEventName.Text == "Add" || CurrentEventName.Text == "Duplicate"))
        {
            if (CurrentEventName.Text == "Add")
            {
                Session["RT_ID"] = "";
                Response.Redirect(reponsegopage);
            }
            else
            {
                Session["RT_ID"] = TextBox1.Text;
                Response.Redirect(reponsegopage);
            }        
        }
        else if (SessionID == "" && CurrentEventName.Text == "Edit")
        {
            Response.Write("<script language='javascript'>alert('Pl Select a row to Edit');location.href='" + reponsepage + "';</script></script>");
        }
        else
        {
            Session["RT_ID"] = TextBox1.Text;
            Response.Redirect(reponsegopage);
        }
    }

    protected void BindRolePermission()
    {
        String ScreenModule = "rt";
        String reponsepage = "rt.aspx";


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




