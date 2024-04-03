namespace Interfaces
{
    public interface IUpgradable
    {
        public int CurrentLevel { get; }

        public int UpdateCost { get; }

        public void Update();
    }
}
