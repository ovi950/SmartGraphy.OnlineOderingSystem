<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/Backend/Site1.Master" CodeBehind="Inbox.aspx.cs" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Admin.Inbox" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
    <br />
    <script src="../../../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <h3 class="page-title">Home
                       
        <small>inbox</small>
    </h3>
    <div class="modal fade" id="modal_viewmsg" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content c-square">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btn_close1">
                        <span aria-hidden="true">×</span>
                    </button>

                    <h4 id="lbl_style" class="modal-title bold uppercase font-grey-cascade">Message</h4>
                </div>
                <div class="modal-body">
                    <div class="portlet-body">

                        <div class="portlet light portlet-fit portlet-form bordered">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class=" icon-layers font-red"></i>
                                    <span id="div_title" class="caption-subject font-red sbold uppercase"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <textarea id="div_msgcontent" readonly="readonly" class="form-control">

                                    </textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" onclick="replyMessage();" id="btn_reply" class="btn dark btn-outline" data-dismiss="modal">Reply</button>
                        <button type="button" id="btn_cancel" class="btn dark btn-outline" data-dismiss="modal">close</button>
                        <%--<asp:Button runat="server" ID="btn_confirm" class="btn green" Text="Confirm" />--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->
    <input type="hidden" id="sender" />
    <div class="inbox">
        <div class="row">
            <div class="col-md-2">
                <div class="inbox-sidebar">
                    <a href="javascript:;" data-title="Compose" class="btn red compose-btn btn-block">
                        <i class="fa fa-edit"></i>Compose </a>
                    <ul class="inbox-nav">

                        <li>
                            <a href="#" id="userinbox" data-type="important" data-title="Inbox">Inbox</a>
                        </li>
                        <li>
                            <a href="#" id="customerinbox" data-type="sent" data-title="Sent Messages">Sent Messagess </a>
                        </li>

                    </ul>
                    <ul class="inbox-contacts">
                    </ul>
                </div>
            </div>
            <div class="col-md-10">
                <div class="portlet light bordered">
                    <div class="portlet-title">
                        <div class="caption">
                            <span class="caption-subject font-blue sbold uppercase">Inbox</span>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <table class="table table-striped table-hover table-bordered" id="tbl_user">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Title</th>
                                    <th>From</th>
                                    <th>DateTime</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_msgs" runat="server">
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="headContent" runat="server">
    <script>
        function showMessage(e) {
            $('#modal_viewmsg').modal('show');
            $("#div_msgcontent").text($(e).attr('data-msg'));
            $("#div_title").text($(e).attr('data-title'));
            $("#sender").val($(e).attr('data-sender'));
            alert($("#sender").val());
        }
        function replyMessage() {

        }
    </script>
</asp:Content>
