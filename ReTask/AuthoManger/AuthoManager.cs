using Microsoft.AspNetCore.Identity;
using ReTask.Models;
using ReTask.Models.ViewModel;
using System;

namespace ReTask.AuthoManger
{
    public class AuthoManager:IAuthoManager
    {
        private readonly UserManager<User> _userManager;
        private User _user;
        public AuthoManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> ValidateUser(LoginUserDTO UserDTO)
        {
            _user = await _userManager.FindByEmailAsync(UserDTO.Email);
            var validPassword = await _userManager.CheckPasswordAsync(_user, UserDTO.Password);
            return (_user != null && validPassword);
        }

        
    }
}
