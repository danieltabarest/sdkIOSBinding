using Android.App;
using Android.Content.PM;
using Android.OS;
using System;


namespace App8.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
   
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            LoadApplication(new App());
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }
    }
}