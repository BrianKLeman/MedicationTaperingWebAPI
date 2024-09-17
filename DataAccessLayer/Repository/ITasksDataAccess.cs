﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ITasksDataAccess
    {
        IEnumerable<Tasks> GetTasks(long personID);

        IEnumerable<Tasks> GetTasks(long personID, string tableName, long entityID);

        long UpdateTask(long personID, Tasks t);
        
        /*
        long InsertNote(long personID, DateTime date, string note, bool behaviourChangeNeeded, bool displayAsHTML, long entityID, string tableName);

        long DeleteNote(long personID, long noteID);*/

    }
}