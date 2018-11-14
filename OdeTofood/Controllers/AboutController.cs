using Microsoft.AspNetCore.Mvc;

namespace OdeTofood.Controllers
{
    //route attributes
    
    //request /about
    //[Route("about")]
    [Route("company/[controller]/[action]")] //controller token
    public class AboutController
    {
        //if its empty its like a default
        //[Route("")]
        public string Phone()
        {
            return "1+555+555+5555";
        }

        //[Route("address")]
        //[Route("[action]")] //action token
        public string Address()
        {
            return "USA";
        }
    }
}
