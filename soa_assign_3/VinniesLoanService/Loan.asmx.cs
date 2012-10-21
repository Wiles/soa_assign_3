﻿/// Loan.asmx.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System;
    using System.Configuration;
    using System.Web.Services;

    /// <summary>
    /// Summary description for VinniesLoanService
    /// </summary>
    [WebService(Namespace = "localhost/VinniesLoanService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Loan : System.Web.Services.WebService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Loan" /> class.
        /// </summary>
        public Loan()
        {
            this.Factory = new ExceptionFactory(
                ConfigurationManager.AppSettings["logPath"]);
        }

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        /// <value>
        /// The factory.
        /// </value>
        private ExceptionFactory Factory { get; set; }

        /// <summary>
        /// Calculates a monthly loan payment amount.
        /// </summary>
        /// <param name="principleAmount">The principle amount.</param>
        /// <param name="interestRate">The interest rate.</param>
        /// <param name="numPayments">The num payments.</param>
        /// <returns>The monthly payment amount.</returns>
        [WebMethod]
        public float LoanPayment(float principleAmount, float interestRate, int numPayments)
        {
            if (principleAmount <= 0)
            {
                throw this.Factory.Create(
                        Context.Request.Url.AbsoluteUri,
                        "Invalid principle amount.",
                        "The principle amount must be greater than zero.");
            }

            if (interestRate <= 0)
            {
                throw this.Factory.Create(
                        Context.Request.Url.AbsoluteUri,
                        "Invalid interest rate.",
                        "The interest rate must be greater than zero.");
            }

            if (numPayments <= 0)
            {
                throw this.Factory.Create(
                        Context.Request.Url.AbsoluteUri,
                        "Invalid number of payments.",
                        "The number of payments must be greater than zero.");
            }

            double rate = interestRate / 12;
            return (float)(rate + (rate / (Math.Pow(1.0f + rate, numPayments) - 1))) * principleAmount;
        }
    }
}
