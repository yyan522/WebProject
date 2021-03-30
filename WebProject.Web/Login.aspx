<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebProject.Web.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

    <div class="hao">
        <h2>Login</h2>
        <div class="login-form">
            <div class="login-item">
                <div class="filename">User Name</div>
                <div class="value">
                    <asp:TextBox ID="txtuserName" runat="server" CssClass="input" Width="300px"></asp:TextBox>
                </div>
            </div>
            <div class="login-item">
                <div class="filename">Password</div>
                <div class="value">
                    <asp:TextBox ID="txtpassWord" runat="server" TextMode="Password" CssClass="input" Width="300px"></asp:TextBox>
                </div>
            </div>	
        </div>
	    
        <div class="btn-list">
            <asp:Button ID="btnSave" runat="server" Text="Login" OnClick="btnSave_Click" CssClass="btncss"></asp:Button>
        </div>
    </div>
    </form>
    
</asp:Content>
