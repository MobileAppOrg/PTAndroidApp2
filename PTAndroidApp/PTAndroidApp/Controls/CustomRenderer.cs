using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace PTAndroidApp
{
	public class MyCheckBox:Button
	{
		public static readonly BindableProperty IsCheckedProperty = 
			BindableProperty.Create<MyCheckBox,bool> (x => x.IsChecked, false);

		public bool IsChecked
		{
			get { return (bool)GetValue (IsCheckedProperty); }
			set { SetValue (IsCheckedProperty, value); }
		}
	}
}

