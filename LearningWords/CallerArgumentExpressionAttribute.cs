using System;

namespace Электронно_обучающая_программа
{
    internal class CallerArgumentExpressionAttribute : Attribute
    {
        private string v;

        public CallerArgumentExpressionAttribute(string v)
        {
            this.v = v;
        }
    }
}