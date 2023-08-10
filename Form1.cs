using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        /* When an operand is selected (not equals), if the parsed value is different than regout, move the parsed value into regB(or perform calculation and move result?. 
         * If it's the same, move regout into regA.
         * 
         * when operand selected, if operand is empty, parse to rega. if operand != empty, then a calculation was just performed, so calc rega-op-(parse)regb and move result
         * to regout. 
         * -regA[0] regB[0] regout[0 or prev. calc result]
         * 0+4+12=16
         * -press 0
         * -press + (operand = 'x' so mov regout[0] to regA, set operand to '+')
         * -press 4
         * -press + (mov 4 to regB, add regA+regB, mov regout to regA[4], set operand to '+')
         * -press 12
         * -press = (mov 12 to regB, add regA+regB, mov regout to regA[16], set operand to '=')
         * 
         * Operand()
         * {
         *      mov regout to rega
         *      parse to regb
         *      calc(rega, regb, operand, out regout)
         *      update()
         * }
         * a[] b[] o[]
         * a[0] b[0] o[0]
         * -type 2
         * ->update()
         * -type +
         * ->mov 0 to a
         * ->mov 2 to b
         * ->calc(0, 2, '+', 2)
         * -type 4
         * ->update()
         * -type +
         * ->mov 2 to a
         * ->mov 4 to b
         * ->calc(2, 4, '+', 6)
         * -type 3
         * ->update()
         * -type -
         * ->mov 6 to a
         * ->mov 3 to b
         * ->calc(6, 3, '+', 9) //operand needs to be set AFTER calculation.
         * ->operand = '-'
         * -type 5
         * -type =
         * ->mov 9 to a
         * ->mov 5 to b
         * ->calc(9, 5, '-', 4)
         * --void Calculate(double RegA, double RegB, char Operand, out double RegOut)
         * --{
         * --   Move RegOut to RegA.
         * --   Move In to RegB.
         * --   Calculate RegA and RegB with PREVIOUS operand.(if 'x', then RegOut = RegA;)
         * --   Set operand = NEW operand input.
         * --   Update display.
         * --}
         */

        //'Global' variables
        private string InputNumberA;
        private string InputNumberB;
        private char Operator;
        private string CalcResult;
        private CalcReg calcReg;
        private bool RegAset = false;

        private double Calculate(double inputA, double inputB, char operation)
        {
            calcReg.RegisterA = inputA;
            calcReg.RegisterB = inputB;
            
            switch (operation)
            {
                case 'x':
                    {
                        calcReg.RegisterOut = calcReg.RegisterA;
                        break;
                    }
                case '+':
                    {
                        calcReg.Add();
                        break;
                    }
                case '-':
                    {
                        calcReg.Subtract();
                        break;
                    }
                case '*':
                    {
                        calcReg.Multiply();
                        break;
                    }
                case '/':
                    {
                        calcReg.Divide();
                        break;
                    }
                case '&':
                    {
                        calcReg.Modulus(); break;
                    }
                case '^':
                    {
                        calcReg.Power(); break;
                    }
                case '~':
                    {
                        calcReg.Root(); break;
                    }
                default:
                    {
                        calcReg.RegisterOut = calcReg.RegisterA;
                        break;
                    }
            }
            UpdateLabels();
            return calcReg.RegisterOut;
        }
        public void UpdateLabels()
        {
            lblRegA.Text = "RegisterA: "+calcReg.RegisterA.ToString();
            lblRegB.Text = "RegisterB: " + calcReg.RegisterB.ToString();
            lblRegOut.Text = "RegisterOut: " + calcReg.RegisterOut.ToString();
            
        }

        public frmCalculator()
        {
            InitializeComponent();
            calcReg = new CalcReg();
            
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            calcReg.Init();
            UpdateLabels();
            Operator = 'x';
            InputNumberA = calcReg.RegisterA.ToString();
            InputNumberB = calcReg.RegisterB.ToString();
            txtCalc.Text = calcReg.RegisterOut.ToString();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtCalc.Text = "0";
            calcReg.ClearRegs();
            RegAset = false;
            InputNumberA = calcReg.RegisterA.ToString();
            InputNumberB = calcReg.RegisterB.ToString();
            Operator = 'x';
            txtCalc.Text = calcReg.RegisterOut.ToString();
            
            UpdateLabels();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
             * parse strIn to regA, iff Op=='x'. if Op!='x', set regA to regOut, parse strIn to regB, set txt to regOut
            */

            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }
            
            Operator = '+';
            UpdateLabels();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {

            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }

            Operator = '-';
            UpdateLabels();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {

            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }

            Operator = '*';
            UpdateLabels();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }

            Operator = '/';
            UpdateLabels();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtCalc.Text.Contains('.')) { txtCalc.Text += '.'; }
            UpdateLabels();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {

            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = calcReg.RegisterOut.ToString(); }

            Operator = '=';
            UpdateLabels();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text != "0") { txtCalc.Text += '0'; }
            UpdateLabels();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '1';
            UpdateLabels();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '2';
            UpdateLabels();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '3';
            UpdateLabels();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '4';
            UpdateLabels();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '5';
            UpdateLabels();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '6';
            UpdateLabels();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '7';
            UpdateLabels();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '8';
            UpdateLabels();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtCalc.Text == "0") { txtCalc.Text = ""; }
            txtCalc.Text += '9';
            UpdateLabels();
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }

            Operator = '~';
            UpdateLabels();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }

            Operator = '%';
            UpdateLabels();
        }
        private void btnPower_Click(object sender, EventArgs e)
        {
            if (!RegAset) { calcReg.RegisterA = Double.Parse(txtCalc.Text); RegAset = true; txtCalc.Text = "0"; }
            else { calcReg.RegisterA = Calculate(calcReg.RegisterA, Double.Parse(txtCalc.Text), Operator); txtCalc.Text = "0"; }

            Operator = '^';
            UpdateLabels();
        }

        
    }
}
