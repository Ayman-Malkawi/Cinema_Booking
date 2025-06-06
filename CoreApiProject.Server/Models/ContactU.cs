﻿using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class ContactU
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime? SubmissionDate { get; set; }
}
