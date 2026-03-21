using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input; // Fixes the MouseState/Keyboard errors
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace LeftyMode
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonsChanged += OnButtonsChanged;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses or releases any buttons.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            // Example: Check if a specific key (like 'W') is pressed to toggle logic
            if (e.Pressed.Contains(SButton.W))
            {
                this.Monitor.Log("W key was pressed! LeftyMode logic can trigger here.", LogLevel.Debug);
            }
        }

        /// <summary>A helper method to get the current mouse state.</summary>
        private void CheckMouse()
        {
            // This now works because of the 'using Microsoft.Xna.Framework.Input' line at the top
            MouseState mouseState = Mouse.GetState();
            
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // Your custom left-click logic
            }
        }
    }
}
