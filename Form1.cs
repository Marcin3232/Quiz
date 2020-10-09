using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {

        public int score = 0;
        public int i = 0;
        public string takeAnswer = "";
        Quiz quiz = new Quiz();
        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
            labelTitle.MaximumSize = new Size(600, 0);
            labelTitle.AutoSize = true;
            Start();




        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        public void Start()
        {
            int pytanie = i + 1;
            labelTitle.Text = pytanie + "." + quiz.Questions[i].Title;
            checkBoxA.Text = "A)" + quiz.Questions[i].AnswerA;
            checkBoxB.Text = "B)" + quiz.Questions[i].AnswerB;
            checkBoxC.Text = "C)" + quiz.Questions[i].AnswerC;

        }



        private void buttonStart_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;
        }



        private string actualCheckAnswer(string a)
        {
            if (checkBoxA.Checked == true)
            {
                return a = "A";
            }
            if (checkBoxB.Checked == true)
            {
                return a = "B";
            }
            if (checkBoxC.Checked == true)
            {
                return a = "C";
            }
            return null;
        }


        private void getScore()

        {

            string answer = actualCheckAnswer(takeAnswer);
            if (answer == quiz.Questions[i].RightAnswerLetter)
            {
                score++;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if ((checkBoxA.Checked || checkBoxB.Checked || checkBoxC.Checked) == true)
            {
                try
                {
                    getScore();
                    i++;
                    Start();
                    checkBoxA.Checked = false;
                    checkBoxB.Checked = false;
                    checkBoxC.Checked = false;


                }
                catch (Exception ex)
                {
                    int max = i;
                    panel2.Visible = true;
                    panel1.Visible = true;
                    labelScore.Text = score.ToString() + "/" + max.ToString();
                }
            }
            else
            {

                MessageBox.Show("Zaznacz jakąś odpowiedź");

            }
        }

        private void checkBoxA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxA.Checked == true)
            {
                checkBoxB.Checked = false;
                checkBoxC.Checked = false;
            }
        }

        private void checkBoxB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxB.Checked == true)
            {
                checkBoxA.Checked = false;
                checkBoxC.Checked = false;
            }
        }

        private void checkBoxC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxC.Checked == true)
            {
                checkBoxB.Checked = false;
                checkBoxA.Checked = false;
            }
        }

        private void buttonAgainGame_Click(object sender, EventArgs e)
        {
            i = 0;
            score = 0;
            takeAnswer = "";
            panel2.Visible = false;
            panel1.Visible = false;
            Start();
        }
    }
}
