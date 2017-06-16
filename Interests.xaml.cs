using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace classi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Interests : Page
    {
        public Interests()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        public class classi2
        {
            public string id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string interest { get; set; }
            public string phone { get; set; }
        };
        public static MobileServiceClient MobileService = new MobileServiceClient(
    "https://classi1.azure-mobile.net/",
    "mCzqouGYosjrScgOGFJYrXnusdvXmk33"
);
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if(frame==null)
            {
                return;
            }
            if(frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void sub_click(object sender, RoutedEventArgs e)
        {
            try
            {
                classi2 i1 = new classi2
                {
                    name = intname.Text,
                    address = intadr.Text,
                    interest = intr.SelectedItem.ToString(),
                    phone = intph.Text
                };
                await MobileService.GetTable<classi2>().InsertAsync(i1);
                MessageDialog m1 = new MessageDialog("Data Inserted");
                await m1.ShowAsync();
            }
            catch(Exception ex)
            {
                var m2 = new MessageDialog("exception\n" + ex).ShowAsync();
            }
        }
    }
}
