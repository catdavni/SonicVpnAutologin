How to use

1) Create VPNAutologin.exe shortcut.
2) Add in shortcut `Target` path to sonic vpn client `exe`, `login` and `password` separated by space.

How to make shortcut `Target`
- find path to sonic .exe (https://www.softwareok.com/?seite=faq-Windows-10&faq=152). Usually it is `C:\Program Files\SonicWall\Global VPN Client\SWGVC.exe`
- wrap path in quotes -> `"C:\Program Files\SonicWall\Global VPN Client\SWGVC.exe"`
- concatenate it with login and password -> `"C:\Program Files\SonicWall\Global VPN Client\SWGVC.exe" putHereLogin putHerePassword`
- add result string to VPNAutologin.exe shortcut `Target`

![Image](https://github.com/vnyTobii/SonicVpnAutologin/blob/master/Images/vpnShortcutTarget.png)
