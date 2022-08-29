<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterApp.master" AutoEventWireup="true"
    CodeFile="dbcompare.aspx.cs" Inherits="dbcompare" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="datecalender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="WEBCSS/Table_AppMasters_DB's.css" rel="stylesheet" />
   
    <br />
    <br />
    <datecalender:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </datecalender:ToolkitScriptManager>
    <datecalender:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="datecalender"
                PopupButtonID="Attendancedate" Format="dd-MMM-yyyy" />

    <datecalender:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="FromDate"
                PopupButtonID="Attendancedate" Format="dd-MMM-yyyy" />

    <%--<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" ></asp:TextBox>--%>
    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none;">
    </asp:Button>--%>


    




    

    <div class="col-12 HTB SecondMenu">

        

        From: <asp:TextBox ID="FromDate" placeholder="         --FromDate--"  runat="server" CssClass="HTB ddl" AutoPostBack="true" OnTextChanged="datecalender_TextChanged" ></asp:TextBox>
        To: <asp:TextBox ID="datecalender" placeholder="         --ToDate--"   runat="server" CssClass="HTB ddl" AutoPostBack="true" OnTextChanged="datecalender_TextChanged" ></asp:TextBox>
        
        
        
        <asp:DropDownList ID="BindENV" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="BindENV_SelectedIndexChanged"> 
            <asp:ListItem>--Env--</asp:ListItem>          
        </asp:DropDownList>

        <asp:DropDownList ID="BindENVLists" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" OnSelectedIndexChanged="BindENVLists_SelectedIndexChanged" > 
                     
        </asp:DropDownList>


        <asp:DropDownList ID="Owner" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="Owner_SelectedIndexChanged" >
            <asp:ListItem>--Owner--</asp:ListItem>             
            <asp:ListItem>Satheesh</asp:ListItem>          
            <asp:ListItem>Allok</asp:ListItem>
            <asp:ListItem>Navin</asp:ListItem>
        </asp:DropDownList>

                <asp:DropDownList ID="DBDiff" runat="server" CssClass="HTB ddl"
            AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="DBDiff_SelectedIndexChanged" >
            <asp:ListItem>--DBDiff--</asp:ListItem>             
            <asp:ListItem>Not Compared</asp:ListItem>          
            <asp:ListItem>Y</asp:ListItem>
            <asp:ListItem>N</asp:ListItem>
        </asp:DropDownList>
        

    </div>
    <div class="col-12 HTB ThirdMenudbcompare">
        <table class="col-12" style="overflow:scroll">
            <tr>
                <th class="HTB tableHeader">
                    <asp:Label ID="Header" runat="server" Text=""></asp:Label>
                </th>
            </tr>
        </table>
    </div>

    <br />
    <br />
    <br />

    


    <asp:TextBox ID="TextBox6" runat="server" Visible="false"></asp:TextBox>

                    <div class="col-12" style="text-align:center;margin-top:10px;">
                   
                <div class="buttondiv">
                    <asp:Label ID="LabelMessage" ForeColor="Red" Visible="false" runat="server" Text="Record Updated Sucessfully...."></asp:Label>
                    <br />
                    <br />
             <%--   <asp:Button ID="Present" runat="server" CausesValidation="True" CssClass="AtdButton" OnClick="PresentButton_Click" Text="P" />--%>
                <asp:Button ID="Update" runat="server" CausesValidation="False" CssClass="AtdButton" Text="Update" OnClick="Update_Click" OnClientClick="myfunction(); return false;" />
             <%--   <asp:Button ID="Holiday" runat="server" CausesValidation="True" CssClass="AtdButton" OnClick="Holiday_Click" Text="H" />--%>
                <asp:Button ID="Calcel" runat="server" CausesValidation="False" CssClass="AtdButton" OnClick="CalcelButton" Text="Cancel" />
                    </div>
                        <br />

            </div>

    <div id="MobileHide" class="col-3">
            .
        </div>
        <br />
    <br />

    <div id="atdtakeD6" class="col-6">
            
            <div class="Atdpanel" style="width:100%" >
                <asp:Panel ID="Panel1"  runat="server" ScrollBars="Auto"  Height="500px" Width="100%">
                    <%--ScrollBars="Both"--%>
                    <%--EmptyDataText="Dont Select Future Month or Data not avaible"--%>


                    <asp:GridView ID="GridView1"  runat="server" width="100%" OnRowDataBound="OnRowDataBound"
                        AutoGenerateColumns="false" CssClass="AtdGrid" HorizontalAlign="Center" ScrollBars="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="DB_ID" HeaderText="Id"/>
                            <asp:BoundField DataField="SourceDB" HeaderText="SourceDB"/>
                            <asp:BoundField DataField="TargetDB" HeaderText="TargetDB" />
                            <asp:BoundField DataField="UserName" HeaderText="Owner" />
                            <asp:TemplateField HeaderText="DB-Difference">
                                <ItemTemplate>
                                      <asp:Label ID="DBDifference" runat="server" Text='<%# Eval("Difference") %>' Visible="False" />                              
                                    <asp:DropDownList ID="Difference" runat="server">
                                       <%-- <asp:ListItem>Not Compared</asp:ListItem>
                                        <asp:ListItem>Y</asp:ListItem>
                                        <asp:ListItem>N</asp:ListItem>--%>
                                    </asp:DropDownList>

                                     </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="DiffVerified">
                                <ItemTemplate> 
                                  <asp:Label ID="DiffVeri" runat="server" Text='<%# Eval("[Diff-Verified]") %>' Visible="False" />
                                    <asp:DropDownList ID="DiffVerified" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Y</asp:ListItem>
                                        <asp:ListItem>N</asp:ListItem>
                                    </asp:DropDownList>

                             </ItemTemplate>
                            </asp:TemplateField>

                               
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>





    <div class="col-12 HTB dynamictablediv">
        <div class="col-12" style="text-align: center; overflow: auto;">
            <br />
            <div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            </div>
        </div>
        <%--<asp:ScriptManager EnablePageMethods="true" ID="ScriptManager" runat="server" ScriptMode="Release"
            LoadScriptsBeforeUI="true">
        </asp:ScriptManager>--%>
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
                            <%--document.getElementById('<%=TextBox1.ClientID %>').value = '<%=Session["temp"] %>';
                            document.getElementById("<%= Button1.ClientID %>").click();--%>
                             alert('<%=Session["temp1"] %>');
                            //                       location.href = 'HME.aspx';
                        };
                    }
                }
            }
        </script>
    </div>
</asp:Content>
