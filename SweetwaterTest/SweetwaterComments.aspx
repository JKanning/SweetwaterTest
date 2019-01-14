<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SweetwaterComments.aspx.cs" Inherits="SweetwaterTest.SweetwaterComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
			Candy:</p>
		<p>
			<asp:TextBox ID="txtCandy" runat="server" Height="100px" TextMode="MultiLine" Width="950px"></asp:TextBox>
		</p>
		<p>
			&nbsp;</p>
		<p>
			Call Me / Don&#39;t Call Me:</p>
		<p>
			<asp:TextBox ID="txtCallMe" runat="server" Height="100px" TextMode="MultiLine" Width="950px"></asp:TextBox>
		</p>
		<p>
			&nbsp;</p>
		<p>
			Referred:</p>
		<p>
			<asp:TextBox ID="txtReferred" runat="server" Height="100px" TextMode="MultiLine" Width="950px"></asp:TextBox>
		</p>
		<p>
			&nbsp;</p>
		<p>
			Signature:</p>
		<p>
			<asp:TextBox ID="txtSignature" runat="server" Height="100px" TextMode="MultiLine" Width="950px"></asp:TextBox>
		</p>
		<p>
			&nbsp;</p>
		<p>
			<asp:Label ID="Label1" runat="server" Text="Display Comments"></asp:Label>
		</p>
		<p>
			<asp:TextBox ID="txtDisplay" runat="server" Height="221px" TextMode="MultiLine" Width="950px"></asp:TextBox>
		</p>
		<p>
			&nbsp;</p>
		<p>
			<asp:TextBox ID="txtTest" runat="server" Height="236px" TextMode="MultiLine" Visible="False" Width="1080px" Wrap="False"></asp:TextBox>
		</p>
        <div>
        </div>
    </form>
</body>
</html>
