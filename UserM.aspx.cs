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




public partial class UserM : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
    SqlCommand cm = new SqlCommand();

    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsss = new DataSet();
    DataSet dssss = new DataSet();
    DataTable dt = new DataTable();
    DataSet dsgen = new DataSet();
    DataSet dsnat = new DataSet();
    DataSet dssec = new DataSet();
    DataSet dsy = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else if (Session["IsAuthenticate"] != "1")
        {
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='Userlist.aspx';</script></script>");
        }
        else
        {

            if (!this.IsPostBack)
            {
                if (Session["ID"] == null || Session["ID"].ToString() == "0" || Session["Roleid"] == null)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                else
                {
                    BindRole1();
                    ActiveStatus1();
                    BindMaster();
                    string Password1 = Password.Text;
                    Password.Attributes.Add("value", Password1);
                }
            }
        }
    }
    
    protected void BindMaster()
    {
        string IDD = null;
        string ChangePass = null;

        IDD = Session["ID"].ToString();
        ChangePass = Session["ChangePass"].ToString();
        if (ChangePass == "1")
        {
            Changepas.Visible = true;
            Cancel.Visible = false;
        }
        else 
        { 
            Changepas.Visible = false; 
        }


        string RTID = null;
        if (Session["UserM_ID"] == null || Session["UserM_ID"] == "")
        {
            RTID = "0";
            TID.Visible = false;
        }
        else
        {
            ID.ReadOnly = true;
            ID.BackColor = System.Drawing.Color.DarkGray;


            //BindENV.Attributes.Add("disabled", "disabled");
            //BindENV.BackColor = System.Drawing.Color.DarkGray;

            RTID = Session["UserM_ID"].ToString();
        }



        SqlCommand cmd = new SqlCommand("[Users_Edit]", cn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USERID", RTID);

        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Name"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100);
        cmd.Parameters["@UserName"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 100);
        cmd.Parameters["@RoleName"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Password"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@ActiveStatus", SqlDbType.NVarChar, 100);
        cmd.Parameters["@ActiveStatus"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
        cmd.Parameters["@Email"].Direction = ParameterDirection.Output;

        cmd.Parameters.Add("@HeaderText", SqlDbType.NVarChar, 100);
        cmd.Parameters["@HeaderText"].Direction = ParameterDirection.Output;

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            string password = cmd.Parameters["@Password"].Value.ToString();


            ID.Text = cmd.Parameters["@USERID"].Value.ToString();
            Name.Text = cmd.Parameters["@Name"].Value.ToString();
            UserName.Text = cmd.Parameters["@UserName"].Value.ToString();
            BindRole.Text = cmd.Parameters["@RoleName"].Value.ToString();
            //Password.Text = CommonClass.EnyDecrypt.Decrypt(password);
            //Password.Text = CommonClass.EnyDecrypt.Decrypt(password);
            //ActiveStatus.Text = cmd.Parameters["@ActiveStatus"].Value.ToString();
            Email.Text = cmd.Parameters["@Email"].Value.ToString();

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

    protected void BindRole1()
    {
        try
        {


            cn.Open();

            SqlCommand cm = new SqlCommand("SELECT RoleName FROM RoleMaster WHERE RoleID IN(1,2,3,4,5) order by RoleID ASC", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dss);
            BindRole.DataSource = dss;
            BindRole.DataTextField = "RoleName";
            BindRole.DataValueField = "RoleName";
            BindRole.DataBind();
            BindRole.Items.Insert(0, new ListItem(""));

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery; // "ins.aspx.cs";
            String Errorfunction = "BindRole1";
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

    protected void ActiveStatus1()
    {
        try
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("select Description   from ActiveStatus ", cn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dssss);
            ActiveStatus.DataSource = dssss;
            ActiveStatus.DataTextField = "Description";
            ActiveStatus.DataValueField = "Description";
            ActiveStatus.DataBind();
            ActiveStatus.Items.Insert(0, new ListItem(""));
            ActiveStatus.Items.Remove("");
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

    protected void Save_Click(object sender, EventArgs e)
    {
        if (Session["Roleid"] == null)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            BindRolePermission();
        }
    }

    protected void BindRolePermission()
    {
        SqlCommand cmd = new SqlCommand("RolePermission_Select", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Module", "User");

        cmd.Parameters.AddWithValue("@ActionSave", "Save");
        cmd.Parameters.AddWithValue("@ActionAdd", "Add");
        cmd.Parameters.AddWithValue("@ActionEdit", "Edit");
        cmd.Parameters.AddWithValue("@ActionDelete", "Delete");
        cmd.Parameters.AddWithValue("@RoleId", Session["Roleid"]);

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


        if (DataSave == "0" || DataAdd == "0" || DataEdit == "0" || DataDelete == "0")
        {
            Add.Enabled = false;
            Response.Write("<script language='javascript'>alert('You dont have Permission to perform this activity');location.href='userlist.aspx';</script></script>");
        }
        else
        {
            Savedata();
        }

    }

    protected void Savedata()
    {

        SqlCommand cmd = new SqlCommand("Users_Update", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ID.Text);
        cmd.Parameters.AddWithValue("@Name", Name.Text.ToString());
        cmd.Parameters.AddWithValue("@Password", CommonClass.EnyDecrypt.Encrypt(Password.Text.ToString()));
        cmd.Parameters.AddWithValue("@UserName", UserName.Text.ToString());
        cmd.Parameters.AddWithValue("@RoleName", BindRole.Text.ToString());
        cmd.Parameters.AddWithValue("@Email", Email.Text.ToString());
        cmd.Parameters.AddWithValue("@StatusName", ActiveStatus.Text.ToString());


        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();

            Response.Write("<script language='javascript'>alert('Data Updated Sucessfully');location.href='userlist.aspx'</script></script>");

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

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("userlist.aspx");
    }

    protected void BindRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}