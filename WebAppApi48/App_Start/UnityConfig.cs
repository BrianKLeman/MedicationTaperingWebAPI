using DataAccessLayer;
using DataAccessLayer.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebAppApi48.Services;

namespace WebAppApi48
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<ITableNotesLinksDataAccess, NoteLinksDataAccess>();
            container.RegisterType<INotesDataAccess, NotesDataAccess>();
            container.RegisterType<IMedicationDataAccess, MedicationDataAccess>();
            container.RegisterType<IPrescriptionDataAccess, PrescriptionDataAccess>();
            container.RegisterType<IPersonDataAccess, PersonDataAccess>();
            container.RegisterType<ILearningAimsDataAccess, LearningAimsDataAccess>();
            container.RegisterType<IProjectsDataAccess, ProjectsDataAccess>();
            container.RegisterType<ISleepsDataAccess, SleepsDataAccess>();
            container.RegisterType<IPhenomenaDataAccess, PhenomenaDataAccess>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
        }
    }
}