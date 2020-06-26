using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyProjectPhone.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }


        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string AsccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AsccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AsccessToken", value);
            }
        }

        public static string RefreshToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("RefreshToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("RefreshToken", value);
            }
        }

    }
}
