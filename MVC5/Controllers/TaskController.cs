using MVC5.Models;
using MVC5.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC5.Models.DTO;
using MVC5.Models.View;
using MVC5.Models.Input;

namespace MVC5.Controllers
{
    public class TaskController : Controller
    {
        string baseUrl = ConfigurationManager.AppSettings["serviceBaseURL"];

        public async Task<ActionResult> List(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var user = await client.Get<UserDTO>($"api/user/{id}");
            var tasks = await client.Get<IEnumerable<TaskDTO>>($"api/taskfromuser/{id}");

            return View(new TaskListViewModel(user, tasks));
        }

        public async Task<ActionResult> Read(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var dto = await client.Get<TaskDTO>($"api/Task/{id}");

            ViewBag.UserId = dto.UserId;

            return View(new TaskViewModel(dto));
        }

        public ActionResult Create(int id)
        {
            var input = new TaskInputModel()
            {
                UserId = id
            };

            ViewBag.UserId = id;

            return View(input);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TaskInputModel input)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.PostJson<string>($"api/task", new TaskDTO(input));

                return RedirectToAction("List", new { id = input.UserId });
            }
            catch
            {
                return View(input);
            }
        }

        public async Task<ActionResult> Update(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var dto = await client.Get<TaskDTO>($"api/task/{id}");

            ViewBag.UserId = dto.UserId;

            return View(new TaskInputModel(dto));
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id, TaskInputModel input)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.PutJson<string>($"api/task/{input.Id}", new TaskDTO(input));

                return RedirectToAction("List", new { id = input.UserId });
            }
            catch
            {
                return View(input);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var dto = await client.Get<TaskDTO>($"api/task/{id}");

            ViewBag.UserId = dto.UserId;

            return View(new TaskViewModel(dto));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, TaskViewModel view)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.Delete<string>($"api/Task/{id}");

                return RedirectToAction("List", new { id = view.UserId });
            }
            catch
            {
                return View(view);
            }
        }
    }
}
