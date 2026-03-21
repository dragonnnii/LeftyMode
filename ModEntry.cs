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
            // Listen for the button press (Works for keyboard or mapped mobile inputs)
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // Ignore if the player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // Check if the 'W' key was pressed
            if (e.Button == SButton.W)
            {
                ToggleClickMode();
            }
        }

        private void ToggleClickMode()
        {
            isRightClickMode = !isRightClickMode;

            // Logic to tell the game which 'tool' or 'action' mouse button to use
            // On mobile, this helps Cinderbox differentiate the touch intent
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
