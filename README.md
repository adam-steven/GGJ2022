# Driving Democracy
![GIF of Game]()

A Twitch chat game which demonstrates the pitfalls of putting driving Cruella's Car up to a vote. Made for Global Game Jam 2022 with the theme 'duality' with a friend over the more *traditional* 48 hours using C# and Unity.

[Download here](https://github.com/giodestone/Driving-Democracy/releases). [View submission page here.](https://globalgamejam.org/2022/games/driving-democracy-3)

Backend and models made by Adam. Visualization made by Feliks.

## How To Play

1. As this game listens to Twitch chat, you have to provide your Twitch username and an authentication token that you can generate from https://twitchapps.com/tmi/.

2. Configure your stream delay to 15s and low latency mode for the best experience.

3. After this all you have to do is stream the game on Twitch and let the votes roll in.

During the voting period, chat can type: 1, 2, 3 or 4 to change the cars lane.

Typing "faster" or "slower" casts a vote for speeding up or slowing down the voting period respectively.

After the voting period the car will change to the highest voted lane and drive straight forward hitting whatever is in front of it. 

The obstacles have positive and negative effects so some votes may be divisive.  

![Image of stream]()

## How It Works
Using the auth token, the game logs in and scans the Twitch chat (using IRC) for numbers 1-4 during the voting period. The voting system counts the amount of votes then gets the best performing one and switches the car to that track. Hopefully, everyone made the best choice, and it didn't end in a stalemate...

The visualization is an infinitely generating level which moves the car at set time intervals.

The game 'syncs up' with the stream by having a delay where it says 'counting votes', however it is still open to voting (as to the viewer which is 15 seconds behind it appears as if its still open). This is to reduce the delay and improve immersion. This can be configured.

## Development Story
Initially we wanted to develop a multiplayer game. However, with time pressure and few innovative ideas that would not be in person we opted to try to make a chat game. Inspired by a night of watching 101 Dalmatians and wondering whether (that telephone)[https://i.imgur.com/Mel2Oag.png] is available for purchase, it was the only plausible art style choice, especially when paired with the right jazz music (per the 'Jazzing it Up' diversifier).

This would be interesting to develop into a fully fledged chat game (maybe a Jackbox-esque chat game collection?) with different voting systems and even custom obstacles. Aside from general usability enhancements, a full voting breakdown would be nice to show along side some polish to make the visualization truly reflective of the 60s animation style - but in 3D.