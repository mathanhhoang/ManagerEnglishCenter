using System.Linq;
using System.Windows;

namespace ttnn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            var id = (from tk in db.DANGNHAPs
                      where tk.ID == txtID.Text.Trim() && tk.MatKhau == txtPassword.Password
                      select tk).SingleOrDefault();

            if (id == null)
            {
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Window1 f = new Window1();

            f.Show();
            Hide();
        }

        private void btnDangKi_Click(object sender, RoutedEventArgs e)
        {
            Dangki.Content = new PageDangKi();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát ứng dụng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Question);
            Close();
        }
    }
}
