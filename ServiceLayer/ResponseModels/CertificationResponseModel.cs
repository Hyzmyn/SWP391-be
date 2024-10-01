﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class CertificationResponse
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ShelterStaffID { get; set; }
        public int PetId { get; set; }
        public string? StaffName { get; set; } 
        public string? PetName { get; set; }   
    }
    public class CertificationResponseDetail
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ShelterStaffId { get; set; }
        public int PetId { get; set; }

        public UserDetailResponse ShelterStaff { get; set; } = null!;
        public PetDetailResponse Pet { get; set; } = null!;
    }

}