using System;
using System.Windows.Forms;
using GTA;
using GTA.UI;

namespace GTAV
{ 
    class Functions
    {
        public MainMenuV Menu;

        public Functions(MainMenuV menu)
        {
            Menu = menu;
        }

        /*
         * 
         * 
         * MENU
         * 
         * FUNCTIONS
         * 
         * 
         */

        public void onTick(object sender, EventArgs e)
        {
            Menu.Pool.Process();
        }


        public void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
            {
                ToggleMenu();
            }
        }

        public void ToggleMenu()
        {
            if (Menu.Pool.AreAnyVisible)
            {
                Menu.Pool.HideAll();
                return;
            }

            Menu.UI.Open();
        }

        /*
         * 
         * 
         * VEHICLE
         * 
         * FUNCTIONS
         * 
         * 
         */

        public void RepairCar(object sender, EventArgs e)
        {
            if (CurrentVehicle != null)
                CurrentVehicle.Repair();
        }

        /*
         * 
         * 
         * PLAYER
         * 
         * FUNCTIONS
         * 
         * 
         */

        public void GodMode(object sender, EventArgs e)
        {
            Player.IsInvincible ^= true;
        }

        public void WantedLevel(object sender, EventArgs e)
        {
            Player.WantedLevel = Menu.WantedLevel.SelectedItem;
        }

        /*
         * 
         * 
         * WEAPONS
         *
         * FUNCTIONS
         *
         * 
         */

        public void GiveWeapon(object sender, EventArgs e)
        {
            Character.Weapons.Give(Menu.GiveWeapon.SelectedItem, 999, true, true);
        }

        public void GiveAllWeapons(object sender, EventArgs e)
        {
            foreach(WeaponHash weapon in (WeaponHash[])Enum.GetValues(typeof(WeaponHash)))
            {
                Character.Weapons.Give(weapon, 999, false, true);
            }
        }

        public void RemoveAllWeapons(object sender, EventArgs e)
        {
            Character.Weapons.RemoveAll();
        }

        /*
         * 
         * 
         * MISC 
         * 
         * FUNCTIONS
         * 
         * 
         */

        public Player Player { get; } = Game.Player;
        public Ped Character { get; } = Game.Player.Character;
        public Vehicle CurrentVehicle { get; } = Game.Player.Character.CurrentVehicle;

    }
}