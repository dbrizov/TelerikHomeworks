using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    public class InvalidRangeException<T> : ApplicationException
    {
        // Fields
        private T min;
        private T max;

        // Constructors
        public InvalidRangeException(T min, T max) : base()
        {
            this.min = min;
            this.max = max;
        }

        public InvalidRangeException(string message, T min, T max)
            : base(message)
        {
            this.min = min;
            this.max = max;
        }

        public InvalidRangeException(string message, Exception innerEx, T min, T max)
            : base(message, innerEx)
        {
            this.min = min;
            this.max = max;
        }

        // Methods
        public override string Message
        {
            get
            {
                return string.Format("The value is out of the range [{0}, {1}]",
                    this.min, this.max);
            }
        }
    }
}
