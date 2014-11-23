using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace WpfApplication1
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            CheckedTimeStampCommand = ReactiveCommand.CreateAsyncObservable(o =>
            {
                CheckedTimeStamp = DateTime.Now.ToString();
                return Observable.Return<object>(null);
            });

            UncheckedTimeStampCommand = ReactiveCommand.CreateAsyncObservable(o =>
            {
                UncheckedTimeStamp = DateTime.Now.ToString();
                return Observable.Return<object>(null);
            });
        }

        string _checkedTimeStamp;
        public string CheckedTimeStamp
        {
            get { return _checkedTimeStamp; }
            private set { this.RaiseAndSetIfChanged(ref _checkedTimeStamp, value); }
        }

        string _uncheckedTimeStamp;
        public string UncheckedTimeStamp
        {
            get { return _uncheckedTimeStamp; }
            private set { this.RaiseAndSetIfChanged(ref _uncheckedTimeStamp, value); }
        }



        public IReactiveCommand<object> CheckedTimeStampCommand { get; private set; }

        public IReactiveCommand<object> UncheckedTimeStampCommand { get; private set; }
    }
}
