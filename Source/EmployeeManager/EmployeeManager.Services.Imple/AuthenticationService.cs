﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EmployeeManager.DatabaseAccesses;
using AutoMapper;

namespace AdventureWorks.EmployeeManager.Services.Imple
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly EmployeeDao _employeeDao;

        public AuthenticationService(EmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }

        public virtual bool Authenticate()
        {
            var name = ServiceSecurityContext.Current.WindowsIdentity.Name;
            return _employeeDao.FindByLoginID(name) != null;
        }
    }
}
