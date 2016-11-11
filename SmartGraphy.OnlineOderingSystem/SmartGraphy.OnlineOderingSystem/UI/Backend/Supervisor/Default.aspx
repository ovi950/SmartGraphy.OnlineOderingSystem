﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/UI/Backend/Site1.Master" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Supervisor.default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        <a href="Default.aspx">HOME</a>
        <small>dashboard & statistics</small>
    </h3>

    <div class="portlet light bordered">
        <div class="portlet-title">
            <div class="caption">
                <span class="caption-subject font-blue sbold uppercase">Today's Summary</span>
            </div>

        </div>
        <div class="portlet-body">
            <div class="row">

                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2 ">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-green-sharp">
                                        <span data-counter="counterup" data-value="7800">0</span>
                                        <small class="font-green-sharp">$</small>
                                    </h3>
                                    <small>TOTAL PROFIT</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-pie-chart"></i>
                                </div>
                            </div>
                            <div class="progress-info">
                                <div class="progress">
                                    <span style="width: 76%;" class="progress-bar progress-bar-success green-sharp">
                                        <span class="sr-only">76% progress</span>
                                    </span>
                                </div>
                                <div class="status">
                                    <div class="status-title">progress </div>
                                    <div class="status-number">76% </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2 ">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-red-haze">
                                        <span data-counter="counterup" data-value="1349">0</span>
                                    </h3>
                                    <small>NEW FEEDBACKS</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-like"></i>
                                </div>
                            </div>
                            <div class="progress-info">
                                <div class="progress">
                                    <span style="width: 85%;" class="progress-bar progress-bar-success red-haze">
                                        <span class="sr-only">85% change</span>
                                    </span>
                                </div>
                                <div class="status">
                                    <div class="status-title">change </div>
                                    <div class="status-number">85% </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2 ">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-blue-sharp">
                                        <span data-counter="counterup" data-value="567"></span>
                                    </h3>
                                    <small>NEW ORDERS</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-basket"></i>
                                </div>
                            </div>
                            <div class="progress-info">
                                <div class="progress">
                                    <span style="width: 45%;" class="progress-bar progress-bar-success blue-sharp">
                                        <span class="sr-only">45% grow</span>
                                    </span>
                                </div>
                                <div class="status">
                                    <div class="status-title">grow </div>
                                    <div class="status-number">45% </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <div class="dashboard-stat2 ">
                            <div class="display">
                                <div class="number">
                                    <h3 class="font-purple-soft">
                                        <span data-counter="counterup" data-value="276"></span>
                                    </h3>
                                    <small>NEW USERS</small>
                                </div>
                                <div class="icon">
                                    <i class="icon-user"></i>
                                </div>
                            </div>
                            <div class="progress-info">
                                <div class="progress">
                                    <span style="width: 57%;" class="progress-bar progress-bar-success purple-soft">
                                        <span class="sr-only">56% change</span>
                                    </span>
                                </div>
                                <div class="status">
                                    <div class="status-title">change </div>
                                    <div class="status-number">57% </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>

</asp:Content>

