using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulucu
{
    internal class bText
    {
        public string Value { get;private set; }
        public int Lenght { get; private set; }

        public bText(string value)
        {
            Value = value;
            Lenght = value.Length;
        }

        public void SetText(string newValue)
        {
            this.Value = newValue;
            this.Lenght = Value.Length;
        }

        public void Reverse()
        {
            char[] charArray = Value.ToCharArray();
            Array.Reverse(charArray);
            SetText(new string(charArray));
        }
    }
}
