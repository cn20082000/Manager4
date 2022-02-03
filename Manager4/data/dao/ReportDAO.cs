using Manager4.data.entity;
using Manager4.data.model;
using System;
using System.Linq;

namespace Manager4.data.dao
{
    public class ReportDAO : DAO, IDisposable
    {
        public ReportEntity Create(float leftSph, float leftCyl, int leftAx, float leftAdd, int leftVa, int leftFh, float leftPd2, float leftPd,
            float rightSph, float rightCyl, int rightAx, float rightAdd, int rightVa, int rightFh, float rightPd2, float rightPd,
            bool distance, bool neutral, bool reading)
        {
            ReportEntity entity = new ReportEntity();
            entity.Time = DateTime.Now;
            entity.Distance = distance;
            entity.Neutral = neutral;
            entity.Reading = reading;

            using (EyeDAO dao = new EyeDAO())
            {
                entity.LeftEye = dao.Create(leftSph, leftCyl, leftAx, leftAdd, leftVa, leftFh, leftPd2, leftPd);
                entity.RightEye = dao.Create(rightSph, rightCyl, rightAx, rightAdd, rightVa, rightFh, rightPd2, rightPd);
            }

            try
            {
                db.Reports.Add(entity);
                db.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                db.Reports.Remove(entity);
                throw;
            }
        }

        public ReportEntity Get(Report rp)
        {
            var reports = from report
                          in db.Reports
                          where report.Id == rp.Id
                          select report;
            return reports.Single();
        }

        public void Dispose() { }
    }
}
