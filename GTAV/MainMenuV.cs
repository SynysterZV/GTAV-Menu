using LemonUI;
using LemonUI.Menus;
using GTA;
using System;
using System.Linq;

namespace GTAV
{
    class MainMenuV
    {

        public Functions funcs;

        public ObjectPool Pool = new ObjectPool();
        public NativeMenu UI = new NativeMenu("Syn'x Mod Menu", "WIP");

        public NativeMenu PlayerUI = new NativeMenu("Player Menu", "Player");
        public NativeSubmenuItem PlayerSubMenuItem;
        public NativeCheckboxItem GodMode = new NativeCheckboxItem("Godmode", Game.Player.IsInvincible);
        public NativeListItem<int> WantedLevel = new NativeListItem<int>("Set Wanted Level", Enumerable.Range(0, 6).ToArray());

        public NativeMenu WeaponUI = new NativeMenu("Weapon Menu", "Weapons");
        public NativeSubmenuItem WeaponSubMenuItem;
        public NativeItem GiveAllWeapons = new NativeItem("Give All Weapons");
        public NativeListItem<WeaponHash> GiveWeapon = new NativeListItem<WeaponHash>("Give Weapon", (WeaponHash[])Enum.GetValues(typeof(WeaponHash)));
        public NativeItem RemoveAllWeapons = new NativeItem("Remove All Weapons");

        public NativeMenu VehicleUI = new NativeMenu("Vehicle Menu", "Vehicles");
        public NativeSubmenuItem VehicleSubMenuItem;
        public NativeMenu VehicleSpawnerUI = new NativeMenu("Vehcile Spanwer", "Vehicle Spawner");
        public NativeSubmenuItem VehicleSpawnerSubMenuItem;
        public NativeItem RepairVehicle = new NativeItem("Repair Vehicle");
        public MainMenuV()
        {

            funcs = new Functions(this);

            CreateSubMenuItems();
            LinkEvents();
        }

        private void CreateSubMenuItems()
        {
            PlayerSubMenuItem = new NativeSubmenuItem(PlayerUI, UI);
            WeaponSubMenuItem = new NativeSubmenuItem(WeaponUI, UI);
            VehicleSubMenuItem = new NativeSubmenuItem(VehicleUI, UI);
            VehicleSpawnerSubMenuItem = new NativeSubmenuItem(VehicleSpawnerUI, VehicleUI);

            Pool.Add(UI);
            UI.Add(PlayerSubMenuItem);
            UI.Add(WeaponSubMenuItem);
            UI.Add(VehicleSubMenuItem);

            Pool.Add(PlayerUI);
            PlayerUI.Add(GodMode);
            PlayerUI.Add(WantedLevel);

            Pool.Add(WeaponUI);
            WeaponUI.Add(GiveAllWeapons);
            WeaponUI.Add(GiveWeapon);
            WeaponUI.Add(RemoveAllWeapons);

            Pool.Add(VehicleUI);
            Pool.Add(VehicleSpawnerUI);
            VehicleUI.Add(VehicleSpawnerSubMenuItem);
            VehicleUI.Add(RepairVehicle);
            CreateVehicleSpawners();

        }

        private void CreateVehicleSpawners()
        {
            foreach (VehicleClass vclass in (VehicleClass[]) Enum.GetValues(typeof(VehicleClass)))
            {
                NativeListItem<VehicleHash> LI = new NativeListItem<VehicleHash>(vclass.ToString(), Vehicle.GetAllModelsOfClass(vclass));
                VehicleSpawnerUI.Add(LI);

                LI.Activated += (object sender, EventArgs e) =>
                {
                    World.CreateVehicle(LI.SelectedItem, (Game.Player.Character.Position + Game.Player.Character.ForwardVector * 3));
                };
            }
        }

    private void LinkEvents()
        {
            /* Player UI */
            GodMode.CheckboxChanged += funcs.GodMode;
            WantedLevel.Activated += funcs.WantedLevel;

            /* Weapon UI */
            GiveWeapon.Activated += funcs.GiveWeapon;
            GiveAllWeapons.Activated += funcs.GiveAllWeapons;
            RemoveAllWeapons.Activated += funcs.RemoveAllWeapons;

            /* Vehcile UI */
            RepairVehicle.Activated += funcs.RepairCar;
        }
    }
}
