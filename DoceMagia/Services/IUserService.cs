using DoceMagia.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace DoceMagia.Services;

public interface IUserService
{
    Task<UsuarioVM> GetUsuarioLogado();
    Task<SignInResult> Login(LoginVM login);
    Task Logout();
}