using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        //'Global' variables
        private string InputNumberA;
        private string InputNumberB;
        private char Operator;

        private string Calculate(string inputA, string inputB, char operation)
        {
            switch (operation)
            {
                case '+':
                    {
                        return (Double.Parse(inputA) + Double.Parse(inputB)).ToString();
                    }
                case '-':
                    {
                        return (Double.Parse(inputA) - Double.Parse(inputB)).ToString();
                    }
                case '*':
                    {
                        return (Double.Parse(inputA) * Double.Parse(inputB)).ToString();
                    }
                case '/':
                    {
                        return (Double.Parse(inputA) / Double.Parse(inputB)).ToString();
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            txtCalc.Text = "0";
            Operator = 'x';
            InputNumberA = "0";
            InputNumberB = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCalc.Text = "0";
            InputNumberA = "0";
            InputNumberB = "0";
            Operator = 'x';
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //set operand, and move string from txtcalc into inputnumbera, then reset txtcalc for getting inputnumberb.
            //In the next revision, change data structure to use a dynamic list of strings that can be parsed as a series of continuous operations.
            Operator = '+';
            InputNumberA = txtCalc.Text;
            txtCalc.Text = "0";
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            Operator = '-';
            InputNumberA = txtCalc.Text;
            txtCalc.Text = "0";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Operator = '*';
            InputNumberA = txtCalc.Text;
            txtCalc.Text = "0";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Operator = '/';
            InputNumberA = txtCalc.Text;
            txtCalc.Text = "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtCalc.Text.Contains('.')){ txtCalc.Text += '.'; }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            InputNumberB = txtCalc.Text;
            string results = Calculate(InputNumberA, InputNumberB, Operator);
            if (results != "") { txtCalc.Text = results.ToString(); }
            //if no operator was selected, leave the textbox alone. Just reset the operand anyway.
            Operator = 'x';
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text != "0") { txtCalc.Text += '0'; }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '1';
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '2';
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '3';
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '4';
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '5';
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '6';
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '7';
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '8';
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '9';
        }
    }
}
