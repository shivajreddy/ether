using Microsoft.UI.Xaml;
using System.ComponentModel;


namespace Ether
{
	public sealed partial class MainWindow : Window
	{
		// Properties
		int count = 0;

		private MainViewModel _viewModel;

		// Constructor
		public MainWindow()
		{
			this.InitializeComponent();
			_viewModel = new MainViewModel();
			this.Content = new MainWindow(_viewModel);
		}

	}

	public class MainViewModel : INotifyPropertyChanged
	{
		private string _name = "";

		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					OnPropertyChanged(nameof(Name));
					OnPropertyChanged(nameof(Greeting));
				}
			}
		}

		public string Greeting => $"Hello, {Name}!";

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
