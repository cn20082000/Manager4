using Manager4.data.entity;
using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.obj;
using System;
using System.Collections.Generic;

namespace Manager4.data
{
    public interface IDataManager
    {
        DataObject<UserEntity, User> Login(string username, string password);
        DataObject<object, object> ChangePassword(User u, string oldPassword, string newPassword);
        DataObject<UserEntity, User> CreateUser(string name, DateTime birthday, string address, string phoneNumber,
            string signature, string username, string password, RoleEnum role);
        DataObject<List<UserEntity>, List<User>> GetAllUser();
        DataObject<UserEntity, User> UpdateBasicInfo(User u, string name, DateTime birthday, string address,
            string phoneNumber, string signature, RoleEnum role);
        DataObject<UserEntity, User> UpdateAccountInfo(User u, string username, string password);
        DataObject<object, object> DeleteUser(User u);
        DataObject<List<CustomerEntity>, List<Customer>> GetAllCustomer(Pageable<CustomerAttrEnum> pageable);
        DataObject<CustomerEntity, Customer> CreateCustomer(string name, DateTime birthday, string address, string phoneNumber);
        DataObject<CustomerEntity, Customer> UpdateCustomer(Customer cus, string name, DateTime birthday, string address, string phoneNumber);
        DataObject<object, object> DeleteCustomer(Customer cus);
        DataObject<List<CustomerEntity>, List<Customer>> FindCustomerByName(string key);
        DataObject<List<CustomerEntity>, List<Customer>> FindCustomerByPhoneNumber(string key);
        DataObject<PrescriptionEntity, Prescription> GetLastPrescription(Customer cus);
        DataObject<PrescriptionEntity, Prescription> CreatePrescription(EyewearEnum eyewear, string note, int reExam, float payment,
            float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd,
            float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd,
            bool newDistance, bool newNeutral, bool newReading, User user, Customer customer);
        DataObject<PrescriptionEntity, Prescription> CreatePrescription(EyewearEnum eyewear, string note, int reExam, float payment, Report oldReport,
            float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd,
            float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd,
            bool newDistance, bool newNeutral, bool newReading, User user, Customer customer);
        DataObject<PrescriptionEntity, Prescription> CreatePrescription(EyewearEnum eyewear, string note, int reExam, float payment,
            float oldLeftSph, float oldLeftCyl, int oldLeftAx, float oldLeftAdd, int oldLeftVa, int oldLeftFh, float oldLeftPd2, float oldLeftPd,
            float oldRightSph, float oldRightCyl, int oldRightAx, float oldRightAdd, int oldRightVa, int oldRightFh, float oldRightPd2, float oldRightPd,
            bool oldDistance, bool oldNeutral, bool oldReading,
            float newLeftSph, float newLeftCyl, int newLeftAx, float newLeftAdd, int newLeftVa, int newLeftFh, float newLeftPd2, float newLeftPd,
            float newRightSph, float newRightCyl, int newRightAx, float newRightAdd, int newRightVa, int newRightFh, float newRightPd2, float newRightPd,
            bool newDistance, bool newNeutral, bool newReading, User user, Customer customer);
        DataObject<List<PrescriptionEntity>, List<Prescription>> GetAllPrescription(Customer cus);
        DataObject<List<PrescriptionEntity>, List<Prescription>> FindPrescriptionByKey(string key);
        DataObject<List<StaPrescription>, List<StaPrescription>> StatisticPrescription(StatisticEnum type, DateTime fr, DateTime to);
    }
}
