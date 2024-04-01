using NHibernate.Cfg;
using NHibernate;
using System.IO;
using System;

namespace ManagementStudentWithNHibernate
{
    public class NHibernateSession
    {
        public static NHibernate.ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models\\hibernate.cfg.xml");
            configuration.Configure(configurationPath);

            var studentConfigurationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mapping\\student.hbm.xml");
            configuration.AddFile(studentConfigurationFile);

            var courseConfigurationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mapping\\course.hbm.xml");
            configuration.AddFile(courseConfigurationFile);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
