using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;
using System.Xml;

namespace ViewModel.QueryProvider
{
    public class MeetingProvider : IQueryMeeting
    {
        //查询所有需要排序的会议 
        public List<string> QueryMeetingCommand()
        {
            //使用工厂模式 提高内存利用率
            using (IQueryMeeting provider = QueryProviderFactory.GetQueryProvider<IQueryMeeting>())
            {
                List<string> result = new List<string>();
                result.Add("Writing Fast Tests Against Enterprise Rails 60min");
                result.Add("Overdoing it in Python 45min");
                result.Add("Lua for the Masses 30min");
                result.Add("Ruby Errors from Mismatched Gem Versions 45min");
                result.Add("Common Ruby Errors 45min");
                result.Add("Rails for Python Developers lightning");
                result.Add("Communicating Over Distance 60min");
                result.Add("Accounting-Driven Development 45min");
                result.Add("Woah 30min");
                result.Add("Sit Down and Write 30min");
                result.Add("Pair Programming vs Noise 45min");
                result.Add("Rails Magic 60min");
                result.Add("Ruby on Rails: Why We Should Move On 60min");
                result.Add("Clojure Ate Scala (on my project) 45min");
                result.Add("Programming in the Boondocks of Seattle 30min");
                result.Add("Ruby vs. Clojure for Back-End Development 30min");
                result.Add("Ruby on Rails Legacy App Maintenance 60min");
                result.Add("A World Without HackerNews 30min");
                result.Add("User Interface CSS in Rails Apps 30min");

                return result;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
