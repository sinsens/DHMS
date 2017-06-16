<%@ Page Title="水电费用费率管理" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DHMS.Ratemgr.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width:100%;" border="1">
        <tr>
            <th colspan="3">水电费用费率管理</th>
        </tr>
    </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" BorderStyle="Solid" ShowHeaderWhenEmpty="True" Width="100%" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="费率名称" HeaderText="费率名称" />
            <asp:BoundField DataField="冷水费率" HeaderText="冷水费率" />
            <asp:BoundField DataField="热水费率" HeaderText="热水费率" />
            <asp:BoundField DataField="电力费率" HeaderText="电力费率" />
            <asp:BoundField DataField="创建时间" HeaderText="创建时间" />
            <asp:BoundField DataField="备注" HeaderText="备注" />
            <asp:HyperLinkField DataNavigateUrlFields="费率编号" DataNavigateUrlFormatString="./Modify.aspx?fid={0}" HeaderText="修改" DataTextField="费率编号" DataTextFormatString="修改" />
            <asp:CheckBoxField DataField="是否启用" HeaderText="启用" />
        </Columns>
    </asp:GridView>
</asp:Content>
