﻿using System.Collections.Generic;
using System.Web.Http;

namespace FeatureBee.Server.Controllers
{
    using System.Linq;

    using FeatureBee.Server.Data.Features;
    using FeatureBee.Server.Models;

    public class FeatureBeeStagingApiController : ApiController
    {
        private readonly IFeatureRepository repository;

        public FeatureBeeStagingApiController(IFeatureRepository repository)
        {
            this.repository = repository;
        }

        // GET api/features
        public IEnumerable<dynamic> Get()
        {
            return repository.Collection().Select(
                feature => new {
                    name = feature.name,
                    conditions = feature.conditions
                });
        }

        // GET api/features/myfeature
        public Feature Get(string id)
        {
            return repository.Collection().FirstOrDefault(_ => _.name == id);
        }
    }
}