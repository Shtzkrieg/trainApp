module myApp.Rail

open System

    type StationID = 
        | Name of string
        | Id of int
        | None // will remove this once createStation is properly implemented

    type Station = {name : string; id: StationID; lat : double ; lon : double}

    let createStation name lat lon =
        {name = name; id = Name(name) ; lat = lat; lon = lon}

    type Line = {name : string; stops : List<Station>}

    // takes the first and last stop of a line; along with a name -> outputs a Line
    let createLine name first last = 
        let stopsToLine = List.concat [[first];[last]]
        {name = name; stops = stopsToLine}

    // here, after refers the previous station to which you are adding the new station
    let addStop (line: Line) (after: Station) (newStop: Station) = 
        failwith "not implemented yet"
        let i =
            match line.stops |> List.contains after with
                | true -> line.stops |> List.findIndex (fun x -> x = after)
                | _ -> -1
        if i > -1 then
            let n =
                line.stops
                |> List.splitAt i
            let newLine = 
                {name = line.name ; stops = List.concat [fst n; [newStop] ; snd n]} // needs to update in database ; nyi
            let responseT = "successfuly created line"
            printfn $"{responseT}"
        else
            failwith "given station does not exist; new station cannot be
                      added at a station that is not in the given line"

    // attempts to store a created line, returns a string that indicates whether 
    // that line exists already or was successfully created
    let storeLine (line: Line) =
        failwith "not implemented yet"
        if line.name.Length > 0 then
            let conn = new Data.SQLite.SQLiteConnection("line.db")
            printf "the connection string is %s" conn.ConnectionString
            conn.Close()
        else
            printf "nada"
        
