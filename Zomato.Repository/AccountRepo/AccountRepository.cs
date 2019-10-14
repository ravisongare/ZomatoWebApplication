using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.AccountRepo
{
    public class AccountRepository :IAccountRepository
    {

        #region Dependencies
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        #endregion

        #region Constructors
        public AccountRepository(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole>roleManager,SignInManager<ApplicationUser>signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }
        #endregion

        public async Task<IdentityResult> Register(User userData)
        {
            var user = new ApplicationUser { UserName= userData.Name,PhoneNumber= userData.Name,Address= userData.Address};
           return  await _userManager.CreateAsync(user,userData.Password);
        }
        public async Task<SignInResult> Login(User user)
        {
          return await _signInManager.PasswordSignInAsync(user.Name, user.Password, true, false);
        
        }
        public async Task<ApplicationUser> GetCurrenUser(User user)
        {
            return await _userManager.FindByNameAsync(user.Name);
        }
    }
}
