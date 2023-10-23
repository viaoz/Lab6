using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
namespace Lab6_Starter;
public partial class ResourcesPage : ContentPage
{
	public ResourcesPage()
	{
  

            InitializeComponent();

            // Create a list of URLs (or resources)
            List<string> urlList = new List<string>
            {
                "https://www.AirportExample1.com",
                "https://www.AirportExample2.com",
                // Add more URLs or resources here
            };

            // Set the ItemsSource of the CollectionView to the list of URLs
            collectionView.ItemsSource = urlList;
        
    }
}