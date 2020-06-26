using MyProjectPhone.Services;
using MyProjectPhone.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyProjectPhone.ViewsModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public string login { get; set; }
        public string password { get; set; }

        public ICommand command 
        {
            get
            {
                return new Command(async () =>
                {

                    var isSuccseful = await _apiServices.Authorization("CommonSP@yandex.ru", "mn124560MN");
                    if (isSuccseful)
                    {
                         Application.Current.MainPage =new MainMenu();
                        
                    }
                    else
                    {
                         await Application.Current.MainPage.DisplayAlert("Ошибка", "Неверно введен Логин или Пароль", "Ок");
                    }

                });
            }
           
        }
    }
}
