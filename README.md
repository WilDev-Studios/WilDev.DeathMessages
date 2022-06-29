# WilDev.DeathMessages
Unturned plugin to add death announcements through the OpenMod API

## How to Install
Make sure you are in-game and run this command:
`/openmod install WilDev.DeathMessages`

## Documentation
*Config.yaml*
```yaml
Enabled: true # If the plugin should be enabled - Must be a boolean value
Death-Message-Image-URL: example.death.message.com/image_death.png # Image that the death message will display - Must be a string value with double/single quotes
```

*Translations.yaml*
```yaml
# All translations below can be configured Rich Text <>

# Player - The Unturned player that died
# Instigator - The Unturned user that killed Player (can be none)
# Weapon - The weapon that was used to kill Player (can be none)
# Distance - The distance at which Player was killed
# Location - The location where Player died

Deaths:
  Acid: "{Player} was blown up by a zombie"
  Animal: "{Player} was eaten by an animal"
  Arena: "{Player} has been eliminated"
  Bleeding: "{Player} bled to death from {Instigator}"
  Bones: "{Player} fractured to death"
  Boulder: "{Player} was crushed by a boulder thrown by a zombie"
  Breath: "{Player} suffocated to death"
  Burner: "{Player} was burnt by a Zombie"
  Burning: "{Player} was burnt to death"
  Charge: "{Player} was blown up by {Instigator} with a remote detonator"
  Food: "{Player} starved to death"
  Freezing: "{Player} froze to death"
  Grenade: "{Player} was blown apart by {Instigator} with a grenade"
  Gun: "{Player} was shot by {Instigator} with a {Weapon}"
  Infection: "{Player} was infected to death"
  Kill: "{Player} was killed"
  Landmine: "{Player} was ripped apart by a landmine"
  Melee: "{Player} was chopped to bits with a {Weapon} by {Instigator}"
  Missile: "{Player} was blown up by {Instigator} with a missile"
  Punch: "{Player} was punched by {Instigator}"
  Roadkill: "{Player} got ran over by {Instigator}"
  Sentry: "{Player} was shot on-site by a sentry"
  Shred: "{Player} was shredded apart"
  Spark: "{Player} was electrocuted by a zombie"
  Spit: "{Player} got dissolved by a zombie"
  Splash: "{Player} was blown up by {Instigator} with an explosive bullet"
  Suicide: "{Player} committed suicide"
  Vehicle: "{Player} was blown up by a vehicle"
  Water: "{Player} dehydrated to death"
  Zombie: "{Player} has been trashed by a zombie"
```

*Parameters*
- Rich Text <>: To add color and text formatting support for in-game text - Must be configured with <>

## Contact Us
### [Discord](https://discord.gg/4Ggybyy87d)
