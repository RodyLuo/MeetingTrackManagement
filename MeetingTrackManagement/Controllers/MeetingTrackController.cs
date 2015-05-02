using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Interface.QueryModel;
using ViewModel.QueryProvider;
using EntityLayer;

namespace MeetingTrackManagement.Controllers
{
    public class MeetingTrackController : Controller
    {
        //
        // GET: /MeetingTrack/


        public ActionResult Index()
        {
            List<string> list = new List<string>();
            using (IQueryMeeting meeting = QueryProviderFactory.GetQueryProvider<IQueryMeeting>())
            {
                list = meeting.QueryMeetingCommand();

            }

            Dictionary<string, List<TalkView>> talkList = new Dictionary<string, List<TalkView>>();
            using (IQueryBestTalk talks = QueryProviderFactory.GetQueryProvider<IQueryBestTalk>())
            {
                talkList = talks.BestTalkList(list);
            }
            return View(talkList);
        }

    }
}
