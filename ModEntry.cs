using System;
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
            // Toggle using the '3' key (Digit3/Number3)
            if (e.Pressed.Contains(SButton.Number3))
            {
                this.IsLeftClickMode = !this.IsLeftClickMode;
                string mode = this.IsLeftClickMode ? "Left Click" : "Right Click";
                
                if (Context.IsWorldReady)
                {
                    Game1.addHUDMessage(new HUDMessage($"Mode: {mode}", 3));
                }
                
                this.Monitor.Log($"Switched to {mode} mode.", LogLevel.Info);
            }
        }
    }
}
