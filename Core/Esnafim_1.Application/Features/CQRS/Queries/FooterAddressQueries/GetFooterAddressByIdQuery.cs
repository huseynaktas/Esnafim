using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery
    {
        public int Id { get; set; }

        public GetFooterAddressByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
