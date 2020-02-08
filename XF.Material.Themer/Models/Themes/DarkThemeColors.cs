using Xamarin.Forms;

namespace XF.Material.Themer.Models.Themes
{
  // initialized with the 'dark theme baseline palette'.
  public class DarkThemeColors : ThemeColorsBase
  {
    public override Color Primary { get; set; } = Color.FromHex("BB86FC");
    public override Color PrimaryVariant { get; set; } = Color.FromHex("3700B3");
    public override Color Secondary { get; set; } = Color.FromHex("03DAC6");
    public override Color SecondaryVariant { get; set; } = Color.FromHex("03DAC6");
    public override Color Background { get; set; } = Color.FromHex("121212");
    public override Color Surface { get; set; } = Color.FromHex("121212");
    public override Color Error { get; set; } = Color.FromHex("CF6679");
    public override Color OnPrimary { get; set; } = Color.FromHex("000000");
    public override Color OnSecondary { get; set; } = Color.FromHex("000000");
    public override Color OnBackground { get; set; } = Color.FromHex("FFFFFF");
    public override Color OnSurface { get; set; } = Color.FromHex("FFFFFF");
    public override Color OnError { get; set; } = Color.FromHex("000000");
  }
}

/*
   https://material.io/resources/color/#!/?view.left=1&view.right=1&primary.color=ff9123&secondary.color=195aa4
   .
   https://material.io/develop/android/theming/color/
   https://material.io/develop/android/theming/dark/
   https://material.io/design/color/dark-theme.html
   .
   Discusses when to test for 4.5:1 or 15.8:1 ratios
   https://blog.prototypr.io/how-to-design-a-dark-theme-for-your-android-app-3daeb264637
   .
   .
   A guide to implementing a dark theme
   https://www.youtube.com/watch?v=FSxgFKlbV9Y
   .
   .
   contrast checker: https://webaim.org/resources/contrastchecker/
   .
   .
   .                  Orange     Normal Text (16px Regular)    Large text (18px bold or 24px Regular)
   primary            #ff7221    Black, min 66% opacity        Black, min 49% opacity
   primary Light      #ffa352    Black, min 60% opacity        Black, min 46% opacity
   Primary Dark       #c54200    White, min 92% opacity        White, min 66% opacity
   .                                                           Black, min 65% opacity
   .
   OnPrimary          #0f0f0f minimum (through to #000000), or use alpha on #000000
   OnPrimaryLight     #2b2b2b minimum(through to #000000), or use alpha on #000000
   OnPrimaryDark      #ffffff only
   .
   ..............................................................................
   ..............................................................................
   .                  Blue
   Secondary          #195aa4     White, min 73% opacity       White, min 52% opacity
   Secondary Light    #5986d6     Black, min 77% opacity       Black, min 55% opacity
   Secondary Dark     #003275     White, min 53% opacity       White, min 38% opacity
   .
   OnSecondary        #d4d4d4 minimum (through to #ffffff), or use alpha on #ffffff
   OnSecondaryLight   #1f1f1f minimum (through to #000000), or use alpha on #000000
   OnSecondaryDark    #c4c4c4 minimum (through to #ffffff), or use alpha on #ffffff
   .
   ..............................................................................
   ..............................................................................
   .
   Background         #171413      #121212 + 2% #ff7221
   OnBackground       #deffffff    87% high emphasis
   OnBackground       #99ffffff    60% medium emphasis
   OnBackground       #61ffffff    38% disabled text
   .
   .
   Surfaces           #171413      00dp elevation    - background
   .                  #23201f      01dp (5% white)
   .                  #282524      02dp (7% white)
   .                  #2a2726      03dp (8% white)
   .                  #2c2a29      04dp (9% white)
   .                  #312e2d      06dp (11% white)
   .                  #333130      08dp (12% white)
   .                  #383535      12dp (14% white)
   .                  #3a3837      16dp (15% white)
   .                  #3d3a39      24dp (16% white)
   .
   .
   . Elevations       https://material.io/design/environment/elevation.html#default-elevations
   .                  Dialog                       : 24dp
   .                  Modal bottom/side sheet      : 16dp
   .                  Navigation drawer            : 16dp
   .                  FAB (pressed)                : 12dp
   .                  Standard bottom/side sheet   : 8dp
   .                  Bottom navigation bar        : 8dp
   .                  Bottom app bar               : 8dp
   .                  Menus and sub-menus          : 8dp
   .                  Card (picked)                : 8dp
   .                  Contained button (pressed)   : 8dp
   .                  Lines / BoxView              : 8dp
   .                  * Button                     : 2dp - 8dp
   .                  * Chips                      : 8dp
   .                  FAB (resting)                : 6dp
   .                  Snackbar                     : 6dp
   .                  Top app bar (scrolled)       : 4dp
   .                  Top app bar (resting)        : 0dp or 4dp
   .                  Refresh indicator            : 3dp
   .                  Search bar (scrolled)        : 3dp
   .                  Card (resting)               : 1dp
   .                  Switch                       : 1dp
   .                  Text button                  : 0dp
   .                  Standard side sheet          : 0dp
*/
