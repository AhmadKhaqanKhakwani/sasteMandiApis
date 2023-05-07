using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISaleInvoicePaymentRepository
    {
        SaleInvoicePayment Add(SaleInvoicePayment obj);
        SaleInvoicePayment Update(SaleInvoicePayment obj);
        bool Delete(int id);
        void Dispose();
        SaleInvoicePayment Get(int id);
        List<SaleInvoicePayment> GetAll();
        DataSet List(int pageNo, int rowPerPage);
    }
}
