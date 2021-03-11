using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Collections.Generic;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace CalculatorUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        TextBlock textBlockLine1;
        TextBlock textBlockLine2;
        long action = 1;
        int counterdivision = 1;
        string value1division = "";
        string value2division = "";
        int countermultiplication = 1;
        string value1multiplication = "";
        string value2multiplication = "";
        int counterminus = 1;
        string value1minus = "";
        string value2minus = "";
        int counterplus = 1;
        string value1plus = "";
        string value2plus = "";
        string resultplus = "";
        string resultminus = "";
        string resultmultiplication = "";
        string resultdivision = "";
        int counterequl = 1;
        string value1equl = "";
        string value2equl = "";
        string resultequl = "";
        string result = "";
        Stack<string> stacknumber = new Stack<string>();

        public MainPage()
        {
            this.InitializeComponent();
            AppTitle();
            CaluMainPage();
        }

        // Метод для изменения заголовка.
        public void AppTitle()
        {
            // получаем ссылку на внешний вид приложения
            Windows.UI.ViewManagement.ApplicationView applicationView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            applicationView.Title = "Калькулятор";
            // получаем ссылку на TitleBar
            var titleBar = applicationView.TitleBar;
            titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
        }

        // Метод для отображения mainpage.
        public void CaluMainPage()
        {
            stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.WhiteSmoke);
            textBlockLine1 = new TextBlock { TextAlignment = TextAlignment.Center, Foreground = new SolidColorBrush(Windows.UI.Colors.DarkGray) };
            stackPanel.Children.Add(textBlockLine1);
            textBlockLine2 = new TextBlock {  Text = "0", TextAlignment = TextAlignment.Center };
            textBlockLine2.FontWeight = Windows.UI.Text.FontWeights.Normal;
            textBlockLine2.FontSize = 60;
            stackPanel.Children.Add(textBlockLine2);
            Grid grid = new Grid();
            grid.Width = 400;
            grid.Height = 450;
            grid.Margin = new Thickness(50, 50, 50, 50);
            ColumnDefinition[] arrayColumn = new ColumnDefinition[] { null, null, null, null };
            for(int i = 0; i < arrayColumn.Length; i++)
            {
                arrayColumn[i] = new ColumnDefinition();
                arrayColumn[i].Width = new GridLength(i, GridUnitType.Auto);
                grid.ColumnDefinitions.Add(arrayColumn[i]);
            }
            RowDefinition[] arrayRow = new RowDefinition[] { null, null, null, null, null, null };
            for(int i = 0; i < arrayRow.Length; i++)
            {
                arrayRow[i] = new RowDefinition();
                arrayRow[i].Height = new GridLength(i, GridUnitType.Auto);
                grid.RowDefinitions.Add(arrayRow[i]);
            }
            String[] arrayName = new String[] { "%", "CE", "C", "Delete",
                "1/x", "x^2", "sqrt(x)", "/",
                "7", "8", "9", "*",
                "4", "5", "6", "-",
                "1", "2", "3", "+",
                "+/-", "0", ",", "=" };
            Button[] arrayButton = new Button[] { null, null, null, null,
                null, null, null, null,
                null, null, null, null,
                null, null, null, null,
                null, null, null, null,
                null, null, null, null };
            for(int i = 0; i < arrayButton.Length; i++)
            {
                arrayButton[i] = new Button();
                arrayButton[i].Width = 100;
                arrayButton[i].Height = 50;
                arrayButton[i].Content = arrayName[i];
                arrayButton[i].Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
                arrayButton[i].Margin = new Thickness(1, 1, 1, 1);
                arrayButton[i].Click += Button_Click;
                arrayButton[i].Tag = i;
            }
            for(int i = 0; i < arrayButton.Length; i++)
            {
                grid.Children.Add(arrayButton[i]);
            }
            for(int i = 0; i < 4; i++)
            {
                Grid.SetColumn(arrayButton[i], i);
                Grid.SetRow(arrayButton[i], 0);
            }
            for (int i = 4; i < 8; i++)
            {
                Grid.SetColumn(arrayButton[i], (i - 4));
                Grid.SetRow(arrayButton[i], 1);
            }
            for (int i = 8; i < 12; i++)
            {
                Grid.SetColumn(arrayButton[i], (i - 8));
                Grid.SetRow(arrayButton[i], 2);
            }
            for (int i = 12; i < 16; i++)
            {
                Grid.SetColumn(arrayButton[i], (i - 12));
                Grid.SetRow(arrayButton[i], 3);
            }
            for (int i = 16; i < 20; i++)
            {
                Grid.SetColumn(arrayButton[i], (i - 16));
                Grid.SetRow(arrayButton[i], 4);
            }
            for (int i = 20; i < 24; i++)
            {
                Grid.SetColumn(arrayButton[i], (i - 20));
                Grid.SetRow(arrayButton[i], 5);
            }
            stackPanel.Children.Add(grid);
        }

        // Метод для обработки всех нажатий кнопок.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch ((int)button.Tag)
            {
                case 0: PercentButtonClick();
                    break;
                case 1: CEButtonClick();
                    break;
                case 2: CButtonClick();
                    break;
                case 3: DeleteButtonClick();
                    break;
                case 4: OneButtonClick();
                    break;
                case 5: DegreeButtonClick();
                    break;
                case 6: SQRTButtonClick();
                    break;
                case 7: DivisionButtonClick();
                    break;
                case 8: SevenButtonClick();
                    break;
                case 9: EightButtonClick();
                    break;
                case 10: NineButtonClick();
                    break;
                case 11: MultiplicationButtonClick();
                    break;
                case 12: FourButtonClick();
                    break;
                case 13: FiveButtonClick();
                    break;
                case 14: SixButtonClick();
                    break;
                case 15: MinusButtonClick();
                    break;
                case 16: FirstButtonClick();
                    break;
                case 17: TwoButtonClick();
                    break;
                case 18: ThreeButtonClick();
                    break;
                case 19: PlusButtonClick();
                    break;
                case 20: ChangeButtonClick();
                    break;
                case 21: NullButtonClick();
                    break;
                case 22: CommaButtonClick();
                    break;
                case 23: EqulButtonClick();
                    break;
            }
        }

        // Метод для обработки % нажатия кнопки.
        public void PercentButtonClick()
        {
            Filter("%");
        }

        // Метод для обработки CE нажатия кнопки.
        public void CEButtonClick()
        {
            Filter("CE");
        }

        // Метод для обработки C нажатия кнопки.
        public void CButtonClick()
        {
            Filter("C");
        }

        // Метод для обработки Delete нажатия кнопки.
        public void DeleteButtonClick()
        {
            Filter("Delete");
        }

        // Метод для обработки 1/x нажатия кнопки.
        public void OneButtonClick()
        {
            Filter("1/x");
        }

        // Метод для обработки x^2 нажатия кнопки.
        public void DegreeButtonClick()
        {
            Filter("x^2");
        }

        // Метод для обработки sqrt(x) нажатия кнопки.
        public void SQRTButtonClick()
        {
            Filter("sqrt(x)");
        }

        // Метод для обработки / нажатия кнопки.
        public void DivisionButtonClick()
        {
            Filter("/");
        }

        // Метод для обработки 7 нажатия кнопки.
        public void SevenButtonClick()
        {
            Filter("7");
        }

        // Метод для обработки 8 нажатия кнопки.
        public void EightButtonClick()
        {
            Filter("8");
        }

        // Метод для обработки 9 нажатия кнопки.
        public void NineButtonClick()
        {
            Filter("9");
        }

        // Метод для обработки * нажатия кнопки.
        public void MultiplicationButtonClick()
        {
            Filter("*");
        }

        // Метод для обработки 4 нажатия кнопки.
        public void FourButtonClick()
        {
            Filter("4");
        }

        // Метод для обработки 5 нажатия кнопки.
        public void FiveButtonClick()
        {
            Filter("5");
        }

        // Метод для обработки 6 нажатия кнопки.
        public void SixButtonClick()
        {
            Filter("6");
        }

        // Метод для обработки - нажатия кнопки.
        public void MinusButtonClick()
        {
            Filter("-");
        }

        // Метод для обработки 1 нажатия кнопки.
        public void FirstButtonClick()
        {
            Filter("1");
        }

        // Метод для обработки 2 нажатия кнопки.
        public void TwoButtonClick()
        {
            Filter("2");
        }

        // Метод для обработки 3 нажатия кнопки.
        public void ThreeButtonClick()
        {
            Filter("3");
        }

        // Метод для обработки + нажатия кнопки.
        public void PlusButtonClick()
        {
            Filter("+");
        }

        // Метод для обработки +/- нажатия кнопки.
        public void ChangeButtonClick()
        {
            Filter("+/-");
        }

        // Метод для обработ 0 нажатия кнопки.
        public void NullButtonClick()
        {
            Filter("0");
        }

        // Метод для обработки , нажатия кнопки.
        public void CommaButtonClick()
        {
            Filter(",");
        }

        // Метод для обработки = нажатия кнопки.
        public void EqulButtonClick()
        {
            Filter("=");
        }

        // Метод для фильтрации и вывода в TextBlock.
        public void Filter(string text)
        {
            if(text == "%")
            {
                string value = textBlockLine1.Text;
                value = value.Remove((value.Length - 1), 1);
                string percent = textBlockLine2.Text;
                MathUWP mathUWP = new MathUWP();
                string result = mathUWP.Percent(value, percent);
                textBlockLine2.Text = result;
                return;
            }
            if(text == "CE")
            {
                UnificationLine1("CE");
                UnificationLine2("CE");
                return;
            }
            if(text == "C")
            {
                UnificationLine1("C");
                UnificationLine2("C");
                return;
            }
            if(text == "Delete")
            {
                UnificationLine2("Delete");
                return;
            }
            if(text == "1/x")
            {
                string value = textBlockLine2.Text;
                MathUWP mathUWP = new MathUWP();
                string result = mathUWP.One(value);
                textBlockLine1.Text = "1/(" + value + ")";
                textBlockLine2.Text = result;
                return;
            }
            if(text == "x^2")
            {
                string value = textBlockLine2.Text;
                MathUWP mathUWP = new MathUWP();
                string result = mathUWP.Degree(value);
                textBlockLine1.Text = "sqr(" + value + ")";
                textBlockLine2.Text = result;
                return;
            }
            if(text == "sqrt(x)")
            {
                string value = textBlockLine2.Text;
                MathUWP mathUWP = new MathUWP();
                string result = mathUWP.SQRT(value);
                textBlockLine1.Text = "sqrt(" + value + ")";
                textBlockLine2.Text = result;
                return;
            }
            if(text == "/")
            {
                UnificationLine1("/");
                return;
            }
            if(text == "7")
            {
                UnificationLine2("7");
                return;
            }
            if(text == "8")
            {
                UnificationLine2("8");
                return;
            }
            if(text == "9")
            {
                UnificationLine2("9");
                return;
            }
            if(text == "*")
            {
                UnificationLine1("*");
                return;
            }
            if(text == "4")
            {
                UnificationLine2("4");
                return;
            }
            if(text == "5")
            {
                UnificationLine2("5");
                return;
            }
            if(text == "6")
            {
                UnificationLine2("6");
                return;
            }
            if(text == "-")
            {
                UnificationLine1("-");
                return;
            }
            if(text == "1")
            {
                UnificationLine2("1");
                return;
            }
            if(text == "2")
            {
                UnificationLine2("2");
                return;
            }
            if(text == "3")
            {
                UnificationLine2("3");
                return;
            }
            if(text == "+")
            {
                UnificationLine1("+");
                return;
            }
            if(text == "+/-")
            {
                UnificationLine2("+/-");
                return;
            }
            if(text == "0")
            {
                UnificationLine2("0");
                return;
            }
            if(text == ",")
            {
                UnificationLine2(",");
                return;
            }
            if(text == "=")
            {
                UnificationLine1("=");
                return;
            }
        }

        // Метод для объединения цифровых значений в одну строку textBlockLine2.
        public void UnificationLine2(string number)
        {
            string content = textBlockLine2.Text;
            if (number == "Delete" && content.Length != 0)
            {
                string temp = content.Remove(content.Length - 1);
                textBlockLine2.Text = temp;
            }
            if(number == "CE" || number == "C")
            {
                textBlockLine1.Text = "";
                textBlockLine2.Text = "0";
                return;
            }
            if(number == "+/-")
            {
                if(content.IndexOf("-") == 0)
                {
                    string temp = content.Remove(0, 1);
                    textBlockLine2.Text = temp;
                    return;
                }
                if(content.IndexOf("-") == (-1))
                {
                    string temp = content.Insert(0, "-");
                    textBlockLine2.Text = temp;
                    return;
                }
            }
            if (content.Length >= 17) return;
            if (number == "0" && content.Length == 1) return;
            if(content.Length == 3)
            {
                content = content + " ";
            }
            if (content.Length == 7)
            {
                content = content + " ";
            }
            if (content.Length == 11)
            {
                content = content + " ";
            }
            if (content.Length == 15)
            {
                content = content + " ";
            }
            if (number == "," && content.IndexOf(',') == (-1))
            {
                content = content + ",";
                textBlockLine2.Text = content;
            }
            if (content.Length < 17 && number != "," && number != "Delete" && number != "+/-" && number != "CE" && number != "C")
            {
                content = content + number;
                textBlockLine2.Text = content;
                action = 1;
            }
            if (content.Length >= 1 && content.Length <= 8) textBlockLine2.FontSize = 60;
            if (content.Length >= 9 && content.Length <= 17) textBlockLine2.FontSize = 30;
        }

        // Метод для объединения цифровых значений в одну строку textBlockLine1.
        public void UnificationLine1(string number)
        {
            string content1 = textBlockLine1.Text;
            string content2 = textBlockLine2.Text;
            if (number == "/") stacknumber.Push(number);
            if (number == "*") stacknumber.Push(number);
            if (number == "-") stacknumber.Push(number);
            if (number == "+") stacknumber.Push(number);
            if (number == "=") stacknumber.Push(number);
            string[] arraynumber = new string[stacknumber.Count];
            stacknumber.CopyTo(arraynumber, 0);
            if (number == "CE" || number == "C")
            {
                textBlockLine1.Text = "";
                textBlockLine2.Text = "0";
                value1division = "";
                value2division = "0";
                counterdivision = 1;
                value1multiplication = "";
                value2multiplication = "0";
                countermultiplication = 1;
                value1minus = "";
                value2minus = "0";
                counterminus = 1;
                value1plus = "";
                value2plus = "0";
                counterplus = 1;
                value1equl = "";
                value2equl = "0";
                counterequl = 1;
                return;
            }
            if (content1.Length >= 70) return;
            if (number == "/" && value1division != textBlockLine2.Text)
            {
                string temp = content1 + content2 + "/";
                textBlockLine1.Text = temp;
                MathUWP mathUWP = new MathUWP();
                switch (counterdivision)
                {
                    case 1:
                        try
                        {
                            if (arraynumber[1] == "+")
                            {
                                value2plus = textBlockLine2.Text;
                                resultplus = mathUWP.Plus(value1plus, value2plus);
                                textBlockLine2.Text = resultplus;              // Вывод результата.
                                value1plus = resultplus;
                                value1division = value1plus;
                                counterdivision = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "-")
                            {
                                value2minus = textBlockLine2.Text;
                                resultminus = mathUWP.Minus(value1minus, value2minus);
                                textBlockLine2.Text = resultminus;              // Вывод результата.
                                value1minus = resultminus;
                                value1division = value1minus;
                                counterdivision = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "*")
                            {
                                value2multiplication = textBlockLine2.Text;
                                resultmultiplication = mathUWP.Multiplication(value1multiplication, value2multiplication);
                                textBlockLine2.Text = resultmultiplication;              // Вывод результата.
                                value1multiplication = resultmultiplication;
                                value1division = value1multiplication;
                                counterdivision = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        value1division =  textBlockLine2.Text;
                        counterdivision = 2;
                        break;
                    case 2:
                        value2division = textBlockLine2.Text;
                        resultdivision = mathUWP.Division(value1division, value2division);
                        textBlockLine2.Text = resultdivision;              // Вывод результата.
                        value1division = resultdivision;
                        break;
                }
            }
            if (number == "*" && value1multiplication != textBlockLine2.Text)
            {
                string temp = content1 + content2 + "*";
                textBlockLine1.Text = temp;
                MathUWP mathUWP = new MathUWP();
                switch (countermultiplication)
                {
                    case 1:
                        try
                        {
                            if (arraynumber[1] == "+")
                            {
                                value2plus = textBlockLine2.Text;
                                resultplus = mathUWP.Plus(value1plus, value2plus);
                                textBlockLine2.Text = resultplus;              // Вывод результата.
                                value1plus = resultplus;
                                value1multiplication = value1plus;
                                countermultiplication = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "-")
                            {
                                value2minus = textBlockLine2.Text;
                                resultminus = mathUWP.Minus(value1minus, value2minus);
                                textBlockLine2.Text = resultminus;              // Вывод результата.
                                value1minus = resultminus;
                                value1multiplication = value1minus;
                                countermultiplication = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "/")
                            {
                                value2division = textBlockLine2.Text;
                                resultdivision = mathUWP.Division(value1division, value2division);
                                textBlockLine2.Text = resultdivision;              // Вывод результата.
                                value1division = resultdivision;
                                value1multiplication = value1division;
                                countermultiplication = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        value1multiplication = textBlockLine2.Text;
                        countermultiplication = 2;
                        break;
                    case 2:
                        value2multiplication = textBlockLine2.Text;
                        resultmultiplication = mathUWP.Multiplication(value1multiplication, value2multiplication);
                        textBlockLine2.Text = resultmultiplication;              // Вывод результата.
                        value1multiplication = resultmultiplication;
                        break;
                }
            }
            if (number == "-" && value1minus != textBlockLine2.Text)
            {
                string temp = content1 + content2 + "-";
                textBlockLine1.Text = temp;
                MathUWP mathUWP = new MathUWP();
                switch (counterminus)
                {
                    case 1:
                        try
                        {
                            if (arraynumber[1] == "+")
                            {
                                value2plus = textBlockLine2.Text;
                                resultplus = mathUWP.Plus(value1plus, value2plus);
                                textBlockLine2.Text = resultplus;              // Вывод результата.
                                value1plus = resultplus;
                                value1minus = value1plus;
                                counterminus = 2;
                                break;
                            }
                        } catch(Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "*")
                            {
                                value2multiplication = textBlockLine2.Text;
                                resultmultiplication = mathUWP.Multiplication(value1multiplication, value2multiplication);
                                textBlockLine2.Text = resultmultiplication;              // Вывод результата.
                                value1multiplication = resultmultiplication;
                                value1minus = value1multiplication;
                                counterminus = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "/")
                            {
                                value2division = textBlockLine2.Text;
                                resultdivision = mathUWP.Division(value1division, value2division);
                                textBlockLine2.Text = resultdivision;              // Вывод результата.
                                value1division = resultdivision;
                                value1minus = value1division;
                                counterminus = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        value1minus = textBlockLine2.Text;
                        counterminus = 2;
                        break;
                    case 2:
                        value2minus = textBlockLine2.Text;
                        resultminus = mathUWP.Minus(value1minus, value2minus);
                        textBlockLine2.Text = resultminus;              // Вывод результата.
                        value1minus = resultminus;
                        break;
                }
            }
            if (number == "+" && value1plus != textBlockLine2.Text)
            {
                string temp = content1 + content2 + "+";
                textBlockLine1.Text = temp;
                MathUWP mathUWP = new MathUWP();
                switch (counterplus)
                {
                    case 1:
                        try
                        {
                            if (arraynumber[1] == "-")
                            {
                                value2minus = textBlockLine2.Text;
                                resultminus = mathUWP.Minus(value1minus, value2minus);
                                textBlockLine2.Text = resultminus;              // Вывод результата.
                                value1minus = resultminus;
                                value1plus = value1minus;
                                counterplus = 2;
                                break;
                            }
                        } catch(Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "*")
                            {
                                value2multiplication = textBlockLine2.Text;
                                resultmultiplication = mathUWP.Multiplication(value1multiplication, value2multiplication);
                                textBlockLine2.Text = resultmultiplication;              // Вывод результата.
                                value1multiplication = resultmultiplication;
                                value1plus = value1multiplication;
                                counterplus = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "/")
                            {
                                value2division = textBlockLine2.Text;
                                resultdivision = mathUWP.Division(value1division, value2division);
                                textBlockLine2.Text = resultdivision;              // Вывод результата.
                                value1division = resultdivision;
                                value1plus = value1division;
                                counterplus = 2;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        value1plus = textBlockLine2.Text;
                        counterplus = 2;
                        break;
                    case 2:
                        value2plus = textBlockLine2.Text;
                        resultplus = mathUWP.Plus(value1plus, value2plus);
                        textBlockLine2.Text = resultplus;              // Вывод результата.
                        value1plus = resultplus;
                        break;
                }
            }
            if (number == "=" && value1equl.IndexOf("=") == -1)
            {
                string tempequl = content1 + content2 + "=";
                value1equl = tempequl;
                textBlockLine1.Text = tempequl;
                MathUWP mathUWP = new MathUWP();
                switch (counterequl)
                {
                    case 1:
                        try
                        {
                            if (arraynumber[1] == "+")
                            {
                                value2plus = textBlockLine2.Text;
                                resultplus = mathUWP.Plus(value1plus, value2plus);
                                textBlockLine2.Text = resultplus;              // Вывод результата.
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "-")
                            {
                                value2minus = textBlockLine2.Text;
                                resultminus = mathUWP.Minus(value1minus, value2minus);
                                textBlockLine2.Text = resultminus;              // Вывод результата.
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "*")
                            {
                                value2multiplication = textBlockLine2.Text;
                                resultmultiplication = mathUWP.Multiplication(value1multiplication, value2multiplication);
                                textBlockLine2.Text = resultmultiplication;              // Вывод результата.
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        try
                        {
                            if (arraynumber[1] == "/")
                            {
                                value2division = textBlockLine2.Text;
                                resultdivision = mathUWP.Division(value1division, value2division);
                                textBlockLine2.Text = resultdivision;              // Вывод результата.
                            }
                        }
                        catch (Exception ex)
                        {
                            string debug = ex.Message;
                        }
                        break;
                }
            }
        }
    }
}
