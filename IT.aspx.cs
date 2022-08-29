
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

public partial class IT : System.Web.UI.Page
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
    DataSet onr = new DataSet();
    DataSet itcs = new DataSet();
    DataSet itts = new DataSet();

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
                BindHtmlTable();
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
            Owner.Items.Insert(0, new ListItem("--Owner--"));
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
            CurrentStatus.Items.Insert(0, new ListItem("--CurrentStatus--"));
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
            TicketStatus.Items.Insert(0, new ListItem("--TicketStatus--"));
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
            SqlCommand cmd = new SqlCommand("IssueTracker_SELECT", cn);
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.Parameters.AddWithValue("@Owner", Owner.Text);
            cmd.Parameters.AddWithValue("@ENV", BindENV.Text);
            cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus.Text);
            cmd.Parameters.AddWithValue("@TicketStatus", TicketStatus.Text);
            cmd.Parameters.AddWithValue("@Search", Search.Text);
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

        SqlCommand cmd = new SqlCommand("IssueTracker_SELECT", cn);
        cmd.Connection = cn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@Owner", Owner.Text);
        cmd.Parameters.AddWithValue("@ENV", BindENV.Text);
        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus.Text);
        cmd.Parameters.AddWithValue("@TicketStatus", TicketStatus.Text);
        cmd.Parameters.AddWithValue("@Search", Search.Text);
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
        Response.AddHeader("content-disposition", "attachment;filename=IssueTracker_" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + ".xlsx");
        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        Session["IT_ID"] = "";
        Response.Redirect("ITAE.aspx");
    }

    protected void Edit_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Response.Write("<script language='javascript'>alert('Place click on the row that you want to Edit');location.href='javascript:history.go(-1)'</script>");
        }
        else
        {
            Session["IT_ID"] = TextBox1.Text;
            Response.Redirect("ITAE.aspx");
        }
    }

    protected void Refresh_Click(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void CurrentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void TicketStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Owner_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }

    protected void Search_TextChanged(object sender, EventArgs e)
    {
        BindHtmlTable();
    }
}




