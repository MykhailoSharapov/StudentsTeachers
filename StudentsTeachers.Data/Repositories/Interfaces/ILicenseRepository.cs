﻿using StudentsTeachers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers.Data.Repositories.Interfaces
{
    public interface ILicenseRepository
    {
        IEnumerable<License> GetAll();
        License GetLicenseByNum(int num);
       
    }
}
