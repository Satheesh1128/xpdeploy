<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="ConsumersE.aspx.cs" Inherits="ConsumersE" %>

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
                            <asp:Label ID="Label22" runat="server" Text="ENV" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="ENV" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow>
                        <asp:TableCell>
                            <%--<div>  <img runat="server" id="Img"  /> </div>--%>
                            <asp:Label ID="Label3" runat="server" Text="Application" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="Application" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="HCCBAPP2Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label15" runat="server" Text="HCCBAPP2" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBAPP2" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="HCCBAPP3Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label17" runat="server" Text="HCCBAPP3" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBAPP3" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="HCCBAPP4Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label19" runat="server" Text="HCCBAPP4" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBAPP4" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>




                    <asp:TableRow runat="server" ID="HCCBAPP5Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label5" runat="server" Text="HCCBAPP5" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBAPP5" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="HCCBAPP6Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label6" runat="server" Text="HCCBAPP6" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBAPP6" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASAPP4Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label7" runat="server" Text="SAASAPP4" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASAPP4" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASAPP5Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label8" runat="server" Text="SAASAPP5" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASAPP5" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>



                    <asp:TableRow runat="server" ID="SAASAPP6Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label9" runat="server" Text="SAASAPP6" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASAPP6" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="HCCBFATHide">
                        <asp:TableCell>
                            <asp:Label ID="Label10" runat="server" Text="HCCBFAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBFAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow runat="server" ID="HCCBUATHide">
                        <asp:TableCell>
                            <asp:Label ID="Label11" runat="server" Text="HCCBUAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="HCCBUAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASSITHide">
                        <asp:TableCell>
                            <asp:Label ID="Label12" runat="server" Text="SAASSIT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASSIT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASUATHide">
                        <asp:TableCell>
                            <asp:Label ID="Label13" runat="server" Text="SAASUAT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASUAT" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SITV2APPHide">
                        <asp:TableCell>
                            <asp:Label ID="Label16" runat="server" Text="SITV2APP" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SITV2APP" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="UATV2APPHide">
                        <asp:TableCell>
                            <asp:Label ID="Label18" runat="server" Text="UATV2APP" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="UATV2APP" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="V2PRDHide">
                        <asp:TableCell>
                            <asp:Label ID="Label23" runat="server" Text="PRDV2APP1" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="PRDV2APP1" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASPILOTHide">
                        <asp:TableCell>
                            <asp:Label ID="Label24" runat="server" Text="SAASPILOT" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASPILOT" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="SAASDEMOHide">
                        <asp:TableCell>
                            <asp:Label ID="Label25" runat="server" Text="SAASDEMO" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="SAASDEMO" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="DEMOV2Hide">
                        <asp:TableCell>
                            <asp:Label ID="Label26" runat="server" Text="DEMOV2" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="DEMOV2" runat="server" CssClass="Textboxdesignaddscreen"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow runat="server" ID="TRAININGHide">
                        <asp:TableCell>
                            <asp:Label ID="Label14" runat="server" Text="TRAINING" CssClass="Labels"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TRAINING" runat="server" CssClass="Textboxdesignaddscreen" autocomplete="off"></asp:TextBox>

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
        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ID"
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
