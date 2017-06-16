<%@ Page Title="用量登记信息管理" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DHMS.Recordmgr.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">用量登记信息管理</th>
        </tr>
        <tr>
            <td>院名称</td>
            <td>
                <asp:DropDownList ID="tbDid" runat="server" TabIndex="1" OnSelectedIndexChanged="tbDid_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>宿舍楼</td>
            <td>
                <asp:DropDownList ID="tbBid" runat="server" TabIndex="2" AutoPostBack="True" OnSelectedIndexChanged="tbBid_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="False" BorderStyle="Solid" ShowHeaderWhenEmpty="True" Width="100%" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="院名称" HeaderText="院名称" />
            <asp:BoundField DataField="宿舍楼名称" HeaderText="宿舍楼称" />
            <asp:BoundField DataField="宿舍名称" HeaderText="宿舍名称" />
            <asp:BoundField DataField="登记日期" HeaderText="最近登记日期" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="宿舍编号" DataNavigateUrlFormatString="./AddRecord.aspx?rid={0}" HeaderText="添加记录" DataTextField="宿舍编号" DataTextFormatString="添加记录" />
        </Columns>
    </asp:GridView>
</asp:Content>
