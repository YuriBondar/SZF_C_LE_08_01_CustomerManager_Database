using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SZF_C_LE_08_01_CustomerManager_Database.ViewModel.ViewModelBaseNamespace
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
