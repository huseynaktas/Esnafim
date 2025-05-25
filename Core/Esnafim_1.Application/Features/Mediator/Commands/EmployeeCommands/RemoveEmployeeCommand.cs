using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.EmployeeCommands
{
    public class RemoveEmployeeCommand: IRequest
    {
        public int Id { get; set; }

        public RemoveEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
