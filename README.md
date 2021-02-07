# PlayStationSharp
This project is based https://github.com/Tustin/PlayStationSharp.
This program was modified to use the PSN remote play login credentials in order to query the account id for a specific user by his/ her PSN id (user name)

It also inludes some experimental features like waking up PS4 and PS5 over PSN. Please note, this feature is experimental and it if you have enabled UPnP on your router the PS5/ PS4 will create
automatically port mappings for port 9308 and/ or 9304 as the official Remoet Play client is using these ports to establish a connection over the internet. So just keep that in mind.

## Usage
__Notice:__
In this project there is a lot of unused code and some things could definetly be implemented in a better way but the main purpose of this test program was to be able to quickly grab Account-Ids
for users of the [PSPlay](https://play.google.com/store/apps/details?id=psplay.grill.com) and [Chiaki](https://play.google.com/store/apps/details?id=com.metallic.chiaki) app. These a two 3rd Party
remote play client applications. Maybe this is useful for others as well.