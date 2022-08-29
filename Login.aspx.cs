using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    //Response.Write(Decrypt(ConnectionStringClass.conStr));
    //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SanConnectionString"].ConnectionString);
    //string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //SqlConnection cn = new SqlConnection(Decrypt(connStr));

    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter();




    protected void Page_Load(object sender, EventArgs e)
    {



        //OTPValidate.Visible = false;
        if (!this.IsPostBack)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
    }



    public void ValidateUser(object sender, EventArgs e)
    {
        
        //ReleaseTracker
        Session["BindENV"] = 0;
        Session["BindENV"] = 0;
        Session["Application"] = 0;
        Session["ReleasePending"] = 0;
        Session["JiraSearch"] = 0;

        //DBS
        Session["dbsENV"] = 0;
        Session["dbsENVList"] = 0;
        Session["dbsStatus"] = 0;
        Session["dbsVersion"] = 0;
        Session["dbsSearch"] = 0;

        SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        int userId = 0;
        string PasswordE = CommonClass.EnyDecrypt.Encrypt(Convert.ToString(Password.Text));
        SqlCommand cmd = new SqlCommand("[User_LoginValidate]");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Username", UserName.Text);
        cmd.Parameters.AddWithValue("@Password", PasswordE);
        cmd.Parameters.Add("@RoleId", SqlDbType.Int);
        cmd.Parameters["@RoleId"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Class", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Class"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Section", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Section"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Medium", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Medium"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Phonenumber", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Phonenumber"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@OTP", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@OTP"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Changepassword", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Changepassword"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@UserId", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@UserId"].Direction = ParameterDirection.Output;
        cmd.Connection = cn;

        cn.Open();
        userId = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Parameters["@RoleId"].Value.ToString();
        string RoleIdd = cmd.Parameters["@RoleId"].Value.ToString();
        cn.Close();

        Session["username"] = UserName.Text;
        Session["Roleid"] = cmd.Parameters["@RoleId"].Value.ToString();
        Session["Class"] = cmd.Parameters["@Class"].Value.ToString();
        Session["Section"] = cmd.Parameters["@Section"].Value.ToString();
        Session["Medium"] = cmd.Parameters["@Medium"].Value.ToString();
        PhoneNumber.Text = cmd.Parameters["@Phonenumber"].Value.ToString();
        //OTPPassword.Text = cmd.Parameters["@OTP"].Value.ToString();
        OTP.Text = cmd.Parameters["@OTP"].Value.ToString();
        Session["ID"] = cmd.Parameters["@UserId"].Value.ToString();
        Session["ChangePass"] = cmd.Parameters["@Changepassword"].Value.ToString();
        string test = Session["ID"].ToString();



        //Response.Write(CommonClass.UserRoleCheck.UserRoleId(cmd.Parameters["@RoleId"].Value.ToString()));
        //Response.Write(Session["Medium"]);

        switch (userId)
        {
            case -1:

                Response.Write("<script language='javascript'>alert('Username/password is incorrect or user is inactive.!')</script>");
                break;

            case -2:

                Response.Write("<script language='javascript'>alert('Username/password is incorrect or user is inactive.!')</script>");
                break;



            default:

                FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);
                string Changepassword = cmd.Parameters["@Changepassword"].Value.ToString();
                if (Changepassword == "1")
                {
                    Response.Redirect("UserM.aspx");

                }

                //OTP.Visible = false;
                //Password.Visible = true;
                //OTPValidate.Visible = true;
                //UserValidate.Visible = false;
                //SentSMS();

                break;


        }


    }



    protected void ValidateUserOtp(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        int userId = 0;
        SqlCommand cmd = new SqlCommand("[User_OtpValidate]");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Username", UserName.Text);
        cmd.Parameters.AddWithValue("@Password", Convert.ToString(Password.Text));
        cmd.Parameters.AddWithValue("@Otp", OTP.Text);
        cmd.Parameters.Add("@RoleId", SqlDbType.Int);
        cmd.Parameters["@RoleId"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Class", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Class"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Section", SqlDbType.NVarChar, 1000000000);
        cmd.Parameters["@Section"].Direction = ParameterDirection.Output;
        cmd.Connection = cn;

        cn.Open();
        userId = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Parameters["@RoleId"].Value.ToString();
        string RoleIdd = cmd.Parameters["@RoleId"].Value.ToString();

        cn.Close();

        //Session["username"] = UserName.Text;
        //Session["Roleid"] = cmd.Parameters["@RoleId"].Value.ToString();
        //Session["Class"] = cmd.Parameters["@Class"].Value.ToString();
        //Session["Section"] = cmd.Parameters["@Section"].Value.ToString();
        //Response.Write(Session["Class"]);

        switch (userId)
        {
            case -1:

                Response.Write("<script language='javascript'>alert('Invalid/Expired OTP Kindly ReLogin Once again...');location.href='Login.aspx'</script>");
                break;

            case -2:

                Response.Write("<script language='javascript'>alert('Invalid/Expired OTP Kindly ReLogin Once again...');location.href='Login.aspx'</script>");
                break;



            default:
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);
                //if (RoleIdd == "6")
                //{
                //    Response.Redirect("Config.aspx");
                //}

                //if (RoleIdd == "5")
                //{
                //    Response.Redirect("SMC.aspx");
                //}

                //if (!url.Contains("%"))
                //{
                //    Response.Redirect("HTS.aspx");
                //}

                //else
                //{
                //    Response.Redirect("HTS.aspx");
                //}
                break;


        }
    }

    protected void SentSMS()
    {
        SqlConnection cn = new SqlConnection(CommonClass.EnyDecrypt.Decrypt(CommonClass.SQLConnectionName.conStr));
        try
        {
            System.Threading.Thread.Sleep(1000);
            string strUrl = "http://103.16.143.58/api/mt/SendSMS?user=satheeshKK&password=123123&senderid=SMSTST&channel=Trans&DCS=0&flashsms=0&number=" + PhoneNumber.Text + "&text=" + OTPPassword.Text + "&route=2";
            WebRequest request = HttpWebRequest.Create(strUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();

        }
        catch (Exception ex)
        {
            String Errorpage = HttpContext.Current.Request.Url.PathAndQuery; // HttpContext.Current.Request.Url.PathAndQuery;
            String Errorfunction = "SMS";
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
            Response.Write("<script language='javascript'>alert('OTP Sent To Your Registered Mobile Sucessfully')</script>");
        }
    }




    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<br/> " + HttpContext.Current.Request.Url.Host);
    //    Response.Write("<br/> " + HttpContext.Current.Request.Url.Authority);
    //    Response.Write("<br/> " + HttpContext.Current.Request.Url.Port);
    //    Response.Write("<br/> " + HttpContext.Current.Request.Url.AbsolutePath);
    //    Response.Write("<br/> " + HttpContext.Current.Request.ApplicationPath);
    //    Response.Write("<br/> " + HttpContext.Current.Request.Url.AbsoluteUri);
    //    Response.Write("<br/> " + HttpContext.Current.Request.Url.PathAndQuery);
    //}
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    //private string Encrypt(string clearText)
    //{
    //    string EncryptionKey = "SATH1128KATTAMPATTI";
    //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
    //    using (Aes encryptor = Aes.Create())
    //    {
    //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
    //        encryptor.Key = pdb.GetBytes(32);
    //        encryptor.IV = pdb.GetBytes(16);
    //        using (MemoryStream ms = new MemoryStream())
    //        {
    //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
    //            {
    //                cs.Write(clearBytes, 0, clearBytes.Length);
    //                cs.Close();
    //            }
    //            clearText = Convert.ToBase64String(ms.ToArray());
    //        }
    //    }
    //    return clearText;
    //}

    //private string Decrypt(string cipherText)
    //{
    //    string EncryptionKey = "SATH1128KATTAMPATTI";
    //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
    //    using (Aes encryptor = Aes.Create())
    //    {
    //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
    //        encryptor.Key = pdb.GetBytes(32);
    //        encryptor.IV = pdb.GetBytes(16);
    //        using (MemoryStream ms = new MemoryStream())
    //        {
    //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
    //            {
    //                cs.Write(cipherBytes, 0, cipherBytes.Length);
    //                cs.Close();
    //            }
    //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
    //        }
    //    }
    //    return cipherText;
    //}

}