<%@ Page Title="删除" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="DHMS.Yardmgr.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <th colspan="3">是否删除该院信息？</th>
        <tr>
            <td>院编号</td>
            <td>
                <asp:TextBox ID="tbId" runat="server" TabIndex="1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>院名称</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" TabIndex="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>院类别</td>
            <td>
                <asp:DropDownList ID="tbType" runat="server" TabIndex="4">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" MaxLength="255" TextMode="MultiLine" Height="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tip" colspan="2">当前共有<b><% =countBuilding %></b>个宿舍楼,<b><% =countRoom %></b>个宿舍与本院相关联</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnDel" runat="server" OnClick="btnAdd_Click" Text="确定删除" TabIndex="6" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentInfo" runat="server">
    <p>删除院别的时候也会删除相关联的宿舍楼和宿舍</p>
</asp:Content>