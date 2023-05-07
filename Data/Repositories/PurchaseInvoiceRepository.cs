using Data.DataContext;
using Data.Interfaces;
using Data.Models;
using Data.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PurchaseInvoiceRepository : IDisposable, IPurchaseInvoiceRepository
    {
        public PurchaseInvoice Add(PurchaseInvoice obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.PurchaseInvoices.Add(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public PurchaseInvoice Update(PurchaseInvoice obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.PurchaseInvoices.Update(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool DeletePurchaseInvoice(int purchaseId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var purchaseInvoice = _context.PurchaseInvoices.Find(purchaseId);
                    var purchaseInvoiceDetails = _context.PurchaseInvoiceDetails.Where(x => x.PurchaseInvoiceId == purchaseId).ToList();
                    _context.PurchaseInvoiceDetails.RemoveRange(purchaseInvoiceDetails);
                    _context.PurchaseInvoices.Remove(purchaseInvoice);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public List<PurchaseInvoice> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var result = _context.PurchaseInvoices.Include(u => u.PurchaseInvoiceDetails).ToList();
                    if (result != null && result.Count > 0)
                    {
                        foreach (var child in result)
                        {
                            if (child.PurchaseInvoiceDetails.Count > 0)
                            {
                                foreach (var data in child.PurchaseInvoiceDetails)
                                {
                                    data.PurchaseInvoice = null;
                                }
                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public PurchaseInvoice Get(int purchaseId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var purchaseInvoice = _context.PurchaseInvoices.Include(u => u.PurchaseInvoiceDetails).FirstOrDefault(u => u.Id == purchaseId);
                    if (purchaseInvoice != null && purchaseInvoice.PurchaseInvoiceDetails != null && purchaseInvoice.Id > 0)
                    {
                        foreach (var child in purchaseInvoice.PurchaseInvoiceDetails.ToList())
                        {
                            child.PurchaseInvoice = null;

                        }
                    }
                    return purchaseInvoice;

                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public PurchaseInvoice GetPurchaseInvoice(int purchaseID)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.PurchaseInvoices.Find(purchaseID);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AddPurchaseInvoiceDetails(List<PurchaseInvoiceDetail> purchaseDetails)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.AddRange(purchaseDetails);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeletePurchaseInvoiceDetail(int purchaseId)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    var purchaseInvoiceDetails = _context.PurchaseInvoiceDetails.Where(x => x.PurchaseInvoiceId == purchaseId).ToList();
                    _context.PurchaseInvoiceDetails.RemoveRange(purchaseInvoiceDetails);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public DataSet List(int pageNo, int rowPerPage)
        {
            DataSet ds = new DataSet("PurchaseInvoice");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_GetPurchaseInvoiceList", conn);
                    sqlComm.Parameters.AddWithValue("@PageNumber", pageNo);
                    sqlComm.Parameters.AddWithValue("@RowspPage", rowPerPage);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

 
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
