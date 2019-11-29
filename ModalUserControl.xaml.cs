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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModalWPF
{
    /// <summary>
    /// Interaction logic for ModalUserControl.xaml
    /// </summary>
    public partial class ModalUserControl : UserControl
    {
        public ModalUserControl()
        {
            Visibility = Visibility.Hidden;
            InitializeComponent();
        }

        public void Show(object content = null)
        {
            Visibility = Visibility.Visible;
            if (content != null)
                AddChild(content);
        }

        public void Hide()
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
