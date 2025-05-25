using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Commands.BusinessCategoryCommands
{
    public class CreateBusinessCategoryCommand: IRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
