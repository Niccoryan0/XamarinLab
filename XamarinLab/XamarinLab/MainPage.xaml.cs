using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLab.Models;

namespace XamarinLab
{
    public partial class MainPage : ContentPage
    {
        ViewCell selectedCell;

        public MainPage()
        {
            InitializeComponent();
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

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage
            {
                BindingContext = new TodoItem()
            });
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                if (viewCell.View.BackgroundColor == Color.Red) viewCell.View.BackgroundColor = Color.Transparent;

                else viewCell.View.BackgroundColor = Color.Red;

                selectedCell = viewCell;
            }
        }
    }
}
