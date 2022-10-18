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




        public ActionResult Details(int id)
        {

            return View();
        }

       

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
