using Omega.Core;
using Omega.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.ServiceBase
{
    public abstract class OmegaServiceBase : IDisposable
    {
        private readonly DataSession _dataSession;
        private List<vMessageData> _messgeList;

        public vReturnCode ReturnStatus { get; set; } = vReturnCode.Failure;
        public OmegaServiceBase(DataSession dataSession)
        {
            _dataSession = dataSession;
            _messgeList = new List<vMessageData>();
        }

        public string? NetworkID { get; set; } = null;
        public string? UserName { get; set; } = null;
        public vLanguageCode LanguageCode { get; set; } = vLanguageCode.English;
        public short CountryCode { get; set; }


        #region IDisposable
        public virtual void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

      
        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion 

        public DataSession SessionObject
        {
            get { return _dataSession; }
        }

        public List<vMessageData> MessgeList
        {
            get
            {
                if (_messgeList == null) _messgeList = new List<vMessageData> { };
                return _messgeList;
            }
        }

        public void ParseMessage(string? message)
        {
            if (message == null) return;
            var data = message.Split(';', StringSplitOptions.RemoveEmptyEntries);
            this.MessgeList.Add(new vMessageData()
            {
                Code = Convert.ToInt16(data[0]),
                Message = data[1].ToString()
            }) ;
        }
        public int RowToInt(object val)
        {
            int retVal = 0;
            if (val is DBNull || val == DBNull.Value || val == null) return retVal;
            int.TryParse(val.ToString(), out retVal);
            return retVal;
        }

        public short RowToShort(object val)
        {
            short retVal = 0;
            if (val is DBNull || val == DBNull.Value || val == null) return retVal;
            short.TryParse(val.ToString(), out retVal);
            return retVal;
        }

        public double RowToDouble(object val)
        {
            double retVal = 0D;
            if (val is DBNull || val == DBNull.Value || val == null) return retVal;
            double.TryParse(val.ToString(), out retVal);
            return retVal;
        }

        public decimal RowToDecimal (object val)
        {
            decimal retVal = 0;
            if (val is DBNull || val == DBNull.Value || val == null) return retVal;
            decimal.TryParse(val.ToString(), out retVal);
            return retVal;
        }

        public DateTime? RowToDateTime(object val)
        {
            DateTime retVal;
            if (val is DBNull || val == DBNull.Value || val == null) return null;
            DateTime.TryParse(val.ToString(), out retVal);
            return retVal;
        }

        public bool RowToBoolean(object val)
        {
            bool retVal = false;
            if (val is DBNull || val == DBNull.Value || val == null) return retVal;
            bool.TryParse(val.ToString(), out retVal);
            return retVal;
        }
        public bool IsReturnSuccess(object val)
        {
            int result = 5100; // false
            if (val == null || val == DBNull.Value) return false;
            int.TryParse(val.ToString(), out result);

            bool retVal = (result == vConstant.C_RET_SUCCESS);
            this.ReturnStatus = (retVal ? vReturnCode.Success : vReturnCode.Failure);
            return retVal;

        }
    }
}
