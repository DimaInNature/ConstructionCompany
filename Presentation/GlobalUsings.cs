﻿global using Data.Context;
global using Domain.Abstract;
global using Domain.Models;
global using Enums.User;
global using Features.Clients.Commands;
global using Features.Clients.Queries;
global using Features.Constructions.Commands;
global using Features.Constructions.Queries;
global using Features.Products.Commands;
global using Features.Products.Queries;
global using Features.Users.Commands;
global using Features.Users.Queries;
global using Features.Workers.Commands;
global using Features.Workers.Queries;
global using IoC.Injectors;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using MVVM.Command;
global using MVVM.ViewModel;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Converters;
global using Presentation.Configurations;
global using Presentation.Configurations.MediatR;
global using Presentation.Configurations.MediatR.Profiles;
global using Presentation.ViewModels;
global using Presentation.ViewModels.Abstract;
global using Presentation.ViewModels.Abstract.Base;
global using Presentation.ViewModels.Abstract.UserControls.Clients;
global using Presentation.ViewModels.Abstract.UserControls.Constructions;
global using Presentation.ViewModels.Abstract.UserControls.Products;
global using Presentation.ViewModels.Abstract.UserControls.Reports;
global using Presentation.ViewModels.Abstract.UserControls.Users;
global using Presentation.ViewModels.Abstract.UserControls.Workers;
global using Presentation.ViewModels.UserControls.Clients;
global using Presentation.ViewModels.UserControls.Constructions;
global using Presentation.ViewModels.UserControls.Products;
global using Presentation.ViewModels.UserControls.Reports;
global using Presentation.ViewModels.UserControls.Users;
global using Presentation.ViewModels.UserControls.Workers;
global using Presentation.Views;
global using Presentation.Views.UserControls.Clients;
global using Presentation.Views.UserControls.Constructions;
global using Presentation.Views.UserControls.Products;
global using Presentation.Views.UserControls.Reports;
global using Presentation.Views.UserControls.Users;
global using Presentation.Views.UserControls.Workers;
global using Services;
global using Services.Abstract.Clients;
global using Services.Abstract.Constructions;
global using Services.Abstract.Products;
global using Services.Abstract.Users;
global using Services.Abstract.Workers;
global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Security;
global using System.Threading.Tasks;
global using System.Windows;
global using System.Windows.Controls;
global using System.Windows.Input;
global using Util.Helpers;