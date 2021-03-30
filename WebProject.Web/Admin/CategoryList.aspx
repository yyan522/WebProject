<%@ Page Title="System" MasterPageFile="~/Admin/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="WebProject.Web.Admin.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="path">
    <div class="item">Home</div>
    <div class="item">/</div>
    <div class="item">Category Manager</div>
</div>
    <table class="condition" style="width: 100%; background:#deddee;" cellpadding="2" cellspacing="1" class="border">
    <tr>
        <td style="width: 80px" align="right" class="tdbg">
                <b>Name：</b>
        </td>
        <td class="tdbg">                       
            <asp:TextBox ID="txtKeyword" CssClass="input" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="btncss" runat="server" Text="Query"  OnClick="btnSearch_Click" ></asp:Button>                    
            <a href="/admin/CategoryEdit.aspx" class="btncss">Add</a>
        </td>
        <td class="tdbg">
        </td>
    </tr>
    </table>
    <!--Search end-->
    <br />
    <asp:GridView ID="gridView" CssClass="tableData" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
        BorderWidth="1px" DataKeyNames="ID" OnRowDataBound="gridView_RowDataBound"
        AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
        <Columns>
        <asp:TemplateField ControlStyle-Width="30" HeaderText="Check"    >
                    <ItemTemplate>
                        <asp:CheckBox ID="DeleteThis" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField> 
                            
    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-HorizontalAlign="Center"  /> 
    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center"  /> 


                <asp:HyperLinkField HeaderText="Button" ControlStyle-Width="50" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="CategoryEdit.aspx?id={0}"
                    Text="Edit"  />

            </Columns>
    </asp:GridView>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
    <tr>
        <td style="width: 1px;">                        
        </td>
        <td align="left">
            <asp:Button ID="btnDelete" CssClass="btncss" runat="server" Text="Delete" OnClick="btnDelete_Click"/>                       
        </td>
    </tr>
    </table>

</asp:Content>

