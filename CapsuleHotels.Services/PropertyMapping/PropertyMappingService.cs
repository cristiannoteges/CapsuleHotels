using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Model.Entities;
using CapsuleHotels.Services.PropertyMapping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.PropertyMapping
{
    public class PropertyMappingService :IPropertyMappingService
    {
        private Dictionary<string, PropertyMappingValue> _usuarioPropertyMapping =
           new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
           {
                { "Id", new PropertyMappingValue(new List<string>() { "Id" }) },
                { "Referencia", new PropertyMappingValue(new List<string>() { "Referencia" }) },
                { "Precio", new PropertyMappingValue(new List<string>() { "Precio" }) }
            };
        //Todo: Esto era para ordenar?

        //TODO: Mapping de otras entidades

        private IList<IPropertyMapping> propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            propertyMappings.Add(new PropertyMapping<UsuarioDto, Usuario>(_usuarioPropertyMapping));
            //TODO :Mapping de otras entidades
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            // Get matching mapping
            var matchingMapping = propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First()._mappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping instance for <{typeof(TSource)}, {typeof(TDestination)}>.");
        }
    }
}
