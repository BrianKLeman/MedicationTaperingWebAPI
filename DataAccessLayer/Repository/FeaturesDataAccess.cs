using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class FeaturesDataAccess : DataAccessBase, IFeaturesDataAccess
    {
        public FeaturesDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Feature> GetFeatures(long personID, bool includePersonal)
        {
            int personal = includePersonal ? 1 : 0;
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var notes = from n in c.GetTable<Feature>()
                            where n.PersonId == personID
                            select n;
                    return notes.ToList();
                }
                else
                {
                    return new Feature[0];
                }
                
            }                
        }

        public IEnumerable<Feature> GetFeaturesForProjectID(long personID, long projectID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var features = from f in c.GetTable<Feature>()
                           where f.PersonId == personID && f.ProjectID != null && f.ProjectID == projectID
                           select f;
                    return features.ToList();
                }
                else
                {
                    return new Feature[0];
                }
            }
        }

        public IEnumerable<Feature> GetFeaturesForLearningAimID(long personID, long learningAimID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var features =  from f in c.GetTable<Feature>()
                           where f.PersonId == personID && f.LearningAimID != null && f.LearningAimID == learningAimID
                           select f;
                    return features.ToList();
                }
                else
                {
                    return new Feature[0];
                }
            }
        }

        public long UpdateFeature(long personID, Feature f)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && f.PersonId == personID)
                {
                    f.PersonId = (uint)personID;
                    var result = c.Update(f);
                    
                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long CreateFeature(long personID, Feature f)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && (f.PersonId == 0 || f.PersonId == personID))
                {
                    f.Id = 0; // I think setting the feature id to zero will make
                                // it get an id by default.
                    f.PersonId = (uint)personID;
                    var id = c.InsertWithIdentity(f);

                    
                    return (long)id;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long DeleteFeature(long personID, Feature f)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && (f.PersonId == 0 || f.PersonId == personID))
                {
                    // Check task with same id belongs to same person
                    var features = from feature in c.GetTable<Feature>()
                                where feature.PersonId == personID && f.Id == feature.Id
                                select feature;

                    var result = -1;
                    foreach (var feature in features.ToList())
                        result = c.Delete(feature);

                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}