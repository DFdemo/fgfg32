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
    /// Логика взаимодействия для ListAdd.xaml
    /// </summary>
    public partial class ListAdd : Window
    {
        DatabaseEntities DB; // подключение к бд через Адо нет
        public ListAdd()
        {
            InitializeComponent();
            DB = new DatabaseEntities();// выделение памяти для работы бд
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(Id.Text); // конвертация значение в инт
            int Cos = Convert.ToInt32(CountOfStats.Text); // конвертация значение в инт
            DB.THotel.Load(); // подгрузка данных из таблицы отелей
            DB.THotel.Add(new THotel { Id = Ids, Name = Name.Text, CointOfStarts = Cos, CountryName = CountryName.Text }); // Запрос на добавленние данный введенных в поля textbox
            DB.SaveChanges(); // сохранение изменений в бд
            this.Close(); // закрытие формы
        }
    }
}
