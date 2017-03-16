﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovDelivery.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public bool AllowUserInitiatedSubscriptions { get; set; }

        public bool DefaultOpen { get; set; }

        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        public Category Parent { get; set; }

        public string QuickSubscribePageCode { get; set; }
    }
}
