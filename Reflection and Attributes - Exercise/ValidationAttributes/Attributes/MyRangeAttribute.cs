using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool isValid(object objProperty)
        {
            int intObj = Convert.ToInt32(objProperty);
            return intObj >= this.minValue && intObj <= this.maxValue;
        }
    }
}
