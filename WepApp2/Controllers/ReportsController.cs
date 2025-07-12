using Microsoft.AspNetCore.Mvc;
using WepApp2.Models;

namespace WepApp2.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult AllReports()
        {
            return View();
        }

        public IActionResult CreateCustomReport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateCustomReport(string ReportTitle, string ReportType, DateTime FromDate, DateTime ToDate, List<string> SelectedFields)
        {
            var fakeData = new List<DeviceReportViewModel>
            {
                new DeviceReportViewModel { Id = 1, DeviceName = "طابعة ثلاثية الأبعاد - 001", DeviceType = "طابعة ثلاثية الأبعاد", Status = "تشغيل" },
                new DeviceReportViewModel { Id = 2, DeviceName = "حاسوب محمول - 002", DeviceType = "حاسبات", Status = "صيانة" },
                new DeviceReportViewModel { Id = 3, DeviceName = "جهاز قياس - 003", DeviceType = "أجهزة قياس", Status = "تشغيل" },
                new DeviceReportViewModel { Id = 4, DeviceName = "طابعة ثلاثية الأبعاد - 004", DeviceType = "طابعة ثلاثية الأبعاد", Status = "خارج الخدمة" },
                new DeviceReportViewModel { Id = 5, DeviceName = "حاسوب مكتبي - 005", DeviceType = "حاسبات", Status = "تشغيل" }
            };

            ViewBag.ReportTitle = ReportTitle;
            ViewBag.ReportType = ReportType;
            ViewBag.FromDate = FromDate.ToString("yyyy-MM-dd");
            ViewBag.ToDate = ToDate.ToString("yyyy-MM-dd");

            return View("PrintReport", fakeData);
        }
    }
}