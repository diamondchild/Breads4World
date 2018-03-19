<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FundRequest.aspx.vb" Inherits="FundRequest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/FundRequest</title>
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
            width: 223px;
            text-align: left;
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
			
		</div>
		<div class="wthree-heading">
			<h2>Transfer Fund</h2><br /><br />
            <form id="Form2" runat = "server">
                        <div style="width: 100%" >
							 <table  background-color: #000000;" 
                                 style="width: 29%; margin-right: auto; margin-left: auto"><tr>
                                     <td style="color: #FFFFFF" class="style1">
                                         &nbsp;</td><td>
											<asp:Label ID="lblMessage" runat="server" Font-Size="Large" 
                                            ForeColor="Yellow"></asp:Label>
                                            </td></tr><tr><td style="color: #FFFFFF"  class="style1">Total Ewallet Balance(USD):</td><td>
											<input id="txteWalletBalance" runat="server"  type="text" style="width: 100%" 
                                                disabled="disabled" />
                                            </td></tr><tr><td style="color: #FFFFFF" class="style1">Amount to Withdrawn(USD):</td><td>
										  <input id="txtAmountWithdrawn" runat="server" placeholder="$" type="text"  style="width: 100%" />
                                          </td></tr><tr><td style="color: #FFFFFF" class="style1"></td><td>
                                                   
                                                    </td></tr><tr><td style="color: #FFFFFF" class="style1">&nbsp;</td><td>
                                                   
                                                    &nbsp;</td></tr><tr><td style="color: #FFFFFF" class="style1">
                                        <button type="button" class="button" id="btnCancelRequest"  runat="server" 
                                         style="background-color: #FF0000"> Cancle Request</button>  
                                       </td><td>
                                       <button type="button" class="button" id="btnRequest"  runat="server" 
                                             style="background-color: #339933"> Request</button> <br />
                                       </td></tr></table>
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