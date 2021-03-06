﻿using System;

namespace Taha.Framework.Infrastructure
{
    //http://csharpindepth.com/Articles/General/Singleton.aspx
    //Third version - attempted thread-safety using double-check locking
    // Bad code! Do not use!
    public sealed class Utility
    {

        #region attempted thread-safety using double-check locking

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

        #endregion

        public DateTime Now()
        {
            return System.DateTime.Now;
        }

    }
}
