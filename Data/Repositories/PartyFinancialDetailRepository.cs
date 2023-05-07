using Data.DataContext;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PartyFinancialDetailRepository : IDisposable, IPartyFinancialDetailRepository
    {
        public PartyFinancialDetail Add(PartyFinancialDetail obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.PartyFinancialDetails.Add(obj);
                    _context.SaveChanges();
                }
                return obj;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<PartyFinancialDetail> GetAll()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.PartyFinancialDetails.ToList();
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public PartyFinancialDetail Update(PartyFinancialDetail obj)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.PartyFinancialDetails.Update(obj);
                    _context.SaveChanges();
                }
                return obj;
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
                    var partyFinancialDetail = _context.PartyFinancialDetails.Find(id);
                    _context.Remove(partyFinancialDetail);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public PartyFinancialDetail Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.PartyFinancialDetails.Find(id);
                }
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
