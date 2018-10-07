using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PwF.CharacterCreation
{
    class Compendium
    {
        public AbsoluteLayout CreateOverlay(String info)
        {
            // Initialise the return variable
            AbsoluteLayout overlay;

            AbsoluteLayout temp = new AbsoluteLayout
            {
                Opacity = 0,
            };
            AbsoluteLayout.SetLayoutBounds(temp, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(temp, AbsoluteLayoutFlags.All);
            
            // Create the semi-transparent shadow effect
            AbsoluteLayout background = new AbsoluteLayout
            {
                BackgroundColor = Color.FromHex("#000000"),
                Opacity = 0.5,
            };
            AbsoluteLayout.SetLayoutBounds(background, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(background, AbsoluteLayoutFlags.All);

            // Create a label that contains the string passed into the method
            Label compendiumContent = new Label
            {
                Text = info,
                FontSize = 24,
            };
            AbsoluteLayout.SetLayoutBounds(compendiumContent, new Rectangle(0.5, 0.5, 0.8, 0.8));
            AbsoluteLayout.SetLayoutFlags(compendiumContent, AbsoluteLayoutFlags.All);

            // Create a scroll view to contain the compendiumContent label
            ScrollView foreground = new ScrollView
            {
                BackgroundColor = Color.FromHex("#F0DFA8"),

                Content = compendiumContent,
            };
            AbsoluteLayout.SetLayoutBounds(foreground, new Rectangle(0.5, 0.5, 0.9, 0.9));
            AbsoluteLayout.SetLayoutFlags(foreground, AbsoluteLayoutFlags.All);

            // Place the shadow and the scroll with the content in the return variable
            overlay = new AbsoluteLayout
            {
                Children =
                {
                    background,
                    foreground,
                    temp,
                }
            };
            AbsoluteLayout.SetLayoutBounds(overlay, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(overlay, AbsoluteLayoutFlags.All);

            return overlay;
        }
    }
}
