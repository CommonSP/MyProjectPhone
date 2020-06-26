using MyProjectPhone.Helpers;
using MyProjectPhone.Models;
using MyProjectPhone.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyProjectPhone.ViewsModels
{
    class HeaderViewModel : BaseViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public string lastName { get; set; }
        public string firstName { get; set; }
        public ImageSource image { get; set; }

        public HeaderViewModel()
        {
            
        }
        public  ICommand GetUser
        {
            get
            {
                return new Command(async () =>
                {
                    
                    User user = await _apiServices.GetUser();
                    Photo photo = await _apiServices.GetPhoto(Settings.Username);
                    lastName = user.Surname;
                    NotyfyPropertyChanged(nameof(lastName));
                    firstName = user.Name;
                    NotyfyPropertyChanged(nameof(firstName));

                    photo.Data = _apiServices.ResizeImageAndroid(photo.Data, 1000, 1000, 50);
                    image = ImageSource.FromStream(() => new MemoryStream(photo.Data)); 
                    NotyfyPropertyChanged(nameof(image));
                });
            }

        }
    }
}
