using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Bases.CQRS;

public interface IQueryHandler<TQuery, TValue> : IRequestHandler<TQuery, TValue>
    where TQuery : IQuery<TValue>
{
}
