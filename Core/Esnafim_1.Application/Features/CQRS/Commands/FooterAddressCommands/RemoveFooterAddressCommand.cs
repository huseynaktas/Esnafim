using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand
    {
        public int Id { get; set; }

        public RemoveFooterAddressCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
