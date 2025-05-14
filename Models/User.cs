using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vacancyApiNET8.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? InsertUser { get; set; }

    public DateOnly? InsertDate { get; set; }

    public int? UpdateUser { get; set; }

    public DateOnly? UpdateDate { get; set; }
    [JsonIgnore]
    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
