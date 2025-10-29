using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IFeaturesDataAccess
    {
        IEnumerable<Feature> GetFeatures(long personID, bool includePersonal);

        IEnumerable<Feature> GetFeaturesForProjectID(long personID, long projectID);

        IEnumerable<Feature> GetFeaturesForLearningAimID(long personID, long learningAimID);

        long UpdateFeature(long personID, Feature t);

        long CreateFeature(long personID, Feature t);

        long DeleteFeature(long personID, Feature t);
    }
}