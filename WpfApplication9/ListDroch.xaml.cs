using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApplication9
{
    /// <summary>
    /// Логика взаимодействия для ListDroch.xaml
    /// </summary>
    public partial class ListDroch : Window
    {
        DatabaseEntities DB; // подключение к бд через Адо нет
        public ListDroch()
        {
            InitializeComponent();
            DB = new DatabaseEntities(); // выделение памяти для работы бд
            DB.THotel.Load(); // подгрузка данных из таблицы отелей
            Gridus.ItemsSource = DB.THotel.Local.ToBindingList(); // вывод в listbox из таблицы отелей
        }

        private void Add_Click(object sender, RoutedEventArgs e) // добавление
        {
            hOTELaDD hd = new hOTELaDD();
            hd.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e) // редактирование
        {
            if (Gridus.SelectedItem != null) // если выбран элемент
            {
                try
                {
                    var gg = MessageBox.Show("", "", MessageBoxButton.YesNo, MessageBoxImage.Question); // вывод окна подтверждения
                    if (gg == MessageBoxResult.Yes) // если выбор в окне подтверждения ДА
                    {
                        ListEDIT HE = new ListEDIT(Gridus.SelectedItem as THotel); // переход на форму с передачей данных из выбранной строки
                        HE.Owner = this;
                        HE.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Windows_Closing(DatabaseEntities DBS) // в случае закрытия окна listEdit 
        {
            try
            {
                DB = DBS; // присвоение строки из фантомной таблицы в базу
                Gridus.ItemsSource = DB.THotel.Local.ToBindingList(); // вывод в listbox из таблицы отелей
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Gridus.SelectedItem != null) // если выбран элемент
            {
                try
                {
                    var msbq = MessageBox.Show("fdd", "asf", MessageBoxButton.YesNo, MessageBoxImage.Question); // вывод окна подтверждения
                    if (msbq == MessageBoxResult.Yes)  // если выбор в окне подтверждения ДА
                    {
                        DB.THotel.Remove(Gridus.SelectedItem as THotel); // Удаление из таблицы выбранной строки из listbox при использовании в нем таблицы отелей
                        DB.SaveChanges(); // сохранение изменений в бд
                        DB.THotel.Load(); // подгрузка данных из таблицы отелей
                        Gridus.ItemsSource = DB.THotel.Local.ToBindingList(); // вывод в listbox из таблицы отелей
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB.THotel.Load(); // подгрузка данных из таблицы отелей
            Gridus.ItemsSource = DB.THotel.Local.ToBindingList(); // вывод в listbox из таблицы отелей
        }

        private void Back_Click(object sender, RoutedEventArgs e) // вернуться на главную форму
        {

        }
    }
}