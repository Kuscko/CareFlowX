# What is this?

CareFlowX is a referral management system prototype designed to demonstrate end-to-end capabilities using both legacy & modern technologies. It’s built to show what I can do—from intake forms to AI, from UI to CI/CD pipelines.

## Run instructions

**API**: dotnet run (note the port; set vite proxy to match)

**AI**: uvicorn ai.app:app --reload --port 8000

**Frontend**: npm run dev

**Legacy**: run WebForms site (IIS Express). Submit a referral.

**Console job**: API_BASE=http://localhost:5xxx dotnet run --project CareFlowX.Console

**Swagger**: show endpoints. http://localhost:5xxx/swagger


## Why did I do things this way?

**Legacy & Modern side-by-side**: shows I can maintain and modernize safely.

**MVVM in Aurelia**: shows clean separation of concerns for testable UIs.

**SQL + stored proc**: flexibility (ORM for CRUD, procs for perf-sensitive reports).

**AI as a sidecar**: isolates risk, lets me iterate without touching core runtime.

**Console job**: demonstrates background workflows and system integration.

**CI**: production habits even for demos—repeatable builds, easy to extend to deploy.
