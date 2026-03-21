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
            // Toggle using the Number 3 key
            if (e.Pressed.Contains(SButton.Number3))
            {
                this.IsLeftClickMode = !this.IsLeftClickMode;
                string mode = this.IsLeftClickMode ? "Left Click" : "Right Click";
                Game1.addHUDMessage(new HUDMessage($"Mode: {mode}", 3));
            }

            // Right-click logic
            if (!this.IsLeftClickMode && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                // Right click simulation logic
            }
        }
    }
}
