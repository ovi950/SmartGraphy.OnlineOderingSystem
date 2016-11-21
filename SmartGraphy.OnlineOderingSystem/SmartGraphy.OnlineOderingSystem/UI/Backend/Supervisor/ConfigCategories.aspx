<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigCategories.aspx.cs" MasterPageFile="~/UI/Backend/Site1.Master" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Supervisor.ConfigCategories" %>

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
        <small>Product Categories</small>
    </h3>
    <form runat="server" id="catForm">
        <div class="modal fade" id="modal_cat" style="display: none;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content c-square">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btn_close1">
                            <span aria-hidden="true">×</span>
                        </button>

                        <h4 id="lbl_style" class="modal-title bold uppercase font-grey-cascade">Category Details</h4>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Category Name</label>
                            </div>
                            <div class="col-md-5">
                                <input type="text" id="txt_catName" class="form-control" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Product Image</label>
                            </div>
                            <div class="col-md-5">
                                <input type="file" id="file_Category" class="form-control" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer raw">
                        <div class="col-lg-7">

                            <asp:Button Type="button" ID="btn_update" CssClass="btn light blue btn-outline" OnClick="btn_update_Click" runat="server" Text="Update"></asp:Button>

                            <asp:Button ID="btnAddCat" CssClass="btn light blue btn-outline" runat="server" OnClick="btn_add_Click" Text="Add" />
                            <button type="button" id="btn_cancel" class="btn dark btn-outline" data-dismiss="modal">Cancel</button>
                            <%--<asp:Button runat="server" ID="btn_confirm" class="btn green" Text="Confirm" />--%>
                        </div>

                        <span class="col-lg-5"></span>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div id="div_compose" class="col-md-12">
        <div class="portlet light bordered">
            <div class="portlet-title">
                <div class="caption">
                    <span runat="server" class="caption-subject font-blue sbold uppercase">Product Categories</span>
                </div>
                <div class="actions">

                    <a data-toggle="modal" href="#modal_cat" id="btn_addnew" class="btn default btn-lg">
                        <i class="fa fa-plus"></i>New Category

                    </a>
                </div>
            </div>
            <div id="div_composeArea" class="portlet-body">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th>Category Name</th>
                            <th>Is Enabled ?</th>
                            <th>Created By</th>
                            <th>Created On</th>
                            <th>Last Updated By</th>
                            <th>Last Updated On</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="tbl_cat" runat="server">
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript">
        $("document").ready(function () {
            $("#btn_addnew").click(function () {
                $("#<%=btnAddCat.ClientID%>").show();
                $("#<%=btn_update.ClientID%>").hide();
                $("#<%=txt_catName.ClientID%>").val("");
            });


        });

        function editCategory(e) {
            $("#<%=btnAddCat.ClientID%>").hide();
            $("#<%=btn_update.ClientID%>").show();
            $("#<%=txt_catName.ClientID%>").val($(e).attr("data-name"));
            $("#<%=hdnID.ClientID%>").val($(e).attr("id"));
            $("#modal_cat").modal("show");
        }

    </script>
</asp:Content>
