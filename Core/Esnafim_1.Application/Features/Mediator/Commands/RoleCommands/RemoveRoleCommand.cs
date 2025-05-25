using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.RoleCommands
{
    public class RemoveRoleCommand: IRequest
    {
        public int Id { get; set; }

        public RemoveRoleCommand(int id)
        {
            Id = id;
        }
    }
}
