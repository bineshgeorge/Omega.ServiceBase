using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Omega.Core;
using Omega.Core.Interface;
using Omega.Data;

namespace Omega.ServiceBase
{
    public abstract class OmegaBusinessBase<T, TF> : OmegaServiceBase
        where T : IDataModel, new()
        where TF : IModelFilter , new()
    { 

        public OmegaBusinessBase(DataSession dataSession) : base(dataSession)
        {

        }
        

        ~OmegaBusinessBase()
        {
            Dispose(false);
        }
        

        public virtual async Task<List<T>> Fetch(TF filter)
        {
            var tcs = new TaskCompletionSource<List<T>>();
            tcs.SetException(new NotImplementedException());
            return await tcs.Task;
            //return await Task.Run(() => new List<T>());
        }
        public async Task<T?> FetchOne(TF filter)
        {
            var data = await Fetch(filter);
            if (data == null || data.Count <= 0 ) return default;
            return data[0];
        }
        public virtual async Task<bool> Add(T model)
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetException(new NotImplementedException());
            return await tcs.Task;
        }

        public virtual async Task<bool> Update(T model)
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetException(new NotImplementedException());
            return await tcs.Task;
        }

        public virtual async Task<bool> Validate(T model)
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetException(new NotImplementedException());
            return await tcs.Task;
        }
        public virtual async Task<bool> Delete(T model)
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetException(new NotImplementedException());
            return await tcs.Task;
        }

      
    }
}