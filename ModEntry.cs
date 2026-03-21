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
            // Changed to Number3 - the official SMAPI name for the '3' key
            if (e.Pressed.Contains(SButton.Number3))
            {
                this.IsLeftClickMode = !this.IsLeftClickMode;
                string modeName = this.IsLeftClickMode ? "Left Click" : "Right Click";

                StardewValley.Game1.addHUDMessage(new StardewValley.HUDMessage($"Mouse Mode: {modeName}", 3));
                this.Monitor.Log($"Switched to {modeName} mode using D3.", LogLevel.Info);
            }

            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !this.IsLeftClickMode)
            {
                this.Monitor.Log("Right-click mode active.", LogLevel.Debug);
            }
        }
    }
}
