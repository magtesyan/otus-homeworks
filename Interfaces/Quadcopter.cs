namespace Interfaces
{
    public class Quadcopter : IFlyingRobot, IChargeable
    {
        readonly List<string> _components = ["rotor1", "rotor2", "rotor3", "rotor4"];
        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
        }

        public List<string> GetComponents()
        {
            return _components;
        }

        public string GetInfo()
        {
            return "Quadcopter v1";
        }

        public string GetRobotType()
        {
            return "I am a Quadcopter";
        }
    }
}
