<%@ Page Title="导入宿舍信息" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="DHMS.Roomgr.ImportData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">

    <table style="width: 100%;" border="1">
        <tr>
            <th colspan="3">导入宿舍信息</th>
        </tr>
        <tr>
            <td>下载示例文件</td>
            <td>
                <asp:Button ID="btnDownSample" runat="server" Text="点击下载" OnClick="btnDownSample_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>上传文件</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="1" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                
                <asp:Button ID="btnUpload" runat="server" Text="确定导入" OnClick="btnUpload_Click" TabIndex="3" />
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
