using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryModel
{
    public interface IQueryMeeting :IQuery
    {
        public List<string> QueryMeetingCommand;
    }
}
