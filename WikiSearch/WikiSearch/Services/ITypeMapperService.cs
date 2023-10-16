using System;
namespace WikiSearch.Services
{
    /// <summary>
    /// Type mapper service to map view with viewmodel and vice versa
    /// </summary>
    public interface ITypeMapperService
    {
        Type MapViewModelToView(Type viewModelType);
        Type MapViewToViewModel(Type vType);
    }
}
