using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CounterApp
{
	public sealed partial class MainPage : Page
	{
		public CounterViewModel ViewModel { get; private set; }

		public MainPage(CounterViewModel viewModel)
		{
			this.InitializeComponent();
			ViewModel = viewModel;
		}

		private void IncrementButton_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.Increment();
		}

		private void DecrementButton_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.Decrement();
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			ViewModel.Reset();
		}
	}
}
