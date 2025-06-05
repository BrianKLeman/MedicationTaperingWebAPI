﻿using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{


    public class LogActivity
    {
        [Required]
        public long JobID { get; set; }
        public DateTime? Date { get; set; }
    }
    [Route("Api/JobsAtHome")]
    public class JobsAtHomeController : ControllerBase
    {
        public JobsAtHomeController(IAuthService authService, IJobsAtHomeViewsDataAccess dataAccess, IJobsAtHomeLogDataAccess alDataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
            this.activityLogDataAccess = alDataAccess;
        }

        private IAuthService authService;
        private IJobsAtHomeViewsDataAccess dataAccess;
        private IJobsAtHomeLogDataAccess activityLogDataAccess;

        [HttpGet()]
        [Route("Summary")]
        public IActionResult JobsAtHomeSummary()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return Ok(dataAccess.GetsJobsAtHomeSummary(personID));
        }

        [HttpPost()]
        [Route("Log")]
        public IActionResult LogActivity([FromBody] LogActivity jobAtHome)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            return Ok(activityLogDataAccess.AddActivity(personID, jobAtHome.JobID, jobAtHome.Date ?? DateTime.Now ));
        }

    }
}