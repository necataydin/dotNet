<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Veri Güncelle" 
            onclick="Button1_Click" /><asp:Button ID="Button2" runat="server" 
            Text="Veri Listele" onclick="Button2_Click" />
        <asp:Panel ID="Panel1" runat="server">

        <table>
        <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Ad Soyad:"></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td><asp:Label ID="Label2" runat="server" Text="E-posta: "></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Şifre: "></asp:Label></td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:Button ID="Button3" runat="server" Text="Veri Ekle" 
                onclick="Button3_Click" />
        </table>

            
            
            
        </asp:Panel>

    </div>
    </form>
</body>
</html>
