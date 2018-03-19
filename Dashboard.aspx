<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/Dashboard</title>
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
    <style type="text/css">
        .style1
        {
            width: 270px;
        }
    </style>
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
									<li><a class="active" href="#">Dashboard</a></li>
									<li><a href="ViewProfile.aspx">Profile</a></li>
									<li><a href="Genealogy.aspx">Genealogy</a></li>
                                    <li><a href="TransactionDetails.aspx">Transaction Details</a></li>
                                    <li ><a href="#"  id = "lnkLogout" runat="server" >Logout</a></li>
                                	
								</ul>	
									
								<div class="clearfix"> </div>
							</div>	
						</nav>		
				</div>
			</div>
		</div>
		<div class="wthree-heading">
			<h2>My Dashboard</h2><br /><br />
            <form id="Form2" runat = "server">
                        <div style="width: 100%" >




							 <div class="wrap-col">
								<h4>-<asp:Label ID="lblUsername" runat="server" Font-Bold="True" ForeColor="Yellow"></asp:Label>-</h4><h4 align="right">&nbsp;<asp:Label ID="lblCurrentStage" runat="server" ForeColor="Yellow" Font-Bold="True"></asp:Label>
                                </h4>
                                <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                                <asp:Label ID="lblReg_Id" runat="server" visible="false"></asp:Label>
                                <asp:Label ID="lbluuid" runat="server" visible="false"></asp:Label>
                                <br />
                                <br />
							
									<fieldset>
                                    <div class="wrapper" align="left"><span style="color: #FFFF00">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
                                    <div/>

                                    
                                    <div class = "sharp"; style="width: 30%;  float: right; " > 
                                   <table style="width:100%; color: #FFFFFF;"><tr><td>&nbsp;</td><td>
                                       &nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>
                                       &nbsp;</td><td>&nbsp;</td></tr><tr><td class="text-left"><span style="color: #FFFF00">Sponsor's Details</span> 
                                       &nbsp;&nbsp;</td><td class="text-left">
                                           &nbsp;</td><td>&nbsp;</td></tr><tr><td class="text-left">ID</td><td class="text-left">
                                       <asp:Label ID="lblSponsorID" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="text-left">NAME</td><td class="text-left">
                                       <asp:Label ID="lblSponsorName" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="text-left">PHONE NUMBER</td>
                                       <td class="text-left">
                                       <asp:Label ID="lblSponsorPhoneNo" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>
                                       &nbsp;</td><td>&nbsp;</td></tr></table>
                                    </div>

                                    <div class="sharp"; style="width: 60%;  float: right;"  >
                                    <div align="right">
                                   <table style="width:100%;  height: 345px; color: #FFFFFF;" class="dashboardTable">
                                   <tr><td class="style2" 
                                           colspan="2" align="center" bgcolor="#CCCCCC" 
                                           style="font-size: x-large; background-color: #006600;">
                                           My Rewards &amp; Bonus</td><td>&nbsp;</td></tr><tr><td class="style1">
                                       &nbsp;</td><td class="text-left">
                                           &nbsp;</td><td>&nbsp;</td></tr><tr><td class="style1">TOTAL BONUS EARNED(USD)</td>
                                       <td class="text-left">
                                       :
                                       $<asp:Label ID="lbltotalbonusearnedusd" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="style1">TOTAL BONUS EARNED(NGN)</td>
                                       <td class="text-left">
                                       :
                                       N<asp:Label ID="lbltotalbonusearnedngn" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="style1">TOTAL BONUS WITHDRAWN(USD)</td>
                                       <td class="text-left">
                                       :
                                       $<asp:Label ID="lbltotalbonuswithdrawnusd" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="style1">TOTAL BONUS WITHDRAWN(NGN)</td>
                                       <td class="text-left">
                                       :
                                       N<asp:Label ID="lbltotalbonuswithdrawnedngn" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="style1">TOTAL EWALLET BALANCE(USD)</td>
                                       <td class="text-left">
                                       
                                       :
                                       
                                       $<asp:Label ID="lbltotalewalletbalanceusd" runat="server" ></asp:Label>
                                       </td><td>&nbsp;</td></tr><tr><td class="style1">TOTAL EWALLET BALANCE(NGN)</td>
                                       <td class="text-left">
                                       
                                       :
                                       
                                       N<asp:Label ID="lbltotalewalletbalancengn" runat="server" ></asp:Label>
                                       </td><td>
                                  

                                           &nbsp;</td></tr><tr><td class="style1">&nbsp;</td><td class="text-left">
                                           &nbsp;</td><td>&nbsp;</td></tr><tr><td class="style1">&nbsp;</td><td class="text-left">
                                           <button id="btnFundRequest" runat="server" class="button" type="button" 
                                               style="background-color: #0099CC">
                                               Fund Request
                                           </button>
                                       </td><td>&nbsp;</td></tr><tr><td class="style1">&nbsp;</td><td class="text-left">
                                           &nbsp;</td><td>&nbsp;</td></tr><tr><td class="style1">&nbsp;</td><td class="text-left">
                                           &nbsp;</td><td>&nbsp;</td></tr></table>

                                        </div>                                           
                                       
                                    </div>
                                  
                                  <div style="width: 70%; margin-right: auto; margin-left: auto"> 
                                      <asp:Label ID="lblSentPIn" runat="server" Text="PINS sent from Admin" 
                                          ForeColor="White"></asp:Label><br />
                                   	  <asp:Repeater ID="Repeater2" runat="server">
          <HeaderTemplate>
     
              <table border="0" width="80%" cellspacing="0" cellpadding="5">
                  <tr style="background-color: #339933; color: #FFFFFF; font-weight: bold; text-align: center; font-size: 15px;">
                       
                        
                          <td class="reapeatercell_header">
                         USER'S NAME</td>
                       <td class="reapeatercell_header">
                        PIN</td>
                          
                           <td class="reapeatercell_header">
                           DATE
                          </td>
                          
                           <td class="reapeatercell_header">
                      
                          </td>
                     </HeaderTemplate>
          <itemtemplate>
              <tr class="reapeatercell" style="background-color:#f2F9FF; width: 100%; text-align: center;">
                  <tr class="reapeatercell" style="background-color:#DFDFFF; text-align: center; font-size: 13px;">
                      <asp:HiddenField ID="systemHiddenID" runat="server" Value='<%# Eval("UUID") %>' Visible="false" />

                       <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "USERSNAME")%>
                      </td>

                      <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "PINS")%>
                      </td>
                      <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "DATE")%>
                      </td>
                     
                    
              </tr>
                  <tr>
                      <td  colspan="4">
                          &nbsp;</td>
                  </tr>
          </itemtemplate>
          <FooterTemplate>
              </table>
          </FooterTemplate>
      </asp:Repeater>
                                  
</div>
                                   	</fieldset>
                                    	
                                    				
									      

							</div>






						</div>
                        </form>
		</div>
		<!-- //banner -->
	<!-- contact -->
	<div class="contact">
		<div class="w3l-about w3l-team">
			<div class="container">
				<!-- map -->
				
				<!-- //map -->
				<div class="agile-contact-grids">
							</div>
						</div>
					</div>

                    <div align="center" style="width: 100%">
					<div class="col-md-7 contact-form" 
                            style="width: 60%; margin-right: auto; margin-left: auto">
						

					</div>
					<div class="clearfix"> </div>	
				</div>
			</div>
		</div>
	</div>
	<!-- //contact -->
	<!-- footer -->
	<div class="footer">
		<div class="container">
			<div class="agileinfo_footer_grids">
				<div class="col-md-4 agileinfo_footer_grid">
					
					
				</div>
				
				
				<div class="clearfix"> </div>
			</div>
			<div class="w3agile_footer_copy">
				<!--<p>&copy; 2017 Kitchen Food. All rights reserved | Design by <a href="#">DiamondChild</a></p>-->
			</div>
		</div>
	</div>
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