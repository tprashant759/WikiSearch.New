using System;
using System.Globalization;
using System.Reflection;

namespace WikiSearch.Services
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class TypeMapperService : ITypeMapperService
    {
        public Type MapViewModelToView(Type viewModelType)
        {
            var viewName = viewModelType.Name.Replace("ViewModel", string.Empty);
            viewName = string.Concat(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,".Views.",viewName);
            var viewAssemblyName = GetTypeAssemblyName(viewModelType);
            var viewTypeName = GenerateTypeName("{0}, {1}", viewName, viewAssemblyName);
            return Type.GetType(viewTypeName);
        }

        public Type MapViewToViewModel(Type viewType)
        {
            var viewModelName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewModelAssemblyName = GetTypeAssemblyName(viewType);
            var viewTypeModelName = GenerateTypeName("{0}ViewModel, {1}", viewModelName, viewModelAssemblyName);
            return Type.GetType(viewTypeModelName);
        }

        string GetTypeAssemblyName(Type type) => type.GetTypeInfo().Assembly.FullName;
        string GenerateTypeName(string format, string typeName, string assemblyName) =>
            string.Format(CultureInfo.InvariantCulture, format, typeName, assemblyName);
    }
}
