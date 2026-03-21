using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace LeftyMode
{
    public class ModEntry : Mod
    {
        private bool isRightClickMode = false;

        public override void Entry(IModHelper helper)
        {
            // Listen for the button press
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // Ignore if the player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // Toggle logic set to 'A' key
            if (e.Button == SButton.A)
            {
                ToggleClickMode();
            }
        }

        private void ToggleClickMode()
        {
            isRightClickMode = !isRightClickMode;

            // Logic to switch between Left (Tool/Hit) and Right (Action/Interact)
            if (isRightClickMode)
            {
                Game1.addHUDMessage(new HUDMessage("Mode: Right Click (Action)", 3));
            }
            else
            {
                Game1.addHUDMessage(new HUDMessage("Mode: Left Click (Tool)", 3));
            }
        }
    }
}
