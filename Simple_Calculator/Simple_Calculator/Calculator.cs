using System;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Calculator : Form
    {
        private readonly Stack stack = new Stack();
        private bool first = true;

        public Calculator()
        {
            InitializeComponent();
            first = true;
        }

        private void Calc_1_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "1";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "1";
            }
        }

        private void Calc_2_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "2";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "2";
            }
        }

        private void Calc_3_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "3";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "3";
            }
        }

        private void Calc_4_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "4";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "4";
            }
        }

        private void Calc_5_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "5";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "5";
            }
        }

        private void Calc_6_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "6";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "6";
            }
        }

        private void Calc_7_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "7";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "7";
            }
        }

        private void Calc_8_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "8";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "8";
            }
        }

        private void Calc_9_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "9";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "9";
            }
        }

        private void Calc_0_Button_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Display_Number_Box.Text = "0";
                first = false;
            }
            else
            {
                Display_Number_Box.Text += "0";
            }
        }

        private void Push_Button_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Display_Number_Box.Text);
            if (stack.Push(value))
            {
                ResultBox.Text += "Push: " + value + " (" + stack.ToString() + ")\n";
            }
            else
            {
                ResultBox.Text += "Error: Stack overflow!\n";
            }

            first = true;
            Display_Number_Box.Text = "0";
        }

        private void Pop_Button_Click(object sender, EventArgs e)
        {
            if (stack.Top < 0)
            {
                ResultBox.Text += "Error: Stack underflow!\n";
            }
            else
            {
                string number = stack.Pop().ToString();

                Display_Number_Box.Text = number;
                ResultBox.Text += "Pop: " + number + " (" + stack.ToString() + ")\n";
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (stack.Top < 1)
            {
                ResultBox.Text += "Error: Stack underflow!\n";
            }
            else
            {
                string number = stack.Add().ToString();

                Display_Number_Box.Text = number;

                ResultBox.Text += "ADD \n";
                ResultBox.Text += ">> " + number + " (" + stack.ToString() + ")\n";
            }
        }

        private void Sub_Button_Click(object sender, EventArgs e)
        {
            if (stack.Top < 1)
            {
                ResultBox.Text += "Error: Stack underflow!\n";
            }
            else
            {
                string number = stack.Sub().ToString();

                Display_Number_Box.Text = number;
                ResultBox.Text += "SUB \n";
                ResultBox.Text += ">> " + number + " (" + stack.ToString() + ")\n";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            first = true;
            Display_Number_Box.Text = "0";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Display_Number_Box.Text = Display_Number_Box.Text.Remove(Display_Number_Box.Text.Length - 1);
            if (Display_Number_Box.Text.Length <= 0)
            {
                first = true;
                Display_Number_Box.Text = "0";
            }
        }
    }
}
