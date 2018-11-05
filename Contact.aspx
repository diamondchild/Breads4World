<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head>
<title>Bread4World/Contact</title>
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
                                  <span style="color: #ffffff; font-family: Broadway;">Enriching lives</span>
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
									<li><a href="index.html">Home</a></li>
									<li><a href="about.html">About Us</a></li>
									<li><a href="HowItWorks.aspx">How It Works</a></li>
                                    <li><a href="FAQ.html">FAQ</a></li>
                                      <li><a href="UpForGrabs.html">Up For Grabs</a></li>
                                       <li><a href="PantryHomes.html">Pantry Homes</a></li>
                                	<li><a class="active" href="contact.html">Contact Us</a></li>
                                     <li><a href="Login.aspx">Login</a></li>
								</ul>	
									
								<div class="clearfix"> </div>
							</div>	
						</nav>		
				</div>
			</div>
		</div>
		<div class="wthree-heading">
			<h2>Contact</h2>
		</div>
	</div>
	<!-- //banner -->
	<!-- contact -->
	<div class="contact">
		<div class="w3l-about w3l-team">
			<div class="container">
				<!-- map -->
				
				<!-- //map -->
				<div class="agile-contact-grids">
					<div class="col-md-5 address">
						<div class="address-row">
							<div class="col-md-2 w3-agile-address-left">
								<span class="glyphicon glyphicon-home" aria-hidden="true"></span>
							</div>
							<div class="col-md-10 w3-agile-address-right">
								<h5>Visit Us</h5>
								<p>18b Second Street, Springs-1559, Johannesburg, South Africa. <br /><br />
                              Plot 208 Idimu-Egbeda Road, Faith Bus Stop.<br />
Lagos State.<br />
Nigeria.</p>
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="address-row">
							<div class="col-md-2 w3-agile-address-left">
								<span class="glyphicon glyphicon-envelope" aria-hidden="true"></span>
							</div>
							<div class="col-md-10 w3-agile-address-right">
								<h5>Mail Us</h5>
								<p>info@breadsforworld.com<br />
                                support@breadsforworld.com</p>
							</div>
							<div class="clearfix"> </div>
						</div>
						<div class="address-row">
							<div class="col-md-2 w3-agile-address-left">
								<span class="glyphicon glyphicon-phone" aria-hidden="true"></span>
							</div>
							<div class="col-md-10 w3-agile-address-right">
								<h5>Call Us</h5>
								<p> +2349067785833
                                <br />
                                +27-634-568-090<br />
                                +234-70-573-3280         </p>
							</div>
							<div class="clearfix"> </div>
						</div>
					</div>
					<div class="col-md-7 contact-form">
						<form  runat = "server" method="post">
                        <table style="width: 100%;">
                        <tr>
                                <td> 
                                    <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                                </td>
                               
                            </tr>
                        <tr>
                                <td>
                  
                                </td>
                                <td>
                                  
                                </td>
                               
                            </tr>
                            <tr>
                                <td> Firstname:
                  
                                </td>
                                <td>
                                  Last Name:
                                </td>
                               
                            </tr>
                            <tr>
                                <td> 
                                   <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>  
                                </td>
                               
                            </tr>

                            <tr>
                                <td> Phone No.:
                  
                                </td>
                                <td>
                                  Email:
                                </td>
                               
                            </tr>

                          <tr>
                                <td> 
                                   <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                  <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>  
                                </td>
                               
                            </tr>

                             <tr>
                                <td> Message
                  
                                </td>
                                <td>
                                  
                                </td>
                               
                            </tr>

                            <tr>
                                <td colspan="2">
                                  <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    &nbsp;
                                </td>
                                                           
                            </tr>
                                                                        
                        </table>
                        <asp:Button id="btnsubmit" runat="server" Text="Submit" />
							
						</form>
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
				<div class="col-md-4 agileinfo_footer_grid">
					<h3>Contact Info</h3>
					<ul class="agileinfo_footer_grid_list">
						<li><i class="glyphicon glyphicon-map-marker" aria-hidden="true"></i>18b Second Street, Springs-1559,<span>Johannesburg, South Africa.</span></li>
						<li><i class="glyphicon glyphicon-envelope" aria-hidden="true"></i>info@breadsforworld.com</li>   
                        						<li><i class="glyphicon glyphicon-earphone" aria-hidden="true"></i>+2349067785833</li>
						<li><i class="glyphicon glyphicon-earphone" aria-hidden="true"></i>+27-634-568-090</li>
                        <li><i class="glyphicon glyphicon-earphone" aria-hidden="true"></i>+2347057333280</li>
					</ul>
				</div>
				
				<div class="clearfix"> </div>
			</div>
			<div class="w3agile_footer_copy">
				<!--<p>© 2017 Kitchen Food. All rights reserved | Design by <a href="#">DiamondChild</a></p>-->
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