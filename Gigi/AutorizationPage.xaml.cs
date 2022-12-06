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

namespace Gigi
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public DBManager manager = new DBManager();
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new RegistrationPage());
        }

        private void btnenter_Click(object sender, RoutedEventArgs e)
        {
            if (TextboxLogin.Text.Length > 0 && pass.Password.Length > 0)
            {
                if(manager.Auth(TextboxLogin.Text,pass.Password))
                {
                    FrameManager.MainFrame.Navigate(new UserPage());
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
