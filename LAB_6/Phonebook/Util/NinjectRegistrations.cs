using Ninject.Modules;
using Phonebook.Models;
using MyRepository;
using DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web.Common;

namespace Phonebook.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<HandbookRecord>>().To<DatabaseRepository.HandbookRepository>();
            //Bind<IRepository<HandbookRecord>>().To<DatabaseRepository.HandbookRepository>().InThreadScope();
            Bind<IRepository<HandbookRecord>>().To<MyRepository.JsonRepository>();
        }
    }
}