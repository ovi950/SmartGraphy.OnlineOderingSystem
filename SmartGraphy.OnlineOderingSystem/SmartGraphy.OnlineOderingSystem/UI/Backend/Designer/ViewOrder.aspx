<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" MasterPageFile="~/UI/Backend/Site1.Master" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Designer.ViewOrder" %>
<%--designer--%>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <link href="../../../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
        <link href="../../../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
        <link href="../../../assets/global/plugins/bootstrap-toastr/toastr.css" rel="stylesheet" type="text/css" />
        <link href="../../../assets/global/plugins/bootstrap-toastr/toastr.min.css" rel="stylesheet" type="text/css" />
        <br />
        <script src="../../../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../../../assets/pages/scripts/ui-extended-modals.js" type="text/javascript"></script>
        <script src="../../../assets/pages/scripts/ui-extended-modals.min.js" type="text/javascript"></script>
        <script src="../../../assets/pages/scripts/ui-modals.js" type="text/javascript"></script>
        <script src="../../../assets/pages/scripts/ui-modals.min.js" type="text/javascript"></script>
        <script src="../../../assets/global/plugins/bootstrap-toastr/toastr.min.js" type="text/javascript"></script>
        <script src="../../../assets/global/plugins/bootstrap-toastr/toastr.js" type="text/javascript"></script>
        <input type="hidden" id="hdnProductCat" runat="server" />
        <h3>
            <a href="Default.aspx">HOME</a>
            <small>View Order</small>
        </h3>

        <input type="hidden" runat="server" id="headerID" />
        <input type="hidden" runat="server" id="user" />
        <div id="modalRequirements" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Availabe Designers</h4>
                    </div>
                    <div class="modal-body">
                        <table class="table table-striped table-hover table-bordered">
                            <thead>
                                <tr>
                                    <th>Designer Name</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody runat="server" id="tbl_designers">
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">

                        <%--                        <asp:Button Type="button" ID="btn_update" CssClass="btn light blue btn-outline" OnClick="btn_update_Click" runat="server" Text="Update"></asp:Button>
                        <asp:Button ID="btnAddCat" CssClass="btn light blue btn-outline" runat="server" OnClick="btnAddCat_Click" Text="Add" />
                        <button type="button" id="btn_cancel" class="btn dark btn-outline" data-dismiss="modal">Cancel</button>--%>
                    </div>
                </div>

            </div>
        </div>


        <div id="div_compose" class="col-md-12">
            <div class="portlet light bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <span runat="server" class="caption-subject font-blue sbold uppercase"></span>
                    </div>
                    <div class="actions">

                       <%-- <a data-toggle="modal" href="#modalRequirements" id="btn_addnew" class="btn default btn-lg">
                            <i class="fa fa-plus"></i>Assign

                        </a>--%>
                    </div>
                </div>
                <div id="div_order" runat="server" class="portlet-body">
                    <div class="row">
                        <div>
                            <h3>Order Header Information </h3>
                            <hr style="border-width: 3px; border-color: #939898;">
                            <div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions">Order Date:</label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblOrderDate" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions">Order End Date:</label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblEndDate" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <label class="form-actions">Customer Name:</label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="LblCustomerName" runat="server"></label>
                        </div>
                        <div class="col-md-5">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions">Customer Address:</label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblAd1" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions"></label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblAd2" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions"></label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblAd3" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions">Order Status:</label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblStatus" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label class="form-actions">Number of Items:</label>
                        </div>
                        <div class="col-md-5">
                            <label class="form-actions" id="lblCountItems" runat="server"></label>
                        </div>
                        <div class="col-md-4">
                        </div>

                    </div>
                    <div class="row">
                        <hr style="border-width: 3px; border-color: #939898;">
                    </div>
                    <div class="row">
                        <div>
                            <h3>Order Details </h3>
                            <hr style="border-width: 3px; border-color: #939898;">
                        </div>
                    </div>
                    <div runat="server" id="orderBody">
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="headContent" runat="server">
  <%--  <script type="text/javascript">
        function assignUser(e) {
            var param = {
                "orderID": $("#<%=headerID.ClientID%>").val(),
                "username": $(e).attr("id")  
            }

            $.ajax(
                    {
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //data: "wrkcenter=workCenter&wrkCenterGroup=workCenterGroup&section=section&plantID=plant&primaryField=primayField",
                        data: JSON.stringify(param),
                        dataType: "json",
                        url: "../../../WebServices/BackendWebservice.asmx/AssignUsers",
                        success: function (result) {
                            toastr.info("Done!...");
                            window.location.replace("ViewOrders.aspx");

                        }
                    }

                    );
        }
    </script>--%>
</asp:Content>
