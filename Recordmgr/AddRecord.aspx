<%@ Page Title="添加宿舍水电用量记录" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AddRecord.aspx.cs" Inherits="DHMS.Recordmgr.AddRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3"><% =Title %></th>
        </tr>
        <tr>
            <td>宿舍信息</td>
            <td>
                <% =DisInfo() %>
            </td>
            <td class="tip"></td>
        </tr>
        <tr>
            <td>冷水用量</td>
            <td>
                <asp:TextBox ID="tbCr" runat="server" TabIndex="2"></asp:TextBox>
            </td>
            <td class="tip"></td>
        </tr>
        <tr>
            <td>热水用量</td>
            <td>
                <asp:TextBox ID="tbHr" runat="server" TabIndex="4"></asp:TextBox>
            </td>
            <td class="tip"></td>
        </tr>
        <tr>
            <td>电力用量</td>
            <td>
                <asp:TextBox ID="tbDr" runat="server" TabIndex="5"></asp:TextBox>
            </td>
            <td class="tip"></td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" MaxLength="255" TextMode="MultiLine" Height="50px" TabIndex="7"></asp:TextBox>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnAdd_Click" Text="保存" TabIndex="8" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <a href="?rid=<% =PrvLink() %>">上一个</a>
    <a href="?rid=<% =NextLink() %>">下一个</a>
</asp:Content>
