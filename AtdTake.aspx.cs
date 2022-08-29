using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


public partial class AtdTake : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
    SqlCommand cm = new SqlCommand();
    DataSet ds = new DataSet(), dss = new DataSet(), dsss = new DataSet(), Sec = new DataSet(), Cls = new DataSet(), Med = new DataSet(), dssss = new DataSet();
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter();
    DataView dv = new DataView();

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
      
        string RoleID = null;
        //ID = Session["ID"].ToString();
        if (Session["Roleid"] == null || Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            RoleID = Session["Roleid"].ToString();
        }

        //if (RoleID != "1")
        //{
        //    DropDownList5.Enabled = false;
        //    DropDownList6.Enabled = false;
        //}

        if (!this.IsPostBack)
        {
            //if (RoleID == "3")
            //{
            //    DropDownList5.Attributes.Add("disabled", "disabled");
            //    DropDownList6.Attributes.Add("disabled", "disabled");
            //}

            //if (RoleID != "1")
            //{
            //    DropDownList5.Visible = true;
            //    DropDownList6.Visible = true;
            //}
            //BindYear1();
            //BindAtdMonth();
            //BindClass();
            //BindSec();
            //BindGrid();
            //BindMedium();
            //FetchButton(null, null);
        }

        try
        {
            int TotalRowsCount = GridView1.Rows.Count;
            TextBox2.Text = ("" + "  " + TotalRowsCount);
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "PageLoad";
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
        }


    }

    protected void BindYear1()
    {


        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("SELECT Distinct YEAR FROM Month ORDER BY year DESC", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dssss);
            BindYear.DataSource = dssss;
            BindYear.DataTextField = "YEAR";
            BindYear.DataValueField = "YEAR";
            BindYear.DataBind();
            //BindYear.Items.Insert(0, new ListItem(""));





        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "BindYear1";
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

    private void BindAtdMonth()
    {
        SqlCommand cmdd = new SqlCommand("Attendance_Insert", cn);
        cmdd.CommandType = CommandType.StoredProcedure;
        try
        {
            cn.Open();
            cmdd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "BindAtdMonth";
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

    private void BindGrid()
    {

        SqlCommand cmd = new SqlCommand("DBs_Compare_SELECT", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@Username", Username);
        //cmd.Parameters.AddWithValue("@Classinput", DropDownList5.Text);
        //cmd.Parameters.AddWithValue("@Sectioninput", DropDownList6.Text);
        //cmd.Parameters.AddWithValue("@Mediuminput", Mediuminput.Text);
        //cmd.Parameters.Add("@AtdDate", SqlDbType.NVarChar, 100);
        //cmd.Parameters["@AtdDate"].Direction = ParameterDirection.Output;
        //cmd.Parameters.Add("@AtdClass", SqlDbType.NVarChar, 100);
        //cmd.Parameters["@AtdClass"].Direction = ParameterDirection.Output;
        //cmd.Parameters.Add("@AtdSec", SqlDbType.NVarChar, 100);
        //cmd.Parameters["@AtdSec"].Direction = ParameterDirection.Output;
        //cmd.Parameters.Add("@AtdMedium", SqlDbType.NVarChar, 100);
        //cmd.Parameters["@AtdMedium"].Direction = ParameterDirection.Output;
        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "BindGrid";
            string str = (ex.Message);
            string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
            SqlCommand cmdc = new SqlCommand("Error_Insert", cn);
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

        //Attendancedate.Text = cmd.Parameters["@AtdDate"].Value.ToString();
        //DropDownList5.Text = cmd.Parameters["@AtdClass"].Value.ToString();
        //DropDownList6.Text = cmd.Parameters["@AtdSec"].Value.ToString();
    }
    
    protected void BindClass()
    {
        try
        {
            cn.Open();
            string ClassName = Session["Class"].ToString();
            string RoleID = Session["Roleid"].ToString();
            if (RoleID == "1" || RoleID == "2")
            {
                ClassName = "";
            }


                SqlCommand cm = new SqlCommand("SELECT classname FROM ClassMaster WHERE ClassName <>'ALL' AND (ClassName = '" + ClassName + "' OR ISNULL('" + ClassName + "', '') = '')  ORDER BY ClassID ASC", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(Cls);
                DropDownList5.DataSource = Cls;
                DropDownList5.DataTextField = "ClassName";
                DropDownList5.DataValueField = "ClassName";
                DropDownList5.DataBind();
           

            //if (RoleID == "3")
            //{

            //    SqlCommand cm1 = new SqlCommand("SELECT DISTINCT Class FROM TeacherClass where YEAR = '" + BindYear.Text + "'AND UserId IN (SELECT UserId FROM Users WHERE UserName  = '" + Session["username"].ToString() + "')", cn);
            //    SqlDataAdapter da1 = new SqlDataAdapter(cm1);
            //    da1.Fill(Cls);
            //    DropDownList5.DataSource = Cls;
            //    DropDownList5.DataTextField = "Class";
            //    DropDownList5.DataValueField = "Class";
            //    DropDownList5.DataBind();

            //}
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "BindClass";
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

    protected void BindSec()
    {
        try
        {
            cn.Open();
            string SectionName = Session["Section"].ToString();
            string RoleID = Session["Roleid"].ToString();
            if (RoleID == "1" || RoleID == "2")
            {
                SectionName = "";
            }
                SqlCommand cm = new SqlCommand("select sectionname from Section where (SectionName = '" + SectionName + "' OR ISNULL('" + SectionName + "', '') = '')  order by ID  asc", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(Sec);
                DropDownList6.DataSource = Sec;
                DropDownList6.DataTextField = "sectionname";
                DropDownList6.DataValueField = "sectionname";
                DropDownList6.DataBind();
            
            //if (RoleID == "3")
            //{

            //    SqlCommand cm2 = new SqlCommand("SELECT DISTINCT Section FROM TeacherClass where YEAR = '" + BindYear.Text + "'AND UserId IN (SELECT UserId FROM Users WHERE UserName  = '" + Session["username"].ToString() + "')", cn);
            //    SqlDataAdapter da2 = new SqlDataAdapter(cm2);
            //    da2.Fill(Sec);
            //    DropDownList6.DataSource = Sec;
            //    DropDownList6.DataTextField = "Section";
            //    DropDownList6.DataValueField = "Section";
            //    DropDownList6.DataBind();

            //}
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "BindSec";
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

    protected void BindMedium()
    {
        try
        {
            cn.Open();
            string MediumName = Session["Medium"].ToString();
            string RoleID = Session["Roleid"].ToString();
            if (RoleID == "1" || RoleID == "2")
            {
                MediumName = "";
            }
                SqlCommand cm = new SqlCommand("select Description from MediumMaster where (Description = '" + MediumName + "' OR ISNULL('" + MediumName + "', '') = '')  order by ID  asc", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(Med);
                Mediuminput.DataSource = Med;
                Mediuminput.DataTextField = "Description";
                Mediuminput.DataValueField = "Description";
                Mediuminput.DataBind();
            

            //if (RoleID == "3")
            //{

            //    SqlCommand cm = new SqlCommand("SELECT DISTINCT MediumInstruction FROM TeacherClass where YEAR = '" + BindYear.Text + "'AND UserId IN (SELECT UserId FROM Users WHERE UserName  = '" + Session["username"].ToString() + "')", cn);
            //    SqlDataAdapter da = new SqlDataAdapter(cm);
            //    da.Fill(Med);
            //    Mediuminput.DataSource = Med;
            //    Mediuminput.DataTextField = "MediumInstruction";
            //    Mediuminput.DataValueField = "MediumInstruction";
            //    Mediuminput.DataBind();
            //}
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "BindMedium";
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

    protected void Holiday_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow g1 in GridView1.Rows)
            {

                g1.Cells[2].Controls.OfType<DropDownList>().LastOrDefault().SelectedValue = "H";


            }
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "Holiday_Click";
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

    protected void PresentButton_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow g1 in GridView1.Rows)
            {

                g1.Cells[2].Controls.OfType<DropDownList>().LastOrDefault().SelectedValue = "P";



            }
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "PresentButton_Click";
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

    protected void CalcelButton(object sender, EventArgs e)
    {
        Response.Redirect("AtdReports.aspx");
    }

    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='MediumSpringGreen ';";
    //        e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
    //        e.Row.ToolTip = "Click to Edit";
    //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
    //        e.Row.Attributes["style"] = "cursor:pointer";
    //    }
    //}

    private DataSet GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the DropDownList in the Row
            DropDownList ddlAtdday = (e.Row.FindControl("ddlAtdday") as DropDownList);
            ddlAtdday.DataSource = GetData("select code from AttendanceCode ");
            ddlAtdday.DataTextField = "code";
            ddlAtdday.DataValueField = "code";
            ddlAtdday.DataBind();

            //Add Default Item in the DropDownList
            //ddlAtdday.Items.Insert(0, new ListItem("Please select"));

            //Select  DropDownList
            string Atddays = (e.Row.FindControl("Atdday") as Label).Text;
            ddlAtdday.Items.FindByValue(Atddays).Selected = true;
        }
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow.Cells[2].Text == "P")
        {
            GridView1.SelectedRow.Cells[2].Text = "A";
        }
        else if (GridView1.SelectedRow.Cells[2].Text == "A")
        {
            GridView1.SelectedRow.Cells[2].Text = "OD";
        }
        else
        {
            GridView1.SelectedRow.Cells[2].Text = "P";
        }
    }

    protected void UpdateButton(object sender, EventArgs e)
    {
        
        cm = new SqlCommand("SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance_Log]') AND type in (N'U')", cn);
        try
        {
            cn.Open();
            TextBox6.Text = cm.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "UpdateButtonStep1";
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

        try
        {
            if (Convert.ToInt32(TextBox6.Text) > 0)
            {
                Response.Write("<script language=\"javascript\">alert('Pl wait for 2 to 3 seconds and then try because another process in Q!');location.href='AtdTake.aspx'</script>");

            }
            else
            {
                cm = new SqlCommand("create table Attendance_Log (Studentcode nvarchar(max),StudentName nvarchar(max)," + TextBox1.Text + " nvarchar(max),Month nvarchar(max))", cn);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            Session["Error"] = ex.Message;
            Session["PageCode"] = "AtdTake.aspx";
            Session["Section"] = "UpdateButton_create_Attendance_Log";
            Response.Redirect("errorpage.aspx");
        }
        finally
        {
            cn.Close();
        }

        try
        {
            foreach (GridViewRow g1 in GridView1.Rows)
            {
                cm = new SqlCommand("insert into Attendance_Log (Studentcode,StudentName," + TextBox1.Text + ",Month ) values ('" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value + "',SUBSTRING('" + Attendancedate.Text + "', 4, 8)) ", cn);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            Session["Error"] = ex.Message;
            Session["PageCode"] = "AtdTake.aspx";
            Session["Section"] = "UpdateButton_insert_Attendance_Log";
            Response.Redirect("errorpage.aspx");
        }
        finally
        {
            cn.Close();
        }

        SqlCommand cmddd = new SqlCommand("Attendance_Update", cn);
        cmddd.CommandType = CommandType.StoredProcedure;
        try
        {
            cn.Open();
            cmddd.ExecuteReader();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "Attendance_Update";
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

        Response.Write("<script language='javascript'>alert('Updated Successfully');location.href='AbsentList.aspx'</script>");
    }

    protected void FetchButton(object sender, EventArgs e)
    {


        try
        {
            cn.Open();
            string atdDate;
            atdDate = Attendancedate.Text;
            string atdclass;
            atdclass = DropDownList5.Text;
            string atdsec;
            atdsec = DropDownList6.Text;
            string atdMed;
            atdMed = Mediuminput.Text;
            SqlCommand cm = new SqlCommand("Attendance_Take", cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Connection = cn;
            da.SelectCommand = cm;
            cm.Parameters.AddWithValue("@atdDate", atdDate);
            cm.Parameters.AddWithValue("@atdclass", atdclass);
            cm.Parameters.AddWithValue("@atdsec", atdsec);
            cm.Parameters.AddWithValue("@atdMed", atdMed);
            cm.Parameters.Add("@selectcolumn1", SqlDbType.NVarChar, 100);
            cm.Parameters["@selectcolumn1"].Direction = ParameterDirection.Output;

            da.Fill(dt);
            TextBox1.Text = cm.Parameters["@selectcolumn1"].Value.ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            int TotalRowsCount = GridView1.Rows.Count;
            //int TotalRowsCount = 10;
            TextBox2.Text = ("" + "  " + TotalRowsCount);
            cm.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "FetchButton";
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

    protected void DropDownList5_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FetchButton(null, null);
    }

    protected void DropDownList6_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FetchButton(null, null);
    }

    protected void Attendancedate_TextChanged1(object sender, EventArgs e)
    {

        FetchButton(null, null);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        String test;

        foreach (GridViewRow row in GridView1.Rows)
        {
            test = row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value;
            Response.Write(test);
        }

    }

    protected void Mediuminput_SelectedIndexChanged(object sender, EventArgs e)
    {
        FetchButton(null, null);
    }
}