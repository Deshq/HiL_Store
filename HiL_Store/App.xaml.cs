using HiL_Store.Domain.Interfaces.Authentication;
using HiL_Store.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HiL_Store.Domain.Services.Authentication;
using HiL_Store.ViewModels.Factories;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.EF.Services;
using HiL_Store.Domain.Entities;
using HiL_Store.ViewModels;
using HiL_Store.State.Navigators;
using HiL_Store.State.Authenticators;
using HiL_Store.State.Accounts;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Services.CreationService;
using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.HostBuilders;

namespace HiL_Store
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                 .AddConfiguration()
                 .AddDbContext()
                 .AddServices()
                 .AddStores()
                 .AddViewModels()
                 .AddViews();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
