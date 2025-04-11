using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Business.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password, bool rememberMe);
    Task LogoutAsync();
    Task<IdentityResult> SignUpAsync(SignUpDto dto, string roleName = "User");
    Task<bool> UserExistsAsync(string email);
}

public class AuthService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : IAuthService
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;

    public async Task<bool> LoginAsync(string email, string password, bool rememberMe)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        return result.Succeeded;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> SignUpAsync(SignUpDto dto, string roleName = "User")
    {
        if (dto == null)
            return null!;

        var userEntity = new UserEntity
        {
            UserName = dto.Email,
            Email = dto.Email,
             FirstName = dto.FirstName,
            LastName = dto.LastName
        };



        var result = await _userManager.CreateAsync(userEntity, dto.Password);
        if (result.Succeeded)
        {
           
        }

        return result;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == email);
    }
}
