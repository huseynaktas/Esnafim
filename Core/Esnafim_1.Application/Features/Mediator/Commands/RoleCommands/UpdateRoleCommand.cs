using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.RoleCommands
{
    public class UpdateRoleCommand: IRequest
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
