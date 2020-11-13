﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ST3Prj3BusinessLogicCore.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ST3Prj3InterfacesCore;
using ST3Prj3DataAccessLogicCore.Data; //Using a EF Core DbContext
using ST3Prj3DataAccessLogicCore.Boundaries;//Using own boundary classe


namespace ST3Prj3MainAndWPFLogicCorePC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// This tutorial using DI container and WPF has been used https://executecommands.com/dependency-injection-in-wpf-net-core-csharp/
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();//Start a DI Container (Dependency Injection Container)
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<iDataAccessLogic,CtrlDataAccessLogicWPF>(); //Add an WPF instance a iDataAccesLogic implementaion to the DI Container
            services.AddSingleton<iBusinessLogic, CtrlBusinessLogic>(); //Add anusing ST3Prj3DataAccessLogicCore.Data; instance a iBusinessLogiciBusinessLogic implementaion to the DI Container
            services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseSqlite("Data Source = Employee.db");//This options may be smarter to set in DbContext
            });

            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
