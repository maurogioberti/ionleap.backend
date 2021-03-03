using System.Runtime.Serialization;

namespace Neoris.Ionleap.CrossCutting.Configuration.DataMembers
{
    public class Application
    {
        [DataMember]
        public bool DebugMode { get; set; }
    }
}
