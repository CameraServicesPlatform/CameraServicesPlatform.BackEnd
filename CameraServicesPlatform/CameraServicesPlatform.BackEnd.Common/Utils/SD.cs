using System.Globalization;

namespace CameraServicesPlatform.BackEnd.Common.Utils;
public class SD
{
    public static int MAX_RECORD_PER_PAGE = short.MaxValue;
    public static string DEFAULT_PASSWORD = "Member@123";
    public class DefaultAccountInformation
    {
        public static string PASSWORD = "Staff123@";
    }

    public class RoleConvert
    {
        public static string ADMIN = "ADMIN";
        public static string MEMBER = "MEMBER";
        public static string STAFF = "STAFF";
        public static string SUPPLIER = "SUPPLIER";

    }


    public static string FormatDateTime(DateTime dateTime)
    {
        return dateTime.ToString("dd/MM/yyyy");
    }
    public static string GenerateOTP(int length = 6)
    {
        // Sử dụng thư viện Random để tạo mã ngẫu nhiên
        Random random = new Random();

        // Tạo chuỗi ngẫu nhiên với độ dài mong muốn
        string otp = "";
        for (int i = 0; i < length; i++)
        {
            otp += random.Next(0, 10); // Sinh số ngẫu nhiên từ 0 đến 9 và thêm vào chuỗi OTP
        }

        return otp;
    }
    public static IEnumerable<WeekForYear> PrintWeeksForYear(int year)
    {
        var weekForYears = new List<WeekForYear>();
        var startDate = new DateTime(year, 1, 1);
        var endDate = startDate.AddDays(6);

        var cultureInfo = CultureInfo.CurrentCulture;

        Console.WriteLine($"Week 1: {startDate.ToString("d", cultureInfo)} - {endDate.ToString("d", cultureInfo)}");
        weekForYears.Add(new WeekForYear
        {
            WeekIndex = 1,
            Timeline = new WeekForYear.TimelineDto
            { StartDate = startDate.ToString("d", cultureInfo), EndDate = endDate.ToString("d", cultureInfo) }
        });

        for (var week = 2; week < 53; week++)
        {
            startDate = endDate.AddDays(1);
            endDate = startDate.AddDays(6);

            Console.WriteLine(
                $"Week {week}: {startDate.ToString("d", cultureInfo)} - {endDate.ToString("d", cultureInfo)}");
            weekForYears.Add(new WeekForYear
            {
                WeekIndex = week,
                Timeline = new WeekForYear.TimelineDto
                { StartDate = startDate.ToString("d", cultureInfo), EndDate = endDate.ToString("d", cultureInfo) }
            });
        }

        return weekForYears;
    }

    public class ResponseMessage
    {
        public static string CREATE_SUCCESSFULLY = "Tạo mới thành công";
        public static string UPDATE_SUCCESSFULLY = "Cập nhật thành công";
        public static string DELETE_SUCCESSFULY = "Xóa thành công";
        public static string CREATE_FAILED = "Có lỗi xảy ra trong quá trình tạo";
        public static string UPDATE_FAILED = "Có lỗi xảy ra trong quá trình cập nhật";
        public static string DELETE_FAILED = "Có lỗi xảy ra trong quá trình xóa";
        public static string LOGIN_FAILED = "Đăng nhập thất bại";
    }

    public class SubjectMail
    {
        public static string VERIFY_ACCOUNT = "[CAMERASERVICEPLATFORM]  CHÀO MỪNG BẠN ĐẾN VỚI CAMERASERVICEPLATFORM. VUI LÒNG XÁC MINH TÀI KHOẢN";
        public static string WELCOME = "[CAMERASERVICEPLATFORM] CHÀO MỪNG BẠN ĐẾN VỚI CAMERASERVICEPLATFORM";
        public static string REMIND_PAYMENT = "[CAMERASERVICEPLATFORM] NHẮC NHỞ THANH TOÁN";
        public static string PASSCODE_FORGOT_PASSWORD = "[CAMERASERVICEPLATFORM] MÃ XÁC THỰC QUÊN MẬT KHẨU";

        public static string SIGN_CONTRACT_VERIFICATION_CODE =
            "[LOVE HOUSE] You are in the process of completing contract procedures".ToUpper();
    }

    public class WeekForYear
    {
        public int WeekIndex { get; set; }
        public TimelineDto? Timeline { get; set; }

        public class TimelineDto
        {
            public string? StartDate { get; set; }
            public string? EndDate { get; set; }
        }
    }

    public class Regex
    {
        public static string PHONENUMBER = "^0\\d{9,10}$";
        public static string EMAIL = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
        public static string NAME = "^[\\p{L}\\s,'.-]+$";
        public static string CHASSISNUMBER = "^[A-HJ-NPR-Z0-9]{12,17}$";
        public static string ENGINENUMBER = "^[A-Za-z0-9]{6,17}$";
        public static string PLATE = "^(?!13)[0-9]{2}[A-Z]{1}[A-Z0-9]{0,1}-[0-9]{4,5}$";

    }

    public class CommonInformation
    {

    }
    public class EnumType
    {


    }

    public class ConfigName
    {
        //  public static string CONFIG_NAME = "Chênh lệch ";
    }


    public class ExcelHeaders
    {


    }
    public class FirebasePathName
    {
        public static string SUPPLIER_PREFIX = "supplier/";
        public static string NEWS_PREFIX = "news/";
        public static string BLOG_PREFIX = "blog/";
        public static string SAMPLE_HOUSE_PREFIX = "sample-house/";
        public static string STAFF_PREFIX = "staff/";
        public static string QR_PREFIX = "qr/";
        public static string EVENT = "event/";
        public static string SPEAKER = "speaker/";
    }

}

