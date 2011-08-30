using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;
using System.Diagnostics;
using System.IO;

namespace MetaBlog
{
    public static class MetaBlogAPIFactory
    {
        public static IBlogger Create()
        {
            IBlogger res = (IBlogger)
                XmlRpcProxyGen.Create(typeof(IBlogger));

            res.ResponseEvent += delegate(object sender,
      XmlRpcResponseEventArgs e)
            {
                Debug.WriteLine(new StreamReader(e.ResponseStream).ReadToEnd());
            };
            return res;
        }
    }
}
