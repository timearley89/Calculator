using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal interface ICalculator
    {
        
        void Add(); 
        void Subtract(); 
        void Multiply(); 
        void Divide();
        void Modulus();
        void Power();
        void Root();
    }
    internal interface ICalcRegisters //: ICalculator
    {
        double RegisterA { get; set; }
        double RegisterB { get; set; }
        double RegisterOut { get; set; }
        void ClearRegs();
        void Init();
        
    }
    internal class CalcReg : ICalcRegisters, ICalculator
    {
        public double RegisterA { get; set; }
        public double RegisterB { get; set; }
        public double RegisterOut { get; set; }
        public void ClearRegs()
        {
            this.Init();
        }
        public void Init()
        {
            this.RegisterA = new double();
            this.RegisterB = new double();
            this.RegisterOut = new double();
        }
        public void Add()
        {
            this.RegisterOut = this.RegisterA + this.RegisterB;
        }
        public void Subtract()
        {
            this.RegisterOut = this.RegisterA - this.RegisterB;
        }
        public void Multiply()
        {
            this.RegisterOut = this.RegisterA * this.RegisterB;
        }
        public void Divide()
        {
            this.RegisterOut = this.RegisterA / this.RegisterB;
        }
        public void Modulus() 
        {
            this.RegisterOut = this.RegisterA % this.RegisterB;
        }
        public void Power()
        {
            this.RegisterOut = Math.Pow(this.RegisterA, this.RegisterB);
        }
        public void PowerCustom()
        {
            this.RegisterOut = 1;
            for (int i = (int)this.RegisterB; i > 0; i--)
            {
                this.RegisterOut *= this.RegisterA;
            }
        }
        public void Root()
        {
            this.RegisterOut = Math.Pow(this.RegisterA, 1.0 / this.RegisterB);
        }
    }
}
