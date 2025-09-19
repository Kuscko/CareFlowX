<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Legacy Referral Intake</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Legacy Referral Intake (WebForms)</h2>
        <asp:TextBox ID="txtPatient" runat="server" Placeholder="Patient Name"></asp:TextBox>
        <asp:TextBox ID="txtProvider" runat="server" Placeholder="Provider"></asp:TextBox>
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="3" Placeholder="Notes"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="SubmitReferral" />
        <asp:Label ID="lblResult" runat="server" />
    </form>
</body>
</html>
