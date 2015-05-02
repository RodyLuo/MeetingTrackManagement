using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;
using View.ViewModel;
using EntityLayer;
using MeetingDomainLayer;

namespace ViewModel.QueryProvider
{
    //读操作
    public class BestTalkProvider : IQueryBestTalk
    {
        public Dictionary<string, List<TalkView>> BestTalkList(List<string> meeting)
        {
            using (IQueryBestTalk provider = QueryProviderFactory.GetQueryProvider<IQueryBestTalk>())
            {
                return TalkDomain.GetBestTalkList(meeting);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
