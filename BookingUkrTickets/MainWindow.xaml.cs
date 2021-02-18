using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingUkrTickets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JsonTrainSearchResponse jsonObject;

        public MainWindow()
        {
            InitializeComponent();
        }

 
        // Button Func
        private void FindTrainsFunc(object sender, RoutedEventArgs e)
        {
            jsonObject = Connection.FindTrains(departurePlaceTb.Text, destinationPlaceTb.Text, departureDatePlaceTb.Text);
            if (jsonObject.Error == 1)
            {
                MessageBox.Show("Данные не были получены!");
                return;
            }
            
            idTrainResult.Items.Clear();
            foreach (List value in jsonObject.Data.List)
                this.idTrainResult.Items.Add(value.Num);
            idTrainResult.SelectedIndex = 0;
            expanderFullInfo.IsExpanded = true;
            MessageBox.Show("Успешно!");

        } // Button, All trains
        private void ChooseTrainFunc(object sender, RoutedEventArgs e)
        {

        } // Button, Type train

        // Changed event
        private void IdTrainResultChangedValue(object sender, SelectionChangedEventArgs e)
        {
            int index = idTrainResult.SelectedIndex;
            if (index == -1)
            {
                departurePlaceResult.Text = "";
                destinationPlaceResult.Text = "";
                departureDatetimePlaceResult.Text = "";
                destinationDatetimePlaceResult.Text = "";
                availableTrainPlaceResult.Items.Clear();
                return;
            }
            departurePlaceResult.Text = jsonObject.Data.List[index].From.StationTrain;
            destinationPlaceResult.Text = jsonObject.Data.List[index].To.StationTrain;
            departureDatetimePlaceResult.Text = jsonObject.Data.List[index].From.Date + ", " + jsonObject.Data.List[index].From.Time.TimeOfDay.ToString();
            destinationDatetimePlaceResult.Text = jsonObject.Data.List[index].To.Date + ", " + jsonObject.Data.List[index].To.Time.TimeOfDay.ToString();

            availableTrainPlaceResult.Items.Clear();
            foreach (var value in jsonObject.Data.List[index].Types)
                this.availableTrainPlaceResult.Items.Add(value.Id + " - " + value.Places);
            if (availableTrainPlaceResult.Items.Count <= 0)
            {
                availableTrainPlaceResult.Visibility = Visibility.Collapsed;
                fullTrainPlaceResult.Visibility = Visibility.Visible;
            }
            else
            {
                fullTrainPlaceResult.Visibility = Visibility.Collapsed;
                availableTrainPlaceResult.Visibility = Visibility.Visible;
                availableTrainPlaceResult.SelectedIndex = 0;
            }
        } // ComboBox changed event, ID train
        private void TypeTrainChangedValue(object sender, SelectionChangedEventArgs e)
        {

        } // ComboBox changed event, Type train
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Keyboard.FocusedElement is TextBox)
                Keyboard.FocusedElement.RaiseEvent(new RoutedEventArgs(LostFocusEvent));
        }
        // Menu bar

        private void SendAuthDataFunc(object sender, RoutedEventArgs e)
        {
            UserAuthWindow userAuthWindow = new UserAuthWindow();
            userAuthWindow.Show();
        }

        //First header
        private void AuthenticationFunc(object sender, RoutedEventArgs e)
        {
            Connection.Authentication();
        } // Correct
        private void DeauthenticationFunc(object sender, RoutedEventArgs e)
        {
            Connection.Deauthentication();
        } // Correct
        private void OpenBrowserFunc(object sender, RoutedEventArgs e)
        {
            LocalWebBrowser localWeb = new LocalWebBrowser("https://booking.uz.gov.ua/ru/?from=2200001&to=2208001&date=2020-08-22&time=00%3A00&url=train-list");
            localWeb.Show();
        } // Correct
        private void OpenCabinetFunc(object sender, RoutedEventArgs e)
        {
            LocalWebBrowser localWeb = new LocalWebBrowser("https://booking.uz.gov.ua/ru/cabinet/actual/");
            localWeb.Show();
        } // Correct
        private void OpenCartFunc(object sender, RoutedEventArgs e)
        {
            LocalWebBrowser localWeb = new LocalWebBrowser("https://booking.uz.gov.ua/ru/cart/");
            localWeb.Show();
        } // Correct
        private void ExitFunc(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        } //Correct

        //Second header
        private void OpenCookiesFormFunc(object sender, RoutedEventArgs e)
        {
            CookiesForm cookiesForm = new CookiesForm();
            cookiesForm.Show();
        }
        private void AddTabItemFunc(object sender, RoutedEventArgs e)
        {           
            int idx = tabControl.Items.Count;
            TabItem ti = new TabItem();
            ti.Header = idx + " пассажир";
            ti.ContentTemplate = tabControl.FindResource("TabTemplatePerson") as DataTemplate;
            tabControl.Items.Insert(idx, ti);
            tabControl.SelectedIndex = idx;
        }
        private void RemoveTabItemFunc(object sender, RoutedEventArgs e)
        {
            int idx = tabControl.Items.Count;
            if (tabControl.SelectedIndex == idx)
                tabControl.SelectedIndex = idx - 1;
            tabControl.Items.RemoveAt(idx-1);
        }
    }
}
