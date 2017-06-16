<%@ Page Title="修改宿舍水电用量记录" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ModifyRecord.aspx.cs" Inherits="DHMS.Recordmgr.ModifyRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">修改宿舍水电用量记录</th>
        </tr>
        <tr>
            <td>宿舍信息</td>
            <td>
                <% =DisInfo() %>
            </td>
        </tr>
        <tr>
            <td>冷水用量</td>
            <td>
                <asp:TextBox ID="tbCr" runat="server" TabIndex="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>热水用量</td>
            <td>
                <asp:TextBox ID="tbHr" runat="server" TabIndex="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>电力用量</td>
            <td>
                <asp:TextBox ID="tbDr" runat="server" TabIndex="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" MaxLength="255" TextMode="MultiLine" Height="50px" TabIndex="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" TabIndex="8" />
            </td>
        </tr>
    </table>
    <a href="?rid=<% Response.Write(Convert.ToInt32(Request["rid"]) - 1); %>">上一个</a>
    <a href="?rid=<% Response.Write(Convert.ToInt32(Request["rid"]) + 1); %>">下一个</a>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentInfo" runat="server">
    <a href="../Settings/Settings.aspx" style="text-decoration:none">优惠额度</a><b>:<% =enableStat()?"开启":"关闭" %></b>
</asp:Content>