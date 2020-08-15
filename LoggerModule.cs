using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using OwinInterface = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OWINWebApi
{
    public class LoggerModule
    {
        private readonly OwinInterface _next;

        private readonly string _prefix;

        public LoggerModule(OwinInterface next, string prefix)
        {
            if (next == null)
                throw new ArgumentNullException("next");
            if (string.IsNullOrEmpty(prefix))
                throw new ArgumentException("prefix can't be null or empty");

            this._next = next;
            this._prefix = prefix;
        } 

        public Task Invoke(IDictionary<string, object> env)
        {
            try {
                Debug.WriteLine("{0} Request: {1}", this._prefix, env["owin.RequestPath"]);
            }
            catch (Exception ex){
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }

            return this._next(env);
        }
    }
}