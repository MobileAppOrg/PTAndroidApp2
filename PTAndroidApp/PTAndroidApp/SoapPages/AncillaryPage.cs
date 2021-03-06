﻿using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PTAndroidApp
{
	public class AncillaryPage  : ContentPage
	{
		private static Entry txtPatientVisitId = new Entry (){ IsVisible = false };
		//private static SoapManager soapMgr = new SoapManager();
		private static ListView ls = new ListView (){RowHeight=60};

		static ContentView CreateFooter(){
			//var btnEdit = new Button{ };
			var btnDelete = new Button{ 
				Text = "Delete",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.FillAndExpand 
			};

		
				btnDelete.Clicked += delegate {
				AncillaryProcedure item;
					if(ls.SelectedItem==null)
						return;

				item = (AncillaryProcedure)ls.SelectedItem;

				if(txtPatientVisitId.Text != "0") // delete in database if edit mode
					SoapManager.DeleteEntity<AncillaryProcedure>(item.RowId,"api/AncillaryProcedures/{id}");

				ls.SelectedItem = null;

				List<AncillaryProcedure> source;
				source = ((List<AncillaryProcedure>)ls.ItemsSource==null?new List<AncillaryProcedure>():(List<AncillaryProcedure>)ls.ItemsSource);
				source.Remove(item);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(AncillaryCell));
			};

			return new ContentView {

				VerticalOptions = LayoutOptions.End,
				Content = btnDelete

			};
		}

		static TableView CreateTable(){

			Entry txtPatientVisitId = new Entry (){ IsVisible = false };
			txtPatientVisitId.SetBinding (Entry.TextProperty,"PatientVisitId", BindingMode.TwoWay);
			//EntryCell txtAncillaryProcOther = new EntryCell { Label="" };
			//EntryCell txtDate = new EntryCell { Label="Date: " };

			var lblAncillary = new Label { Text="Procedure: "};
			var pckAncillary = new Picker () { Items = { "XRAY", "MRI", "Blood Test","NCV","EMG","CT SCAN", "Others"}, 
				Title = "Procedures", HorizontalOptions = LayoutOptions.FillAndExpand};

			EntryCell txtResult = new EntryCell {
				Label = "Result"};

			var datePicker = new DatePicker {
				Format = "MM/dd/yyyy", HorizontalOptions = LayoutOptions.FillAndExpand};

			var btnAdd = new Button {
				Text = "Add Ancillary",
				HorizontalOptions = LayoutOptions.FillAndExpand};

			var AncillaryNameCell = new StackLayout {
				Children = { lblAncillary, pckAncillary },
				Orientation = StackOrientation.Horizontal  
			};

			ViewCell AncillaryCell = new ViewCell {
				View = new StackLayout () {
					Children = { AncillaryNameCell},
					VerticalOptions = LayoutOptions .FillAndExpand 
				}
			};
				ViewCell btnCell = new ViewCell {
				View = new StackLayout () {
					Children = { btnAdd, txtPatientVisitId }
				}

			};
					
			ViewCell dateCell = new ViewCell{
				Height = 100,
				View = new StackLayout(){
					Children = {
						new Label (){ FontSize = 20, Text = "Date: ", HorizontalOptions = LayoutOptions.Fill, YAlign = TextAlignment.Center },
						datePicker
					},
					Padding = new Thickness(5,1,1,1),
					HorizontalOptions = LayoutOptions.Fill,
					Orientation = StackOrientation.Horizontal
				}
			};

			btnAdd.Clicked += delegate {
				if (pckAncillary.SelectedIndex < 0) // no item selected in picker; exit event pre-maturely
					return;

				AncillaryProcedure Ap = new AncillaryProcedure();

				Ap.RowId = 0;
				Ap.ProcedureName = pckAncillary.Items[pckAncillary.SelectedIndex];
				Ap.ProcedureDate = datePicker.Date;
				Ap.Result = txtResult.Text;

				if(txtPatientVisitId.Text != "0") // add to db if edit mode
				{
					Ap.PatientVisitId = Convert.ToInt32(txtPatientVisitId.Text);
					Ap = SoapManager.AddEntity<AncillaryProcedure>(Ap,"api/AncillaryProcedures");
				}
					

				List<AncillaryProcedure> source;
				source = ((List<AncillaryProcedure>)ls.ItemsSource==null?new List<AncillaryProcedure>():(List<AncillaryProcedure>)ls.ItemsSource);
				source.Add(Ap);
				ls.ItemsSource = source;
				ls.ItemTemplate = new DataTemplate(typeof(AncillaryCell));
			};

			TableSection ts = new TableSection ();
			return new TableView () {
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 260,
				Intent = TableIntent.Form,
				Root = new TableRoot () {
					new TableSection ("Ancillary Procedures") {
						AncillaryCell,
						dateCell,
						txtResult,
						btnCell,	
					}
				}
			};

		}
		public AncillaryPage ()
		{
			var form = CreateTable ();
			//ls.ItemsSource = source;
			ls.ItemTemplate = new DataTemplate(typeof(AncillaryCell));
			ls.SetBinding (ListView.ItemsSourceProperty,"AncillaryProcedures",BindingMode.TwoWay);
			ContentView footerButtons = CreateFooter ();

			Content = new StackLayout {
				Spacing = 0,
				Padding = 0,
				Children = {
					form,
					ls,
					footerButtons
				}
			};
		}
	}



	public class AncillaryCell : ViewCell
	{
		public AncillaryCell()
		{
			var idLabel = new Label {
				IsVisible = false //false
			};
			idLabel.SetBinding (Label.TextProperty, "RowId");

			var patientVisitIdLabel = new Label {
				IsVisible = false //false
			};
			patientVisitIdLabel.SetBinding (Label.TextProperty, "PatientVisitId");

			var nameLabel = new Label
			{
				FontSize = 20,
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, new Binding(path: "ProcedureName", stringFormat: "Procedure: {0}"));

			var nameLayout = CreateNameLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = { idLabel,patientVisitIdLabel,nameLabel, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{

			var dateLabel = new Label
			{
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			dateLabel.SetBinding(Label.TextProperty, new Binding(path: "ProcedureDate", stringFormat: "Date: {0:D}"));

			var resultLabel = new Label {
				FontSize = 12,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			resultLabel.SetBinding (Label.TextProperty, new Binding(path: "Result",stringFormat: "Result: {0}"));

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { dateLabel, resultLabel }
			};
			return nameLayout;
		}
	}
}


