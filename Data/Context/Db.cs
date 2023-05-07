using Data.Entities;


namespace Data.Context
{
    public static class Db
    {
        public static SasteMandiUATContext Create()
        {
            try
            {
                SasteMandiUATContext db = new SasteMandiUATContext();
                return db;
            }
            catch { return null; }
        }
    }
}

