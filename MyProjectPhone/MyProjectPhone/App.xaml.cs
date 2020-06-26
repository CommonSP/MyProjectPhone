using Autofac;
using Autofac.Core;
using MyProjectPhone.Views;
using MyProjectPhone.ViewsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MyProjectPhone
{
    public partial class App : Application
    {
        
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Authorization());
           
            
        }

       

       
      

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
