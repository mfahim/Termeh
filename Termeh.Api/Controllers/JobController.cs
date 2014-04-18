using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using JobTrack.Api.Models.Job;

namespace JobTrack.Api.Controllers
{
    public class JobController : ApiController
    {
        private List<Job> _jobs;

        public JobController()
        {
            _jobs = new List<Job>
            {
                new Job()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Status = JobStatus.Binding,
                    Name = "Source Control Upgrade",
                    JobNumber = 1025698,
                    Description = "Description for Source",
                    DueDate = DateTime.Now.AddDays(10),
                    Quantity = 7
                },
                new Job()
                {
                    Id = 2,
                    CreatedDate = DateTime.Now.AddDays(2),
                    Status = JobStatus.Dispatched,
                    Name = "CCW maintain",
                    JobNumber = 1345456,
                    Description = "All Description for CCw customers",
                    DueDate = DateTime.Now.AddDays(15),
                    Quantity = 23
                },
            };

        }

        public IHttpActionResult Get()
        {
            return Ok(_jobs);
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_jobs.SingleOrDefault(p => p.Id == id));
        }

        public IHttpActionResult Post(Job jobViewModel)
        {
            var resource = new Job();
            resource.CreatedDate = DateTime.Now;
            resource.Name = jobViewModel.Name;
            resource.Description = jobViewModel.Description;
            return Created(Url.Link("DefaultApi", new { controller = "Job", id = jobViewModel.Id }), jobViewModel);
        }

        public IHttpActionResult Put(int id, Job jobViewModel)
        {
            var g = _jobs.Single(p => p.Id == id);
            g.Name = jobViewModel.Name;
            g.Quantity = jobViewModel.Quantity;
            g.Description = jobViewModel.Description;
            return Ok(g);
        }

        public IHttpActionResult DeleteResource(int id)
        {
            var jb = _jobs.SingleOrDefault(p => p.Id == id);
            _jobs.Remove(jb);

            return Ok();
        }
    }
}