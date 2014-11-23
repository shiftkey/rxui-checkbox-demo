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
            viewmodel.SetInitialState(true);
            ViewModel = viewmodel;

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.CheckedTimeStamp, v => v.checkedText.Text);
                this.Bind(ViewModel, vm => vm.IsChecked, v => v.checkbox.IsChecked);
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
