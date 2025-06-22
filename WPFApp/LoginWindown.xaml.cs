using BusinessObjects;
using Services;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindown.xaml
    /// </summary>
    public partial class LoginWindown : Window
    {
        private readonly IAccountService iAccountService;
        public LoginWindown()
        {
            InitializeComponent();
            iAccountService = new AccountService();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUser.Text;
                string password = txtPass.Password;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password are required!", "Login Error");
                    return;
                }

                var account = iAccountService.GetAccountById(username);

                if (account != null && account.MemberPassword.Equals(password))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Login Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
