using Android.App;
using Android.OS;
using App.ViewModels;
using MvvmCross.Droid.Views;

namespace App
{
    [Activity(Label = "App", MainLauncher = true)]
    public class MainView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

