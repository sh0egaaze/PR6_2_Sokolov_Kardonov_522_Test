using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PR6_2_Sokolov_Kardonov_522_Test
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        public bool Register(string fio, string login, string password, string gender, string role, string phone, string photoUrl)
        {
            if (string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(phone))
            {
                return false;
            }

            using (var db = new Entities())
            {
                if (db.User.Any(u => u.Login == login))
                {
                    return false;
                }

                var user = new User
                {
                    FIO = fio,
                    Login = login,
                    Password = password,
                    Role = role,
                    Gender = gender,
                    PhoneNumber = phone,
                    PhotoURL = photoUrl
                };

                db.User.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string gender = (CmbGender.SelectedItem as ComboBoxItem)?.Content.ToString();
            string photoUrl = TextBoxPhoto.Text;

            if (Register(TextBoxFIO.Text, TextBoxLogin.Text, PasswordBox.Password, CmbRole.Text, TextBoxPhone.Text, gender, photoUrl))
            {
                MessageBox.Show("Регистрация прошла успешно!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации: проверьте введенные данные.");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFIO.Text = "";
            TextBoxLogin.Text = "";
            PasswordBox.Password = "";
            CmbGender.SelectedIndex = 0;
            CmbRole.SelectedIndex = 0;
            TextBoxPhone.Text = "";
            TextBoxPhoto.Text = "";
            NavigationService.GoBack();
        }
    }
}