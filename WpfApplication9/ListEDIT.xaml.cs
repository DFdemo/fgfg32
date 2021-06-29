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
    /// Логика взаимодействия для ListEDIT.xaml
    /// </summary>
    public partial class ListEDIT : Window
    {
        DatabaseEntities DB; // подключение к бд через Адо нет
        public ListEDIT(THotel TH) // передаём копию таблицы TH
        {
            InitializeComponent();
            DB = new DatabaseEntities(); // выделение памяти для работы бд
        }

        private void eDIT_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(Id.Text); // конвертация значение в инт
            int Cos = Convert.ToInt32(CountOfStats.Text); // конвертация значение в инт
            DB.THotel.Load(); // подгрузка данных из таблицы отелей

            try
            {
                var gg = MessageBox.Show("", "", MessageBoxButton.YesNo, MessageBoxImage.Question); // вывод окна подтверждения
                if (gg == MessageBoxResult.Yes) // если выбор в окне подтверждения ДА
                {
                    var ED = DB.THotel.Local.Where(predicate => predicate.Id == Ids).FirstOrDefault(); // Сверка по id для создания локального фантома таблицы бд
                    // Данные для изменения //
                    ED.Id = Ids;
                    ED.Name = Name.Text;
                    ED.CointOfStarts = Cos;
                    ED.CountryName = CountryName.Text;
                    //-//
                    DB.SaveChanges(); // сохранение изменений в бд
                    (this.Owner as ListDroch).Windows_Closing(DB); // выборка области из таблицы листдроч в методе Windows_Closing с обращении к бд
                    this.Close(); // Закрытие формы
                }
                else if(gg == MessageBoxResult.No) // если выбор в окне подтверждения НЕТ
                {
                    this.Close(); // Закрытие формы
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            (this.Owner as ListDroch).Windows_Closing(DB); // выборка области из таблицы листдроч в методе Windows_Closing с обращении к бд
            this.Close(); // Закрытие формы
        }
    }
}
