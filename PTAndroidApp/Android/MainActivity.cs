using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
//using Xamarin.Forms.Labs.Droid;


namespace PTAndroidApp.Android
{
	[Activity (Label = "PTAndroidApp.Android.Android", MainLauncher = true,ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@android:style/Theme.Holo.Light")]

	public class MainActivity : AndroidActivity  

	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//ActionBar.NavigationMode = ActionBarNavigationMode.Standard ;
		

			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage (App.GetMainPage ());

		}




	}
}

