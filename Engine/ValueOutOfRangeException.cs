using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    // TODO look at this ctors again, do I need to implemnte all?
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string message) : base(message)
        {
        }

        public ValueOutOfRangeException(string message, Exception inner) : base(message, inner)
        {
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string message) : base(message)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
