<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="mle.aspx.cs" Inherits="mle" %>

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








                    <asp:TableRow runat="server" ID="IDT">
                        <asp:TableCell>
                            <asp:Label ID="Label1" runat="server" Text="ID" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ID" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="ENVTTB">
                        <asp:TableCell>
                            <asp:Label ID="Label3" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ENVTB" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow runat="server" ID="ENVT">
                        <asp:TableCell>
                            <asp:Label ID="Label20" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindENV" runat="server" CssClass="Textboxdesignaddscreen" AutoPostBack="false" OnSelectedIndexChanged="BindENV_SelectedIndexChanged">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow runat="server" ID="ClientsT">
                        <asp:TableCell>
                            <asp:Label ID="Label2" runat="server" Text="Clients" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Clients" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="ServerNameTDD">
                        <asp:TableCell>
                            <asp:Label ID="Label6" runat="server" Text="ServerType" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindServer" runat="server" CssClass="Textboxdesignaddscreen" AutoPostBack="false">
                                
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="ServerNameTTB">
                        <asp:TableCell>
                            <asp:Label ID="Label4" runat="server" Text="ServerName" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ServerName" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="ServerListT">
                        <asp:TableCell>
                            <asp:Label ID="Label5" runat="server" Text="ServerList" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ServerList" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                   
                    <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label21" runat="server" Text="Status" CssClass="Labels"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:DropDownList ID="ActiveStatus" runat="server" CssClass="ddladdscreen">
                             <asp:ListItem></asp:ListItem>
                             <asp:ListItem>Active</asp:ListItem>
                             <asp:ListItem>InActive</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>


                   





                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="Save" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Save_Click" />&nbsp;
                            <%--<asp:Button ID="Insert" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Insert_Click" />&nbsp;--%>


                            <%--<input type="button" class="HTB btns bd3" value="Cancel" onclick="history.go(-1); return false;">--%>
                            <asp:Button ID="btnCancel" class="HTB btns bd3" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />&nbsp;
                            <asp:Button ID="Delete" class="HTB btns bd3" runat="server" Text="Delete" OnClick="Delete_Click" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>













        <div class="col-3" style="text-align: center">
            <asp:Label ID="Mandatory" runat="server" ForeColor="Red" Text="➼Need to Mention atleast 1 DB" Visible="false"></asp:Label>
        </div>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false"></asp:ValidationSummary>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select the ENV"
            Display="None" SetFocusOnError="True" ControlToValidate="BindENV"></asp:RequiredFieldValidator>

       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Add Client Name"
            Display="None" SetFocusOnError="True" ControlToValidate="Clients"></asp:RequiredFieldValidator>

         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Add Client ENV"
            Display="None" SetFocusOnError="True" ControlToValidate="ENVTB"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Add Client Server Name"
            Display="None" SetFocusOnError="True" ControlToValidate="ServerName"></asp:RequiredFieldValidator>

         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Add Client Server List"
            Display="None" SetFocusOnError="True" ControlToValidate="ServerList"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Add Status"
            Display="None" SetFocusOnError="True" ControlToValidate="ActiveStatus"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Add ServerType"
            Display="None" SetFocusOnError="True" ControlToValidate="BindServer"></asp:RequiredFieldValidator>
        
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="select the Status"
            Display="None" SetFocusOnError="True" ControlToValidate="Status"></asp:RequiredFieldValidator>--%>

</asp:Content>
