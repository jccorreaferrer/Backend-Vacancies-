using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vacancyApiNET8.Models;

public partial class Vacancy
{
    public int IdVacancy { get; set; }

    public int? IdUsuario { get; set; }

    public string? Title { get; set; }

    public string? VacancyLink { get; set; }

    public string? JobPositionName { get; set; }

    public string? JobDescription { get; set; }

    public string? Company { get; set; }

    public int? IdCatContractType { get; set; }

    public int? IdCatLanguage { get; set; }

    public string? RequiredSkill { get; set; }

    public string? Salary { get; set; }

    public int? IdCatCurrency { get; set; }

    public int? IdCatColor { get; set; }

    public int? IdStatus { get; set; }

    public int? InsertUser { get; set; }

    public DateOnly? InsertDate { get; set; }

    public int? UpdateUser { get; set; }

    public DateOnly? UpdateDate { get; set; }
    [JsonIgnore]
    public virtual CatColor? IdCatColorNavigation { get; set; }
    [JsonIgnore]
    public virtual CatContractType? IdCatContractTypeNavigation { get; set; }
    [JsonIgnore]
    public virtual CatCurrency? IdCatCurrencyNavigation { get; set; }
    [JsonIgnore]
    public virtual CatLanguage? IdCatLanguageNavigation { get; set; }
    [JsonIgnore]
    public virtual Status? IdStatusNavigation { get; set; }
    [JsonIgnore]
    public virtual User? IdUsuarioNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
