<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true" CodeFile="VerSum.aspx.cs" Inherits="VerSum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="WEBCSS/Table_AppMasters.css" />
    <br />
    <br />

    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" Style="display: none;"></asp:TextBox><%--Style="display: none;"--%>



    <div class="col-12 HTB SecondMenu">


        <asp:DropDownList ID="BindENV" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="BindENV_SelectedIndexChanged">
            <%--<asp:ListItem>HCCB</asp:ListItem>
            <asp:ListItem>SAAS</asp:ListItem>
            <asp:ListItem>Xnapp2.0</asp:ListItem>
            <asp:ListItem>All</asp:ListItem>--%>
        </asp:DropDownList>

        <asp:DropDownList ID="Application" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="Application_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="ExportExcelData" runat="server" class="HTB btns bd1" Text="Export" OnClick="Export_ExcelData"></asp:Button>



    </div>
    <div class="col-12 HTB ThirdMenu">
        <table class="col-12" style="overflow: scroll">
            <tr>
                <th class="HTB tableHeader">
                    <asp:Label ID="Header" runat="server"></asp:Label>
                </th>
            </tr>
        </table>
    </div>

    <div class="col-12 HTB dynamictablediv">
        <div class="col-12" style="text-align: center; overflow: auto;">
            <br />
            <div style="height: 595px">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            </div>
        </div>
        <asp:ScriptManager EnablePageMethods="true" ID="ScriptManager" runat="server" ScriptMode="Release"
            LoadScriptsBeforeUI="true">
        </asp:ScriptManager>



    </div>




</asp:Content>

