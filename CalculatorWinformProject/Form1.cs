using System.Configuration;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace CalculatorWinformProject
{
    public partial class Form1 : Form
    {
        public string[] nums = new string[2];
        public char Op;
        public Form1()
        {

            InitializeComponent();

        }
        private void RepeatControl(char Operator)
        {
            if (string.IsNullOrEmpty(label2.Text) != false)
            {
                return;
            }

            for (int i = 1; i < label2.Text.Length; i++)
            {
                if ((label2.Text[i] == '+' || label2.Text[i] == '-' || label2.Text[i] == '/' || label2.Text[i] == '*') )
                {
                    return;
                }
            }
            if (label2.Text[label2.Text.Length-1]!='.')   //   example=  "  12 . + "   error (after dot,there  has to be digit )
            {
                label2.Text += Operator;
            }
           
            if (Operator == '+')
            {
                Op = '+';
            }
            else if (Operator == '-')
            {
                Op = '-';
            }
            else if (Operator == '/')
            {
                Op = '/';
            }
            else if (Operator == '*')
            {
                Op = '*';
            }
           
        }


        private void Num1_Click(object sender, EventArgs e)
        {
            label2.Text += "1";
        }
        private void Num2_Click(object sender, EventArgs e)
        {

            label2.Text += "2";
        }
        private void Num3_Click(object sender, EventArgs e)
        {
            label2.Text += "3";
        }
        private void Num4_Click(object sender, EventArgs e)
        {

            label2.Text += "4";
        }
        private void Num5_Click(object sender, EventArgs e)
        {
            label2.Text += "5";
        }
        private void Num6_Click(object sender, EventArgs e)
        {
            label2.Text += "6";
        }
        private void Num7_Click(object sender, EventArgs e)
        {
            label2.Text += "7";
        }
        private void Num8_Click(object sender, EventArgs e)
        {
            label2.Text += "8";
        }
        private void Num9_Click(object sender, EventArgs e)
        {
            label2.Text += "9";
        }
        private void Num0_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label2.Text) == false && label2.Text != "0")
            {
                label2.Text += '0';
            }
            else
            {
                label2.Text = "0";
            }
        }
        private void Button13_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label2.Text) == true)
            {
                return;
            }
            label2.Text = label2.Text.Remove(label2.Text.Length - 1);
            //try
            //{
            //    label2.Text = label2.Text.Remove(label2.Text.Length - 1);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error!");
            //    label2.Text = "";
            //    throw;
            //}
        }
        private void OpTimes_Click(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(num1) == false )
            //{
            //    Op = '*';
            //    num2 = num1;
            //    num1 = "";

            //    label1.Text = allProcces += "*";
            //}
            //label2.Text += "*";
            //Op = '*';
            RepeatControl('*');
        }
        private void OpPlus_Click(object sender, EventArgs e)
        {
            RepeatControl('+');
        }
        private void Equal_Click(object sender, EventArgs e)
        {
            if (Op == '+' && char.IsDigit(label2.Text[label2.Text.Length - 1]) == true)
            {

                nums = label2.Text.Split('+');
                label2.Text = nums[0] = (Convert.ToString(Convert.ToDecimal(nums[0]) + Convert.ToDecimal(nums[1])));
                nums[1] = "";
                Op = 'e';
            }
            else if (Op == '*' && char.IsDigit(label2.Text[label2.Text.Length - 1]) == true)
            {

                nums = label2.Text.Split('*');
                label2.Text = nums[0] = (Convert.ToString(Convert.ToDecimal(nums[0]) * Convert.ToDecimal(nums[1])));
                nums[1] = "";
                Op = 'e';


            }
            else if (Op == '/')
            {

                nums = label2.Text.Split('/');
                if (nums[1] == "0" && nums[0] != "0")
                {
                    MessageBox.Show("CAN NOT DEVIDED BY ZERO");    //    digit/0 error
                    label2.Text = string.Empty;
                    return;
                }
                else if (nums[1] == "0" && nums[0] == "0")       //       0/0 error
                {
                    MessageBox.Show("Result is undefined");
                    label2.Text = string.Empty;
                    return;
                }
                label2.Text = nums[0] = (Convert.ToString(Convert.ToDecimal(nums[0]) / Convert.ToDecimal(nums[1])));
                nums[1] = "";
                Op = 'e';
            }
            else if (Op == '-')
            {
                // -5 -5 toplama iþlemi hatasý !!!! düzelt
                nums = label2.Text.Split('-');
                label2.Text = nums[0] = (Convert.ToString(Convert.ToDecimal(nums[0]) - Convert.ToDecimal(nums[1])));  // if we write convert.toDouble, there is some promlems gonna show up. /*
                                                                                                                      // like 2.3 - 0.3 = 1.9999;
                                                                                                                      //
                                                                                                                      //
                                                                                                                      //double a=Convert.ToDouble( Console.ReadLine());
                                                                                                                      //double b = Convert.ToDouble(Console.ReadLine());
                                                                                                                      //Console.WriteLine(a + b);
                                                                                                                      //Console.WriteLine(a - b);
                                                                                                                      //When we enter the values 2.3 into the first variable and - 0.3 into the second variable, it returns the wrong result, 1.99999.



                nums[1] = "";
                Op = 'e';
            }
        }
        private void OpDivided_Click(object sender, EventArgs e)
        {
            //Op = '/';
            //num2 = num1;
            //num1 = "";
            //label1.Text = allProcces += "/";
            //Op = '/';
            //label2.Text += '/';
            RepeatControl('/');
        }

        private void OpMinus_Click(object sender, EventArgs e)
        {
            RepeatControl('-');
            //Op = '-';
            //label2.Text += '-';
            //Op = '-';
            //num2 = num1;
            //num1 = "";
            //label1.Text = allProcces += "-";
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            Op = 'e';
            nums[0] = "";
            nums[1] = "";
        }
        private void Dot_Click(object sender, EventArgs e)
        {
            int numberOfDots = 0;
            bool ifOperator = false;
            if (string.IsNullOrEmpty(label2.Text) != false)
            {
                return;
            }

            for (int i = 0; i < label2.Text.Length ; i++)
            {
                if (label2.Text[i] == '+' || label2.Text[i] == '-' || label2.Text[i] == '/' || label2.Text[i] == '*')
                {
                    ifOperator = true;    // if operators are ( + - * /) inside the label2.Txt ifOperator=true 

                }
                if (label2.Text[i] == '.')
                {
                    numberOfDots++;
                }
            }
            if (((char.IsDigit(label2.Text[label2.Text.Length-1])==true && (ifOperator == false && (numberOfDots == 0)  || (ifOperator == true && (numberOfDots == 0 || numberOfDots == 1))))))
            {
                label2.Text += '.';
            }


            
            

        }
    }
}