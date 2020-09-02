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
                    Name = "Nicco",
                    Notes = "Ryan"
                },
                new TodoItem
                {
                    Name = "Yasir",
                    Notes = "Mohamud"
                },
                new TodoItem
                {
                    Name = "Peyton",
                    Notes = "Cysewski"
                }

            };
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            
            if (viewCell.View != null)
            {
                if (viewCell.View.BackgroundColor == Color.Gray) viewCell.View.BackgroundColor = Color.Transparent;

                else viewCell.View.BackgroundColor = Color.Gray;
                

                selectedCell = viewCell;
            }
        }
    }
}
