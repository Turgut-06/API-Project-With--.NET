﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Domain.Entities
{
    public class Role :IdentityRole<Guid> //rollerimizi tutarken key olarak guid olarak tutuyorum
    {
    }
}
