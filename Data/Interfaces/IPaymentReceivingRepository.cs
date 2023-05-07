using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPaymentReceivingRepository
    {
        PaymentReceiving Add(PaymentReceiving obj);
        PaymentReceiving Update(PaymentReceiving obj);
        bool Delete(int id);
        void Dispose();
        PaymentReceiving Get(int id);
        List<PaymentReceiving> GetAll();
        DataSet List(int pageNo, int rowPerPage);
    }
}
