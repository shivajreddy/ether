using Microsoft.UI.Xaml;
using System.ComponentModel;

namespace CounterApp
{
	public sealed partial class MainWindow : Window
	{
		private CounterViewModel _viewModel;

		public MainWindow()
		{
			this.InitializeComponent();
			_viewModel = new CounterViewModel();
			this.Content = new MainPage(_viewModel);
		}
	}

	public class CounterViewModel : INotifyPropertyChanged
	{
		private int _count = 0;

		public int Count
		{
			get => _count;
			set
			{
				if (_count != value)
				{
					_count = value;
					OnPropertyChanged("Count");
				}
			}
		}

		public void Increment()
		{
			Count++;
		}

		public void Decrement()
		{
			Count--;
		}

		public void Reset()
		{
			Count = 0;
		}


		public event PropertyChangedEventHandler? PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
