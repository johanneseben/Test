﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Models
{
    public class Staatsbuergerschaft
    {
        public virtual int StaatsbuergerschaftID { get; set; }
        public virtual string Staat { get; set; }

        public Staatsbuergerschaft()
        {

        }
    }
}
