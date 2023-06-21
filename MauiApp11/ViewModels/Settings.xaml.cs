using MauiApp11.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace MauiApp11;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

private void Switch_Toggled(object sender, ToggledEventArgs e)
	{
		var s = sender as Microsoft.Maui.Controls.Switch;
		Debug.WriteLine(s.IsToggled);
	}



  
}




