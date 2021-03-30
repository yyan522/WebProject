<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="PopularSportEdit.aspx.cs" Inherits="WebProject.Web.Admin.PopularSportEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="path">
        <div class="item">Home</div>
        <div class="item">/</div>
        <div class="item">Popular Sport Edit</div>
    </div>
    <div class="main-form">
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="tdbg">

                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        
                        <tr>
                            <td height="25" width="30%" align="right">Choose Category：</td>
                            <td height="25" width="*" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="400px" CssClass="input"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Name：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Remark：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Client：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="400px" CssClass="input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Image 1：</td>
                            <td height="25" width="*" align="left">
                                <asp:FileUpload ID="fileUpload1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Image 2：</td>
                            <td height="25" width="*" align="left">
                                <asp:FileUpload ID="fileUpload2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">Image 3：</td>
                            <td height="25" width="*" align="left">
                                <asp:FileUpload ID="fileUpload3" runat="server" />
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

