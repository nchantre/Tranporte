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
        public IEnumerable<Empleado> Get()
        {
            var empleado = _empleado.GetAllEmpleado();

            if (empleado == null)
            {
                //return NotFound();
            }

            return empleado;

        }

      

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public  ActionResult<Empleado> GetEmpleadoId(int id)
        {
            var empleado =  _empleado.GetAllEmpleadoId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }


        // POST api/<EmpleadosController>
        [HttpPost]
        public void InsertEmpleado([FromBody] Empleado model)
        {
            _empleado.AddEmpleado(model);
          
        }


        // PUT api/<EmpleadosController>/5
        [HttpPut("{idEmpleado}")]
        public void Put(int idEmpleado, [FromBody] Empleado model) {

            model.IdEmpleado = idEmpleado;
            _empleado.UpEmpleado(model);

        }


        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{idEmpleado}")]
        public void Delete(int idEmpleado)
        {
            Empleado model = new Empleado();

            model.IdEmpleado = idEmpleado;
            _empleado.DeleteEmpleado(model);
        }
    }
}
