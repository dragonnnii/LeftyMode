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
            // The name here...
            helper.Events.Input.ButtonsChanged += OnButtonsChanged;
        }

        // ...MUST match the name here!
        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            if (e.Pressed.Contains(SButton.W))
            {
                IsLeftClickMode = !IsLeftClickMode;
                string mode = IsLeftClickMode ? "Left Click" : "Right Click";
                this.Monitor.Log($"Switched to {mode} mode.", LogLevel.Info);
            }

            // Simple Mouse Check
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && !IsLeftClickMode)
            {
                // Logic for right-click simulation
            }
        }
    }
}
