using AutoMapper;
using Microsoft.Win32;
using PaskiPlacowe.InteractionRequest;
using PaskiPlacowe.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PaskiPlacowe.Utils;

namespace PaskiPlacowe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AutomapperSetup.AutomapperInitialize();
        }
    }
}
