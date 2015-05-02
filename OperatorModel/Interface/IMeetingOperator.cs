using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;

namespace OperatorModel.Interface
{
    public interface IMeetingOperator:IDelete<TalkView>,IAdd<TalkView>,IUpdate<TalkView>
    {

    }
}
