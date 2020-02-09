using Domain.Constants;
using System;

namespace Helpers
{
    public static class EnvironmentHelper
    {
        public static string EnvironmentName
        {
            get
            {
#if DEBUG
                return EnviromentConstants.Development;
#elif QA
                return EnviromentConstants.Testing;
#elif BETA
                return EnviromentConstants.Beta;
#else
                return EnviromentConstants.Release;
#endif
            }
        }

        public static bool IsProduction
        {
            get
            {
                var env = EnvironmentName;
                if (env == EnviromentConstants.Beta || env == EnviromentConstants.Release)
                {
                    return true;
                }
                return false;
            }
        }

        public static string MachineHostname
        {
            get
            {
                string machineName = Environment.GetEnvironmentVariable("MACHINE_HOSTNAME");
                return machineName;
            }
        }
    }
}
