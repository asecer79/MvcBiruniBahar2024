using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.AuthorizationServices.Abstract;
using Business.AuthorizationServices.Concrete;
using Business.CommonServices.ICommonUserInterfaces;
using Business.Services.Obs.Abstract;
using Business.Services.Obs.Concrete;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using DataAccess.ObsDbContext.Ef.Dal.Concrete;

namespace Business.DependencyResolvers.ObsDependencyResolver
{
    public class ObsDependencyResolver:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FacultyService>().As<IFacultyService>();
            builder.RegisterType<FacultyDal>().As<IFacultyDal>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<DepartmentDal>().As<IDepartmentDal>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<OperationClaimService>().As<IOperationClaimService>();
            builder.RegisterType<OperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<UserOperationClaimDal>().As<IUserOperationClaimDal>();
            builder.RegisterType<UserOperationClaimService>().As<IUserOperationClaimService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}
