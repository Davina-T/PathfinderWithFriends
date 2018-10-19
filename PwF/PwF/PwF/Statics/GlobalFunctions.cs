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

        public static AbsoluteLayout getCompendium(string title, string content, Command exitCommand) {


            Button CompendiumX = new Button {
                BackgroundColor = Color.FromHex("#AAAAAA"),
                Text = "X",
                FontSize = 24,
                Command=exitCommand
            };
            AbsoluteLayout.SetLayoutBounds(CompendiumX, new Rectangle(1, 0, .15, .1));
            AbsoluteLayout.SetLayoutFlags(CompendiumX, AbsoluteLayoutFlags.All);

            Label CompendiumTitle = new Label {
                Text=title,
                FontSize=24,
                HorizontalTextAlignment=TextAlignment.Center,
                VerticalTextAlignment=TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(CompendiumTitle, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(CompendiumTitle, AbsoluteLayoutFlags.All);

            AbsoluteLayout CompendiumTitleHolder = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#FFFFFF"),
                Children = {
                    CompendiumTitle
                }
            };
            AbsoluteLayout.SetLayoutBounds(CompendiumTitleHolder, new Rectangle(.5, 0, 1, .1));
            AbsoluteLayout.SetLayoutFlags(CompendiumTitleHolder, AbsoluteLayoutFlags.All);

            Label CompendiumContent = new Label {
                Text=content,
                FontSize=24,
                HorizontalTextAlignment=TextAlignment.Center
            };
            AbsoluteLayout.SetLayoutBounds(CompendiumContent, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(CompendiumContent, AbsoluteLayoutFlags.All);

            AbsoluteLayout CompendiumContentLayout = new AbsoluteLayout {
                Children = {
                    CompendiumContent
                }
            };
            AbsoluteLayout.SetLayoutBounds(CompendiumContentLayout, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(CompendiumContentLayout, AbsoluteLayoutFlags.All);

            ScrollView CompendiumContentHolder = new ScrollView {

            };
            AbsoluteLayout.SetLayoutBounds(CompendiumContentHolder, new Rectangle(.5, 1, 1, .9));
            AbsoluteLayout.SetLayoutFlags(CompendiumContentHolder, AbsoluteLayoutFlags.All);

            CompendiumContentHolder.Content = CompendiumContentLayout;

            AbsoluteLayout CompendiumHolder = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#F0DFA8"),
                Children = {
                    CompendiumTitleHolder,
                    CompendiumX,
                    CompendiumContentHolder
                }
            };
            AbsoluteLayout.SetLayoutBounds(CompendiumHolder, new Rectangle(.5, .5, .9, .75));
            AbsoluteLayout.SetLayoutFlags(CompendiumHolder, AbsoluteLayoutFlags.All);

            AbsoluteLayout Compendium = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#50000000"),
                Children = {
                    CompendiumHolder
                }
            };
            AbsoluteLayout.SetLayoutBounds(Compendium, new Rectangle(.5, .5, 1, 1));
            AbsoluteLayout.SetLayoutFlags(Compendium, AbsoluteLayoutFlags.All);

            return Compendium;
        }

        public static AbsoluteLayout getFeatsView() {
            Label popUpTitleText = new Label {
                Text = "Feats",
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

            AbsoluteLayout popUp = new AbsoluteLayout {
                BackgroundColor = Color.FromHex("#FFFFFF"),

                Children =
                {
                    popUpTitle
                }
            };
            AbsoluteLayout.SetLayoutBounds(popUp, new Rectangle(.05, .5, .6, .4));
            AbsoluteLayout.SetLayoutFlags(popUp, AbsoluteLayoutFlags.All);

            return popUp;
        }

        public static double getFontSize(int FontSize, double width) {
            double OriginalSize = 411.5;
            double scale = FontSize / OriginalSize;
            double Font = width * scale;
            return Font;
        }
    }
}
