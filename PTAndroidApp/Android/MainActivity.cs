using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace PTAndroidApp.Android
{
	[Activity (Label = "PTAndroidApp.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@style/HoloTheme")]
	public class MainActivity : FormsApplicationActivity

	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);
			 
			//SetPage (App.GetMasterPage ());
	
			SetPage (MainPage.GetMasterPage());

		}




	}
}

