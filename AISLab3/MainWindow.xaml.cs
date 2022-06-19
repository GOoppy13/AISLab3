using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AISLab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Laptop[] laptops = new Laptop[]
               {
                new Laptop { Id = 0, Company = "ASUS", Model = "Laptop 14 F415EA-EB736", CPU = "Intel Pentium Gold 7505", RAM = 8, Price = 30999, StoreId = 0},
                new Laptop { Id = 1, Company = "HP", Model = "15s-eq1322ur", CPU = "AMD 3020e", RAM = 8, Price = 32999, StoreId = 1},
                new Laptop { Id = 2, Company = "Acer", Model = "Aspire 3 A315-56-34Q8", CPU = "Intel Core i3-1005G1", RAM = 4, Price = 34999, StoreId = 2},
                new Laptop { Id = 3, Company = "HP", Model = "Laptop 15s-eq1142ur", CPU = "AMD Athlon Silver 3050U", RAM = 8, Price = 36999, StoreId = 0},
                new Laptop { Id = 4, Company = "Acer", Model = "Swift 3 SF314-43", CPU = "AMD Ryzen 3 5300U", RAM = 8, Price = 42999, StoreId = 1},
                new Laptop { Id = 5, Company = "ASUS", Model = "Laptop 14 D415DA-EK614T", CPU = "AMD Ryzen 3 3250U", RAM = 8, Price = 44999, StoreId = 2},
                new Laptop { Id = 6, Company = "HP", Model = "15s-fq2018ur", CPU = "Intel Core i3-1115G4", RAM = 8, Price = 47999, StoreId = 0},
                new Laptop { Id = 7, Company = "ASUS", Model = "VivoBook Flip 14 TM420UA-EC063T", CPU = "AMD Ryzen 3 5300U", RAM = 4, Price = 49999, StoreId = 1},
                new Laptop { Id = 8, Company = "Lenovo", Model = "IdeaPad Flex 5 14ALC05", CPU = "AMD Ryzen 3 5300U", RAM = 8, Price = 51999, StoreId = 2},
                new Laptop { Id = 9, Company = "HP", Model = "Pavilion Aero 13-be0050ur", CPU = "AMD Ryzen 5 5600U", RAM = 8, Price = 55999, StoreId = 0},
                new Laptop { Id = 10, Company = "ASUS", Model = "VivoBook 15 X513EA-BQ2370W", CPU = "Intel Core i3-1115G4", RAM = 8, Price = 58699, StoreId = 1},
                new Laptop { Id = 11, Company = "Acer", Model = "Aspire 3 A315-56-71MM", CPU = "Intel Core i7-1065G7", RAM = 8, Price = 61999, StoreId = 2},
                new Laptop { Id = 12, Company = "Lenovo", Model = "Yoga Slim 7 14ARE05", CPU = "AMD Ryzen 5 4500U", RAM = 8, Price = 64999, StoreId = 0},
                new Laptop { Id = 13, Company = "Dell", Model = "Inspiron 5515-0363", CPU = "AMD Ryzen 7 5700U", RAM = 8, Price = 65999, StoreId = 1},
                new Laptop { Id = 14, Company = "HP", Model = "Pavilion Aero 13-be0005ur", CPU = "AMD Ryzen 5 5600U", RAM = 16, Price = 69999, StoreId = 2},
               };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(Laptop l in laptops)
            {
                listBoxLaptops.Items.Add(l.Id + " - " + l.Model);
                if (!comboBoxM.Items.Contains(l.Company))
                {
                    comboBoxM.Items.Add(l.Company);
                    comboBoxM2.Items.Add(l.Company);
                }
                if (!comboBoxC.Items.Contains(l.CPU))
                {
                    comboBoxC.Items.Add(l.CPU);
                }
            }
        }

        private void listBoxLaptops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockInfo.Text = laptops[listBoxLaptops.SelectedIndex].ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string company = comboBoxM.SelectedItem as string;
            var result = from l in laptops where l.Company == company select l;
            string str = "";
            foreach (var l in result)
            {
                str += '\n' + l.ToString() + '\n'; 
            }
            MessageBox.Show(str, $"Данные о ноутбуках производителя {company}");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string cpu = comboBoxC.SelectedItem as string;
            var result = from l in laptops where l.CPU == cpu select l;
            string str = "";
            foreach(var l in result)
            {
                str += l.Model + '\n';
            }
            MessageBox.Show(str, $"Модели ноутбуков с процессорами {cpu}");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int ram = int.Parse(textBoxR.Text);
            var result = from l in laptops where l.RAM > ram select l;
            string str = string.Format("{0} шт.", result.Count());
            MessageBox.Show(str, $"Число ноутбуков с памятью более {ram}");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int p1 = int.Parse(textBoxP1.Text);
            int p2 = int.Parse(textBoxP2.Text);
            var result = from l in laptops where l.Price >= p1 && l.Price <= p2 select l;
            string str = "";
            foreach (var l in result)
            {
                str += '\n' + l.ToString() + '\n';
            }
            MessageBox.Show(str, $"Ноутбуки с ценой от {p1} до {p2}");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            string company = comboBoxM2.SelectedItem as string;
            var result = from l in laptops where l.Company == company select l.Price;
            string str = string.Format($"{result.Average()} руб");
            MessageBox.Show(str, $"Средняя цена ноутбуков производителя {company}");
        }
    }
}
