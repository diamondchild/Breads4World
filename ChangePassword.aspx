<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/ChangePassword</title>
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
            width: 252px;
            text-align: left;
        }
        .style2
        {
            color: #00FF00;
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
										<li><a href="index.html">Dashboard</a></li>
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

                  
                                   <div class = "sharp2" style="padding: 10px; width: 60%;   margin-right: auto; margin-left: auto;"  
                                            align="center"><h4 class="style2"><strong>Change Password</strong></h4><br />
                                            <asp:Label ID="lblMessage" runat="server" Font-Size="Large" 
                                            ForeColor="Yellow"></asp:Label>

                                            <table style="width:73%;"><tr><td class="style1" style="color: #FFFFFF">Enter Reg Id</td><td>
											<input id="txtRegID" runat="server" type="text" style="width: 100%" /></td></tr>
                                            <tr><td class="style1" style="color: #FFFFFF">Enter Existing Password:</td><td>
											<input id="txtPassword" runat="server" type="password" style="width: 100%" />
                                            </td></tr><tr><td class="style1" style="color: #FFFFFF">&nbsp;</td><td>
											        &nbsp;</td></tr><tr><td class="style1" style="color: #FFFFFF">Enter New Password:</td><td>
										    <input id="txtNewPassword" runat="server" type="password"  style="width: 100%" />
                                            </td></tr><tr><td class="style1" style="color: #FFFFFF">Confirm New Password</td><td>
										    <input id="txtConfirmNewPassword" runat="server" type="password"  style="width: 100%" /></td></tr><tr><td class="style1" style="color: #FFFFFF"></td><td>&nbsp;</td></tr></table>
                                                        
                                                        <button type="button" class="button" id="btnCancel"  runat="server"> Back</button> 
                                                      <button type="button" class="button" id="btnChange"  runat="server"> Change</button>  
                                                      

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
				<div class="col-md-4 agileinfo_footer_grid">
					<h3>Contact Info</h3>
					<ul class="agileinfo_footer_grid_list">
						<li><i class="glyphicon glyphicon-map-marker" aria-hidden="true"></i>18b Second Street, Springs-1559,<span>Johannesburg, South Africa.</span></li>
						<li><i class="glyphicon glyphicon-envelope" aria-hidden="true"></i><a href="mailto:info@breadsforworld.com">info@breadsforworld.com</a></li>   <li><i class="glyphicon glyphicon-envelope" aria-hidden="true"></i><a href="mailto:support@breadsforworld.com">support@breadsforworld.com</a></li>
						<li><i class="glyphicon glyphicon-earphone" aria-hidden="true"></i>+27-634-568-090</li>
					</ul>
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