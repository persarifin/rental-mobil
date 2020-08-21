using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Qios.DevSuite.Components;
using Qios.DevSuite.Components.Ribbon;

namespace apk
{
    public partial class Form1 : QRibbonForm
    {
        MySqlConnection con = new MySqlConnection(@"Server=localhost;Database=rentalmobil;Uid=root;Pwd=;");
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataRow row;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        public bool tanya(string data)
        {
            if (MessageBox.Show(data, "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
                return false;
        }
        string type = "";
        void loadpelanggan()
        {
            string perintah = "select * from pelanggan";
            da = new MySqlDataAdapter(perintah, con);
            da.Fill(ds, "pelanggan");
            dataGridView1.DataSource = ds.Tables["pelanggan"];
        }
        void loadmobil()
        {
            MySqlConnection con = new MySqlConnection(@"Server=localhost;Database=rentalmobil;Uid=root;Pwd=;");

            MySqlDataAdapter da1 = new MySqlDataAdapter();
            string perintah = "select * from mobil";
            da1 = new MySqlDataAdapter(perintah, con);
            da1.Fill(ds1, "mobil");
            dataGridView2.DataSource = ds1.Tables["mobil"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            tampilist();
            loadmobil();
            loadpelanggan();
            loadtrans();
            tampilpengembalian();
            penomoranmobi();
            penomorannota();
            penomoranpengguna();

        }
        void loadtrans()
        {
            MySqlConnection con = new MySqlConnection(@"Server=localhost;Database=rentalmobil;Uid=root;Pwd=;");

            MySqlDataAdapter da2 = new MySqlDataAdapter();
            string perintah = "select * from transaksi";
            da2 = new MySqlDataAdapter(perintah, con);
            da2.Fill(ds2, "transaksi");
            dataGridView3.DataSource = ds2.Tables["transaksi"];
        }

        private void qButton1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("anda yakin untuk melanjutkan tansaksi ?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                qTabPage6.Show();
            }
            else
            {
                e.GetType();
            }
        }

        private void qTabPage5_Activated(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {

        }

        private void qTabPage2_Activated(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("silahkan menghubungi constumer kami di +6281-090-7861", "kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            qTabPage5.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            qTabPage1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox6.Text == "" || textBox5.Text == "" || textBox3.Text == "" || comboBox3.Text == "")
                MessageBox.Show("data tidak boleh kosong", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {
                button9.Enabled = true;
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * From pelanggan WHERE (username = '" + textBox6.Text + "')";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("data sudah ada", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox6.Focus();
                    }
                    else
                    {

                        MySqlCommand cmd = new MySqlCommand("insert into pelanggan values ('" + label2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "')", con);
                        dr.Close();
                        cmd.ExecuteNonQuery();
                        loadpelanggan();
                        MessageBox.Show("data berhasil disimpan", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        logout();
                    }

                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void qButton2_Click(object sender, EventArgs e)
        {
            qTabPage1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            qTabPage3.Show();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("anda yakin untuk menghapus akun?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Data berhasil di hapus", "Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                e.GetType();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {

            if (username.Text == "")
            {
                MessageBox.Show("Tentukan kode barang sebelum dirubah", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                username.Focus();
            }
            else
            {
                DialogResult dialog = MessageBox.Show("anda yakin untuk mengubah akun?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    MessageBox.Show("Data berhasil di Ubah", "Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    e.GetType();
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            qTabPage5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("anda harus log out terlebih dahulu!", "kesalahan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                qTabPage9.Show();

            }
            else
                GetType();
        }

        private void qButton4_Click(object sender, EventArgs e)
        {
            qTabPage3.Show();
        }

        private void qButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transaksi sukses", "selesai", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            qTabPage1.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void qTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            qTextBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qTextBox1.Text == "arifin" && qTextBox2.Text == "54321")
            {
                MessageBox.Show("anda masuk sebagai admin, tabel profil, transaksi dan pengembalian di nonaktifkan");
                qTabPage9.Show();
                qTabPage1.ButtonVisible = false;
                pictureBox19.Enabled = false;
                pictureBox20.Visible = true;
                label44.Visible = true;
                pictureBox3.Visible = true;
                label58.Visible = true;
                pictureBox4.Visible = true;
                label74.Visible = true;
                pictureBox18.Visible = true;
                label42.Visible = true;
                pictureBox3.Visible = true;

            }
            else
            {
                try
                {
                    con.Open();
                    if (qTextBox1.Text == "" || qTextBox2.Text == "")
                    {
                        MessageBox.Show("silahkan isi username dan password", "kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM pelanggan WHERE username='" + qTextBox1.Text + "' AND password='" + qTextBox2.Text + "'", con);
                        MySqlDataReader rd = cmd.ExecuteReader();
                        if (!rd.Read())
                        {
                            MessageBox.Show("cek username and password", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                            qTabPage9.Show();
                            qTabPage1.ButtonVisible = false;
                            label30.Text = rd["id"].ToString();
                            username.Text = rd["username"].ToString();
                            textnama.Text = rd["nama"].ToString();
                            alamat.Text = rd["alamat"].ToString();
                            jk.Text = rd["jenkel"].ToString();
                            password.Text = rd["password"].ToString();
                            pictureBox20.Visible = false;
                            label44.Visible = false;
                        }
                        rd.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }


        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                qTextBox2.UseSystemPasswordChar = false;

            else
                qTextBox2.UseSystemPasswordChar = true;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand("select * from mobil", con);
            qTabPage3.Show();
            penomoranmobi();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand("select * from pelanggan where username='" + qTextBox1.Text + "'password='" + qTextBox2.Text + "'", con);

            qTabPage2.Show();

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand("select * from pelanggan ", con);
            qTabPage4.Show();
            penomoranpengguna();
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "pilih gambar";
            opf.Filter = "jpeg (*.jpg; *.png; *.img;)| *jpg; *.png; *.img;";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(opf.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox15.Text == "")
                MessageBox.Show("tentukan mobil sebelum di rubah");
            else
            {
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * From pelanggan WHERE (username = '" + textBox16.Text + "')";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("data sudah ada", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox16.Focus();
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("update mobil set kode='" + textBox2.Text + "',merk='" + textBox12.Text + "' ,nama='" + textBox11.Text + "',harga='" + textBox15.Text + "' where kode='" + textBox2.Text + "'", con);
                        dr.Close();
                        cmd.ExecuteNonQuery();
                        loadmobil();
                        MessageBox.Show("Data berhasil diubah");
                    }
                }
                finally
                {
                    bersihmobil();
                    penomoranmobi();
                    con.Close();

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("anda harus log out terlebih dahulu!", "kesalahan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                qTabPage9.Show();

            }
            else
                GetType();
        }
        void logout()
        {
            qTabPage1.Show();
            qTabPage1.ButtonVisible = true;
            qTextBox1.Text = "";
            qTextBox2.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("yakin untuk log out?", "peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                logout();
            }
            else
                GetType();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            qTabPage9.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            qTabPage9.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            qTabPage9.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            qTabPage1.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bersihtrans();
            qTabPage9.Show();
        }

        private void btnBatal_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("anda harus log out terlebih dahulu!", "kesalahan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                qTabPage9.Show();

            }
            else
                GetType();
        }

        void penomoranmobi()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            com.Connection = con;
            com.CommandText = "SELECT * FROM mobil";
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                com.CommandText = "SELECT kode FROM mobil ORDER BY kode DESC LIMIT 1";
                textBox2.Text = string.Format("c{0,3:000000#}", Convert.ToInt32(com.ExecuteScalar().ToString().Substring(1)) + 1);
            }
            else
            {
                textBox2.Text = "c0078001";
            }
            con.Close();
        }

        private void qButton3_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("anda harus log out terlebih dahulu!", "kesalahan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                qTabPage9.Show();

            }
            else
                GetType();
        }


        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("anda yakin untuk menghapus akun?", "peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("delete from pelanggan where username='" + qTextBox1.Text + "'", con);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    loadpelanggan();
                    MessageBox.Show("Akun berhasil di hapus");

                    logout();

                }
                else
                    GetType();
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBox19_SizeChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void btnUbah_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("yakin untuk mengubah data?", "peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                qTabPage10.Show();
            }
            else
                GetType();

        }
        void penomoranpengguna()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            com.Connection = con;
            com.CommandText = "SELECT * FROM pelanggan";
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                com.CommandText = "SELECT id FROM pelanggan ORDER BY id DESC LIMIT 1";
                label2.Text = string.Format("a{0,3:00#}", Convert.ToInt32(com.ExecuteScalar().ToString().Substring(1)) + 1);
            }
            else
            {
                textBox2.Text = "a001";
            }
            con.Close();
        }
        void penomorannota()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            com.Connection = con;
            com.CommandText = "SELECT * FROM transaksi";
            dr.Close();
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                com.CommandText = "SELECT nota FROM transaksi ORDER BY nota DESC LIMIT 1";
                textBox25.Text = string.Format("b{0,3:00#}", Convert.ToInt32(com.ExecuteScalar().ToString().Substring(1)) + 1);
            }
            else
            {
                textBox25.Text = "b001";
            }
            con.Close();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "" || textBox17.Text == "" || textBox9.Text == "" || comboBox1.Text == "" || textBox10.Text == "")
                MessageBox.Show("data tidak boleh kosong", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * From pelanggan WHERE (username = '" + textBox16.Text + "')";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("data sudah ada", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox16.Focus();
                    }
                    else
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("update pelanggan set username='" + textBox16.Text + "',nama='" + textBox10.Text + "' ,alamat='" + textBox17.Text + "',jenkel='" + comboBox1.Text + "',password='" + textBox9.Text + "' where username='" + qTextBox1.Text + "'", con);
                        dr.Close();
                        cmd.ExecuteNonQuery();
                        loadpelanggan();
                        MessageBox.Show("Data berhasil diubah");
                        logout();
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox8.Text != textBox9.Text)
            {
                label51.Text = "pasword tidak sama";
                label51.ForeColor = System.Drawing.Color.Red;
                button18.Enabled = false;
            }
            else
            {
                label51.Text = "";
                button18.Enabled = true;
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            qTabPage2.Show();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                type = "toyota";
                tampilist();
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                type = "honda";
                tampilist();
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                type = "daihatsu";
                tampilist();
            }
            else
            {
                listBox1.Items.Clear();
            }
        }
        void tampilist()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM mobil WHERE merk='" + type + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["nama"].ToString());
                }
            }
            finally
            {
                con.Close();
            }
        }
        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                type = "mitsubishi";
                tampilist();
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox15.Text == "")
                MessageBox.Show("masukkan data sebelum di disimpan");
            else
            {
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * From mobil WHERE (kode = '" + textBox2.Text + "')";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("data sudah ada", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.Focus();
                    }
                    else
                    {

                        MySqlCommand cmd = new MySqlCommand("insert into mobil values ('" + textBox2.Text + "','" + textBox12.Text + "','" + textBox11.Text + "','" + textBox15.Text + "')", con);
                        dr.Close();
                        cmd.ExecuteNonQuery();
                        loadmobil();
                        MessageBox.Show("data berhasil disimpan", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                finally
                {
                    bersihmobil();
                    con.Close();
                    textBox2.Focus();
                    penomoranmobi();
                }
            }
        }
        void bersihmobil()
        {
            textBox2.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox15.Clear();
        }
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox24.Text = Convert.ToString(ds.Tables["pelanggan"].Rows[dataGridView1.CurrentRow.Index].ItemArray[0]);
                textBox23.Text = Convert.ToString(ds.Tables["pelanggan"].Rows[dataGridView1.CurrentRow.Index].ItemArray[1]);
                textBox13.Text = Convert.ToString(ds.Tables["pelanggan"].Rows[dataGridView1.CurrentRow.Index].ItemArray[2]);
                textBox14.Text = Convert.ToString(ds.Tables["pelanggan"].Rows[dataGridView1.CurrentRow.Index].ItemArray[3]);
                comboBox2.Text = Convert.ToString(ds.Tables["pelanggan"].Rows[dataGridView1.CurrentRow.Index].ItemArray[4]);
            }
            catch (Exception ex)
            {
                dataGridView1.Focus();
                penomoranpengguna();
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            penomoranpengguna();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != textBox6.Text)
            {
                label54.Text = "pasword tidak sama";
                label54.ForeColor = System.Drawing.Color.Red;
                button9.Enabled = false;
            }
            else
            {
                label54.Text = "";
                button9.Enabled = true;
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            penomoranpengguna();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Convert.ToString(ds1.Tables["mobil"].Rows[dataGridView2.CurrentRow.Index].ItemArray[0]);
                textBox12.Text = Convert.ToString(ds1.Tables["mobil"].Rows[dataGridView2.CurrentRow.Index].ItemArray[1]);
                textBox11.Text = Convert.ToString(ds1.Tables["mobil"].Rows[dataGridView2.CurrentRow.Index].ItemArray[2]);
                textBox15.Text = Convert.ToString(ds1.Tables["mobil"].Rows[dataGridView2.CurrentRow.Index].ItemArray[3]);
            }
            catch (Exception ex)
            {
                bersihmobil();
                penomoranmobi();
                dataGridView2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void qTabPage3_Activated(object sender, EventArgs e)
        {

        }

        private void qTabControl1_ActivePageChanged(object sender, QTabPageChangeEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("anda yakin untuk menghapus mobil?", "peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("delete from mobil where kode='" + textBox2.Text + "'", con);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    penomoranmobi();
                    MessageBox.Show("mobil berhasil di hapus");


                }
                else
                    GetType();

            }
            finally
            {
                bersihmobil();
                con.Close();

            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            
                qTabPage6.Show();
                textBox18.Text = textnama.Text;
                penomorannota();
       
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label60.Text = listBox1.Text;
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("select harga,kode from mobil where nama='" + label60.Text + "'", con);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    textBox26.Text = dr["harga"].ToString();
                    textBox20.Text = dr["kode"].ToString();
                }


            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand(@"select * from transaksi", con);
            qTabPage12.Show();
        }

        private void qButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || listBox1.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("data tidak boleh kosong", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox25.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * From transaksi WHERE (nota = '" + textBox25.Text + "')";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("No Nota sudah ada", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox25.Focus();
                    }
                    else
                    {
                        dr.Close();
                        MySqlCommand cmd = new MySqlCommand("insert into transaksi values ('" + textBox25.Text + "','" + label30.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + label60.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox1.Text + "','" + textBox19.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        loadtrans();
                        MessageBox.Show("transaksi berhasil disimpan", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        logout();
                    }
                }
                finally
                {

                    con.Close();
                }
            }
        }


        void bersihtrans()
        {
            textBox18.Text = "";
            listBox1.Text = "";
            textBox20.Text = "";
            textBox1.Text = "";
            textBox26.Text = "";
            textBox19.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            dateTimePicker1.Text = "";

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("select harga,kode from mobil where nama='" + label60.Text + "'", con);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    textBox26.Text = dr["harga"].ToString();
                    textBox20.Text = dr["kode"].ToString();
                }


            }
            finally
            {
                con.Close();
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_Click(object sender, EventArgs e)
        {

        }

        private void btnCek_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("lama sewa tidak boleh kosong");
            else
                textBox19.Text = Convert.ToString(Convert.ToUInt32(textBox1.Text) * Convert.ToUInt32(textBox26.Text));
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox30.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[0]);
                textBox28.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[1]);
                textBox29.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[2]);
                textBox27.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[3]);
                textBox34.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[4]);
                dateTimePicker4.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[5]);
                textBox33.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[6]);
                textBox31.Text = Convert.ToString(ds2.Tables["transaksi"].Rows[dataGridView2.CurrentRow.Index].ItemArray[7]);
            }
            catch (Exception ex)
            {
                dataGridView3.Focus();
                bersihtrans();
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand("select * from transaksi", con);            
            qTabPage11.Show();
            penomorannota();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox15.Text == "")
                MessageBox.Show("masukkan data sebelum di disimpan");
            else
            {
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * From transaksi";
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        MessageBox.Show("data sudah ada", "Pesan Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox2.Focus();
                    }
                    else
                    {

                        MySqlCommand cmd = new MySqlCommand("insert into nota values ('" + textBox2.Text + "','" + textBox12.Text + "','" + textBox11.Text + "','" + textBox15.Text + "')", con);
                        dr.Close();
                        cmd.ExecuteNonQuery();
                        loadmobil();
                        MessageBox.Show("data berhasil disimpan", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                finally
                {
                    bersihtrans();
                    con.Close();
                    textBox2.Focus();
                    penomorannota();
                }
            }
        }
        

        private void button22_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            qTabPage9.Show();
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {

        }

        private void qButton6_Click_1(object sender, EventArgs e)
        {

        }

        private void qTabPage12_Activated(object sender, EventArgs e)
        {

        }
        void tampilpengembalian()
        {
            string perintah = "select nota from transaksi";
            da = new MySqlDataAdapter(perintah, con);
            da.Fill(ds, "transaksi");
            comboBox6.DataSource = ds.Tables["transaksi"];
            comboBox6.DisplayMember = "nota";
            comboBox6.ValueMember = "nota";
            comboBox6.Text = "";
            comboBox6.SelectedValue = "";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(@"select * from transaksi where nota='" + comboBox6.Text + "'", con);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    DateTime ts = Convert.ToDateTime(dr["tgl_sewa"].ToString());
                    ts = ts.AddDays(Convert.ToDouble(dr["lm_sewa"].ToString()));


                    textBox40.Text = dr["id_pelanggan"].ToString();
                    textBox41.Text = dr["nm_pelanggan"].ToString();
                    textBox39.Text = dr["id_mobil"].ToString();
                    textBox38.Text = dr["nm_mobil"].ToString();
                    textBox37.Text = dr["lm_sewa"].ToString();
                    textBox35.Text = dr["bayar"].ToString();
                    dateTimePicker2.Text = ts.ToString();
                    if (DateTime.Now > ts)
                    {
                        DateTime awal = ts;
                        DateTime akhir = DateTime.Now;
                        TimeSpan kurang = akhir - awal;
                        int days = kurang.Days;
                        double denda = days * 200000;
                        textBox43.Text = Convert.ToString(denda);
                        textBox32.Text = Convert.ToString(Convert.ToUInt32(textBox35.Text) + (Convert.ToUInt32(textBox43.Text)));
                    }
                    else
                    {
                        textBox43.Text = "0";
                    }
                }
            }
            finally
            {
                con.Close();
            }


        }

        private void button24_Click(object sender, EventArgs e)
        {
            qTabPage9.Show();
            comboBox6.ResetText();
            textBox40.Clear();
            textBox41.Clear();
            textBox39.Clear();
            textBox38.Clear();
            textBox37.Clear();
            textBox35.Clear();
            textBox43.Clear();
            dateTimePicker1.Text = "";

        }

        private void qButton4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


  
        
    
    
