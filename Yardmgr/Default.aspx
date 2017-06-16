<%@ Page Title="查看院信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DHMS.Yardmgr.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="">
        <tr>
            <td>院类型</td>
            <td>
                <asp:DropDownList ID="tbType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tbType_SelectedIndexChanged">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" ShowHeaderWhenEmpty="True" Width="100%">
        <Columns>
            <asp:BoundField DataField="院编号" HeaderText="院编号" />
            <asp:BoundField DataField="院名称" HeaderText="院名称" />
            <asp:BoundField DataField="院类型" HeaderText="院类型" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="院编号" DataNavigateUrlFormatString="./Modify.aspx?did={0}" HeaderText="修改" DataTextField="院编号" DataTextFormatString="修改" />
            <asp:HyperLinkField DataNavigateUrlFields="院编号" DataNavigateUrlFormatString="./Delete.aspx?did={0}" HeaderText="删除" DataTextField="院编号" DataTextFormatString="删除" />
        </Columns>
    </asp:GridView>
</asp:Content>
