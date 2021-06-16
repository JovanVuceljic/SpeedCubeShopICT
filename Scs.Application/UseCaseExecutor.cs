using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Scs.Application.ICommand;
using Scs.Application.Exceptions;

namespace Scs.Application
{
    public class UseCaseExecutor
    {

        private readonly IApplicationActor actor;

        public UseCaseExecutor(IApplicationActor actor)
        {
            this.actor = actor;
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command, 
            TRequest request) {
            Console.WriteLine($"{DateTime.Now} : {actor.Identity} is trying to execute {command.Name} using data: " +
                $"{JsonConvert.SerializeObject(request)}");

            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
                
            command.Execute(request);
            
        }
}
}
