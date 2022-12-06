using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gigi
{
    /// <summary>
    /// Логика взаимодействия для UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Page
    {
        DBManager manager = new DBManager();
        public UpdateUser()
        {
            InitializeComponent();
            ComboboxRole.SelectedIndex = DBManager.UserRole - 1;
            ComboboxRole.ItemsSource = manager.db.Role.Select(o => o.NameRole).ToList();
            TextboxLogin.Text = DBManager.Login;
            Password.Password = DBManager.Password;
            TextboxName.Text = DBManager.Name;
        }
        private void ButtonAddphoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dig = new Microsoft.Win32.OpenFileDialog();
            dig.FileName = "Фото"; //имя файла по умолчанию
            dig.DefaultExt = ".png";
            dig.Filter = "Фото (.png)|*.png";
            Nullable<bool> result = dig.ShowDialog();
            if (result == true)
            {
                //открываем документ
                Photo.Source = new BitmapImage(new Uri(dig.FileName));
                DBManager.file = dig.FileName;
            }
        }
        private void ButtonUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            //проверяем заполненность полей
            if (TextboxLogin.Text.Length != 0 && Password.Password.Length != 0 && TextboxName.Text.Length != 0
            && ComboboxRole.SelectedIndex != 0)
            {
                manager.UpdateUser(TextboxLogin.Text, Password.Password, TextboxName.Text, ComboboxRole.SelectedIndex, DBManager.file);
                MessageBox.Show("Пoльзoвaтeль успешно изменен");
                FrameManager.MainFrame.GoBack();
            }
            else
                MessageBox.Show("3anonHHTe все поля");
            }
    }
}
