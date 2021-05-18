module myApp.Rail

open System

    type Station = {name : string; id: option<int>; lat : double ; lon : double}

    let createStation name lat lon =
        {name = name; id = None ; lat = lat; lon = lon}

    type Line = {name : string; stops : List<Station>}

    let createLine name first last = 
        let stopsToLine = List.concat [[first];[last]]
        {name = name; stops = stopsToLine}

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
        
