using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlocNotasCurso.ViewModel.Base
{
    public class ViewModelBase : IViewModel
    {
        // 
        private bool _isBusy;
        private double _opacity;
        private bool _enabled;

        // cada vez que una propiedad se lanza el evento
        public event PropertyChangedEventHandler PropertyChanged;

        public string Titulo { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }

        public double Opacity
        {
            get { return _opacity; }
            set { _opacity = value; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        // CallerMemberName es el nombre del origen de la llamada
        protected virtual bool SetProperty<T>(ref T variable, T valor, [CallerMemberName] string nombre = null)
        {
            // si tienen el mismo valor return false
            if (object.Equals(variable, valor))
                return false;
            variable = valor;
            OnPropertyChanged(nombre);
            return true;

        }

        protected void OnPropertyChanged([CallerMemberName]string nombre = null)
        {
            throw new NotImplementedException();
        }

        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            throw new NotImplementedException();
        }
    }
}