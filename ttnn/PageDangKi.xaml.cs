using System.Windows;
using System.Windows.Controls;

namespace ttnn
{
    /// <summary>
    /// Interaction logic for PageDangKi.xaml
    /// </summary>
    public partial class PageDangKi : Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public PageDangKi()
        {
            InitializeComponent();
        }

        private void btnCreat_Click(object sender, RoutedEventArgs e)
        {
            var nd = new DANGNHAP
            {
                ID = txtNhapID.Text,
                MatKhau = txtNhapPassword.Password,
                NameID = txtNhapTen.Text,
                NamSinhID = txtNhapNamSinh.Text,
                QQID = txtNhapQQ.Text
            };

            db.DANGNHAPs.InsertOnSubmit(nd);
            db.SubmitChanges();

            MessageBox.Show("Đăng kí thành công");

            txtNhapID.Clear();
            txtNhapPassword.Clear();
            txtNhapTen.Clear();
            txtNhapNamSinh.Clear();
            txtNhapQQ.Clear();
        }
    }
}
