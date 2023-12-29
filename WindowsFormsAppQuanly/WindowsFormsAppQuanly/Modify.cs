using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsAppQuanly
{
    internal class Modify
    {
       SqlDataAdapter dataAdapter; //truy xuất dữ liệu vào bảng
        //Dataset trả về nhiều bảng
        //Datatable trả về một bảng
       public Modify() { }
       SqlCommand sqlCommand;//dùng để truy vấn câu lệnh insert, update,delete,...
       private SqlDataReader dataReader;
       SqlDataReader sqlDataReader;//dùng để đọc dữ liệu trong bảng
       public List<NHANVIEN> TaiKhoans(string query)//check tai khoan
        {
            List<NHANVIEN> TaiKhoans = new List<NHANVIEN>();
            using(SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query,sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    TaiKhoans.Add(new NHANVIEN(dataReader.GetString(7), dataReader.GetString(8)));
                }


                sqlConnection.Close();
            }
            return TaiKhoans;
        }
        public void Command(string query)//dang ky tai khoan
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                sqlCommand = new SqlCommand (query,sqlConnection);
                sqlCommand.ExecuteNonQuery();//thuc thi cau truy van
                sqlConnection.Close();
            }
        }
        //nhanvien
        public DataTable getAllNhanvien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from NHANVIEN";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection()) {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query,sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


                return dataTable;
        }

        

        public bool insert(nhanvien1 nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into NHANVIEN values (@MaNV,@TenNV,@Ngaysinh,@DiachiNV,@SDTNV,@Chucvu,@Email,@Taikhoan,@MatKhau)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.MaNV1;
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.Hoten1;
                sqlCommand.Parameters.Add("@Ngaysinh", SqlDbType.DateTime).Value = nhanVien.Ngaysinh1;
                sqlCommand.Parameters.Add("@DiachiNV", SqlDbType.NVarChar).Value = nhanVien.Diachi1;
                sqlCommand.Parameters.Add("@SDTNV", SqlDbType.NVarChar).Value = nhanVien.Sdt1;
                sqlCommand.Parameters.Add("@Chucvu", SqlDbType.NVarChar).Value = nhanVien.Chucvu1;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nhanVien.Email1;
                sqlCommand.Parameters.Add("@Taikhoan", SqlDbType.NVarChar).Value = nhanVien.Taikhoan1;
                sqlCommand.Parameters.Add("@Matkhau", SqlDbType.NVarChar).Value = nhanVien.Matkhau1;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool update(nhanvien1 nhanVien)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update NHANVIEN set TenNV = @TenNV,Ngaysinh = @Ngaysinh,DiachiNV = @DiachiNV,SDTNV = @SDTNV,Chucvu = @Chucvu,Email = @Email,Taikhoan = @Taikhoan,Matkhau = @MatKhau where MaNV=@MaNV";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.MaNV1;
                sqlCommand.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.Hoten1;
                sqlCommand.Parameters.Add("@Ngaysinh", SqlDbType.DateTime).Value = nhanVien.Ngaysinh1;
                sqlCommand.Parameters.Add("@DiachiNV", SqlDbType.NVarChar).Value = nhanVien.Diachi1;
                sqlCommand.Parameters.Add("@SDTNV", SqlDbType.NVarChar).Value = nhanVien.Sdt1;
                sqlCommand.Parameters.Add("@Chucvu", SqlDbType.NVarChar).Value = nhanVien.Chucvu1;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nhanVien.Email1;
                sqlCommand.Parameters.Add("@Taikhoan", SqlDbType.NVarChar).Value = nhanVien.Taikhoan1;
                sqlCommand.Parameters.Add("@Matkhau", SqlDbType.NVarChar).Value = nhanVien.Matkhau1;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }


        public bool delete(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM NHANVIEN WHERE MaNV = @MaNV";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end nhanvien

        //hoadon
        public DataTable getAllHoadon() { 
            DataTable dataTable = new DataTable();
            string query = "select * from HOADON";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertHoadon(hoadon1 hoaDon)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into HOADON values (@SoHD,@Ngayban,@HTTT,@MaNV,@MaKH)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.VarChar).Value = hoaDon.Sohd;
                sqlCommand.Parameters.Add("@Ngayban", SqlDbType.DateTime).Value = hoaDon.Ngayban;
                sqlCommand.Parameters.Add("@HTTT", SqlDbType.NVarChar).Value = hoaDon.Httt;
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = hoaDon.Manv;
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = hoaDon.Makh;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateHoadon(hoadon1 hoaDon)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update HOADON set Ngayban=@Ngayban,HTTT=@HTTT,MaNV=@MaNV,MaKH=@MaKH where SoHD=@SoHD";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.VarChar).Value = hoaDon.Sohd;
                sqlCommand.Parameters.Add("@Ngayban", SqlDbType.DateTime).Value = hoaDon.Ngayban;
                sqlCommand.Parameters.Add("@HTTT", SqlDbType.NVarChar).Value = hoaDon.Httt;
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = hoaDon.Manv;
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = hoaDon.Makh;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool deleteHoadon(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM HOADON WHERE SoHD = @SoHD";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end hoadon

        //hang
        public DataTable getAllHang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from MATHANG";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertHang(hang1 hang)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into MATHANG values (@MaMH,@TenMH,@Mau,@Size,@HSX,@Soluong,@Dongia)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = hang.Mamh;
                sqlCommand.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = hang.Tenmh;
                sqlCommand.Parameters.Add("@Mau", SqlDbType.NVarChar).Value = hang.Mau;
                sqlCommand.Parameters.Add("@Size", SqlDbType.VarChar).Value = hang.Size;
                sqlCommand.Parameters.Add("@HSX", SqlDbType.VarChar).Value = hang.Hsx;
                sqlCommand.Parameters.Add("@Soluong", SqlDbType.Int).Value = hang.Soluong;
                sqlCommand.Parameters.Add("@Dongia", SqlDbType.Int).Value = hang.Dongia;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateHang(hang1 hang)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update MATHANG set TenMH = @TenMH, Mau = @Mau, Size = @Size, HSX = @HSX, Soluong = @Soluong, Dongia = @Dongia where MaMH = @MaMH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = hang.Mamh;
                sqlCommand.Parameters.Add("@TenMH", SqlDbType.NVarChar).Value = hang.Tenmh;
                sqlCommand.Parameters.Add("@Mau", SqlDbType.NVarChar).Value = hang.Mau;
                sqlCommand.Parameters.Add("@Size", SqlDbType.VarChar).Value = hang.Size;
                sqlCommand.Parameters.Add("@HSX", SqlDbType.VarChar).Value = hang.Hsx;
                sqlCommand.Parameters.Add("@Soluong", SqlDbType.Int).Value = hang.Soluong;
                sqlCommand.Parameters.Add("@Dongia", SqlDbType.Int).Value = hang.Dongia;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }


        public bool deleteHang(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM MATHANG WHERE MaMH = @MaMH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end hang

        //khach hang
        public DataTable getAllKhachhang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from KHACHHANG";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertKhachhang(khachhang1 khachHang)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into KHACHHANG values (@MaKH,@TenKH,@DiachiKH,@SDTKH,@Ghichu)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = khachHang.Makh;
                sqlCommand.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = khachHang.Tenkh;
                sqlCommand.Parameters.Add("@DiachiKH", SqlDbType.NVarChar).Value = khachHang.Diachi;
                sqlCommand.Parameters.Add("@SDTKH", SqlDbType.VarChar).Value = khachHang.Sodt;
                sqlCommand.Parameters.Add("@Ghichu", SqlDbType.VarChar).Value =khachHang.Ghichu;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateKhachhang(khachhang1 khachHang)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update KHACHHANG set TenKH = @TenKH, DiachiKH = @DiachiKH, SDTKH = @SDTKH, Ghichu = @Ghichu where MaKH = @MaKH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.VarChar).Value = khachHang.Makh;
                sqlCommand.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = khachHang.Tenkh;
                sqlCommand.Parameters.Add("@DiachiKH", SqlDbType.NVarChar).Value = khachHang.Diachi;
                sqlCommand.Parameters.Add("@SDTKH", SqlDbType.VarChar).Value = khachHang.Sodt;
                sqlCommand.Parameters.Add("@Ghichu", SqlDbType.VarChar).Value = khachHang.Ghichu;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool deleteKhachhang(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end khach hang

        //nhà cung cấp
        public DataTable getAllNhacc()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from NHACUNGCAP";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertNhacc(nhacc1 nhaCc)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into NHACUNGCAP values (@MaNCC,@TenNCC,@DiachiNCC,@SDTNCC,@Ghichu)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNCC", SqlDbType.VarChar).Value = nhaCc.MaNCC;
                sqlCommand.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = nhaCc.TenNCC;
                sqlCommand.Parameters.Add("@DiachiNCC", SqlDbType.NVarChar).Value = nhaCc.DiachiNCC;
                sqlCommand.Parameters.Add("@SDTNCC", SqlDbType.VarChar).Value = nhaCc.Sdt;
                sqlCommand.Parameters.Add("@Ghichu", SqlDbType.VarChar).Value = nhaCc.Ghichu;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateNhacc(nhacc1 nhaCc)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update NHACUNGCAP set TenNCC = @TenNCC, DiachiNCC = @DiachiNCC, SDTNCC = @SDTNCC, Ghichu = @Ghichu where MaNCC = @MaNCC";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNCC", SqlDbType.VarChar).Value = nhaCc.MaNCC;
                sqlCommand.Parameters.Add("@TenNCC", SqlDbType.NVarChar).Value = nhaCc.TenNCC;
                sqlCommand.Parameters.Add("@DiachiNCC", SqlDbType.NVarChar).Value = nhaCc.DiachiNCC;
                sqlCommand.Parameters.Add("@SDTNCC", SqlDbType.VarChar).Value = nhaCc.Sdt;
                sqlCommand.Parameters.Add("@Ghichu", SqlDbType.VarChar).Value = nhaCc.Ghichu;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }


        public bool deleteNhacc(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaNCC", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end nhà cung cấp


        //nhập hàng
        public DataTable getAllNhaphang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from NHAPHANG";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertNhaphang(nhaphang1 nhapHang)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into NHAPHANG values (@SoPN,@Ngayban,@HTTT,@MaNV,@MaNCC)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoPN", SqlDbType.VarChar).Value = nhapHang.Sopn;
                sqlCommand.Parameters.Add("@Ngayban", SqlDbType.DateTime).Value = nhapHang.Ngaynhap;
                sqlCommand.Parameters.Add("@HTTT", SqlDbType.NVarChar).Value = nhapHang.Httt;
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = nhapHang.Manv;
                sqlCommand.Parameters.Add("@MaNCC", SqlDbType.VarChar).Value = nhapHang.Mancc;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateNhaphang(nhaphang1 nhapHang)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update NHAPHANG set Ngayban = @Ngayban, HTTT = @HTTT, MaNV = @MaNV, MaNCC = @MaNCC where SoPN = @SoPN";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoPN", SqlDbType.VarChar).Value = nhapHang.Sopn;
                sqlCommand.Parameters.Add("@Ngayban", SqlDbType.DateTime).Value = nhapHang.Ngaynhap;
                sqlCommand.Parameters.Add("@HTTT", SqlDbType.NVarChar).Value = nhapHang.Httt;
                sqlCommand.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = nhapHang.Manv;
                sqlCommand.Parameters.Add("@MaNCC", SqlDbType.VarChar).Value = nhapHang.Mancc;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool deleteNhaphang(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM NHAPHANG WHERE SoPN = @SoPN";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@SoPN", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end nhập hàng


        //trả hàng 
        public DataTable getAllTrahang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from TRAHANG";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        


        //chitiethoadon
        public DataTable getAllChitiethd()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from CHITIETHOADON";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertChitiethd(chitiethd1 chiTiethd)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into CHITIETHOADON values (@MaMH,@Soluongban,@Dongia,@Tongtien,@SoHD)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = chiTiethd.Mamh;
                sqlCommand.Parameters.Add("@Soluongban", SqlDbType.Int).Value = chiTiethd.Soluongban;
                sqlCommand.Parameters.Add("@Dongia", SqlDbType.Int).Value = chiTiethd.Dongia;
                sqlCommand.Parameters.Add("@Tongtien", SqlDbType.Int).Value = chiTiethd.Tongtien;
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.VarChar).Value = chiTiethd.Sohd;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateChitiethd(chitiethd1 chiTiethd)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "UPDATE CHITIETHOADON SET Soluongban = @Soluongban, Dongia = @Dongia, Tongtien = @Tongtien WHERE MaMH = @MaMH  SoHD = @SoHD";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = chiTiethd.Mamh;
                sqlCommand.Parameters.Add("@Soluongban", SqlDbType.Int).Value = chiTiethd.Soluongban;
                sqlCommand.Parameters.Add("@Dongia", SqlDbType.Int).Value = chiTiethd.Dongia;
                sqlCommand.Parameters.Add("@Tongtien", SqlDbType.Int).Value = chiTiethd.Tongtien;
                sqlCommand.Parameters.Add("@SoHD", SqlDbType.VarChar).Value = chiTiethd.Sohd;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool deleteChitiethd(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM CHITIETHOADON WHERE MaMH = @MaMH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end chitiethoadon

        //chi tiet nhap hang
        public DataTable getAllChitietnh()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from CHITIETNHAPHANG";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertChitietnh(chitietnh1 chiTietnh)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into CHITIETNHAPHANG values (@MaMH,@Soluongnhap,@Gianhap,@Tongtien,@SoPN)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = chiTietnh.Mamh;
                sqlCommand.Parameters.Add("@Soluongnhap", SqlDbType.Int).Value = chiTietnh.Soluongnhap;
                sqlCommand.Parameters.Add("@Gianhap", SqlDbType.Int).Value = chiTietnh.Gianhap;
                sqlCommand.Parameters.Add("@Tongtien", SqlDbType.Int).Value = chiTietnh.Tongtien;
                sqlCommand.Parameters.Add("@SoPN", SqlDbType.VarChar).Value = chiTietnh.Sopn;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateChitietnh(chitietnh1 chiTietnh)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "UPDATE CHITIETNHAPHANG SET Soluongnhap = @Soluongnhap, Gianhap = @Gianhap, Tongtien = @Tongtien WHERE MaMH = @MaMH AND SoPN = @SoPN";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = chiTietnh.Mamh;
                sqlCommand.Parameters.Add("@Soluongnhap", SqlDbType.Int).Value = chiTietnh.Soluongnhap;
                sqlCommand.Parameters.Add("@Gianhap", SqlDbType.Int).Value = chiTietnh.Gianhap;
                sqlCommand.Parameters.Add("@Tongtien", SqlDbType.Int).Value = chiTietnh.Tongtien;
                sqlCommand.Parameters.Add("@SoPN", SqlDbType.VarChar).Value = chiTietnh.Sopn;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }


        public bool deleteChitietpn(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM CHITIETNHAPHANG WHERE MaMH = @MaMH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end chi tiết nhập hàng

        //chi tiết trả hàng
        public DataTable getAllChitietth()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from CHITIETTRAHANG";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }


            return dataTable;
        }

        public bool insertChitietth(chitietth1 chiTietth)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "insert into CHITIETTRAHANG values (@MaMH,@Soluongtra,@Gianhap,@Tongtientra,@SoPT)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = chiTietth.Mamh;
                sqlCommand.Parameters.Add("@Soluongtra", SqlDbType.Int).Value = chiTietth.Soluongtra;
                sqlCommand.Parameters.Add("@Gianhap", SqlDbType.Int).Value = chiTietth.Gianhap;
                sqlCommand.Parameters.Add("@Tongtientra", SqlDbType.Int).Value = chiTietth.Tongtientra;
                sqlCommand.Parameters.Add("@SoPT", SqlDbType.VarChar).Value = chiTietth.Sopt;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool updateChitietth(chitietth1 chiTietth)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update CHITIETTRAHANG set Soluongtra = @Soluongtra, Gianhap = @Gianhap, Tongtientra = @Tongtientra where MaMH = @MaMH and SoPT = @SoPT";

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.VarChar).Value = chiTietth.Mamh;
                sqlCommand.Parameters.Add("@Soluongtra", SqlDbType.Int).Value = chiTietth.Soluongtra;
                sqlCommand.Parameters.Add("@Gianhap", SqlDbType.Int).Value = chiTietth.Gianhap;
                sqlCommand.Parameters.Add("@Tongtientra", SqlDbType.Int).Value = chiTietth.Tongtientra;
                sqlCommand.Parameters.Add("@SoPT", SqlDbType.VarChar).Value = chiTietth.Sopt;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }


        public bool deleteChitietth(string id)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "DELETE FROM CHITIETTRAHANG WHERE MaMH = @MaMH";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaMH", SqlDbType.NVarChar).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        //end chi tiet tra hang 
    }
}
