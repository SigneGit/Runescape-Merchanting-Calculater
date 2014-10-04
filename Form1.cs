using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runescape_Merchanting_Calculater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int BuyingFor = 0;

        public int SellingFor = 0;

        public int Quantity = 0;

        public int Profit = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        public void Calculate()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;
            if (string.IsNullOrEmpty(textBox2.Text))
                return;
            if (string.IsNullOrEmpty(textBox3.Text))
                return;
            try
            {
                SellingFor = Convert.ToInt32(textBox1.Text);
            }
            catch (OverflowException)
            {
                LabelProfit.Text = "Int to large!";
                textBox1.Text = "";
                return;
            }
            catch (FormatException)
            {
                label1.Text = "Letters cannot be entered";
                textBox1.Text = "";
                return;
            }
            try
            {
                BuyingFor = Convert.ToInt32(textBox2.Text);
            }
            catch (OverflowException)
            {
                LabelProfit.Text = "Int to large!";
                textBox2.Text = "";
                return;
            }
            catch (FormatException)
            {
                label2.Text = "Letters cannot be entered";
                textBox2.Text = "";
                return;
            }
            try
            {
                Quantity = Convert.ToInt32(textBox3.Text);
            }
            catch (OverflowException)
            {
                LabelProfit.Text = "Int to large!";
                textBox3.Text = "";
                return;
            }
            catch (FormatException)
            {
                label5.Text = "Letters cannot be entered";
                textBox3.Text = "";
                return;
            }
            int _SellingFor = Quantity * SellingFor;
            int _BuyingFor = Quantity * BuyingFor;
            int _Margin = SellingFor - BuyingFor;

            int Profit = _SellingFor - _BuyingFor;
            if (label1.Text != "Selling For:")
                label1.Text = "Selling For:";
            if (label2.Text != "Buying For:")
                label2.Text = "Buying For:";
            if (label5.Text != "Quantity:")
                label5.Text = "Quantity:";

            LabelProfit.Text = String.Format("{0:N0}", Profit);
            labelInput.Text = String.Format("{0:N0}", _BuyingFor);
            labelOutput.Text = String.Format("{0:N0}", _SellingFor);
            labelMargin.Text = String.Format("{0:N0}", _Margin);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                return;
            if (string.IsNullOrEmpty(textBox2.Text))
                return;
            if (string.IsNullOrEmpty(textBox3.Text))
                return;
            string Copy = "";

            Copy += "Item: " + textBox4.Text + "\n";

            Copy += "Selling For: " + textBox1.Text + "\n";
            Copy += "Buying For: " + textBox2.Text + "\n";
            Copy += "Quantity: " + textBox3.Text + "\n";
            Copy += "Profit: " + LabelProfit.Text + "\n";
            Copy += "Input: " + labelInput.Text + "\n";
            Copy += "Output: " + labelOutput.Text + "\n";
            Clipboard.SetText(Copy);
        }




    }
}
