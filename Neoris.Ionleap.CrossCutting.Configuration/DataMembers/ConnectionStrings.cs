using System.Runtime.Serialization;

namespace Neoris.Ionleap.CrossCutting.Configuration.DataMembers
{
    public class ConnectionStrings
    {
        [DataMember]
        public string DatabaseContext { get; set; }
    }
}
