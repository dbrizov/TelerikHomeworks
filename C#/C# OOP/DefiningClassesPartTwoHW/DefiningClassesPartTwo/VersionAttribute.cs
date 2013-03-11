using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum |
        AttributeTargets.Method | AttributeTargets.Interface)]

    public class VersionAttribute : System.Attribute
    {
        // Fields
        private int major;
        private int minor;

        // Constructor
        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        // Properties
        public int Major
        {
            get
            {
                return this.major;
            }
        }

        public int Minor
        {
            get
            {
                return this.minor;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Version: {0}.{1}", this.major, this.minor);
        }
    }
}
