using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.ServiceProcess;
using System.Threading;

namespace Todo.Service
{
    public partial class Reminders : ServiceBase
    {
        Timer _workTimer;
        static readonly string baseUrl = ConfigurationManager.AppSettings["serviceUrl"];
	    static readonly string mailFrom = ConfigurationManager.AppSettings["mailFrom"];
		static readonly IRestClient restClient = new RestClient(baseUrl);
		// Make sure to fill in the smtp settings in the app.config file
        static readonly SmtpClient mailClient = new SmtpClient();
        protected override void OnStart(string[] args)
        {
            _workTimer = new Timer(doWork, null, TimeSpan.FromSeconds(60), TimeSpan.FromDays(1));
            base.OnStart(args);
        }

        static void doWork(object state)
        {
            restClient.Get<List<string>>(new RestRequest("/accounts"))
                      .Data
                      .Select(email => new
                      {
	                      Email = email,
						  Tasks = restClient.Get<List<Task>>(new RestRequest($"tasks/{email}/overdue")).Data
                      })
                      .Where(account => account.Tasks.Any())
                      .ToList()
                      .ForEach(account => mailClient.Send(mailFrom, account.Email, $"Overdue tasks from {ConfigurationManager.AppSettings["companyName"]}", 
                                    account.Tasks.Aggregate($"Hi, you have {account.Tasks.Count} overdue tasks: \n", 
                                                                (m, t) => m + $"- {t.Name} ({t.DueDate.ToString("dd-MM-yyyy")})\n")));
        }

		protected override void OnStop()
		{
			_workTimer.Dispose();
			base.OnStop();
		}
	}

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
    }
}
