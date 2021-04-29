using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ttnn
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Page1()
        {
            InitializeComponent();
        }

        public void load_KH()
        {
            //Load dữ liệu trên comboBox Khóa học
            var khoahoc = from kh in db.KHOAHOCs
                          select new { kho = kh.KhoaHoc1, ten = kh.TenKhoaHoc };
            cboKhoaHoc.ItemsSource = khoahoc;
            cboKhoaHoc.DisplayMemberPath = "ten";
            cboKhoaHoc.SelectedValuePath = "kho";
        }

        public void load_Data()
        {
            //Load dữ liệu lên DataGird
            var query = (from dt in db.TTHVs
                         select new TestModel
                         {
                             Ca = dt.KHOAHOC1.Ca,
                             HoTen = dt.HoTen,
                             NamSinh = dt.NamSinh,
                             QueQuan = dt.QueQuan,
                             KhoaHoc = dt.KhoaHoc,
                             TenKhoaHoc = dt.KHOAHOC1.TenKhoaHoc,
                             GiaoVien = dt.KHOAHOC1.GiaoVien,
                         }).ToList();

            data1.ItemsSource = query;
        }

        private void pageDK_Load(object sender, RoutedEventArgs e)
        {
            load_KH();
            load_Data();
        }

        private void btnDangKi_Click(object sender, RoutedEventArgs e)
        {
            var hv = new TTHV
            {
                HoTen = txtTen.Text,
                NamSinh = txtNamSinh.Text,
                QueQuan = txtQQ.Text,
                KhoaHoc = cboKhoaHoc.SelectedValue.ToString()
            };
            db.TTHVs.InsertOnSubmit(hv);
            db.SubmitChanges();
            load_Data();
            txtTen.Clear();
            txtQQ.Clear();
            txtNamSinh.Clear();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var query = from xoa in db.TTHVs
                        where xoa.HoTen == txtTen.Text
                        select xoa;

            foreach (var xoa in query)
            {
                db.TTHVs.DeleteOnSubmit(xoa);
            }

            db.SubmitChanges();
            load_Data();
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var query = from tim in db.TTHVs
                        where tim.HoTen.EndsWith(txtTim.Text)
                        select new
                        {
                            tim.HoTen,
                            tim.NamSinh,
                            tim.QueQuan,
                            tim.KhoaHoc,
                            tim.KHOAHOC1.TenKhoaHoc,
                            tim.KHOAHOC1.GiaoVien,
                            tim.KHOAHOC1.Ca
                        };
            data1.ItemsSource = query;
        }

        //private void data1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int i = data1.SelectedIndex;
        //    if (i >= 0)
        //    {
        //        TTHV hv = (TTHV)data1.Items.GetItemAt(i);
        //        txtTen.Text = hv.HoTen;
        //        txtNamSinh.Text = hv.NamSinh;
        //        txtQQ.Text = hv.QueQuan;
        //        //cboKhoaHoc.SelectedItem = hv.KhoaHoc;
        //    }
        //}

        private void data1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = data1.SelectedIndex;
            if (i >= 0 && i < data1.Items.Count - 1)
            {
                var hv = (TestModel)data1.SelectedItem;

                txtTen.Text = hv.HoTen;
                txtNamSinh.Text = hv.NamSinh;
                txtQQ.Text = hv.QueQuan;
                cboKhoaHoc.SelectedValue = hv.KhoaHoc.ToString();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var query = from hv in db.TTHVs
                        where hv.HoTen == txtTen.Text
                        select hv;
            foreach (var hv in query)
            {
                hv.HoTen = txtTen.Text;
                hv.NamSinh = txtNamSinh.Text;
                hv.QueQuan = txtQQ.Text;
                hv.KhoaHoc = cboKhoaHoc.SelectedValue.ToString();

            }
            db.SubmitChanges();
            load_Data();
        }
    }

    public class TestModel
    {
        public string HoTen { get; set; }
        public string NamSinh { get; set; }
        public string QueQuan { get; set; }
        public string KhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public string GiaoVien { get; set; }
        public string Ca { get; set; }
    }

}
