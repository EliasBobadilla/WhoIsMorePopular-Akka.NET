using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhoIsMorePopular.Common;

namespace WhoIsMorePopular.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorActorInstance CalculatorActor;

        public CalculatorController(ICalculatorActorInstance calculatorActor)
        {
            CalculatorActor = calculatorActor;
        }

        [HttpGet("{x}/{y}")]
        public async Task<double> Sum(double x, double y)
        {
            AnswerMessage answer = null;
            for (var i = 0; i < 10; i++)
            {
                answer  = await CalculatorActor.Sum(new AddMessage(x, y));
            }
            return answer.Value;
        }
    }
}