using MyProjectPhone.ViewsModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectPhone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorization : ContentPage
    {
        public Authorization()
        {
            InitializeComponent();
            this.BindingContext = new AuthorizationViewModel();
            
            
        }

      

      
    }
}