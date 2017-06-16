<%@ Page Title="查看系统信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="SystemInfo.aspx.cs" Inherits="DHMS.Admin.SystemInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="2"><% =Title %></th>
        </tr>
        <tr>
            <td>院别统计</td>
            <td><b><% =YidCountF %></b>个</td>
        </tr>
        <tr>
            <td>宿舍楼统计</td>
            <td><b><% =BidCount %></b>个</td>
        </tr>
        <tr>
            <td>宿舍统计</td>
            <td><b><% =RidCount %></b>个</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentInfo" runat="server">
</asp:Content>
