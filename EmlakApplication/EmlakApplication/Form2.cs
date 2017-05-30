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

namespace EmlakApplication
{
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AMH6387\SQLEXPRESS; Initial Catalog = binalar;Integrated Security=SSPI");

        public Form2()
        {
            InitializeComponent();
        }

        private void Goster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * From binalar_table", baglanti);
            SqlDataReader oxu = kmt.ExecuteReader();

            while (oxu.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = oxu["id"].ToString();
                add.SubItems.Add(oxu["bina"].ToString());
                add.SubItems.Add(oxu["satkira"].ToString());
                add.SubItems.Add(oxu["otaq"].ToString());
                add.SubItems.Add(oxu["metr"].ToString());
                add.SubItems.Add(oxu["qiymet"].ToString());
                add.SubItems.Add(oxu["blok"].ToString());
                add.SubItems.Add(oxu["menzil"].ToString());
                add.SubItems.Add(oxu["adsoyad"].ToString());
                add.SubItems.Add(oxu["telefon"].ToString());
                add.SubItems.Add(oxu["elaveler"].ToString());

                listView1.Items.Add(add);
                
            }
            baglanti.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "29")
            {
                btn29.BackColor = Color.Yellow;
                btn27.BackColor = Color.DarkGray;
                btn28.BackColor = Color.DarkGray;
                btn26.BackColor = Color.DarkGray;
            }else if (comboBox1.Text == "28")
            {
                btn29.BackColor = Color.DarkGray;
                btn27.BackColor = Color.DarkGray;
                btn28.BackColor = Color.Yellow;
                btn26.BackColor = Color.DarkGray;
            }
            else if (comboBox1.Text == "27")
            {
                btn29.BackColor = Color.DarkGray;
                btn27.BackColor = Color.Yellow;
                btn28.BackColor = Color.DarkGray;
                btn26.BackColor = Color.DarkGray;
            }else if (comboBox1.Text == "26")
            {
                btn29.BackColor = Color.DarkGray;
                btn27.BackColor = Color.DarkGray;
                btn28.BackColor = Color.DarkGray;
                btn26.BackColor = Color.Yellow;
            }
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            Goster();
        }

        private void btnYaddaSaxla_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Insert into binalar_table(bina,satkira,otaq,metr,qiymet,blok, menzil,adsoyad,telefon,elaveler) values('" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            Goster();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        int id = 0;
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Delete from binalar_table where id = ("+id+")",baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            Goster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("update binalar_table set bina='" + comboBox1.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "',otaq='" + comboBox3.Text.ToString() + "',metr='" + textBox1.Text.ToString() + "',qiymet='" + textBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',menzil='" + textBox6.Text.ToString() + "',adsoyad='" + textBox4.Text.ToString() + "',telefon='" + textBox5.Text.ToString() + "',elaveler='" + textBox3.Text.ToString() + "'where id  = " + id + "", baglanti);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            Goster();
        }
    }
}
