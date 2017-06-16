<%@ Page Title="查看宿舍信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DHMS.Roomgr.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="2">查看宿舍信息</th>
        </tr>
        <tr>
            <td>院名称</td>
            <td>
                <asp:DropDownList ID="tbDid" runat="server" TabIndex="1" OnSelectedIndexChanged="tbDid_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>宿舍楼</td>
            <td>
                <asp:DropDownList ID="tbBid" runat="server" TabIndex="2" AutoPostBack="True" OnSelectedIndexChanged="tbBid_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="宿舍名称" HeaderText="宿舍名称" />
            <asp:BoundField DataField="宿舍楼名称" HeaderText="宿舍楼" />
            <asp:BoundField DataField="院名称" HeaderText="院别" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="宿舍编号" DataNavigateUrlFormatString="./Modify.aspx?rid={0}" HeaderText="修改" DataTextField="宿舍编号" DataTextFormatString="修改" />
            <asp:HyperLinkField DataNavigateUrlFields="宿舍编号" DataNavigateUrlFormatString="./Delete.aspx?rid={0}" HeaderText="删除" DataTextField="宿舍编号" DataTextFormatString="删除" />
        </Columns>
    </asp:GridView>
    总共有<b><% =countRoom() %></b>个宿舍
</asp:Content>
