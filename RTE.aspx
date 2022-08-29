<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="RTE.aspx.cs" Inherits="RTE" %>

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

                    <asp:TableRow Visible="false">
                        <asp:TableCell>
                            <asp:Label ID="Label4" runat="server" Text="Client" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindClient" runat="server" CssClass="Textboxdesignaddscreen">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label20" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="BindENV" runat="server" CssClass="Textboxdesignaddscreen" AutoPostBack="true" OnSelectedIndexChanged="BindENV_SelectedIndexChanged">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TApplication">
                        <asp:TableCell>
                            <%--<div>  <img runat="server" id="Img"  /> </div>--%>
                            <asp:Label ID="Label3" runat="server" Text="Application" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Application" runat="server" CssClass="Textboxdesignaddscreen">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ApplicationV1" runat="server" CssClass="Textboxdesignaddscreen">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TVersion">
                        <asp:TableCell>
                            <asp:Label ID="Label2" runat="server" Text="Version" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Version" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>




                    <asp:TableRow runat="server" ID="FATHide">
                        <asp:TableCell>
                            <asp:Label ID="Label15" runat="server" Text="FAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SITFAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="SITFAT"
                                PopupButtonID="SITFAT" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="DEVHide">
                        <asp:TableCell>
                            <asp:Label ID="Label10" runat="server" Text="DEV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="DEV" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="DEV"
                                PopupButtonID="DEV" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SITHide">
                        <asp:TableCell>
                            <asp:Label ID="Label9" runat="server" Text="SIT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SIT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="SIT"
                                PopupButtonID="SIT" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="UATHide">
                        <asp:TableCell>
                            <asp:Label ID="Label17" runat="server" Text="UAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="UAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="UAT"
                                PopupButtonID="UAT" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="PRDHide">
                        <asp:TableCell>
                            <asp:Label ID="Label19" runat="server" Text="PRD" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="PRD" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="PRD"
                                PopupButtonID="PRD" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TRIHide">
                        <asp:TableCell>
                            <asp:Label ID="Label14" runat="server" Text="TRI" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TRI" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TRI"
                                PopupButtonID="TRI" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="DEMOV2Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label5" runat="server" Text="DEMOV2" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="DEMOV2" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="DEMOV2"
                                PopupButtonID="DEMOV2" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASDEMOHide">
                        <asp:TableCell>
                            <asp:Label ID="Label12" runat="server" Text="DEMO" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="DEMO" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="DEMO"
                                PopupButtonID="DEMO" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASPILOTHide">
                        <asp:TableCell>
                            <asp:Label ID="Label13" runat="server" Text="PILOT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="PILOT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="PILOT"
                                PopupButtonID="PILOT" Format="dd-MMM-yyyy" />
                        </asp:TableCell>
                    </asp:TableRow>

                    

                    <asp:TableRow runat="server" ID="TJira">
                        <asp:TableCell>
                            <asp:Label ID="Label18" runat="server" Text="Jira" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Jira" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TAD">
                        <asp:TableCell>
                            <asp:Label ID="Label16" runat="server" Text="AppDependency" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="AppDependency" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    

                    <asp:TableRow runat="server" ID="TConfigChange">
                        <asp:TableCell>
                            <asp:Label ID="Label6" runat="server" Text="Config" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Config" runat="server" CssClass="Textboxdesignaddscreen">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TRollback">
                        <asp:TableCell>
                            <asp:Label ID="Label7" runat="server" Text="Rollback" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="Rollback" runat="server" CssClass="Textboxdesignaddscreen">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TReason">
                        <asp:TableCell>
                            <asp:Label ID="Label8" runat="server" Text="Reason" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Reason" runat="server" CssClass="Textboxdesignaddscreen" TextMode="MultiLine"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <asp:Button ID="Save" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Save_Click" />&nbsp;
                            <%--<asp:Button ID="Insert" runat="server" class="HTB btns bd1" Text="Save" CausesValidation="true" OnClick="Insert_Click" />&nbsp;--%>
                    
                       
                            <%--<input type="button" class="HTB btns bd3" value="Cancel" onclick="history.go(-1); return false;">--%>
                            <%--<asp:Button ID="btnCancel" class="HTB btns bd3" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(2); return false;" />&nbsp;--%>
                            <%--<asp:Button ID="cancel1" class="HTB btns bd3" runat="server" Text="Cancel" OnClientClick="history.go(-2); return false;" />
                            <asp:Button ID="cancel2" class="HTB btns bd3" runat="server" Text="Cancel" OnClientClick="history.go(-2); return false;" />--%>
                            <asp:Button ID="cancel1" class="HTB btns bd3" runat="server" Text="Cancel" OnClick="cancel1_Click"  CausesValidation="false"/>
                            <asp:Button ID="Delete" class="HTB btns bd3" runat="server" Text="Delete" OnClick="Delete_Click" />
                            
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

        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="select Rollback"
            Display="None" SetFocusOnError="True" ControlToValidate="Rollback"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Version (If app does not have version enter 0.0.0.0)"
            Display="None" SetFocusOnError="True" ControlToValidate="Version"></asp:RequiredFieldValidator>

      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None"
            SetFocusOnError="True" ErrorMessage="Only numbers are allowed eg: 1.0.0.1"
            ControlToValidate="Version" ValidationExpression="^[0-9\.]{1,7}$"></asp:RegularExpressionValidator>

                        </asp:Content>
