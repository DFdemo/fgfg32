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
    /// Логика взаимодействия для hOTELaDD.xaml
    /// </summary>
    public partial class hOTELaDD : Window
    {
        DatabaseEntities DB;
        public hOTELaDD()
        {
            InitializeComponent();
            DB = new DatabaseEntities();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int Ids = Convert.ToInt32(Id.Text);
            int Cos = Convert.ToInt32(CountOfStats.Text);
            DB.THotel.Load();
            DB.THotel.Add(new THotel { Id = Ids, Name = Name.Text, CointOfStarts = Cos, CountryName = CountryName.Text });
            DB.SaveChanges();
            this.Close();
        }
    }
}
