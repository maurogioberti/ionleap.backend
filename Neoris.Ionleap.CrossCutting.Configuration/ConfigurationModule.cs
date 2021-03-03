using Neoris.Ionleap.CrossCutting.Configuration.DataMembers;
using Neoris.Ionleap.CrossCutting.Infrastructure;

namespace Neoris.Ionleap.CrossCutting.Configuration
{
    public static class ConfigurationModule
    {
        public static Security Security => ProcessFile.Read<Security>();
        public static ConnectionStrings ConnectionStrings => ProcessFile.Read<ConnectionStrings>();
        public static Application Application => ProcessFile.Read<Application>();

        public static Scheduler Scheduler => ProcessFile.Read<Scheduler>();

        //public static Business Business => Infrastructure.ProcessFile.Read<Business>();
    }

}
