using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Company
{
    public class List
    {
        public class Query : IRequest<List<Company>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Company>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Company>> Handle(Query request,
             CancellationToken cancellationToken)
            {
                var company = await _context.Company.ToListAsync();
                return company;
            }
        }
    }
}