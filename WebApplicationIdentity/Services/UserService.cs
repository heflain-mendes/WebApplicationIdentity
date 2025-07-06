using Microsoft.AspNetCore.Identity;
using WebApplicationIdentity.DTOs.Request;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Services
{
    public class UserService(
        IUserContext userContext,
        IUserStore<User> userStore, // Possui operações de baixo nível com o CRUD
        UserManager<User> userManager, // Possui a funcionalidade completa como a de adicionar uma role a um usuário
        RoleManager<IdentityRole> roleManager) : IUserService
    {
        public async Task UpdateUserDetails(UserUpdateDetailsRequest request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();

            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

            if (dbUser == null)
            {
                // Lançar uma exception customizada!!!
                throw new Exception($"Not Found {nameof(user)} with {user!.Id}");
            }

            dbUser.Nationality = request.Nationality;
            dbUser.DateOfBirth = request.DateOfBirth;

            await userStore.UpdateAsync(dbUser, cancellationToken);
        }

        public async Task AssignUserRole(AssignUserRoleRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new Exception($"Não foi possível encontrar o usuário com email {request.UserEmail}");

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new Exception($"Não foi possível encontrar a role de nome {request.RoleName}");

            await userManager.AddToRoleAsync(user, role.Name!);
        }
    }
}
