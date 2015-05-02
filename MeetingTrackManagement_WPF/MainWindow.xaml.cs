using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel.Interface.QueryModel;
using ViewModel.QueryProvider;
using EntityLayer;

namespace MeetingTrackManagement_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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

            Meeting.ItemsSource = talkList;
        }
    }
}
