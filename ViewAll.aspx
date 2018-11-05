<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewAll.aspx.vb" Inherits="ViewAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
    <div style="width: 50%; margin-right: auto; margin-left: auto">
    <div style="font-family: 'Arial Black'; background-color: #006600; color: #FFFFFF; width: 100%;"><h1>List of Registered Users&nbsp;&nbsp;  
       <div style="float: right"> <asp:Label ID="lblCount" runat="server" style="color: #FF0000" 
            BackColor="White"></asp:Label></h1></div>
       
    <asp:Repeater ID="Repeater2" runat="server">
            <HeaderTemplate>
            <table border="0" width="100%" cellspacing="0" cellpadding="2">
            <tr style="background-color: #006600; color: #FFFFFF; font-weight: bold; text-align: center;">
             
                 <td class="reapeatercell_header">REG_ID</td>
                 <td class="reapeatercell_header">USERSNAME</td>
                  <td class="reapeatercell_header">FIRST_NAME</td>
                   <td class="reapeatercell_header">LAST_NAME</td>
                   <td class="reapeatercell_header">MOBILE</td>
                     <td class="reapeatercell_header">SPONSOR NAME</td>
                     <td class="reapeatercell_header">PASSWORD</td>
                       <td class="reapeatercell_header">CURRENT_STAGE_ID</td>
                   <td class="reapeatercell_header">DATE</td>
                                       
            </HeaderTemplate>

            <itemtemplate>
            <tr class="reapeatercell" style="background-color: #F4F4FF; text-align: center; color: #000000;">
        
           
               <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "REG_ID")%></td>
                <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "USERSNAME")%></td>

                                <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "FIRST_NAME")%></td>
                                                <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "LAST_NAME")%></td>

                 <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "MOBILE")%></td>
                 <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "SPONSOR_NAME")%></td>
                  <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "PASSWORD")%></td>
                    <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "CURRENT_STAGE_ID")%></td>
                  <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "DATE")%></td>

            </tr>
             <tr> 
            <td  colspan="4">&nbsp;</td>    
            </tr>
             </itemtemplate>
            </asp:Repeater>
             </div>
    </div>
    </form>
</body>
</html>
