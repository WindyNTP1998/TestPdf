using Microsoft.AspNetCore.Mvc;

namespace TestPDF.Controllers;

[ApiController]
[Route("[controller]")]
public class PdfController : Controller
{
    // GET
    [HttpGet(Name = "PdfExport")]
    public ActionResult Get()
    {
        return Ok();    
    }
}