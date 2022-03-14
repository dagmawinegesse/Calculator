using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* this program will do basic operation of a calculator but it also includes
 a menu strip to let the user choose from standard calculator, scientific calculator and 
 temperature converter. The first load if the program will show the standard calculator.*/
namespace Calculator
{
    public partial class Form1 : Form
    {
        //declare variables 
        Double results = 0;
        String operation = "";
        bool enter_Value = false;
        char tempoperation;
        float celcius,fah,kelvin;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            //will calculate the sinh
            double sinh = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("Sinh" + "(" + (txtdisplay.Text) + ")");
            sinh = Math.Sinh(sinh);
            txtdisplay.Text = System.Convert.ToString(sinh);
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //adjust's the size of the standard calculator
            this.Width = 370;
            txtdisplay.Width = 310;
        }

        private void sientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //adjust's the size of the scientific calculator 
            this.Width = 770;
            txtdisplay.Width = 700;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //the size of the view shown when the program runs first
            this.Width = 370;
            txtdisplay.Width = 320;
        }

        private void numbutton_click(object sender, EventArgs e)
        {
                  /*since the numbers are in a grouped function click this will
                    this will take the numbers and display the number in the text box.
                    --> It will also take care of the dot if it is clicked more than once, 
                    in which it will not allow the user to enter the dot button more than once */
            if ((txtdisplay.Text == "0") || (enter_Value))
                txtdisplay.Text = "";
            enter_Value = false;
            Button num = (Button)sender;


            if (num.Text == ".")
            {
                if (!txtdisplay.Text.Contains("."))
                    txtdisplay.Text = txtdisplay.Text + num.Text;


            }
            else
                txtdisplay.Text = txtdisplay.Text + num.Text;


        }

        private void cancelallButton_Click(object sender, EventArgs e)
        {
            //when cancel button is clicked it will display an empty text box
            txtdisplay.Text = "0";
            lblshowOperation.Text = "";
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
                //will remove one number at a time when the backspace button is clicked
            if (txtdisplay.Text.Length > 0)
            {
                txtdisplay.Text = txtdisplay.Text.Remove(txtdisplay.Text.Length - 1, 1);
            }
            if (txtdisplay.Text == "")
                txtdisplay.Text = "0";
        }

        private void arithmeticOperation(object sender, EventArgs e)
        {
                
            Button num = (Button)sender;
            operation = num.Text;
            results = Double.Parse(txtdisplay.Text);
            txtdisplay.Text = "";
            lblshowOperation.Text = System.Convert.ToString(results) + " " + operation ;


        }

        private void equals_Click(object sender, EventArgs e)
        {
            //lblshowOperation.Text = "";
            switch (operation)
            {
                    //takes care of the addition button 
                case "+":
                    txtdisplay.Text = (results + Double.Parse(txtdisplay.Text)).ToString();
                   
                    break;
                    //takes care of the substraction button
                case "-":
                    txtdisplay.Text = (results - Double.Parse(txtdisplay.Text)).ToString();
                    break;
                    //takes care of the multiplication button
                case "*":
                    txtdisplay.Text = (results * Double.Parse(txtdisplay.Text)).ToString();
                    break;
                    //takes care of the divison button
                case "/":
                    txtdisplay.Text = (results / Double.Parse(txtdisplay.Text)).ToString();
                    break;
                    //will find the power of any given number for eg.3^2=9
                case "EXP":
                    double i = Double.Parse(txtdisplay.Text);
                    double q = results;
                    txtdisplay.Text = Math.Exp(i * Math.Log(q * 4)).ToString();
                    break;
                    //takes care of the MOD function
                case "MOD":
                    txtdisplay.Text = (results % Double.Parse(txtdisplay.Text)).ToString();

                    break;


            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            /*display pi when clicked but if the txt box already include a number 
            it will display the number multiplied with pi*/
            double pi = 3.141592653589977323;

            if (txtdisplay.Text == "0" &&  sender.Equals(button40))
            {

                txtdisplay.Text = pi.ToString();
            }
            else if(txtdisplay.Text != "" && sender.Equals(button40))
            {

                txtdisplay.Text = (pi * Double.Parse(txtdisplay.Text)).ToString();
                
            }

          
                
            
            
        }

        private void MOD_Click(object sender, EventArgs e)
        {
            //calculates the MOD
            
            lblshowOperation.Text = "";
            results = Double.Parse(txtdisplay.Text);

            Button num = (Button)sender;
            if( num.Text == "MOD")
            {
               
                txtdisplay.Text = (results % Double.Parse(txtdisplay.Text)).ToString();
            }
            
            
        }

        private void LOG_Click(object sender, EventArgs e)
        {
            //finds the logarithm
            double log = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text =System.Convert.ToString("log"+ "(" + (txtdisplay.Text)+ ")");
            log = Math.Log10(log);
            txtdisplay.Text = System.Convert.ToString(log);
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            //finds the sqaure root of a number
            double sqrt = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("√" + "(" + (txtdisplay.Text) + ")");
            sqrt = Math.Sqrt(sqrt);
            txtdisplay.Text = System.Convert.ToString(sqrt);
        }

        private void powerby2_Click(object sender, EventArgs e)
        {
            //finds the double of a number
            double doubled = Double.Parse(txtdisplay.Text);
           

            lblshowOperation.Text = System.Convert.ToString("(" + (txtdisplay.Text) + ")" +"^2");
            doubled = Math.Pow(doubled,2);
            txtdisplay.Text = System.Convert.ToString(doubled);
        }

        private void poweredby3_Click(object sender, EventArgs e)
        {
            //calculates the triple of a number
            double thripled = Double.Parse(txtdisplay.Text);


            lblshowOperation.Text = System.Convert.ToString("(" + (txtdisplay.Text) + ")" + "^");
            thripled = Math.Pow(thripled, 3);
            txtdisplay.Text = System.Convert.ToString(thripled);
        }

        private void Sin_Click(object sender, EventArgs e)
        {
            //calculates the sin
            double sin = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("Sin" + "(" + (txtdisplay.Text) + ")");
            sin = Math.Sin(sin);
            txtdisplay.Text = System.Convert.ToString(sin);
        }

        private void Cosh_Click(object sender, EventArgs e)
        {
            //calculates the cosh
            double Cosh = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("Cosh" + "(" + (txtdisplay.Text) + ")");
            Cosh = Math.Cosh(Cosh);
            txtdisplay.Text = System.Convert.ToString(Cosh);
        }

        private void Cos_Click(object sender, EventArgs e)
        {
            //calculates the cos 
            double Cos = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("Cos" + "(" + (txtdisplay.Text) + ")");
            Cos = Math.Cos(Cos);
            txtdisplay.Text = System.Convert.ToString(Cos);
        }

        private void Tanh_Click(object sender, EventArgs e)
        {
            //finds the Tanh
            double Tanh = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("Tanh" + "(" + (txtdisplay.Text) + ")");
            Tanh = Math.Tanh(Tanh);
            txtdisplay.Text = System.Convert.ToString(Tanh);
        }

        private void Tan_Click(object sender, EventArgs e)
        {
            //finds the Tan
            double Tan = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("Tan" + "(" + (txtdisplay.Text) + ")");
            Tan = Math.Tanh(Tan);
            txtdisplay.Text = System.Convert.ToString(Tan);

        }

        private void ToDec_Click(object sender, EventArgs e)
        {
            int num = int.Parse(txtdisplay.Text);
            txtdisplay.Text = System.Convert.ToString(num);

        }

        private void ToOct_Click(object sender, EventArgs e)
        {
            //converts to oct
            int num = int.Parse(txtdisplay.Text);
            txtdisplay.Text = System.Convert.ToString(num,8);
        }

        private void toBinary_Click(object sender, EventArgs e)
        {
            //converts to binary

            int num = int.Parse(txtdisplay.Text);
            txtdisplay.Text = System.Convert.ToString(num, 2);
        }

        private void ToHex_Click(object sender, EventArgs e)
        {
            //converts to Hexadecimal

            int num = int.Parse(txtdisplay.Text);
            txtdisplay.Text = System.Convert.ToString(num, 16);
        }

        private void inverse_Click(object sender, EventArgs e)
        {
            //finds the inverse 
            double a = 1.0;

            a = (a / Convert.ToDouble(txtdisplay.Text));
            txtdisplay.Text = System.Convert.ToString(a);
        }

        private void naturalLog_Click(object sender, EventArgs e)
        {
            //find the natural log
            double lnx = Double.Parse(txtdisplay.Text);
            lblshowOperation.Text = System.Convert.ToString("ln" + "(" + (txtdisplay.Text) + ")");
            lnx = Math.Log(lnx);
            txtdisplay.Text = System.Convert.ToString(lnx);
        }

        private void findpercentage_Click(object sender, EventArgs e)
        {
            //will find the percentage 
            double a = Double.Parse(txtdisplay.Text);
            a = a / Convert.ToDouble(100);
            txtdisplay.Text = System.Convert.ToString(a);

        }

        private void temperatureConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1100;
            txtdisplay.Width = 700;
        }

        private void celToFahrenite_CheckedChanged(object sender, EventArgs e)
        {
            //represent cel with c
            tempoperation = 'C';
        }

        private void FahToCel_CheckedChanged(object sender, EventArgs e)
        {
            //represent fah with f
            tempoperation = 'F';
        }

        private void ToKevin_CheckedChanged(object sender, EventArgs e)
        {
            //represent kelvin with l
            tempoperation = 'K';
        }

        private void convertAction_Click(object sender, EventArgs e)
        {
            /*using switch statments convert cel to Fah
             * convert fah to cel
             * and also convert to kelvin*/

            switch (tempoperation)
            {
                case 'C':
                    celcius = float.Parse(txtEnterValue.Text);
                    txtConverted.Text = (((9 * celcius) / 5) + 32).ToString();
                    break;
                case 'F':
                    fah = float.Parse(txtEnterValue.Text);
                    txtConverted.Text = (((fah-32)*5)/9).ToString();
                    break;
                case 'K':
                    kelvin = float.Parse(txtEnterValue.Text);
                    txtConverted.Text = ((((9 * kelvin) / 5) + 32) + 273.15).ToString();
                    break;
            }
        }
    }
}
