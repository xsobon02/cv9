using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace cv9
{
    // treba davat vzdy CE ak chceme zacat operaciu s novymi cislami, musel som vypisat do first a second 0 aby program nepadol po opatovnom stlaceni = 
    //a to sposobilo ze sa divno vypisuju cisla po operacii
    class Calculator
    {
        private enum Operation
        {
            Plus,
            Minus,
            Mulitply,
            Divide
        };

        private enum Status
        {
            FirstNumber,
            SecondNumber,
            Operation,            
            Result
        };
        private Status _status = Status.FirstNumber;
        public String Display { get; set; } // display na cisla
        public String Display2 { get; set; } // memory display
        public String Memory { get; set; }

        private string first = "0";
        private string second = "0";
        private Operation operation;        
        private string result = "";

        public void Button(String button)
        {
            var number = "";

            switch (button)
            {
                case "0":
                    number += "0";
                    break;
                case "1":
                    number += "1";
                    break;
                case "2":
                    number += "2";
                    break;
                case "3":
                    number += "3";
                    break;
                case "4":
                    number += "4";
                    break;
                case "5":
                    number += "5";
                    break;
                case "6":
                    number += "6";
                    break;
                case "7":
                    number += "7";
                    break;
                case "8":
                    number += "8";
                    break;
                case "9":
                    number += "9";
                    break;
                case ",":
                    number += ",";
                    break;
                case "+":
                    _status = Status.Operation;
                    operation = Operation.Plus;
                    break;
                case "-":
                    _status = Status.Operation;
                    operation = Operation.Minus;
                    break;
                case "*":
                    _status = Status.Operation;
                    operation = Operation.Mulitply;
                    break;
                case "/":
                    _status = Status.Operation;
                    operation = Operation.Divide;
                    break;
                case "=":
                    _status = Status.Result;
                    result = DoOperation();
                    Display = result;
                    first = Display;
                    second = "0";
                    result = "";

                    break;
                case "+/-":
                    if (Display != "")
                    {
                        if (_status == Status.FirstNumber)
                        {
                            var input = Convert.ToDouble(first) * -1;
                            first = "0" + input;
                        }
                        if (_status == Status.SecondNumber)
                        {
                            var input = Convert.ToDouble(second) * -1;
                            second = "0" + input;
                        }
                    }
                    break;

                case "CE":
                    if (_status == Status.FirstNumber)
                    {
                        first = "0";
                        Display = first;
                    }
                    if (_status == Status.SecondNumber)
                    {
                        second = "0";
                        Display = second;
                    }

                    break;
                case "C":
                    _status = Status.FirstNumber;
                    Display = result;
                    first = "0";
                    second = "0";
                    result = "";
                    break;
                case "BackSpace":
                    if (_status == Status.FirstNumber)
                    {
                        first = first.Substring(0,first.Length - 1);
                        Display = first;
                    }
                    if (_status == Status.SecondNumber)
                    {
                        second = first.Substring(0,second.Length - 1);
                        Display = second;
                    }

                    break;

                case "MS":
                    Memory = "0" + Display;
                    Display2 = "M";
                    break;

                case "MR":
                    if (_status == Status.FirstNumber)
                    {
                        first = Memory;
                    }
                    if (_status == Status.SecondNumber)
                    {
                        second = Memory;
                    }

                    Display = Memory.Substring(1);
                    break;

                case "MC":
                    Memory = "";
                    Display2 = "";
                    break;
                case "M+":
                    Memory = (double.Parse(Memory) + double.Parse(Display)).ToString();
                    break;
                case "M-":
                    Memory = (double.Parse(Memory) - double.Parse(Display)).ToString();
                    break;

                default:
                    break;

            }

            switch (_status)
            {
                case Status.FirstNumber:
                    first += number;
                    Display = first.Substring(1);
                    break;
                case Status.SecondNumber:
                    second += number;
                    Display = second.Substring(1);
                    break;
                case Status.Operation:
                    _status = Status.SecondNumber;
                    break;
                case Status.Result:
                    _status = Status.FirstNumber;
                    break;
            }
        }     
      private string DoOperation()
        {
            var fNum = Convert.ToDouble(first);
            var sNum = Convert.ToDouble(second);
            double result = 0;
            switch (operation)
            {
                case Operation.Plus:
                    result = fNum + sNum;
                    break;
                case Operation.Minus:
                    result = fNum - sNum;
                    break;
                case Operation.Mulitply:
                    result = fNum * sNum;
                    break;
                case Operation.Divide:
                    result = fNum / sNum;
                    break;
            }
            return "" + result;
        }

    }


}
