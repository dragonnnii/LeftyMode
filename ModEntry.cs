using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace LeftClickToRightClick
{
    public class ModEntry : Mod
    {
        private bool isRightClickEnabled = false;

        public override void Entry(IModHelper helper)
        {
            // Listen for key presses and mouse/touch input
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // Toggle mode when 'W' is pressed
            if (e.Button == SButton.W)
            {
                isRightClickEnabled = !isRightClickEnabled;
                string status = isRightClickEnabled ? "ENABLED" : "DISABLED";
                
                // Show a message on screen so you know it worked
                Game1.addHUDMessage(new HUDMessage($"Right-Click Mode: {status}", 3));

                // Prevent the 'W' from making the character walk up while toggling
                this.Helper.Input.Suppress(SButton.W);
            }

            // If mode is ON and user taps (MouseLeft), swap it to MouseRight
            if (isRightClickEnabled && e.Button == SButton.MouseLeft)
            {
                // Stop the normal Left-Click
                this.Helper.Input.Suppress(SButton.MouseLeft);

                // Force a Right-Click at the current cursor position
                this.Helper.Input.TriggerMouseButton(SButton.MouseRight);
            }
        }
    }
}
