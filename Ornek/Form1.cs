using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ornek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.database1DataSet.Ogrenci);
            // listele 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Ogrenci",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {   // ekle 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,Numara,Cinsiyet) values (@p1,@p2,@p3,@p4)",baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3",Convert.ToInt32( textBox3.Text));
            komut.Parameters.AddWithValue("@p4", textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // listele 
       
            SqlCommand komut = new SqlCommand("Select * from Ogrenci",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // guncelle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Ogrenci set Ograd=@p1,OgrSoyad=@p2,Numara=@p3,Cinsiyet=@p4 where Id=@p5", baglanti);
            komut.Parameters.AddWithValue("@p5", textBox4.Text);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", Convert.ToInt32(textBox3.Text));
            komut.Parameters.AddWithValue("@p4",textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sil
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" delete from Ogrenci where Id=@p4", baglanti);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
