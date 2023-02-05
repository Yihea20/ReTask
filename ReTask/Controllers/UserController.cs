using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReTask.AuthoManger;
using ReTask.IRepository;
using ReTask.Models;
using ReTask.Models.ViewModel;
using System;

namespace ReTask.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthoManager _authoManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, IAuthoManager authoManger, IMapper mapper)
        {
            _userManager = userManager;
            _authoManager = authoManger;
            _mapper = mapper;
          }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register( UserDTO UserDTO)
        {

            var user = _mapper.Map<User>(UserDTO);
            user.UserName = UserDTO.FirstName + UserDTO.LastName;
            user.Email = UserDTO.Email;
            var result = await _userManager.CreateAsync(user, UserDTO.Password);
            if (!result.Succeeded)
            {
                foreach (var Error in result.Errors)
                {
                    ModelState.AddModelError(Error.Code, Error.Description);

                }
                return RedirectToAction("Register","User");
            }
           
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO UserDTO)
        {
            try
            {
                if (!await _authoManager.ValidateUser(UserDTO))
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("GetAll","Newss");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login");
            }
        }

    }
}
