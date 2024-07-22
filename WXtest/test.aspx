<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WXtest.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
          body{height:100%;background-color:#000000;}
        #main{
            min-height: 54em;
            max-width: 98%;
            border: 0px solid orange;
            background: ForestGreen;
            margin: 0 auto;
            margin-top: 1%;
        }
         .six {
             display: flex;
             font-size: 4.5rem;
             justify-content: space-around;
             margin-top:1em;
          }
          .six1 {
             display: initial;
             flex-direction: column;
             justify-content: space-around;
             align-items: end;
             line-height: 8rem;
           }
           .small {
             border-radius: 5px;
           }
         }
    </style>
</head>
<body>
    <form id="form1" style="background-color:black;color:white;" runat="server">
           
    <div style="background-color:black;margin: 0 auto; width: 100%;height:100%" >&nbsp;
        <div style="border: solid 1px;max-width: 90%; margin: 0 auto; color: grey;">
        <div id="main"  runat="server">
             <br />
        <div >
          
        </div>
        <br />
        <br />
        </div>
          <div style="text-align:center;margin-top:2em;">
              <label style="text-align: center;font-size: 3.8rem;color: #fb895e;" id="PassNo" runat="server">
              </label>
          </div>
          <br />
        </div>
        <div style="min-height:300px;"> 
            <div class="big six">
                <div class="six1">
                    <div class="small">
                        Date&nbsp&nbsp&nbsp:
                    </div>
                    <div class="small">
                        ID&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:
                    </div>
                    <div class="small">
                        Name:
                    </div>
                    <div class="small">
                       <label id="NameV" runat="server"></label>
                    </div>
                    <div class="small">
                </div>
                </div>
                <div class="six1">
                    <div class="small">
                        <label id="DataS" runat="server"></label>
                    </div>
                    <div class="small">
                        <label id="EmpNo" runat="server"></label>
                    </div>
                    <div class="small">
                    </div>
                    <div class="small"></div>
                </div>
                
        </div>
     </div>
        <br />
        <div id="Tips" style="font-size:2.2rem;line-height: 1.0em;white-space:pre-wrap;border:solid 1px #f00;border-radius:1rem;padding:1rem;" runat="server"></div>
        <br />
    </div>
    </form>
 
</body>
</html>
