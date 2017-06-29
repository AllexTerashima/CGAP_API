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
    public class SalasController : Controller
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
            ("/api/salas").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Sala> data = JsonConvert.DeserializeObject
            <List<Sala>>(stringData);

            List<Sala> data2 = new List<Sala>();
            List<Departamento> deps = getDepartamentos();
            foreach(var d in data)
            {
                d.Departamento = deps.FirstOrDefault(e => e.DepartamentoID == d.DepartamentoID);
                data2.Add(d);
            }
            return View(data2);
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
        public ActionResult Insert(Sala obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent
            (stringData, System.Text.Encoding.UTF8,
            "application/json");
            HttpResponseMessage response = client.PostAsync
            ("http://localhost:49820/api/salas/", contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/salas/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Sala data = JsonConvert.
            DeserializeObject<Sala>(stringData);
            ViewData["DepartamentoID"] = new SelectList(getDepartamentos2(), "DepartamentoID", "Nome");
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Sala obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
            ("http://localhost:49820/api/salas/" + obj.SalaID,
            contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/salas/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Sala data = JsonConvert.
            DeserializeObject<Sala>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            return View(data);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(Sala obj)
        {
            HttpResponseMessage response =
            client.DeleteAsync("http://localhost:49820/api/salas/"
            + obj.SalaID).Result;
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

        public ActionResult Details(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/salas/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Sala data = JsonConvert.
            DeserializeObject<Sala>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            ViewData["Message2"] = id.ToString();
            return View(data);
        }
    }
}
