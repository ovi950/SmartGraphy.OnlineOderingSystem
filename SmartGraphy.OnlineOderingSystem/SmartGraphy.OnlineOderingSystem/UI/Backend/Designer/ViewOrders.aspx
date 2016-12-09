<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/Backend/Site1.Master" CodeBehind="ViewOrders.aspx.cs" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Designer.ViewOrders" %>

<%--Designer--%>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        <small>All Orders</small>
    </h3>

    <div id="div_compose" class="col-md-12">
        <div class="portlet light bordered">
            <div class="portlet-title">
                <div class="caption">
                    <span runat="server" class="caption-subject font-blue sbold uppercase">Product Categories</span>
                </div>
                <div class="actions">

                    <%--<a data-toggle="modal" href="#modal_cat" id="btn_addnew" class="btn default btn-lg">
                        <i class="fa fa-plus"></i>New Category

                    </a>--%>
                </div>
            </div>
            <div id="div_composeArea" class="portlet-body">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th>Customer Name</th>
                            <th>Contact No</th>
                            <th>Order Date/Time</th>
                            <th>Status</th>
                            <th></th>

                        </tr>
                    </thead>
                    <tbody id="tbl_order" runat="server">
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript">
        $("document").ready(function () {
            
        });
    </script>
</asp:Content>




