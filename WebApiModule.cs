using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

using OwinInterface = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
using Microsoft.Owin;

namespace OWINWebApi
{
    public class WebApiModule
    {
        private readonly OwinInterface _next;

        public ContractModule(OwinInterface next)
        {
            if(next == null)
                throw new ArgumentNullException("next");
            this._next = next;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            try {

                var request = new OwinRequest(env);
                var path = request.Path.Value.TrimEnd(new[] {'/'});

             if (path.Equals("/contracts", StringComparison.OrdinalIgnoreCase)){

                    var responce = new OwinResponse(env);
                    return responce.WriteAsync("My email: hanna@gmail.com, contact phone: +1234567890");
                }
            }
            catch (Exception ex) {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }
            return this._next(env);
        }
    }
}