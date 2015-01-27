using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

[assembly: ExportRenderer(typeof(PTAndroidApp.MyCheckBox), typeof(PTAndroidApp.CheckBoxRenderer))]

namespace PTAndroidApp
{
	public class CheckBoxRenderer : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged (e);

			var control = new CheckBox(this.Context);
			this.SetNativeControl(control);
		}

	}

	public class MyCheckBox:Xamarin.Forms.Button
	{

	}
}

