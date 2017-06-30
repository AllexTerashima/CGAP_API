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
            ViewData["DepartamentoID"] = new SelectList(getDepartamentos(), "DepartamentoID", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Usuario obj)
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

        public ActionResult Update(string id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/usuarios/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Usuario data = JsonConvert.
            DeserializeObject<Usuario>(stringData);
            ViewData["DepartamentoID"] = new SelectList(getDepartamentos2(), "DepartamentoID", "Nome");
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Usuario obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
            ("http://localhost:49820/api/usuarios/" + obj.Id,
            contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Delete(string id)
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
            + obj.Id).Result;
            TempData["Message"] =
            response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

        private List<Departamento> getDepartamentos()
        {
            HttpResponseMessage response = client.GetAsync
            ("/api/departamentos").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject
            <List<Departamento>>(stringData);
        }

        private List<Departamento> getDepartamentos2()
        {
            HttpResponseMessage response = client.GetAsync
            ("http://localhost:49820/api/departamentos").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject
            <List<Departamento>>(stringData);
        }

        public ActionResult Details(string id)
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

        public ActionResult Login()
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
