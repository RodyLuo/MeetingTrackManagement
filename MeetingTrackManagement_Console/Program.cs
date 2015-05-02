using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ViewModel;
using System.IO;
using View.ViewModel;
using ViewModel.Interface.QueryModel;
using ViewModel.QueryProvider;
using EntityLayer;

namespace MeetingTrackManagement_Console
{
    class Program
    {
        static void Main()
        {
            List<string> list = new List<string>();
            using (IQueryMeeting meeting = QueryProviderFactory.GetQueryProvider<IQueryMeeting>())
            {
                list = meeting.QueryMeetingCommand();
                
            }

            Dictionary<string, List<TalkView>> talkList1 = new Dictionary<string, List<TalkView>>();
            using (IQueryBestTalk talks = QueryProviderFactory.GetQueryProvider<IQueryBestTalk>())
            {
                talkList1 = talks.BestTalkList(list);
                foreach (var item in talkList1)
                {
                    Console.WriteLine(item.Key);
                    foreach (var talk in item.Value)
                    {
                        Console.WriteLine(talk.Name);
                    }
                }
            }



            //这是一种方式 使用设计模式facade
            TalkViewFacade facade = new TalkViewFacade();
            Dictionary<string,List<TalkView>> talkList2 = facade.BestTalkList();

            foreach (var item in talkList2) {
                Console.WriteLine(item.Key);
                foreach (var talk in item.Value)
                {
                    Console.WriteLine(talk.Name);
                }
            }

            Console.ReadKey();
        }
    }
}