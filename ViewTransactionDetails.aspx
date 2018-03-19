<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewTransactionDetails.aspx.vb" Inherits="ViewTransactionDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Bread4World/TransactionDetails</title>
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
			<h2>Transaction Log</h2><br /><br />
            <form id="Form2" runat = "server">
                        <div style="width: 100%" >
							 <div id="templatemo_banner">
        <div class="cleaner_h40"></div> <!-- gives space above -->
         
         <div id ="main_content">
         <div style="margin-right: auto; margin-left: auto; width: 800px; margin-top: 10px;">
         <br /> <br />
    <div style="width: 900px; margin-right: auto; margin-left: auto; text-align: center;">
        <div style="text-align: center; font-weight: 700; background-color: #99FF99; color: #000000; font-size: medium; font-family: 'Arial Rounded MT Bold';">
                                          search via Reg_ID(PIN)        <asp:DropDownList ID="ddlUserID" color="#000000" runat="server" 
                                         style="background-color: #FFFFFF; color: #000000;" AutoPostBack="True" >
               </asp:DropDownList> </div>
        <div style="text-align: center; font-size: small;">
            
            <br />
                       
        </div>
        <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
       

        <asp:Label ID="lblReg_Id" runat="server"  Visible="False"></asp:Label>
       

       <asp:Repeater ID="Repeater2" runat="server">
          <HeaderTemplate>
     
              <table border="0" width="100%" cellspacing="0" cellpadding="5">
                  <tr style="background-color: #339933; color: #FFFFFF; font-weight: bold; text-align: center; font-size: 15px;">
                       
                        
                          <td class="reapeatercell_header">
                         REG ID</td>
                       <td class="reapeatercell_header">
                        AMOUNT</td>
                          
                           <td class="reapeatercell_header">
                          TRANSACTION TYPE
                          </td>
                           <td class="reapeatercell_header">
                          DESCRIPTION
                          </td>
                           <td class="reapeatercell_header">
                          DATE
                          </td>

                           <td class="reapeatercell_header">
                      
                          </td>
                     </HeaderTemplate>
          <itemtemplate>
              <tr class="reapeatercell" style="background-color:#f2F9FF; width: 100%; text-align: center;">
                  <tr class="reapeatercell" style="background-color:#DFDFFF; text-align: center; font-size: 13px;">
                      <asp:HiddenField ID="systemHiddenID" runat="server" Value='<%# Eval("REG_ID") %>' Visible="false" />
                      
                       <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "REG_ID")%>
                      </td>

                      <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "AMOUNT")%>
                      </td>

                      <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "TRANSACTION_TYPE")%>
                      </td>

                      <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "DESCRIPTION")%>
                      </td>

                       <td class="reapeatercell">
                          <%# DataBinder.Eval(Container.DataItem, "_DATE")%>
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
