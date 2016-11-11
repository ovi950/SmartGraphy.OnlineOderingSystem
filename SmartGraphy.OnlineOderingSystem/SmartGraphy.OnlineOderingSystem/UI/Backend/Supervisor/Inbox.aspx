<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" MasterPageFile="~/UI/Backend/Site1.Master" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Supervisor.Inbox" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<%--    <link href="../../../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />--%>
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

    <h3 class="page-title">Home
                       
        <small>Messaging</small>
    </h3>
    <input type="hidden" id="reciever" />
    <input type="hidden" id="title" />
    <div class="modal fade" id="modal_viewmsg" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content c-square">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btn_close2">
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


    <div class="modal fade" id="modal_reply" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content c-square">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btn_close1">
                        <span aria-hidden="true">X</span>
                    </button>

                    <h4 class="modal-title bold uppercase font-grey-cascade">Message</h4>
                </div>
                <div class="modal-body">
                    <div class="portlet-body">

                        <div class="portlet light portlet-fit portlet-form bordered">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class=" icon-layers font-red"></i>
                                    <span class="caption-subject font-red sbold uppercase"></span>
                                </div>

                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <textarea id="div_replyContent" runat="server" class="form-control">

                                    </textarea>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btn_sendReply" class="btn dark btn-outline" data-dismiss="modal">Send!</button>
                        <button type="button" id="btn_cancelRep" class="btn dark btn-outline" data-dismiss="modal">close</button>
                        <%--<asp:Button runat="server" ID="btn_confirm" class="btn green" Text="Confirm" />--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->
    <input type="hidden" id="sender" />
    <input type="hidden" id="user" runat="server" />
    <div class="inbox">
        <div class="row">
            <div class="col-md-2">
                <div class="inbox-sidebar">
                    <a id="btn_compose" data-title="Compose" class="btn red compose-btn btn-block" href="#">
                        <i class="fa fa-edit"></i>Compose </a>
                    <ul class="inbox-nav">

                        <li>
                            <a href="#" id="userInbox" onclick="loadInbox();">Inbox</a>
                        </li>
                        <li>
                            <a href="#" onclick="loadSentItems();" id="sentItems">Sent Messagess </a>
                        </li>

                    </ul>
                    <ul class="inbox-contacts">
                    </ul>
                </div>
            </div>
            <div id="div_inbox" class="col-md-10">
                <div class="portlet light bordered">
                    <div class="portlet-title">
                        <div class="caption">
                            <span runat="server" id="div_caption" class="caption-subject font-blue sbold uppercase">Inbox</span>
                        </div>

                    </div>
                    <div id="div_msgArea" class="portlet-body">
                        <table class="table table-striped table-hover table-bordered" id="tbl_user">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Title</th>
                                    <th id="th_info">From</th>
                                    <th>DateTime</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_msgs" runat="server">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div id="div_compose" class="col-md-10">
                <div class="portlet light bordered">
                    <div class="portlet-title">
                        <div class="caption">
                            <span runat="server" class="caption-subject font-blue sbold uppercase">Compose</span>
                        </div>

                    </div>
                    <div id="div_composeArea" class="portlet-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="note note-info row">
                                    <div class="row">
                                        <span class="col-md-1"></span>
                                        <label class="form-actions col-md-4">TO</label>
                                        <div class="col-md-6">
                                            <select id="ddl_to" class="form-actions ">
                                                <option value="1">User</option>
                                                <option value="2">Group</option>
                                            </select>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row" id="div_selectUser">
                                        <span class="col-md-1"></span>
                                        <div class="col-md-11">
                                            <select id="ddl_users" runat="server" class="form-action">
                                            </select>
                                        </div>

                                    </div>
                                    <div class="row" id="div_selectgrp" hidden="hidden">
                                        <span class="col-md-1"></span>
                                        <div class="col-md-11">
                                            <select id="ddl_group" runat="server" class="form-action">
                                                <option value="admin">Admin</option>
                                                <option value="admin">Supervisors</option>
                                                <option value="admin">GraphicDesigners</option>
                                            </select>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="note note-info row">
                            <div class="row">
                                <span class="col-md-1"></span>
                                <div class="col-md-1">
                                    <label class="form-actions">Title</label>
                                </div>
                                <div class="col-md-7">
                                    <input type="text" id="txt_newmsgtitle" class="form-control" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <textarea style="margin: 0px -18.2375px 0px 0px; height: 194px; width: 1127px;" class="form-control" id="txt_newmsgcontent"></textarea>
                                </div>
                            </div>
                            <br />
                            <div class="row">

                                <div class="col-md-2">
                                    <button id="btn_sendnewmsg" onclick="sendNewMsg();" class="bg-blue">Send</button>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="headContent" runat="server">
    <script>
        var table = null;
        $("document").ready(function () {

            $("#div_compose").hide();

            table = $("#tbl_user").DataTable({
                "oLanguage": { "sLengthMenu": "Number of messages per page: \_MENU_" },
                "bSort": false,
            });
            $("#<%=ddl_users.ClientID%>").val("");
            $("#<%=ddl_group.ClientID%>").val("");
            $("#<%=ddl_users.ClientID%>").select2({
                multiple: "multiple",
                placeholder: "Select Users",
                allowClear: true
            });
            $("#<%=ddl_group.ClientID%>").select2({
                multiple: "multiple",
                placeholder: "Select user groups",
                allowClear: true
            });
            $("#btn_sendReply").click(function () {


                var params = {
                    "reciever": $("#reciever").val(),
                    "title": "RE: " + $("#title").val(),
                    "content": $("#<%=div_replyContent.ClientID%>").val()
                };
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "inbox.aspx/sendMessage",
                    data: JSON.stringify(params),
                    dataType: "json",
                    success: function (result) {


                    }
                });
            });
            $("#btn_compose").click(function () {
                loadCompose();
            });
            //$("#ddl_to").change(function () {
            //    if ($("#ddl_to").val() == 1) {
            //        $("#div_selectUser").removeProp('hidden');
            //    }

            //});
            $(document).on('change', '#ddl_to', function () {

                if ($("#ddl_to").val() == 1) {
                    $("#div_selectUser").show();
                    $("#div_selectgrp").hide();
                }
                if ($("#ddl_to").val() == 2) {
                    $("#div_selectUser").hide();
                    $("#div_selectgrp").show();
                }
            });


        });
        function showMessage(e) {
            $("btn_reply").show();
            $('#modal_viewmsg').modal('show');
            $("#div_msgcontent").text($(e).attr('data-msg'));
            $("#div_title").text($(e).attr('data-title'));
            $("#sender").val($(e).attr('data-sender'));
            alert($(e).attr('id'));
            $("#reciever").val($(e).attr('data-sender'));
            $("#title").val($(e).attr('data-title'));
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Inbox.aspx/ChangeMsgStatus",
                data: JSON.stringify({
                    "msgNo": $(e).attr('id')
                }),
                dataType: "json",
                success: function (result) {
                    loadInbox();
                }

            });
        }

        function showSentMessage(e) {

            $('#modal_viewmsg').modal('show');
            $("#div_msgcontent").text($(e).attr('data-msg'));
            $("#div_title").text($(e).attr('data-title'));
            $("#sender").val($(e).attr('data-sender'));
            alert($("#sender").val());
            $("#reciever").val($(e).attr('data-sender'));
            $("#title").val($(e).attr('data-title'));

        }

        function replyMessage() {
            $("#modal_reply").modal('show');
        }
        function loadInbox() {
            $("#div_inbox").show();
            $("#btn_reply").show();
            $("#div_compose").hide();

            if (table != null) {
                table.destroy();
            }
            table = $("#tbl_user").DataTable({
                "oLanguage": { "sLengthMenu": "Number of messages per page: \_MENU_" },
                "bSort": false,
            });
            $("#th_info").html("From");
            var param = { "option": 1 };
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../../../WebServices/BackendWebservice.asmx/LoadUserMessages",
                data: JSON.stringify(param),
                dataType: "json",
                success: function (result) {

                    var result1 = JSON.parse(result.d);
                    $("#<%=tbl_msgs.ClientID%>").html(result1);
                    $("#<%=div_caption.ClientID%>").html("Inbox");
                },

            });
        }
        function loadSentItems() {
            try{
                $("#div_compose").hide();
                $("#div_inbox").show();
                $("#btn_reply").hide();
                if (table != null) {
                    table.destroy();
                }

                table = $("#tbl_user").DataTable({
                    "oLanguage": { "sLengthMenu": "Number of messages per page: \_MENU_" },
                    "bSort": false,
                });
                $("#th_info").html("To");
                var param = { "option": 2 };
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../../../WebServices/BackendWebservice.asmx/LoadUserMessages",
                    data: JSON.stringify(param),
                    dataType: "json",
                    success: function (result) {
                        var result1 = JSON.parse(result.d);
                        $("#<%=tbl_msgs.ClientID%>").html(result1);
                        $("#<%=div_caption.ClientID%>").html("Sent Messages");

                    }
                });
            }
            catch(e){}
        }
        function loadCompose() {
            $("#div_compose").show();
            $("#div_inbox").hide();
        }

        function sendNewMsg() {
            // alert( $("#<%=ddl_users.ClientID%>").val());
            // var data = $("#<%=ddl_users.ClientID%>").val();
            //string[] recievers, string title, string message
            var param = {
                "recievers": $("#<%=ddl_users.ClientID%>").val(),
                "title": $("#txt_newmsgtitle").val(),
                "message": $("#txt_newmsgcontent").val()
            };
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../../../WebServices/BackendWebservice.asmx/SendMessagesToUsers",
                data: JSON.stringify(param),
                dataType: "json",
                success: function () {
                    toastr.success("Message sent", "Alert");
                }
            });
        }

    </script>
</asp:Content>