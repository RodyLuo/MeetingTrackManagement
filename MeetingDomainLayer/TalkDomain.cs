using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;

namespace MeetingDomainLayer
{
    public class TalkDomain
    {
        /// <summary>
        /// 领域模型 最核心的业务逻辑和算法所在层
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        public static Dictionary<string, List<TalkView>> GetBestTalkList(List<string> meeting)
        {
            Dictionary<string, List<TalkView>> result = new Dictionary<string, List<TalkView>>();
            List<string> lines = meeting;
            int len = lines.Count;
            TalkView[] TalkViews = new TalkView[len];

            for (int i = 0; i < len; i++)
            {
                TalkViews[i] = new TalkView();
                TalkViews[i].Name = lines[i]; ;
                string[] items = lines[i].Trim().Split(' ');
                int len2 = items.Length - 1;
                string last = items[len2].ToLower();
                if (last == "lightning")
                {
                    TalkViews[i].Duration = 5;
                }
                else
                {
                    TalkViews[i].Duration = int.Parse(last.Replace("min", ""));
                }
            }

            List<TalkView> t1am = new List<TalkView>();
            List<TalkView> t1pm = new List<TalkView>();
            List<TalkView> t2am = new List<TalkView>();
            List<TalkView> t2pm = new List<TalkView>();

            //贪心算法 每次都会去分配满足最长时间的会议 降序排列
            TalkViews = TalkViews.OrderByDescending(t => t.Duration).ToArray();

            int s1am = 0, s1pm = 0, s2am = 0, s2pm = 0;
            int next = 0;

            for (int i = 0; i < len; i++)
            {
                int duration = TalkViews[i].Duration;

                if (next == 0 && (s1am + duration) <= 180)
                {
                    t1am.Add(TalkViews[i]);
                    s1am += duration;
                    next++;
                }
                else if (next == 1 && (s2am + duration) <= 180)
                {
                    t2am.Add(TalkViews[i]);
                    s2am += duration;
                    next++;
                }
                else if (next == 2 && (s1pm + duration) <= 240)
                {
                    t1pm.Add(TalkViews[i]);
                    s1pm += duration;
                    next++;
                }
                else if (next == 3 && (s2pm + duration) <= 240)
                {
                    t2pm.Add(TalkViews[i]);
                    s2pm += duration;
                    next = 0;
                }
                else
                {
                    i--;
                    next++;
                    if (next == 4) next = 0;
                }
            }

            // 网络事件
            int mins = Math.Max(s1pm, s2pm);
            if (mins < 180) mins = 180; // 不能在4点之前
            DateTime nwe = DateTime.Today.AddHours(13).AddMinutes(mins);

            string key1 = "方案One:";
            List<TalkView> listView1 = new List<TalkView>();
            DateTime dt = DateTime.Today.AddHours(9);

            foreach (TalkView t in t1am)
            {
                TalkView item = new TalkView();
                item.Name = string.Format("{0} {1}", dt.ToString("hh:mmtt"), t.Name);
                item.Duration = t.Duration;
                listView1.Add(item);

                dt = dt.AddMinutes(t.Duration);
            }

            listView1.Add(new TalkView() { Name = "12:00PM Lunch" });
            dt = DateTime.Today.AddHours(13);

            foreach (TalkView t in t1pm)
            {
                TalkView item = new TalkView();
                item.Name = string.Format("{0} {1}", dt.ToString("hh:mmtt"), t.Name);
                item.Duration = t.Duration;
                listView1.Add(item);

                dt = dt.AddMinutes(t.Duration);
            }

            listView1.Add(new TalkView() { Name = string.Format("{0} Networking Event", nwe.ToString("hh:mmtt")) });

            result.Add(key1, listView1);

            string key2 = "方案Two:";
            List<TalkView> listView2 = new List<TalkView>();
            dt = DateTime.Today.AddHours(9);

            foreach (TalkView t in t2am)
            {
                TalkView item = new TalkView();
                item.Name = string.Format("{0} {1}", dt.ToString("hh:mmtt"), t.Name);
                item.Duration = t.Duration;
                listView2.Add(item);

                dt = dt.AddMinutes(t.Duration);
            }

            listView2.Add(new TalkView() { Name = "12:00PM Lunch" });
            dt = DateTime.Today.AddHours(13);

            foreach (TalkView t in t2pm)
            {
                TalkView item = new TalkView();
                item.Name = string.Format("{0} {1}", dt.ToString("hh:mmtt"), t.Name);
                item.Duration = t.Duration;
                listView2.Add(item);

                dt = dt.AddMinutes(t.Duration);
            }

            listView2.Add(new TalkView() { Name = string.Format("{0} Networking Event", nwe.ToString("hh:mmtt")) });

            result.Add(key2, listView2);

            return result;
        }
    }
}
