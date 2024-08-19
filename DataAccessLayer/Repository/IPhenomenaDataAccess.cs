﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IPhenomenaDataAccess
    {
        IEnumerable<Phenomena> GetPhenomena(long personID);

        //TODO Implement
        //long InsertNote(long personID, DateTime date, string note, bool behaviorChange);

        //long DeleteNote(long personID, long noteID);

        //long UpdateNote(long personID, DateTime date, string note, bool behaviorChange, long noteID);
        
    }
}