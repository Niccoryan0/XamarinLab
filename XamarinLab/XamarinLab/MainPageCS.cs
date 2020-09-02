using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinLab.Models;

namespace XamarinLab
{
    public class MainPageCS : ContentPage
    {
        ListView listView;

        public MainPageCS()
        {
            Title = "Todo";



            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                IconImageSource = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MainPageCS
                {
                    BindingContext = new TodoItem()
                });
            };
            ToolbarItems.Add(toolbarItem);




            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    label.SetBinding(Label.TextProperty, "Name");

                    var tick = new Image
                    {
                        Source = ImageSource.FromFile("check.png"),
                        HorizontalOptions = LayoutOptions.End
                    };
                    tick.SetBinding(VisualElement.IsVisibleProperty, "Done");

                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label, tick }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            listView.ItemSelected += async (sender, e) =>
            {

                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new MainPageCS
                    {
                        BindingContext = e.SelectedItem as TodoItem
                    });
                }
            };

            Content = listView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = new List<TodoItem>()
            {
                new TodoItem
                {
                    Name = "test",
                    Notes = "testing",
                    Done = false
                },
                new TodoItem
                {
                    Name = "test2",
                    Notes = "testing2",
                    Done = false
                },
                new TodoItem
                {
                    Name = "test3",
                    Notes = "testing3",
                    Done = false
                }

            };
        }
    }
}
