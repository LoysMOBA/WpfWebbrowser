using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfWebbrowser.Pages;

namespace WpfWebbrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SettingsPage settingsPage = new SettingsPage();
        WebViewPage webViewPage = new WebViewPage();
        public MainWindow()
        {
            InitializeComponent();
            myFrame.Content = webViewPage;
            webViewPage.webView.NavigationCompleted += WebView_NavigationCompleted;
        }

        private void WebView_NavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
        {
            textBoxURL.Text = webViewPage.webView.Source.ToString();
            Title = "Web Browser -" + webViewPage.webView.DocumentTitle;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = webViewPage;
            webViewPage.webView.GoBack();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = webViewPage;
            webViewPage.webView.GoForward();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = webViewPage;
            webViewPage.webView.Refresh();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = webViewPage;
            webViewPage.webView.Navigate(new Uri("https://www.google.com"));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new Uri("Pages/WebViewPage.xaml", UriKind.Relative));
             
        }

        private void textBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!String.IsNullOrEmpty(textBoxURL.Text))
                {
                    myFrame.Content = webViewPage;
                    webViewPage.webView.Navigate(new Uri(textBoxURL.Text));
                }
            }
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Content = settingsPage;
        }
    }
}
