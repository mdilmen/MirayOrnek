﻿using MirayOrnek.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Logger
{
    public interface ILoggers
    {
        void LogWrite(string logMessage);
    }
}