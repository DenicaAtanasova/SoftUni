namespace SIS.MvcFramework.Attributes.Validation
{
    using System;

    public class PasswordSisAttribute : ValidationSisAttribute
    {
        public PasswordSisAttribute(string errorMessage)
            : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            string valueAsString = (string)Convert.ChangeType(value, typeof(string));

            return valueAsString.Length >= 3;
        }
    }
}