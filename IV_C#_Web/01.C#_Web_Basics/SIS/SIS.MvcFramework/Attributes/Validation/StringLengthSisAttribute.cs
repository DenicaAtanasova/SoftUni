namespace SIS.MvcFramework.Attributes.Validation
{
    using System;

    public class StringLengthSisAttribute : ValidationSisAttribute
    {
        private readonly int minLength;
        private readonly int maxLength;

        public StringLengthSisAttribute(int minLength, int maxLength, string errorMessage)
            : base(errorMessage)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = (string)Convert.ChangeType(value, typeof(string));

            return valueAsString.Length >= this.minLength && valueAsString.Length <= this.maxLength;
        }
    }
}