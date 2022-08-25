using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Overlord
{
    [SupportedOSPlatform("windows")]
    public class WindowsController : IOperatingSystemController
    {
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        [DllImport("user32.dll")]
        private static extern int ExitWindowsEx(int uFlags, int dwReason);

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

        public void Hibernate()
        {
            SetSuspendState(true, true, true);
        }

        public void Restart(WindowsForceFlags forceFlags)
        {
            int flag = (int)WindowsFlags.Reboot | (int)forceFlags;
            ExitWindowsEx(flag, 0);
        }

        public void Shutdown(WindowsForceFlags forceFlags)
        {
            int flag = (int)WindowsFlags.Shutdown | (int)forceFlags;
            ExitWindowsEx(flag, 0);
        }

        public void Sleep()
        {
            SetSuspendState(false, true, true);
        }

        public void Lock()
        {
            LockWorkStation();
        }

        public void Logoff(WindowsForceFlags forceFlags)
        {
            int flag = (int)WindowsFlags.Shutdown | (int)forceFlags;
            ExitWindowsEx(flag, 0);
        }
    }
}