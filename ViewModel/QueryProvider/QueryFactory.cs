using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Interface.QueryModel;

namespace ViewModel.QueryProvider
{
    public class QueryProviderFactory
    {
        public static Dictionary<Type, IQuery> Providers { get; set; }

        static QueryProviderFactory()
        {
            Providers = new Dictionary<Type, IQuery>();

            Providers.Add(typeof(IQueryBestTalk), new BestTalkProvider());
            Providers.Add(typeof(IQueryMeeting), new MeetingProvider());

        }

        public static T GetQueryProvider<T>() where T : IQuery
        {
            IQuery provider;
            if (QueryProviderFactory.Providers.TryGetValue(typeof(T), out provider))
            {
                return (T)provider;
            }

            return default(T);
        }
    }

}
