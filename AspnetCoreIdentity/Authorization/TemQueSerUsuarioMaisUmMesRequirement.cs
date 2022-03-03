using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreIdentity.Authorization
{
    public class TemQueSerUsuarioMaisUmMesRequirement: IAuthorizationRequirement
    {
        public TemQueSerUsuarioMaisUmMesRequirement()
        { }
    }

    public class TemQueSerUsuarioMaisUmMesRequirementHandler:AuthorizationHandler<TemQueSerUsuarioMaisUmMesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TemQueSerUsuarioMaisUmMesRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "DataCadastro"))
                return Task.CompletedTask;

            var dataCadastroUsuario = DateTime.Parse(context.User.FindFirst(x => x.Type == "DataCadastro").Value);
            var tempoCadastrado = DateTime.Today - dataCadastroUsuario;
            if (tempoCadastrado.Days >= 30)
                context.Succeed(requirement);

            return Task.CompletedTask;

        }
    }
}
