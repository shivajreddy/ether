﻿using Microsoft.UI.Xaml;


namespace CounterApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
		{
			m_window = new MainWindow();
			m_window.Activate();
		}

		private Window? m_window;
	}
}
