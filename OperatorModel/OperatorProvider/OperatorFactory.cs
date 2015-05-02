using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatorModel.Interface;
using OperatorModel.OperatorProvider;

namespace ViewModel.QueryProvider
{
    public class OperatorProviderFactory
    {
        public static Dictionary<Type, IOperator> Providers { get; set; }

        static OperatorProviderFactory()
        {
            Providers = new Dictionary<Type, IOperator>();

            Providers.Add(typeof(IMeetingOperator), new MeetingOperatorProvider());

        }

        public static T GetQueryProvider<T>() where T : IOperator
        {
            IOperator provider;
            if (OperatorProviderFactory.Providers.TryGetValue(typeof(T), out provider))
            {
                return (T)provider;
            }

            return default(T);
        }
    }

}
