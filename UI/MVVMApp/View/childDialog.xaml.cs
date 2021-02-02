using MVVMApp.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MVVMApp.View
{
    /// <summary>
    /// Interaction logic for childDialog.xaml
    /// </summary>
    public partial class childDialog : Window
    {
        public childDialog()
        {
            InitializeComponent();
            DataContext = new ItemInfoViewModel();
        }
    }
}
