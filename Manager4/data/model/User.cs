using Manager4.data.entity;
using Manager4.util.enu;
using System;

namespace Manager4.data.model
{
    public class User
    {
        private long _id;
        private string _name;
        private DateTime _birthday;
        private string _address;
        private string _phoneNumber;
        private string _signature;
        private RoleEnum _role;
        private string _username;

        public User(UserEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Birthday = entity.Birthday;
            Address = entity.Address;
            PhoneNumber = entity.PhoneNumber;
            Role = entity.Role;
            Signature = entity.Signature;
            UserName = entity.Username;
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
        public string Signature
        {
            get => _signature;
            set => _signature = value;
        }
        public RoleEnum Role
        {
            get => _role;
            set => _role = value;
        }
        public string UserName
        {
            get => _username;
            set => _username = value;
        }
    }
}
