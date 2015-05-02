using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorModel.Interface
{
    public interface IAdd<T> : IOperator
    {
         T Add(T t);
    }
}
