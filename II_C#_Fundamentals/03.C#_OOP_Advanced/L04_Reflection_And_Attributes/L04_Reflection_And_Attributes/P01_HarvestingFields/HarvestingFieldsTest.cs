 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var filterParameter = string.Empty;
            while ((filterParameter = Console.ReadLine()) != "HARVEST")
            {
                var harvestingFieldsType = typeof(HarvestingFields);
                var fieldsInfo = harvestingFieldsType
                    .GetFields(BindingFlags.Instance |
                               BindingFlags.NonPublic |
                               BindingFlags.Public |
                               BindingFlags.Static);

                var filteredFileds = FilterFieldsByType(fieldsInfo, filterParameter);
                foreach (var field in filteredFileds)
                {
                    var fieldAttribute = field.Attributes.ToString().ToLower();
                    var accessModifier = fieldAttribute == "family" ? "protected" : fieldAttribute;

                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }
            }
                     
        }
        private static FieldInfo[] FilterFieldsByType(FieldInfo[] fieldsInfo, string filterParameter)
        {
            switch (filterParameter)
            {
                case "private":
                    return fieldsInfo.Where(fi => fi.IsPrivate).ToArray();
                case "protected":
                    return fieldsInfo.Where(fi => fi.IsFamily).ToArray();
                case "public":
                    return fieldsInfo.Where(fi => fi.IsPublic).ToArray();
                default:
                    return fieldsInfo;
            }
        }
    }
}
