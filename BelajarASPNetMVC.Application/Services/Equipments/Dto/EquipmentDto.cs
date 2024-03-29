﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Equipments.Dto
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
