using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley; // <--- THIS LINE IS REQUIRED FOR Game1

namespace LeftyMode
{
    public class ModEntry : Mod
    {
        private bool IsLeftClickMode = true;

        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonsChanged += OnButtonsChanged;
        }

        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            if (e.Pressed.Contains(SButton.W))
            {
                IsLeftClickMode = !IsLeftClickMode;
                string mode = IsLeftClickMode ? "Left Click" : "Right Click";
                
                // We use StardewValley.Game1 to be 100% sure the compiler finds it
                StardewValley.Game1.addHUDMessage(new StardewValley.HUDMessage($"Mouse Mode: {mode}", 3));
                
                this.Monitor.Log($"Switched to {mode} mode.", LogLevel.Info);
            }
        }
    }
}
