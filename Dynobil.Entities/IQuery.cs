﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Entities
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}