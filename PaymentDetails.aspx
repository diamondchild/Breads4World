<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentDetails.aspx.vb" Inherits="PaymentDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 149px;
            text-align: left;
        }
        .style2
        {
            text-align: left;
        }
        .style3
        {
            width: 149px;
            text-align: left;
            color: #CCCCFF;
        }
        .style4
        {
            color: #003300;
            background-color: #FFCCCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="margin-top: 50px">
        <table style="width: 40%; background-color: #CCFFCC;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <strong><span class="style4">BANK DETAILS</span></strong></td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Amount Requested</td>
                <td class="style2">
                    <asp:Label ID="lblAmount" runat="server" 
                        style="color: #FF0000; font-weight: 700; background-color: #FFFFFF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    UserName:</td>
                <td class="style2">
                    <asp:Label ID="lblUserName" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Reg_Id:</td>
                <td class="style2">
                    <asp:Label ID="lblID" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Bank Name:</td>
                <td class="style2">
                    <asp:Label ID="lblBankName" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Account Name:</td>
                <td class="style2">
                    &nbsp;<asp:Label ID="lblAccountName" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Account Number:</td>
                <td class="style2">
                    &nbsp;<asp:Label ID="lblAccountNumber" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Description:</td>
                <td class="style2">
                    <asp:TextBox ID="txtDescription" runat="server" Height="39px" Width="282px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                    <asp:Button ID="btnDone" runat="server" BackColor="#006600" 
                        ForeColor="White" Text="Done" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
