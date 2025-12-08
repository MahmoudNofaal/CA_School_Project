using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Bases.CQRS;

public interface IQuery<TValue> : IRequest<TValue>
{
}
