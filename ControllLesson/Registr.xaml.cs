using DataAccess;
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

namespace ControllLesson
{
  /// <summary>
  /// Логика взаимодействия для Registr.xaml
  /// </summary>
  public partial class Registr : Window
  {
    public Registr()
    {
      InitializeComponent();
    }

    private void signInButton_Click(object sender, RoutedEventArgs e)
    {
      var login = NewLoginTextBox.Text;
      var password = NewPasswordBox.Text;

      if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
      {
        MessageBox.Show("Заполните все поля");
        return;
      }

      using (var context = new SecurityContext())
      {
        var register = context.Registers.FirstOrDefault(searchingRegister => searchingRegister.NewLogin == login);
        if (register != null && DataEncryptor.IsValidPassword(password, register.NewPassword))
        {
          MainWindow mainWindow = new MainWindow();
          mainWindow.Show();
        }
        else
        {
          MessageBox.Show("Пшёл вон!");
        }
      }
    }
  }
}
