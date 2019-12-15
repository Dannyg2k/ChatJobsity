<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatJobsity._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-sm-4">
            <div id="OnlineUserCounts"></div>
            <br />
            <ul id="userList">

            </ul>
        </div>
          <div class="col-sm-6">
              Message <br />

                <ul id="messageArea">

            </ul>
          </div>
        

    </div>
    <h4>Input Message</h4>
    <div class="row">
       <div class="col-sm-6">
           <asp:TextBox ID="userMessage" runat="server" Height="104px" TextMode="MultiLine" Width="516px"></asp:TextBox>
       </div>
         <div class="col-sm-6">
            <h5> Last Time Users Disconnected </h5><br />

                <ul id="disconnectList" runat="server"></ul>
       </div>
    </div>
    

    <div class="row">
       <div class="col-sm-6">
           <input id="btnSendMessage" type="button"  CssClass="btn btn-block btn-primary btn-flat" value="Send" />
        
       </div>
    </div>
    <br />
    <h4></h4>

    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src="signalr/hubs"></script>

    <script type="text/javascript" >
      
        $(function () {
            var chat = $.connection.chatHub;
            var username = '<%: Context.User.Identity.GetUserName()  %>';
            //  alert(username);
            chat.client.updateUsers = function (userCount, userList,disco) {
                $("#OnlineUserCounts").text('Online Users : ' + userCount);
                $("#userList").empty();
                userList.forEach(function (username) {
                    $("#userList").append('<li>' + username + '</li>');
                 }
                );

                $("#<%= disconnectList.ClientID %>").empty();
                disco.forEach(function (username) {
                    $("#<%= disconnectList.ClientID %>").append('<li>' + username + '</li>');
                }
                );

            };

            chat.client.SendData = function (username, message) {

                $("#messageArea").append('<li><strong>' + username + ':</strong> ' + message + '</li>');
                
            };

            $("#btnSendMessage").click(function () {
                var message = $("#<%= userMessage.ClientID %>").val();
               // alert(message);
                chat.server.send(message);
                $("#<%= userMessage.ClientID %>").val("");
            }
            );

            $.connection.hub.start().done(function () {
                chat.server.connect(username);
            });


        });

    </script>
</asp:Content>
