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
using MVC5.Models.Input;
using MVC5.Models.View;

namespace MVC5.Controllers
{
    public class UserController : Controller
    {
        string baseUrl = ConfigurationManager.AppSettings["serviceBaseURL"];

        public async Task<ActionResult> List()
        {
            RESTClient client = new RESTClient(baseUrl);

            var response = await client.Get<IEnumerable<UserDTO>>("api/User");

            var viewModel = response.ToList()
                .Select(x => new UserListViewModel(x));

            return View(viewModel);
        }

        public async Task<ActionResult> Read(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var dto = await client.Get<UserDTO>($"api/User/{id}");

            return View(new UserViewModel(dto));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserInputModel inputModel)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.PostJson<string>("api/User", new UserDTO(inputModel));

                return RedirectToAction("List");
            }
            catch
            {
                return View(inputModel);
            }
        }

        public async Task<ActionResult> Update(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var dto = await client.Get<UserDTO>($"api/User/{id}");

            return View(new UserInputModel(dto));
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id, UserInputModel input)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.PutJson<string>($"api/User/{id}", new UserDTO(input));

                return RedirectToAction("List");
            }
            catch
            {
                return View(input);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            RESTClient client = new RESTClient(baseUrl);

            var dto = await client.Get<UserDTO>($"api/User/{id}");

            return View(new UserViewModel(dto));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, UserViewModel model)
        {
            try
            {
                RESTClient client = new RESTClient(baseUrl);
                await client.Delete<string>($"api/User/{id}");

                return RedirectToAction("List");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
