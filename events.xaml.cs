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
    public sealed partial class events : Page
    {
        public events()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        public static MobileServiceClient MobileService = new MobileServiceClient(
    "https://classi1.azure-mobile.net/",
    "mCzqouGYosjrScgOGFJYrXnusdvXmk33"
);
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }
            if (frame.CanGoBack)
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<classi.Addevents.class1> allusers = new List<classi.Addevents.class1>();
            {
                try
                {
                    allusers = await MobileService.GetTable<classi.Addevents.class1>().ToListAsync();
                    String res = "";
                    foreach (classi.Addevents.class1 u in allusers)
                    {
                        res += "\nEvent is:  " + u.events + "\nplace :   " + u.place + "\ndate :   " + u.date + "\nwebsite is:" + u.website + "\n";
                    }
                    TextBlock tb1 = new TextBlock();
                    tb1.FontSize = 30;
                    tb1.Text = res;
                    sp.Children.Add(tb1);

                    //MessageDialog m5 = new MessageDialog(res);
                    //await m5.ShowAsync();
                }
                catch (Exception ex)
                {
                    var m6 = new MessageDialog("Exception\n" + ex).ShowAsync();
                }
            }
            
        }

    }
}
