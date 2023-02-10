using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.Optimization.LineSearch;
using MathNet.Numerics.Providers.FourierTransform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button10_Click(object sender, EventArgs e)
        {
            //Get all the boxes value 1 for black 0 for white
            var buttonsOnForm = this.Controls.OfType<Button>();
            var listOfButtons = buttonsOnForm.ToList();
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

        private String Calculate(List<int> input)
        {
            int temp;
            int i;
            var inp = input.ToArray();
            bool isPlus = true;
            bool isMinus = true;
            while (true)
            {
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
                var r = res.ToArray();
               // Console.WriteLine("---------------");    
                res.Clear();
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine(r[j] + "==" + plus[j]);
                    if (r[j] != plus[j])
                    {
                        isPlus = false;
                    }
                }
                //Console.WriteLine("plus above--------------- minus below");
                for (int k = 0; k < 9; k++)
                {
                    Console.WriteLine(r[k] + "==" + minus[k]);
                    if (r[k] != minus[k])
                    {
                        isMinus = false;
                    }
                }
                if (isPlus == true || isMinus == true)
                    break;
                else
                {
                    inp = r;
                    isPlus = true;
                    isMinus = true;
                }

            }
            if (isPlus)
                return "plus +";
            if (isMinus)
                return "minus -";
            else
                return "Cannot be identified!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.White)
                button1.BackColor = Color.Black;
            else
                button1.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.White)
                button2.BackColor = Color.Black;
            else
                button2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.White)
                button3.BackColor = Color.Black;
            else
                button3.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.White)
                button4.BackColor = Color.Black;
            else
                button4.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.White)
                button5.BackColor = Color.Black;
            else
                button5.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.White)
                button6.BackColor = Color.Black;
            else
                button6.BackColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.White)
                button7.BackColor = Color.Black;
            else
                button7.BackColor = Color.White;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.White)
                button8.BackColor = Color.Black;
            else
                button8.BackColor = Color.White;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.White)
                button9.BackColor = Color.Black;
            else
                button9.BackColor = Color.White;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UIinput.Clear();
            res.Clear();
            var buttonsOnForm = this.Controls.OfType<Button>();
            var listOfButtons = buttonsOnForm.ToList();
            listOfButtons.RemoveAt(0);
            listOfButtons.RemoveAt(0);
            foreach(var btn in listOfButtons)
            {
                btn.BackColor = Color.White;
            }
        }
    }
}
