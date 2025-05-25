using Esnafim_1.Application.Features.CQRS.Queries.ContactQueries;
using Esnafim_1.Application.Features.CQRS.Results.ContactResults;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Email = values.Email,
                Message = values.Message,
                Subject = values.Subject,
                Name = values.Name,
                SendDate = values.SendDate
            };
        }
    }
}
