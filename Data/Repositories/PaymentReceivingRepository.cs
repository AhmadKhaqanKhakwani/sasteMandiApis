using Data.DataContext;
using Data.Interfaces;
using Data.Models;
using Data.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SaleInvoicePaymentRepository : IDisposable, ISaleInvoicePaymentRepository
    {
        public SaleInvoicePayment Add(SaleInvoicePayment obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SaleInvoicePayments.Add(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public SaleInvoicePayment Update(SaleInvoicePayment obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.SaleInvoicePayments.Update(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<SaleInvoicePayment> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.SaleInvoicePayments.ToList();
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var item = _context.SaleInvoicePayments.Find(id);
                    _context.Remove(item);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public SaleInvoicePayment Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.SaleInvoicePayments.Find(id);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public DataSet List(int pageNo, int rowPerPage)
        {
            DataSet ds = new DataSet("Record");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_GetSaleInvoicePayment", conn);
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
