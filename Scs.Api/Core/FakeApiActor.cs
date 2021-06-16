using Scs.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scs.Api.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;
        public string Identity => "Test Api User";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1 };

      }

    public class AdminFakeActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Admin Api User";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);
    }
}
