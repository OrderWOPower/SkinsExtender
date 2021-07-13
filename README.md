# SkinsExtender
In the vanilla game, only entire skins.xml files could be merged, so if a mod wanted to modify skins.xml, it had to include an entire skins.xml file. This was impractical if the mod only wanted to add a few nodes, such as a new hair or a new beard. It could also cause issues whenever TaleWorlds updates the native skins.xml.

I created this utility for modders to add new nodes to skins.xml. However it can't edit existing nodes yet. If anyone wants me to make it be able to edit existing nodes, please make a request.

This utility is compatible with Detailed Character Creation and it has to be after DCC in the load order. If you use DCC you can also have as many skins.xml files as you want. Without this utility DCC only "sees" the last one if there are multiple ones.

To use the utility, your mod's project.mbproj file needs to have "soln_skins_extension" as the id of the file that references your skins.xml (the filename can be any name). Also, your mod needs to be after Skins Extender in the load order. And yes, your mod can load after Native.

For the format of the skins.xml, please refer to the screenshot.

This utility requires Harmony.
