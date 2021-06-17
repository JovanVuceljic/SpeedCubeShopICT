using System;
using System.Collections.Generic;
using System.Text;

namespace Scs.Application.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException()
        {
        }

        public EntityAlreadyExistsException(int id, Type type)
            : base($"Entity of type {type.Name} with id of {id} already exists")
        {

        }
    }
}
