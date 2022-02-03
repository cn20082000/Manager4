using Manager4.data.entity;
using System;

namespace Manager4.data.model
{
    public class Report
    {
        private long _id;
        private DateTime _time;
        private bool _distance;
        private bool _neutral;
        private bool _reading;
        private Eye _leftEye;
        private Eye _rightEye;

        public Report(ReportEntity entity)
        {
            Id = entity.Id;
            Time = entity.Time;
            Distance = entity.Distance;
            Neutral = entity.Neutral;
            Reading = entity.Reading;
            LeftEye = entity.LeftEye == null ? null : new Eye(entity.LeftEye);
            RightEye = entity.RightEye == null ? null : new Eye(entity.RightEye);
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime Time
        {
            get => _time;
            set => _time = value;
        }

        public bool Distance
        {
            get => _distance;
            set => _distance = value;
        }

        public bool Neutral
        {
            get => _neutral;
            set => _neutral = value;
        }

        public bool Reading
        {
            get => _reading;
            set => _reading = value;
        }

        public Eye LeftEye
        {
            get => _leftEye;
            set => _leftEye = value;
        }

        public Eye RightEye
        {
            get => _rightEye;
            set => _rightEye = value;
        }
    }
}
