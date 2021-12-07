# Unity Material Icons

[![paypal](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=YAUUBSC3KYUEC&source=url)

This project simplifies the usage of Google's Material Design icons on Unity.

Supported Unity versions are 2017.1 or higher.

![preview](doc/preview.png)

## Quickstart

Simply import the package into Unity by downloading it from the [latest release](https://github.com/convalise/unity-material-icons/releases/latest).

Then, add the MaterialIcon class to your GameObject and you are good to go.

You can also add a new icon to the scene by right-clicking on the hierarchy window and selecting `Google > Material Icon`.

## Documentation

The MaterialIcon class inherits from `UnityEngine.UI.Text`, so you have all properties and methods available [here](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/script-Text.html) such as color and raycast target.

You can set the icon programaticaly by setting the text to the properly Unicode escaped char (e.g., `icon.text = "\uE84D"`), or without unicode notation by using the provided sugar `iconUnicode` (e.g., `icon.iconUnicode = "E84D"`).

## Known issues

The "goat" icon (unicode 10FFFD) is currently the only unsupported one due to surrogate-pair characters limitations.

## Credits

This project was created by Conrado (https://github.com/convalise).

It makes usage of the [Material Design icons project by Google](https://github.com/google/material-design-icons).\
More information on the Google's project can be found at the [Material Icons Guide](http://google.github.io/material-design-icons/).

## License

This software is licensed under **Apache License 2.0**. You can find the full text of the license [here](LICENSE).
