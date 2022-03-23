using Extract_Information_SalesForce.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Extract_Information_SalesForce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesForceController : Controller
    {
        public IAnalyzeEmailService _analyzeEmailService;

        public SalesForceController(IAnalyzeEmailService analyzeEmailService)
        {
            _analyzeEmailService = analyzeEmailService;
        }

        [HttpPost]
        public IActionResult SalesRapId(test file)
        {
           var retorno =  _analyzeEmailService.ReturnIdSalesForce(file.file);
           return Ok(retorno);
        }
    }

    public struct test{
      public string file { get; set; }
    }
}
