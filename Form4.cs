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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;


namespace WindowsFormsAppProjekt
{
    public partial class firma : Form
    {
        public firma()
        {
            InitializeComponent();
        }
        private bool Itsreplacing = false;// глобална променливата е с стойност false когато запазваме нова информация и true когато редактираме 
        private string oldline = ""; // глобална променливата пази предишните стойности при редактиране


        //ЗАПАЗИ Бутон 1 проверява въведената информация и запазва във файла
        private void button1_Click(object sender, EventArgs e)
        {
            // наименование на фирмата
            String naimenovanie = "";
            if (Naimenovanie() != "")
            {
                naimenovanie = Naimenovanie();

                if (naimenovanie == "1")
                {
                    MessageBox.Show("Моля въведете наименование на фирмата по дълго от един знак!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Моля въведете наименованието на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //RadioButon за вида на фирмата
            string statut;
            if (Statut() != "") { statut = Statut(); }
            else
            {
                MessageBox.Show("Моля въведете wida на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            // булстат на фирмата
            String bulstat;
            if (Bulstat() != "")
            {
                bulstat = Bulstat();
            }
            else
            {
                MessageBox.Show("Моля въведете 9 цифрения булстат на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //Данъчен номер
            string dnomer;
            if (DanuchenNomer() != "")
            {
                dnomer = DanuchenNomer();
            }
            else
            {
                MessageBox.Show("Моля въведете данъчен номер на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Моля въведете адрес на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //Телефон
            string telefon;
            if (GetTelefon() != "")
            {
                telefon = GetTelefon();

            }
            else
            {
                MessageBox.Show("Моля въведете telefon на фирмата! * 12 цифри", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //Имейл
            String email;
            if (GetEmail() != "")
            {
                email = GetEmail();
            }
            else
            {
                MessageBox.Show("Моля въведете имейл на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //Уеб адрес
            String web;
            if (GetWEb() != "")
            {
                web = GetWEb();
            }
            else
            {
                MessageBox.Show("Моля въведете уеб адрес на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            // Мол
            String mol = "";
            if (GetMol() != "")
            {
                mol = GetMol();
            }
            else
            {
                MessageBox.Show("Моля въведете Мол на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            // prowerka dali cifrite ot bulstatut otgovarqt na danuchniq nomer
            if (bulstat != dnomer.Substring(2))
            {
                MessageBox.Show("Данъчният номер не съответства на булстата на фирмата!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            // ako cqlata forma e polulnena yapiswa w faila
            if (naimenovanie != "" && statut != "" && bulstat != "" && dnomer != "" && adress != "" &&
               telefon != "" && email != "" && web != "" && mol != "")
            {

                try
                {

                    const string caption = " ";
                    var result = MessageBox.Show("Сигурни ли сте че искате да запишете?", caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);


                    // при натискане на бутона Да запаметява във файла ...
                    if (result == DialogResult.Yes)
                    {
                        string file1 = Environment.CurrentDirectory + "/" + "file1.csv";
                        string text = File.ReadAllText(file1);
                        if (Itsreplacing)
                        {


                            text = text.Replace(oldline, String.Join(";", naimenovanie, statut, bulstat, dnomer, adress, telefon, email, web, mol, System.Environment.NewLine));
                            File.WriteAllText(file1, text);
                            File.WriteAllLines(file1, File.ReadAllLines(file1).Where(l => !string.IsNullOrWhiteSpace(l)));


                        }
                        else
                        {
                            File.AppendAllText(file1, String.Join(";", naimenovanie, statut, bulstat, dnomer, adress, telefon, email, web, mol, System.Environment.NewLine));

                        }

                        Close();
                        spisukkrienti.RefreshForm();

                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("Файлът не съществува!", " ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }


            }

        }



        // Проверява дали са въведени само букви
        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        // Проверява дали са въведени само букви и space
        public static bool IsAllLettersAndSpaces(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }
        // Проверява дали са въведени само букви и цифри
        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

        // Проверява дали са въведени само цифри
        public static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        // Наименование на фирмата/ може да съдържа всичко / ДА Е ПО ДЪЛГО ОТ ЕДИН ЗНАК
        private String Naimenovanie()
        {
            String naimenovanie = "";
            if (textBox1.Text != "" && textBox1.Text.Length > 1)
            {
                naimenovanie = textBox1.Text;
            }
            else if (textBox1.Text.Length == 1)
            {
                naimenovanie = "1";// ako naimenovanieto e 1 znak vurni edinica
            }


            return naimenovanie;
        }
        // radiobuton за статут на фирмата
        private string Statut()
        {
            String statut = "";
            if (radioButton1.Checked)
            {
                return statut = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                return statut = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                return statut = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                return statut = radioButton4.Text;
            }
            else if (radioButton5.Checked)
            {
                return statut = radioButton5.Text;
            }
            else
                return statut;
        }
        // Булстат от 9 цифри 
        private String Bulstat()
        {
            String bulstat = "";
            if (textBox2.Text != "" && textBox2.TextLength == 9)
            {
                if (IsAllDigits(textBox2.Text) == true)
                {
                    bulstat = textBox2.Text;

                }
                else { MessageBox.Show("Въведете само числа за булстат!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
            else if (textBox2.TextLength < 9)
            {
                MessageBox.Show("Въвели сте по-малко числа за булстат!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            return bulstat;
        }
        // Данъчен номер
        private String DanuchenNomer()
        {
            string dnomer = "";
            if (textBox3.Text != "" && textBox3.Text != "BG")
            {
                dnomer = textBox3.Text;
            }
            return dnomer;
        }
        // Адрес
        private String Adress()
        {
           
            String adress = "";
            if (textBox4.Text != "") 
            {
                adress = textBox4.Text;
            }
            return adress;
        }
        // Телефон 12 цифри nachalo s 087 088 089
        private String GetTelefon()
        {
            string telefon = "";
            if (textBox5.Text != "" && textBox5.TextLength == 12)
            {
                if (IsAllDigits(textBox5.Text) == true)
                {
                    if (textBox5.Text.StartsWith("087") || textBox5.Text.StartsWith("088") || textBox5.Text.StartsWith("089"))
                    {
                        telefon = textBox5.Text;
                    }
                    else
                    {
                        MessageBox.Show("Въвели сте невалиден номер.Моля започнете с 088 /087 / 089!", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        {
            Regex regemeil = new Regex(@"^[A-Za-z][A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            String email = "";
            if (textBox6.Text != "" && regemeil.IsMatch(textBox6.Text))
            {
                email = textBox6.Text;
            }
            return email;
        }






        // Уеб адрес
        private String GetWEb()
        {
            Regex webreg = new Regex(@"^(www\.+[A-Za-z0-9][A-Za-z0-9._-]+\.[a-zA-Z]{2,})$");
            String web = "";
            if (textBox7.Text != "" && webreg.IsMatch(textBox7.Text))
            {
                web = textBox7.Text;
            }
            return web;
        }
        // Мол imenata na sobstvenika
        private String GetMol()
        {
            String mol = "";
            if (textBox8.Text != "")
            {
                if (IsAllLettersAndSpaces(textBox8.Text) == true)
                {
                    mol = textBox8.Text;
                }
            }
            return mol;
        }



        //  Пълни полетата в формата при редактиране
        public void fillText(string line)
        {

            string[] arr = line.Split(';');
            textBox1.Text = arr[0];
            textBox2.Text = arr[2];
            textBox3.Text = arr[3];
            textBox4.Text = arr[4];
            textBox5.Text = arr[5];
            textBox6.Text = arr[6];
            textBox7.Text = arr[7];
            textBox8.Text = arr[8];

            switch (arr[1])
            {
                case "ЕТ":
                    radioButton1.Checked = true;
                    break;
                case "АД":
                    radioButton2.Checked = true;
                    break;
                case "ООД":
                    radioButton3.Checked = true;
                    break;
                case "сдружение":
                    radioButton4.Checked = true;
                    break;
                case "друго":
                    radioButton5.Checked = true;
                    break;

            }

            Itsreplacing = true;
            oldline = line;

        }

        // pri klikane vurhu poleto za wuwejdane na Danuchen nomer vuvejda avtomatichno nomera ot bulstata
        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text.Length == 9)
            {

                textBox3.Text = "BG" + textBox2.Text;
            }
        }












        // ne se polzvat..........................................................
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void imefirma_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //************************************************************************* 
    }
}
