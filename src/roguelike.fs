open System
// open Mono
open Unix.Terminal

let curse = 
    // Standard Init sequence
    Curses.initscr ()
    Curses.cbreak ()
    Curses.noecho ()
    // Recommended
    Curses.nonl ()

    Curses.addstr ("acción")
    Curses.refresh ()
    Curses.getch ()
    
    Curses.Window.Standard.intrflush (false)
    Curses.Window.Standard.keypad (true)
    // Shutdown
    Curses.endwin ()
    
[<EntryPoint>]
let main argv = 
    printfn "Hello World" 
    curse
    Console.ReadLine() |> ignore
    0
