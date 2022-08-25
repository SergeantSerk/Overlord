using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Overlord
{
    public class OperatingSystemController : IOperatingSystemController
    {
        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        [SupportedOSPlatform("windows")]
        [DllImport("user32.dll")]
        private static extern int ExitWindowsEx(int uFlags, int dwReason);

        [SupportedOSPlatform("windows")]
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public enum WindowsFlags
        {
            Logoff = 0x00000000,
            Shutdown = 0x00000001,
            Reboot = 0x00000002,
            Poweroff = 0x00000008,
            HybridShutdown = 0x00400000,
            RebootWithApps = 0x00000040
        }

        public enum WindowsForceFlags
        {
            None = 0x00000000,
            Force = 0x00000004,
            ForceIfHung = 0x00000010
        }

        [SupportedOSPlatform("windows")]
        public void Hibernate()
        {
            SetSuspendState(true, true, true);
        }

        [SupportedOSPlatform("windows")]
        public void Restart(bool force)
        {
            int flag =
                (int)WindowsFlags.Reboot |
                (int)(force ? WindowsForceFlags.ForceIfHung : WindowsForceFlags.None);
            ExitWindowsEx(flag, 0);
        }

        [SupportedOSPlatform("windows")]
        public void Shutdown(bool force)
        {
            int flag =
                (int)WindowsFlags.Shutdown |
                (int)(force ? WindowsForceFlags.ForceIfHung : WindowsForceFlags.None);
            ExitWindowsEx(flag, 0);
        }

        [SupportedOSPlatform("windows")]
        public void Sleep()
        {
            SetSuspendState(false, true, true);
        }

        [SupportedOSPlatform("windows")]
        public void Lock()
        {
            LockWorkStation();
        }

        [SupportedOSPlatform("windows")]
        public void Logoff(bool force)
        {
            int flag =
                (int)WindowsFlags.Shutdown |
                (int)(force ? WindowsForceFlags.ForceIfHung : WindowsForceFlags.None);
            ExitWindowsEx(flag, 0);
        }
    }
}