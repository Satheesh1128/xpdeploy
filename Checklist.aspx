<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="Checklist.aspx.cs" Inherits="Checklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="WEBCSS/Table_AppMasters.css" />
    <br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" Style="display: none;"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none;">
    </asp:Button>

    <div class="col-12 HTB SecondMenu">

        <asp:DropDownList ID="BindENV" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="BindENV_SelectedIndexChanged"> 
            <asp:ListItem>--Env--</asp:ListItem>          
        </asp:DropDownList>

        <asp:DropDownList ID="BindENVLists" runat="server" CssClass="HTB ddl"
            AutoPostBack="true"  OnSelectedIndexChanged="BindENVLists_SelectedIndexChanged"> 
            <asp:ListItem></asp:ListItem>          
        </asp:DropDownList>

        <asp:DropDownList ID="Version" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="Version_SelectedIndexChanged"> 
            <asp:ListItem>--Version--</asp:ListItem> 
            <asp:ListItem>V1</asp:ListItem>          
            <asp:ListItem>V2</asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="Owner" runat="server" CssClass="HTB ddl" Visible="false"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="BindOwner_SelectedIndexChanged">
            <asp:ListItem>--Owner--</asp:ListItem>             
            <asp:ListItem>Satheesh</asp:ListItem>          
            <asp:ListItem>Allok</asp:ListItem>
            <asp:ListItem>Navin</asp:ListItem>
        </asp:DropDownList>
        
        <asp:DropDownList ID="BindStatus" CssClass="HTB ddl" runat="server" OnSelectedIndexChanged="BindStatus_SelectedIndexChanged"
            AutoPostBack="true">
        </asp:DropDownList>

        <asp:TextBox ID="DBNameSearch" CssClass="HTB Textboxdesign" runat="server" placeholder="Search DBs" AutoPostBack="true"  OnTextChanged="dbsSearch_TextChanged"></asp:TextBox>

        <asp:Button ID="Edit" runat="server" Text="Edit" class="HTB btns bd1" OnClick="Edit_Click"></asp:Button>
        
        <asp:Button ID="Add" runat="server" Text="Add" class="HTB btns bd1" OnClick="Add_Click"></asp:Button>

        <asp:DropDownList ID="BindRoleMaster" Visible="false" CssClass="HTB ddl"  runat="server" OnSelectedIndexChanged="BindRoleMaster_SelectedIndexChanged"
            AutoPostBack="true" AppendDataBoundItems="True">
            
        </asp:DropDownList>
        
        
      

        <asp:Button ID="AddUsers" Visible="false" class="HTB btns bd2" runat="server" Text="Add" OnClick="Add_Click"></asp:Button>
        <asp:Button ID="Refresh" runat="server" Text="Refresh" class="HTB btns bd1" OnClick="Refresh_Click"></asp:Button>
    </div>
    <div class="col-12 HTB ThirdMenu">
        <table class="col-12" style="overflow:scroll">
            <tr>
                <th class="HTB tableHeader">
                    <asp:Label ID="Header1" CssClass="HeaderTextdesign1" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="Header2" CssClass="HeaderTextdesign2" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="Header3" CssClass="HeaderTextdesign3" runat="server" Text=""></asp:Label>
                </th>
            </tr>
        </table>
    </div>
    <div class="col-12 HTB dynamictablediv">
        <div class="col-12" style="text-align: center; overflow: auto;">
            <br />
            <div>
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
                            //document.getElementById("<%= Button1.ClientID %>").click();
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
