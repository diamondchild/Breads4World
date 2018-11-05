<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Genealogy.aspx.vb" Inherits="Genealogy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/Genealogy</title>
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

    <style type="text/css">
    ul.tree {
        overflow-x: auto;
        white-space: nowrap;
    }
    ul.tree,
    ul.tree ul {
        width: auto;
        margin: 0;
        padding: 0;
        list-style-type: none;
    }
    ul.tree li {
        display: block;
        width: auto;
        float: left;
        vertical-align: top;
        padding: 0;
        margin: 0;
    }
    ul.tree ul li {
        background-image: url(data:image/gif;base64,R0lGODdhAQABAIABAAAAAP///ywAAAAAAQABAAACAkQBADs=);
        background-repeat: repeat-x;
        background-position: left top;
    }
    ul.tree li span {
        display: block;
        width: 10em;
        /*
          uncomment to fix levels
          height: 1.5em;
        */
        margin: 0 auto;
        text-align: center;
        white-space: normal;
        letter-spacing: normal;
    }
</style>
<!--[if IE gt 8]> IE 9+ and not IE -->
<style type="text/css">
    ul.tree ul li:last-child {
        background-repeat: no-repeat;
        background-size:50% 1px;
        background-position: left top;
    }
    ul.tree ul li:first-child {
        background-repeat: no-repeat;
        background-size: 50% 1px;
        background-position: right top;
    }
    ul.tree ul li:first-child:last-child {
        background: none;
    }
    ul.tree ul li span {
        background: url(data:image/gif;base64,R0lGODdhAQABAIABAAAAAP///ywAAAAAAQABAAACAkQBADs=) no-repeat 50% top;
        background-size: 1px 0.8em;
        padding-top: 1.2em;
    }
    ul.tree ul {
        background: url(data:image/gif;base64,R0lGODdhAQABAIABAAAAAP///ywAAAAAAQABAAACAkQBADs=) no-repeat 50% top;
        background-size: 1px 0.8em;
        margin-top: 0.2ex;
        padding-top: 0.8em;
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
									<li><a  href="ViewProfile.aspx">Profile</a></li>
									<li><a class="active" href="Genealogy.aspx">Genealogy</a></li>
                                    <li><a  href="ViewDownliners.aspx" target = "_blank">View Downliners</a></li>
                                    <li ><a href="#"  id = "lnkLogout" runat="server" >Logout</a></li>
									
								<div class="clearfix"> </div>
							</div>	
						</nav>		
				</div>
			</div>
		</div>
		<div class="wthree-heading">
			<h2>Genealogy</h2><br /><br />

           <div>
              
   
							<div style="width: 100%; margin-right: auto; margin-left: auto">
							<form id="Form1"  runat="server">				
									 <asp:DropDownList ID="ddlUsersname" color="#000000" runat="server" 
                                         style="background-color: #FFFFFF; color: #000000;" AutoPostBack="True" >
               </asp:DropDownList> <br /><br />
                            <asp:Label ID="lblStageName" runat="server" 
                                         style="color: #FFFF00; font-weight: 700; font-size: x-large"></asp:Label>
             




                                    <div><h4 style="color: #FFFF00; width: 399px;" > 
                                        
                                        </h4><br />
                                            <div style="width:2500px; margin-left: auto; margin-right: auto; background-color: #FFFFFF;" runat="server" 
                                            id="genealogyDiv"></div>
                                           
                                     </div>






                                       
										
																
														
								</form>
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

                    <div align="center" style="width: 100%; background-color: #FFFFFF;">
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