﻿using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Models
{
    public class Warehouse
    {
        [Key]
        public int id { get; set; }
        public string WareHouseName { get; set; }
    }
}
