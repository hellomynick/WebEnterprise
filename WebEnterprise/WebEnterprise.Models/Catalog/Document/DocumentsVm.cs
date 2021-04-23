using System;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsVm
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public Guid UserID { get; set; }
        public string DocumentPath { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public string Caption { get; set; }
        public int ViewCount { get; set; }
        public int TotalTrue { get; set; }
        public int TotalFalse { get; set; }
        public int TotalIT { get; set; }
        public int TotalITTrue { get; set; }
        public int TotalITFalse { get; set; }
        public int TotalToursim { get; set; }
        public int TotalToursimTrue { get; set; }
        public int TotalToursimFalse { get; set; }
        public int TotalDesign { get; set; }
        public int TotalDesignTrue { get; set; }
        public int TotalDesignFalse { get; set; }
        public int TotalMarketing { get; set; }
        public int TotalMarketingTrue { get; set; }
        public int TotalMarketingFalse { get; set; }
        public int TotalBusiness { get; set; }
        public int TotalBusinessTrue { get; set; }
        public int TotalBusinessFalse { get; set; }
        public DateTime Daynow { get; set; }
        public long FileSize { get; set; }
        public DateTime CreateOn { set; get; }
        public DateTime StartDay { set; get; }
        public DateTime EndDay { set; get; }
    }
}