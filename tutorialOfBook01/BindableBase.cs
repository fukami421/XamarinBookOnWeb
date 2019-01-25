using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace tutorialOfBook01
{
    public class BindableBase:INotifyPropertyChanged
    {
        protected BindableBase()
        {
        }

        // INotifyPropertyChangedインターフェイスの実装
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T field,T value,[CallerMemberName]string properName = null)
        {
            if (object.Equals(field, value)) { return false; }
            field = value;
            OnPropertyChanged(properName);
            return true;
        }
    }
}
