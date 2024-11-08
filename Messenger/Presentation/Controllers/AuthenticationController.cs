using Application.DataTransferObjects;
using Application.Services.Contracts;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationController(IAuthenticationService authenticationService, IUnitOfWork unitOfWork)
    {
        _authenticationService = authenticationService;
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthenticationDto)
    {
        var tokenDto = await _authenticationService.LoginAsync(userForAuthenticationDto);
        return tokenDto == null ? Unauthorized() : Ok(tokenDto);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        if (!await _authenticationService.CreateUserAsync(userForRegistrationDto)) 
            return BadRequest();
        await _unitOfWork.SaveChangesAsync();
        var user = new UserForAuthenticationDto(userForRegistrationDto.Email, userForRegistrationDto.Password);
        var token = await _authenticationService.LoginAsync(user);
        return Ok(token);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        return Ok(await _authenticationService.RefreshTokensAsync(tokenDto, _unitOfWork));
    }
}