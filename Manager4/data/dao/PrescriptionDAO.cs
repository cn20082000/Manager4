using Manager4.data.entity;
using Manager4.data.model;
using Manager4.util;
using Manager4.util.enu;
using Manager4.util.ext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager4.data.dao
{
    internal class PrescriptionDAO : DAO
    {
        public PrescriptionEntity GetLast(Customer cus)
        {
            var prescriptions = from prescription
                                in db.Prescriptions
                                where prescription.Customer.Id == cus.Id
                                select prescription;
            List<PrescriptionEntity> pres = prescriptions.ToList();
            return prescriptions.OrderByDescending(x => x.Id).First();
        }

        public PrescriptionEntity GetLast()
        {
            var prescriptions = from prescription
                                in db.Prescriptions
                                select prescription;
            return prescriptions.OrderByDescending(x => x.Id).First();
        }

        public List<PrescriptionEntity> GetAll(Customer cus)
        {
            var prescriptions = from prescription
                                in db.Prescriptions
                                where prescription.Customer.Id == cus.Id
                                select prescription;
            return prescriptions.OrderByDescending(x => x.Id).ToList();
        }

        public List<PrescriptionEntity> FindByKey(string key)
        {
            var prescriptions = from prescription
                                in db.Prescriptions
                                where prescription.Key.Contains(key)
                                select prescription;
            return prescriptions.OrderByDescending(x => x.Id).Page(1, 20).ToList();
        }

        public PrescriptionEntity Create(EyewearEnum eyewear, string note, int reExam, float payment,
            float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd,
            float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd,
            bool newDistance, bool newNeutral, bool newReading, User user, Customer customer)
        {
            PrescriptionEntity prescription = new PrescriptionEntity();
            prescription.Eyewear = eyewear;
            prescription.Note = note;
            prescription.ReExam = reExam;
            prescription.Time = DateTime.Now;
            prescription.Payment = payment;
            try
            {
                prescription.Key = Security.GenerateKey(GetLast().Key);
            }
            catch (Exception)
            {
                prescription.Key = Security.GenerateKey("");
            }

            prescription.OldReport = null;

            using (ReportDAO dao = new ReportDAO())
            {
                prescription.NewReport = dao.Create(newLeftSph, newLeftCyl, newLeftAx, newLeftAdd, newLeftVa, newLeftFh, newLeftPd2, newLeftPd,
                    newRightSph, newRightCyl, newRightAx, newRightAdd, newRightVa, newRightFh, newRightPd2, newRightPd,
                    newDistance, newNeutral, newReading);
            }
            using (UserDAO dao = new UserDAO())
            {
                prescription.User = dao.Get(user);
            }
            using (CustomerDAO dao = new CustomerDAO())
            {
                prescription.Customer = dao.Get(customer);
            }

            try
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return prescription;
            }
            catch (Exception)
            {
                db.Prescriptions.Remove(prescription);
                throw;
            }
        }

        public PrescriptionEntity Create(EyewearEnum eyewear, string note, int reExam, float payment, Report oldReport,
            float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd,
            float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd,
            bool newDistance, bool newNeutral, bool newReading, User user, Customer customer)
        {
            PrescriptionEntity prescription = new PrescriptionEntity();
            prescription.Eyewear = eyewear;
            prescription.Note = note;
            prescription.ReExam = reExam;
            prescription.Time = DateTime.Now;
            prescription.Payment = payment;
            try
            {
                prescription.Key = Security.GenerateKey(GetLast().Key);
            }
            catch (Exception)
            {
                prescription.Key = Security.GenerateKey("");
            }


            using (ReportDAO dao = new ReportDAO())
            {
                prescription.OldReport = dao.Get(oldReport);
                prescription.NewReport = dao.Create(newLeftSph, newLeftCyl, newLeftAx, newLeftAdd, newLeftVa, newLeftFh, newLeftPd2, newLeftPd,
                    newRightSph, newRightCyl, newRightAx, newRightAdd, newRightVa, newRightFh, newRightPd2, newRightPd,
                    newDistance, newNeutral, newReading);
            }
            using (UserDAO dao = new UserDAO())
            {
                prescription.User = dao.Get(user);
            }
            using (CustomerDAO dao = new CustomerDAO())
            {
                prescription.Customer = dao.Get(customer);
            }

            try
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return prescription;
            }
            catch (Exception)
            {
                db.Prescriptions.Remove(prescription);
                throw;
            }
        }

        public PrescriptionEntity Create(EyewearEnum eyewear, string note, int reExam, float payment,
            float oldLeftSph, float oldLeftCyl, int oldLeftAx, float oldLeftAdd, int oldLeftVa, int oldLeftFh, float oldLeftPd2, float oldLeftPd,
            float oldRightSph, float oldRightCyl, int oldRightAx, float oldRightAdd, int oldRightVa, int oldRightFh, float oldRightPd2, float oldRightPd,
            bool oldDistance, bool oldNeutral, bool oldReading,
            float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd,
            float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd,
            bool newDistance, bool newNeutral, bool newReading, User user, Customer customer)
        {
            PrescriptionEntity prescription = new PrescriptionEntity();
            prescription.Eyewear = eyewear;
            prescription.Note = note;
            prescription.ReExam = reExam;
            prescription.Time = DateTime.Now;
            prescription.Payment = payment;
            try
            {
                prescription.Key = Security.GenerateKey(GetLast().Key);
            }
            catch (Exception)
            {
                prescription.Key = Security.GenerateKey("");
            }

            using (ReportDAO dao = new ReportDAO())
            {
                prescription.OldReport = dao.Create(oldLeftSph, oldLeftCyl, oldLeftAx, oldLeftAdd, oldLeftVa, oldLeftFh, oldLeftPd2, oldLeftPd,
                    oldRightSph, oldRightCyl, oldRightAx, oldRightAdd, oldRightVa, oldRightFh, oldRightPd2, oldRightPd,
                    oldDistance, oldNeutral, oldReading);
                prescription.NewReport = dao.Create(newLeftSph, newLeftCyl, newLeftAx, newLeftAdd, newLeftVa, newLeftFh, newLeftPd2, newLeftPd,
                    newRightSph, newRightCyl, newRightAx, newRightAdd, newRightVa, newRightFh, newRightPd2, newRightPd,
                    newDistance, newNeutral, newReading);
            }
            using (UserDAO dao = new UserDAO())
            {
                prescription.User = dao.Get(user);
            }
            using (CustomerDAO dao = new CustomerDAO())
            {
                prescription.Customer = dao.Get(customer);
            }

            try
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return prescription;
            }
            catch (Exception)
            {
                db.Prescriptions.Remove(prescription);
                throw;
            }
        }

        public List<StaPrescription> Statistic(StatisticEnum type, DateTime fr, DateTime to)
        {
            to = to.AddDays(1);
            List<StaPrescription> list = new List<StaPrescription>();
            switch (type)
            {
                case StatisticEnum.BY_DAY:
                    {
                        var sta = from pres
                                  in db.Prescriptions
                                  where pres.Time >= fr && pres.Time < to
                                  group pres by new { day = pres.Time.Day, month = pres.Time.Month, year = pres.Time.Year } into d
                                  select new { day = d.Key.day, month = d.Key.month, year = d.Key.year, payment = d.Sum(x => x.Payment), count = d.Count() };
                        sta.OrderByDescending(x => x.year).ThenByDescending(x => x.month).ThenByDescending(x => x.day).ToList().ForEach(x =>
                        {
                            list.Add(new StaPrescription(string.Format("{0:00}/{1:00}/{2:0000}", x.day, x.month, x.year), x.payment, x.count));
                        });
                        break;
                    }
                case StatisticEnum.BY_MONTH:
                    {
                        var sta = from pres
                                  in db.Prescriptions
                                  where pres.Time >= fr && pres.Time < to
                                  group pres by new { month = pres.Time.Month, year = pres.Time.Year } into d
                                  select new { month = d.Key.month, year = d.Key.year, payment = d.Sum(x => x.Payment), count = d.Count() };
                        sta.OrderByDescending(x => x.year).ThenByDescending(x => x.month).ToList().ForEach(x =>
                        {
                            list.Add(new StaPrescription(string.Format("{0:00}/{1:0000}", x.month, x.year), x.payment, x.count));
                        });
                        break;
                    }
                case StatisticEnum.BY_YEAR:
                    {
                        var sta = from pres
                                  in db.Prescriptions
                                  where pres.Time >= fr && pres.Time < to
                                  group pres by new { year = pres.Time.Year } into d
                                  select new { year = d.Key.year, payment = d.Sum(x => x.Payment), count = d.Count() };
                        sta.OrderByDescending(x => x.year).ToList().ForEach(x =>
                        {
                            list.Add(new StaPrescription(string.Format("{0:0000}", x.year), x.payment, x.count));
                        });
                        break;
                    }
            }

            return list;
        }
    }
}
