
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

public partial class Apps : System.Web.UI.Page
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
    DataSet bs = new DataSet();
    DataSet ac1 = new DataSet();
    DataSet ac2 = new DataSet();
    DataSet ac23 = new DataSet();
    DataSet au = new DataSet();



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
                BindAppCategor1();
                BindAppCategor2();                
                BindApplicationList();
                BindClient1();
                BindUser1();
                BindHtmlTable();
            }
        }
    }

    protected void BindAppCategor1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("SELECT * FROM AppCategory1 ORDER BY CategoryName DESC", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ac1);
            BindAppCategory1.DataSource = ac1;
            BindAppCategory1.DataTextField = "CategoryName";
            BindAppCategory1.DataValueField = "CategoryName";
            BindAppCategory1.DataBind();
            BindAppCategory1.Items.Insert(0, new ListItem("--Category1--"));

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindAppCategory2";
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
        try
        {
            cn.Open();
            if (BindAppCategory1.Text == "--Category1--")
            {
                SqlCommand cm = new SqlCommand("SELECT distinct A.CategoryName FROM AppCategory2 A INNER JOIN AppCategory1 B WITH(NOLOCK) ON B.Category1ID = A.Category1ID", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ac2);
                BindAppCategory2.DataSource = ac2;
                BindAppCategory2.DataTextField = "CategoryName";
                BindAppCategory2.DataValueField = "CategoryName";
                BindAppCategory2.DataBind();
                BindAppCategory2.Items.Insert(0, new ListItem("--Category2--"));
            }
            else
            {
                SqlCommand cm = new SqlCommand("SELECT * FROM AppCategory2 A INNER JOIN AppCategory1 B WITH(NOLOCK) ON B.Category1ID = A.Category1ID WHERE B.CategoryName = '" + BindAppCategory1.Text + "'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ac2);
                BindAppCategory2.DataSource = ac2;
                BindAppCategory2.DataTextField = "CategoryName";
                BindAppCategory2.DataValueField = "CategoryName";
                BindAppCategory2.DataBind();
                BindAppCategory2.Items.Insert(0, new ListItem("--Category2--"));
            }

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindAppCategory2";
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
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ApplicationListall, cn);
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
            cn.Open();
            String Action = "SelectData";
            SqlCommand cmd = new SqlCommand("ApplicationList_SELECT", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.Parameters.AddWithValue("@AppCategory2", BindAppCategory2.Text);
            cmd.Parameters.AddWithValue("@AppCategory1", BindAppCategory1.Text);
            cmd.Parameters.AddWithValue("@ServerName", BindServer.Text);
            cmd.Parameters.AddWithValue("@ActiveStatus", BindActiveStatus.Text);
            cmd.Parameters.AddWithValue("@Application", Application.Text);
            cmd.Parameters.AddWithValue("@Responsible", Responsible.Text);
            cmd.Parameters.AddWithValue("@Search", Search.Text);

            cmd.Parameters.Add("@Header1", SqlDbType.NVarChar, 1000000000);
            cmd.Parameters["@Header1"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Header2", SqlDbType.NVarChar, 1000000000);
            cmd.Parameters["@Header2"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@Header3", SqlDbType.NVarChar, 1000000000);
            cmd.Parameters["@Header3"].Direction = ParameterDirection.Output;

            sda.SelectCommand = cmd;
            sda.Fill(dt);
            cmd.ExecuteNonQuery();
            Header1.Text = cmd.Parameters["@Header1"].Value.ToString();
            Header2.Text = cmd.Parameters["@Header2"].Value.ToString();
            Header3.Text = cmd.Parameters["@Header3"].Value.ToString();
            
            
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
            cmd.ExecuteNonQuery();
        }
        
        finally
        {
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

        SqlCommand cmd = new SqlCommand("ApplicationList_SELECT", cn);
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@AppCategory2", BindAppCategory2.Text);
        cmd.Parameters.AddWithValue("@AppCategory1", BindAppCategory1.Text);
        cmd.Parameters.AddWithValue("@ServerName", BindServer.Text);
        cmd.Parameters.AddWithValue("@ActiveStatus", BindActiveStatus.Text);
        cmd.Parameters.AddWithValue("@Application", Application.Text);
        cmd.Parameters.AddWithValue("@Responsible", Responsible.Text);
        cmd.Parameters.AddWithValue("@Search", Search.Text);

        cmd.Parameters.Add("@Header1", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Header1"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Header2", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Header2"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Header3", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Header3"].Direction = ParameterDirection.Output;
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
        ds.Tables[0].TableName = "ApplicationList";
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
        Response.AddHeader("content-disposition", "attachment;filename=ApplicationList_" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".xlsx");
        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }

    protected void BindClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindServer1();
        BindHtmlTable();
    }

    protected void BindServer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void BindAppCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //if (BindAppCategory1.Text == "")
        //{
        //    BindAppCategory2.Visible = false;
        //}
        //else
        //{
        //    BindAppCategory2.Visible = true;
        //}
        BindAppCategor2();
        BindHtmlTable();
    }

    protected void BindAppCategory2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();

    }

    protected void Application_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void BindActiveStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Responsible_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Refresh_Click(object sender, EventArgs e)
    {
        BindHtmlTable();
    }    

    protected void Search_TextChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Edit_Click(object sender, EventArgs e)
    {
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

    protected void GoAppsAddEdit()
    {
        Session["Apps_ID"] = TextBox1.Text;
        String SessionID = TextBox1.Text;

        Session["IsAuthenticate"] = "1";
        String reponsepage = "Apps.aspx";
        String reponsegopage = "Appse.aspx";



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
        String ScreenModule = "Apps";
        String reponsepage = "Apps.aspx";


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




