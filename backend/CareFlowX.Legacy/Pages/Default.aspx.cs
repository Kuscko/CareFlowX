using System;
using System.Data.SqlClient;

public partial class Pages_Default : System.Web.UI.Page
{
    // This method handles the submission of a referral form.
    protected void SubmitReferral(object sender, EventArgs e)
    {
        var cs = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand("INSERT INTO Referrals (PatientName, Provider, Status, Notes, DateCreated) VALUES (@p,@pr,'New',@n, GETUTCDATE())", con))
        {
            cmd.Parameters.AddWithValue("@p", txtPatient.Text);
            cmd.Parameters.AddWithValue("@pr", txtProvider.Text);
            cmd.Parameters.AddWithValue("@n", txtNotes.Text);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        lblResult.Text = "Referral submitted.";
    }
}
