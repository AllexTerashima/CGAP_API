using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using CGAP_SITE.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CGAP_SITE.Controllers
{
    public class DepartamentosController : Controller
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
            ("/api/departamentos").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Departamento> data = JsonConvert.DeserializeObject
            <List<Departamento>>(stringData);
            return View(data);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Departamento obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent
            (stringData, System.Text.Encoding.UTF8,
            "application/json");
            HttpResponseMessage response = client.PostAsync
            ("http://localhost:49820/api/departamentos/", contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/departamentos/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Departamento data = JsonConvert.
            DeserializeObject<Departamento>(stringData);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Departamento obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
            ("http://localhost:49820/api/departamentos/" + obj.DepartamentoID,
            contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/departamentos/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Departamento data = JsonConvert.
            DeserializeObject<Departamento>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            return View(data);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(Departamento obj)
        {
            HttpResponseMessage response =
            client.DeleteAsync("http://localhost:49820/api/departamentos/"
            + obj.DepartamentoID).Result;
            TempData["Message"] =
            response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/departamentos/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Departamento data = JsonConvert.
            DeserializeObject<Departamento>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            ViewData["Message2"] = id.ToString();
            return View(data);
        }
    }
}
