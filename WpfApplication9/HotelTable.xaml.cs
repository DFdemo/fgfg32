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
    /// Логика взаимодействия для HotelTable.xaml
    /// </summary>
    public partial class HotelTable : Window
    {
        DatabaseEntities DB;
        public HotelTable()
        {
            InitializeComponent();
            DB = new DatabaseEntities();
            DB.THotel.Load();
            Gridus.ItemsSource = DB.THotel.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            hOTELaDD hd = new hOTELaDD();
            hd.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Gridus.SelectedItem != null)
            {
                try
                {
                    hOTELeDIT HE = new hOTELeDIT(Gridus.SelectedItem as THotel);
                    HE.Owner = this;
                    HE.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Windows_Closing(DatabaseEntities DBS)
        {
            try
            {
                DB = DBS;
                Gridus.ItemsSource = DB.THotel.Local.ToBindingList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(Gridus.SelectedItem != null)
            {
                try
                {
                    var msbq = MessageBox.Show("fdd", "asf", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(msbq == MessageBoxResult.Yes)
                    {
                        DB.THotel.Remove(Gridus.SelectedItem as THotel);
                        DB.SaveChanges();
                        DB.THotel.Load();
                        Gridus.ItemsSource = DB.THotel.Local.ToBindingList();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB.THotel.Load();
            Gridus.ItemsSource = DB.THotel.Local.ToBindingList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
