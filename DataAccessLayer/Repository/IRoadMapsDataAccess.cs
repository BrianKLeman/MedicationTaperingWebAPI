using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IRoadMapsDataAccess
    {
        IEnumerable<RoadMap> GetRoadMaps(long personID, bool includePersonal);

        IEnumerable<RoadMap> GetRoadMapsForProjectID(long personID, long projectID);

        IEnumerable<RoadMap> GetRoadMapsForLearningAimID(long personID, long learningAimID);

        long UpdateRoadMap(long personID, RoadMap t);

        long CreateRoadMap(long personID, RoadMap t);

        long DeleteRoadMap(long personID, RoadMap t);
    }
}