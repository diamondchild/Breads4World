<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewProfile.aspx.vb" Inherits="ViewProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/ViewProfile</title>
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
            width: 123px;
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
									<li><a href="Dashboard.aspx">Dashboard</a></li>
									<li><a class="active" href="ViewProfile.aspx">Profile</a></li>
									<li><a href="Genealogy.aspx">Genealogy</a></li>
                                    <li ><a href="#"  id = "lnkLogout" runat="server" >Logout</a></li>
                                	
								</ul>	
									
								<div class="clearfix"> </div>
							</div>	
						</nav>		
				</div>
			</div>
		</div>
		<div class="wthree-heading">
			<h2>My Profile</h2><br /><br />
            <form id="Form2" runat = "server">
                        <div style="width: 100%" >




							 <div class = "sharp" style="padding: 10px; width: 60%;   margin-right: auto; margin-left: auto;"  
                                            align="center">
<asp:Label ID="lblMessage" runat="server" ></asp:Label>

                                    <table style="width: 98%; font-size: large; color: #FFFFFF; padding-left: 10px; " border="3" 
                                    cellspacing="2" frame="box" >
                                   <tr><td class="style1">&nbsp;</td><td>
                                       &nbsp;</td></tr>
                                   <tr><td class="style1">First Name</td><td>
                                       <asp:Label ID="lblfirstname" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Last Name</td><td>
                                       <asp:Label ID="lbllastname" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Country</td><td>
                                       <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                       </td></tr><tr><td class="style1">State</td><td>
                                       <asp:Label ID="lblState" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">City</td><td>
                                       <asp:Label ID="lblCity" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">E-mail</td><td>
                                       <asp:Label ID="lblEmail" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Mobile</td><td>
                                       <asp:Label ID="lblMobile" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Gender</td><td>
                                       <asp:Label ID="lblGender" runat="server"></asp:Label>
                                       </td></tr><tr><td class="style1">Address</td><td>
                                       <asp:Label ID="lblAddress" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Date of Birth</td><td>
                                       <asp:Label ID="lblDOB" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Username</td><td>
                                       <asp:Label ID="lblUsername" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">Bank Name</td><td>
                                       <asp:Label ID="lblBankName" runat="server"></asp:Label>
                                       </td></tr><tr><td class="style1">Account Name</td><td>
                                       <asp:Label ID="lblAccountName" runat="server"></asp:Label>
                                       </td></tr><tr><td class="style1">Account Number</td><td>
                                       <asp:Label ID="lblAccountNumber" runat="server" ></asp:Label>
                                       </td></tr><tr><td class="style1">&nbsp;</td><td>
                                            &nbsp;</td></tr></table><br />
                                        <button type="button" class="button" id="btnEdit"  runat="server"> Edit</button>  
                                        <button type="button" class="button" id="btnChangePassword"  runat="server"> Change Password</button>  
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