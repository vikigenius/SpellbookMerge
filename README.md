﻿# Spellbook Merge

This is a mod for Pathfinder Wrath of the Righteous. It adds additional spellbook merging options.

## Patch 1.3

Owlcat introduced several changes to the Spellbook Merging system in patch 1.3, that just broke the mod.
To quickly fix the issue I have just undid the spellbook merging changes they introduced and used the old system.
So people that like Owlcat's new system, you will have to wait for a while for me to figure the new system out and patch it.
For people that liked the older merging system, think of this as a feature instead of a bug :)

## Warnings

* This mod creates new blueprints and thus creates a save dependency. Once your save depends on this mod, it is not safe to uninstall it.

* To be careful, install this mod just before reaching Mythic Rank 3. Test that you get the option to merge spellbooks, if not file a bug report.

* I have tested this mod only with Aeon-Inquisitor, the other merges are untested (for now).

* After merging spellbooks your mythic spell progression is tied to your base spellbook. So be careful when taking dips, if you don't progress your base spellbook enough, you might end up not getting the required slots to cast higher level mythic spells.

* Currently for Casters that learn spells automatically (Druid, Paladin etc.), there is a bug where any new spell slots gained by merging spellbooks do not trigger learning new spells. Reload the save/game to fix the issue. I haven't tested if you can recover them if use respec and keep progressing without learning these spells.

* There is an incompatibility with Tabletop Tweaks where it modifies the BloodRager spellbook. So if you want to merge BloodRager with mythic paths, disable the specific TTT tweak for it.

## Configuration

The patches to spellbook progressions can be disabled in the json settings file.
In your mod directory for this mod, you should find a UserSettings directory. Open PatchSettings.json and set any spellbook progression patch that you do not want to false.
Note that this only disables the spellbook progression patches, you will still get options to merge spellbooks, you can just chose not to merge if you don't want to.

## Mythic Paths

### Angel

Angel can merge with the followin additional spellbooks
* Palading (This needs thorough testing to see if higher level spells are castable and if the progressions are applied correctly. Be warned.)
* Sorcerer
* Wizard
* Arcanist
* Witch
* Sage Sorcerer
* Crossblooded Sorcerer

### Lich

Lich can now merge with the following spellbooks.

* Druid
* Oracle
* Shaman
* Cleric

### Aeon

Aeon gets to merge spellbooks with the following base spellbooks

* WarPriest
* Inquisitor
* Druid
* Magus
* Sword Saint
* Hunter
* Eldritch Scion
* Sorcerer
* Wizard
* Arcanist
* Sage Sorcerer
* Cross Blooded Sorcerer
* Oracle
* Bard
* Shaman
* Cleric
* Witch

### Azata
Azata gets to merge spellbooks with the following base spellbooks
* Magus
* Bard
* Skald
* Sword Saint
* Sorcerer
* Sage Sorcerer
* Druid
* Hunter
* BloodRager
* Wizard
* ExploiterWizard
* Arcanist
* Eldritch Scion
* Arcanist
* Cross Blooded Sorcerer
* Oracle
* Shaman
* Cleric
* Witch

### Demon
Demon gets to merge spellbooks with the following base spellbooks
* BloodRager
* Hunter
* Skald
* Magus
* Sword Saint
* Sorcerer
* Sage Sorcerer
* Bard
* Eldritch Scion
* Cross Blooded Sorcerer
* Arcanist
* Oracle
* Bard
* Shaman
* Cleric
* Wizard
* Druid
* Witch

### Trickster
Trickster gets to merge spellbooks with the following base spellbooks
* Alchemist
* Eldritch Scoundrel
* Magus
* Sword Saint
* Bard
* Skald
* Witch
* Eldritch Scion
* Sage Sorcerer
* Sorcerer
* Cross Blooded Sorcerer
* Wizard
* Druid
* Cleric
* Oracle
* Shaman


## Base Spellbooks

The following spellbooks have had their spell slot progressions patched to allow access to higher level spells from mythic paths.

* Magus
* Sword Saint
* Alchemist
* BloodRager
* Bard
* Skald
* Inquisitor
* WarPriest
* Paladin
* Hunter (Uses the Bard spellbook)
* Eldritch Scion (Uses the Bard progression)


The patched hybrid casters mentioned above can cast 7th level spells post CL 20.

Paladin progression has been specifically patched for allowing Angel merge. It has not been tested well yet. The progression is tight and slower than an Angel Oracle, but can't be helped, with the current approach. But by my estimation if you stay pure Paladin, you should be able to cast level 10 Angel spells as a merged caster once you reach Mythic 9/10.
File an issue report if that's not the case.


## Acknowledgements

I would like to give my sincerest thanks to:

1. Owlcat for this amazing game.
2. My fellow modders from discord for inspiration and answering my questions. Particularly Narria Cabarius, Vek17, Bubbles and ArcaneTrixter.