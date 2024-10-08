﻿using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using WebAppApi48.Attributes;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{
    [RoutePrefix("Api/Prescriptions")]
    [Route("{action=Get}")]
    public class PrescriptionsController : ApiController
    {
        public PrescriptionsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IPrescriptionDataAccess)) as IPrescriptionDataAccess;
        }

        private IAuthService authService;
        private IPrescriptionDataAccess dataAccess;
        public IEnumerable<Prescription> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetPrescriptions(personID);
        }
        
    }
}