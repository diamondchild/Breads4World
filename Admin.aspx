<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/Admin</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta charset="utf-8">
<meta name="keywords" content="Kitchen Food Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- bootstrap-css -->
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
<!--// bootstrap-css -->
<!-- css -->
<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
<!--// css -->
<!-- font-awesome icons -->
<link href="css/font-awesome.css" rel="stylesheet"> 
<!-- //font-awesome icons -->
<!-- font -->
<link href="//fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet">
<!-- //font -->
<script src="js/jquery-1.11.1.min.js"></script>
<script src="js/bootstrap.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $(".scroll").click(function (event) {
            event.preventDefault();
            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
        });
    });
</script> 
<!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
<![endif]-->
    </head>
<body>
	<!-- banner -->
	<div class="banner">
		<div class="header-top-grids">
			<div class="header">
					<div class="header-left">
						<div class="w3layouts-logo">
							<h1>
								<a href="index.html">Bread For World <span>Int.</span></a>
							</h1>
						</div>
					</div>
			</div>
			<div class="top-nav">
				<div class="top-nav-info">
						<nav class="navbar navbar-default">
								<div class="navbar-header">
									<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
										<span class="sr-only">Toggle navigation</span>
										<span class="icon-bar"></span>
										<span class="icon-bar"></span>
										<span class="icon-bar"></span>
									</button>
								   </div>
							<!-- Collect the nav links, forms, and other content for toggling -->
							<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
								<ul class="nav navbar-nav">
									<li><a class="active"  href="#">Generate PIN</a></li>
									<li><a href="Transfer.aspx">Pending Transfer</a></li>
                                    	<li><a href="ViewTransactionDetails.aspx">Transaction Details</a></li>
								<li><a href="ViewAll.aspx" target = "_blank">View All Users</a></li>
                                     <li><a  href="#" id="lnkLogout" runat="server">Logout</a></li>
								</ul>	
									
								<div class="clearfix"> </div>
							</div>	
						</nav>		
				</div>
			</div>
		</div>
		<div class="wthree-heading">
			<h2>Admin Panel</h2><br /><br />
            <form id="Form2" runat = "server">
                        <div style="width: 100%" >
							 <div id="templatemo_banner">
        <div class="cleaner_h40"></div> <!-- gives space above -->
         
         <div id ="main_content">
         <div style="margin-right: auto; margin-left: auto; width: 800px; margin-top: 10px;">
         <br /> <br />
    <div style="width: 700px; margin-right: auto; margin-left: auto; text-align: center;">
        <div style="text-align: center; font-weight: 700; background-color: #99FF99; color: #000000; font-size: medium; font-family: 'Arial Rounded MT Bold';">
            CODE GENERATION FORM</div>
        <div style="text-align: center; font-size: small;">
            <strong>
            <br />
                       <hr />
        </div>
        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblRegID" runat="server" Visible="False"></asp:Label>
        <br />
        <table cellspacing="7" 
            
            style="border: thin dotted #C0C0C0; width: 400px; margin-right: auto; margin-left: auto; font-size: small; text-align: left; color: #FFFFFF;">
            <tr>
                <td class="style2">
                    <asp:Label ID="lblcodetext" runat="server" Text="Enter No of codes:" 
                        ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcodeNo" ForeColor="Black" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Send Code to UsersName</td>
                <td>
            <strong>
                    <asp:TextBox ID="txtUsersname" ForeColor="Black" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="" colspan="2" style="text-align: center">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btngenerate" runat="server"  Text="Generate" BackColor="#006600" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;
                  
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
       
            <asp:Repeater ID="Repeater2" runat="server">
            <HeaderTemplate>
            <table border="0" width="100%" cellspacing="0" cellpadding="2">
            <tr style="background-color: #6666FF; color: #FFFFFF; font-weight: bold; text-align: center;">
                 <td class="reapeatercell_header">ID</td>
                 <td class="reapeatercell_header">REG_ID</td>
                
                 
            </HeaderTemplate>

            <itemtemplate>
            <tr class="reapeatercell" style="background-color: #33CCFF; text-align: center; color: #000000;">
        
               <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "ID")%></td>
               <td class="reapeatercell"> <%# DataBinder.Eval(Container.DataItem, "REG_ID")%></td>
                 
        
            </tr>
             <tr> 
            <td  colspan="4">&nbsp;</td>    
            </tr>
             </itemtemplate>
            </asp:Repeater>
        
        <br />
    </div>

          </div>
         </div>
     
    
    </div>
						</div>
                        </form>
		</div>
		<!-- //banner -->
	<!-- contact -->
	
		</div>
	</div>
	<!-- //contact -->
	<!-- footer -->
	
	<!-- //footer -->
	<script src="js/SmoothScroll.min.js"></script>
	<script type="text/javascript" src="js/move-top.js"></script>
	<script type="text/javascript" src="js/easing.js"></script>
	<!-- here stars scrolling icon -->
	<script type="text/javascript">
	    $(document).ready(function () {
	        /*
	        var defaults = {
	        containerID: 'toTop', // fading element id
	        containerHoverID: 'toTopHover', // fading element hover id
	        scrollSpeed: 1200,
	        easingType: 'linear' 
	        };
	        */

	        $().UItoTop({ easingType: 'easeOutQuart' });

	    });
	</script>
	<!-- //here ends scrolling icon -->
</body>	
</html>