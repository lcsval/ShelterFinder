using System.Collections.Generic;

namespace ShelterFinder.Domain.Command
{
    public abstract class BaseCommand
    {
        public BaseCommand()
        {
            Notifications = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Notifications { get; set; }
    }
}
