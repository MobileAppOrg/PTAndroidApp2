using System;
using Xamarin.Forms;

namespace PTAndroidApp
{
	public class App
	{
		public static Page GetMainPage ()
		{
			return new NavigationPage(new MainPage());
		}


		public static Page SearchPatientPage ()
		{
			return new NavigationPage(new SearchPatientPage());

		}

		public static Page SearchSoapPatientPage ()
		{
			return new NavigationPage(new SearchSoapPatientPage());

		}


	}
}

