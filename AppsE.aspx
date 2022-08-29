<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="AppsE.aspx.cs" Inherits="AppsE" %>

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








                    <asp:TableRow runat="server" ID="TID">
                        <asp:TableCell>
                            <asp:Label ID="Label1" runat="server" Text="ID" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ID" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    


                    <asp:TableRow runat="server" ID="TApplication">
                        <asp:TableCell>
                            <%--<div>  <img runat="server" id="Img"  /> </div>--%>
                            <asp:Label ID="Label3" runat="server" Text="Application" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Application" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TCategory1">
                        <asp:TableCell>
                            <asp:Label ID="Label2" runat="server" Text="Category1" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Category1" runat="server" CssClass="Textboxdesignaddscreen" AutoPostBack="true" OnSelectedIndexChanged="Category1_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TCategory2">
                        <asp:TableCell>
                            <asp:Label ID="Label4" runat="server" Text="Category2" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Category2" runat="server" CssClass="Textboxdesignaddscreen">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TVersion">
                        <asp:TableCell>
                            <asp:Label ID="Label5" runat="server" Text="Version" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Version" runat="server" CssClass="Textboxdesignaddscreen">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>V1</asp:ListItem>
                                <asp:ListItem>V2</asp:ListItem>
                                <asp:ListItem>Both</asp:ListItem>
                                
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TResponsible">
                        <asp:TableCell>
                            <asp:Label ID="Label9" runat="server" Text="Responsible" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Responsible" runat="server" AppendDataBoundItems="true" CssClass="Textboxdesignaddscreen">
                                <asp:ListItem></asp:ListItem>
                               <%-- <asp:ListItem>Allok</asp:ListItem>
                                <asp:ListItem>Nawin</asp:ListItem>
                                <asp:ListItem>Satheesh</asp:ListItem>
                                <asp:ListItem>Karthi</asp:ListItem>
                                <asp:ListItem>Anand</asp:ListItem>
                                <asp:ListItem>Mukesh</asp:ListItem>--%>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="Save" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Save_Click" />&nbsp;
                            <%--<asp:Button ID="Insert" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Insert_Click" />&nbsp;--%>


                            <%--<input type="button" class="HTB btns bd3" value="Cancel" onclick="history.go(-1); return false;">--%>
                            
                            <asp:Button ID="Cancel" runat="server" class="HTB btns bd3" Text="Cancel" CausesValidation="false"  OnClick="Cancel_Click" />&nbsp;
                            <asp:Button ID="Delete" class="HTB btns bd3" runat="server" Text="Delete" CausesValidation="false"  OnClick="Delete_Click" />
                        </asp:TableCell>
                    </asp:TableRow>
                    
                </asp:Table>
                
            </div>
        </div>






        






        <div class="col-12" style="text-align: center">
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false"></asp:ValidationSummary>

        

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Application Name"
            Display="None" SetFocusOnError="True" ControlToValidate="Application"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select Category1"
            Display="None" SetFocusOnError="True" ControlToValidate="Category1"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="select Category2"
            Display="None" SetFocusOnError="True" ControlToValidate="Category2"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="select Responsible"
            Display="None" SetFocusOnError="True" ControlToValidate="Responsible"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="select Version"
            Display="None" SetFocusOnError="True" ControlToValidate="Version"></asp:RequiredFieldValidator>

        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ID"
            Display="None" SetFocusOnError="True" ControlToValidate="ID"></asp:RequiredFieldValidator>--%>
   <%--     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
            SetFocusOnError="True" ErrorMessage="ID: Alphabetic/Numeric/Space are Allowed with Max length 15 Character"
            ControlToValidate="ID" ValidationExpression="^[a-zA-Z0-9\s]{1,15}$"></asp:RegularExpressionValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select ENV"
            Display="None" SetFocusOnError="True" ControlToValidate="BindENV"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select Application"
            Display="None" SetFocusOnError="True" ControlToValidate="Application"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="select Application"
            Display="None" SetFocusOnError="True" ControlToValidate="ApplicationV1"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="select Config"
            Display="None" SetFocusOnError="True" ControlToValidate="Config"></asp:RequiredFieldValidator>

        --%>

      

                        </asp:Content>
