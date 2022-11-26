using System.Configuration;



/// <summary>
/// Summary description for CommonClass
/// </summary>
public class ValidateUserCalss
{
    public class ValidateUserData
    {
        public static string conStr = ConfigurationManager.ConnectionStrings["_ConnectionString"].ConnectionString;
    }

    public class RolePermission
    {
        public static string RoleAction(string RoleAction)
        {
            return RoleAction;

        }

    }




}