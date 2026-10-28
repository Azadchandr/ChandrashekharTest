using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChandrashekharTest.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public int EducationId { get; set; }

        public int PermanentStateId { get; set; }

        public int PermanentDistrictId { get; set; }

        public string PermanentAddress { get; set; }

        public int CorrespondenceStateId { get; set; }
        public string CorrespondenceStateName { get; set; }

        public int CorrespondenceDistrictId { get; set; }
        public string CorrespondenceDistrictName { get; set; }

        public string CorrespondenceAddress { get; set; }

        [Required]
        public string PhotoPath { get; set; }

        public DateTime SubmittedDate { get; set; }

        public string Status { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public DateTime? RejectedDate { get; set; }

        public bool InterviewMessageSent { get; set; }

        public string RejectionReason { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string EducationName { get; set; }

        public string PermanentStateName { get; set; }

        public string PermanentDistrictName { get; set; }

        public bool IsAdult()
        {
            //DateTime minimumDob = DateTime.Today.AddYears(-18);

            //return DOB <= minimumDob;

            return DOB <= DateTime.Today.AddYears(-18);
        }
    }
    }














