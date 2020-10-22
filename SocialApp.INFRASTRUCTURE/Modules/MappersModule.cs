using Autofac;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using SocialApp.INFRASTRUCTURE.Mappers.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Modules
{
    public class MappersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FriendMapper>().As<IFriendMapper>().InstancePerLifetimeScope();
            builder.RegisterType<PostMapper>().As<IPostMapper>().InstancePerLifetimeScope();
        }
    }
}
