using System.Runtime.Serialization;

namespace Neoris.Ionleap.CrossCutting.Configuration.DataMembers
{
    public class Security
    {
        [DataMember]
        public int TokenMinutesAlive { get; set; }
        [DataMember]
        public string TokenSecretKey { get; set; }
    }
}
