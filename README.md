API: dotnet run (note the port; set vite proxy to match)

AI: uvicorn ai.app:app --reload --port 8000

Frontend: npm run dev

Legacy: run WebForms site (IIS Express). Submit a referral.

Console job: API_BASE=http://localhost:5xxx dotnet run --project CareFlowX.Console

Swagger: show endpoints. http://localhost:5xxx/swagger
