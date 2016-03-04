﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string UserTypeValue { get; set; }
        public virtual List<UserType> UserTypes { get; set; }
    }
}
