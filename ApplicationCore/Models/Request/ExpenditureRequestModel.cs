using System;

namespace ApplicationCore.Models.Request
{
    public class ExpenditureRequestModel
    {
        public int UserId { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Remarks { get; set; }
    }
}