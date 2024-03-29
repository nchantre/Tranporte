﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TrasnporteAdmin.Models;

namespace TrasnporteAdmin.Servicios
{
    public class Servicio_API : IServicio_API
    {
       
        private static string _baseUrl;
   

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("Uris:ServidorEmpleado").Value;
        }


        public async Task<List<EmpleadoViewModel>> Lista()
        {
            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("api/Empleados");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(json_respuesta);
            }

            return lista;
        }

        public async Task<EmpleadoViewModel> Obtener(int idProducto)
        {
            EmpleadoViewModel objeto = new EmpleadoViewModel();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"api/Empleados/{idProducto}");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmpleadoViewModel>(json_respuesta);
                
            }

            return objeto;
        }

        public async Task<bool> Guardar(EmpleadoViewModel objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Empleados", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Editar(EmpleadoViewModel objeto)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Empleados/{objeto.IdEmpleado}", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int idProducto)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.DeleteAsync($"api/Empleados/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
