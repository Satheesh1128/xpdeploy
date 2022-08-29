<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="WEBCSS/Columns.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Css/Login.css" />
    <link href="Css/Login.css" rel="stylesheet" />
    <title></title>

</head>
<body style="background-color: #f1f1f1;">
    
    
    <form id="form1" runat="server">
     

        <div id="Login" class="col-12" style="margin-top:100px">
            <div class="imgcontainer" >
                
                <img style="border-radius:100px" src="Images/Logo.jpg" class="LI" />
            </div>

            <div class="col-4" style="color: white">
                -
            </div>
            <div class="col-4" style="text-align: center">
                <div class="container" style="background-color: #f1f1f1">

                    <asp:TextBox ID="UserName" placeholder="Enter Username" Text="" runat="server" autocomplete="off"
                        CssClass="Logintextbox" required></asp:TextBox>
                    <br />

                    <asp:TextBox ID="Password" placeholder="Password" Text="" TextMode="Password" AutoComplete="off" runat="server"
                        CssClass="Logintextbox" required></asp:TextBox>
                    <%--TextMode="Password"--%>

                    <asp:TextBox ID="OTP" placeholder="Enter OTP" AutoComplete="off" runat="server"
                        CssClass="Logintextbox" Visible="false" required></asp:TextBox>
                    <br />
                    <asp:Button ID="UserValidate" runat="server" Text="Login"  CssClass="button" OnClick="ValidateUser"></asp:Button> <%--Text="Validate"--%>
                    <%--<asp:Button ID="OTPValidate" runat="server" Text="Login" CssClass="button" OnClick="ValidateUserOtp"></asp:Button>--%>

                    <asp:TextBox ID="PhoneNumber" Visible="false" runat="server" ></asp:TextBox>
                    <asp:TextBox ID="OTPPassword" Visible="false" runat="server" ></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Login" CssClass="cancelbtn" Visible ="false"></asp:Button>
                        <%--<span class="psw">Forgot <a href="FP.aspx">password?</a></span>--%>
                </div>
                
                
                <%--<asp:Label ID="Errortext" runat="server" Text="Label" CssClass ="ErrorText" Visible="false"></asp:Label>--%>
            </div>
    </form>
</body>


</html>
