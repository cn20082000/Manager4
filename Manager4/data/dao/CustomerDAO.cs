using Manager4.data.entity;
using Manager4.data.model;
using Manager4.util.enu;
using Manager4.util.ext;
using Manager4.util.obj;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager4.data.dao
{
    public class CustomerDAO : DAO, IDisposable
    {
        public CustomerEntity Get(Customer cus)
        {
            var customers = from customer
                            in db.Customers
                            where customer.Active == true && customer.Id == cus.Id
                            select customer;
            return customers.Single();
        }

        public List<CustomerEntity> GetAll()
        {
            var customers = from customer
                            in db.Customers
                            where customer.Active == true
                            select customer;
            return customers.ToList();
        }

        public List<CustomerEntity> GetAll(Pageable<CustomerAttrEnum> pageable)
        {
            var customers = from customer
                            in db.Customers
                            where customer.Active == true
                            select customer;
            Func<CustomerEntity, object> orderBy;
            switch (pageable.OrderBy)
            {
                case CustomerAttrEnum.NAME:
                    {
                        orderBy = x => x.Name;
                        break;
                    }
                case CustomerAttrEnum.BIRTHDAY:
                    {
                        orderBy = x => x.Birthday;
                        break;
                    }
                case CustomerAttrEnum.ADDRESS:
                    {
                        orderBy = x => x.Address;
                        break;
                    }
                case CustomerAttrEnum.PHONE_NUMBER:
                    {
                        orderBy = x => x.PhoneNumber;
                        break;
                    }
                default:
                    {
                        orderBy = x => x.Id;
                        break;
                    }
            }
            if (pageable.Ascending)
            {
                return customers.OrderBy(orderBy).Page(pageable.Page, pageable.PageSize).ToList();
            }
            return customers.OrderByDescending(orderBy).Page(pageable.Page, pageable.PageSize).ToList();
        }

        public List<CustomerEntity> FindByName(string key)
        {
            var customers = from customer
                            in db.Customers
                            where customer.Active == true && customer.Name.ToLower().Contains(key.ToLower())
                            select customer;
            return customers.OrderByDescending(x => x.Id).Page(1, 20).ToList();
        }

        public List<CustomerEntity> FindByPhoneNumber(string key)
        {
            var customers = from customer
                            in db.Customers
                            where customer.Active == true && customer.PhoneNumber.Contains(key)
                            select customer;
            return customers.OrderByDescending(x => x.Id).Page(1, 20).ToList();
        }

        public CustomerEntity Create(string name, DateTime birthday, string address, string phoneNumber)
        {
            CustomerEntity entity = new CustomerEntity();
            entity.Name = name;
            entity.Birthday = birthday;
            entity.Address = address;
            entity.PhoneNumber = phoneNumber;
            entity.Active = true;
            try
            {
                db.Customers.Add(entity);
                db.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                db.Customers.Remove(entity);
                throw;
            }
        }

        public CustomerEntity Update(Customer cus, string name, DateTime birthday, string address, string phoneNumber)
        {
            CustomerEntity entity = (from customer
                                     in db.Customers
                                     where customer.Active == true && customer.Id == cus.Id
                                     select customer).Single();
            entity.Name = name;
            entity.Birthday = birthday;
            entity.Address = address;
            entity.PhoneNumber = phoneNumber;
            entity.Active = true;
            try
            {
                db.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                db.Entry(entity).Reload();
                throw;
            }
        }

        public void Delete(Customer cus)
        {
            CustomerEntity cs = (from customer
                                 in db.Customers
                                 where customer.Active == true && customer.Id == cus.Id
                                 select customer).Single();
            cs.Active = false;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Entry(cs).Reload();
                throw;
            }
        }

        public void Dispose() { }
    }
}
