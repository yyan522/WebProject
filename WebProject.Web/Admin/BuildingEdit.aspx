<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="BuildingEdit.aspx.cs" Inherits="WebProject.Web.Admin.BuildingEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="path">
        <div class="item">Home</div>
        <div class="item">/</div>
        <div class="item">Building Edit</div>
    </div>
    <div class="main-form">
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="tdbg">

                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        
                        <tr>
                            <td height="25" width="30%" align="right">BuildName：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Address：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">lng：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">lat：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox4" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="tdbg" align="center" valign="bottom">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btncss"></asp:Button>
                    <asp:Button ID="btnCancle" runat="server" Text="Cancel" OnClick="btnCancle_Click" CssClass="btncss"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

