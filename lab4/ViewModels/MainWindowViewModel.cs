using System.Reactive;
using ReactiveUI;

namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            OnClickValue = ReactiveCommand.Create<string, string>((str) => Output += str);
            OnClickOper = ReactiveCommand.Create<string, string>((str) => Output = str);
        }
        private string output = "", first, second, oper = "";
        public string Output
        {
            set
            {

                if ((value == "+" || value == "-" || value == "*" || value == "/") && oper == "")
                {
                    first = output;
                    oper = value;
                    this.RaiseAndSetIfChanged(ref output, "");
                }
                else if (value == "=" && oper != "")
                {
                    second = output;
                    var a = new RomanNumberExtend(first);
                    var b = new RomanNumberExtend(second);

                    switch (oper)
                    {
                        case ("+"):
                            value = (a + b).ToString();
                            break;
                        case ("-"):
                            value = (a - b).ToString();
                            break;
                        case ("*"):
                            value = (a * b).ToString();
                            break;
                        case ("/"):
                            value = (a / b).ToString();
                            break;
                    }
                    oper = "";
                    this.RaiseAndSetIfChanged(ref output, value);
                }
                else if ((value == "+" || value == "-" || value == "*" || value == "/") && oper != "")
                {
                    second = output;
                    var a = new RomanNumberExtend(first);
                    var b = new RomanNumberExtend(second);
                    var c = value;

                    switch (oper)
                    {
                        case ("+"):
                            first = (a + b).ToString();
                            break;
                        case ("-"):
                            first = (a - b).ToString();
                            break;
                        case ("*"):
                            first = (a * b).ToString();
                            break;
                        case ("/"):
                            first = (a / b).ToString();
                            break;
                    }
                    oper = c;
                    this.RaiseAndSetIfChanged(ref output, "");
                }
                else
                    this.RaiseAndSetIfChanged(ref output, value);
            }
            get
            {
                return output;
            }
        }
        public ReactiveCommand<string, string> OnClickValue { get; }
        public ReactiveCommand<string, string> OnClickOper { get; }
    }
}
