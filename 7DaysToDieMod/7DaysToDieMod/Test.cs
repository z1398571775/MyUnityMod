using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DaysToDieMod
{
    internal class Test
    {
        protected float m_Value;

        bool wholeNumbers = false;

        public virtual float value
        {
            get
            {
                if (!this.wholeNumbers)
                {
                    return this.m_Value;
                }
                return MathF.Round(this.m_Value);
            }
            set
            {
                
            }
        }
    }
}
