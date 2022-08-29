<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="UserM.aspx.cs" Inherits="UserM" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" type="text/css" href="WEBCSS/MasterEditTable.css" />
    <link rel="stylesheet" type="text/css" href="Css/Button.css" />
     <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
   


    <div class="col-12" style="margin: 40px auto auto auto;">
    <div class="col-3" style="background-color:white;color:white">
        -
        </div>

    <div class="col-6">
        <div class="col-12" style="text-align: center">
            <asp:Table runat="server">
            
               <asp:TableRow>
                <asp:TableHeaderCell ColumnSpan ="2" cssclass="HTB tableHeader">
                    <asp:Label ID="Header" runat="server" Text="Add / Modify User"></asp:Label>
                </asp:TableHeaderCell>
            </asp:TableRow>

                <asp:TableRow runat="server" ID="TID">
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="ID" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                       <asp:TextBox ID="ID" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label4" runat="server" Text="Name" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                       <asp:TextBox ID="Name" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label22" runat="server" Text="Role" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                     <asp:DropDownList ID="BindRole" runat="server" AutoPostBack="false" OnSelectedIndexChanged="BindRole_SelectedIndexChanged" CssClass="HTB ddladdscreen"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="UserName" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="UserName" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label3" runat="server" Text="Password" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                
                              
               

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label30" runat="server" Text="Email" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="Email" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                  

                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label21" runat="server" Text="Status" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:DropDownList ID="ActiveStatus" runat="server" CssClass="ddladdscreen">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                
               
              

                                
                 <asp:TableRow>
                    <asp:TableCell ColumnSpan ="2">
                        <asp:Button ID="Add" runat="server" class="HTB btns bd1"  Text="Save" CausesValidation="true" OnClick="Save_Click" />&nbsp;                    
                        
                       <asp:Button ID="Cancel" runat="server"  class="HTB btns bd3" Text="Cancel" CausesValidation="false" OnClick="Cancel_Click" />&nbsp; 
                        
                    </asp:TableCell>
                </asp:TableRow>
           </asp:Table>
            <br />
            <p id="Changepas" style="color:red" runat="server">Your password got expired / First Time login pl change...</p>
        </div>
    </div>
        












    <div class="col-12" style="text-align: center">
        
        
    </div>
    </div>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
        ShowSummary="false"></asp:ValidationSummary>

    

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ErrorMessage="Enter Name" 
    ControlToValidate="Name"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ErrorMessage="Select Role" 
    ControlToValidate="BindRole"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ErrorMessage="Enter Username" 
    ControlToValidate="UserName"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Please Enter password" 
    ControlToValidate="Password"></asp:RequiredFieldValidator>
           
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="None" ControlToValidate="Password" 
        runat="server" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$" 
        ErrorMessage="Password must be 8 characters long with at least One Numeric,Lower, Upper Case and One Special Character.">
    </asp:RegularExpressionValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ErrorMessage="Enter Email" 
    ControlToValidate="Email"></asp:RequiredFieldValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="None" ControlToValidate="Email" 
        runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ErrorMessage="Invalid Email">
    </asp:RegularExpressionValidator>
     



</asp:Content>
