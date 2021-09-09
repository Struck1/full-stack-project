using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Qery : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Qery, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Qery request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }

    }
}