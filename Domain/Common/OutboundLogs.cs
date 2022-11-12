using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public partial class OutboundLog
    {

        public string OutboundLogId { get; set; }
        public string ServiceProvider { get; set; }
        public string EndPointCalled { get; set; }
        public DateTime LogDate { get; set; }
        public string RequestDetails { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string ResponseDetails { get; set; }
        public DateTime ResponseDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError => ErrorMessage != "";
        public bool IsSuccess { get; set; } = true;

    }
}
