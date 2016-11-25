<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/Backend/Site1.Master" CodeBehind="TemplateRequirements.aspx.cs" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Designer.TemplateRequirements" %>

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
        <small>Product Templates</small>
    </h3>

    

    <div id="modalRequirements" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <form name="test" action="TemplateRequirements.aspx" method="post" runat="server">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Requirement Details</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row" id="div_requirements">
                            <div class="row">
                                <span class="col-md-1"></span>
                                <div class="col-md-2">
                                    <label class="form-action">Requirement</label>
                                </div>
                                <div class="col-md-5">
                                    <input type="text" name="txt_requirement" id="txt_requirement" runat="server" class="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <span class="col-md-1"></span>
                                <div class="col-md-2">
                                    <label class="form-actions">Requirement Type</label>
                                </div>
                                <input type="hidden" id="hdnID" runat="server" />
                                <div class="col-md-5">
                                    <select id="ddlRequirements" runat="server" class="form-control">
                                        <option value="text">Text</option>
                                        <option value="tel">Telephone Number</option>
                                        <option value="number">Numeric</option>
                                        <option value="email">email</option>
                                        <option value="file">file</option>
                                    </select>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">

                        <asp:Button Type="button" ID="btn_update" CssClass="btn light blue btn-outline" OnClick="btn_update_Click" runat="server" Text="Update"></asp:Button>
                        <asp:Button ID="btnAddCat" CssClass="btn light blue btn-outline" runat="server" OnClick="btnAddCat_Click" Text="Add" />
                        <button type="button" id="btn_cancel" class="btn dark btn-outline" data-dismiss="modal">Cancel</button>

                    </div>
                </div>
            </form>
        </div>
    </div>





    <div id="div_compose" class="col-md-12">
        <div class="portlet light bordered">
            <div class="portlet-title">
                <div class="caption">
                    <span runat="server" class="caption-subject font-blue sbold uppercase">Product Templates</span>
                </div>
                <div class="actions">

                    <a data-toggle="modal" href="#modalRequirements" id="btn_addnew" class="btn default btn-lg">
                        <i class="fa fa-plus"></i>Add New

                    </a>
                </div>
            </div>
            <div id="div_composeArea" class="portlet-body">
                <table class="table table-striped table-hover table-bordered" id="tbl_requirement">
                    <thead>
                        <tr>
                            <th>Requirement</th>
                            <th>Requirement Type</th>
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
        var bntISVisible = false;
        $("document").ready(function () {
            $("#btn_addnew").click(function () {
                $("#<%=btnAddCat.ClientID%>").show();
                $("#<%=btn_update.ClientID%>").hide();
                $("#<%=txt_requirement.ClientID%>").val("");
            });
            $("#tbl_requirement").DataTable();
            $("#btnNewRequirement").click(function () {
                bntISVisible = !bntISVisible;

            });
        });

        function editRequirements(e) {
            $("#<%=btnAddCat.ClientID%>").hide();
            $("#<%=btn_update.ClientID%>").show();
            $("#<%=txt_requirement.ClientID%>").val($(e).attr("data-name"));
            $("#<%=hdnID.ClientID%>").val($(e).attr("id"));
            $("#modalRequirements").modal("show");
        }

    </script>
</asp:Content>

