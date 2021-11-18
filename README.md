# Spellbook Merge

This is a mod for Pathfinder Wrath of the Righteous. It adds additional spellbook merging options.

## Warnings

* This mod creates new blueprints and thus creates a save dependency. Once your save depends on this mod, it is not safe to uninstall it.

* To be careful, install this mod just before reaching Mythic Rank 3. Test that you get the option to merge spellbooks, if not file a bug report.

* I have tested this mod only with Aeon-Inquisitor, the other merges are untested (for now).

* After merging spellbooks your mythic spell progression is tied to your base spellbook. So be careful when taking dips, if you don't progress your base spellbook enough, you might end up not getting the required slots to cast higher level mythic spells.

* Currently for Casters that learn spells automatically (Druid, Paladin etc.), there is a bug where any new spell slots gained by merging spellbooks do not trigger learning new spells. Reload the save/game to fix the issue. I haven't tested if you can recover them if use respec and keep progressing without learning these spells.

* There is an incompatibility with Tabletop Tweaks where it modifies the BloodRager spellbook. So if you want to merge BloodRager with mythic paths, disable the specific TTT tweak for it.
## Mythic Paths

### Angel

Angel has been patched to allow Paladin as a mergeable option. This needs thorough testing to see if higher level spells are castable and if the progressions are applied correctly. Be warned.


### Aeon

Aeon gets to merge spellbooks with the following base spellbooks

* WarPriest
* Inquisitor
* Druid
* Magus
* Sword Saint
* Hunter

### Azata
Azata gets to merge spellbooks with the following base spellbooks
* Magus
* Bard
* Skald
* Sword Saint
* Sorcerer
* Druid
* Hunter
* BloodRager
* Wizard
* ExploiterWizard

### Demon
Demon gets to merge spellbooks with the following base spellbooks
* BloodRager
* Hunter
* Skald
* Magus
* Sword Saint

### Trickster
Trickster gets to merge spellbooks with the following base spellbooks
* Alchemist
* Eldritch Scoundrel
* Magus
* Sword Saint
* Bard
* Skald
* Witch


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

The patched hybrid casters mentioned above can cast 7th level spells post CL 20.

Paladin progression has been specifically patched for allowing Angel merge. It has not been tested well yet. The progression is tight and slower than an Angel Oracle, but can't be helped, with the current approach. But by my estimation if you stay pure Paladin, you should be able to cast level 10 Angel spells as a merged caster once you reach Mythic 9/10.
File an issue report if that's not the case.


## Acknowledgements

I would like to give my sincerest thanks to:

1. Owlcat for this amazing game.
2. My fellow modders from discord for inspiration and answering my questions. Particularly Narria Cabarius, Vek17, Bubbles and ArcaneTrixter.