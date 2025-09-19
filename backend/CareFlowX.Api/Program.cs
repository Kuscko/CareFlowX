using CareFlowX.Api.Data;
using CareFlowX.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("ai", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["AIServiceUrl"]!);
});

var app = builder.Build();

// Middleware configuration
app.UseSwagger();
app.UseSwaggerUI();

// Basic ping
app.MapGet("/", () => Results.Ok(new { service="CareFlowX.Api", status="Running", time=DateTime.UtcNow }));

// Referral endpoints & CRUD operations

// Get all referrals
app.MapGet("/api/referrals", async (AppDbContext db) =>
    Results.Ok(await db.Referrals.OrderByDescending(r => r.DateCreated).ToListAsync()));

// Get a specific referral by ID
app.MapGet("/api/referrals/{id:int}", async (int id, AppDbContext db) =>
    await db.Referrals.FindAsync(id) is Referral referral
        ? Results.Ok(referral)
        : Results.NotFound());

// Create a new referral
app.MapPost("/api/referrals", async (Referral referral, AppDbContext db) =>
{
    referral.DateCreated = DateTime.UtcNow;
    db.Referrals.Add(referral);
    await db.SaveChangesAsync();
    return Results.Created($"/api/referrals/{referral.Id}", referral);
});

// Update an existing referral
app.MapPut("/api/referrals/{id:int}", async (int id, Referral updatedReferral, AppDbContext db) =>
{
    var referral = await db.Referrals.FindAsync(id);
    if (referral is null) return Results.NotFound();
    referral.PatientName = updatedReferral.PatientName;
    referral.Provider = updatedReferral.Provider;
    referral.Status = updatedReferral.Status;
    referral.Notes = updatedReferral.Notes;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Delete a referral
app.MapDelete("/api/referrals/{id:int}", async (int id, AppDbContext db) =>
{
    var referral = await db.Referrals.FindAsync(id);
    if (referral is null) return Results.NotFound();
    db.Remove(referral);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Simple Entity Framework Report
app.MapGet("/api/report/summary", async (AppDbContext db) =>
{
    var totalReferrals = await db.Referrals.CountAsync();
    var pendingReferrals = await db.Referrals.CountAsync(r => r.Status == "Pending");
    var completedReferrals = await db.Referrals.CountAsync(r => r.Status == "Completed");
    var report = new
    {
        TotalReferrals = totalReferrals,
        PendingReferrals = pendingReferrals,
        CompletedReferrals = completedReferrals
    };
    return Results.Ok(report);
});

// AI Integration Proxy for referral analysis and summary
app.MapPost("/api/ai/summarize", async (HttpContext ctx, IHttpClientFactory hf) =>
{
    var req = await ctx.Request.ReadFromJsonAsync<object>();
    var client = hf.CreateClient("ai");
    var resp = await client.PostAsJsonAsync("/ai/summarize", req!);
    var payload = await resp.Content.ReadFromJsonAsync<object>();
    return Results.Ok(payload);
});

app.Run();
