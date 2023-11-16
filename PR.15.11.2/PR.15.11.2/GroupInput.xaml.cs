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

namespace PR._15._11._2
{
    /// <summary>
    /// Логика взаимодействия для GroupInput.xaml
    /// </summary>
    public partial class GroupInput : Window
    {
        public GroupInput()
        {
            InitializeComponent();
        }
        public string ResponseText
        {
            get { return TB_Result.Text; }
            set { TB_Result.Text = value; }
        }

        private void btn_CreateAndClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
