using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand
    {
        public int Id { get; set; }

        public RemoveTestimonialCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
