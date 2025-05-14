using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using vacancyApiNET8.Models;
using vacancyApiNET8.Models.DTOs;
using Microsoft.AspNetCore.Cors;

namespace vacancyApiNET8.Interfaces
{
    public interface ICatContractType
    {
        [HttpGet]
        public Task<IActionResult> ReadList();
    }
}
