using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace KanbanTaskManagementApplication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public List<User> Users = new List<User>();
        public Registration()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string firstname = textBoxFirstName.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else
                {
                    errormessage.Text = "";
                    Users.Add(new User(firstname, email, password));
                    errormessage.Text = "You have Registered successfully.";
                }
            }
        }
    }
}
