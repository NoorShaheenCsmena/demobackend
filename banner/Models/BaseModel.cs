﻿using System;
using System.ComponentModel.DataAnnotations;

namespace banner.Models
{
    public class BaseModel
    {
        [Key] public Guid? Id { get; set; } = Guid.NewGuid();
    }
}
