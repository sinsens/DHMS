<%@ Page Title="设置初始用量" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="SetDefaultValues.aspx.cs" Inherits="DHMS.Recordmgr.SetDefaultValues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">设置初始用量</th>
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
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="False" BorderStyle="Solid" ShowHeaderWhenEmpty="True" Width="100%" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="院名称" HeaderText="院名称" />
            <asp:BoundField DataField="宿舍楼名称" HeaderText="宿舍楼称" />
            <asp:BoundField DataField="宿舍名称" HeaderText="宿舍名称" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="宿舍编号" DataNavigateUrlFormatString="./AddRecord.aspx?rid={0}&do=setValue" HeaderText="设定初始用量" DataTextField="宿舍编号" DataTextFormatString="设定初始用量" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentInfo" runat="server">
    <p>由于一些原因，不少单位的水电表并不是从零开始记录的。所以我们提供了本项功能。</p>
    <p>通过本页面设定好水电表的初始值后,以后的统计将是由此递增记录的。</p>
</asp:Content>
