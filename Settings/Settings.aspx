<%@ Page Title="计费设置" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="DHMS.Settings.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width:100%;" border="1">
        <tr>
            <td>记录模式</td>
            <td><asp:DropDownList ID="tbRecordMode" runat="server" TabIndex="2">
                <asp:ListItem>叠加统计</asp:ListItem>
                <asp:ListItem>依次计算</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>优惠额度</td>
            <td>
                <asp:CheckBox ID="tbEnable" runat="server" Text="启用" />
            </td>
        </tr>
        <tr>
            <td>冷水额度</td>
            <td>
                <asp:TextBox ID="tbCr" runat="server" TabIndex="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td>热水额度</td>
            <td><asp:TextBox ID="tbHr" runat="server" TabIndex="3"></asp:TextBox></td>
        </tr>
        <tr>
            <td>电力额度</td>
            <td><asp:TextBox ID="tbDr" runat="server" TabIndex="4"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="保存" TabIndex="10" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentInfo" runat="server">
    <p><b>依次计算</b>:每次只记录新增用量，不计累计总数。</p>
    <p>如:上月电表累计用量1050度，本月使用了100度,即累计用量1150度,但记录时只记录本月使用了100度。</p>
    <br/>
    <p><b>叠加统计</b>:每次记录时都记录最新累积量,当月使用量为最新累积量减去上月累积量的差额。</p>
    <p>建议使用叠加统计模式。</p>
    <br/>
    <p><b>优惠额度</b>:使用量未达到该值则不计费。勾选启用复选框保存后下次计费时才能生效。</p>
</asp:Content>
