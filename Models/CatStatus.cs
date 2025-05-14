using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vacancyApiNET8.Models;

public partial class CatStatus
{
    public int IdCatStatus { get; set; }

    public string? Notation { get; set; }

    public int? InsertUser { get; set; }

    public DateOnly? InsertDate { get; set; }

    public int? UpdateUser { get; set; }

    public DateOnly? UpdateDate { get; set; }
    [JsonIgnore]
    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();
}
