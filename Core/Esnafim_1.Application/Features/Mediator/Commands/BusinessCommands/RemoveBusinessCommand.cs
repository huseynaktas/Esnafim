using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.BusinessCommands
{
    public class RemoveBusinessCommand: IRequest
    {
        public int Id { get; set; }

        public RemoveBusinessCommand(int id)
        {
            Id = id;
        }
    }
}
