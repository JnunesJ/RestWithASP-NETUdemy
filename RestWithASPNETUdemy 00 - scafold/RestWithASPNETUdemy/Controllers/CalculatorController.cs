using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        
        // GET api/values/sum/5/5
        [HttpGet("sum/{firstNumber}/{secundNumber}")]
        public ActionResult<string> Sum(String firstNumber, String secundNumber)
        {
            if ( isNumeric(firstNumber) && isNumeric(secundNumber))
            {

                var soma = convertToDecimal(firstNumber) + convertToDecimal(secundNumber);
                return Ok(soma.ToString());
            }

            return BadRequest("Verifique se informou valores válidos!");
        }

        // GET api/values/subtrair/5/5
        [HttpGet("subtrair/{primeiroNumero}/{segundoNumero}")]
        public ActionResult<string> Subtrair(String primeiroNumero, String segundoNumero)
        {
            if (isNumeric(primeiroNumero) && isNumeric(segundoNumero))
            {

                var subtracao = convertToDecimal(primeiroNumero) - convertToDecimal(segundoNumero);
                return Ok(subtracao.ToString());
            }

            return BadRequest("Verifique se informou valores válidos!");
        }

        private decimal convertToDecimal(string Number)
        {
            decimal valorDecimal;
            if (decimal.TryParse(Number, out valorDecimal))
            {
                return valorDecimal;
            }
            return 0;
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
