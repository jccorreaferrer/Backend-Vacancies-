using Microsoft.AspNetCore.Mvc;

namespace vacancyApiNET8.Interfaces
{
    public interface ICatalog
    {
        [HttpGet]
        public Task<IActionResult> ReadList();
    }
}
