
using System.ComponentModel;
using Xamarin.Forms;

namespace MyProjectPhone.ViewsModels
{
   public abstract class BaseViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
       

        protected void NotyfyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
