using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6API_.Controllers
{
   [Route("api/[controller]/[action]")]
   [ApiController]
   public class ValuesController : ControllerBase
   {
      //[Route("[action]")]
      [HttpGet]
      public string GetName()
      {
         return "Test";
      }

      //[Route("[action]")]
      [HttpGet]
      public string GetFullName()
      {
         return "Mr Robot";
      }
   }
}