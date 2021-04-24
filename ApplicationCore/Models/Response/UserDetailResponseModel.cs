using System;
using System.Collections.Generic;

namespace ApplicationCore.Models.Response
{
    public class UserDetailResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }

        public List<IncomeResponseModel> Incomes { get; set; }
        public List<ExpenditureResponseModel> Expenditures { get; set; }

        public class IncomeResponseModel
        {
            public int Id { get; set; }
            public decimal? Amount { get; set; }
            public string Description { get; set; }
            public DateTime? IncomeDate { get; set; }
            public string Remarks { get; set; }
        }

        public class ExpenditureResponseModel
        {
            public int Id { get; set; }
            public decimal? Amount { get; set; }
            public string Description { get; set; }
            public DateTime? ExpDate { get; set; }
            public string Remarks { get; set; }
        }
    }
}