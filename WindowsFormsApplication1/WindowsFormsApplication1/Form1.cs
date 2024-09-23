using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|ders.accdb");
       
        private void listele()
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from dersler";
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["derskod"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["sinif"].ToString());
                ekle.SubItems.Add(oku["alan"].ToString());
                ekle.SubItems.Add(oku["saat"].ToString());
                listView1.Items.Add(ekle);
            }
            bag.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from dersler where derskod = '"+textBox1.Text+"'";
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            textBox2.Text = oku["ad"].ToString();
            textBox3.Text = oku["sinif"].ToString();
            textBox4.Text = oku["alan"].ToString();
            textBox5.Text = oku["saat"].ToString();
            bag.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = "insert into dersler (derskod,ad,sinif,alan,saat) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            komut.ExecuteNonQuery();
            bag.Close();
            listele();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = "update dersler set  ad = '" + textBox2.Text + "',sinif = '" + textBox3.Text + "',alan = '" + textBox4.Text + "',saat = '" + textBox5.Text + "' where derskod = '"+textBox1.Text+"'  ";
            komut.ExecuteNonQuery();
            bag.Close();
            listele();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = "delete from dersler where derskod = '" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            bag.Close();
            listele();
        }
    }
}
