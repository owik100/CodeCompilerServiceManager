﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Settings
{
    public class AppSettingsModel
    {
        public TimeSpan OperationTimeout { get; set; }
        public int CheckStatusInterval { get; set; }
    }
}