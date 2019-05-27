using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Practice_27_05
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            var processes = Process.GetProcesses();
            processesGrid.ItemsSource = processes;
        }

        private void KillButtonClick(object sender, RoutedEventArgs e)
        {
            if(processesGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите процесс!");
            }
            else
            {
                try
                {
                    Process toKill = (Process)processesGrid.SelectedItem;
                    toKill.Kill();
                }
                catch(System.ComponentModel.Win32Exception exception)
                {
                    MessageBox.Show($"Невозможно удалить процесс!\n{exception.Message}");
                }
                catch (NotSupportedException exception)
                {
                    MessageBox.Show($"Невозможно удалить процесс!\n{exception.Message}");
                }
                catch(InvalidOperationException exception)
                {
                    MessageBox.Show($"Невозможно удалить процесс!\n{exception.Message}");
                }

            }
        }
    }
}
