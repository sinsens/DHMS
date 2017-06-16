<%@ Page Title="修改费率信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="DHMS.Ratemgr.Modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">修改费率信息</th>
        </tr>
        <tr>
            <td>显示名称</td>
            <td>
                <asp:TextBox ID="tbName" MaxLength="32" runat="server" TabIndex="0"></asp:TextBox>;</td>
            <td class="tip">用来便于记忆的名称(不能与已有的重复)</td>
        </tr>
        <tr>
            <td>是否启用</td>
            <td>
                <asp:DropDownList ID="tbUse" runat="server" TabIndex="1">
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tip">当前为:<asp:Label ID="lbUse" runat="server" Text="[null]"></asp:Label></td>
        </tr>
        <tr>
            <td>冷水费率</td>
            <td>
                <asp:TextBox ID="tbCr" runat="server" TabIndex="2"></asp:TextBox>
            </td>
            <td class="tip">当前为:<asp:Label ID="lbCr" runat="server" Text="[null]"></asp:Label></td>
        </tr>
        <tr>
            <td>热水费率</td>
            <td>
                <asp:TextBox ID="tbHr" runat="server" TabIndex="4"></asp:TextBox>
            </td>
            <td class="tip">当前为:<asp:Label ID="lbHr" runat="server" Text="[null]"></asp:Label></td>
        </tr>
        <tr>
            <td>电力费率</td>
            <td>
                <asp:TextBox ID="tbDr" runat="server" TabIndex="5"></asp:TextBox>
            </td>
            <td class="tip">当前为:<asp:Label ID="lbDr" runat="server" Text="[null]"></asp:Label></td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" MaxLength="255" TextMode="MultiLine" Height="50px" TabIndex="7"></asp:TextBox>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnAdd_Click" Text="保存修改" TabIndex="8" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
