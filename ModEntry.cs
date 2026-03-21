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
        // Tracks if we are in normal mode (true) or lefty/right-click mode (false)
        private bool IsLeftClickMode = true;

        public override void Entry(IModHelper helper)
        {
            // Set up the listener for button presses (like the 'W' key)
            helper.Events.Input.ButtonsChanged += this.OnButtonsChanged;
        }

        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            // 1. Toggle Mode Logic (Press 'W' to switch)
            if (e.Pressed.Contains(SButton.W))
            {
                this.IsLeftClickMode = !this.IsLeftClickMode;
                string modeName = this.IsLeftClickMode ? "Left Click" : "Right Click";

                // Show a message on the screen in-game
                StardewValley.Game1.addHUDMessage(new StardewValley.HUDMessage($"Mouse Mode: {modeName}", 3));
                
                // Log the change to the SMAPI console
                this.Monitor.Log($"Switched to {modeName} mode.", LogLevel.Info);
            }

            // 2. Mouse Input Logic
            // This part detects physical mouse clicks using MonoGame (Microsoft.Xna.Framework.Input)
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (!this.IsLeftClickMode)
                {
                    // If you are in 'Right Click' mode, we can add logic here 
                    // to trigger game actions usually reserved for the right mouse button.
                    this.Monitor.Log("Left click detected while in Right-Click Mode!", LogLevel.Debug);
                }
            }
        }
    }
}
