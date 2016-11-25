<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigTemplates.aspx.cs" MasterPageFile="~/UI/Backend/Site1.Master" Inherits="SmartGraphy.OnlineOderingSystem.UI.Customer.ConfigTemplates" %>

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
    <form runat="server" id="catForm" novalidate="novalidate">
        <div id="modalRequirements" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Set Requirements</h4>
                    </div>

                    <div class="modal-body">
                        <div class="row" id="div_requirements">

                            <div class="row">
                                <span class="col-md-1"></span>
                                <div class="col-md-2">
                                    <label class="form-actions">select Requirements</label>
                                </div>
                                <br />
                                <div class="col-md-5">
                                    <select id="ddlRequirements" multiple="true" class="form-control" runat="server"></select>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">

                        <button type="button" onclick="setValues();" class="btn btn-default" data-dismiss="modal">Set</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>





        <div class="modal fade" id="modal_cat" style="display: none;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content c-square">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btn_close1">
                            <span aria-hidden="true">X</span>
                        </button>

                        <h4 id="lbl_style" class="modal-title bold uppercase font-grey-cascade">Template Details</h4>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Template Name</label>
                            </div>
                            <div class="col-md-5">
                                <input type="text" required="required" id="txt_temName" class="form-control" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Template Image</label>
                            </div>
                            <div class="col-md-5">
                                <input type="file" required="required" id="file_Template" class="form-control" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Product Category</label>
                            </div>
                            <div class="col-md-5">
                                <select id="ddlCat" class="form-control" runat="server"></select>

                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Required Days</label>
                            </div>
                            <div class="col-md-5">
                                <input type="number" id="txtRequiredDays" required="required" runat="server" class="form-control" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <span class="col-md-1"></span>
                            <div class="col-md-2">
                                <label class="form-actions">Unit Price</label>
                            </div>
                            <div class="col-md-5">
                                <input type="number" required="required" id="txtPrice" runat="server" class="form-control" />
                            </div>
                        </div>


                    </div>
                </div>
                <div class="modal-footer raw">
                    <div class="col-lg-7">

                        <asp:Button Type="button" ID="btn_update" CssClass="btn light blue btn-outline" OnClick="btn_update_Click" runat="server" Text="Update"></asp:Button>

                        <asp:Button ID="btnAddCat" CssClass="btn light blue btn-outline" runat="server" OnClick="btnAddCat_Click" Text="Add" />
                        <button type="button" id="btn_cancel" class="btn dark btn-outline" data-dismiss="modal">Cancel</button>
                        <%--<asp:Button runat="server" ID="btn_confirm" class="btn green" Text="Confirm" />--%>
                    </div>

                </div>
            </div>
        </div>

    </form>
    <div id="div_compose" class="col-md-12">
        <div class="portlet light bordered">
            <div class="portlet-title">
                <div class="caption">
                    <span runat="server" class="caption-subject font-blue sbold uppercase">Product Templates</span>
                </div>
                <div class="actions">

                    <a data-toggle="modal" href="#modal_cat" id="btn_addnew" class="btn default btn-lg">
                        <i class="fa fa-plus"></i>New template

                    </a>
                </div>
            </div>
            <div id="div_composeArea" class="portlet-body">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th>TemlateName Name</th>
                            <th>Is Enabled ?</th>
                            <th>Created On</th>
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
        var bntISVisible = false;
        $("document").ready(function () {
            $("#btn_addnew").click(function () {
                $("#<%=btnAddCat.ClientID%>").show();
                $("#<%=btn_update.ClientID%>").hide();
                $("#<%=txt_temName.ClientID%>").val("");
            });

            $("#btnNewRequirement").click(function () {
                bntISVisible = !bntISVisible;

            });
        });

        function editTemplate(e) {
            $("#<%=btnAddCat.ClientID%>").hide();
            $("#<%=btn_update.ClientID%>").show();
            $("#<%=txt_temName.ClientID%>").val($(e).attr("data-name"));
            $("#<%=txtPrice.ClientID%>").val($(e).attr("data-price"));
            $("#<%=txtRequiredDays.ClientID%>").val($(e).attr("data-days"));    
            $("#<%=hdnID.ClientID%>").val($(e).attr("id"));
            $("#modal_cat").modal("show");
        }
        function setRequirements(e) {
            var param={"templateID":$(e).attr("id")}
           
        
            

            
            var data =JSON.parse( $(e).attr("data-requirements"));
            <%--$("#<%=ddlRequirements.ClientID%>").select2({data:data});--%>
               
            
             $("#<%=ddlRequirements.ClientID%>").val(data);
            $("#<%=hdnID.ClientID%>").val($(e).attr("id"));
            $("#modalRequirements").modal("show");
        }

        function setValues() {
            var requirements = $("#<%=ddlRequirements.ClientID%>").val()
            
            var templateID=$("#<%=hdnID.ClientID%>").val();
            var param={
                "requirement":requirements,
                "templateID":templateID
            };

            $.ajax(
                   {
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       //data: "wrkcenter=workCenter&wrkCenterGroup=workCenterGroup&section=section&plantID=plant&primaryField=primayField",
                       data: JSON.stringify(param),
                       dataType: "json",
                       url: "ConfigTemplates.aspx/setRiqurements",
                       success: function (result) {
                           //var data1 = JSON.parse(result.d);
                           toastr.info("done");
                           }

                       }
                   

                   );
        }
    </script>
</asp:Content>

