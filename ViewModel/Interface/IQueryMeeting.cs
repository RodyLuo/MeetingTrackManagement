using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;

namespace ViewModel.Interface.QueryModel
{
    public interface IQueryMeeting :IQuery
    {
         List<string> QueryMeetingCommand();
    }
}
