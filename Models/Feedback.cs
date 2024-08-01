using System;
using System.Collections.Generic;

namespace chatbot_backend.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public string? Label { get; set; }

    public double? Score { get; set; }
}
