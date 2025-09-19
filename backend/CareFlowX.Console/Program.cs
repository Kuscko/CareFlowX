using System.Net.Http.Json;

Console.WriteLine("CareFlowX.Console starting nightly job...");

// Get API base URL from environment variable or use default
var api = Environment.GetEnvironmentVariable("API_BASE") ?? "http://localhost:5175";

// Create HttpClient with base address
var client = new HttpClient { BaseAddress = new Uri(api) };

// Fetch all referrals from the API
var list = await client.GetFromJsonAsync<List<Referral>>("/api/referrals") ?? new();

// Update all referrals with status "New" to "InReview"
foreach (var r in list.Where(x => x.Status.ToLower() == "new"))
{
    var updated = r with { Status = "InReview" };
    await client.PutAsJsonAsync($"/api/referrals/{r.Id}", updated);
    Console.WriteLine($"Updated referral {r.Id} status to InReview");
}

public record Referral(
    int Id,
    string PatientName,
    string Provider,
    string Status,
    string? Notes,
    DateTime DateCreated
);