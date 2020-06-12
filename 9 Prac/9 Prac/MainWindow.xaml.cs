using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator1;
namespace WPF_Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calc;
        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.DidUpdateValue += Calc_DidUpdateValue;
            calc.InputError += calc_Error;
            calc.CalculationError += calc_Error;
        }
        private void calc_Error(object sender, string e)
        {
            MessageBox.Show(e, "Calculator Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void Calc_DidUpdateValue(Calculator sender, double value, int precision)
        {
            if (precision > 0)
                output.Text = String.Format("{0:F" + precision + "}", value);
            else output.Text = $"{value}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int digit = -1;
            if (int.TryParse(button.Content.ToString(), out digit))
            {
                calc.AddDigit(digit);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calc.AddDecimalPoint();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;


            object tag = button.Tag;
            switch (tag)
            {
                case "decimal":
                    calc.AddDecimalPoint();
                    break;
                case "evaluate":
                    calc.Compute();
                    break;
                case "addition":
                    calc.AddOperation(Operation.Add);
                    break;
                case "subtraction":
                    calc.AddOperation(Operation.Sub);
                    break;
                case "multiplication":
                    calc.AddOperation(Operation.Mul);
                    break;
                case "division":
                    calc.AddOperation(Operation.Div);
                    break;
                case "tan":
                    calc.AddOperation(Operation.Tan);
                    break;
                case "sqrt":
                    calc.AddOperation(Operation.Sqrt);
                    
                    break;
                case "pow":
                    calc.AddOperation(Operation.Pow);
                    break;
                case "log":
                    calc.AddOperation(Operation.Log);
                    
                    break;
                case "clear":
                    calc.Clear();
                    break;
                case "reset":
                    calc.Reset();
                    break;
                /*  case "clearsimbol":
                      calc.ClearSimbol();
                      break;*/
                case "sin":
                    calc.AddOperation(Operation.Sin);
                    break;
                case "cos":
                    calc.AddOperation(Operation.Cos);
                    break;
            }
        }
    }
}

