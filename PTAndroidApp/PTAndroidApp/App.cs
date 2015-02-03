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


		public static Page PMHxPage ()
		{
			return new NavigationPage(new BalanceAndTolerancePage   ());

		}

//		public static Page SearchSoapPatientPage ()
//		{
//			return new NavigationPage(new SearchSoapPatientPage());
//
//		}


	}
}

