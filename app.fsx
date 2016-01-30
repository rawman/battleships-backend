#r "packages/Suave/lib/net40/Suave.dll"

open System
open Suave                 // always open suave
open Suave.Web             // for config
open System.Net

printfn "initializing script..."

let config = 
    let port = System.Environment.GetEnvironmentVariable("PORT")
    let ip127  = IPAddress.Parse("127.0.0.1")
    let ipZero = IPAddress.Parse("0.0.0.0")

    { defaultConfig with 
        logger = Logging.Loggers.saneDefaultsFor Logging.LogLevel.Verbose
        bindings=[ (if port = null then HttpBinding.mk HTTP ip127 (uint16 8080)
                    else HttpBinding.mk HTTP ipZero (uint16 port)) ] }

startWebServer config (Successful.OK "Hello from Sauve!")
printfn "exiting server..."


