using System;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Xamarin.Forms;
using PTAndroidApp.Android;
using PTAndroidApp;
using Android.Views;

[assembly: ExportRenderer(typeof(MyCheckBox), typeof(CheckBoxRenderer))]

namespace PTAndroidApp.Android
{
	public class CheckBoxRenderer : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged (e);

			var control = new CheckBox (this.Context);
			this.SetNativeControl (control);
		}

		public override bool OnKeyUp (Keycode keyCode, KeyEvent e)
		{
			return base.OnKeyUp (keyCode, e);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == MyCheckBox.IsCheckedProperty.PropertyName) {
				var _sender = (MyCheckBox)sender;
				var control = new CheckBox (this.Context);
				control.Checked = !_sender.IsChecked;
				this.SetNativeControl (control);
			}
		}
	}
}

