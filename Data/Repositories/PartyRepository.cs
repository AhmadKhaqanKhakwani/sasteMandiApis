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
    public class PartyRepository : IDisposable, IPartyRepository
    {
        public Party Add(Party obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Parties.Add(obj);
                    _context.SaveChanges();
                }
                return obj;
            }


            catch (Exception ex)
            {

                return null;
            }
        }
        public List<Party> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Parties.ToList();
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public Party Update(Party obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Parties.Update(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool Delete(int partyId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var party = _context.Parties.Find(partyId);
                    _context.Remove(party);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public Party Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Parties.Find(id);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public DataSet List(int pageNo, int rowPerPage)
        {
            DataSet ds = new DataSet("Party");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_GetPartyList", conn);
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
