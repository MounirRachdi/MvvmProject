﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProject.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
