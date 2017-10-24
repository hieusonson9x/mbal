using mbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Data
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();
            if (context.insurrances.Any())
            {
                return;   // DB has been seeded
            }
            var users = new User[]
            {
                new User{ username="hieunm", password="1",fullname="Nguyễn Minh Hiếu",role="admin"},
                 new User{ username="thanhvt", password="1",fullname="Nguyễn Minh Hiếu",role="staff"},
                  new User{username="user", password="1",fullname="Nguyễn Minh Hiếu",role="em"}
            };
            foreach(var i in users)
            {
                context.users.Add(i);
            }
            context.SaveChanges();
            var products = new Product[] {
                new Product{ProductName="sản phấm số 1", ProductCode="A001",ProductStatus="1",Money="100000",PayMethod=1},
                 new Product{ProductName="sản phấm số 2", ProductCode="A002",ProductStatus="1",Money="100000",PayMethod=1},
                  new Product{ProductName="sản phấm số 3", ProductCode="A003",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 4", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1}
            };
            foreach(var i in products)
            {
                context.products.Add(i);
            }
            context.SaveChanges();

            var agencies = new Agency[]
            {
                new Agency{ ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 1", Phonenumber="04123432", },
                new Agency{ ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 2", Phonenumber="04123432"},
                new Agency{ ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 3", Phonenumber="04123432"},
                new Agency{ ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 4", Phonenumber="04123432"}
            };

            foreach(var i in agencies)
            {
                context.agencies.Add(i);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{ Cmtnd="135847874", Dob= new DateTime(), Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn A"},
                new Customer{ Cmtnd="1358478741", Dob= new DateTime(), Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn B"},
                new Customer{ Cmtnd="1358478742", Dob= new DateTime(), Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn C"},
                new Customer{ Cmtnd="1358478743", Dob= new DateTime(), Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn D"}
            };
            foreach(var i in customers)
            {
                context.customers.Add(i);
            }
            context.SaveChanges();
            var insurrances = new Insurrance[]
            {
                new Insurrance{ BanhchCode="1",ContractNumber="A001", CoverageRate="10%",
                    Create_at = new DateTime(), Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="1",ContractNumber="A002", CoverageRate="10%",
                    Create_at = new DateTime(), Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="1",ContractNumber="A003", CoverageRate="10%",
                    Create_at = new DateTime(), Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="1",ContractNumber="A004", CoverageRate="10%",
                    Create_at = new DateTime(), Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="1",ContractNumber="A005", CoverageRate="10%",
                    Create_at = new DateTime(), Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"}
            };
            foreach(var i in insurrances)
            {
                context.insurrances.Add(i);
            }
            context.SaveChanges();
        }
    }
}
