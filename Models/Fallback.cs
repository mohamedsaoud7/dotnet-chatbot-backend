using System;
using System.Collections.Generic;

namespace chatbot_backend.Models;

public partial class Fallback
{
    public int Id { get; set; }

    public string UserMessage { get; set; } = null!;

    public double Confidence { get; set; }

    public string IntentRanking { get; set; } = null!;

    public DateTime Timestamp { get; set; }
}
