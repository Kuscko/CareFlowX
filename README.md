# CareFlowX

CareFlowX is a simple **referral management demo**. It shows how to connect old and new systems together using Microsoft tech, a modern frontend, and an AI helper.

---

## What it does
- **Legacy Intake (ASP.NET WebForms)**: basic form to add referrals.
- **Modern API (.NET 8 + EF Core)**: REST endpoints for referrals and reports.
- **Frontend (Aurelia + TypeScript + Bulma)**: simple dashboard for list, detail, and reports.
- **Database (SQL Server)**: one table `Referrals` and a stored procedure for counts.
- **Console Job (C#)**: simulates nightly processing.
- **AI Microservice (FastAPI)**: stub that summarizes notes.
- **CI/CD**: GitHub Actions + Azure Pipelines samples.

---

## How to run (quick start)

1. **Database**
   - Run `database/schema.sql` in SQL Server.

2. **API**
   ```bash
   cd CareFlowX.Api
   dotnet run
   ```
   Swagger: `http://localhost:5xxx/swagger`

3. **Frontend**
   ```bash
   cd careflowx-aurelia
   npm install
   npm run dev
   ```
   Browser: `http://localhost:5173`

4. **Legacy WebForms**
   - Open `CareFlowX.Legacy` in Rider (Windows) and run with IIS Express.

5. **AI Service**
   ```bash
   cd ai
   uvicorn app:app --reload --port 8000
   ```

6. **Console Job**
   ```bash
   API_BASE=http://localhost:5xxx dotnet run --project CareFlowX.Console
   ```

---

## Demo Flow
1. Add a referral in **Legacy WebForms**.
2. See it in the **Frontend dashboard** (via .NET API).
3. Edit and click **AI Summarize** to get a note summary.
4. Check **Reports** for counts by status.
5. Run **Console job** to move "New → InReview". Refresh dashboard.

---

## Why it matters
CareFlowX shows:
- I can support **legacy systems** and **modern APIs** together.
- I know **SQL Server**, **stored procs**, and **ORMs**.
- I can build a **modern SPA** with Aurelia + Bulma.
- I understand **background jobs** and **AI integration**.
- I follow **CI/CD practices**.
