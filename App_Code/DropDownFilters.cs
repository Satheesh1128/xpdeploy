/// <summary>
/// Summary description for CommonClass
/// </summary>
public class DropDownFilters
{
    public class DropDownList
    {
        public static string ApplicationList = "SELECT * FROM Applications WHERE VersionSupport IN (3,2) ORDER BY ApplicationName";
        public static string ApplicationListV1 = "SELECT * FROM Applications WHERE VersionSupport IN (3,1) ORDER BY ApplicationName";
        public static string ApplicationListall = "SELECT * FROM Applications ORDER BY ApplicationName";
        public static string WebApps = "SELECT ApplicationName FROM Applications WHERE AppCategory2 IN (SELECT Category2ID FROM AppCategory2 WHERE CategoryName in ('Web','WebService')) ORDER BY ApplicationName";
        public static string ENVName = "SELECT ENVName FROM ENVMaster WHERE ID NOT IN (4) ORDER BY ENVName ASC";
        public static string ServerName = "SELECT ServerName FROM ServerMaster ORDER BY ID ASC";
        public static string ClientMaster = "SELECT ClientName FROM ClientMaster";
        public static string ENVName_DBs = "SELECT * FROM ENVMaster WHERE ENVName NOT IN ('SAASV2') ORDER BY ID";
        public static string ENVLists = "SELECT * FROM ENVMasterList ORDER BY ENVListID ASC";
        public static string ENVName_ml = "SELECT * FROM ENVMaster";
        public static string hccbusers = "SELECT Name FROM Users WHERE RoleID = 3 ORDER BY Name";
        public static string adminusers = "SELECT UserName FROM Users WHERE RoleID = 1 ORDER BY UserName";

        //IT, ITAD

        public static string ITCurrentStatus = "SELECT * FROM ITStatus WITH(NOLOCK) WHERE Type = 'CurrentStatus' ORDER BY ID";
        public static string ITTicketStatus = "SELECT * FROM ITStatus WITH(NOLOCK) WHERE Type = 'TicketStatus' ORDER BY ID";
        public static string ITReleaseChange = "SELECT * FROM ITStatus WITH(NOLOCK) WHERE Type = 'ReleaseChange' ORDER BY ID";

    }
}