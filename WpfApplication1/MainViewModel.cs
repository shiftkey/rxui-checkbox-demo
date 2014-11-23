using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace WpfApplication1
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            UpdateTimestampCommand = ReactiveCommand.CreateAsyncObservable(o =>
            {
                var val = (bool) o;
                if (val)
                {
                    CheckedTimeStamp = "Checked at " + DateTime.Now.ToString();
                }
                else
                {
                    CheckedTimeStamp = "Unchecked at " + DateTime.Now.ToString();
                }
                return Observable.Return<object>(null);
            });

        }

        string _checkedTimeStamp;
        public string CheckedTimeStamp
        {
            get { return _checkedTimeStamp; }
            private set { this.RaiseAndSetIfChanged(ref _checkedTimeStamp, value); }
        }

        public ReactiveCommand<object> UpdateTimestampCommand { get; private set; }
    }
}
