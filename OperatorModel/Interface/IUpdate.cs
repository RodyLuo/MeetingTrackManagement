using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorModel.Interface
{
    public interface IUpdate<T> : IOperator
    {
         T Update(T t);
    }
}
