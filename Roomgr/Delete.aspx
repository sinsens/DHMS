<%@ Page Title="删除宿舍楼信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="DHMS.Roomgr.Delete" %>

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
                <asp:DropDownList ID="tbDid" runat="server" TabIndex="1"></asp:DropDownList>
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
            <td>&nbsp;</td>
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
