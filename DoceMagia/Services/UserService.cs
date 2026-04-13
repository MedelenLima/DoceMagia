using System.Security.Claims;
using DoceMagia.Data;
using DoceMagia.Helpers;
using DoceMagia.Models;
using DoceMagia.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoceMagia.Services;

public class UserService : IUserService
{
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly ILogger<UserService> _logger;
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(
        AppDbContext context,
        IHttpContextAccessor httpContextAccessor,
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        ILogger<UserService> logger
    )
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<UsuarioVM> GetUsuarioLogado()
    {
        var userId = _httpContextAccessor.HttpContext.User
        .FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return null;
        var userAccount = await _userManager.FindByIdAsync(userId);
        var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == userId);
        var perfis = string.Join(", ", await _userManager.GetRolesAsync(userAccount));
        var IsAdmin = await _userManager.IsInRoleAsync(userAccount, "Administrador");
        UsuarioVM usuarioVM = new()
        {
            UsuarioId = userId,
            Nome = usuario.Nome,
            DataNascimento = usuario.DataNascimento,
            Foto = usuario.Foto,
            Email = userAccount.Email,
            UserName = userAccount.UserName,
            Perfil = perfis,
            IsAdmin = IsAdmin
        };
        return usuarioVM;
    }

    public async Task<SignInResult> Login(LoginVM login)
    {
        string userName = login.Email;
        if (Helper.IsValidEmail(login.Email))
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
                userName = user.UserName;
        }

        var result = await _signInManager.PasswordSignInAsync(
            userName, login.Senha, login.Lembrar, lockoutOnFailure: true
        );

        if (result.Succeeded)
            _logger.LogInformation($"Usuário '{userName}' acessou o sistema");
        if (result.IsLockedOut)
            _logger.LogWarning($"Usuário  '{userName}' foi bloqueado");

        return result;
    }

    public async Task Logout()
    {
        _logger.LogInformation($"Usuário '{ClaimTypes.Email}' saiu do sistema");
        await _signInManager.SignOutAsync();
    }
}
