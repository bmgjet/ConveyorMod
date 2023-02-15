/*_                      _      _   
 | |__  _ __ ___   __ _ (_) ___| |_ 
 | '_ \| '_ ` _ \ / _` || |/ _ \ __|
 | |_) | | | | | | (_| || |  __/ |_ 
 |_.__/|_| |_| |_|\__, |/ |\___|\__|
                  |___/__/          */
namespace Oxide.Plugins
{
    [Info("ConveyorMod", "bmgjet", "1.0.0")]
    [Description("Changes Settings On Servers Conveyors")]
    class ConveyorMod : RustPlugin
    {
        public int MaxStackSizePerMoveAdustment = 1024; //Change Setting here, -1 will make no change.
        private void OnEntitySpawned(IndustrialConveyor conveyor) { ChangeSettings(conveyor); }
        private void OnServerInitialized(bool initial){Startup(initial ? 20 : 1);}
        private void Startup(int delay){timer.Once(delay, () =>{foreach (BaseNetworkable bn in BaseNetworkable.serverEntities.entityList.Values) { if (bn is IndustrialConveyor) { ChangeSettings(bn as IndustrialConveyor); } }});}
        private void ChangeSettings(IndustrialConveyor conveyor)
        {
            if (conveyor == null) { return; }
            if (!conveyor.IsDestroyed && MaxStackSizePerMoveAdustment != -1){conveyor.MaxStackSizePerMove = MaxStackSizePerMoveAdustment;}
        }
    }
}
