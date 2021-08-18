using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Property
    {
        private readonly string r_MemberName;
        private readonly string r_DisplayName;
        private readonly Type r_MemberType;
        private string m_MemberInfo;
        private string m_FormQuestion;
        private object m_MemberValue;

        public object MemberValue
        {
            get
            {
                return m_MemberValue;
            }

            set
            {
                m_MemberValue = value;
            }
        }

        public string FormQuestion
        {
            get
            {
                return m_FormQuestion;
            }

            set
            {
                m_FormQuestion = value;
            }
        }

        public string MemberInfo
        {
            get
            {
                return m_MemberInfo;
            }

            set
            {
                m_MemberInfo = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return r_DisplayName;
            }
        }

        public string MemberName
        {
            get
            {
                return r_MemberName;
            }
        }

        public Type MemberType
        {
            get
            {
                return r_MemberType;
            }
        }

        public Property(string i_DisplayName, string i_MemberName, Type i_MemberType)
        {
            r_DisplayName = i_DisplayName;
            r_MemberName = i_MemberName;
            r_MemberType = i_MemberType;
        }
    }
}
