using System;
using System.Collections.Generic;
using System.Text;

namespace Contato.Application.Service.Messages
{
    internal abstract class BaseResponseMessage<T> where T : class
    {
        public T Model { get; private set; }
        public bool IsSuccess { get; private set; }
    }
}
