<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigCategories.aspx.cs" MasterPageFile="~/UI/Backend/Site1.Master" Inherits="SmartGraphy.OnlineOderingSystem.UI.Backend.Supervisor.ConfigCategories" %>

<asp:content id="content1" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <div id="div_compose" class="col-md-10">
                <div class="portlet light bordered">
                    <div class="portlet-title">
                        <div class="caption">
                            <span runat="server" class="caption-subject font-blue sbold uppercase">Product Categories</span>
                        </div>

                    </div>
                    <div id="div_composeArea" class="portlet-body">
                        <table class="table table-striped table-hover table-bordered" >
                            <thead>
                                <tr>
                                    <th>Category Name</th>
                                    <th>Is Enabled ?</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="tbl_cat" runat="server">
                                
                            </tbody>
                        </table>
                    </div>
                </div>
        </div>
</asp:content>
