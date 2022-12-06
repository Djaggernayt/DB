using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gigi
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        DBManager manager = new DBManager();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnRegist_Click(object sender, RoutedEventArgs e)
        {
            if(TextboxLoginReg.Text.Length>0&&PasswordParolReg.Password.Length>0)
            {
                if(manager.Reg(TextboxLoginReg.Text,PasswordParolReg.Password,TextboxNameReg.Text,DBManager.file))
                {
                    MessageBox.Show("Регистрация прошла успешно");
                    FrameManager.MainFrame.Navigate(new AutorizationPage());
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }

        private void BtnNewPhoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dl = new Microsoft.Win32.OpenFileDialog();
            dl.FileName = "Фото";
            dl.DefaultExt = ".png";
            Nullable<bool> result = dl.ShowDialog();
            if(result==true)
            {
                PhotoReg.Source = new BitmapImage(new Uri(dl.FileName));
                DBManager.file = dl.FileName;
            }
        }
    }
}
