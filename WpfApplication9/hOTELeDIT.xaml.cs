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
    /// Логика взаимодействия для hOTELeDIT.xaml
    /// </summary>
    public partial class hOTELeDIT : Window
    {
        DatabaseEntities DB;
        public hOTELeDIT(THotel TH)
        {
            InitializeComponent();
            DB = new DatabaseEntities();
        }

        private void eDIT_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(Id.Text);
            int Cos = Convert.ToInt32(CountOfStats.Text);
            DB.THotel.Load();
            var ED = DB.THotel.Local.Where(predicate => predicate.Id == Ids).FirstOrDefault();
            

            ED.Id = Ids;
            ED.Name = Name.Text;
            ED.CointOfStarts = Cos;
            ED.CountryName = CountryName.Text;
            DB.SaveChanges();

            (this.Owner as HotelTable).Windows_Closing(DB);
            this.Close();
        }
    }
}
