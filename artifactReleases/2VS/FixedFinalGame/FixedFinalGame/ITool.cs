﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    internal interface ITool
    {
        string Name { get; set; }
        void Use() { }
    }
}
