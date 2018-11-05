<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head>
<style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
         .style1
            {
                float: left;
                height: 50px;
                padding: 15px 15px;
                font-size: 18px;
                line-height: 20px;
                color: #FFFFFF;
            }
    </style>


<title>Bread4World/Home</title>
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
<!-- animation -->
<link href="css/animate.css" rel="stylesheet" type="text/css" media="all">
<script src="js/wow.min.js"></script>
	<script>
	    new WOW().init();
	</script>
<!-- //animation --> 

<!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
<![endif]-->
    <style type="text/css">
        .style1
        {
            background-color: #3333FF;
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
                               
								<a href="index.html">Bread For World <span>Int.</span></a><span></span> 
                                     <span style="color: #ffffff; font-family: Broadway; right: auto; left: auto;" class="style1">Enriching lives</span>
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
									<li><a class="active" href="index.html">Home</a></li>
									<li><a href="about.html">About Us</a></li>
									<li><a href="HowItWorks.aspx">How It Works</a></li>
                                    <li><a href="FAQ.html">FAQ</a></li>
                                      <li><a href="UpForGrabs.html">Up For Grabs</a></li>
                                       <li><a href="PantryHomes.html">Pantry Homes</a></li>
                                	<li><a href="contact.html">Contact Us</a></li>
                                     <li><a href="Login.aspx">Login</a></li>
								</ul>	
								<div class="clearfix"> </div>
							</div>	
						</nav>		
				</div>
			</div>
		</div>

         <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


<%--**********************flappy*********************--%>

<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2" TargetControlID="show2"
    CancelControlID="Button1" BackgroundCssClass="Background">
</cc1:ModalPopupExtender>

<asp:Panel ID="Panel2" runat="server" CssClass="Popup" align="center" style = "display:none">
    <iframe style=" width: 400px; height: 400px;" id="Iframe1" src="BreakingNews.aspx" runat="server"></iframe>
   <br/>
    <asp:Button ID="Button1" runat="server" Text="Close" />
</asp:Panel>





       
        <br /><br />
       <asp:Button ID="show2" runat="server" Text="Breaking New"  />
		


		<div class="w3layouts-banner-slider">
				<div class="container">
					<div class="slider">
						<div class="callbacks_container">
							
								
								<div align="center" class = "sharp2">
                                 <marquee class='marquee-code' direction='left' behavior='alternate' scrollamount='1' >
                           <img src="images/home1.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;
                          <img src="images/home2.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <img src="images/home3.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <img src="images/home4.jpg" />
                           </marquee>

                           <br />                      </div>

                       




						</div>
						<div class="clearfix"> </div>
						<script>
						    // You can also use "$(window).load(function() {"
						    $(function () {
						        // Slideshow 4
						        $("#slider4").responsiveSlides({
						            auto: true,
						            pager: true,
						            nav: false,
						            speed: 500,
						            namespace: "callbacks",
						            before: function () {
						                $('.events').append("<li>before event fired.</li>");
						            },
						            after: function () {
						                $('.events').append("<li>after event fired.</li>");
						            }
						        });

						    });
						 </script>
						<!--banner Slider starts Here-->
					</div>
				</div>
		</div>
	</div>
	<!-- //banner -->
	<!-- welcome -->
	<div class="welcome" id="welcome">
		<div class="col-md-5 ab-w3-agile-img">
			 
		</div>
		<div class="col-md-7 ab-w3-agile-info">
			<div class="ab-w3-agile-info-text">
				<h2 class="title-w3">Welcome</h2>
				<p class="sub-text one">to Bread4World</p>
				<p>Bread for world is an international organization. In 1984, the movement started in a community in America as an NGO which later annexed to Europe (Uk and Greece) and Africa (Cameroon and South Africa). <br/><br/>The company main aim and initial objective is to shelter the less privilege, feed the orphans and widows, attend to the needy, the sick and injured.</p>
				
			</div>
			<div class="ab-w3-agile-inner">
				<div class="col-md-6 ab-w3-agile-part">
					<h4>History</h4>
					<p> In 1995, the movement annexed to Africa with its formal agenda. 
Thereafter, the Co-founders in South Africa introduced the multi level marketing aspect of Bread For World here in Nigeria, being the biggest populated black Nation of the world. <br />
This business aspect of Bread For World serves as trusted “ PLAN B”, for more food in your kitchen and financial upliftment. </p>
				</div>
				<div class="col-md-6 ab-w3-agile-part two">
					<h4>Our Services</h4>
					<p>-Out door services and promotion of goods and services of different brands
E.g; food, beverages, toiletries, home appliances, materials, etc.
 <br />
-Humanitarian services, Eg; free medical eye care.
 
-Event planning, Interior decoration
 
-Skill acquisition programs <br/>
E.g; Vocational skills, bakery, bead-making, soap-making, make-up, etc.</p>
				</div>
				<div class="clearfix"></div>		   
			</div>	
		</div>
		<div class="clearfix"></div>
	</div>
    
	<!-- //welcome -->
	<!-- services -->
	<!--<div class="services" id="services">
		<div class="container">
			<div class="w3-agile-heading">
				<!--<h3>Services</h3>-->
			</div>
			<!--<div class="w3ls-services-grids">
				<div class="col-md-3 w3ls-services-left">
					<div class="w3ls-services-left-top">
						<i class="fa fa-user" aria-hidden="true"></i>
						<h5>Praesent et metus</h5>
						<p>Donec neque urna, tempor id est id, gravida molestie nunc. Fusce non lectus pretium</p>
					</div>
					<div class="w3ls-services-left-top w3ls-services-left-top1">
						<i class="fa fa-asterisk" aria-hidden="true"></i>
						<h5>Praesent et metus</h5>
						<p>Donec neque urna, tempor id est id, gravida molestie nunc. Fusce non lectus pretium</p>
					</div>
				</div>
				<div class="col-md-6 w3ls-services-middle">
					<div class="w3ls-services-middle-img">
						<img src="images/4.jpg" alt="" />
					</div>
					<div class="w3ls-services-middle-grids">
						<div class="col-md-6 w3ls-services-middle-left">
							<div class="w3ls-services-left-top">
								<i class="fa fa-bell" aria-hidden="true"></i>
								<h5>Praesent et metus</h5>
								<p>Donec neque urna, tempor id est id, gravida molestie nunc. Fusce non lectus pretium</p>
							</div>
						</div>
						<div class="col-md-6 w3ls-services-middle-left">
							<div class="w3ls-services-left-top">
								<i class="fa fa-heart" aria-hidden="true"></i>
								<h5>Praesent et metus</h5>
								<p>Donec neque urna, tempor id est id, gravida molestie nunc. Fusce non lectus pretium</p>
							</div>
						</div>
						<div class="clearfix"> </div>
					</div>
				</div>
				<div class="col-md-3 w3ls-services-left">
					<div class="w3ls-services-left-top">
						<i class="fa fa-eye" aria-hidden="true"></i>
						<h5>Praesent et metus</h5>
						<p>Donec neque urna, tempor id est id, gravida molestie nunc. Fusce non lectus pretium</p>
					</div>
					<div class="w3ls-services-left-top w3ls-services-left-top1">
						<i class="fa fa-anchor" aria-hidden="true"></i>
						<h5>Praesent et metus</h5>
						<p>Donec neque urna, tempor id est id, gravida molestie nunc. Fusce non lectus pretium</p>
					</div>
				</div>
				<div class="clearfix"> </div>
			</div>-->
		</div>
	</div>-->
	<!-- //services -->
	<!-- news -->
	<!--<div class="news jarallax">
		<div class="container">
			<div class="w3-agile-heading news-heading">
				<h3>Events</h3>
			</div>
			<div class="news-grids">
				<div class=" col-md-4 section-grid-wthree one">
					<div class="services-info-w3-agileits">
						<h5 class="sub-title"><a href="single.html">Lorem ipsum dolor sit </a></h5>
						<h6>Sep 06,2017 | By <a href="#">Admin</a></h6>
						<p class="para-w3">Lorem Ipsum is simply dummy text of the printing and typesetting industry. ever since the 1500s.</p>
					</div>
					<div class="services-img-agileits-w3layouts">
						<a href="single.html"><img src="images/5.jpg" alt="service-img"></a>
					</div>
				</div>
				<div class=" col-md-4 section-grid-wthree">
					<div class="services-img-agileits-w3layouts">
						<a href="single.html"><img src="images/6.jpg" alt="service-img"></a>
					</div>
					<div class="services-info-w3-agileits mid">
						<h5 class="sub-title"><a href="single.html">Lorem ipsum dolor sit </a></h5>
						<h6>Sep 06,2017 | By <a href="#">Admin</a></h6>
						<p class="para-w3">Lorem Ipsum is simply dummy text of the printing and typesetting industry. ever since the 1500s.</p>
					</div>
				</div>
				<div class=" col-md-4 section-grid-wthree">
					<div class="services-info-w3-agileits">
						<h5 class="sub-title"><a href="single.html">Lorem ipsum dolor sit </a></h5>
						<h6>Sep 06,2017 | By <a href="#">Admin</a></h6>
						<p class="para-w3">Lorem Ipsum is simply dummy text of the printing and typesetting industry. ever since the 1500s.</p>
					</div>
					<div class="services-img-agileits-w3layouts">
						<a href="single.html"><img src="images/7.jpg" alt="service-img"></a>
					</div>
				</div>
				<div class="clearfix"></div>
			</div>
		</div>
	</div>-->
	<!-- //news -->
	<!-- subscribe -->
	<!--<div class="subscribe">
		<div class="container">
			<div class="w3-agile-heading agile-subscribe-heading">
				<h3>Subscribe</h3>
				<p>Subscribe to our email newsletter to receive updates</p>
			</div>
			<div class="subscribe-grid">
				<form action="#" method="post">
					<input type="text" placeholder="Subscribe" name="Subscribe" required="">
					<button class="btn1"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
				</form>
			</div>
		</div>
	</div>-->
	<!-- //subscribe -->
	<!-- footer -->
    </form>
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
                        <!--<li><i class="glyphicon glyphicon-earphone" aria-hidden="true"></i>+2347039327639</li>-->
					</ul>
				</div>

            
				
                <div class="clearfix">      </div>
			</div>
			<div class="w3agile_footer_copy">
            <a href="Terms.aspx">Terms and Condition</a>
				<!--<p>&copy; 2017 Kitchen Food. All rights reserved | Design by <a href="#">DiamondChild</a></p>-->
			</div>
		</div>
	</div>-->
	<!-- //footer -->
	<script src="js/responsiveslides.min.js"></script>
	<script src="js/jarallax.js"></script>
	<script src="js/SmoothScroll.min.js"></script>
	<script type="text/javascript">
	    /* init Jarallax */
	    $('.jarallax').jarallax({
	        speed: 0.5,
	        imgWidth: 1366,
	        imgHeight: 768
	    })
	</script>
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