namespace Overlord
{
    public interface IOperatingSystemController
    {
        public void Shutdown(bool force);
        public void Restart(bool force);
        public void Hibernate();
        public void Sleep();
        public void Lock();
        public void Logoff(bool force);
    }
}