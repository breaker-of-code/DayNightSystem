namespace DNS.Interfaces
{
    public interface IView
    {
        public IController Controller { get; set; }

        void Init(IController controller);
    }
}