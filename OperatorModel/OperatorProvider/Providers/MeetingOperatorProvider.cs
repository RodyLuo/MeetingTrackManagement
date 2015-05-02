using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatorModel.Interface;
using EntityLayer;
using ViewModel.QueryProvider;

namespace OperatorModel.OperatorProvider
{
    public class MeetingOperatorProvider : IMeetingOperator
    {

        public TalkView Add(TalkView t)
        {
            //使用工厂模式 提高内存利用率
            using (IMeetingOperator provider = OperatorProviderFactory.GetQueryProvider<IMeetingOperator>())
            {
                //调用Biz层的相关方法
                return new TalkView();
            }
        }

        public TalkView Update(TalkView t)
        {
            //使用工厂模式 提高内存利用率
            using (IMeetingOperator provider = OperatorProviderFactory.GetQueryProvider<IMeetingOperator>())
            {
                //调用Biz层的相关方法
                return new TalkView();
            }
        }

        public bool Delete(TalkView t)
        {
            //使用工厂模式 提高内存利用率
            using (IMeetingOperator provider = OperatorProviderFactory.GetQueryProvider<IMeetingOperator>())
            {
                //调用Biz层的相关方法
                return false;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
