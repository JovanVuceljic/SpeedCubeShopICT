using Scs.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Commands.OrderCommands
{
    public interface ICreateOrderCommand : ICommand<OrderDto>
    {
    }
}
