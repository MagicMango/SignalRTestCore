using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Interfaces
{
    public interface ISessionHub
    {
        Task Notify(string username);
    }
}
