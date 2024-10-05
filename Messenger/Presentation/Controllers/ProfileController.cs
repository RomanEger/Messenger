using Application.Services.Contracts;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IUserProfileManager _userProfileManager;
    private readonly IPasswordManager _passwordManager;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileController(IPasswordManager passwordManager, IUnitOfWork unitOfWork, IUserProfileManager userProfileManager)
    {
        _passwordManager = passwordManager;
        _unitOfWork = unitOfWork;
        _userProfileManager = userProfileManager;
    }

    [HttpPatch("password")]
    public async Task<IActionResult> ChangePassword(string newPassword)
    {
        if (!await _passwordManager.ChangePassword(HttpContext.User.Identity.Name, newPassword)) 
            return BadRequest();
        await _unitOfWork.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPatch("username")]
    public async Task<IActionResult> ChangeUserName(string newUserName)
    {
        if (!await _userProfileManager.ChangeUserName(HttpContext.User.Identity.Name, newUserName)) 
            return BadRequest();
        await _unitOfWork.SaveChangesAsync();
        return Ok();
    }
}