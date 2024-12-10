using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muhasebe
{
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection conn=new SqlConnection("Data Source=HP;Initial Catalog=muhasebe;Integrated Security=True;TrustServerCertificate=True");
        private void Urunler_Load(object sender, EventArgs e)
        {
            doldur();
        }
        private void doldur()
        {
            string cumle = "Select * from kategoriler";
            SqlDataAdapter da = new SqlDataAdapter(cumle,conn);
            DataTable dt =new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string cumle = "insert into kategoriler (kategoriAd) values (@kategoriAd)";
                SqlCommand cmd=new SqlCommand(cumle,conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriAd", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kaydınız Eklenmiştir");

                    
                conn.Close();
                doldur();

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu:" + ex.Message);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = dataGridView1.CurrentRow.Index;
            //seçilen satır  numarası alır
            textBox1.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString();
            // sıfır kategoriId 1 no alan kategoriAd
            //textBox1.Text kategorİAd
            textBox2.Text = dataGridView1.Rows[satir].Cells[0].Value.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap = MessageBox.Show("Bu Kaydı Silmek İstiyor musunuz?","Silme", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (cevap==DialogResult.Yes)
                {
                    conn.Open();
                    string cumle = "delete from kategoriler where kategoriId=@Id";
                    SqlCommand cmd = new SqlCommand(cumle, conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Silinmiştir");


                    conn.Close();
                    doldur();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu:" + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string cumle = "update kategoriler set kategoriAd=@kategoriAd where kategoriId=@Id";
                SqlCommand cmd = new SqlCommand(cumle, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriAd", textBox1.Text);
                cmd.Parameters.AddWithValue("@Id", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kaydınız düzeltilmiştir.");


                conn.Close();
                doldur();

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluştu:" + ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Arama Kutusu Boş Olamaz");
                textBox3.Focus();
                textBox3.BackColor = Color.Brown;
                textBox3.ForeColor = Color.White;

            }
            else
            {
                string cumle = "Select * from kategoriler where kategoriAd like '%" + textBox3.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cumle, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource= dt;
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("Kayıt Bulunamadı");

                }
            }
        }
    }
}
 