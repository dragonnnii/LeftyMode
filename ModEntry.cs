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
            // Changed from SButton.W to SButton.RightStick (D3)
            if (e.Pressed.Contains(SButton.RightStick))
            {
                this.IsLeftClickMode = !this.IsLeftClickMode;
                string modeName = this.IsLeftClickMode ? "Left Click" : "Right Click";

                Game1.addHUDMessage(new HUDMessage($"Mouse Mode: {modeName}", 3));
                this.Monitor.Log($"Switched to {modeName} mode using D3.", LogLevel.Info);
            }

            // Mouse logic remains the same
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !this.IsLeftClickMode)
            {
                this.Monitor.Log("D3 Mode: Simulating Right Click...", LogLevel.Debug);
            }
        }
    }
}
