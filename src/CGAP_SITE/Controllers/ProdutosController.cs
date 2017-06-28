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
    public class ProdutosController : Controller
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
            ("/api/produtos").Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            List<Produto> data = JsonConvert.DeserializeObject
            <List<Produto>>(stringData);
            return View(data);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Produto obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent
            (stringData, System.Text.Encoding.UTF8,
            "application/json");
            HttpResponseMessage response = client.PostAsync
            ("http://localhost:49820/api/produtos/", contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Update(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/produtos/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Produto data = JsonConvert.
            DeserializeObject<Produto>(stringData);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Produto obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync
            ("http://localhost:49820/api/produtos/" + obj.ProdutoID,
            contentData).Result;
            ViewBag.Message = response.Content.
            ReadAsStringAsync().Result;
            return RedirectToAction("Index", obj);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/produtos/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Produto data = JsonConvert.
            DeserializeObject<Produto>(stringData);
            ViewData["Message1"] = data.Tipo.ToString();
            ViewData["Message2"] = data.Marca.ToString();
            return View(data);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(Produto obj)
        {
            HttpResponseMessage response =
            client.DeleteAsync("http://localhost:49820/api/produtos/"
            + obj.ProdutoID).Result;
            TempData["Message"] =
            response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response =
            client.GetAsync("http://localhost:49820/api/produtos/" + id).Result;
            string stringData = response.Content.
            ReadAsStringAsync().Result;
            Produto data = JsonConvert.
            DeserializeObject<Produto>(stringData);
            ViewData["Message1"] = data.Tipo.ToString();
            ViewData["Message2"] = data.Marca.ToString();
            ViewData["Message3"] = id.ToString();
            return View(data);
        }
    }
}
