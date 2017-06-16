<%@ Page Title="添加新院别" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DHMS.Yardmgr.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">添加新院别</th>
        </tr>
        <tr>
            <td>院编号</td>
            <td>
                <asp:TextBox ID="tbId" runat="server" TabIndex="1"></asp:TextBox>
            </td>
            <td class="tip">示例:1(不能以0开头,保存后该字段无法修改)</td>
        </tr>
        <tr>
            <td>院名称</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" TabIndex="2"></asp:TextBox>
            </td>
            <td class="tip">示例:男1号院（保存后可以修改）</td>
        </tr>
        <tr>
            <td>院类别</td>
            <td>
                <asp:DropDownList ID="tbType" runat="server" TabIndex="4">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tip">(保存后可以修改)</td>
        </tr>
        <tr>
            <td>备注信息</td>
            <td>
                <asp:TextBox ID="info" runat="server" TabIndex="2" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="tip">示例:男1号院（保存后可以修改）</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="确定添加" TabIndex="6" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
