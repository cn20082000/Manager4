using Manager4.data.dao;
using Manager4.data.entity;
using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.obj;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager4.data
{
    public class DataManagerImpl : IDataManager
    {
        UserDAO user = new UserDAO();
        CustomerDAO customer = new CustomerDAO();
        PrescriptionDAO prescription = new PrescriptionDAO();

        public DataObject<object, object> ChangePassword(User u, string oldPassword, string newPassword)
        {
            return new DataObject<object, object>(() =>
                {
                    user.ChangePassword(u, oldPassword, newPassword);
                    return null;
                }, o => null);
        }

        public DataObject<CustomerEntity, Customer> CreateCustomer(string name, DateTime birthday, string address, string phoneNumber)
        {
            return new DataObject<CustomerEntity, Customer>(() => customer.Create(name, birthday, address, phoneNumber), entity => new Customer(entity));
        }

        public DataObject<PrescriptionEntity, Prescription> CreatePrescription(EyewearEnum eyewear, string note, int reExam, float payment, float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd, float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd, bool newDistance, bool newNeutral, bool newReading, User user, Customer customer)
        {
            return new DataObject<PrescriptionEntity, Prescription>(() => prescription.Create(eyewear, note, reExam, payment, newLeftSph, newLeftCyl, newLeftAx, newLeftAdd, newLeftVa, newLeftFh, newLeftPd2, newLeftPd, newRightSph, newRightCyl, newRightAx, newRightAdd, newRightVa, newRightFh, newRightPd2, newRightPd, newDistance, newNeutral, newReading, user, customer), entity => new Prescription(entity));
        }

        public DataObject<PrescriptionEntity, Prescription> CreatePrescription(EyewearEnum eyewear, string note, int reExam, float payment, Report oldReport, float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd, float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd, bool newDistance, bool newNeutral, bool newReading, User user, Customer customer)
        {
            return new DataObject<PrescriptionEntity, Prescription>(() => prescription.Create(eyewear, note, reExam, payment, oldReport, newLeftSph, newLeftCyl, newLeftAx, newLeftAdd, newLeftVa, newLeftFh, newLeftPd2, newLeftPd, newRightSph, newRightCyl, newRightAx, newRightAdd, newRightVa, newRightFh, newRightPd2, newRightPd, newDistance, newNeutral, newReading, user, customer), entity => new Prescription(entity));
        }

        public DataObject<PrescriptionEntity, Prescription> CreatePrescription(EyewearEnum eyewear, string note, int reExam, float payment, float oldLeftSph, float oldLeftCyl, int oldLeftAx, float oldLeftAdd, int oldLeftVa, int oldLeftFh, float oldLeftPd2, float oldLeftPd, float oldRightSph, float oldRightCyl, int oldRightAx, float oldRightAdd, int oldRightVa, int oldRightFh, float oldRightPd2, float oldRightPd, bool oldDistance, bool oldNeutral, bool oldReading, float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd, float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd, bool newDistance, bool newNeutral, bool newReading, User user, Customer customer)
        {
            return new DataObject<PrescriptionEntity, Prescription>(() => prescription.Create(eyewear, note, reExam, payment, oldLeftSph, oldLeftCyl, oldLeftAx, oldLeftAdd, oldLeftVa, oldLeftFh, oldLeftPd2, oldLeftPd, oldRightSph, oldRightCyl, oldRightAx, oldRightAdd, oldRightVa, oldRightFh, oldRightPd2, oldRightPd, oldDistance, oldNeutral, oldReading, newLeftSph, newLeftCyl, newLeftAx, newLeftAdd, newLeftVa, newLeftFh, newLeftPd2, newLeftPd, newRightSph, newRightCyl, newRightAx, newRightAdd, newRightVa, newRightFh, newRightPd2, newRightPd, newDistance, newNeutral, newReading, user, customer), entity => new Prescription(entity));
        }

        public DataObject<UserEntity, User> CreateUser(string name, DateTime birthday, string address, string phoneNumber, string signature, string username, string password, RoleEnum role)
        {
            return new DataObject<UserEntity, User>(() => user.Create(name, birthday, address, phoneNumber, signature, username, password, role), entity => new User(entity));
        }

        public DataObject<object, object> DeleteCustomer(Customer cus)
        {
            return new DataObject<object, object>(() =>
            {
                customer.Delete(cus);
                return null;
            }, o => null);
        }

        public DataObject<object, object> DeleteUser(User u)
        {
            return new DataObject<object, object>(() =>
            {
                user.Delete(u);
                return null;
            }, o => null);
        }

        public DataObject<List<CustomerEntity>, List<Customer>> FindCustomerByName(string key)
        {
            return new DataObject<List<CustomerEntity>, List<Customer>>(() => customer.FindByName(key), list => list.Select(entity => new Customer(entity)).ToList());
        }

        public DataObject<List<CustomerEntity>, List<Customer>> FindCustomerByPhoneNumber(string key)
        {
            return new DataObject<List<CustomerEntity>, List<Customer>>(() => customer.FindByPhoneNumber(key), list => list.Select(entity => new Customer(entity)).ToList());
        }

        public DataObject<List<PrescriptionEntity>, List<Prescription>> FindPrescriptionByKey(string key)
        {
            return new DataObject<List<PrescriptionEntity>, List<Prescription>>(() => prescription.FindByKey(key), list => list.Select(entity => new Prescription(entity)).ToList());
        }

        public DataObject<List<CustomerEntity>, List<Customer>> GetAllCustomer(Pageable<CustomerAttrEnum> pageable)
        {
            return new DataObject<List<CustomerEntity>, List<Customer>>(() => customer.GetAll(pageable), list => list.Select(entity => new Customer(entity)).ToList());
        }

        public DataObject<List<PrescriptionEntity>, List<Prescription>> GetAllPrescription(Customer cus)
        {
            return new DataObject<List<PrescriptionEntity>, List<Prescription>>(() => prescription.GetAll(cus), list => list.Select(entity => new Prescription(entity)).ToList());
        }

        public DataObject<List<UserEntity>, List<User>> GetAllUser()
        {
            return new DataObject<List<UserEntity>, List<User>>(() => user.GetAll(), list => list.Select(x => new User(x)).ToList());
        }

        public DataObject<PrescriptionEntity, Prescription> GetLastPrescription(Customer cus)
        {
            return new DataObject<PrescriptionEntity, Prescription>(() => prescription.GetLast(cus), entity => new Prescription(entity));
        }

        public DataObject<UserEntity, User> Login(string username, string password)
        {
            return new DataObject<UserEntity, User>(() => user.Login(username, password), entity => new User(entity));
        }

        public DataObject<List<StaPrescription>, List<StaPrescription>> StatisticPrescription(StatisticEnum type, DateTime fr, DateTime to)
        {
            return new DataObject<List<StaPrescription>, List<StaPrescription>>(() => prescription.Statistic(type, fr, to), list => list);
        }

        public DataObject<UserEntity, User> UpdateAccountInfo(User u, string username, string password)
        {
            return new DataObject<UserEntity, User>(() => user.UpdateAccountInfo(u, username, password), entity => new User(entity));
        }

        public DataObject<UserEntity, User> UpdateBasicInfo(User u, string name, DateTime birthday, string address, string phoneNumber, string signature, RoleEnum role)
        {
            return new DataObject<UserEntity, User>(() => user.UpdateBasicInfo(u, name, birthday, address, phoneNumber, signature, role), entity => new User(entity));
        }

        public DataObject<CustomerEntity, Customer> UpdateCustomer(Customer cus, string name, DateTime birthday, string address, string phoneNumber)
        {
            return new DataObject<CustomerEntity, Customer>(() => customer.Update(cus, name, birthday, address, phoneNumber), entity => new Customer(entity));
        }
    }
}