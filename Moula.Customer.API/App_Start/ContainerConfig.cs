using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Moula.Customer.Service;
using Moula.Customer.Data;
using System.Web.Http;
using Autofac.Integration.WebApi;
using FluentValidation;
using System.Reflection;

namespace Moula.Customer.API
{
    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var executingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(executingAssembly);

            builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<JsonFileAccess>().As<ICustomerDataAccess>().SingleInstance();

            //builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            //builder.RegisterHttpRequestMessage(GlobalConfiguration.Configuration);


            //builder.RegisterWebApiModelBinderProvider();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}