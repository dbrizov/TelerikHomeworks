using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebAndHtmlControls
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBtnInput_Click(object sender, EventArgs e)
        {
            var button = (Button)(sender);
            this.TextBoxCalcDisplay.Text += button.Text;
        }

        protected void OnBtnClear_Click(object sender, EventArgs e)
        {
            this.TextBoxCalcDisplay.Text = "";
        }

        protected void OnBtnCalculate_Click(object sender, EventArgs e)
        {
            string infixNotation = this.TextBoxCalcDisplay.Text;
            string postfixNotation = ConvertInfixToPostfix(infixNotation);

            int result = EvaluatePostFix(postfixNotation);
            this.TextBoxCalcDisplay.Text = result.ToString();
        }

        protected void OnBtnCalculateSqrt_Click(object sender, EventArgs e)
        {
            string infixNotation = this.TextBoxCalcDisplay.Text;
            string postfixNotation = ConvertInfixToPostfix(infixNotation);

            int result = (int)Math.Sqrt(EvaluatePostFix(postfixNotation));
            this.TextBoxCalcDisplay.Text = result.ToString();
        }

        private static string ConvertInfixToPostfix(string infix)
        {
            int length = infix.Length;
            Stack<char> stack = new Stack<char>();
            StringBuilder postfix = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if ((infix[i] >= '0') && (infix[i] <= '9'))
                {
                    postfix.Append(infix[i]);
                }
                else if (infix[i] == '(')
                {
                    stack.Push(infix[i]);
                }
                else if ((infix[i] == '*') || (infix[i] == '+') || (infix[i] == '-') || (infix[i] == '/'))
                {
                    while ((stack.Count > 0) && (stack.Peek() != '('))
                    {
                        if (ComparePrecedence(stack.Peek(), infix[i]))
                        {
                            postfix.Append(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    stack.Push(infix[i]);
                }
                else if (infix[i] == ')')
                {
                    while ((stack.Count > 0) && (stack.Peek() != '('))
                    {
                        postfix.Append(stack.Pop());
                    }
                    if (stack.Count > 0)
                    {
                        stack.Pop(); // popping out the left brace '('
                    }
                }
            }

            while (stack.Count > 0)
            {
                postfix.Append(stack.Pop());
            }

            return postfix.ToString();
        }

        private static bool ComparePrecedence(char top, char p_2)
        {
            if (top == '+' && p_2 == '*') // + has lower precedence than *
            {
                return false;
            }

            if (top == '-' && p_2 == '*')
            {
                return false;
            }

            if (top == '*' && p_2 == '-') // * has higher precedence over -
            {
                return true;
            }

            if (top == '*' && p_2 == '+')
            {
                return true;
            }

            if (top == '+' && p_2 == '/') // + has lower precedence than *
            {
                return false;
            }

            if (top == '-' && p_2 == '/')
            {
                return false;
            }

            if (top == '/' && p_2 == '-') // * has higher precedence over -
            {
                return true;
            }

            if (top == '/' && p_2 == '+')
            {
                return true;
            }

            if (top == '*' && p_2 == '/' ||
                top == '/' && p_2 == '*')
            {
                return true;
            }

            if (top == '+' && p_2 == '-') // + has same precedence over +
            {
                return true;
            }

            return true;
        }

        private static int EvaluatePostFix(string postfix)
        {
            Stack<int> resultStack = new Stack<int>();
            int length = postfix.Length;
            for (int i = 0; i < length; i++)
            {
                if (postfix[i] == '*' || postfix[i] == '+' || postfix[i] == '-' || postfix[i] == '/')
                {
                    int result = ApplyOperator(resultStack.Pop(), resultStack.Pop(), postfix[i]);
                    resultStack.Push(result);
                }
                else if ((postfix[i] >= '0') || (postfix[i] <= '9'))
                {
                    resultStack.Push((int)(postfix[i] - '0'));
                }
            }

            return resultStack.Pop();
        }

        private static int ApplyOperator(int p, int p_2, char p_3)
        {
            switch (p_3)
            {
                case '+':
                    return p_2 + p;
                case '-':
                    return p_2 - p;
                case '*':
                    return p_2 * p;
                case '/':
                    return p_2 / p;
                default:
                    return -1;
            }
        }
    }
}