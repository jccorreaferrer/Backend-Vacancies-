namespace vacancyApiNET8.Models.DTOs
{
    public class VacancyInsertDTO
    {
        public int IdVacancy { get; set; }

        //public int? IdUsuario { get; set; }

        public string? Title { get; set; }

        public string? VacancyLink { get; set; }

        public string? JobPositionName { get; set; }

        public string? JobDescription { get; set; }

        public string? Company { get; set; }

        public string? RequiredSkill { get; set; }

        public string? Salary { get; set; }

        public int? IdCatContractType { get; set; }

        public int? IdCatLanguage { get; set; }

        public int? IdCatCurrency { get; set; }

        public int? IdCatColor { get; set; }

        public int? IdNote { get; set; }

    }
}
