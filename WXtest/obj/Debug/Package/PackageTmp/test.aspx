<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WXtest.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
        #main{
            width: 400px;
            border: 2px solid orange;
            padding: 5px;
            background: rgba(120,60,30,0.2);
            margin-right: auto;
            margin-left: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    <div><asp:Image ImageUrl="~/20210421175833.png" ID="Image1" runat="server" /></div>
    <div>
        <br />
        <label style="text-align:center;font-size:xx-large" id="DataS" runat="server"  ></label>
        <br />
         <label style="text-align:center;" id="EmpNo" runat="server" ></label>
        <br />
        <label style="text-align:center; overflow: auto;" id="pass" >綠色= Pass (ผ่าน)</label>
        <br />
        <label style="text-align:center;" id="nopass">紅色= Not Pass (ไม่ผ่าน)</label>
    </div>
        </div>
    </form>
</body>
</html>
