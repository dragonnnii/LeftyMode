using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace LeftyMode
{
    public class ModEntry : Mod
    {
        private bool IsLeftClickMode = true;

        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonsChanged += this.OnButtonsChanged;
        }

        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            if (e.Pressed.Contains(SButton.W))
            {
                this.IsLeftClickMode = !this.IsLeftClickMode;
                string modeName = this.IsLeftClickMode ? "Left Click" : "Right Click";

                // Using the full path ensures the compiler finds Game1 and HUDMessage
                StardewValley.Game1.addHUDMessage(new StardewValley.HUDMessage($"Mouse Mode: {modeName}", 3));
                
                this.Monitor.Log($"Switched to {modeName} mode.", LogLevel.Info);
            }
        }
    }
}
