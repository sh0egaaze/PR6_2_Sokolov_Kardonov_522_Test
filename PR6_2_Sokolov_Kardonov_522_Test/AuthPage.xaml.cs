using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing; 

namespace PR6_2_Sokolov_Kardonov_522_Test
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private int _failedAttempts = 0;
        internal string _currentCaptchaText;

        public AuthPage()
        {
            InitializeComponent();
        }

        public bool Auth(string login, string password)
        {
            if (CaptchaPanel.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Сначала введите капчу правильно!");
                return false;
            }

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }

            using (var db = new Entities())
            {
                var user = db.User.FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    MessageBox.Show($"Здравствуйте, {user.Role} {user.FIO.Split(' ')[1]}!");
                    _failedAttempts = 0;
                    return true;
                }
                else
                {
                    _failedAttempts++;
                    if (_failedAttempts >= 3)
                    {
                        ShowCaptcha();
                    }
                    MessageBox.Show("Неверный логин или пароль!");
                    return false;
                }
            }
        }

        private void ShowCaptcha()
        {
            _currentCaptchaText = GenerateRandomString(5);
            CaptchaImage.Source = GenerateCaptchaImage(_currentCaptchaText);
            CaptchaPanel.Visibility = Visibility.Visible;
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private BitmapImage GenerateCaptchaImage(string text)
        {
            using (var bitmap = new System.Drawing.Bitmap(200, 50))
            using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.White);

                var random = new Random();

                for (int i = 0; i < 100; i++)
                {
                    using (var brush = new System.Drawing.SolidBrush(
                        System.Drawing.Color.FromArgb(
                            random.Next(256), random.Next(256), random.Next(256))))
                    {
                        graphics.FillEllipse(brush, random.Next(200), random.Next(50), 2, 2);
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    using (var pen = new System.Drawing.Pen(
                        System.Drawing.Color.FromArgb(
                            random.Next(256), random.Next(256), random.Next(256)), 1))
                    {
                        graphics.DrawLine(pen,
                            new System.Drawing.Point(random.Next(200), random.Next(50)),
                            new System.Drawing.Point(random.Next(200), random.Next(50)));
                    }
                }

                using (var font = new System.Drawing.Font("Arial", 20,
                    System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))
                using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        graphics.DrawString(text[i].ToString(), font, brush,
                            20 + i * 30, 10 + (int)(Math.Sin(i) * 5));
                    }
                }

                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    memory.Position = 0;

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();

                    return bitmapImage;
                }
            }
        }

        public Visibility GetCaptchaVisibility()
        {
            return CaptchaPanel.Visibility;
        }

        public string GetCurrentCaptchaText()
        {
            return _currentCaptchaText;
        }

        public void BtnCheckCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaTextBox.Text.Equals(_currentCaptchaText, StringComparison.OrdinalIgnoreCase))
            {
                CaptchaPanel.Visibility = Visibility.Collapsed;
                _failedAttempts = 0;
                CaptchaTextBox.Text = "";
                MessageBox.Show("Капча введена верно!");
            }
            else
            {
                MessageBox.Show("Неверная капча! Попробуйте еще раз.");
                ShowCaptcha();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Auth(TextBoxLogin.Text, PasswordBox.Password);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}