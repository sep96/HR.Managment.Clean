﻿using HR.Managment.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Domain
{
    public class LeaveTypes : BaseEntity
    {
        [Key]
        public int LeaveTypesID { get; set; }
        public string LeaveTypesName { get; set; } = string.Empty;
        public int LeaveTypesDefaultDays { get; set; }
    }
}
