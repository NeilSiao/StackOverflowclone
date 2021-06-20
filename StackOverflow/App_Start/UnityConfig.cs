using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using StackOverflow.ServiceLayers;
using StackOverflow.ViewModels;
namespace StackOverflow
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IQuestionsService, QuestionsService>();
            container.RegisterType<IAnswersService, AnswersService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICategoriesService, CategoriesService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}