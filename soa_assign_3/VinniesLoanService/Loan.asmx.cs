/// Loan.asmx.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System;
    using System.Web.Services;

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
