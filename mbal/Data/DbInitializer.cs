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
                 new User{ username="thanhvt", password="1",fullname="Vũ Tiến Thành",role="staff"},
                  new User{username="chungpd", password="1",fullname="Phạm Đức Chung",role="em"}
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
                   new Product{ProductName="sản phấm số 4", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 5", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 6", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 7", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 8", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 9", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 10", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 11", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 12", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 13", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 14", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1},
                   new Product{ProductName="sản phấm số 15", ProductCode="A004",ProductStatus="1",Money="100000",PayMethod=1}
            };
            foreach(var i in products)
            {
                context.products.Add(i);
            }
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee {EmployeeNumber = "E2014001",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh A", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2014002",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh B", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2014003",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh C", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2015001",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh D", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2016001",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh E", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2017045",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh F", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2011034",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh G", PhoneNumber="0123456798"},
                new Employee {EmployeeNumber = "E2012032",Dob = DateTime.Parse("1996-12-18"), Address="Hà Nội", Email="abc@123", Fullname="Nguyễn Minh H", PhoneNumber="0123456798"}
            };
            foreach(var i in employees)
            {
                context.employees.Add(i);
            }
            context.SaveChanges();


            var agencies = new Agency[]
            {
                new Agency{BanhchCode="MBHQ1", ConsultantName="Nguyễn Minh Hiếu A",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 1", Phonenumber="04123432", },
                new Agency{BanhchCode="MBHQ2", ConsultantName="Vũ Tiến Thành A",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 2", Phonenumber="04123432"},
                new Agency{BanhchCode="MBHQ3", ConsultantName="Phạm Đức Chung A",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 3", Phonenumber="04123432"},
                new Agency{BanhchCode="MBHQ4", ConsultantName="Nguyễn Mạnh Cường A",  Address="Hà Nội", Name="chi nhánh Cầu Giấy 4", Phonenumber="04123432"}
            };

            foreach(var i in agencies)
            {
                context.agencies.Add(i);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{ Cmtnd="135847874", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn A" , CustomerCode="A2017001",CreateAt=DateTime.Parse("1996-12-18")},
                new Customer{ Cmtnd="1358478741", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn B",CustomerCode="A2017002",CreateAt=DateTime.Parse("1996-12-18")},
                new Customer{ Cmtnd="1358478742", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nữ",FullName="Nguyễn Thị C",CustomerCode="A2017003",CreateAt=DateTime.Now},
                new Customer{ Cmtnd="1358478743", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn D",CustomerCode="A2017004",CreateAt=DateTime.Now},
                new Customer{ Cmtnd="1358478744", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn E",CustomerCode="A2017005",CreateAt=DateTime.Now},
                 new Customer{ Cmtnd="1358478745", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn F",CustomerCode="A2017006",CreateAt=DateTime.Now},
                  new Customer{ Cmtnd="1358478746", Dob= DateTime.Now, Phonenumber="0978963262", Sex="Nam",FullName="Nguyễn Văn G",CustomerCode="A2017007",CreateAt=DateTime.Now}
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
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=2,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A003", CoverageRate="10%",EmployeeID = 3,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=2,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A004", CoverageRate="10%",EmployeeID = 4,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=3,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A005", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=3,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A006", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=4,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A007", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=4,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A008", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=4,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A009", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=5,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A010", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=5,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A011", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=5,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"},
                new Insurrance{ BanhchCode="MBHQ1",ContractNumber="A012", CoverageRate="10%",EmployeeID = 5,description="Các sản phẩm bảo hiểm được thiết kế riêng biệt theo từng nhu cầu khách hàng trong từng giai đoạn cuộc đời. Không chỉ hướng tới mục tiêu bảo vệ Quý khách và những người thân yêu trước rủi ro của cuộc sống, các kế hoạch bảo hiểm còn giúp Quý khách thực hiện được các kế hoạch tài chính cho cá nhân và gia đình, đảm bảo nguồn tài chính vững vàng cho tương lai.",
                    Create_at = DateTime.Now, Create_by="hieunm",CustomerID=6,DurationOfInsurrance=3,ProductID=1,FormOfPayment=1,StatusContract="Đang hiệu lực",StatusFee="Đã thanh toán"}
            };
            foreach(var i in insurrances)
            {
                context.insurrances.Add(i);
            }
            context.SaveChanges();

            context.SaveChanges();
            var payments = new Payment[]
            {
                new Payment{AmountPayment=100, CustomerCode ="A2017001",InsurranceId=1,CreateAt=DateTime.Now},
                new Payment{AmountPayment=100, CustomerCode ="A2017001",InsurranceId=1,CreateAt=DateTime.Now},
                new Payment{AmountPayment=100, CustomerCode ="A2017002",InsurranceId=2,CreateAt=DateTime.Now},
                new Payment{AmountPayment=100, CustomerCode ="A2017002",InsurranceId=2,CreateAt=DateTime.Now},
                new Payment{AmountPayment=100, CustomerCode ="A2017002",InsurranceId=2,CreateAt=DateTime.Now},
            };
            foreach (var i in payments)
            {
                context.payments.Add(i);
            }
            context.SaveChanges();

            var compensation = new Compensation[]
            {
                new Compensation{AcceptCompensation=1,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017001",InsurranceId=1},
                new Compensation{AcceptCompensation=1,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017001",InsurranceId=1},
                new Compensation{AcceptCompensation=1,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017002",InsurranceId=2},
                new Compensation{AcceptCompensation=1,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017002",InsurranceId=2},
                new Compensation{AcceptCompensation=1,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017003",InsurranceId=3},
                new Compensation{AcceptCompensation=1,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017003",InsurranceId=3},
                new Compensation{AcceptCompensation=0,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017003",InsurranceId=3},
                new Compensation{AcceptCompensation=0,CompensationDate=DateTime.Parse("2016-12-18"),CompensationMoney=(float)101.1,DateOfCompensation=DateTime.Now,Reason="bồi thường thiệt hại",CustomerCode="A2017003",InsurranceId=3},
            };

            foreach (var i in compensation)
            {
                context.compensations.Add(i);
            }
            context.SaveChanges();
        }
    }
}
