using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.AccountRepo;
using Zomato.Repository.UnitOfWork;

namespace Zomato.Core.ApiControllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: Controller
    {
        #region Dependencies

        private readonly IUnitOfWork _UnitOfWork;
        #endregion

        #region Constructor
        public AccountController(IUnitOfWork _unitOfWork)
        {
           
            _UnitOfWork = _unitOfWork;
        }
        #endregion

        [HttpPost,Route("register")]
        public async Task<ActionResult>Register([FromBody] User user)
        {
          var result=await _UnitOfWork.AccountRepository. Register(user);
      

            if (result.Succeeded)
            {
                //await unitOfWork.data.AddRole(model, user);
                //   await unitOfWork.data.SignIn(user);

                return Ok(new { id = user.Id });
            }
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return BadRequest();
        }
        [HttpPost,Route("login")]
        public async Task<ActionResult> getdata([FromBody] User user)
        {
          var result=await _UnitOfWork.AccountRepository.Login(user);
            if (result.Succeeded)
            {
                var currentUser =  await _UnitOfWork.AccountRepository.GetCurrenUser(user);
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new List<Claim>{
                                          new Claim(ClaimTypes.Name,currentUser.UserName),
                                          
                                          new Claim("id",currentUser.Id )
                                          };
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
   
}
