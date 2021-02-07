using Autofac;
using SocialApp.INFRASTRUCTURE.Extensions.Abstract;
using SocialApp.INFRASTRUCTURE.Extensions.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
        }
    }
}
