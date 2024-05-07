namespace PolishNotation;

    public class MathP
    {
        protected List<string> _globalOperators = new List<string>(new string[]
            {
                "(", ")", "+", "-", "*", "/", "^"
            });
        protected List<string> _biOperators = new List<string>(new string[]
            {
                "+", "-", "*", "/", "^"
            });
        protected List<string> _prefixFunction = new List<string>(new string[]
            {
                "sin", "cos", "tg", "ctg",
                "arcsin", "arccos", "arctg", "arcctg",
                "-"
            });
        protected List<Func<double, double, double>> _operationResult = new List<Func<double, double, double>>(new Func<double, double, double>[] {
                null,(x,y)=>x+y,(x,y)=>x-y, (x,y)=>x*y, (x,y)=>x/y, (x,y)=>Math.Pow(x,y)
            });
        protected List<Func<double, double>> _functionResult = new List<Func<double, double>>(new Func<double, double>[]
            {
                null,
                x => Math.Sin(x),
                x => Math.Cos(x),
                x => Math.Tan(x),
                x => Math.Pow(Math.Tan(x), -1) ,
                x => Math.Asin(x),
                x => Math.Acos(x),
                x => Math.Atan(x),
                x => (Math.PI/2) -Math.Atan(x),
                x => Math.Log(x),
                x => -x
            });

        public virtual string[] Polska(string s)
            {
                string[] S = Split(s);
                return Polska(S);
            }

        public virtual string[] Polska(string[] s)
            {
                List<string> vs = new List<string>();
                Stack<string> Operators = new Stack<string>();
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i][0] - 48 >= 0 && s[i][0] - 48 < 10) || s[i] == "x") vs.Add(s[i]);
                    else if (_biOperators.Contains(s[i]))
                    {
                        while (Operators.Count != 0 && (_prefixFunction.Contains("" + Operators.Peek()) == true ||
                         GetPrioritet(Convert.ToChar(Operators.Peek())) >= GetPrioritet(Convert.ToChar(s[i]))) && Operators.Peek() != "(")
                        {
                            vs.Add(Operators.Pop());
                        }
                        Operators.Push(s[i]);
                    }
                    else if (s[i] == "(") Operators.Push(s[i]);
                    else if (s[i] == ")")
                    {
                        while (Operators.Peek() != "(") vs.Add(Operators.Pop());
                        Operators.Pop();
                    }
                    else if (_prefixFunction.Contains(s[i])) Operators.Push(s[i]);
                }
                while (Operators.Count != 0) vs.Add(Operators.Pop());
                string[] vs1 = new string[vs.Count];
                vs.CopyTo(vs1, 0);
                return vs1;
            }

        protected virtual string[] Split(string s)
            {
                List<string> vs = new List<string>();
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] - 48 < 10 && s[i] - 48 >= 0) || s[i] == ',')
                    {
                        vs.Add("");
                        while ((s[i] - 48 < 10 && s[i] - 48 >= 0) || s[i] == ',')
                        {
                            vs[vs.Count - 1] += s[i];
                            i++;
                            if (i == s.Length)
                            {
                                string[] vss = new string[vs.Count];
                                vs.CopyTo(vss, 0);
                                return vss;
                            }
                        }
                    }
                    if (_globalOperators.Contains(Convert.ToString(s[i])) == true)
                    {
                        if ((s[i] == '-' && i == 0) || (s[i] == '-' && (s[i - 1] - 48 >= 10 || s[i - 1] - 48 < 0) && s[i - 1] != 'x'))
                        {
                            vs.Add("-");
                            continue;
                        }
                        vs.Add("" + s[i]);
                    }
                    else if (s[i] == 'c' && s[i + 1] == 'o')
                    {
                        i += 2;
                        vs.Add("cos");
                    }
                    else if (s[i] == 's')
                    {
                        i += 2;
                        vs.Add("sin");
                    }
                    else if (s[i] == 't')
                    {
                        i += 1;
                        vs.Add("tg");
                    }
                    else if (s[i] == 'c' && s[i] == 't')
                    {
                        i += 2;
                        vs.Add("ctg");
                    }
                    else if (s[i] == 'a' && s[i + 3] == 's')
                    {
                        i += 5;
                        vs.Add("arcsin");
                    }
                    else if (s[i] == 'a' && s[i + 4] == 'o')
                    {
                        i += 5;
                        vs.Add("arccos");
                    }
                    else if (s[i] == 'a' && s[i + 3] == 't')
                    {
                        i += 4;
                        vs.Add("arctg");
                    }
                    else if (s[i] == 'a' && s[i + 4] == 't')
                    {
                        i += 5;
                        vs.Add("arcctg");
                    }
                    else if (s[i] == 'l')
                    {
                        i++;
                        vs.Add("ln");
                    }
                    else if (s[i] == 'x') vs.Add("x");
                }
                string[] vs1 = new string[vs.Count];
                vs.CopyTo(vs1, 0);
                return vs1;
            }

        protected virtual int GetPrioritet(char s)
            {
                switch (s)
                {
                    case '(': return 100;
                    case ')': return 100;
                    case '+': return 1;
                    case '-': return 1;
                    case '*': return 2;
                    case '/': return 2;
                    case '^': return 3;
                    default: throw new ArgumentException();
                }
            }
        
        }
