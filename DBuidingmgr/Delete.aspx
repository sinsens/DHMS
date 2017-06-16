<%@ Page Title="删除宿舍楼信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="DHMS.DBuidingmgr.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">删除宿舍楼信息</th>
        </tr>
        <tr>
            <td>院别</td>
            <td>
                <asp:Label ID="lbYid" runat="server" Text="[tbdid]"></asp:Label>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>宿舍楼编号</td>
            <td>
                <asp:TextBox ID="tbBid" runat="server" TabIndex="2" ReadOnly="true"></asp:TextBox>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>宿舍楼名称</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" TabIndex="4" ReadOnly="true"></asp:TextBox>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="tip">注意:与本宿舍楼相关的宿舍将会被删除</td>
            <td class="tip">&nbsp;</td>
            </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="tip">当前共有<b><asp:Label ID="lbCount" runat="server" Text="[count]"></asp:Label></b>条宿舍数据信息与本宿舍楼相关联</td>
            <td class="tip">&nbsp;</td>
            </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="确定删除" TabIndex="6" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
