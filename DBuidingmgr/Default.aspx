<%@ Page Title="查看宿舍楼信息信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DHMS.DBuidingmgr.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">宿舍楼管理</th>
        </tr>
        <tr>
            <td>院名称</td>
            <td>
                <asp:DropDownList ID="tbDid" runat="server" TabIndex="1" OnSelectedIndexChanged="tbDid_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"  ShowHeaderWhenEmpty="True" Width="100%" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="宿舍楼名称" HeaderText="宿舍楼名称" />
            <asp:BoundField DataField="院名称" HeaderText="院名称" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="宿舍楼编号" DataNavigateUrlFormatString="./Modify.aspx?bid={0}" HeaderText="修改" DataTextField="宿舍楼编号" DataTextFormatString="修改" />
            <asp:HyperLinkField DataNavigateUrlFields="宿舍楼编号" DataNavigateUrlFormatString="./Delete.aspx?bid={0}" HeaderText="删除" DataTextField="宿舍楼编号" DataTextFormatString="删除" />
        </Columns>
    </asp:GridView>
</asp:Content>
