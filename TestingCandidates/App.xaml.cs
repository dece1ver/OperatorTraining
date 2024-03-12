using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Testing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CultureInfo culture = new CultureInfo("ru-RU");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
