using System;

namespace Engine
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException()
        {
        }

        public ValueOutOfRangeException(string i_Message) : base(i_Message)
        {
        }

        public ValueOutOfRangeException(string i_Message, Exception i_Inner) : base(i_Message, i_Inner)
        {
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_Message) : base(i_Message)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }
    }
}