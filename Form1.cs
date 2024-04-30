using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        private Random random;
        private Dictionary<string, string> previousAnswers;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            previousAnswers = new Dictionary<string, string>();
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            string question = input.Text;
            //Приведение всех букв к нижнему регистру и удаление всей пунктуации, чтобы она не прияла на содержание вопроса
            question = question.ToLower();
            question = Regex.Replace(question, "\\p{P}", string.Empty);
            question = Regex.Replace(question, " ", string.Empty);

            if (previousAnswers.ContainsKey(question))
            {
                label_Answer.Text = previousAnswers[question];
            }
            else
            {
                int randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    label_Answer.Text = "Yes";
                }
                else
                {
                    label_Answer.Text = "No";
                }
                previousAnswers[question] = label_Answer.Text;
            }
        }
    }
}
