using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;
using EntityLayer;
using ViewModel.QueryProvider;

namespace View.ViewModel
{
    /// <summary>
    /// Meeting Track Log Entity
    /// </summary>
    public class TalkViewFacade 
    {
        private IQueryMeeting iQueryMeeting;
        private IQueryBestTalk iQueryBestTalk;

        public TalkViewFacade()
        {
            iQueryMeeting = new MeetingProvider();
            iQueryBestTalk = new BestTalkProvider();
        }

        public TalkViewFacade(IQueryMeeting meeting = null, IQueryBestTalk talk = null)
        {
            iQueryMeeting = meeting;
            iQueryBestTalk = talk;
        }

        /// <summary>
        /// 查询所有会议
        /// </summary>
        /// <returns></returns>
        public List<string> QueryMeetingCommand() {
            if (iQueryMeeting != null)
            {
                return iQueryMeeting.QueryMeetingCommand();
            }
            return null;
        }

        /// <summary>
        /// 最优会议方案列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<TalkView>> BestTalkList()
        {
            if (iQueryBestTalk != null)
            {
                List<string> list = QueryMeetingCommand();
                return iQueryBestTalk.BestTalkList(list);
            }
            return null;
        }
    }
}
