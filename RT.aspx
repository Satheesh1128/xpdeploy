<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="RT.aspx.cs" Inherits="RT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="WEBCSS/Table_AppMasters.css" />
    <br />
    <br />


    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" Style="display: none;"></asp:TextBox><%--Style="display: none;"--%>
    <asp:TextBox ID="CurrentEventName" runat="server" Style="display: none;"></asp:TextBox>



    <div class="col-12 HTB SecondMenu">
        <asp:DropDownList ID="BindClient" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" OnSelectedIndexChanged="BindClient_SelectedIndexChanged" Visible="false">           
        </asp:DropDownList>

        <asp:DropDownList ID="BindENV" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" OnSelectedIndexChanged="BindENV_SelectedIndexChanged">           
        </asp:DropDownList>


        <asp:DropDownList ID="Application" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="Application_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:DropDownList ID="ApplicationV1" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="ApplicationV1_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:DropDownList ID="ReleasePending" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="ReleasePending_SelectedIndexChanged">
            <asp:ListItem>--PendingRelease--</asp:ListItem>
            <asp:ListItem>UATRelease</asp:ListItem>
            <asp:ListItem>PRDRelease</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="JiraSearch" CssClass="HTB Textboxdesign" runat="server" placeholder="Search jira" AutoPostBack="true"  OnTextChanged="JiraSearch_TextChanged"></asp:TextBox>

        <asp:TextBox ID="Search" runat="server" CssClass="HTB Textboxdesign" placeholder="Search Name" AutoPostBack="true" Visible="false"></asp:TextBox>
        <asp:Button ID="ExportExcelData" runat="server" class="HTB btns bd1" Text="Export" OnClick="Export_ExcelData"></asp:Button>
        <asp:Button ID="Edit" runat="server" Text="Edit" class="HTB btns bd1" OnClick="Edit_Click"></asp:Button>
        <asp:Button ID="Duplicate" runat="server" Text="Duplicate" class="HTB btns bd1" OnClick="Duplicate_Click"></asp:Button>
        <asp:Button ID="Add" runat="server" Text="Add" class="HTB btns bd1" OnClick="Add_Click"></asp:Button>
        <asp:Button ID="Refresh" runat="server" Text="Refresh" class="HTB btns bd1" OnClick="Refresh_Click"></asp:Button>
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
        <script id="Script" language="javascript">

            //        var tbl = document.getElementById("tblMain");
            //        if (tbl != null) {
            //            for (var i = 0; i < tbl.rows.length; i++) {
            //                for (var j = 0; j < tbl.rows[i].cells.length; j++)
            //                    tbl.rows[i].cells[j].onclick = function () { getval(this); };
            //            }
            //        }

            //        function getval(cel) {
            //            alert(cel.innerHTML);
            //        }


            init();
            function init() {

                addRowHandlers('DynamicTable');

            }

            function addRowHandlers(tableId) {
                if (document.getElementById(tableId) != null) {
                    var table = document.getElementById(tableId);
                    var rows = table.getElementsByTagName('tr');
                    var ocb = '';
                    for (var i = 2; i < rows.length; i++) {
                        rows[i].i = i;


                        rows[i].onclick = function () {

                            ocb = table.rows[this.i].cells[0].innerHTML;
                            //                       area = table.rows[this.i].cells[1].innerHTML;
                            //                       name = table.rows[this.i].cells[2].innerHTML;
                            //                       cell = table.rows[this.i].cells[3].innerHTML;
                            //                       nick = table.rows[this.i].cells[4].innerHTML;
                            //                       alert('ocb: ' + ocb + ' area: ' + area + ' name: ' + name + ' cell: ' + cell + ' nick: ' + nick);
                            //                       alert(ocb);
                            var myvar1 = ocb;
                            '<%Session["temp"] = "' + myvar1 + '"; %>';
                            document.getElementById('<%=TextBox1.ClientID %>').value = '<%=Session["temp"] %>';
                            
                            //alert('<%=Session["temp"] %>');
                            //alert(table.rows[this.i].cells[9].innerHTML);
                            //location.href = "RTE.aspx";



                        };
                    }
                }
            }
        </script>

        <script>

            $(document).ready(function () {

                $('tr').click(function () {
                    $('tr td').css({ 'background-color': 'White' });
                    $('tr td').css({ 'color': 'Black' });
                    $('td a').css({ 'color': 'blue' });


                    $('td', this).css({ 'background-color': 'Green' });
                    $('td', this).css({ 'color': 'White' });
                    $('a', this).css({ 'color': 'White' });
                });



            });
        </script>



    </div>
</asp:Content>
