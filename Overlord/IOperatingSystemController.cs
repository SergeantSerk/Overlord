using static Overlord.WindowsController;

namespace Overlord
{
    public interface IOperatingSystemController
    {
        public void Shutdown(WindowsForceFlags forceFlags);
        public void Restart(WindowsForceFlags forceFlags);
        public void Hibernate();
        public void Sleep();
        public void Lock();
        public void Logoff(WindowsForceFlags forceFlags);
    }
}