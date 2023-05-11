using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkdb.Service
{
    public interface IQueueSender
    {
        public void sendMessage(string message);
    }
}