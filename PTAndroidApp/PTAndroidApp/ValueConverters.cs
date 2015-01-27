using System;
using Xamarin.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace PTAndroidApp.ValueConverters
{
	public class ValueConverters
	{
		public ValueConverters ()
		{
		}
	}
	public class IntConverter : IValueConverter
	{
		public object Convert (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			int theInt = (int)value;
			return theInt.ToString ();
		}

		public object ConvertBack (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			string strValue = value as string;
			if (string.IsNullOrEmpty (strValue))
				return 0;
			int resultInt;
			if (int.TryParse (strValue, out resultInt)) {
				return resultInt;
			}
			return 0;
		}
	}
	//Items = { "Single", "Married", "Divorced", "Widowed" }
	public class IndexToGenericListConverter:IValueConverter
	{
		public List<string> ItemList { get; set; }

//		public IndexToCivilStatusConverter(){
//			CivilStatusList = new string[]{ "Single", "Married", "Divorced", "Widowed" };
//		}

		public object Convert (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			string strVal = value as string;
			return ItemList.IndexOf (strVal);
		}

		public object ConvertBack (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			int intIndex = (int)value;
			string retVal = null;

			if (intIndex==-1 || intIndex > ItemList.Count-1)
				return retVal;

			return ItemList.ToArray()[intIndex];
		}
	}

	public class IndexToGenderConverter:IValueConverter
	{
		public object Convert (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			string stringGender = value as string;
			int retVal = -1;
			switch(stringGender){
			case "M":
			case "Male":
				retVal = 0;
				break;
			case "F":
			case "Female":
				retVal = 1;
				break;
			};
			return retVal;
		}

		public object ConvertBack (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			int intGender = (int)value;
			string retVal = null;
			switch(intGender){
			case 0:
				retVal = "M";
				break;
			case 1:
				retVal = "F";
				break;
			};
			return retVal;
		}
	}

	public class StringToNullDateTimeConverter:IValueConverter
	{
		public object Convert (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			DateTime? dateVal = (DateTime?)value;
			return dateVal.ToString ();
		}

		public object ConvertBack (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			string strValue = value as string;
			if (string.IsNullOrEmpty (strValue))
				return (DateTime?)null;

			DateTime resultDate;

			if (DateTime.TryParse (strValue, out resultDate))
				return (DateTime?)resultDate;

			return (DateTime?)null;
		}
	}
		

	public class IndexToBoolConverter:IValueConverter
	{
		public object Convert (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			bool boolVal = (bool)value;
			if (boolVal)
				return 1;

			return 0;
		}

		public object ConvertBack (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			int intVal = (int)value;

			if (intVal == 1)
				return true;

			return false;
		}
	}
}

