using MVC5.Models;
using MVC5.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace MVC5.Controllers
{
    public class TaskController : Controller
    {
        string baseUrl = ConfigurationManager.AppSettings["serviceBaseURL"];

        public async Task<ActionResult> Index()
        {
            RESTClient client = new RESTClient(baseUrl);

            var response = await client.Get<IEnumerable<Models.Task>>("api/Task");

            return View(response);
        }

        // GET: Test/Details/5
        public async Task<ActionResult> Details(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var response = await client.Get<Models.Task>($"api/Task/{id}");

            return View(response);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public async Task<ActionResult> Create(Models.Task model)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.PostJson<string>("api/Task", model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Test/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var response = await client.Get<Models.Task>($"api/Task/{id}");

            return View(response);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Models.Task model)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.PutJson<string>($"api/Task/{id}", model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var response = await client.Get<Models.Task>($"api/Task/{id}");

            return View(response);
        }

        // POST: Test/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Models.Task model)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.Delete<string>($"api/Task/{id}");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
