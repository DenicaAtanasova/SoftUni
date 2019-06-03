namespace SIS.MvcFramework.Mapping
{
    using System;
    using System.Collections;
    using System.Reflection;

    public static class ModelMapper
    {
        private static void MapProperty(object originInstance, object destinationInstance, PropertyInfo originProperty, PropertyInfo destinationProperty)
        {
            if (destinationProperty == null)
                return;

            if (destinationProperty.PropertyType == typeof(string))
            {
                destinationProperty.SetValue(destinationInstance, originProperty.GetValue(originInstance).ToString());
            }
            else if (typeof(IEnumerable).IsAssignableFrom(destinationProperty.PropertyType))
            {
                var originCollection = originProperty.GetValue(originInstance) as IEnumerable;
                var destinationElementType = destinationProperty
                    .GetValue(destinationInstance)
                    .GetType()
                    .GetGenericArguments()[0];

                var destinationCollection = Activator.CreateInstance(destinationProperty.PropertyType) as IList;

                foreach (var originElement in originCollection)
                {
                    destinationCollection.Add(MapObject(originElement, destinationElementType));
                }
            }
            else
            {
                destinationProperty.SetValue(destinationInstance,
                        originProperty.GetValue(originInstance));
            }
        }

        private static object MapObject(object origin, Type destinationType)
        {
            var destinationInstance = Activator.CreateInstance(destinationType);

            foreach (var originProperty in origin.GetType().GetProperties())
            {
                var propertyName = originProperty.Name;
                PropertyInfo destinationProperty = destinationInstance.GetType().GetProperty(propertyName);

                MapProperty(origin, destinationInstance, originProperty, destinationProperty);
            }

            return destinationInstance;
        }

        public static TDestination ProjectTo<TDestination>(object origin)
        {
            return (TDestination)MapObject(origin, typeof(TDestination));
        }
    }
}