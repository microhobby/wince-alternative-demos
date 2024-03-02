
using Torizon.Shell;

namespace Torizon
{
    public class TorizonInfo
    {
        public enum Arch
        {
            Arm,
            Arm64,
            x64,
            Unknown
        }

        public static string GetTorizonVersion()
        {
            var res = Exec.Bash("grep PRETTY_NAME /etc/os-release | cut -d= -f2- | tr -d '\\\\\"'");
            if (res.exitCode != 0)
            {
                throw new System.Exception($"Failed to get Torizon version :: {res.exitCode}");
            }

            return res.output;
        }

        public static string GetKernelVersion()
        {
            var res = Exec.Bash("uname -r");
            if (res.exitCode != 0)
            {
                throw new System.Exception($"Failed to get kernel version :: {res.exitCode}");
            }

            return res.output;
        }

        public static Arch GetArch()
        {
            var res = Exec.Bash("uname -m");
            if (res.exitCode != 0)
            {
                throw new System.Exception($"Failed to get machine architecture :: {res.exitCode}");
            }

            if (res.output.Contains("arm"))
            {
                return Arch.Arm;
            }
            else if (res.output.Contains("aarch64"))
            {
                return Arch.Arm64;
            }
            else if (res.output.Contains("x86_64"))
            {
                return Arch.x64;
            }
            else
            {
                return Arch.Unknown;
            }
        }
    }
}
