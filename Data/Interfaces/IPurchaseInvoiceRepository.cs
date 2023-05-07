using Data.Models;
using System.Collections.Generic;
using System.Data;

namespace Data.Interfaces
{
    public interface IPurchaseInvoiceRepository
    {
        PurchaseInvoice Add(PurchaseInvoice obj);
        bool AddPurchaseInvoiceDetails(List<PurchaseInvoiceDetail> purchaseDetails);
        bool DeletePurchaseInvoice(int purchaseId);
        bool DeletePurchaseInvoiceDetail(int purchaseId);
        void Dispose();
        List<PurchaseInvoice> GetAll();
        PurchaseInvoice Get(int purchaseId);
        PurchaseInvoice GetPurchaseInvoice(int purchaseID);
        DataSet List(int pageNo, int rowPerPage);
        PurchaseInvoice Update(PurchaseInvoice obj);
    }
}