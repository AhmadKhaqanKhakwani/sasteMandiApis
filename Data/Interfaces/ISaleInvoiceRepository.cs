using Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces
{
    public interface ISaleInvoiceRepository
    {
        SaleInvoice Add(SaleInvoice obj);
        bool AddSaleInvoiceDetails(List<SaleInvoiceDetail> saleDetails);
        bool DeleteSaleInvoice(int saleId);
        bool DeleteSaleInvoiceDetail(int saleId);
        void Dispose();
        List<SaleInvoice> GetAll();
        SaleInvoice Get(int saleId);
        SaleInvoice GetSaleInvoice(int saleID);
        DataSet List(int pageNo, int rowPerPage);
        SaleInvoice Update(SaleInvoice obj);
        DataSet InvoicesByParty(int id);

    }
}