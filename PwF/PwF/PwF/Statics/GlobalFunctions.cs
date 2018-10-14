using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PwF.Statics
{
    public static class GlobalFunctions
    {

        // returning the modifier of selected Score
        public static int ReturnModifier(int scoreValue) {
            double temp;

            // if found Score then apply equation, round down number and return result
            temp = (Math.Floor(((double)scoreValue - 10) / 2));
            return (int)temp;

        }

        public static AbsoluteLayout getPopupBase(string title, Command exitCommand) {
            Label popUpTitleText = new Label {
                Text = title,
                FontSize = 24,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(popUpTitleText, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(popUpTitleText, AbsoluteLayoutFlags.All);

            AbsoluteLayout popUpTitle = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#FFAA00"),

                Children =
                {
                    popUpTitleText
                }
            };
            AbsoluteLayout.SetLayoutBounds(popUpTitle, new Rectangle(0, 0, 1, .2));
            AbsoluteLayout.SetLayoutFlags(popUpTitle, AbsoluteLayoutFlags.All);

            Button popUpCloseButton = new Button {
                BackgroundColor = Color.FromHex("#BB0000"),
                Text = "Close",
                FontSize = 20,
                Command = exitCommand


            };
            AbsoluteLayout.SetLayoutBounds(popUpCloseButton, new Rectangle(0, 1, 1, .2));
            AbsoluteLayout.SetLayoutFlags(popUpCloseButton, AbsoluteLayoutFlags.All);

            AbsoluteLayout popUp = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#FFFFFF"),

                Children =
                {
                    popUpTitle,
                    popUpCloseButton
                }
            };
            AbsoluteLayout.SetLayoutBounds(popUp, new Rectangle(.5, .5, .6, .4));
            AbsoluteLayout.SetLayoutFlags(popUp, AbsoluteLayoutFlags.All);

            return popUp;
        }

        public static AbsoluteLayout getPopUpFill() {

            AbsoluteLayout popUpFill = new AbsoluteLayout {
            };
            AbsoluteLayout.SetLayoutBounds(popUpFill, new Rectangle(.5, .5, 1, .6));
            AbsoluteLayout.SetLayoutFlags(popUpFill, AbsoluteLayoutFlags.All);

            return popUpFill;
        }

        public static double getFontSize(int FontSize, double width) {
            double OriginalSize = 411.5;
            double scale = FontSize / OriginalSize;
            double Font = width * scale;
            return Font;
        }
    }
}
