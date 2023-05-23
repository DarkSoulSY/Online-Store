using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.common.UserDto;
using Services.common.UserRoleEntity;
using Services.Services.UserPermissionService;
using Services.Services.UserRoleService;
using Task3.web.Models;

namespace Task3.web.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRole;

        public UserRoleController(IUserRoleService userRole)
        {
            _userRole = userRole;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _userRole.GetAllUserRole();
            var mappedUserRoles = new List<UserRoleIndexModel>();
            if (response.Success)
            {
                mappedUserRoles = response.Data!.Select(UR => new UserRoleIndexModel() { Id = UR.Id, RoleName = UR.Role.Name, Username = UR.User.Username }).ToList();
            }            
            return View(mappedUserRoles);                        
            
        }
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _userRole.DenyRole(id);
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(UserRoleIndexModel newRole)
        {
            UserRoleDto role = new UserRoleDto()
            {
                Role = newRole.RoleName,
                Username = newRole.Username
            };
            var response = await _userRole.GrantRole(role);

            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _userRole.GetUserRoleByCondition(UR => UR.Id == id);

            UserRoleIndexModel model = new UserRoleIndexModel()
            {
                Id = response.Data!.Id,
                Username = response.Data.User.Username,
                RoleName = response.Data.Role.Name
            };

           
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserRoleIndexModel model1)
        {

            UserRoleDto role = new UserRoleDto
            {
                Id = model1.Id,
                Username = model1.Username,
                Role = model1.RoleName,
                
                 
            };
            var response = await _userRole.UpdateRole(role);

            if (response.Success)
            {
                return RedirectToAction("Index");
            }

            return View(model1);

        }

        
        /*
        public async Task<ActionResult> Details(int id)
        {

            return RedirectToAction("Index");
        }*/
    }
}
