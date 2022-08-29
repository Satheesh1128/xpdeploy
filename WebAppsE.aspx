<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="WebAppsE.aspx.cs" Inherits="WebAppsE" %>

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

                    <asp:TableRow Visible="false">
                        <asp:TableCell>
                            <asp:Label ID="Label1" runat="server" Text="ID" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ID" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label4" runat="server" Text="Client" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="BindClient" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                            <%-- <asp:DropDownList ID="BindClient" runat="server" CssClass="Textboxdesignaddscreen" OnSelectedIndexChanged="BindClient_SelectedIndexChanged">
                            </asp:DropDownList>--%>
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow>
                        <asp:TableCell>
                            <%--<div>  <img runat="server" id="Img"  /> </div>--%>
                            <asp:Label ID="Label3" runat="server" Text="Application" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Application" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                            <%--<asp:DropDownList ID="Application" runat="server" CssClass="Textboxdesignaddscreen">
                            </asp:DropDownList>--%>
                        </asp:TableCell>
                    </asp:TableRow>







                    <asp:TableRow Visible="false">
                        <asp:TableCell>
                            <asp:Label ID="Label20" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindENV" runat="server" CssClass="Textboxdesignaddscreen">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow Visible="false">
                        <asp:TableCell>
                            <asp:Label ID="Label2" runat="server" Text="Version" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Version" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>




                    <asp:TableRow runat="server" ID="FATHide">

                        <asp:TableCell runat="server" ID="FatSitHide">
                            <asp:Label ID="Label15" runat="server" Text="FAT/SIT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell runat="server" ID="PilotEnable">
                            <asp:Label ID="Label5" runat="server" Text="PILOT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell runat="server" ID="DemoEnable">
                            <asp:Label ID="Label6" runat="server" Text="DEMO" CssClass="Labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell runat="server" ID="TriEnable">
                            <asp:Label ID="Label9" runat="server" Text="Training" CssClass="Labels"></asp:Label>
                        </asp:TableCell>

                        <%--<asp:TableCell runat="server" ID="TriEnable">
                            <asp:Label ID="Label8" runat="server" Text="Training" CssClass="Labels"></asp:Label>
                        </asp:TableCell>--%>

                        <asp:TableCell>
                            <asp:TextBox ID="Url1" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="UATHide">


                        <asp:TableCell runat="server" ID="UATHide1">
                            <asp:Label ID="Label17" runat="server" Text="UAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell runat="server" ID="DemoEnable1">
                            <asp:Label ID="Label7" runat="server" Text="DEMOV2" CssClass="Labels"></asp:Label>
                        </asp:TableCell>



                        <asp:TableCell>
                            <asp:TextBox ID="Url2" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="PRDHide">
                        <asp:TableCell>
                            <asp:Label ID="Label19" runat="server" Text="PRD" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Url3" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                   

                    <asp:TableRow Visible="false">
                        <asp:TableCell>
                            <asp:Label ID="Label16" runat="server" Text="AppDependency" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="AppDependency" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow Visible="false">
                        <asp:TableCell>
                            <asp:Label ID="Label18" runat="server" Text="Jira" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Jira" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label21" runat="server" Text="ActiveStatus" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>

                            <asp:DropDownList ID="ActiveStatus" runat="server" CssClass="HTB ddl">
                                <asp:ListItem>Active</asp:ListItem>
                                <asp:ListItem>InActive</asp:ListItem>
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
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ID"
            Display="None" SetFocusOnError="True" ControlToValidate="ID"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
            SetFocusOnError="True" ErrorMessage="ID: Alphabetic/Numeric/Space are Allowed with Max length 15 Character"
            ControlToValidate="ID" ValidationExpression="^[a-zA-Z0-9\s]{1,15}$"></asp:RegularExpressionValidator>
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
