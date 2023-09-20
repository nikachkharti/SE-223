using MystatService;
using MystatService.Interfaces;
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

namespace Mystat.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshStudentList();
        }

        private async void RefreshStudentList()
        {
            try
            {
                var allStudents = await _unitOfWork.Student.GetAllStudentsAsync();
                allStudents.ForEach(student => StudentList.Items.Add($"{student.FirstName} {student.LastName}"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "დაფიქსირდა შეცდომა", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
