using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatorModel.Interface;
using EntityLayer;
using OperatorModel.OperatorProvider;

namespace OperatorModel.Facade
{
    class MeetingOperatorFacade
    {
        /// <summary>
        /// 这里只写一个例子 设计成这样子是为了程序在调用的时候读写分离 
        /// 如果写操作是webservice的话 在facade中调用webservice即可 
        /// 方便与分布部署。
        /// </summary>
        private IMeetingOperator iOperator;
        

        public MeetingOperatorFacade()
        {
            iOperator = new MeetingOperatorProvider();
        }

        public MeetingOperatorFacade(IMeetingOperator ator)
        {
            iOperator = ator;
        }

        /// <summary>
        /// 新增操作
        /// </summary>
        /// <returns></returns>
        public TalkView AddMeeting(TalkView view) {
            if (iOperator != null)
            {
                return iOperator.Add(view);
            }
            return null;
        }
    }
}
