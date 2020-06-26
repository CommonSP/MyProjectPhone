using MyProjectPhone.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectPhone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Header : ContentView
    {
        
        public Header()
        {
            InitializeComponent();

            HeaderViewModel headerViewModel = new HeaderViewModel();
            this.BindingContext = headerViewModel;
           
            var comand = headerViewModel.GetUser;
            comand.Execute(BindingContext);
            
        }

       


    }
}