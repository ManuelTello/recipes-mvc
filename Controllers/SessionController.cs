using Microsoft.AspNetCore.Mvc;
using recipes.Data;
using recipes.Services;
using recipes.Models;
using recipes.ViewModels.Session;
using recipes.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace recipes.Controllers
{
    public class SessionController : Controller
    {
        private readonly SessionService Service;

        private readonly string? SessionKey;

        public SessionController(DataContext context, IConfiguration configuration)
        {
            this.Service = new SessionService(context);
            this.SessionKey = configuration.GetConnectionString("sessionkey");
        }

        [HttpGet]
        [Route("{controller}/signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        [Route("{controller}/signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("{controller}/signin")]
        public async Task<IActionResult> SignInValidation(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Operation<User> operation = await this.Service.FetchUser(model);
                    if (operation.Payload == null)
                    {
                        ModelState.AddModelError("", operation.ErrorMessage!);
                        return View("SignIn", model);
                    }
                    else
                    {
                        HttpContext.Session.SetString(this.SessionKey!, operation.Payload[0].Username);
                        return RedirectToAction("UserPanel", "Session");
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return View("SignIn", model);
            }
        }

        [HttpPost]
        [Route("{controller}/signup")]
        public async Task<IActionResult> SignUpValidation(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Operation<User> added = await this.Service.AddUser(model);

                    if (added.Completed)
                    {
                        HttpContext.Session.SetString(this.SessionKey!, model.Username);
                        return RedirectToAction("UserPanel", "Session");
                    }
                    else
                    {
                        ModelState.AddModelError("", added.ErrorMessage!);
                        return View("SignUp", model);
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return View("SignUp", model);
            }
        }

        [HttpGet]
        [Route("{controller}/panel")]
        public async Task<IActionResult> UserPanel()
        {
            string? session = HttpContext.Session.GetString(this.SessionKey!);
            PanelViewModel model;

            if (session == null)
            {
                model = new PanelViewModel();
            }
            else
            {
                Operation<User> user = await this.Service.FetchUser(session);
                model = new PanelViewModel()
                {
                    Username = user.Payload![0].Username,
                    Email = user.Payload[0].Email
                };
            }

            return View("Panel", model);
        }


        [HttpGet]
        [Route("{controller}/logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(this.SessionKey!);
            return RedirectToAction("UserPanel", "Session");
        }
    }
}