using System.Diagnostics;
using System.ServiceProcess;

namespace Todo.Service
{
    static class Program
    {
        static void Main()
        {
            ServiceBase.Run(new Reminders());
        }
    }
}
