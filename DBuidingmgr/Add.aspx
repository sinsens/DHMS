<%@ Page Title="添加新宿舍楼" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DHMS.DBuidingmgr.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">添加新宿舍楼</th>
        </tr>
        <tr>
            <td>院别</td>
            <td>
                <asp:DropDownList ID="tbDid" runat="server" TabIndex="1"></asp:DropDownList>
            </td>
            <td class="tip">&nbsp;</td>
        </tr>
        <!--tr>
            <td>宿舍楼编号</td>
            <td>
                <asp:TextBox ID="tbId" runat="server" TabIndex="2"></asp:TextBox>
            </td>
            <td class="tip">(该编号会自动追加成院编号+自定义编号)</td>
        </!tr-->
        <tr>
            <td>宿舍楼名称</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" TabIndex="4" MaxLength="32"></asp:TextBox>
            </td>
            <td class="tip">示例:1栋</td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" TabIndex="5" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
            </td>
            <td class="tip">(关于该宿舍楼的备注信息)</td>
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
