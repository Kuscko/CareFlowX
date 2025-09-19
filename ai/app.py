from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

class SummarizeIn(BaseModel):
    text: str
    tone: str = "clinical"

@app.post("/summarize")
async def summarize(data: SummarizeIn):
    text = (data.text or "").strip()
    if not text:
        return {"summary": "", "error": "No text provided"}
    # Use a real model later; this is good enough for a demo + "prompt eng" discussion
    return {"summary": f"Summary ({data.tone}): {text[:75]}..." if len(text) > 75 else text}
    