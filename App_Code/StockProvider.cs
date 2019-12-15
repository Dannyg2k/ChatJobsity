using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ChatJobsity.App_Code
{
    public  class StockProvider
    {

        public  string  GetStock(string _stockCode)
        {
            string _retorna = "";
            string _url = "https://stooq.com/q/l/?s=" + _stockCode + "&f=sd2t2ohlcv&h&e=csv​";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
            httpWebRequest.Timeout = 3000000;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                String line = string.Empty;
                int fila = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    fila += 1;

                   if (fila==2)
                   {
                        _retorna = line;

                   }  
                }
            
            }

            return _retorna;

        }
    }
}