using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.BusinessCategoryCommands
{
    public class RemoveBusinessCategoryCommand: IRequest
    {
        public int Id { get; set; }

        public RemoveBusinessCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
