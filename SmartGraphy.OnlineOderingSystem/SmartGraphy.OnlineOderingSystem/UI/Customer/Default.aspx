<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartGraphy.OnlineOrderingSystem.Web.UI.Default" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Smart Graphy</title>

    <!-- Bootstrap Core CSS -->
    <link href="../../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Theme CSS -->
    <link href="../../assets/global/plugins/bootstrap-toastr/toastr.min.css" rel="stylesheet" type="text/css" />
    <link href="../../assets/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../assets/css/freelancer.min.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lato:400,700,400italic,700italic" rel="stylesheet" type="text/css">


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <!-- jQuery -->
    <script src="../../assets/vendor/jquery/jquery.min.js"></script>

</head>

<body id="page-top" class="index">
    <form id="data" runat="server" novalidate="novalidate" enctype="multipart/form-data" action="Default.aspx" method="post">
        <!-- Modal -->
        <input type="hidden" runat="server" id="img">

        <div id="modalProducts" class="modal fade" style="zoom: 150%;" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Templates</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row" id="div_templates" runat="server">
                        </div>
                        
                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

         <div id="placedOrder" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row" id="div_msg">
                            
                            
                            
                        </div>
                        
                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

        <div id="modalCart" class="modal fade"  role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row" id="cartBody" runat="server">
                            <table class="table table-striped table-hover table-bordered" id="tbl_user">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Category Name</th>
                                        <th>Tempalte Name</th>
                                        <th>Unit Price</th>
                                        <th>Qty</th>
                                        <th>Sub Total</th>
                                        <th></th>
                                        
                                    </tr>
                                </thead>
                                <tbody id="cart" runat="server">

                                </tbody>
                            </table>
                        </div> 
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btn_placeOrder" OnClick="btn_placeOrder_Click" Text="Place Order" CssClass="btn bg-success"></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

        <div id="modalSignIn" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-action">Username</label>
                            </div>
                            <div class="col-md-8">
                                <input type="text" id="txt_un" required="required" class="form-control" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-action">Password</label>
                            </div>
                            <div class="col-md-8">
                                <input type="password" id="txt_pass" required="required" class="form-control" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" OnClick="btnIn_Click" ID="btnIn" Text="Sign In" CssClass="btn btn-default" ></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

        <input type="hidden" runat="server" id="CategoryID">
        <input type="hidden" runat="server" id="UnitPrice">
        <input type="hidden" runat="server" id="TemplateName">
        <input type="hidden" runat="server" id="CategoryName">
        <input type="hidden" runat="server" id="hdnOrderID" />
        <input type="hidden" runat="server" id="templateID1" />

<div id="modalRequirements" class="modal fade"  role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title"></h4>
      </div>
      <div class="modal-body">
        <div class="row" id="div_req" runat="server">

        </div>
        <div class="row">
           <div class="col-md-1"></div>
           <div class="col-md-2"><label class="col-md-2">Qty</label></div>
           <div class="col-md-7">
               <input type="number" required="required" id="txt_Qty" class="form-control" runat="server" />
               <input type="text" id="minVal" runat="server" hidden="hidden" value="100" />
               <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Quantity must be more than 100 items" ControlToCompare="minVal" ControlToValidate="txt_Qty" Operator="GreaterThanEqual"></asp:CompareValidator>
           </div>
          </div>
      </div>
      <div class="modal-footer">
         <asp:Button  CssClass="btn btn-default" runat="server" ID="addCart1" OnClick="addCart1_Click" Text="Add to cart"/> 
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>    


    
        <input type="hidden" runat="server" id="productData" />
    
    <!-- Navigation -->
    <nav id="mainNav" style="background-color: black;" class="navbar navbar-default navbar-fixed-top navbar-custom">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span> Menu <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand" href="#page-top" style="color:white">Smart Graphy</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a href="#page-top"></a>    
                    </li>
                    <li class="page-scroll">
                        <a href="#about">About</a>
                    </li>
                    <li class="page-scroll">
                        <a href="#portfolio">Our Products</a>
                    </li>
                    <li id="li_signup" runat="server" class="page-scroll">
                        <a href="#contact">Sign Up</a>
                    </li>
                    <li id="li_signIn" runat="server"  class="page-scroll">
                        <a data-toggle="modal" data-target="#modalSignIn" href="#modalSignIn">Sign In</a>
                    </li>

                     <li id="li_cart" runat="server"  class="page-scroll">
                        <a data-toggle="modal" data-target="#modalCart" href="#modalCart">Shopping Cart</a>
                    </li>

                    <li onclick="signOut();" hidden="hidden" runat="server" id="li_sginOut" class="page-scroll">
                        <a href="#">Sign out</a>
                    </li>

                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>

    <!-- Header -->
    <header>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <img class="img-responsive" src="../../Images/Logo.PNG" alt="">
                    <div class="intro-text">
                        <span class="name">Smart Graphy</span>
                        <hr class="star-light">
                        <span class="skills"></span>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <!-- About Section -->
    <section id="about">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>About</h2>
                    <hr class="star-primary">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-lg-offset-2">
                    <p>We design and print Bussiness Cards, Banners, Posters as your need using best metirials and deliver them to your home</p>
                </div>
                <div class="col-lg-4">
                    <p>We have unique collection templates on each categories designed by experienced graphic designers and also we accept your idias</p>
                </div>
                <div class="col-lg-8 col-lg-offset-2 text-center">
                    <a href="#" class="btn btn-lg btn-outline">
                        <i class="fa fa-download"></i>Download Theme
                    </a>
                </div>
            </div>
        </div>
    </section>

    <!-- Portfolio Grid Section -->
    <section id="portfolio">
        <div class="container">
            <div class="row" ">
                <div class="col-lg-12 text-center">
                    <h2>Products</h2>
                    <hr class="star-primary">
                </div>
            </div>
            <div id="row_cat" runat="server" class="row">
            </div>
        </div>

    </section>



    <!-- Contact Section -->
    <section id="contact" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>SIGN UP</h2>
                    <hr class="star-primary">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2">
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19. -->
                    <!-- The form should work on most web servers, but if the form is not working you may need to configure your web server differently. -->
                    
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>First Name</label>
                                <input type="text" runat="server" id="txtFirstName" class="form-control" placeholder="First Name">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Last Name</label>
                                <input type="text" class="form-control" runat="server" placeholder="Last Name" id="txtLastName">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Shipping Address Line1</label>
                                <input type="text" id="txt_adLine1" class="form-control" runat="server" placeholder="Address Line1">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Shipping Address Line2</label>
                                <input type="text" runat="server"  class="form-control" placeholder="Address Line2" id="txt_adline2">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Shipping Address Line3</label>
                                <input type="text" runat="server" class="form-control" placeholder="Address Line3" id="txt_adline3">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Email Address</label>
                                <input type="email" runat="server" class="form-control" placeholder="Email Address" id="txt_email">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Phone Number</label>
                                <input type="tel" runat="server" class="form-control" placeholder="Phone Number" id="txt_cn">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Username</label>
                                <input runat="server" type="text" class="form-control" placeholder="Username" id="txt_usrname" />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="row control-group">
                            <div class="form-group col-xs-12 floating-label-form-group controls">
                                <label>Password</label>
                                <input runat="server" type="password" class="form-control" placeholder="Password" id="pw">
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <br>
                        <div id="success"></div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <asp:Button runat="server" ID="btn_up" OnClick="btn_up_Click" CssClass="btn btn-success btn-lg" text="Sign Up" />
                            </div>
                        </div>
                    
                </div>
            </div>
        </div>
    </section>

<input type="hidden" runat="server" id="Status" />
    </form>
    <!-- Footer -->
    <footer class="text-center">
        <div class="footer-above">
            <div class="container">
                <div class="row">
                    <div class="footer-col col-md-4">
                        <h3>Location</h3>
                        <p>
                            55/5B
                            <br>
                            Malwaththa Road, Petah
                        </p>
                    </div>
                    <div class="footer-col col-md-4">
                        <%--<h3>Around the Web</h3>--%>
                        <ul class="list-inline">
                            <li>
                                <a href="#" class="btn-social btn-outline"><i class="fa fa-fw fa-facebook"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><i class="fa fa-fw fa-google-plus"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><i class="fa fa-fw fa-twitter"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><i class="fa fa-fw fa-linkedin"></i></a>
                            </li>
                            <li>
                                <a href="#" class="btn-social btn-outline"><i class="fa fa-fw fa-dribbble"></i></a>
                            </li>
                        </ul>
                    </div>
                    <div class="footer-col col-md-4">
                        <%--<h3>About Freelancer</h3>
                        <p>Freelance is a free to use, open source Bootstrap theme created by <a href="http://startbootstrap.com">Start Bootstrap</a>.</p>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-below">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        Copyright &copy; Smart Graphy 2016
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <!-- Scroll to Top Button (Only visible on small and extra-small screen sizes) -->
    <div class="scroll-top page-scroll hidden-sm hidden-xs hidden-lg hidden-md">
        <a class="btn btn-primary" href="#page-top">
            <i class="fa fa-chevron-up"></i>
        </a>
    </div>





    <!-- Bootstrap Core JavaScript -->
    <link href="../../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Plugin JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src="../../assets/global/plugins/bootstrap-toastr/toastr.min.js" type="text/javascript"></script>
    <!-- Contact Form JavaScript -->
    <script src="../../assets/js/contact_me.js"></script>
    <script src="../../assets/js/jqBootstrapValidation.js"></script>
    <!-- Theme JavaScript -->
    <script src="../../assets/js/freelancer.min.js"></script>
    <script src="../../assets/global/plugins/bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript">
        var products = null;
        var allTemplates = null;
        var requirements = [];
        var selectedProduct = {};
        var selectedTemplate = {};

        $("document").ready(function () {

            products = JSON.parse($("#<%=productData.ClientID%>").val());

            if ($("#<%=Status.ClientID%>").val() == "") {

                $("#<%=li_sginOut.ClientID%>").hide();
            }
            if ($("#<%=Status.ClientID%>").val() == "failed") {

                toastr.error("invalid user details");
            }
            if ($("#<%=Status.ClientID%>").val() == "placed") {
                
                var html = "<p class=\"container\">Dear valuable customer. You have successfully placed an order.<br/> We will contact you within 24 hours. <a href=\"<%:ResolveUrl(hdnOrderID.Value)%>\" target=\"_blank\"> Click here to get your invoce</a></p>";
                $("#div_msg").html(html);
                $("#placedOrder").modal("show");
                $("#<%=Status.ClientID%>").val("");
            }
        });

        function setProductModal(e) {
            var html = "";

            $("#<%=CategoryID.ClientID%>").val($(e).attr("id"));
            $("#<%=CategoryName.ClientID%>").val($(e).attr("data-name"));


            $("#modalProducts").modal("show");

            $("#<%=div_templates.ClientID%>").html(html);
            for (var i = 0; i < products.length; i++) {
                for (var j = 0; j < products[i].Templates.length; j++) {

                    if (products[i].CategoryID == $(e).attr("id")) {
                        selectedProduct = products[i];
                        html += "<div class=\"col-sm-4 portfolio-item\">";
                        html += "<a data-img=\"" + products[i].Templates[j].TemplateImage + "\" data-name=\"" + products[i].Templates[j].TemplateName + "\" data-price=\"" + products[i].Templates[j].UnitPrice + "\" id=\"" + products[i].Templates[j].TemplateID + "\" onClick=\"setRequirements(this);\" href=\"#portfolioModal5\" class=\"portfolio-link\" data-toggle=\"modal\">";
                        html += "<div class=\"caption\">";
                        html += "<div class=\"caption-content\">";

                        html += "</div>";
                        html += "</div>";
                        html += "<label class=\"form-control\" style=\"text-align:center;\"><strong>" + products[i].Templates[j].TemplateName + " </strong></label>"
                        html += "<img style=\"height: 150px; width: 300px;\" src =\"../.." + products[i].Templates[j].TemplateImage + "\" class=\"img-responsive\" alt=\"\">";
                        html += "<label style=\"font-size: small;\" class=\"form-control\"><strong>Price Per Item - Rs " + products[i].Templates[j].UnitPrice + "</strong></label>"
                        html += "<br/>";
                        html += "</a>";
                        html += "</div>";
                        $("#<%=div_templates.ClientID%>").html(html);
                    }

                }
            }
        }
        function setRequirements(e) {
            $("#<%=templateID1.ClientID%>").val($(e).attr("id"));
            $("#<%=UnitPrice.ClientID%>").val($(e).attr("data-price"));
            $("#<%=TemplateName.ClientID%>").val($(e).attr("data-name"));
            var html = "";
            for (var i = 0; i < selectedProduct.Templates.length; i++) {
                if (selectedProduct.Templates[i].TemplateID == $(e).attr("id")) {
                    selectedTemplate = selectedProduct.Templates[i];
                    requirements = selectedTemplate.Requirements;
                }
            }
            if ($("#<%=Status.ClientID%>").val() == "signedIn") {
                html += "";
                html + "<div class=\"row\">";
                html += "<img  src =\"../.." + $(e).attr("data-img") + "\" style=\"width: 600px;\" class=\"img-responsive\" alt=\"\">";
                html += "</div>";
                html += "<br>";
                for (var i = 0; i < requirements.length; i++) {
                    if (requirements[i].DataType == "text") {
                        html += setTextBox(requirements[i].ControllerID, requirements[i].Description, requirements[i].RequirementID);
                    }
                    if (requirements[i].DataType == "tel") {
                        html += setTelBox(requirements[i].ControllerID, requirements[i].Description, requirements[i].RequirementID);
                    }
                    if (requirements[i].DataType == "email") {
                        html += setEmailBox(requirements[i].ControllerID, requirements[i].Description, requirements[i].RequirementID);
                    }
                    if (requirements[i].DataType == "number") {
                        html += setNumberBox(requirements[i].ControllerID, requirements[i].Description, requirements[i].RequirementID);
                    }
                    if (requirements[i].DataType == "file") {
                        html += setFileInput(requirements[i].ControllerID, requirements[i].Description, requirements[i].RequirementID, "required");
                    }
                }
                html += setTextArea("txt_CusComments", "Your Comments(Optional)", 14);
                //html += setFileInput("txt_additionalAttachments", "Additional Attachments(Optional)", 13);
                html += "<div class=row>";
                html += "<div class=\"col-md-1\"></div>";
                html += "<div class=\"col-md-2\">";
                html += "<label class=\"form-control\">Additional Attachments(Optional)</label>";
                html += "</div>";
                html += "<div class=\"col-md-1\"></div>";
                html += "<div class=\"col-md-7\">";
                html += "<input type=\"file\" id=\"file_additionalAttachments\" name=\"file_additionalAttachments\" class=\"form-action\"  data-key=\"14\"></input>";
                html += "</div>";
                html += "</div>";
                html += "<br/>";
            }
            else {
                html += "<div clsaa=\"container\">";
                html += "<p>";
                html += "<h1> Please Login or signup to place your Order </h1>";
                html += "</p>";
                html + "</div>";
            }
            $("#<%=div_req.ClientID%>").html("");
            $("#<%=div_req.ClientID%>").html(html);

            $("#modalRequirements").modal("show");
        }

        function setTextBox(id, label, key) {
            var html = "";
            html += "<div class=\"row\">";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-2\">";
            html += "<label class=\"form-action\">" + label + "</label>";
            html += "</div>"
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-7\">"
            html += "<input type=\"text\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" required=\"required\" data-key=\"" + key + "\"></input>";
            html += "</div>";
            html += "</div>";
            html += "<br/>";

            return html;
        }

        function setTextArea(id, label, key) {
            var html = "";
            html += "<div class=\"row\">";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-2\">";
            html += "<label class=\"form-action\">" + label + "</label>";
            html += "</div>"
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-7\">"
            html += "<textArea id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\"  data-key=\"" + key + "\"></textArea>";
            html += "</div>";
            html += "</div>";
            html += "<br/>";

            return html;
        }

        function setTelBox(id, label, key) {
            var html = "";
            html += "<div class=\"row\">";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-2\">";
            html += "<label class=\"form-action\">" + label + "</label>";
            html += "</div>"
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-7\">"
            html += "<input type=\"tel\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" required=\"required\" data-key=\"" + key + "\"></input>";
            html += "</div>";
            html += "</div>";
            html += "<br/>";

            return html;
        }
        function setNumberBox(id, label, key) {
            var html = "";
            html += "<div class=\"row\">";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-2\">";
            html += "<label class=\"form-action\">" + label + "</label>";
            html += "</div>"
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-7\">"
            html += "<input type=\"number\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" required=\"required\" data-key=\"" + key + "\"></input>";
            html += "</div>";
            html += "</div>";
            html += "<br/>";

            return html;
        }



        function setEmailBox(id, label, key) {
            var html = "";
            html += "<div class=row>";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-2\">";
            html += "<label class=\"form-action\">" + label + "</label>";
            html += "</div>"
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-7\">";
            html += "<input type=\"text\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-control\" required=\"required\" data-key=\"" + key + "\"></input>";
            html += "</div>";
            html += "</div>";
            html += "<br/>";

            return html;
        }

        function setFileInput(id, label, key, required) {
            var html = "";
            html += "<div class=row>";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-2\">";
            html += "<label class=\"form-control\">" + label + "</label>";
            html += "</div>";
            html += "<div class=\"col-md-1\"></div>";
            html += "<div class=\"col-md-7\">";
            html += "<input type=\"file\" id=\"" + id + "\" name=\"" + id + "\" class=\"form-action\" required=\"" + required + "\" data-key=\"" + key + "\"></input>";
            html += "</div>";
            html += "</div>";
            html += "<br/>";

            return html;
        }
        function signOut() {
            $.ajax(
                   {
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //data: "wrkcenter=workCenter&wrkCenterGroup=workCenterGroup&section=section&plantID=plant&primaryField=primayField",
                       data: null,
                       dataType: "json",
                       url: "../../WebServices/BackendWebservice.asmx/SignOut",
                       success: function (result) {

                           window.location.replace("Default.aspx");

                       }

                   }


                   );
        }
    </script>

</body>

</html>

