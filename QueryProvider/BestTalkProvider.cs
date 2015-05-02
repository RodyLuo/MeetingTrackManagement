using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;
using View.ViewModel;

namespace QueryProvider
{
    public class BestTalkProvider : IQueryBestTalk
    {

        public Dictionary<string, List<TalkView>> BestTalkList()
        {
            throw new NotImplementedException();
        }
    }
}
