using GTA;

namespace GTAV
{
    public class Main : Script
    {
        readonly MainMenuV Menu = new MainMenuV();
        public Main()
        {
            Tick += Menu.fn.onTick;
            KeyDown += Menu.fn.onKeyDown;
        }
    }
}