using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Bases.CQRS;

public interface ICommandHandler<TCommand, TValue> : IRequestHandler<TCommand, TValue>
   where TCommand : ICommand<TValue>
{
}
