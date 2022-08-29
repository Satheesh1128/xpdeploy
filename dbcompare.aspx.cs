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

public partial class dbcompare : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
    SqlCommand cmd = new SqlCommand();
    SqlCommand cm = new SqlCommand();
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsss = new DataSet();
    DataSet dssss = new DataSet();
    DataSet dssec = new DataSet();
    DataSet dsmed = new DataSet();
    DataSet dsgen = new DataSet();
    DataSet be = new DataSet();
    DataSet bel = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated || Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
       

        //if (Session["Roleid"].ToString() == "1")
        //{
        //    AddUsers.Visible = true;
        //}
        //else
        //{
        //    AddUsers.Visible = false;
        //}


        if (!this.IsPostBack)
        {
            BindENVLists.Visible = false;
            DateTime today = DateTime.Today;
            FromDate.Text = today.ToString("dd-MMM-yyyy");
            datecalender.Text = today.ToString("dd-MMM-yyyy");

            BindENV1();
            BindENVList1();
            FetchButton(null, null);
        }


        
    }

    protected void BindENVList1()
    {
        try
        {
            cn.Open();
            //SqlCommand cm = new SqlCommand("SELECT * FROM ENVMasterList WHERE ENVID IN (SELECT ID FROM ENVMaster WHERE ENVName = '" + BindENV.Text + "')", cn);
            SqlCommand cm = new SqlCommand(DropDownFilters.DropDownList.ENVLists, cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(bel);
            BindENVLists.DataSource = bel;
            BindENVLists.DataTextField = "ENVListName";
            BindENVLists.DataValueField = "ENVListName";
            BindENVLists.DataBind();
            BindENVLists.Items.Insert(0, new ListItem("--Server--"));

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

    private DataSet GetData(string query)
    {
        string conString = CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr);
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
            DropDownList Difference = (e.Row.FindControl("Difference") as DropDownList);
            Difference.DataSource = GetData("select Name from [dbo].[Dropdowns] where category = 'DBCompare' order by id");
            Difference.DataTextField = "Name";
            Difference.DataValueField = "Name";
            Difference.DataBind();

            //Add Default Item in the DropDownList
            //ddlAtdday.Items.Insert(0, new ListItem("Please select"));

            //Select  DropDownList
            string DBDifference = (e.Row.FindControl("DBDifference") as Label).Text;
            Difference.Items.FindByValue(DBDifference).Selected = true;


            //Find the DropDownList in the Row
            DropDownList DiffVerified = (e.Row.FindControl("DiffVerified") as DropDownList);
            DiffVerified.DataSource = GetData("select '' AS DIFF UNION SELECT 'Y' UNION SELECT 'N'");
            DiffVerified.DataTextField = "DIFF";
            DiffVerified.DataValueField = "DIFF";
            DiffVerified.DataBind();

            //Add Default Item in the DropDownList
            //ddlAtdday.Items.Insert(0, new ListItem("Please select"));

            //Select  DropDownList
            string DiffVeri = (e.Row.FindControl("DiffVeri") as Label).Text;
            DiffVerified.Items.FindByValue(DiffVeri).Selected = true;
        }
    }



    protected void FetchButton(object sender, EventArgs e)
    {

        LabelMessage.Visible = false;
        try
        {

            cn.Open();
            SqlCommand cm = new SqlCommand("DBCompare_SELECT", cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Connection = cn;
            da.SelectCommand = cm;
            cm.Parameters.AddWithValue("@FromDate", FromDate.Text);
            cm.Parameters.AddWithValue("@CreatedDate", datecalender.Text);
            cm.Parameters.AddWithValue("@ENV", BindENV.Text);
            cm.Parameters.AddWithValue("@Owner", Owner.Text);
            cm.Parameters.AddWithValue("@Server", BindENVLists.Text);
            cm.Parameters.AddWithValue("@DBDiff", DBDiff.Text);
            cm.Parameters.Add("@Header", SqlDbType.NVarChar, 1000000000);
            cm.Parameters["@Header"].Direction = ParameterDirection.Output;
            
            //cm.Parameters.Add("@selectcolumn1", SqlDbType.NVarChar, 100);
            //cm.Parameters["@selectcolumn1"].Direction = ParameterDirection.Output;

            da.Fill(dt);
            //TextBox1.Text = cm.Parameters["@selectcolumn1"].Value.ToString();
            //TextBox1.Text = "Difference";
            GridView1.DataSource = dt;
            GridView1.DataBind();
            int TotalRowsCount = GridView1.Rows.Count;
            cm.ExecuteNonQuery();
            Header.Text = cm.Parameters["@Header"].Value.ToString();
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

    //protected void UpdateButton(object sender, EventArgs e)
    //{

    //    //cm = new SqlCommand("SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dbcomparison_Log]') AND type in (N'U')", cn);
    //    //try
    //    //{
    //    //    cn.Open();
    //    //    TextBox6.Text = cm.ExecuteScalar().ToString();
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
    //    //    String Errorfunction = "UpdateButtonStep1";
    //    //    string str = (ex.Message);
    //    //    string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
    //    //    SqlCommand cmd = new SqlCommand("Error_Insert", cn);
    //    //    cmd.Connection = cn;
    //    //    cmd.CommandType = CommandType.Text;
    //    //    cmd.CommandType = CommandType.StoredProcedure;
    //    //    cmd.Parameters.AddWithValue("@Exmessage", Exmessage);
    //    //    cmd.Parameters.AddWithValue("@Errorpage", Errorpage);
    //    //    cmd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
    //    //    cmd.ExecuteNonQuery();
    //    //    Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");

    //    //}
    //    //finally
    //    //{
    //    //    cn.Close();
    //    //}

    //    //try
    //    //{
    //    //    //if (Convert.ToInt32(TextBox6.Text) > 0)
    //    //    //{
    //    //    //    Response.Write("<script language=\"javascript\">alert('Pl wait for 2 to 3 seconds and then try because another process in Q!');location.href='dbcompare.aspx'</script>");

    //    //    //}
    //    //    //else
    //    //    //{

    //    //        cn.Open();


    //    //            //cm = new SqlCommand("insert into dbcomparison_Log (SourceDB,TargetDB,Difference ) values ('" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value + "') ", cn);

    //    //            cm = new SqlCommand("DBCompare_LOG", cn);


    //    //        cm.ExecuteNonQuery();
    //    //        //cn.Close();
    //    //    //}
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
    //    //    String Errorfunction = "create table dbcomparison_Log";
    //    //    string str = (ex.Message);
    //    //    string Exmessage = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
    //    //    SqlCommand cmd = new SqlCommand("Error_Insert", cn);
    //    //    cmd.Connection = cn;
    //    //    cmd.CommandType = CommandType.Text;
    //    //    cmd.CommandType = CommandType.StoredProcedure;
    //    //    cmd.Parameters.AddWithValue("@Exmessage", Exmessage);
    //    //    cmd.Parameters.AddWithValue("@Errorpage", Errorpage);
    //    //    cmd.Parameters.AddWithValue("@Errorfunction", Errorfunction);
    //    //    cmd.ExecuteNonQuery();
    //    //    Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(Exmessage) + "')</script>");

    //    //}
    //    //finally
    //    //{
    //    //    cn.Close();
    //    //}




    //}

    protected void CalcelButton(object sender, EventArgs e)
    {
        FetchButton(null, null);

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

    protected void BindENV_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindENVLists.Visible = true;
        BindENVList1();

        if (this.IsPostBack)
        {
            FetchButton(null, null);
        }
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        
        try
        {
            cn.Open();
            foreach (GridViewRow g1 in GridView1.Rows)
            {
                //cm = new SqlCommand("insert into dbcomparison_Log (SourceDB,TargetDB,Difference ) values ('" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value + "') ", cn);
                //Response.Write(g1.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);

                cm = new SqlCommand("insert into dbcomparison_Log (DB_ID,SourceDB,TargetDB,Difference,CreatedDate,ModifiedDateTime,[Diff-Verified] ) values ('" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value + "','" + datecalender.Text + "',GETDATE(),'" + g1.Cells[5].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value + "') ", cn);

                cm.ExecuteNonQuery();





            }

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "HTS.aspx.cs";
            String Errorfunction = "insert into dbcomparison_Log";
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

        SqlCommand cmddd = new SqlCommand("DBCompare_UPDATE", cn);
        cmddd.CommandType = CommandType.StoredProcedure;
        try
        {
            cn.Open();
            cmddd.ExecuteReader();
            LabelMessage.Visible = true;
        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // "users.aspx.cs";
            String Errorfunction = "DBCompare_UPDATE";
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void datecalender_TextChanged(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            FetchButton(null, null);
        }
    }

    protected void BindENVLists_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            FetchButton(null, null);
        }
    }

    protected void Owner_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            FetchButton(null, null);
        }
    }

    protected void DBDiff_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            FetchButton(null, null);
        }
    }


}




