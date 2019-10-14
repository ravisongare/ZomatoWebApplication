using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.AccountRepo
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Register(User user);
        Task<SignInResult> Login(User user);
        Task<ApplicationUser> GetCurrenUser(User user);
    }
}
