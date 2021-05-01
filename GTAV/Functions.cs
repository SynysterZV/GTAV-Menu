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
            if (e.KeyCode == Keys.F5)
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
            Vehicle currentVehicle = GetCurrentVehicle();
            if (currentVehicle != null)
                currentVehicle.Repair();
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
            GetPlayer().IsInvincible ^= true;
        }

        public void WantedLevel(object sender, EventArgs e)
        {
            GetPlayer().WantedLevel = Menu.WantedLevel.SelectedItem;
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
            GetCharacter().Weapons.Give(Menu.GiveWeapon.SelectedItem, 999, true, true);
        }

        public void GiveAllWeapons(object sender, EventArgs e)
        {
            foreach(WeaponHash weapon in (WeaponHash[])Enum.GetValues(typeof(WeaponHash)))
            {
                GetCharacter().Weapons.Give(weapon, 999, false, true);
            }
        }

        public void RemoveAllWeapons(object sender, EventArgs e)
        {
            GetCharacter().Weapons.RemoveAll();
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

        public Player GetPlayer()
        {
            return Game.Player;
        }

        public Ped GetCharacter()
        {
            return Game.Player.Character;
        }

        public Vehicle GetCurrentVehicle()
        {
            return Game.Player.Character.CurrentVehicle;
        }
    }
}
