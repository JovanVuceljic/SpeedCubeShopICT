using Scs.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using static Scs.Application.ICommand;

namespace Scs.Application.Commands
{
    public interface ICreateBrandCommand : ICommand<BrandDto>
    {
    }
}
