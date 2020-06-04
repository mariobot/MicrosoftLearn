using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrintFramerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceFrameController : ControllerBase
    {
         /// <summary>
        /// Retorna el precio de un marco basandose en sus dimensiones.
        /// </summary>
        /// <param name="Height">El alto del marco.</param>
        /// <param name="Width">El ancho del marcho.</param>
        /// <returns>.</returns>
        /// <remarks>
        /// Peticion de ejemplo:
        ///
        ///     Get /api/priceframe/5/10
        ///
        /// </remarks>
        /// <response code="200">El precio, en dolares, del marco de la imagen.</response>
        /// <response code="400">La API retorna 'not valid' si el total del tamaño de marco (El perimetro del marco) es menor que 20 pulgadas y mayor que 1000 pulgadas.</response>
        [HttpGet("{Height}/{Width}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<string> GetPrice(string Height, string Width)
        {
            string result;
            result = CalculatePrice(Double.Parse(Height), Double.Parse(Width));
            if (result == "not valid")
            {
                return BadRequest(result);
            }
            else
            {
                return Ok($"The cost of a {Height}x{Width} frame is ${result}");
            }
        }

        private string CalculatePrice(double height,double width)
        {
            double perimeter;
            perimeter = (2*height) + (2*width);

            if ((perimeter > 20.00 ) &&  (perimeter <= 50.00))
            {
                return "20.00";
            }
            if ((perimeter > 50.00) && (perimeter <= 100.00))
            {
                return "50.00";
            }
            if ((perimeter > 100.00) && (perimeter <= 1000.00))
            {
                return "100.00";
            }
            return  "not valid";
        }
    }
}
