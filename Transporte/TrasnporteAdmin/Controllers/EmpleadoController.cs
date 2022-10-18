using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrasnporteAdmin.Models;
using TrasnporteAdmin.Servicios;

namespace TrasnporteAdmin.Controllers
{
    public class EmpleadoController : Controller
    {
        #region Properties
        private readonly IServicio_API _servicioApi;
        #endregion

        #region Constructor
        public EmpleadoController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }
        #endregion

        #region ListarEmpleado
        public async Task<IActionResult> Index()
        {
            List<EmpleadoViewModel> lista = await _servicioApi.Lista();
            return View(lista);
        }

        #endregion

        #region Create
        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoViewModel model)
        {
            bool respuesta;
            try
            {
                respuesta = await _servicioApi.Guardar(model);
                
            }
            catch
            {
                return View();
            }
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
        #endregion

        #region Detalle
        public async Task<IActionResult> Details(int id)
        {

            EmpleadoViewModel obj = new EmpleadoViewModel();

            if (id != 0)
            {      
                obj = await _servicioApi.Obtener(id);
            }

            return View(obj);
        }
        #endregion


        // GET: EmpleadoController/Edit/5
        public async Task<IActionResult>  Edit(int id)
        {
            EmpleadoViewModel obj = new EmpleadoViewModel();
            if (id != 0)
            {
                obj = await _servicioApi.Obtener(id);
            }
            return View(obj);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmpleadoViewModel model)
        {
            bool respuesta;
            try
            {
                respuesta = await _servicioApi.Editar(model);

            }
            catch
            {
                return View();
            }
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        // GET: EmpleadoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            EmpleadoViewModel obj = new EmpleadoViewModel();
            if (id != 0)
            {
                obj = await _servicioApi.Obtener(id);
            }
            return View(obj);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmpleadoViewModel model)
        {
            bool respuesta;
            try
            {
                respuesta = await _servicioApi.Eliminar(model.IdEmpleado);

            }
            catch
            {
                return View();
            }
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}
