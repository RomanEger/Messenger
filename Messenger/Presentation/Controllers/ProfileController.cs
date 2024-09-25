using Application.DataTransferObjects;
using Application.Services.Contracts;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IPasswordManager _passwordManager;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileController(IPasswordManager passwordManager, IUnitOfWork unitOfWork)
    {
        _passwordManager = passwordManager;
        _unitOfWork = unitOfWork;
    }

    [HttpPatch("password")]
    public async Task<IActionResult> ChangePassword(UserForAuthenticationDto user, string newPassword)
    {
        if (await _passwordManager.ChangePassword(user, newPassword))
        {
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }
}