using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taha.Core.Infrastructure
{
    //http://csharpindepth.com/Articles/General/Singleton.aspx
    //Third version - attempted thread-safety using double-check locking
    // Bad code! Do not use!
    public sealed class Utility
    {
        private static Utility _Curent = null;
        private static readonly object padlock = new object();


        public static Utility Curent
        {
            get
            {
                if (_Curent == null)
                {
                    lock (padlock)
                    {
                        if (_Curent == null)
                        {
                            _Curent = new Utility();
                        }
                    }
                }
                return _Curent;
            }
        }
        public DateTime Now()
        {
            return System.DateTime.Now;
        }
    }
}
