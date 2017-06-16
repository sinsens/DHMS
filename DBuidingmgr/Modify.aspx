<%@ Page Title="修改宿舍楼信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="DHMS.DBuidingmgr.Modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">修改宿舍楼信息</th>
        </tr>
        <tr>
            <td>院编号</td>
            <td>
                <asp:DropDownList ID="tbDid" runat="server" TabIndex="1"></asp:DropDownList>
            </td>
            <td class="tip">当前为:<asp:Label ID="lbDid" runat="server" Text="[null]"></asp:Label></td>
        </tr>
        <tr>
            <td>宿舍楼编号</td>
            <td>
                <asp:TextBox ID="tbBid" runat="server" TabIndex="2" ReadOnly="true"></asp:TextBox>
            </td>
            <td class="tip">(不可更改)</td>
        </tr>
        <tr>
            <td>宿舍楼名称</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" TabIndex="4"></asp:TextBox>
            </td>
            <td class="tip">当前为:<asp:Label ID="lbName" runat="server" Text="[null]"></asp:Label></td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" MaxLength="255" TextMode="MultiLine" Height="50px"></asp:TextBox>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="tip">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnAdd_Click" Text="保存修改" TabIndex="6" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
