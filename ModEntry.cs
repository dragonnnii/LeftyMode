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
            helper.Events.Input.ButtonsChanged += OnButtonsChanged;
        }

        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            // Toggles the mode when the 'W' key is pressed
            if (e.Pressed.Contains(SButton.W))
            {
                IsLeftClickMode = !IsLeftClickMode;
                string mode = IsLeftClickMode ? "Left Click" : "Right Click";
                this.Monitor.Log($"Switched to {mode} mode.", LogLevel.Info);
                Game1.addHUDMessage(new HUDMessage($"Mouse Mode: {mode}", 3));
            }

            CheckMouse();
        }

        private void CheckMouse()
        {
            MouseState mouseState = Mouse.GetState();
            
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (IsLeftClickMode)
                {
                    // Logic for standard Left Click
                }
                else
                {
                    // Logic to simulate Right Click when in Lefty Mode
                }
            }
        }
    }
}
