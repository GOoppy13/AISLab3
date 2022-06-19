using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AISLab3._2
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument docEmployees = XDocument.Load("employees.xml");
            var employees = from employe in docEmployees.Descendants("работник")
                        select employe;
            foreach (var employe in employees)
            {
                EmployeesDataGrid.Items.Add(new
                {
                    Id = (string)employe.Attribute("код"),
                    FIO = (string)employe.Element("фио"),
                    CarId = (string)employe.Attribute("номер_машины"),
                });
            }
        }
    }
}
