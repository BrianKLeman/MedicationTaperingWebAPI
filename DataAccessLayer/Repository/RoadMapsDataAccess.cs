using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class RoadMapsDataAccess : DataAccessBase, IRoadMapsDataAccess
    {
        public RoadMapsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<RoadMap> GetRoadMaps(long personID, bool includePersonal)
        {
            int personal = includePersonal ? 1 : 0;
            using (var c = NewDataConnection())
            {               
                var roadmaps = from n in c.GetTable<RoadMap>()
                        where n.PersonId == personID
                        select n;
                return roadmaps.ToList();                
            }                
        }

        public IEnumerable<RoadMap> GetRoadMapsForProjectID(long personID, long projectID)
        {
            using (var c = NewDataConnection())
            {
                var roadmaps = from f in c.GetTable<RoadMap>()
                        where f.PersonId == personID && f.ProjectID != null && f.ProjectID == projectID
                        select f;
                return roadmaps.ToList();
            }
        }

        public IEnumerable<RoadMap> GetRoadMapsForLearningAimID(long personID, long learningAimID)
        {
            using (var c = NewDataConnection())
            {               
                var roadmaps =  from f in c.GetTable<RoadMap>()
                        where f.PersonId == personID && f.LearningAimID != null && f.LearningAimID == learningAimID
                        select f;
                return roadmaps.ToList();
            }
        }

        public long UpdateRoadMap(long personID, RoadMap r)
        {
            using (var c = NewDataConnection())
            {
                if (r.PersonId == personID)
                {
                    r.PersonId = (uint)personID;
                    var result = c.Update(r);
                    
                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long CreateRoadMap(long personID, RoadMap r)
        {
            using (var c = NewDataConnection())
            {
                if (r.PersonId == 0 || r.PersonId == personID)
                {
                    r.Id = 0; // I think setting the roadmap id to zero will make
                                // it get an id by default.
                    r.PersonId = (uint)personID;
                    var id = c.InsertWithIdentity(r);

                    
                    return (long)id;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long DeleteRoadMap(long personID, RoadMap r)
        {
            using (var c = NewDataConnection())
            {
                if (r.PersonId == 0 || r.PersonId == personID)
                {
                    // Check task with same id belongs to same person
                    var roadmaps = from roadmap in c.GetTable<RoadMap>()
                                where roadmap.PersonId == personID && r.Id == roadmap.Id
                                select roadmap;

                    var result = -1;
                    foreach (var roadmap in roadmaps.ToList())
                        result = c.Delete(roadmap);

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