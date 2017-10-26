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

            var employees = new Employee[]
            {
                new Employee {EmployeeNumber = "E2014001",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2014002",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2014003",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2015001",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2016001",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2017045",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2011034",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2012032",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"}
            };
            foreach(var i in employees)
            {
                context.employees.Add(i);
            }
            context.SaveChanges();


            var agencies = new Agency[]
            {
                new Agency{BanhchCode="MBHQ1", ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 1", Phonenumber="04123432", },
                new Agency{BanhchCode="MBHQ2", ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 2", Phonenumber="04123432"},
                new Agency{BanhchCode="MBHQ3", ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 3", Phonenumber="04123432"},
                new Agency{BanhchCode="MBHQ4", ConsultantName="Nguyễn Minh Hiếu",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 4", Phonenumber="04123432"}
            };

            foreach(var i in agencies)
            {
                context.agencies.Add(i);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{ Cmtnd="135847874", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn A" , CustomerCode="A2017001"},
                new Customer{ Cmtnd="1358478741", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn B",CustomerCode="A2017001"},
                new Customer{ Cmtnd="1358478742", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn C",CustomerCode="A2017001"},
                new Customer{ Cmtnd="1358478743", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn D",CustomerCode="A2017001"}
            };
            foreach(var i in customers)
            {
                context.customers.Add(i);
            }
            context.SaveChanges();
            var insurrances = new Insurrance[]
            {
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A001", CoverageRate="10%", EmployeeID = 1,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A002", CoverageRate="10%",EmployeeID = 2,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A003", CoverageRate="10%",EmployeeID = 3,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A004", CoverageRate="10%",EmployeeID = 4,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A005", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=1,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"}
            };
            foreach(var i in insurrances)
            {
                context.insurrances.Add(i);
            }
            context.SaveChanges();
        }
    }
}
