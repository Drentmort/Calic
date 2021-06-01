using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcil
{
    public partial class MainForm : Form
    {
        string leftNum = "";
        string rightNum = "";
        string sign = "";
        bool isSecondNum = false;
        int pointNum1 = 0;
        int pointNum2 = 0;

        public MainForm()
        {
            InitializeComponent();
            leftNum = "";
            rightNum = "";
            sign = "";
            isSecondNum = false;
            pointNum1 = 0;
            pointNum2 = 0;
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            numberButton1.ButtonHasPressed += Number_ButtonPressed;
            numberButton2.ButtonHasPressed += Number_ButtonPressed;
            numberButton3.ButtonHasPressed += Number_ButtonPressed;
            numberButton4.ButtonHasPressed += Number_ButtonPressed;
            numberButton5.ButtonHasPressed += Number_ButtonPressed;
            numberButton6.ButtonHasPressed += Number_ButtonPressed;
            numberButton7.ButtonHasPressed += Number_ButtonPressed;
            numberButton8.ButtonHasPressed += Number_ButtonPressed;
            numberButton9.ButtonHasPressed += Number_ButtonPressed;
            numberButton0.ButtonHasPressed += Number_ButtonPressed;
            Dot.ButtonHasPressed += Number_ButtonPressed;
            Plus.ButtonHasPressed += Sign_ButtonPressed;
            Minus.ButtonHasPressed += Sign_ButtonPressed;
            Mult.ButtonHasPressed += Sign_ButtonPressed;
            Divide.ButtonHasPressed += Sign_ButtonPressed;
            Result.ButtonHasPressed += Result_ButtonPressed;
            Reset.ButtonHasPressed += Reset_ButtonPressed;

        }

        private void Reset_ButtonPressed(string obj)
        {
            leftNum = "";
            rightNum = "";
            sign = "";
            isSecondNum = false;
            pointNum1 = 0;
            pointNum2 = 0;
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
        }

        private void Result_ButtonPressed(string obj)
        {
            double num1;
            double num2;
            double result;
            bool haveNum1 = double.TryParse(leftNum, out num1);
            bool haveNum2 = double.TryParse(rightNum, out num2);

            if (!haveNum1 || !haveNum2 || sign.Length > 1)
            {
                leftNum = "";
                rightNum = "";
                sign = "";
                isSecondNum = false;
                pointNum1 = 0;
                pointNum2 = 0;
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "Incorrect input";
                return;
            }

            if (sign.Contains("+"))
                result = num1 + num2;
            else if (sign.Contains("-"))
                result = num1 - num2;
            else if (sign.Contains("*"))
                result = num1 * num2;
            else if (sign.Contains("/"))
            {
                if (num2 == 0)
                {
                    leftNum = "";
                    rightNum = "";
                    sign = "";
                    isSecondNum = false;
                    pointNum1 = 0;
                    pointNum2 = 0;
                    label1.Text = "";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "Infinity";
                    return;
                }
                result = num1 / num2;
            }
            else result = double.NaN;

            leftNum = "";
            rightNum = "";
            sign = "";
            isSecondNum = false;
            pointNum1 = 0;
            pointNum2 = 0;
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = result.ToString();
        }

        private void Sign_ButtonPressed(string obj)
        {
            if (rightNum.Length == 0 && leftNum.Length != 0)
            {
                sign = obj;
                label3.Text = sign;
                isSecondNum = true;
            }
            
        }

        private void Number_ButtonPressed(string obj)
        {
            InputNum(obj);
        }

        void InputNum(string input)
        {
            label4.Text = "";
            if (!isSecondNum)
            {
                if (input.Contains(","))
                    pointNum1++;

                if (pointNum1 > 1 && input.Contains(","))
                {
                    return;
                }

                leftNum += input;
                if (leftNum.Length > 11)
                    label1.Text = leftNum.Substring(leftNum.Length - 10);
                else
                    label1.Text = leftNum;
            }

            else
            {
                if (input.Contains(","))
                    pointNum2++;

                if (pointNum2 > 1 && input.Contains(","))
                {
                    return;
                }

                rightNum += input;
                if (rightNum.Length > 11)
                    label2.Text = rightNum.Substring(rightNum.Length - 10);
                else
                    label2.Text = rightNum;
            }

        }

    }
}
