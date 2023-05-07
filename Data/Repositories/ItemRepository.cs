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
    public class ItemRepository : IDisposable, IItemRepository
    {
        public Item Add(Item obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Items.Add(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public Item Update(Item obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Items.Update(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<Item> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Items.ToList();
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<Item> GetAllByParty(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Items.Where(o => o.PartyId == id).ToList();
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
                    var item = _context.Items.Find(id);
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
        public Item Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Items.Find(id);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public DataSet List(int pageNo, int rowPerPage)
        {
            DataSet ds = new DataSet("Item");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_GetItemsList", conn);
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
