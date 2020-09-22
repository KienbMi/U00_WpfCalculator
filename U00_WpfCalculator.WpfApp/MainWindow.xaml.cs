using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace U01_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double _result = 0;
        double _number = 0;
        char _lastOperator = '\0';


        public MainWindow()
        {
            InitializeComponent();

            txtOutput.Text = _result.ToString();

            btn0.Click += Button_Click;
            btn1.Click += Button_Click;
            btn2.Click += Button_Click;
            btn3.Click += Button_Click;
            btn4.Click += Button_Click;
            btn5.Click += Button_Click;
            btn6.Click += Button_Click;
            btn7.Click += Button_Click;
            btn8.Click += Button_Click;
            btn9.Click += Button_Click;
            btnPlus.Click += Button_Click;
            btnMinus.Click += Button_Click;
            btnMul.Click += Button_Click;
            btnDiv.Click += Button_Click;
            btnCalc.Click += Button_Click;
            btnClear.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Content.ToString().Length != 1)
                {
                    return;
                }

                char c = button.Content.ToString()[0];

                switch (c)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        {
                            _number = _number * 10 + (c - '0');
                            txtOutput.Text = _number.ToString();
                            break;
                        }
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '=':
                        {
                            switch (_lastOperator)
                            {
                                case '+':
                                    {
                                        _result += _number;
                                        txtOutput.Text = _result.ToString();
                                        break;
                                    }
                                case '-':
                                    {
                                        _result -= _number;
                                        txtOutput.Text = _result.ToString();
                                        break;
                                    }
                                case '*':
                                    {
                                        _result *= _number;
                                        txtOutput.Text = _result.ToString();
                                        break;
                                    }
                                case '/':
                                    {
                                        if (_number == 0)
                                        {
                                            Clear();
                                            return;
                                        }
                                        
                                        _result /= _number;
                                        txtOutput.Text = _result.ToString();
                                        break;
                                    }
                                case '=':
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        _result = _number;
                                        txtOutput.Text = _result.ToString();
                                        break;
                                    }
                            }

                            _number = 0;
                            _lastOperator = c;
                            break;
                        }
                    case 'C':
                        {
                            Clear();
                            break;
                        }
                }
            }
        }

        private void Clear()
        {
            txtOutput.Text = "0";
            _number = 0;
            _result = 0;
            _lastOperator = '\0';
        }
    }
}
