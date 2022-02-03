using Manager4.data.entity;
using System;

namespace Manager4.data.model
{
    public class Customer
    {
        private long _id;
        private string _name;
        private DateTime _birthday;
        private string _address;
        private string _phoneNumber;

        public Customer(CustomerEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Birthday = entity.Birthday;
            Address = entity.Address;
            PhoneNumber = entity.PhoneNumber;
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }
        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
    }
}
