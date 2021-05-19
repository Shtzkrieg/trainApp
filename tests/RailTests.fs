module Tests

open myApp.Rail
open System
open Xunit

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