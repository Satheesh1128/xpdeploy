<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="DevOpse.aspx.cs" Inherits="DevOpse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

    <link rel="stylesheet" type="text/css" href="WEBCSS/MasterEditTable.css" />

    <div class="col-12" style="margin: 80px auto auto auto;">
        <div class="col-3" style="background-color: white; color: white">
            -
        </div>




        <div class="col-6">
            <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
            <div class="col-12" style="text-align: center">
                <asp:Table runat="server">

                    <asp:TableRow>


                        <asp:TableHeaderCell ColumnSpan="2" CssClass="HTB tableHeader">

                            <asp:Label ID="HeaderText" runat="server" CssClass="Labels"></asp:Label>

                        </asp:TableHeaderCell>
                    </asp:TableRow>


                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label20" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>                           
                            <asp:TextBox ID="BindENV" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>

                            <asp:Label ID="Label3" runat="server" Text="Application" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            
                            <asp:TextBox ID="Application" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label2" runat="server" Text="CodeDeployName" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="CodeDeployName" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label1" runat="server" Text="CodePipelineName" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="CodePipelineName" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label4" runat="server" Text="S3" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="S3" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label5" runat="server" Text="App_Spec" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="App_Spec" runat="server" TextMode="MultiLine" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label6" runat="server" Text="ActiveStatus" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindActiveStatus" runat="server" CssClass="HTB ddl" OnSelectedIndexChanged="BindActiveStatus_SelectedIndexChanged">
                                <asp:ListItem>Active</asp:ListItem>
                                <asp:ListItem>InActive</asp:ListItem>
                                <%--<asp:ListItem>All</asp:ListItem>--%>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>





                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="Save" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Save_Click" />&nbsp;
                    
                       
                            <%--<input type="button" class="HTB btns bd3" value="Cancel" onclick="history.go(-1); return false;">--%>
                            <asp:Button ID="btnCancel" class="HTB btns bd3" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>













        <div class="col-12" style="text-align: center">
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false"></asp:ValidationSummary>
        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ID"
            Display="None" SetFocusOnError="True" ControlToValidate="ID"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
            SetFocusOnError="True" ErrorMessage="ID: Alphabetic/Numeric/Space are Allowed with Max length 15 Character"
            ControlToValidate="ID" ValidationExpression="^[a-zA-Z0-9\s]{1,15}$"></asp:RegularExpressionValidator>--%>
        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Code"
        ControlToValidate="Code" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None"
        SetFocusOnError="True" ErrorMessage="Code: Alphabetic/Numeric are Allowed with Max length 15 Character"
        ControlToValidate="Code" ValidationExpression="^[a-zA-Z0-9]{1,15}$"></asp:RegularExpressionValidator>--%>
        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Name"
        ControlToValidate="Name" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="None"
        SetFocusOnError="True" ErrorMessage="Name: Alphabetic and Space are Allowed with Max length 30 Character"
        ControlToValidate="Name" ValidationExpression="^[a-zA-Z\s]{1,30}$"></asp:RegularExpressionValidator>--%>
</asp:Content>
