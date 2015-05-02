using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;

namespace QueryProvider
{
    public class MeetingProvider : IQueryMeeting
    {
        //查询所有需要排序的会议
        public List<string> QueryMeetingCommand()
        {
            throw new NotImplementedException();
        }
    }
}
