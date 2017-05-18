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
    public class PerfisController : Controller
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
            ("/api/perfis").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Perfil> data = JsonConvert.DeserializeObject
            <List<Perfil>>(stringData);
            return View(data);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Perfil obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent
            (stringData, System.Text.Encoding.UTF8,
            "application/json");
            HttpResponseMessage response = client.PostAsync
            ("http://localhost:49820/api/perfis/", contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/perfis/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Perfil data = JsonConvert.
            DeserializeObject<Perfil>(stringData);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Perfil obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
            ("http://localhost:49820/api/perfis/" + obj.PerfilID,
            contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/perfis/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Perfil data = JsonConvert.
            DeserializeObject<Perfil>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            return View(data);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(Perfil obj)
        {
            HttpResponseMessage response =
            client.DeleteAsync("http://localhost:49820/api/perfis/"
            + obj.PerfilID).Result;
            TempData["Message"] =
            response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/perfis/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Perfil data = JsonConvert.
            DeserializeObject<Perfil>(stringData);
            ViewData["Message"] = data.Nome.ToString();
            ViewData["Message2"] = id.ToString();
            return View(data);
        }
    }
}
