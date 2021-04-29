using System.Windows.Controls;
using System.Data;
using System.Linq;
using System.Windows;

namespace ttnn
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Page2()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var query = from tk in db.KHOAHOCs
                        join hv in db.TTHVs
                        on tk.KhoaHoc1 equals hv.KhoaHoc
                        group tk by new {
                            tk.KhoaHoc1,
                            tk.TenKhoaHoc, 
                            tk.GiaoVien, 
                            tk.Ca } into kq
                        select new { 
                            kq.Key.KhoaHoc1,
                            kq.Key.TenKhoaHoc,
                            kq.Key.GiaoVien,
                            kq.Key.Ca,
                            So_Luong_HV = kq.Count() };
            data2.ItemsSource = query;
        }
    }
}
