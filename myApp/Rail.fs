module myApp.Rail

open System

    type StationID = 
        | Name of string
        | Id of int
        | None // will remove this once createStation is properly implemented

    type Station = {name : string; id: StationID; lat : double ; lon : double}

    let createStation name lat lon =
        {name = name; id = Name(name) ; lat = lat; lon = lon}

    type Line = 
        {name : string; stops : List<Station>}

        member self.stationIndex (s: Station) : option<int> = 
            match self.stops |> List.contains s with
            | true -> self.stops |> List.tryFindIndex (fun x -> x = s)
            | _ -> option<int>.None

    // takes the first and last stop of a line; along with a name -> outputs a Line
    let createLine name first last = 
        let stopsToLine = List.concat [[first];[last]]
        {name = name; stops = stopsToLine}

    // here, 'after' refers the previous station to which you are adding the new station
    // You may simply pass the index of line[i] as 'after' ; or add after an explicit Station
    let addStop (line: Line) (after: Station) (newStop: Station) =
        match line.stationIndex after with
        | Some i -> let n = line.stops |> List.splitAt (i+1) 
                    option<Line>.Some {name = line.name ; stops = List.concat [fst n; [newStop] ; snd n]}
        | _ -> option<Line>.None
        
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
        
