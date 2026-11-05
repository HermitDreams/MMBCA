To use the battle script, first paste the "battle" file's contents into mIRC's aliases tab and save it.

If you are not also using BNCTBet, chip_select, and enemy_deck, you can manually populate the p1.txt and p2.txt files.

The first line of p1 and p2 will be your NaviChip. Virus Chips work too.
The next two lines will be your top and bottom first selected chips
The next three lines are top, middle, and then bottom in the center column
The next four lines are the top corner, top middle, bottom middle, and bottom corner chips in the final column
The next two lines are Slot L and Slot R
Finally, the last two lines are the threshold at which Slot L and Slot R will attempt to activate

Once those two files are populated, you can type "/battle" into mIRC and it will simulate a battle between those two decks.

If you are using the above additional scripts, you can randomly generate two decks by including a library file with "/battle", e.g. "/battle BNCT Full"

Known Bugs:
- Currently, NavRcycl and CardRevive are not supported
- Panic and PanicCloud may heal the opponent if you have more selected chips than your opponent but are missing at least one
- A Navi directly destroying a box chip does not report the box emptying
- Coin flip chips (like Meteors) always trigger total block counters instead of rolling to miss first
- The Gauge can go above 100% when boosted

Maybe Bugs:
- GaiaSwrd does not gain power from Boost chips after it
- Balloons do not benefit from Boosts

Intentional Changes:
- Dodge formula revised to be a random number between 1 and your dodge score must exceed the accuracy of the attack
 - This means for 100 dodge, the formula is the same, but chance is slightly higher at lower dodge scores
 - This may be reverted to its original formula at some point
- All attack-and-recover attacks will still gain health even if the attack is blocked, not just Roll's
 - This gives a buff to CanDevils
 - Recovery is nullified if AntiRecv or PoisnApple blocked it
- Two New Field Types: Beta Sand and Star Force Ice
 - Beta Sand: Inverted elemental priority (Nulls go first) and boost to Wind Chips
 - Star Force Ice: Aqua Navis gain a damage boost to Breaking Chips
 - There is currently no chip that sets Beta Sand
- At 50% gauge, if you select a completely dead line, you will spend your gauge to reroll a different line
