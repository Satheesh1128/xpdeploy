<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="ITAE.aspx.cs" Inherits="ITAE" %>

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

                   

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label20" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindENV" runat="server" CssClass="Textboxdesignaddscreen">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TCurrentStatus">
                        <asp:TableCell>
                            <asp:Label ID="Label3" runat="server" Text="CurrentStatus" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="CurrentStatus" runat="server" CssClass="Textboxdesignaddscreen">
                               <%-- <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Development</asp:ListItem>
                                <asp:ListItem>SIT-Testing</asp:ListItem>
                                <asp:ListItem>UAT-Testing</asp:ListItem>
                                <asp:ListItem>Ready to Release</asp:ListItem>--%>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TTicketStatus">
                        <asp:TableCell>
                            <asp:Label ID="Label10" runat="server" Text="TicketStatus" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="TicketStatus" runat="server" CssClass="Textboxdesignaddscreen">
                                <%--<asp:ListItem></asp:ListItem>
                                <asp:ListItem>Open</asp:ListItem>
                                <asp:ListItem>Closed</asp:ListItem>
                                <asp:ListItem>Void</asp:ListItem>--%>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TIssueSummary">
                        <asp:TableCell>
                            <asp:Label ID="Label2" runat="server" Text="IssueSummary" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="IssueSummary" runat="server" TextMode="MultiLine" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TReportedDate">
                        <asp:TableCell>
                            <asp:Label ID="Label9" runat="server" Text="ReportedDate" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ReportedDate" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="ReportedDate"
                                PopupButtonID="ReportedDate" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow runat="server" ID="TSITFAT">
                        <asp:TableCell>
                            <asp:Label ID="Label15" runat="server" Text="SIT/FAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SITFAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="SITFAT"
                                PopupButtonID="SITFAT" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="TUAT">
                        <asp:TableCell>
                            <asp:Label ID="Label17" runat="server" Text="UAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="UAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="UAT"
                                PopupButtonID="UAT" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="TPRD">
                        <asp:TableCell>
                            <asp:Label ID="Label19" runat="server" Text="PRD" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="PRD" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="PRD"
                                PopupButtonID="PRD" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    

                    

                    <asp:TableRow runat="server" ID="TDevJira">
                        <asp:TableCell>
                            <asp:Label ID="Label18" runat="server" Text="DevJira" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="DevJira" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TDeployJira">
                        <asp:TableCell>
                            <asp:Label ID="Label11" runat="server" Text="DeployJira" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="DeployJira" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TReleaseChange">
                        <asp:TableCell>
                            <asp:Label ID="Label16" runat="server" Text="ReleaseChange" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            
                            <asp:DropDownList ID="ReleaseChange" runat="server" CssClass="Textboxdesignaddscreen">
                                <%--<asp:ListItem></asp:ListItem>
                                <asp:ListItem>SP</asp:ListItem>
                                <asp:ListItem>Code</asp:ListItem>--%>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    

                    <asp:TableRow runat="server" ID="TOwner">
                        <asp:TableCell>
                            <asp:Label ID="Label6" runat="server" Text="ReportedBy" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Owner" runat="server" CssClass="Textboxdesignaddscreen">
                               
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>





                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="Save" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Save_Click" />&nbsp;
                            <%--<asp:Button ID="Insert" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Insert_Click" />&nbsp;--%>
                    
                       
                            <%--<input type="button" class="HTB btns bd3" value="Cancel" onclick="history.go(-1); return false;">--%>
                            <%--<asp:Button ID="btnCancel" class="HTB btns bd3" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(2); return false;" />&nbsp;--%>
                            <asp:Button ID="cancel1" class="HTB btns bd3" runat="server" Text="Cancel" CausesValidation="false" OnClientClick="history.go(-1); return false;" />
                            
                            <asp:Button ID="Delete" class="HTB btns bd3" runat="server" CausesValidation="false" Text="Delete" OnClick="Delete_Click" />
                            
                            
                        </asp:TableCell>
                    </asp:TableRow>
                    
                </asp:Table>
                
            </div>
        </div>



        <div class="col-12" style="text-align: center">
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
            ShowSummary="false"></asp:ValidationSummary>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ID"
            Display="None" SetFocusOnError="True" ControlToValidate="ID"></asp:RequiredFieldValidator>--%>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
            SetFocusOnError="True" ErrorMessage="Issue Summary: Max length 75 Character and Except(@,&,-,%)Special Characters are not allowed"
            ControlToValidate="IssueSummary" ValidationExpression="^[a-zA-Z0-9\s\@\&\-\%]{1,75}$"></asp:RegularExpressionValidator>

      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select ENV"
            Display="None" SetFocusOnError="True" ControlToValidate="BindENV"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select CurrentStatus"
            Display="None" SetFocusOnError="True" ControlToValidate="CurrentStatus"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="select TicketStatus"
            Display="None" SetFocusOnError="True" ControlToValidate="TicketStatus"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter IssueSummary"
            Display="None" SetFocusOnError="True" ControlToValidate="IssueSummary"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="select ReportedDate"
            Display="None" SetFocusOnError="True" ControlToValidate="ReportedDate"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="select Reported By"
            Display="None" SetFocusOnError="True" ControlToValidate="Owner"></asp:RequiredFieldValidator>

      

                        </asp:Content>
