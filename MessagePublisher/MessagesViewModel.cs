using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessagePublisher
{
    /// <summary>
    /// Your TODO: please follow insstruction 
    /// </summary>
    public class MessagesViewModel : IMessagesViewModel
    {
        private readonly IDispatcher _dispatcher;
        private MyCommand _commandHandler;
        private IEnumerable<UserQueue> _observedUsers;

        MessagesViewModel()
        {
            _observedUsers = Globals.GetRandomDataForAllUsers();
            SelectedUser = ObservedUsers.First();
            ToDate = DateTime.Now;
            TimeSpan _timespan = new TimeSpan(365, 0, 0, 0, 0);
            FromDate = ToDate.Subtract(_timespan);
        }

        public MessagesViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;            
        }


        string UserName
        {
            get
            {
                return _observedUsers.First().Owner; 
            }
        }

        UserQueue SelectedUser
        {
            get;
            set;
        }

        IEnumerable<UserQueue> ObservedUsers
        {
            get
            {
                return _observedUsers;
            }
        }

        string NewMessageText
        {
            get;

            set;

        }

        ICommand PublishCommand
        {
            get { return _commandHandler; }
        }

        DateTime FromDate
        {
            get;
            set;
        }

        DateTime ToDate
        {
            get;
            set;
        }

        string TextFilter
        {
            get;
            set;
        }

        ICommand FilterCommand
        {
            get { return _commandHandler; }
        }

        IEnumerable<Message> FilteredMessages
        {
            
            get
            {
                return Filter();
            }
        }

        ICommand SaveCommand
        {
            get { return _commandHandler; }
        }

        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        IEnumerable<Message> Filter()
        {
            var resultList = new List<Message>();

            if (!String.IsNullOrEmpty(TextFilter) && SelectedUser != null && SelectedUser.Messages.Count != null && SelectedUser.Messages.Count > 0)
            {
                DateMessageSearcher dataSearcher = new DateMessageSearcher(this.FromDate, this.ToDate);
                TextMessageSearcher textSearcher = new TextMessageSearcher(TextFilter);

            }
            return resultList;
        }
    }
}
