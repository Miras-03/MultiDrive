using System.Collections.Generic;

namespace SwitchOption
{
    public sealed class Switcher
    {
        private List<ISwitchable> sounders = new List<ISwitchable>();

        public void AddSwitchObservers(ISwitchable switchables) => sounders.Add(switchables);

        public void NotifyCarObservers()
        {
            foreach (ISwitchable sounder in sounders)
                sounder.SwitchToCar();
        }

        public void NotifyPlaneObservers()
        {
            foreach (ISwitchable sounder in sounders)
                sounder.SwitchToPlane();
        }
    }
}