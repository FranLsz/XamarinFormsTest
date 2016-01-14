using System;
using System.ComponentModel;

namespace BlocNotasCurso.ViewModel.Base
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Titulo { get; set; }

        // se utiliza para cambiar el estado del ViewModel
        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}