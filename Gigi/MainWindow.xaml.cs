using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class FrameManager
    {
        public static Frame MainFrame;
    }

    public class DBManager
    {
        public bd db = new bd();

        public static int UserId;
        public static int UserRole;
        public static string Login;
        public static string Password;
        public static string Name;
        public static int Sel;
        public static int Type;
        public static int Status;
        public static string Text;
        public static string file;

        public bool Auth(string login, string password)
        {
            bool Auth = false;
            int id = 0;
            id = db.Users.AsNoTracking().Where(o => o.Login == login && o.PassWord == password).Select(o => o.IdUsers).FirstOrDefault();
            if (id != 0)
            {
                UserId = id;
                Auth = true;
                UserRole = db.Users.AsNoTracking().Where(o => o.IdUsers == id).Select(o => o.Role).FirstOrDefault();
            }
            return Auth;
        }

        public bool Reg(string login, string password, string name, string ifile)
        {
            bool reg = false;
            if (db.Users.Where(o => o.Login == login).Select(o => o).FirstOrDefault() == null)
            {
                byte[] imagedata = null;
                FileInfo finfo = new FileInfo(ifile);
                long numbytes = finfo.Length;
                FileStream fst = new FileStream(ifile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fst);
                imagedata = br.ReadBytes((int)numbytes);
                string iImageEx = System.IO.Path.GetExtension(ifile).Replace(".", "").ToLower();
                Users user = new Users
                {
                    Login = login,
                    PassWord = password,
                    NameUser = name,
                    Role = 2,
                    Photo = imagedata
                };
                db.Users.Add(user);
                db.SaveChanges();
                reg = true;

            }
            return reg;
        }
        public void AddOrder(string text, int type)
        {
            Order order = new Order
            {
                Text = text,
                Type = type,
                Users = UserId,
                Status = 2
            };
            //заявка пользователя с ролью id=2
            db.Order.Add(order); // добавляем заявку
            db.SaveChanges(); //сохраняем в БД
        }
        //метод редактирования заявки
        public void UpdateOrder(string text, int type, int status)
        {
            //описываем данные заявки
            Order order = db.Order.Where(o => o.IdOrder == Sel).First();
            order.Text = text;
            order.Type = type;
            order.Status = status;
            db.SaveChanges(); //сохраняем в БД
        }
        public void UpdateUser(string login, string password, string name, int role, string iFile)
        { //конвертация изображения в биты
            byte[] imageData = null;
            FileInfo flnfo = new FileInfo(iFile);
            long numBytes = flnfo.Length;
            FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);
            //описываем данные пользователя
            Users us = db.Users.Where(o => o.IdUsers == Sel).First();
            us.Login = login;
            us.PassWord = password;
            us.NameUser = name;
            us.Role = role;
            db.SaveChanges(); //сохраняем в БД]
        }
        public bool dataOrder()
        {
            bool data = false;
            Order ord = db.Order.Where(o => o.IdOrder == Sel).First();
            Text = ord.Text;
            Status = ord.Status;
            Type = ord.Type;
            data = true; return data;
        }
        //сохранение данных пользователя в переменные
        public bool datallser()
        {
            bool data = false;
            Users us = db.Users.Where(o => o.IdUsers == Sel).First();
            Login = us.Login;
            Password = us.PassWord;
            Name = us.NameUser;
            data = true; return data;
        }
        public void removeUser(int selected)
        {
            //находим пользователя в БД по id
            Users selectedUser = db.Users.Where(o => o.IdUsers == selected).Select(o => o).First(); //подсчитываем заявки пользователя
            int count = db.Order.Where(o => o.Users == UserId).Select(o => o).Count();
            //в цикле удаляем заявки
            for (int i = 0; i < count; i ++)
            {
                Order selOrder = db.Order.Where(o => o.Users == UserId).Select(o => o).First();
                db.Order.Remove(selOrder);
                db.SaveChanges();
            }
            //удаляем пользователя из БД
            db.Users.Remove(selectedUser);
            //сохраняем изменения в БД
            db.SaveChanges();
        }
        public void removeOrder(int selected)
        {
            //находим заявку в БД по id
            Order selectedOrder = db.Order.Where(o => o.IdOrder == selected).Select(o => o).First(); //удаляем заявку из БД
db. Order. Remove( selectedOrder); //сохраняем изменения в БД
                                   db.SaveChanges();
        }
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.MainFrame = this.Mainframe;
            Mainframe.Navigate(new AutorizationPage());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Mainframe.GoBack();
        }
        private void Mainframe_ContentRendered(object selender, EventArgs e)
        {
            if (Mainframe.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Collapsed;
            }
        }
    }
}
