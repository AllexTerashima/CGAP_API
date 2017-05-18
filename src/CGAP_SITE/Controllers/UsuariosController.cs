using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using CGAP_SITE.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CGAP_SITE.Controllers
{
    public class UsuariosController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            client.BaseAddress = new Uri
            ("http://localhost:49820/");
            MediaTypeWithQualityHeaderValue contentType =
            new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync
            ("/api/usuarios").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Usuario> data = JsonConvert.DeserializeObject
            <List<Usuario>>(stringData);
            return View(data);
        }

        public ActionResult Insert()
        {
            client.BaseAddress = new Uri
            ("http://localhost:49820/");
            MediaTypeWithQualityHeaderValue contentType =
            new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync
            ("/api/perfis").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Perfil> data = JsonConvert.DeserializeObject
            <List<Perfil>>(stringData);
            ViewData["PerfilID"] = new SelectList(data, "PerfilID", "Nome");
            response = client.GetAsync
            ("/api/departamentos").Result;
            string stringData2 = response.Content.
            ReadAsStringAsync().Result;
            List<Departamento> data2 = JsonConvert.DeserializeObject
            <List<Departamento>>(stringData2);
            ViewData["DepartamentoID"] = new SelectList(data2, "DepartamentoID", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Usuario obj)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent
                (stringData, System.Text.Encoding.UTF8,
                "application/json");
                HttpResponseMessage response = client.PostAsync
                ("http://localhost:49820/api/usuarios/", contentData).Result;
                ViewBag.Message = response.Content.
                ReadAsStringAsync().Result;
                return RedirectToAction("Index", obj);
            }
            return View(obj);
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/usuarios/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Usuario data = JsonConvert.
            DeserializeObject<Usuario>(stringData);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Usuario obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
            ("http://localhost:49820/api/usuarios/" + obj.UsuarioID,
            contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/usuarios/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Usuario data = JsonConvert.
            DeserializeObject<Usuario>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            return View(data);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(Usuario obj)
        {
            HttpResponseMessage response =
            client.DeleteAsync("http://localhost:49820/api/usuarios/"
            + obj.DepartamentoID).Result;
            TempData["Message"] =
            response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/usuarios/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Usuario data = JsonConvert.
            DeserializeObject<Usuario>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            ViewData["Message2"] = id.ToString();
            return View(data);
        }

        public IActionResult Login()
        {
            client.BaseAddress = new Uri
            ("http://localhost:49820/");
            MediaTypeWithQualityHeaderValue contentType =
            new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync
            ("/api/usuarios").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Usuario> data = JsonConvert.DeserializeObject
            <List<Usuario>>(stringData);
            return View();
        }
    }
}
