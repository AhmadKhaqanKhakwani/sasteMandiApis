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
    public class SaleInvoiceRepository : IDisposable, ISaleInvoiceRepository
    {
        public SaleInvoice Add(SaleInvoice obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SaleInvoices.Add(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SaleInvoice Update(SaleInvoice obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SaleInvoices.Update(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool DeleteSaleInvoice(int saleId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var saleInvoice = _context.SaleInvoices.Find(saleId);
                    var saleInvoiceDetails = _context.SaleInvoiceDetails.Where(x => x.SaleInvoiceId == saleId).ToList();
                    _context.SaleInvoiceDetails.RemoveRange(saleInvoiceDetails);
                    _context.SaleInvoices.Remove(saleInvoice);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public List<SaleInvoice> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var result = _context.SaleInvoices.Include(u => u.SaleInvoiceDetails).ToList();
                    if (result != null && result.Count > 0)
                    {
                        foreach (var child in result)
                        {
                            if (child.SaleInvoiceDetails.Count > 0)
                            {
                                foreach (var data in child.SaleInvoiceDetails)
                                {
                                    data.SaleInvoice = null;
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
        public SaleInvoice Get(int saleId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var saleInvoice = _context.SaleInvoices.Include(u => u.SaleInvoiceDetails).FirstOrDefault(u => u.Id == saleId);
                    saleInvoice.SaleInvoiceDetails = saleInvoice.SaleInvoiceDetails.ToList();
                    if (saleInvoice != null && saleInvoice.SaleInvoiceDetails != null && saleInvoice.Id > 0)
                    {
                        foreach (var child in saleInvoice.SaleInvoiceDetails.ToList())
                        {
                            child.SaleInvoice = null;

                        }

                    }
                    return saleInvoice;


                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public SaleInvoice GetSaleInvoice(int saleID)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.SaleInvoices.Find(saleID);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AddSaleInvoiceDetails(List<SaleInvoiceDetail> saleDetails)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.AddRange(saleDetails);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeleteSaleInvoiceDetail(int saleId)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    var saleInvoiceDetails = _context.SaleInvoiceDetails.Where(x => x.SaleInvoiceId == saleId).ToList();
                    _context.SaleInvoiceDetails.RemoveRange(saleInvoiceDetails);
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
            DataSet ds = new DataSet("SaleInvoice");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_GetSaleInvoiceList", conn);
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


        public DataSet InvoicesByParty(int id)
        {
            DataSet ds = new DataSet("InvoiceByParty");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_PartyInvoiceList", conn);
                    sqlComm.Parameters.AddWithValue("@PartyId", id);

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
