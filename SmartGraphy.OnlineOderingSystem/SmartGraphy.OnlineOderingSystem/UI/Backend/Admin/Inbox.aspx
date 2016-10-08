<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/Backend/Site1.Master" CodeBehind="Inbox.aspx.cs" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Admin.Inbox" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
    <br />
    <script src="../../../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <h3 class="page-title">Home
                       
        <small>inbox</small>
    </h3>
    <!-- END PAGE TITLE-->
    <!-- END PAGE HEADER-->
    <div class="inbox">
        <div class="row">
            <div class="col-md-2">
                <div class="inbox-sidebar">
                    <a href="javascript:;" data-title="Compose" class="btn red compose-btn btn-block">
                        <i class="fa fa-edit"></i>Compose </a>
                    <ul class="inbox-nav">
                        
                        <li>
                            <a href="#" id="userinbox" data-type="important" data-title="From Users">From Users </a>
                        </li>
                        <li>
                            <a href="#" id="customerinbox" data-type="sent" data-title="From Customers">From Cumtomers </a>
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
                                    <th>#</th>
                                    <th></th>

                                </tr>
                            </thead>
                            <tbody id="all_user" runat="server">
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
