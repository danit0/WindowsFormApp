using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppProjekt
{
    public partial class startform : Form
    {
        public startform()
        {
            InitializeComponent();
        }

        // zarejda spisuk s klienti
        public void Klienti_Click(object sender, EventArgs e)
        {
            spisukkrienti spisuk = new spisukkrienti();  // създава формата
            spisuk.ReadingCSVFile();                    // вика функцията която чете от файла
            spisuk.Show();                             //показва формата
        }

        // informaciq za avtora
        private void info_Click(object sender, EventArgs e)
        {
            AutorForm avtor = new AutorForm();  // създава форма с информация за автора
            avtor.Show();              // визуализира формата
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
