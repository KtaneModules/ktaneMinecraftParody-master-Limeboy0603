using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using rnd = UnityEngine.Random;

public class MinecraftParody : MonoBehaviour
{
    public KMAudio Audio;
    public KMSelectable[] Button;
    public KMSelectable submit;
    public TextMesh[] Lyrics_Textbox;
    public MeshRenderer[] UsersSelectionBox;
    public MeshRenderer componentbg;
    public Texture[] UsersPFP;
    public Material[] SongBG;
    static int _moduleIdCounter = 1;
    int _moduleId = 0;

    string[] RevengeLyrics = new string[48]
    {
        "Creeper",
        "Aw man",
        "So we back in the mine",
        "Got our pickaxe swinging from side to side",
        "Side-side to side",
        "This task, a grueling one",
        "Hope to find some diamonds tonight, night, night",
        "Diamonds tonight",
        "Heads up",
        "You hear a sound, turn around and look up",
        "Total shock fills your body",
        "Oh, no, it's you again",
        "I can never forget those eyes, eyes, eyes",
        "Eyes-eye-eyes",
        "'Cause baby tonight",
        "The creeper's tryna steal all our stuff again",
        "'Cause baby tonight",
        "You grab your pick, shovel, and bolt again (Bolt again-gain)",
        "And run, run until it's done, done",
        "Until the sun comes up in the morn'",
        "'Cause baby tonight",
        "The creeper's tryna steal all our stuff again",
        "Just when you think you're safe",
        "Overhear some hissing from right behind",
        "Right-right behind",
        "That's a nice life you have",
        "Shame it's gotta end at this time, time, time",
        "Time-ti-time-time",
        "Blows up",
        "Then your health bar drops and you could use a one-up",
        "Get inside, don't be tardy",
        "So now you're stuck in there",
        "Half a heart is left, but don't die, die, die",
        "Die-die-die",
        "Creepers, you're mine, haha",
        "Dig up diamonds,",
        "And craft those diamonds,",
        "And make some armor,",
        "Get it, baby, go and forge that like you so MLG pro",
        "The sword's made of diamonds, so come at me bro",
        "Huh? Training in your room under the torchlight",
        "Hone that form to get you ready for the big fight",
        "Every single day and the whole night",
        "Creeper's out prowlin', woo, alright",
        "Look at me, look at you",
        "Take my revenge, that's what I'm gonna do",
        "I'm a warrior, baby, what else is new?",
        "And my blade's gonna tear through you, bring it",
    };

    string[] TakeBackTheNightLyrics = new string[17]
    {
        "Closet full of secrets and skeletons awakes, but nothing's true",
        "I used to own a castle, now it's boxes that I have to move",
        "Right here in the darkness, there's nothing left for me to do",
        "It's easier to run away, but today, today we got to",
        "Cast the shadows out from sight",
        "A final stand, a shouting cry",
        "All the wrongs now turned to right",
        "So fight the past, take back the night",
        "And call upon a torch tonight",
        "To bring out all the ghosts to light",
        "Because at last we have to go",
        "It's time to take back the night",
        "To take back the night",
        "Bridges burned and broken on different sides, we start anew",
        "Being chased by monsters to face head-on or be consumed",
        "Reaching out for something, grasping on to nothing to lose",
        "Payback's left too long unpaid, but today, today we got to",
    };

    string[] FallenKingdomLyrics = new string[28]
    {
        "I used to rule the world",
        "Chunks would load when I gave the word",
        "Now every night I go stow away",
        "Hide from the mobs I used to slay",
        "They once were terrified",
        "Every time I looked into their eyes",
        "Villagers would cheer my way",
        "For a hero I was, that's what they'd say",
        "One minute we had it all",
        "Next our world began to fall",
        "Away from all that it had once become",
        "They all cried for my help, but I stood there numb",
        "I gaze off into the boundless skyline",
        "Noteblock choirs playing in the sunshine",
        "Turn 'round pick up my sword and wield",
        "The blade that once forced evil mobs to yield",
        "And hope one day that this chaos and",
        "Destruction turns for the better",
        "Never a bow in hand",
        "And that was when I ruled the land",
        "It was the creepers and Skeletons",
        "Blew down the doors and boxed us in",
        "Arrows whizzing by like streaks of light",
        "I tried all that I could to stay and fight",
        "As the undead roamed the street",
        "Families broken at my feet",
        "Life itself suspended by a thread",
        "Oh, why is it that I wasn't dead",
    };

    string[] FindThePiecesLyrics = new string[15]
    {
        "The city it runs cold today",
        "Sunshine it is shining grey",
        "And I wish I could dig straight down",
        "Black it all away",
        "But in the dark there’s still a sound",
        "And nothing changed",
        "Don’t know if I have ever heard you sing but I hear it",
        "Hear it, hear it, hear it, hear it,",
        "Don’t know if I have ever held your hand but I seek it",
        "Seek it, seek it, seek it, seek it",
        "Don’t know if I have ever loved but I feel it",
        "Put the puzzle back together see what I’m dreaming",
        "When I find the pieces",
        "Faces echo with no names",
        "Strangers feel like home but fade",
    };

    string[] DragonheartedLyrics = new string[26]
    {
        "Lost but marching on like we've always known the trail",
        "Searching for our ending to the fairy-tale",
        "Sometimes even shooting stars find wishes that miss their marks",
        "But when the night gets too dark",
        "And the road home seems too far",
        "We'll see the sun come up again",
        "We will climb higher than we've been",
        "We got a fire that burns within",
        "We are the Dragonhearted",
        "We are the Dragonhearted",
        "Courage to stop a cannonball",
        "Together we stand 30 feet tall",
        "We got a fire that burns within",
        "We are the Dragonhearted",
        "We are the Dragonhearted",
        "We are the Dragonhearted",
        "Fearless we soar, speeding arrows ricochet",
        "Break free, our hearts burn brighter than yesterday",
        "And through the battles we wage",
        "When our shields fall away",
        "The armor cracks and breaks",
        "If ever our torches fade",
        "Standing tall, forever united",
        "We are the Dragonhearted",
        "We are the Dragonhearted-o-o-ooo",
        "We are the Dragonhearted",
    };

    string[] TNTLyrics = new string[34]
    {
        "I came to dig",
        "I'll build a city oh so big",
        "Just wait a sec gotta kill this pig",
        "Cook me some bacon take a swig swig swig",
        "Because there must be something I can craft",
        "To help me ease the burden of this task",
        "I shoot my arrows in the air sometimes",
        "Singing ooooh",
        "Creeper's KO'd",
        "Loot his remains and now his sulfur's mine",
        "Singing ooooh",
        "Not today no",
        "Then I'll go to work under the birch tree",
        "And I'll make myself tons of TNT",
        "And I'll use it all to build a city",
        "I'll mine it all with TNT",
        "I came to blow",
        "Up everything you've ever known",
        "Expel you out of house and home",
        "Biome to biome you shall roam roam roam roam",
        "Because I am a creeper I will rob",
        "All of your precious items that's my job",
        "Then I'll get back home where I'll smile with glee",
        "Now that I can make tons of TNT",
        "'Cause I rule my world made in 3x3",
        "I'll blow it up with TNT",
        "Gonna blow it all up",
        "Every mountain every valley",
        "Ruler of the world yup",
        "All the animals will fear me",
        "'Cause TNT is just",
        "TNT's just really cool",
        "Is just really cool",
        "Is just really cool",
    };

    string[] RunningToNeverLyrics = new string[28]
    {
        "Triumph in our dreams",
        "We want it all",
        "Hearts lost in the moonlight",
        "And off we go",
        "Chasing stardust",
        "Our wildest treasures",
        "Or a mirage",
        "Perfect intentions",
        "But will we ever know",
        "How to stop?",
        "Running running",
        "Are we running to never?",
        "So blind we can't see",
        "How close we get to the edge",
        "Are we running to never?",
        "A race against the horizon",
        "We can't win",
        "A fire burning bright",
        "In our hearts tonight",
        "Are we running to never?",
        "Running to never",
        "We can't build a staircase",
        "To reach new heights",
        "If we lose courage to step",
        "Into the sky",
        "Chasing stardust",
        "We claw and push our way",
        "To the top",
    };

    string[] MineDiamondsLyrics = new string[29]
    {
        "Minin' away",
        "I don't know what to mine",
        "I'll mine this anyway",
        "In this Minecraft day",
        "So beautiful, mine further down",
        "What's that I found?",
        "Mine diamonds (Take on me)",
        "Mine diamonds (Take on me)",
        "I'll mine them",
        "So far I've got two!",
        "So easy to mine",
        "With my Minecraft pickaxe and shovels",
        "Hopefully they stay",
        "In my Minecraft chests",
        "So I'm gonna make",
        "A lock on it",
        "All these diamonds",
        "Sittin' carefully lay",
        "I'm getting worried (Shut the fucking door!)",
        "If they might get stolen",
        "From my ender chest",
        "Wait, who is that?",
        "Holy sheep, it's Notch!",
        "Mine diamonds (Take on me)",
        "Mine diamonds (Take on me)",
        "Now they're safe",
        "Now Now that they're safe",
        "Mine diamonds (Take on me)",
        "Mine diamonds (Take on me)",
    };

    string[] YouCanFindItLyrics = new string[22]
    {
        "There is something calling you",
        "Everything has changed",
        "Running down a dangerous path",
        "You begin the chase",
        "It feels like you'll see",
        "The building blocks of dreams",
        "You can find it",
        "But it won't be mined like a diamond in a cave",
        "You can find it",
        "Even if there's no treasure map to lead the way",
        "There's a guide in your heart",
        "And no matter how far",
        "Or how long the journey takes",
        "You can find it",
        "Your destiny awaits",
        "Today",
        "Sometimes all your dreams might look",
        "Too far out of reach",
        "But one in a million shot",
        "Is all you need",
        "It's there if you choose",
        "To look inside you",
    };

    string[] LevelUpLyrics = new string[24]
    {
        "Awakened by the sun’s rays,",
        "up I rise for the new day.",
        "The same routine but I have changed,",
        "no longer will I stay the same.",
        "My doubts and weakness used to reign,",
        "but a new power I have now gained,",
        "to face the day with a new light.",
        "Worries fade away, and I’m ready to fight.",
        "Continue on this winding road,",
        "strengths within must start to show.",
        "I’ll leave behind my selfish ways,",
        "gonna power up and it starts today.",
        "A change is due, a different view, we must go on.",
        "I’ll find that key, inside of me, as we try to level up.",
        "A change is due, a different view, we must go on.",
        "I’ll find that key, inside of me, as we try to level up.",
        "Beyond my home my journeys told,",
        "thats full of life and love to behold.",
        "The skills I’ve learned shape how I’ve grown,",
        "still so much of this world is unknown.",
        "Through storm and drought I’ll travel far,",
        "over mountain tops, to guide I’ll use the star.",
        "It lights the way through the darkest night,",
        "illuminating our path, the end is in sight.",
    };

    string[] NewWorldLyrics = new string[19]
    {
        "First I opened my eyes",
        "Then I felt such a strange breeze",
        "I had traveled to a world made of blocks",
        "Totally unbeknownst to me",
        "When you play Mine, Mine, Minecraft",
        "Mine, Mine, Minecraft",
        "Mine, Mine, Minecraft",
        "Oh oh oh oh, oh oh oh oh",
        "There were animals all across the land",
        "Villagers working hard hand in hand",
        "There were roses, mountains, and a big blue sea",
        "Even trees as far as the eye could see",
        "How'd this happen?",
        "Why am I here?",
        "Whats my purpose in this place?",
        "Who's that coming?",
        "What am I hearing?",
        "As the night approaches, I should go and hide",
        "There's all sorts of creatures, run with all my might",
    };

    string[] FatedLyrics = new string[29]
    {
        "We broke the ocean right in half, just to be here...",
        "Did you even know, when you looked away?",
        "Too scared to leave, we can’t turn back, will you let us",
        "Survive...?",
        "Where are we now...?",
        "Where are we now...?",
        "Where are we now?",
        "Did we follow a fading light?",
        "Where are we now?",
        "Will you guide us through the night?",
        "Where are we now?",
        "We’ve journeyed...",
        "By land and sea",
        "By land and sea",
        "Where are we now?",
        "It’s not a dream",
        "There’s strength that flows between us, can’t you see?",
        "We’re fated!",
        "We went from lost to feeling found, all around us...",
        "Our fates entwined have paved the way",
        "No longer broken on the ground, we can stand tall",
        "Survive...",
        "Where are we now...?",
        "Where are we now...?",
        "From nothing more",
        "Than hate and war",
        "We’ll make it through together",
        "Where are we now?",
        "Where are we now?",
    };

    string[] TheHerobrineLyrics = new string[62]
    {
        "I aimed for the vein, lead to the lack of a heartbeat",
        "Oh well, best killers can't be choosy",
        "Needed to receive attention for my bravery",
        "Wanted to be left alone in darkness excuse me",
        "Been lusting my brains, and eat them too",
        "And flanking in both ways",
        "Flames made you go boom ‘cause you got located",
        "When it blew; see it was amusing",
        "`Cause all I wanted to do is beat Herobrine the dead beast",
        "Improved it, used it as a tool when I splash speed",
        "Hit the artery (tehe)",
        "With what I strung back was not a mean feat",
        "It was like kicking a bruised king",
        "Demonic 'cause I think I'm getting so evil I don’t think",
        "You’re beginning to lose sleep: one dead, two dead",
        "Seeing postmen and speedy’s like Crazy Craft",
        "But we’re actually scarier than you think",
        "Cause I'm...",
        "Not afraid of the Herobrine",
        "That's completely un-dead",
        "Keep away from the voices, creeps under your bed",
        "We're trying to kill you",
        "Stop wishing us dead",
        "We're going crazy",
        "Yeah, we’re going crazy (crazy)",
        "Well, they’re nothing",
        "Well, they’re nothing",
        "Now, he isn’t usually one to blow it but somebody then told me",
        "To siege with bowmen and don’t blunder it",
        "`Cause you never know when they could all be dead, the sorrow",
        "So I’ll keep pillaging, sometimes I wonder where these mobs spawn from",
        "(Yeah tree shade’ll do wonders.",
        "No wonder you’re losing your army the way you squander.)",
        "Dream-Yoda-le-hee-hun",
        "I think it went wandering off a Ravine",
        "And it stumbled on Herobrine – inventor of mean",
        "Think I need an interdemiensionist",
        "To teleport between me and this monster",
        "And save him from myself and all this bloodshed",
        "`Cause they’re very thin and you hate them killing you",
        "But you can’t master it",
        "My skele bones keep bonking you in the head",
        "Keep blocking, defend my throne, I’m battle talking",
        "I’m just replaying what the dark in my head’s saying",
        "Don’t shoot the messenger, I’m not afraid of the Herobrine",
        "They call us crazy but then there’s division",
        "One day I’ll walk amongst them ‘cause I’m an irregular villain",
        "But until then mobs get killed and I’m respawning straight from",
        "MC, blood gets spilled and I’ll",
        "Take them back to rot in the hay stack",
        "Train every kid who’s born that",
        "Pumped up feeling and shoot to slay ‘em, hack",
        "Said every kid who saw me slay him",
        "I ain’t here to save the fucking village",
        "But if one King out of a hundred pillage",
        "They are going through a struggle, feel it and the relay it straight back",
        "It’s payback, Herobrine falling way back",
        "In the shaft, turn nothing into something, still can make that",
        "Stone into gold, chump, I will spin arrows in a foes back",
        "Maybe they need an axe to hack it, face facts",
        "I’m evil for real, but I’m okay with that",
        "Then again, you’re now afraid of the",
    };

    string[] TurnItUpLyrics = new string[24]
    {
        "What if I wrote this song about you",
        "and it turned out that every word is true?",
        "What if last night I had a vision",
        "where I saw you sitting silent in your room?",
        "So so sick and tired of feeling out of place",
        "Got your headphones on with the boosted bass",
        "You're not alone right now",
        "Just hear my voice cut through\nthe noise when you play this song loud",
        "Turn it up turn it up",
        "Whenever you're fallin' hit play",
        "Turn it up turn it up",
        "If you feel you're too far away",
        "Turn it up turn it up",
        "We all want to feel connected",
        "Like magnets that were pulled too far apart",
        "What if the distance didn't mattee\nand our words could fix all lonely hearts?",
        "Love in the harmony and you find a way",
        "To broadcast to the world the melody that plays",
        "You're not alone right now",
        "Just hear my voice cut through the noise when you play this song loud",
        "Turn it up turn it up",
        "You can start right now break the silence down",
        "Turn it up",
        "You are not alone when you play this loud",
    };

    string[] Users = new string[]
    {
        "Limeboy",
        "Eltrick",
        "BananaLord",
        "Strike",
        "Jack",
        "Weird",
        "Finder",
        "CrunchyBot",
        "Cooldoom",
        "Pruz",
        "Kavinkul",
        "Blanana",
        "River",
        "LordKabewm",
        "Legend",
        "RockDood",
        "Kat",
        "Timwi",
        "Red",
        "Emik",
        "Qkrisi"
    };

    int chosensong;
    int[] currentchosenuser = new int[4];
    int[] answer = new int[4];

    void Awake()
    {
        _moduleId = _moduleIdCounter++;
        submit.OnInteract += delegate ()
        {
            checkans();
            return false;
        };
        for (int i = 0; i < 4; i++)
        {
            int j = i;
            Button[i].OnInteract += delegate ()
            {
                ChangeImage(j);
                return false;
            };
        }
    }

    void Start()
    {
        init();
    }

    void init()
    {
        currentchosenuser = new int[] { 0, 0, 0, 0 };
        chosensong = rnd.Range(0, 14);
        int n;
        switch (chosensong)
        {
            case 0://revenge
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Revenge", _moduleId);
                n = rnd.Range(0, 45);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = RevengeLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 1://take back the night
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Take Back The Night", _moduleId);
                n = rnd.Range(0, 14);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = TakeBackTheNightLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 2://fallen kingdom
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Fallen Kingdom", _moduleId);
                n = rnd.Range(0, 25);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = FallenKingdomLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 3://find the pieces
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Find the Pieces", _moduleId);
                n = rnd.Range(0, 12);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = FindThePiecesLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 4://dragonhearted
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Dragonhearted", _moduleId);
                n = rnd.Range(0, 23);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = DragonheartedLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 5://tnt
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: TNT", _moduleId);
                n = rnd.Range(0, 31);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = TNTLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 6://running to never
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Running to Never", _moduleId);
                n = rnd.Range(0, 23);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = RunningToNeverLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 7://mine diamonds
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Mine Diamonds", _moduleId);
                n = rnd.Range(0, 26);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = MineDiamondsLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 8://u can find it
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: You Can Find It", _moduleId);
                n = rnd.Range(0, 19);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = YouCanFindItLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 9://level up
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Level Up", _moduleId);
                n = rnd.Range(0, 21);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = LevelUpLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 10://new world
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: New World", _moduleId);
                n = rnd.Range(0, 16);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = NewWorldLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 11://fated
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Fated", _moduleId);
                n = rnd.Range(0, 26);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = FatedLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 12://the herobrine
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: The Herobrine", _moduleId);
                n = rnd.Range(0, 59);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = TheHerobrineLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
            case 13://turn it up
                Debug.LogFormat("[Minecraft Parody #{0}] Chosen song: Turn It Up", _moduleId);
                n = rnd.Range(0, 21);
                for (int i = 0; i < 4; i++)
                {
                    Lyrics_Textbox[i].text = TurnItUpLyrics[i + n];
                    answer[i] = (i + n) % Users.Length;
                }
                break;
        }
        componentbg.material = SongBG[chosensong];
        for (int i = 0; i < 4; i++)
        {
            Debug.LogFormat("[Minecraft Parody #{0}] Lyric {1}: {2}", _moduleId, i + 1, Lyrics_Textbox[i].text);
            UsersSelectionBox[i].material.mainTexture = UsersPFP[0];
        }
    }

    void ChangeImage(int i)
    {
        currentchosenuser[i]++;
        if (currentchosenuser[i] >= Users.Length)
            currentchosenuser[i] = 0;
        UsersSelectionBox[i].material.mainTexture = UsersPFP[currentchosenuser[i]];
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Button[i].transform);
    }


    void checkans()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, submit.transform);
        bool correct = true;
        for (int i = 0; i < 4; i++)
        {
            if (answer[i] == currentchosenuser[i])
                correct = correct && true;
            else correct = correct && false;
            Debug.LogFormat("[Minecraft Parody #{0}] Submitted user {1}: {2}. Correct answer: {3}", _moduleId, i+1, Users[currentchosenuser[i]], Users[answer[i]]);
        }
        if (correct == true)
        {
            GetComponent<KMBombModule>().HandlePass();
            Debug.LogFormat("[Minecraft Parody #{0}] Submission correct. You have defeated the Bomb-brine", _moduleId);
            for (int i = 0; i < 4; i++)
                Lyrics_Textbox[i].text = "UR A MINECRAFT PROFESSIONAL";
        }
        else
        {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Minecraft Parody #{0}] Submission incorrect. AWWWWWWWWWWWWW MAN", _moduleId);
            init();
        }
    }

#pragma warning disable 414
    private string TwitchHelpMessage = "!{0} submit [submit the singers]. !{0} (names) (names) (names) (names) [input the names].Names include: Limeboy, Eltrick, BananaLord, Strike, Jack, Weird, Finder, CrunchyBot, Cooldoom, Pruz, Kavinkul, Blanana, River, LordKabewm, Legend, RockDood, Kat, Timwi, Red, Emik, Qkrisi. Names must have their corresponding letters capitalized.";
#pragma warning restore 414
    int tpreturnvalue(int i, int a)
    {
        if (a < currentchosenuser[i])
            return a + 20;
        else return a;
    }

    IEnumerator ProcessTwitchCommand(string command)
    {
        if (command.Equals("submit"))
            submit.OnInteract();
        else if (command.Equals("cv"))
            yield return null;
        else if (command.Equals("claim"))
            yield return null;
        else if (command.Equals("help"))
            yield return null;
        else if (command.Equals("unclaim"))
            yield return null;
        else if (command.Equals("unview"))
            yield return null;
        else if (command.Equals("player"))
            yield return null;
        else if (command.Equals("show"))
            yield return null;
        else if (command.Equals("unc"))
            yield return null;
        else
        {
            string[] parameters = command.Split(' ');
            if (parameters.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (!Users.Contains(parameters[i]))
                        yield break;
                    for (int j = currentchosenuser[i]; j < tpreturnvalue(i, Array.IndexOf(Users, parameters[i])); j++)
                    {
                        yield return null;
                        Button[i].OnInteract();
                        yield return new WaitForSeconds(0.05f);
                    }
                }
            }
            else yield return "sendtochaterror Please enter all 4 users at the same time.";
        }
        yield return null;
    }
}