using Autofac;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.DB.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FriendRepository>().As<IFriendRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }
    }
}
