<%@ Page Title="添加新宿舍信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DHMS.Roomgr.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">添加新宿舍信息</th>
        </tr>
        <tr>
            <td>院别</td>
            <td>
                <asp:DropDownList ID="tbDid" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tbDid_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>宿舍楼</td>
            <td>
                <asp:DropDownList ID="tbBid" runat="server" TabIndex="1">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <!--tr>
            <td>宿舍编号</td>
            <td>
                <asp:TextBox ID="tbId" runat="server" TabIndex="3"></asp:TextBox>
            </td>
            <td class="tip">如:102</td>
        </tr-->
        <tr>
            <td>宿舍名称</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" TabIndex="4"></asp:TextBox>
            </td>
            <td class="tip">如:102宿舍</td>
        </tr>
        <tr>
            <td>备注</td>
            <td>
                <asp:TextBox ID="tbInfo" runat="server" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="tip">(该宿舍的一些备注信息)</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="确定添加" TabIndex="6" />
            </td>
        </tr>
    </table>
</asp:Content>
