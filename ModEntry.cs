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
            // This name must match the function below!
            helper.Events.Input.ButtonsChanged += OnButtonsChanged;
        }

        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            // Toggle mode with 'W' key
            if (e.Pressed.Contains(SButton.W))
            {
                IsLeftClickMode = !IsLeftClickMode;
                string mode = IsLeftClickMode ? "Left Click" : "Right Click";
                this.Monitor.Log($"Switched to {mode} mode.", LogLevel.Info);
            }

            // Mouse check
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (!IsLeftClickMode)
                {
                    // Logic for right-click simulation goes here
                }
            }
        }
    }
}
