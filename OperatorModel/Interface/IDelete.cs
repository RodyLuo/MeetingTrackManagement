using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorModel.Interface
{
    public interface IDelete<T> : IOperator
    {
         bool Delete(T t);
    }
}
