using System;
using System.Collections;

namespace CalculatorUWP
{
    class MathUWP
    {

        // Метод для расчётов процентов.
        public string Percent(string value, string percent)
        {
            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value.IndexOf(" ") != -1)
                {
                    value = value.Remove(value.IndexOf(" "), 1);
                }
            }
            for (int i = 0; i < percent.Length - 1; i++)
            {
                if (percent.IndexOf(" ") != -1)
                {
                    percent = percent.Remove(percent.IndexOf(" "), 1);
                }
            }
            double dbvalue = Convert.ToDouble(value);
            double dbpercent = Convert.ToDouble(percent);
            double dbresult = (dbvalue / 100) * dbpercent;
            return dbresult.ToString();
        }

        // Метод для вычисления 1/(x).
        public string One(string value)
        {
            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value.IndexOf(" ") != -1)
                {
                    value = value.Remove(value.IndexOf(" "), 1);
                }
            }
            double dbvalue = Convert.ToDouble(value);
            double dbresult = 1 / dbvalue;
            return dbresult.ToString();
        }

        // Метод для вычисления x^2.
        public string Degree(string value)
        {
            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value.IndexOf(" ") != -1)
                {
                    value = value.Remove(value.IndexOf(" "), 1);
                }
            }
            double dbvalue = Convert.ToDouble(value);
            double dbresult = dbvalue * dbvalue;
            return dbresult.ToString();
        }

        // Метод для вычисления Sqrt(x).
        public string SQRT(string value)
        {
            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value.IndexOf(" ") != -1)
                {
                    value = value.Remove(value.IndexOf(" "), 1);
                }
            }
            double dbvalue = Convert.ToDouble(value);
            double dbresult = Math.Sqrt(dbvalue);
            return dbresult.ToString();
        }

        // Метод для вычисления /.
        public string Division(string value1, string value2)
        {
            for (int i = 0; i < value1.Length; i++)
            {
                if (value1.IndexOf(" ") != -1)
                {
                    value1 = value1.Remove(value1.IndexOf(" "), 1);
                }
            }
            for (int i = 0; i < value2.Length; i++)
            {
                if (value2.IndexOf(" ") != -1)
                {
                    value2 = value2.Remove(value2.IndexOf(" "), 1);
                }
            }
            double dbvalue1 = Convert.ToDouble(value1);
            double dbvalue2 = Convert.ToDouble(value2);
            double dbresult = dbvalue1 / dbvalue2;
            return dbresult.ToString();
        }

        // Метод для вычисления *.
        public string Multiplication(string value1, string value2)
        {
            for (int i = 0; i < value1.Length; i++)
            {
                if (value1.IndexOf(" ") != -1)
                {
                    value1 = value1.Remove(value1.IndexOf(" "), 1);
                }
            }
            for (int i = 0; i < value2.Length; i++)
            {
                if (value2.IndexOf(" ") != -1)
                {
                    value2 = value2.Remove(value2.IndexOf(" "), 1);
                }
            }
            double dbvalue1 = Convert.ToDouble(value1);
            double dbvalue2 = Convert.ToDouble(value2);
            double dbresult = dbvalue1 * dbvalue2;
            return dbresult.ToString();
        }

        // Метод для вычисления -.
        public string Minus(string value1, string value2)
        {
            for (int i = 0; i < value1.Length; i++)
            {
                if (value1.IndexOf(" ") != -1)
                {
                    value1 = value1.Remove(value1.IndexOf(" "), 1);
                }
            }
            for (int i = 0; i < value2.Length; i++)
            {
                if (value2.IndexOf(" ") != -1)
                {
                    value2 = value2.Remove(value2.IndexOf(" "), 1);
                }
            }
            double dbvalue1 = Convert.ToDouble(value1);
            double dbvalue2 = Convert.ToDouble(value2);
            double dbresult = dbvalue1 - dbvalue2;
            return dbresult.ToString();
        }

        // Метод для вычисления +.
        public string Plus(string value1, string value2)
        {
            for (int i = 0; i < value1.Length; i++)
            {
                if (value1.IndexOf(" ") != -1)
                {
                    value1 = value1.Remove(value1.IndexOf(" "), 1);
                }
            }
            for (int i = 0; i < value2.Length; i++)
            {
                if (value2.IndexOf(" ") != -1)
                {
                    value2 = value2.Remove(value2.IndexOf(" "), 1);
                }
            }
            double dbvalue1 = Convert.ToDouble(value1);
            double dbvalue2 = Convert.ToDouble(value2);
            double dbresult = dbvalue1 + dbvalue2;
            return dbresult.ToString();
        }
    }
}
