﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="IT.aspx.cs" Inherits="IT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="WEBCSS/Table_AppMasters.css" />
    <br />
    <br />


    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" Style="display: none;"></asp:TextBox><%--Style="display: none;"--%>



    <div class="col-12 HTB SecondMenu">

        <asp:DropDownList ID="BindENV" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" OnSelectedIndexChanged="BindENV_SelectedIndexChanged">
        </asp:DropDownList>


        <asp:DropDownList ID="CurrentStatus" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="CurrentStatus_SelectedIndexChanged">
            
        </asp:DropDownList>

        <asp:DropDownList ID="TicketStatus" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="TicketStatus_SelectedIndexChanged">
            
        </asp:DropDownList>

        <asp:DropDownList ID="Owner" runat="server" CssClass="HTB ddl" AutoPostBack="true" OnSelectedIndexChanged="Owner_SelectedIndexChanged">
           
        </asp:DropDownList>

        <asp:TextBox ID="Search" CssClass="HTB Textboxdesign" runat="server" placeholder="Issue Summary" AutoPostBack="true" OnTextChanged="Search_TextChanged"></asp:TextBox>


        <asp:Button ID="ExportExcelData" runat="server" class="HTB btns bd1" Text="Export" OnClick="Export_ExcelData"></asp:Button>

        <asp:Button ID="Edit" runat="server" Text="Edit" class="HTB btns bd1" OnClick="Edit_Click"></asp:Button>

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
                            //document.getElementById("<%= Edit.ClientID %>").click();
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
