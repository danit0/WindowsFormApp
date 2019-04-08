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
using System.Text.RegularExpressions;


namespace WindowsFormsAppProjekt
{
    public partial class lice : Form
    {
        public lice()
        {
            InitializeComponent();
        }
        private bool Nowreplace = false; // променливата е с стойност false когато запазваме нова информация и true когато редактираме 
        private string oldperson = "";  // променливата пази предишните стойности при редактиране

        //ЗАПАЗИ Бутонът 1 проверява информацията и запазва в файла
        private void button1_Click(object sender, EventArgs e)
        {
            // Име
            String ime = "";
            if (Ime(textBox1) != "")
            {
                ime = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Моля въведете име!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //  Презиме
            String prezime = "";
            if (Ime(textBox2) != "")
            {
                prezime = textBox2.Text;
            }
            else
            {
                MessageBox.Show("Моля въведете презиме!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            // Фамилия
            String fam = "";
            if (Ime(textBox3) != "")
            {
                fam = textBox3.Text;
            }
            else
            {
                MessageBox.Show("Моля въведете фамилия!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            // Пол
            string pol = "";
            if (PolChek() != "") { pol = PolChek(); }
            else
            {
                MessageBox.Show("Моля въведете пол!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //EGH
            String egn = "";
            if (EGN() != "")
            {
                egn = EGN();
            }
            else
            {
                MessageBox.Show("Моля въведете ЕГН!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //Номер на лична карта
            String karta = "";
            if (lichnakarta() != "")
            {
                karta = lichnakarta();
            }
            else
            {
                MessageBox.Show("Моля въведете номер на лична карта!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //Адрес

            String adress = "";
            if (Adress() != "")
            {
                adress = Adress();
            }
            else
            {
                MessageBox.Show("Моля въведете адрес!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //Телефон
            string telefon = "";
            if (GetTelefon() != "")
            {
                telefon = GetTelefon();
            }
            else
            {
                MessageBox.Show("Моля въведете телефон!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //Имейл
            String email = "";
            if (GetEmail() != "")
            {
                email = GetEmail();
            }
            else
            {
                MessageBox.Show("Моля въведете имейл!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (ime != "" && prezime != "" && fam != "" && pol != "" && egn != "" && karta != "" && adress != "" && telefon != "" && GetEmail() != "")
            {
                try
                {
                    const string caption = " ";
                    var result = MessageBox.Show("Сигурни ли сте че искате да запишете?", caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                    // Ако е избран бутона ДА информацията се запазва
                    if (result == DialogResult.Yes)
                    {
                        string file1 = Environment.CurrentDirectory + "/" + "file1.csv";
                        string text = File.ReadAllText(file1);
                        if (Nowreplace)
                        {


                            text = text.Replace(oldperson, String.Join(";", ime, prezime, fam, pol, egn, karta, adress, telefon, email, System.Environment.NewLine));
                            File.WriteAllText(file1, text);
                            File.WriteAllLines(file1, File.ReadAllLines(file1).Where(l => !string.IsNullOrWhiteSpace(l)));

                        }
                        else
                        {

                            File.AppendAllText(file1, String.Join(";", ime, prezime, fam, pol, egn, karta, adress, telefon, email, System.Environment.NewLine));
                        }


                        spisukkrienti.ActiveForm.Update();
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("Файлът не съществува!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (IOException)

                {

                    MessageBox.Show("Файлът!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }


                Close();
                spisukkrienti.RefreshForm();
            }



        }

       
        // проверка за въвеждане само на букви
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        // проверка за въвеждане само на букви и цифри
        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
        // проверка за въвеждане само на цифри
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        // Имена
        private String Ime(TextBox tbox)
        {
            String ime = "";
            if (tbox.Text != "" && tbox.TextLength > 2)
            {
                if (IsAllLetters(tbox.Text) == true)

                    ime = tbox.Text;
            }

            return ime;
        }
        // метод за пол на лицето
        private string PolChek()
        {
            string pol = "";
            if (radioButton1.Checked)
            {
                pol = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                pol = radioButton2.Text;

            }
            return pol;
        }
        // ЕГН на клиента 10 cifri
        private String EGN()
        {
            String egn = "";
            if (textBox4.Text != "" && IsAllDigits(textBox4.Text) == true)
            {
                if (textBox4.Text.Length == 10)
                {
                    egn = textBox4.Text;
                }

            }
            return egn;
        }
        // Номер на лична карта 9 cifri
        private String lichnakarta()
        {
            String karta = "";
            if (textBox5.Text != ""&& textBox5.Text.Length==9)
            {
                return karta = textBox5.Text;
            }
            return karta;

        }
        // Адрес
        private String Adress()
        {
           
            String adress = "";
            if (textBox6.Text != "")
            {
                adress = textBox6.Text;
            }
            return adress;
        }
        // Телефон
        private String GetTelefon()
        {
            string telefon = "";
            if (textBox7.Text != "" && textBox7.TextLength == 12)
            {
                
                if (IsAllDigits(textBox7.Text) == true)
                {
                    if (textBox7.Text.StartsWith("087") || textBox7.Text.StartsWith("088") || textBox7.Text.StartsWith("089"))
                    {
                        telefon = textBox7.Text;
                    }
                    else
                    {
                        MessageBox.Show("Въвели сте невалиден номер. Моля започнете с 088/087/089!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                else
                {
                    MessageBox.Show("Въведете само числа!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            return telefon;
        }
        //Имейл
        private String GetEmail()
        {Regex regemeil=new Regex (@"^[A-Za-z][A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            String email = "";
            if (textBox8.Text != ""&& regemeil.IsMatch(textBox8.Text))
            {
                email = textBox8.Text;
            }
            return email;
        }

       

       
        //Пълни полетата в формата при редактиране
        public void fillText1(string line)
        {

            string[] arr = line.Split(';');
            textBox1.Text = arr[0];
            textBox2.Text = arr[1];
            textBox3.Text = arr[2];

            textBox4.Text = arr[4];
            textBox5.Text = arr[5];
            textBox6.Text = arr[6];
            textBox7.Text = arr[7];
            textBox8.Text = arr[8];
            switch (arr[3])
            {
                case "мъж":
                    radioButton1.Checked = true;
                    break;
                case "жена":
                    radioButton2.Checked = true;
                    break;

            }

            Nowreplace = true;
            oldperson = line;
        }








 private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void button2_Click(object sender, EventArgs e)
        {
            //string file1 = @"C: \Users\Danito\source\repos\WindowsFormsAppProjekt\WindowsFormsAppProjekt\file1.csv";

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
 private void lice_Load(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged_1(object sender, EventArgs e)
        {

        }
    }
}