using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class WriteLog

    {
        public void WriteTransactionLog(TransactionLog log)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"../../../Log.txt", true))
                {
                    sw.WriteLine($"{log.TransactionDate}--||--{log.TrackUserInput}:--||--${log.PreviousBalance}--||--${log.CurrentBalance}");
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Sorry Error");
            }
        
        }
    }
}
