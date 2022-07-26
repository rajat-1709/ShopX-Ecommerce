﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AdminECommerceAPI.Models
{
    public partial class Contribution
    {
        public int Cid { get; set; }
        public int? ChangeMadeBy { get; set; }
        public string Reference { get; set; }
        public string ChangesMade { get; set; }
        public string ChangedTime { get; set; }
        public string Reason { get; set; }

        public virtual Admin ChangeMadeByNavigation { get; set; }
    }
}
