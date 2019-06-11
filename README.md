# Pokesean
Senior Project 2018
Microsoft Form C#.NET Application

    Abstract

“Pokesean” is a management tool for a fan-made collaboration of the two franchises, Pokemon and Dungeons and Dragons. The game originated as a personal friend’s idea, which in reality became a slow, boring, number-crunching four hours every week. The purpose of Pokesean is to minimize the down-time and number-crunching required to play what is affectionally called, “PokeDND.” Created using C#.NET in conjunction with SQL Databases, Pokesean allows players to create and edit their personal team of six members in addition to an easy-to-use calculator.

    Introduction
In PokeDND, there are animals called Pokemon which have supernatural and often powerful abilities. These could include breathing fire, stomping on the ground to create an earthquake, all the way to being able to manipulate time and space. Humans have the option, at the age of ten, to become a Pokemon Trainer in which you are given your first Pokemon and allowed to journey the world meeting new friends and Pokemon along the way.

Pokemon Battling is the norm in the world of Pokemon. In fact, it’s as natural as evolution. As Pokemon battle more, they gain “experience points” (exp) which allow them to “level up” and become even stronger, usually gaining new abilities or transforming into more mature, powerful versions of themselves called evolving.
    
Trainers are able to store up to 6 Pokemon on their person at any time. They are allowed to catch additional Pokemon, but they must be stored in a PC (Pokemon Computer). All Pokemon have six statistics that determine their strength in battle, health (HP), physical attack (ATK), physical defense (DEF), special attack (SP.ATK), special defense (SP.DEF), and speed (SPD). In addition, each Pokemon may learn up to four moves at a time. All of this requires each player to constantly and carefully manage their team as well as balance strengths/weaknesses, and get their (albeit relatively simple) math correct when calculating damage during battle. 
    
At first, doing all of this was relatively simple and easy because we each only had one or two Pokemon to keep track of. As time went on, however, we all started to have an increasingly large (15-20+) number of Pokemon all with varying levels, types, moves, and stats. Most players near the end of the game switched over to creating their own Excel sheets to more efficiently manage their teams. 

The biggest factor in wanting to make this tool is to simplify the team management experience so that gameplay is quicker and more interactive. Having to look up and research every Pokemon that you come into contact with when there are almost 1,000 Pokemon is time consuming and slows the game down immensely. 

I at first found an API made by the wonderful Pokemon community called PokeAPI which has a vast wealth of resources and data already pooled together. I was quite excited to learn about it! However, their documentation was lackluster at best. Following this, Professor Goetz suggested a simple SQL file, which then led me down the path to creating my own database. 
Inputting information while time consuming was not challenging. Creating the program itself was relatively simple although I certainly hit quite a few snags along the way. One of my biggest issues was with the level calculator. For a Pokemon to level up in PokeDND, they must gain exp equal to their current level +1. So, for instance, a level 5 Pokemon would need 6exp to get to level 6. 

This process gets slightly more complicated depending on the level difference between the Pokemon in question. If the victor is of higher level than the loser, the experience gained is halved. If the victor is of equal or lower level, the experience gained is base (equal to the level of the losing Pokemon). However, if the victorious Pokemon’s typing (a Fire Pokemon) is the same as one of its owner’s “Specialist Types,” they receive double experience (after halving the base exp if needed). This multiplier goes up to 3x if the Pokemon is a dual-type Pokemon that matches with both of the Trainer’s Special Types. 

The process can become long and grueling when each trainer has six Pokemon that are all above level 40, so a calculator was definitely needed in addition to team management. 
