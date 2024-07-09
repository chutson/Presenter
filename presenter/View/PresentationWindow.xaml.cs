﻿using presenter.ViewModel;
using System.Windows;
using System.Windows.Navigation;

namespace presenter.View
{
    /// <summary>
    /// Interaction logic for PresentationWindow.xaml
    /// </summary>
    public partial class PresentationWindow : Window
    {
        public PresentationWindow(PlaylistViewModel viewModel)
        {
            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            InitializeComponent();
            imgContent.Visibility = Visibility.Visible;
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}
