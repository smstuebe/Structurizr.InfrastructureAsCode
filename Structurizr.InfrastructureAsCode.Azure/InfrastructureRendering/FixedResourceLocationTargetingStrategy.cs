﻿using Structurizr.InfrastructureAsCode.InfrastructureRendering;

namespace Structurizr.InfrastructureAsCode.Azure.InfrastructureRendering
{
    public class FixedResourceLocationTargetingStrategy : IResourceLocationTargetingStrategy
    {
        private readonly string _location;

        public FixedResourceLocationTargetingStrategy(string location)
        {
            _location = location;
        }
        public string TargetLocation(IInfrastructureEnvironment environment, IHaveInfrastructure elementWithInfrastructure)
        {
            return _location;
        }
    }
}