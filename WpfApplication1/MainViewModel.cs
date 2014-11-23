using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace WpfApplication1
{
    public class MainViewModel : ReactiveObject, IDisposable
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

        public void SetInitialState(bool isChecked)
        {
            IsChecked = isChecked;
            _trackChanges = this.WhenAnyValue(vm => vm.IsChecked)
                .Skip(1)
                .SelectMany(x => UpdateTimestampCommand.ExecuteAsync(x))
                .Subscribe();
        }

        string _checkedTimeStamp;
        public string CheckedTimeStamp
        {
            get { return _checkedTimeStamp; }
            private set { this.RaiseAndSetIfChanged(ref _checkedTimeStamp, value); }
        }

        public ReactiveCommand<object> UpdateTimestampCommand { get; private set; }

        bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { this.RaiseAndSetIfChanged(ref _isChecked, value); }
        }

        IDisposable _trackChanges;
        public void Dispose()
        {
            if (_trackChanges != null)
            {
                _trackChanges.Dispose();
                _trackChanges = null;
            }
        }
    }
}
