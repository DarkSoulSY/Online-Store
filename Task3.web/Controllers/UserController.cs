using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.common.UserDto;
using Services.Services.AuthService;
using Task3.web.Models;

namespace Task3.web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService _auth;

        public UserController(IAuthService auth)
        {
            _auth = auth;

        }
        public async Task<IActionResult> Index()
        {
            var users = await _auth.GetAllUsers();
            var model = users.Select(u => new UserIndexModel() { Address = u.Address, Email = u.Email, Id = u.Id, PhoneNumber = u.PhoneNumber, Username = u.Username }).ToList();
            return View(model);
        }

        public async Task<ActionResult> Delete(DeleteUserModel deleteUser)
        {
            var response = await _auth.DeleteUser(deleteUser.Id);           
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _auth.GetUser(id);

            var model = new CreateOrUpdateUser() {
                Id = response.Data!.Id,
                Username = response.Data!.Username,
                PhoneNumber = response.Data!.PhoneNumber,
                Address = response.Data!.Address,
                Password = string.Empty
            };
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Edit(CreateOrUpdateUser model1)
        {

            User user = new User
            {
                Id = (int) model1.Id!,
                Username = model1.Username,
                Address = model1.Address,
                PhoneNumber = model1.PhoneNumber,
                Email = model1.Email,
                PasswordHash = new byte[0],
                PasswordSalt = new byte[0]
            };
            var response = await _auth.UpdateUser(user, model1.Password);

            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            
            return View(model1);

        }

        public async Task<ActionResult> Create()
        {           
                return View();            
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateOrUpdateUser newUser)
        {
            UserSignUpDto user = new UserSignUpDto()
            {
                Username = newUser.Username,
                PhoneNumber = newUser.PhoneNumber,
                Address = newUser.Address,
                Email = newUser.Email,
                Password = newUser.Password
            };
            var response = await _auth.Register(user);

            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        public async Task<ActionResult> Details(int id)
        {
            
            return RedirectToAction("Index");
        }




    }
}
