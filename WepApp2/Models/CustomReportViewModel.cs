namespace WepApp2.Models
{
    public class CustomReportViewModel
    {
        public string ReportTitle { get; set; }
        public string ReportType { get; set; }
        public string ServiceType { get; set; }
        public List<string> Fields { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
    
