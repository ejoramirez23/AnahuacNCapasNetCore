using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ML;
using System.ComponentModel.DataAnnotations;

namespace PL.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class RolController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RolController(RoleManager<IdentityRole> rolMgr)
        {
            roleManager = rolMgr;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Asignar(Guid idRole, string name)
        {

            ML.Result result = BL.UserIdentity.GetAll();
            ML.UserIdentity ui = new ML.UserIdentity();

            if (result.Correct)
            {
               
                ui.IdentityUsers = result.Objects;
            }

            ui.Rol = new ML.Rol();
            ui.Rol.RoleId = idRole;
            ui.Rol.Name = name;
            ViewBag.Name = name;

            return View(ui);
        }

        [HttpPost]
        public IActionResult Asignar(ML.UserIdentity user)
        {
            ML.Result result = BL.UserIdentity.Asignar(user);

            if (result.Correct)
            {
                ViewBag.Titulo = "Aviso";
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Titulo = "Error";
                ViewBag.Message = result.Message;
            }

            return PartialView("Modal");
        }

        [HttpPost]
        public async Task<IActionResult> Form([Required] Microsoft.AspNetCore.Identity.IdentityRole rol)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = await roleManager.FindByIdAsync(rol.Id.ToString());

                if (role == null)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(rol.Name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAll");
                    }
                }
                else
                {
                    role.Id = await roleManager.GetRoleIdAsync(rol);
                    role.Name = await roleManager.GetRoleNameAsync(rol);

                    IdentityResult result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAll");
                    }
                }
            }
            return View(rol);
        }

        [HttpGet]
        public IActionResult Form(Guid IdRole, string Name)
        {
            IdentityRole role = new IdentityRole();
            if (Name != null)
            {
                role.Name = Name;
                role.Id = IdRole.ToString();
                return View(role);
            }
            else
            {
                return View(role);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid IdRole)
        {
            IdentityRole role = await roleManager.FindByIdAsync(IdRole.ToString());
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("GetAll");
                //else
                //    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("GetAll", roleManager.Roles);
        }
    }
}
