using System;
using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;

namespace WpfApplication1
{
    public partial class MainWindow : IViewFor<MainViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            // KIDS: DO NOT TRY THIS AT HOME
            var viewmodel = new MainViewModel();
            ViewModel = viewmodel;

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.CheckedTimeStamp, v => v.checkedText.Text);

                d(Observable.FromEventPattern<RoutedEventHandler, EventArgs>(
                    x => checkbox.Checked += x,
                    x => checkbox.Checked -= x)
                    .Select(x => true)
                    .SelectMany(x => ViewModel.UpdateTimestampCommand.ExecuteAsync(x))
                    .Subscribe());

                d(Observable.FromEventPattern<RoutedEventHandler, EventArgs>(
                    x => checkbox.Unchecked += x,
                    x => checkbox.Unchecked -= x)
                    .Select(x => false)
                    .SelectMany(x => ViewModel.UpdateTimestampCommand.ExecuteAsync(x))
                    .Subscribe());
            });

        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as MainViewModel; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof (MainViewModel), typeof (MainWindow), new PropertyMetadata(default(MainViewModel)));

        public MainViewModel ViewModel
        {
            get { return (MainViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

    }
}
