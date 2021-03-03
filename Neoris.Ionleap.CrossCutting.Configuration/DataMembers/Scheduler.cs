using System.Runtime.Serialization;

namespace Neoris.Ionleap.CrossCutting.Configuration.DataMembers
{
    public class Scheduler
    {
        [DataMember]
        public int WebSiteProductsSyncJob_ExecutionTime { get; set; }

        [DataMember]
        public string WebSiteProductsSyncJob_TriggerName { get; set; }

        [DataMember]
        public string WebSiteProductsSyncJob_DisplayName { get; set; }

        [DataMember]
        public string WebSiteProductsSyncJob_ProductsRequestUrl { get; set; }

        [DataMember]
        public string WebSiteProductsSyncJob_TokenRequest { get; set; }
    }
}