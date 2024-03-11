using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace chron_expression_web.Client.ViewModels
{
    public class ViewModel<ModelType> : INotifyPropertyChanged where ModelType : new()
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected ModelType _Model;
        public ModelType Model
        {
            get { return _Model; }
            set
            {
                _Model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModel()
        {
            _Model = new ModelType();
            Model = new ModelType();
        }
    }

}