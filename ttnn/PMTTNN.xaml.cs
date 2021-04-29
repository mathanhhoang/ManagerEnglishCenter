using System.Windows;

namespace ttnn
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Window1()
        {
            InitializeComponent();
        }

        private void btnDangKiHocVien_Click(object sender, RoutedEventArgs e)
        {
            Thongtin.Content = new Page1();

        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            
            Thongtin.Content = new Page2();
        }
    }
}
