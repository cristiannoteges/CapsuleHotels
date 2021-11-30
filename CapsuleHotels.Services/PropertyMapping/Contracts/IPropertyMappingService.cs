using System.Collections.Generic;

namespace CapsuleHotels.Services.PropertyMapping.Contracts
{
    interface IPropertyMappingService
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}
