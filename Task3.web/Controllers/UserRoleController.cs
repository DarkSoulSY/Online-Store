using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.common.UserDto;
using Services.common.UserRoleEntity;
using Services.Services.AuthService;
using Services.Services.RoleService;
using Services.Services.UserPermissionService;
using Services.Services.UserRoleService;
using Task3.web.Models;

namespace Task3.web.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRole;
        private readonly IAuthService _auth;
        private readonly IRoleService _role;

        public UserRoleController(IUserRoleService userRole, IAuthService auth, IRoleService role)
        {
            _userRole = userRole;
            _auth = auth;
            _role = role;
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
            var response2 = await _auth.GetAllUsers();
            var response3 = await _role.GetAllRoles();
            var names = response2.Select(U => U.Username).ToList();
            var roles = response3.Data.Select(R => R.Name).ToList();

            UserRoleUpdateIndexModel model = new UserRoleUpdateIndexModel()
            {
                
                Usernames = new List<SelectListItem>(),
                RoleNames = new List<SelectListItem>()
            };
            foreach (var name in names)
            {
                model.Usernames.Add(new SelectListItem()
                {
                    Text = name,
                    Value = name
                });

            }
            foreach (var role in roles)
            {
                model.RoleNames.Add(new SelectListItem()
                {
                    Text = role,
                    Value = role
                });

            }


            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(UserRoleUpdateIndexModel newRole)
        {
            UserRoleDto role = new UserRoleDto()
            {
                Role = newRole.SelectedRole,
                Username = newRole.SelectedUsername
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
            var response = await _userRole.GetAllUserRole();
            var response2 = await _auth.GetAllUsers();
            var response3 = await _role.GetAllRoles();
            var names = response2.Select(U => U.Username).ToList();
            var roles = response3.Data.Select(R=> R.Name).ToList();


            UserRoleUpdateIndexModel model = new UserRoleUpdateIndexModel()
            {
                Id = id,
                Usernames = new List<SelectListItem>(),
                RoleNames = new List<SelectListItem>()
            };
            foreach (var name in names) 
            {
                model.Usernames.Add(new SelectListItem() { 
                Text = name,
                Value = name
                });

            }
            foreach (var role in roles)
            {
                model.RoleNames.Add(new SelectListItem()
                {
                    Text = role,
                    Value = role
                });

            }


            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserRoleUpdateIndexModel model1)
        {
            
            
            UserRoleDto role = new UserRoleDto
            {
                Id = model1.Id,
                Username = model1.SelectedUsername,
                Role = model1.SelectedRole,
                
                 
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
