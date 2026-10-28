using ChandrashekharTest.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ChandrashekharTest.Data
{
    public class CandidateRepository
    {
        private readonly AppDbConnection _db;

          public CandidateRepository()
            {
                _db = new AppDbConnection();
            }

            // ============================
            // INSERT CANDIDATE
            // ============================

            public int Insert(Candidate candidate)
            {
                using (var con = _db.CreateConnection())
                {
                    var parameters = new
                    {
                        candidate.TitleId,
                        candidate.Name,
                        candidate.Gender,
                        candidate.Email,
                        candidate.DOB,
                        candidate.EducationId,

                        candidate.PermanentStateId,
                        candidate.PermanentDistrictId,
                        candidate.PermanentAddress,

                        candidate.CorrespondenceStateId,
                        candidate.CorrespondenceDistrictId,
                        candidate.CorrespondenceAddress,

                        candidate.PhotoPath,

                        candidate.CreatedBy
                    };

                    return con.QuerySingle<int>(
                        "dbo.sp_Candidate_Insert",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }
            }


            // ============================
            // GET ALL CANDIDATES
            // ============================

            public IEnumerable<Candidate> GetAll()
            {
                using (var con = _db.CreateConnection())
                {
                    return con.Query<Candidate>(
                        "dbo.sp_Candidate_GetAll",
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                }
            }


            // ============================
            // GET CANDIDATE BY ID
            // ============================

            public Candidate GetById(int candidateId)
            {
                using (var con = _db.CreateConnection())
                {
                    return con.QueryFirstOrDefault<Candidate>(
                        "dbo.sp_Candidate_GetById",
                        new
                        {
                            CandidateId = candidateId
                        },
                        commandType: CommandType.StoredProcedure);
                }
            }


        // ============================
        // UPDATE CANDIDATE
        // ============================




        public bool Update(Candidate candidate)
        {
            using (var con = _db.CreateConnection())
            {
                return con.QuerySingle<bool>(
                    "dbo.sp_Candidate_Update",
                    new
                    {
                        candidate.CandidateId,
                        candidate.TitleId,
                        candidate.Name,
                        candidate.Gender,
                        candidate.Email,
                        candidate.DOB,
                        candidate.EducationId,
                        candidate.PermanentStateId,
                        candidate.PermanentDistrictId,
                        candidate.PermanentAddress,
                        candidate.CorrespondenceStateId,
                        candidate.CorrespondenceDistrictId,
                        candidate.CorrespondenceAddress,
                        candidate.PhotoPath
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        // ============================
        // DELETE CANDIDATE
        // ============================

        public bool Delete(int candidateId)
            {
                using (var con = _db.CreateConnection())
                {
                    return con.QuerySingle<bool>(
                        "dbo.sp_Candidate_Delete",
                        new
                        {
                            CandidateId = candidateId
                        },
                        commandType: CommandType.StoredProcedure);
                }
            }


            // ============================
            // DASHBOARD STATISTICS
            // ============================

            public DashboardStats GetDashboardStats()
            {
                using (var con = _db.CreateConnection())
                {
                    return con.QueryFirstOrDefault<DashboardStats>(
                        "dbo.sp_Candidate_DashboardStats",
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
    
        //-------------------------
       // UPDATE STATUS
      //---------------------------

        public bool UpdateStatus( int candidateId,string status)
        {
            using (var con = _db.CreateConnection())
            {
                string sql = @"
            UPDATE tbl_Candidate
            SET
                Status = @Status,

                ApprovedDate =
                    CASE
                        WHEN @Status = 'Approved'
                            THEN GETDATE()
                        WHEN @Status = 'Rejected'
                            THEN NULL
                        ELSE ApprovedDate
                    END,

                RejectedDate =
                    CASE
                        WHEN @Status = 'Rejected'
                            THEN GETDATE()
                        WHEN @Status = 'Approved'
                            THEN NULL
                        ELSE RejectedDate
                    END,

                ModifiedDate = GETDATE()

            WHERE CandidateId = @CandidateId;
        ";

                int result = con.Execute(
                    sql,
                    new
                    {
                        CandidateId = candidateId,
                        Status = status
                    });

                return result > 0;
            }
        }



    }
}






  