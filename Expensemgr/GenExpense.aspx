<%@ Page Title="生成费用清单" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="GenExpense.aspx.cs" Inherits="DHMS.Recordmgr.GenExpense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">生成费用清单</th>
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
            <asp:BoundField DataField="冷水用量" HeaderText="冷水用量" />
            <asp:BoundField DataField="热水用量" HeaderText="热水用量" />
            <asp:BoundField DataField="电力用量" HeaderText="电力用量" />
            <asp:BoundField DataField="登记日期" HeaderText="上次登记日期" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="记录编号" DataNavigateUrlFormatString="~/Recordmgr/ModifyRecord.aspx?rid={0}" HeaderText="修改记录" DataTextField="记录编号" DataTextFormatString="修改记录" />
        </Columns>
    </asp:GridView>
    共有<% =countRoom() %>个宿舍,已有
</asp:Content>
