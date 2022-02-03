using Manager4.data.entity;
using Manager4.util.enu;
using System;

namespace Manager4.data.model
{
    public class Prescription
    {
        private long _id;
        private EyewearEnum _eyewear;
        private string _note;
        private int _reExam;
        private DateTime _time;
        private float _payment;
        private string _key;
        private Report _oldReport;
        private Report _newReport;
        private User _user;
        private Customer _customer;

        public Prescription(PrescriptionEntity entity)
        {
            Id = entity.Id;
            Eyewear = entity.Eyewear;
            Note = entity.Note;
            ReExam = entity.ReExam;
            Time = entity.Time;
            Payment = entity.Payment;
            Key = entity.Key;
            OldReport = entity.OldReport == null ? null : new Report(entity.OldReport);
            NewReport = entity.NewReport == null ? null : new Report(entity.NewReport);
            User = entity.User == null ? null : new User(entity.User);
            Customer = entity.Customer == null ? null : new Customer(entity.Customer);
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public EyewearEnum Eyewear
        {
            get => _eyewear;
            set => _eyewear = value;
        }

        public string Note
        {
            get => _note;
            set => _note = value;
        }

        public int ReExam
        {
            get => _reExam;
            set => _reExam = value;
        }

        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public float Payment
        {
            get => _payment;
            set => _payment = value;
        }

        public string Key
        {
            get => _key;
            set => _key = value;
        }

        public Report OldReport
        {
            get => _oldReport;
            set => _oldReport = value;
        }

        public Report NewReport
        {
            get => _newReport;
            set => _newReport = value;
        }

        public User User
        {
            get => _user;
            set => _user = value;
        }

        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
    }
}
