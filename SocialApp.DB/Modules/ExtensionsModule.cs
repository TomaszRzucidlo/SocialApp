using Autofac;
using SocialApp.DB.Extensions.Abstract;
using SocialApp.DB.Extensions.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Modules
{
    public class ExtensionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordManager>().As<IPasswordManager>().InstancePerLifetimeScope();
        }
    }
}
