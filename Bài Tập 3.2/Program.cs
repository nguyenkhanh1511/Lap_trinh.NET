using System;
using System.Collections.Generic;

namespace OOPExercises
{
    // ============================================================
    // BÀI TẬP 1: QUẢN LÝ TÀI KHOẢN NGÂN HÀNG
    // ============================================================

    public class BankAccount
    {
        // Static field: tự động tăng số tài khoản
        private static long _nextAccountNumber = 1000000001;

        // Backing field cho Balance
        private decimal _balance;

        // Số tài khoản chỉ được gán khi khởi tạo
        public long AccountNumber { get; init; }

        // Tên chủ tài khoản
        private string _accountHolder = string.Empty;

        public string AccountHolder
        {
            get => _accountHolder;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Tên chủ tài khoản không được để trống hoặc null."
                    );
                }

                _accountHolder = value;
            }
        }

        // Chỉ cho phép đọc Balance từ bên ngoài
        public decimal Balance => _balance;

        // Constructor
        public BankAccount(string accountHolder, decimal initialBalance)
        {
            if (initialBalance < 50000)
            {
                throw new ArgumentException(
                    "Số dư ban đầu phải >= 50.000 VNĐ."
                );
            }

            AccountNumber = _nextAccountNumber++;
            AccountHolder = accountHolder;
            _balance = initialBalance;
        }

        // Nạp tiền
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Số tiền nạp phải lớn hơn 0."
                );
            }

            _balance += amount;

            Console.WriteLine(
                $"Nạp thành công {amount:N0} VNĐ."
            );
        }

        // Rút tiền
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Số tiền rút phải lớn hơn 0."
                );
            }

            // Sau khi rút vẫn phải còn tối thiểu 50.000
            if (_balance - amount < 50000)
            {
                return false;
            }

            _balance -= amount;
            return true;
        }

        // Hiển thị thông tin
        public void DisplayInfo()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Số tài khoản : {AccountNumber}");
            Console.WriteLine($"Chủ tài khoản: {AccountHolder}");
            Console.WriteLine($"Số dư        : {Balance:N0} VNĐ");
            Console.WriteLine("-----------------------------------");
        }
    }


    // ============================================================
    // BÀI TẬP 2: HỆ THỐNG PHÂN CẤP NHÂN VIÊN
    // ============================================================

    public class Person
    {
        public string Id { get; init; }
        public string FullName { get; set; }
        public int BirthYear { get; set; }

        public Person(string id, string fullName, int birthYear)
        {
            Id = id;
            FullName = fullName;
            BirthYear = birthYear;
        }

        public int GetAge(int currentYear)
        {
            return currentYear - BirthYear;
        }
    }


    public class Employee : Person
    {
        public decimal BaseSalary { get; set; }

        public Employee(
            string id,
            string fullName,
            int birthYear,
            decimal baseSalary
        ) : base(id, fullName, birthYear)
        {
            BaseSalary = baseSalary;
        }

        public virtual decimal CalculateIncome()
        {
            return BaseSalary;
        }
    }


    // sealed: không cho phép lớp khác kế thừa từ Manager
    public sealed class Manager : Employee
    {
        public decimal ResponsibilityAllowance { get; set; }

        public Manager(
            string id,
            string fullName,
            int birthYear,
            decimal baseSalary,
            decimal allowance
        ) : base(id, fullName, birthYear, baseSalary)
        {
            ResponsibilityAllowance = allowance;
        }

        public override decimal CalculateIncome()
        {
            return BaseSalary + ResponsibilityAllowance;
        }
    }

    

    // ============================================================
    // BÀI TẬP 3: ĐA HÌNH - OVERLOADING & OVERRIDING
    // ============================================================

    public static class DiscountCalculator
    {
        public static decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount * 0.95m;
        }

        
        public static decimal ApplyDiscount(
            decimal totalAmount,
            double percentage
        )
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentException(
                    "Phần trăm giảm phải từ 0 đến 100."
                );
            }

            return totalAmount *
                   (1 - (decimal)percentage / 100);
        }

        
        public static decimal ApplyDiscount(
            decimal totalAmount,
            decimal fixedVoucher,
            decimal minimumOrder
        )
        {
            if (fixedVoucher < 0)
            {
                throw new ArgumentException(
                    "Giá trị voucher không được âm."
                );
            }

            if (totalAmount >= minimumOrder)
            {
                return Math.Max(0, totalAmount - fixedVoucher);
            }

            return totalAmount;
        }
    }


    
    public class DeliveryService
    {
        public string OrderId { get; set; }
        public double DistanceKm { get; set; }

        public DeliveryService(
            string orderId,
            double distanceKm
        )
        {
            OrderId = orderId;
            DistanceKm = distanceKm;
        }

       
        public virtual decimal CalculateShippingFee()
        {
            return (decimal)(DistanceKm * 5000);
        }
    }


   
    public class ExpressDelivery : DeliveryService
    {
        public ExpressDelivery(
            string orderId,
            double distanceKm
        ) : base(orderId, distanceKm)
        {
        }

        public override decimal CalculateShippingFee()
        {
            decimal basicFee =
                (decimal)(DistanceKm * 5000);

            return basicFee * 1.5m + 20000;
        }
    }


    
    public class EcoDelivery : DeliveryService
    {
        public EcoDelivery(
            string orderId,
            double distanceKm
        ) : base(orderId, distanceKm)
        {
        }

        public override decimal CalculateShippingFee()
        {
            decimal basicFee =
                (decimal)(DistanceKm * 5000);

            if (DistanceKm > 10)
            {
                return basicFee * 0.9m;
            }

            return basicFee;
        }
    }


    // ============================================================
    // BÀI TẬP 4: CỔNG THANH TOÁN ĐA PHƯƠNG THỨC
    // ============================================================

    
    public interface IPayable
    {
        bool ProcessPayment(decimal amount);
    }


    
    public interface IRefundable
    {
        bool ProcessRefund(decimal amount, string reason);
    }


    
    public abstract class PaymentGateway
    {
        public string TransactionId { get; init; }

        public DateTime CreationDate { get; init; }

        public string Status { get; protected set; }

        protected PaymentGateway(string transactionId)
        {
            TransactionId = transactionId;
            CreationDate = DateTime.Now;
            Status = "Pending";
        }

        public abstract void ValidateConnection();

        public virtual void LogTransaction(string message)
        {
            Console.WriteLine(
                $"[Transaction: {TransactionId}] {message}"
            );
        }
    }


    
    public class MomoPayment :
        PaymentGateway,
        IPayable,
        IRefundable
    {
        public string PhoneNumber { get; set; }

        public MomoPayment(
            string transactionId,
            string phoneNumber
        ) : base(transactionId)
        {
            PhoneNumber = phoneNumber;
        }

        
        public override void ValidateConnection()
        {
            Console.WriteLine(
                "Đang kiểm tra kết nối API MoMo..."
            );

            Console.WriteLine(
                "Kết nối API MoMo thành công."
            );
        }

        
        public bool ProcessPayment(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(
                    "Thanh toán thất bại: số tiền không hợp lệ."
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                Console.WriteLine(
                    "Thanh toán thất bại: số điện thoại không hợp lệ."
                );

                return false;
            }

            Status = "Success";

            LogTransaction(
                $"Thanh toán {amount:N0} VNĐ thành công."
            );

            return true;
        }

        
        public bool ProcessRefund(
            decimal amount,
            string reason
        )
        {
            if (amount <= 0)
            {
                Console.WriteLine(
                    "Hoàn tiền thất bại: số tiền không hợp lệ."
                );

                return false;
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                Console.WriteLine(
                    "Hoàn tiền thất bại: lý do không hợp lệ."
                );

                return false;
            }

            Status = "Refunded";

            LogTransaction(
                $"Hoàn tiền {amount:N0} VNĐ. " +
                $"Lý do: {reason}"
            );

            return true;
        }
    }


    // ============================================================
    // PROGRAM
    // ============================================================

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =
                System.Text.Encoding.UTF8;

            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("        CHƯƠNG TRÌNH BÀI TẬP OOP");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Quản lý tài khoản ngân hàng");
                Console.WriteLine("2. Hệ thống phân cấp nhân viên");
                Console.WriteLine("3. Đa hình - Overloading & Overriding");
                Console.WriteLine("4. Cổng thanh toán đa phương thức");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("======================================");

                Console.Write("Nhập lựa chọn: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    choice = -1;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        RunExercise1();
                        break;

                    case 2:
                        RunExercise2();
                        break;

                    case 3:
                        RunExercise3();
                        break;

                    case 4:
                        RunExercise4();
                        break;

                    case 0:
                        Console.WriteLine(
                            "Đã thoát chương trình."
                        );
                        break;

                    default:
                        Console.WriteLine(
                            "Lựa chọn không hợp lệ!"
                        );
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "Nhấn phím bất kỳ để quay lại Menu..."
                    );
                    Console.ReadKey();
                }

            } while (choice != 0);
        }


        // ========================================================
        // CHẠY BÀI 1
        // ========================================================

        static void RunExercise1()
        {
            Console.WriteLine(
                "========== BÀI TẬP 1 =========="
            );
            Console.WriteLine(
                "QUẢN LÝ TÀI KHOẢN NGÂN HÀNG"
            );
            Console.WriteLine();

            try
            {
                
                BankAccount account1 =
                    new BankAccount(
                        "Nguyen Van An",
                        1000000
                    );

                
                BankAccount account2 =
                    new BankAccount(
                        "Tran Thi Binh",
                        2000000
                    );

                Console.WriteLine("2 tài khoản hợp lệ:");
                account1.DisplayInfo();
                account2.DisplayInfo();

                Console.WriteLine();
                Console.WriteLine(
                    "--- Kiểm tra tài khoản không hợp lệ ---"
                );

                try
                {
                    BankAccount invalidAccount =
                        new BankAccount(
                            "Le Van C",
                            30000
                        );
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                        $"Bắt lỗi thành công: {ex.Message}"
                    );
                }

                Console.WriteLine();
                Console.WriteLine(
                    "--- Thao tác trên tài khoản 1 ---"
                );

                account1.Deposit(500000);

                account1.DisplayInfo();

                bool withdrawResult =
                    account1.Withdraw(300000);

                Console.WriteLine(
                    $"Rút 300.000 VNĐ: " +
                    $"{(withdrawResult ? "Thành công" : "Thất bại")}"
                );

                account1.DisplayInfo();

                Console.WriteLine();
                Console.WriteLine(
                    "--- Thử rút vượt quá hạn mức ---"
                );

                withdrawResult =
                    account1.Withdraw(2000000);

                Console.WriteLine(
                    $"Rút 2.000.000 VNĐ: " +
                    $"{(withdrawResult ? "Thành công" : "Thất bại")}"
                );

                account1.DisplayInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Lỗi: {ex.Message}"
                );
            }
        }


        // ========================================================
        // CHẠY BÀI 2
        // ========================================================

        static void RunExercise2()
        {
            Console.WriteLine(
                "========== BÀI TẬP 2 =========="
            );
            Console.WriteLine(
                "HỆ THỐNG PHÂN CẤP NHÂN VIÊN"
            );
            Console.WriteLine();

            int currentYear = DateTime.Now.Year;

            Employee employee =
                new Employee(
                    "NV001",
                    "Nguyen Van An",
                    2000,
                    12000000
                );

            Manager manager =
                new Manager(
                    "QL001",
                    "Tran Thi Binh",
                    1995,
                    20000000,
                    5000000
                );

           
            Console.WriteLine("----- PHIẾU LƯƠNG EMPLOYEE -----");
            Console.WriteLine(
                $"Tên: {employee.FullName}"
            );
            Console.WriteLine(
                $"Tuổi: {employee.GetAge(currentYear)}"
            );
            Console.WriteLine(
                $"Lương cơ bản: {employee.BaseSalary:N0} VNĐ"
            );
            Console.WriteLine(
                $"Thu nhập: {employee.CalculateIncome():N0} VNĐ"
            );

            Console.WriteLine();

          
            Console.WriteLine("----- PHIẾU LƯƠNG MANAGER -----");
            Console.WriteLine(
                $"Tên: {manager.FullName}"
            );
            Console.WriteLine(
                $"Tuổi: {manager.GetAge(currentYear)}"
            );
            Console.WriteLine(
                $"Lương cơ bản: {manager.BaseSalary:N0} VNĐ"
            );
            Console.WriteLine(
                $"Phụ cấp trách nhiệm: " +
                $"{manager.ResponsibilityAllowance:N0} VNĐ"
            );
            Console.WriteLine(
                $"Thu nhập: {manager.CalculateIncome():N0} VNĐ"
            );

            Console.WriteLine();
            Console.WriteLine(
                "Manager được đánh dấu sealed nên không thể "
                + "có lớp khác kế thừa từ Manager."
            );
        }


        // ========================================================
        // CHẠY BÀI 3
        // ========================================================

        static void RunExercise3()
        {
            Console.WriteLine(
                "========== BÀI TẬP 3 =========="
            );
            Console.WriteLine(
                "ĐA HÌNH - OVERLOADING & OVERRIDING"
            );
            Console.WriteLine();

            decimal totalAmount = 1000000;

           
            decimal result1 =
                DiscountCalculator.ApplyDiscount(
                    totalAmount
                );

            Console.WriteLine(
                "1. Giảm mặc định 5%:"
            );
            Console.WriteLine(
                $"   Ban đầu: {totalAmount:N0} VNĐ"
            );
            Console.WriteLine(
                $"   Sau giảm: {result1:N0} VNĐ"
            );

            Console.WriteLine();

         
            decimal result2 =
                DiscountCalculator.ApplyDiscount(
                    totalAmount,
                    10
                );

            Console.WriteLine(
                "2. Giảm 10%:"
            );
            Console.WriteLine(
                $"   Ban đầu: {totalAmount:N0} VNĐ"
            );
            Console.WriteLine(
                $"   Sau giảm: {result2:N0} VNĐ"
            );

            Console.WriteLine();

            
            decimal result3 =
                DiscountCalculator.ApplyDiscount(
                    totalAmount,
                    100000,
                    500000
                );

            Console.WriteLine(
                "3. Voucher 100.000 VNĐ:"
            );
            Console.WriteLine(
                $"   Ban đầu: {totalAmount:N0} VNĐ"
            );
            Console.WriteLine(
                $"   Sau giảm: {result3:N0} VNĐ"
            );

            Console.WriteLine();
            Console.WriteLine(
                "========== RUNTIME POLYMORPHISM =========="
            );

       
            List<DeliveryService> deliveries =
                new List<DeliveryService>
                {
                    new ExpressDelivery(
                        "ORD001",
                        5
                    ),

                    new EcoDelivery(
                        "ORD002",
                        8
                    ),

                    new EcoDelivery(
                        "ORD003",
                        15
                    )
                };

            foreach (DeliveryService delivery in deliveries)
            {
                Console.WriteLine(
                    $"Mã đơn: {delivery.OrderId}"
                );

                Console.WriteLine(
                    $"Loại: {delivery.GetType().Name}"
                );

                Console.WriteLine(
                    $"Khoảng cách: {delivery.DistanceKm} km"
                );

                Console.WriteLine(
                    $"Phí vận chuyển: " +
                    $"{delivery.CalculateShippingFee():N0} VNĐ"
                );

                Console.WriteLine();
            }

            Console.WriteLine(
                "Các đối tượng đều được lưu dưới kiểu " +
                "DeliveryService nhưng khi gọi CalculateShippingFee(), "
                + "C# thực hiện đúng phiên bản override của lớp con."
            );
        }


        // ========================================================
        // CHẠY BÀI 4
        // ========================================================

        static void RunExercise4()
        {
            Console.WriteLine(
                "========== BÀI TẬP 4 =========="
            );
            Console.WriteLine(
                "CỔNG THANH TOÁN ĐA PHƯƠNG THỨC"
            );
            Console.WriteLine();

            MomoPayment momo =
                new MomoPayment(
                    "TXN20260909001",
                    "0987654321"
                );

            Console.WriteLine(
                $"Mã giao dịch: {momo.TransactionId}"
            );

            Console.WriteLine(
                $"Ngày tạo: {momo.CreationDate}"
            );

            Console.WriteLine(
                $"Trạng thái ban đầu: {momo.Status}"
            );

            Console.WriteLine();

            momo.ValidateConnection();

            Console.WriteLine();

            IPayable payable = momo;

            Console.WriteLine(
                "--- THỰC HIỆN THANH TOÁN ---"
            );

            bool paymentResult =
                payable.ProcessPayment(500000);

            Console.WriteLine(
                $"Kết quả: " +
                $"{(paymentResult ? "Thành công" : "Thất bại")}"
            );

            Console.WriteLine(
                $"Trạng thái: {momo.Status}"
            );

            Console.WriteLine();

            IRefundable refundable = momo;

            Console.WriteLine(
                "--- THỰC HIỆN HOÀN TIỀN ---"
            );

            bool refundResult =
                refundable.ProcessRefund(
                    500000,
                    "Khách hàng yêu cầu hoàn tiền"
                );

            Console.WriteLine(
                $"Kết quả: " +
                $"{(refundResult ? "Thành công" : "Thất bại")}"
            );

            Console.WriteLine(
                $"Trạng thái: {momo.Status}"
            );

            Console.WriteLine();
            Console.WriteLine(
                "MomoPayment triển khai đồng thời "
                + "IPayable và IRefundable."
            );
        }
    }
}