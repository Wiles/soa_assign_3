using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace soa_assign_3
{
    /// <summary>
    /// Summary description for VinniesLoanService
    /// </summary>
    [WebService(Namespace = "localhost/VinniesLoanService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Loan : System.Web.Services.WebService
    {
        [WebMethod]
        public float LoanPayment(float principleAmount, float interestRate, int numPayments)
        {
            double rate = interestRate / 12;
            //TODO ERROR HANDLING
            return (float)(rate + (rate / (Math.Pow(1.0f + rate, numPayments) - 1))) * principleAmount;
        }
    }
}
