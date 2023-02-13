using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HopFieldCode
{
    public partial class Form1 : Form
    {
        int[] plus = { 0, 1, 0, 1, 1, 1, 0, 1, 0 };
        int[] minus = { 0, 0, 0, 1, 1, 1, 0, 0, 0 };
        List<int> res;
        List<int[]> weights;
        List<int> UIinput;
        int[] wt1 = { 0, 0, 2, -2, -2, -2, 2, 0, 2 };
        int[] wt2 = { 0, 0, 0, 0, 0, 0, 0, 2, 0 };
        int[] wt3 = { 2, 0, 0, -2, -2, -2, 2, 0, 2 };
        int[] wt4 = { 2, 0, -2, 0, 2, 2, -2, 0, -2 };
        int[] wt5 = { 2, 0, -2, 2, 0, 2, -2, 0, -2 };
        int[] wt6 = { 2, 0, -2, 2, 2, 0, -2, 0, -2 };
        int[] wt7 = { 2, 0, 2, -2, -2, -2, 0, 0, 2 };
        int[] wt8 = { 0, 2, 0, 0, 0, 0, 0, 0, 0 };
        int[] wt9 = { 2, 0, 2, -2, -2, -2, 2, 0, 0 };

        public Form1()
        {
            InitializeComponent();
            weights = new List<int[]>();
            UIinput = new List<int>();
            res = new List<int>();
            weights.Add(wt1);
            weights.Add(wt2);
            weights.Add(wt3);
            weights.Add(wt4);
            weights.Add(wt5);
            weights.Add(wt6);
            weights.Add(wt7);
            weights.Add(wt8);
            weights.Add(wt9);
        }

        /// <summary>
        /// Changes the color of a button to either Black or White
        /// </summary>
        /// <param name="button"> Input button </param>
        private void ButtonColorChange(Button button)
        {
            if (button.BackColor == Color.White)
                button.BackColor = Color.Black;
            else
                button.BackColor = Color.White;
        }

        /// <summary>
        /// Calculates the hopfield 
        /// </summary>
        /// <param name="input">Given input from the 3x3 buttons</param>
        /// <returns>Returns the correspending string output</returns>
        private String Calculate(List<int> input)
        {
            int temp;
            int i;
            var inp = input.ToArray();
            bool isPlus = true;
            bool isMinus = true;
            int ctr = 0;

            while (true)
            {
                ctr++;

                // Actual Calculation
                foreach (var weight in weights)
                {
                    temp = 0;
                    for (i = 0; i < 9; i++)
                    {
                        temp += weight[i] * inp[i];
                    }
                    if (temp < 1)
                        res.Add(0);
                    else
                        res.Add(1);
                }

                // Assign res to a new variable r
                var r = res.ToArray();
                res.Clear();

                // Checks if res is equal to plus
                for (int j = 0; j < 9; j++)
                {
                    if (r[j] != plus[j])
                    {
                        isPlus = false;
                    }
                }

                // Checks if res is equal to minus
                for (int k = 0; k < 9; k++)
                {
                    if (r[k] != minus[k])
                    {
                        isMinus = false;
                    }
                }

                // Breaks out of the loop if res equals to either plus or minus or iteration exceeds 999
                if (isPlus == true || isMinus == true || ctr == 999)
                    break;

                // Assign both isPlus and isMinus as true to re-iterate
                else
                {
                    inp = r;
                    isPlus = true;
                    isMinus = true;
                }
            }

            if (isPlus) { return "plus +"; }

            if (isMinus) { return "minus -"; }

            return "Cannot be identified!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Get all the boxes value.
            // 1 for black 0 for white.
            var buttonsOnForm = this.Controls.OfType<Button>();
            var listOfButtons = buttonsOnForm.ToList();

            // Removes the non input button "Identify" and "Reset"
            listOfButtons.RemoveAt(0);
            listOfButtons.RemoveAt(0);
            listOfButtons.Reverse();

            foreach (var btn in listOfButtons)
            {
                if (btn.BackColor == Color.Black)
                    UIinput.Add(1);
                else
                    UIinput.Add(0);
            }

            var res = Calculate(UIinput);
            textBox1.Text = res;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UIinput.Clear();
            res.Clear();
            textBox1.Text = "";
            var buttonsOnForm = this.Controls.OfType<Button>();
            var listOfButtons = buttonsOnForm.ToList();
            listOfButtons.RemoveAt(0);
            listOfButtons.RemoveAt(0);
            foreach (var btn in listOfButtons)
            {
                btn.BackColor = Color.White;
            }
        }
    }
}