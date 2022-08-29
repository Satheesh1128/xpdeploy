<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true" CodeFile="AtdTake.aspx.cs" Inherits="AtdTake" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
        <%--<link href="WEBCSS/buttondiv.css" rel="stylesheet" />--%>
        <link href="WEBCSS/Table_Design.css" rel="stylesheet" type="text/css" />
        <%--<link href="Css/test.css" rel="stylesheet" />--%>
        <br />
        <br />
        <asp:DropDownList ID="BindYear" runat="server" Visible="false"></asp:DropDownList>
        <%--<asp:Label ID="Label4" runat="server" Text="Section" CssClass = "Labels"></asp:Label>--%>
       
            <div style="position:fixed;width:100%">
        <div class="col-12  HTB SecondMenu">

            <asp:TextBox ID="Attendancedate" runat="server"
                AutoPostBack="true" OnTextChanged="Attendancedate_TextChanged1"></asp:TextBox>
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="HTB ddl" AutoPostBack="True"
                AppendDataBoundItems="true"
                OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged1">
            </asp:DropDownList>

            <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" CssClass="HTB ddl"
                AppendDataBoundItems="true"
                OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged1">
            </asp:DropDownList>

            <asp:TextBox ID="TextBox2" runat="server" CssClass="atdtextbox" AutoPostBack="False" Visible="False"
                ReadOnly="true"></asp:TextBox>

            <asp:Button ID="FetchData" runat="server" Text="FetchData"
                CausesValidation="True" Visible="false" OnClick="FetchButton"></asp:Button>

        </div>


                <div class="col-12 HTB ThirdMenu">
                <table class="col-12">
                    <tr>
                        <th class="HTB tableHeader" >
                            <asp:Label ID="Header" runat="server" Text="Mark Attendence"></asp:Label>
                        </th>
                    </tr>
                </table>
            </div>
                
                
                <div class="col-12" style="text-align:center;margin-top:5px;">
                   
                <div class="buttondiv">
                <asp:Button ID="Present" runat="server" CausesValidation="True" CssClass="AtdButton" OnClick="PresentButton_Click" Text="P" />
                <asp:Button ID="Update" runat="server" CausesValidation="True" CssClass="AtdButton" OnClick="UpdateButton" Text="Update" />
                <asp:Button ID="Holiday" runat="server" CausesValidation="True" CssClass="AtdButton" OnClick="Holiday_Click" Text="H" />
                <asp:Button ID="Button4" runat="server" CausesValidation="False" CssClass="AtdButton" OnClick="CalcelButton" Text="Cancel" />
                    </div>


            </div>

            </div>

        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
        <br />


        <asp:TextBox ID="TextBox1" runat="server" Visible="True"></asp:TextBox>
        <asp:TextBox ID="TextBox6" runat="server" Visible="True"></asp:TextBox>




        <br />
        <br />
        <br />

        <div id="MobileHide" class="col-3">
            .
        </div>
        <div id="atdtakeD6" class="col-6">
            
            <div class="Atdpanel" >
                <asp:Panel ID="Panel1"  runat="server" ScrollBars="Auto" Height="520px">
                    <%--ScrollBars="Both"--%>
                    <%--EmptyDataText="Dont Select Future Month or Data not avaible"--%>

                    <%--OnRowDataBound="OnRowDataBound"--%>
                    <asp:GridView ID="GridView1"  runat="server" OnRowDataBound="OnRowDataBound"
                        AutoGenerateColumns="true" CssClass="AtdGrid" HorizontalAlign="Center" ScrollBars="Vertical">
                        <Columns>
                         
                          <asp:BoundField DataField="StudentCode" HeaderText="StudentCode" ItemStyle-Width="30"/>
                               <asp:BoundField DataField="UserName" HeaderText="StudentName" ItemStyle-Width="30" />
                            
                          <asp:TemplateField HeaderText="Atd-Mark">
                                <ItemTemplate>
                                    <asp:Label ID="Atdday" runat="server" Text='<%# Eval(TextBox1.Text) %>' Visible="false" />
                                    <asp:DropDownList ID="ddlAtdday" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>


        <div id="atdtakeD4" class="col-12">
            <br />
            <asp:Label ID="Mediuminputlabel" runat="server" Text="Medium" Visible="True" CssClass="atdlabel"></asp:Label>

            <asp:DropDownList ID="Mediuminput" runat="server" Visible="false" CssClass="atdtextbox" AutoPostBack="True"
                AppendDataBoundItems="true" OnSelectedIndexChanged="Mediuminput_SelectedIndexChanged">
                <%--<asp:ListItem Text=""></asp:ListItem>--%>
            </asp:DropDownList>

        </div>


        <div id="atdtakeD4" class="col-12">
            <br />

            <asp:Button ID="Button5" runat="server" Text="Test" OnClick="Button5_Click" Visible="False" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Section"
                ControlToValidate="DropDownList6" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

        <div id="atdtakeD3" class="col-12">


            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Class"
                ControlToValidate="DropDownList5" Display="None" SetFocusOnError="False"></asp:RequiredFieldValidator>
        </div>

        <div id="atdtakeD2" class="col-12">
            <br />

            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Attendancedate"
                PopupButtonID="Attendancedate" Format="dd-MMM-yyyy" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                ShowSummary="False"></asp:ValidationSummary>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Date"
                ControlToValidate="Attendancedate" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>
</asp:Content>

