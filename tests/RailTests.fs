module Tests

open myApp.Rail
open System
open Xunit

let station1 = {
        name = "São Bento";
        id = Name("São Bento");
        lat = 5.0;
        lon = 5.0
    }

let station2 = {
    name = "Orientale";
    id = Id(7);
    lat = 4.0;
    lon = 1.0;
}

let station3 = {
    name = "Lisboa Campanhã";
    id = Name("Lisboa Campanhã");
    lat = 3.5;
    lon = 1.1
}

let station4 = {
    name = "Matosinhos";
    id = None;
    lat = 9.2;
    lon = 0.4
}

let line1 = {
    name = "primeira linha";
    stops = [
        station1;
        station2;
        station3;
        station4
    ]
}

let station5 = createStation "Colisseu Centro" 33.2 2.3

let station6 = {
        name = "Matosinhos";
        id = None;
        lat = 9.2;
        lon = 0.4
    }

let station7 = createStation "Matosinhos" 9.2 0.4

[<Fact>]
let ``createStationTest1`` () =
    let name, id, lat, lon = "São Bento", 12, 5.0, 5.0
    let expectedStation : Station = {
        name = name;
        id = Name(name);
        lat = 5.0;
        lon = 5.0
    }
    let newStation = createStation name lat lon
    Assert.True(newStation.Equals(expectedStation))

[<Fact>]
let ``createStationTest2`` () =
    let name, lat, lon = "Lisboa Centro", 4.0, -2.0
    let expectedStation : Station = {
        name = name;
        id = Name(name);
        lat = 4.0;
        lon = -2.0
    }
    let actualStation = createStation name lat lon
    Assert.True(actualStation.Equals(expectedStation))

[<Fact>]
let ``createLineTest1`` () = 
    let expectedStation = createLine "line 1" station1 station2
    let actualStation = {
        name = "line 1";
        stops = [station1; station2]
    }
    Assert.True(actualStation.Equals(expectedStation))

[<Fact>]
let ``createLineTest2`` () =
    let expectedStation = createLine "line 1" station1 station3
    let actualStation = {
        name = "line 1";
        stops = [station1; station2]
    }
    Assert.False(actualStation.Equals(expectedStation))

[<Fact>]
let ``addStopTest1`` () =
    let expected = line1
    let start = createLine "primeira linha" station1 station4
    let step2 = addStop start station1 station3
    let step3 = step2.Value
    let step4 = addStop step3 station1 station2
    let actual = step4.Value
    Assert.Equal(expected, actual)

// [<Fact>]
// let ``addStopTest2`` () =
//     failwith "not implemented yet"