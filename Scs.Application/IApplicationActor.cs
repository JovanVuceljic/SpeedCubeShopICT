using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<int> AllowedUseCases { get;  } // 1
    }
}
