using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using View.ViewModel;
using EntityLayer;

namespace ViewModel.Interface.QueryModel
{
    public interface IQueryBestTalk : IQuery
    {
         Dictionary<string, List<TalkView>> BestTalkList(List<string> meeting);
    }
}
