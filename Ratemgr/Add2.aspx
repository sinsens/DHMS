<%@ Page Title="新建变动费率信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Add2.aspx.cs" Inherits="DHMS.Ratemgr.Add2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">新建变动费率信息</th>
        </tr>
        <tr>
            <td>是否启用</td>
            <td>
                <asp:DropDownList ID="tbUse" runat="server" TabIndex="1">
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tip"></td>
        </tr>
        <tr>
            <td>冷水费率</td>
            <td>
                <asp:TextBox ID="tbCr" runat="server" TabIndex="2"></asp:TextBox>
            </td>
            <td class="tip">如:2.4</td>
        </tr>
        <tr>
            <td>热水费率</td>
            <td>
                <asp:TextBox ID="tbHr" runat="server" TabIndex="4"></asp:TextBox>
            </td>
            <td class="tip">如:3.3</td>
        </tr>
        <tr>
            <td>电力费率</td>
            <td>
                <asp:TextBox ID="tbDr" runat="server" TabIndex="5"></asp:TextBox>
            </td>
            <td class="tip">如:0.5</td>
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
                <asp:Button ID="btnSave" runat="server" OnClick="btnAdd_Click" Text="保存" TabIndex="8" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
