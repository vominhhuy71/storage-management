using MVVMApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ItemViewModel();
            UpdateGrid.Visibility = Visibility.Hidden;
            AddGrid.Visibility = Visibility.Hidden;
        }
        private void lvItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateGrid.Visibility == Visibility.Hidden)
            {
                UpdateGrid.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Hidden;
                AddButton.Visibility = Visibility.Hidden;
                AddGrid.Visibility = Visibility.Hidden;
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (UpdateGrid.Visibility == Visibility.Visible)
            {
                UpdateGrid.Visibility = Visibility.Hidden;
                UpdateButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Visible;
                
                AddGrid.Visibility = Visibility.Hidden;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddGrid.Visibility == Visibility.Hidden)
            {
                AddGrid.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Hidden;
                AddButton.Visibility = Visibility.Hidden;
                
                UpdateGrid.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (AddGrid.Visibility == Visibility.Visible)
            {
                AddGrid.Visibility = Visibility.Hidden;
                UpdateButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Visible;
                
                UpdateGrid.Visibility = Visibility.Hidden;
            }
            ItemViewModel itemViewModel = new ItemViewModel();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateGrid.Visibility == Visibility.Visible)
            {
                UpdateGrid.Visibility = Visibility.Hidden;
                UpdateButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Visible;

                AddGrid.Visibility = Visibility.Hidden;
            }
        }

        private void Return1(object sender, RoutedEventArgs e)
        {
            if (UpdateGrid.Visibility == Visibility.Visible)
            {
                UpdateGrid.Visibility = Visibility.Hidden;
                UpdateButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Visible;               
                AddGrid.Visibility = Visibility.Hidden;
            }
        }

        private void Return2(object sender, RoutedEventArgs e)
        {
            if (AddGrid.Visibility == Visibility.Visible)
            {
                AddGrid.Visibility = Visibility.Hidden;
                UpdateButton.Visibility = Visibility.Visible;
                AddButton.Visibility = Visibility.Visible;

                UpdateGrid.Visibility = Visibility.Hidden;
            }
        }
    }

}
