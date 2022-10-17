using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteDAL.CONTRATOS;
using TransporteModel.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WbApiEmpleado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        #region Properties
        private readonly IEmpleado _empleado;
   
        #endregion

        #region Constructor
        public EmpleadosController( IEmpleado empleado)
        {
            try
            {
                _empleado = empleado;

            }
            catch (Exception ex)
            {
                //ex.Message("error");
            }
        }
        #endregion



        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public  ActionResult<Empleado> GetEmpleado(int id)
        {
            var categoria =  _empleado.GetAllEmpleadoId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }


        // POST api/<EmpleadosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
