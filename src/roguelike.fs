#if INTERACTIVE
#r "../lib/mono-curses.dll"
#endif

open Unix.Terminal
    
let rec loop input =
    match input with
    | 27 -> 0
    | _  -> Curses.move (10, 10)
            Curses.addch (int '@')
            loop <| Curses.getch ()

let setup =
    // Initialisation
    Curses.initscr ()
    Curses.cbreak () 
    Curses.noecho () 
    Curses.nonl ()   
    // Config
    Curses.Window.Standard.intrflush (false)
    Curses.Window.Standard.keypad (true) 

[<EntryPoint>]
let main argv =  
    setup // initialise Curses
    
    Curses.addstr ("""Welcome to the game.
Press any key to start.
If you want to quit press 'q' or 'Q'""")
    Curses.refresh ()                   

    let input = Curses.getch ()
    loop input

    // Shutdown
    Curses.endwin ()
    0
