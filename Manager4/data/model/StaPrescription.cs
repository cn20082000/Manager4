namespace Manager4.data.model
{
    public class StaPrescription
    {
        private string _time;
        private float _payment;
        private int _count;

        public StaPrescription(string time, float payment, int count)
        {
            Time = time;
            Payment = payment;
            Count = count;
        }

        public string Time
        {
            get => _time;
            set => _time = value;
        }

        public float Payment
        {
            get => _payment;
            set => _payment = value;
        }

        public int Count
        {
            get => _count;
            set => _count = value;
        }
    }
}
