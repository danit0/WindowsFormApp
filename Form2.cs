using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppProjekt
{
    public partial class spisukkrienti : Form
    {

        public spisukkrienti()
        {
            InitializeComponent();


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //  извиква форма за физическо лице
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            lice lice = new lice();
            lice.Show();


        }
        //  извиква форма за юридическо лице
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            firma firma = new firma();
            firma.Show();

        }

       

        // Чете текста от файла и го визуализира в листбокса
        public void ReadingCSVFile()

        { try
            {

                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "/" + "file1.csv"))
                {

                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arr = line.Split(';');

                        string res = "";
                        foreach (var elem in arr)
                        {
                            if (elem == "") { }
                            else
                            {
                                res +=elem + "  |   ";
                            }
                        }

                       
                        listBox1.Items.Add(res);
                        
                    }
                    sr.Close();
                }
                
            }

            catch (FileNotFoundException ex)
            {



                var result1 = MessageBox.Show("Файлът не съществува! Да създам ли нов файл?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (result1 == DialogResult.Yes)
                {
                    string file1 = Environment.CurrentDirectory + "/" + "file1.csv";
                    if (!File.Exists(file1))
                    {

                        File.Create(file1);
                        MessageBox.Show("Файлът е създаден!");

                    }

                }
                else
                {
                    Close();
                }
            


            }

        }


        // Редактиране на информацията
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

                string lineToReplace = listBox1.SelectedItem.ToString(); // записва избрания ред
                lineToReplace = lineToReplace.Replace("  |   ", ";");

                string file1 = Environment.CurrentDirectory + "/" + "file1.csv"; // zapiswa lokaciqta na faila
                string text = File.ReadAllText(file1);  // чете файла
                string[] arr = lineToReplace.Split(';');


                if (arr[3] == "мъж" || arr[3] == "жена")

                {
                    lice chovek = new lice();
                    chovek.fillText1(lineToReplace);
                    chovek.Show();

                }
                else
                {
                    firma firm = new firma();
                    firm.fillText(lineToReplace);
                    firm.Show();

                }
                
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Файлът не съществува!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Не сте маркирали ред!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        // изтриване на ред
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            try
            {
                string file1 = Environment.CurrentDirectory + "/" + "file1.csv"; // zapiswa lokaciqta na faila
                string lineToDelete = listBox1.SelectedItem.ToString(); // реда за триене
                lineToDelete = lineToDelete.Replace("  |   ", ";");

                const string caption = " ";
                var result = MessageBox.Show("Сигурни ли сте че искате да изтриете?", caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                // Ако бутонът ДА е натиснат трие реда от фаила
                if (result == DialogResult.Yes)
                {
                    string text = File.ReadAllText(file1);

                    text = text.Replace(lineToDelete, string.Empty);


                    File.WriteAllText(file1, text);
                    File.WriteAllLines(file1, File.ReadAllLines(file1).Where(l => !string.IsNullOrWhiteSpace(l)));
                    RefreshForm();
                }

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Файлът не съществува!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);




            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Не сте маркирали ред!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }




        }



        //подновява формата
        public static void RefreshForm()
        {
            spisukkrienti.ActiveForm.Dispose();
            spisukkrienti spisuk = new spisukkrienti();
            spisuk.ReadingCSVFile();
            spisuk.Show();
        }










        private void spisukkrienti_Load(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}



