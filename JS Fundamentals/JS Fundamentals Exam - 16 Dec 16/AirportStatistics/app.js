function solve(input) {
    let airports = [];
    let planes = [];

    for (let line in input) {
        let splitted = input[line].split(' ');
        if (checkForPlane(planes, splitted[0])) {
            if (checkIfPlaneLanded(planes, splitted[0])) {
                if (splitted[3] == 'depart') {
                    if (checkForAirport(airports, splitted[1])) {
                        let airport = getAirport(airports, splitted[1]);
                        let airportPlanes = airport.planes;
                        let plane = getPlane(planes, splitted[0]);

                        plane.isLanded = false;
                        if (!checkForPlane(airportPlanes, plane.name))
                            airportPlanes.push(plane);
                        airport.planes = airportPlanes;
                        airport.departures += parseInt(splitted[2]);
                        replaceAirport(airports, airport.name, airport);
                        replacePlane(planes, plane.name, plane);
                    }
                    else {
                        let airport = { name: splitted[1], arrivals: 0, departures: parseInt(splitted[2]) };
                        let tempPlanes = [];
                        let plane = getPlane(planes, splitted[0]);

                        plane.isLanded = false;
                        tempPlanes.push(plane);
                        airport.planes = tempPlanes;
                        airports.push(airport);
                        replacePlane(planes, plane.name, plane);
                    }
                }
            }
            else {
                if (splitted[3] == 'land') {
                    if (checkForAirport(airports, splitted[1])) {
                        let airport = getAirport(airports, splitted[1]);
                        let airportPlanes = airport.planes;
                        let plane = getPlane(planes, splitted[0]);

                        plane.isLanded = true;
                        if (!checkForPlane(airportPlanes, plane.name))
                            airportPlanes.push(plane);
                        airport.planes = airportPlanes;
                        airport.arrivals += parseInt(splitted[2]);
                        replaceAirport(airports, airport.name, airport);
                        replacePlane(planes, plane.name, plane);
                    }
                    else {
                        let airport = { name: splitted[1], arrivals: parseInt(splitted[2]), departures: 0 };
                        let tempPlanes = [];
                        let plane = getPlane(planes, splitted[0]);

                        plane.isLanded = true;
                        tempPlanes.push(plane);
                        airport.planes = tempPlanes;
                        airports.push(airport);
                        replacePlane(planes, plane.name, plane);
                    }
                }
            }
        }
        else {
            if (splitted[3] == 'land') {
                let plane = { name: splitted[0], isLanded: true };
                planes.push(plane);
                if (checkForAirport(airports, splitted[1])) {
                    let airport = getAirport(airports, splitted[1]);
                    let airportPlanes = airport.planes;

                    airportPlanes.push(plane);
                    airport.planes = airportPlanes;
                    airport.arrivals += parseInt(splitted[2]);
                    replaceAirport(airports, airport.name, airport);
                }
                else {
                    let airport = { name: splitted[1], arrivals: parseInt(splitted[2]), departures: 0 };
                    let tempPlanes = [];

                    tempPlanes.push(plane);
                    airport.planes = tempPlanes;
                    airports.push(airport);
                }
            }
        }
    }

    console.log(printPlanesLeft(planes));
    console.log(printAirports(airports));

    function comparePlanes(a, b) {
        var nameA = a.name.toLowerCase(), nameB = b.name.toLowerCase();
        if (nameA < nameB) return -1;
        if (nameA > nameB) return 1;
        return 0;
    }

    function compareAirports(a, b) {
        if (a.arrivals < b.arrivals) return 1;
        if (a.arrivals > b.arrivals) return -1;
        if (a.arrivals == b.arrivals) {
            var nameA = a.name.toLowerCase(), nameB = b.name.toLowerCase();
            if (nameA < nameB) return -1;
            if (nameA > nameB) return 1;
            return 0;
        }
        return 0;
    }

    function printAirports(arr) {
        let result = '';
        arr.sort(compareAirports);
        for (let a in arr) {
            result += arr[a].name + '\n';
            result += 'Arrivals: ' + arr[a].arrivals + '\n';
            result += 'Departures: ' + arr[a].departures + '\n';
            result += 'Planes:';
            let temp = arr[a].planes;
            temp.sort(comparePlanes);
            for (let p in temp) {
                result += '\n-- ' + temp[p].name;
            }
            result += '\n';
        }
        return result;
    }

    function printPlanesLeft(arr) {
        let result = '';
        result += 'Planes left:';
        arr.sort(comparePlanes);
        for (let plane in arr) {
            if (arr[plane].isLanded == true) result += '\n- ' + arr[plane].name;
        }
        return result;
    }

    function checkIfPlaneLanded(arr, name) {
        let result = true;
        let plane;
        for (let p in arr) {
            if (arr[p].name == name) plane = arr[p];
        }
        if (plane.isLanded != true) result = false;
        return result;
    }

    function getPlane(arr, name) {
        let result;
        for (let plane in arr) {
            if (arr[plane].name == name) result = arr[plane];
        }
        return result;
    }

    function checkForPlane(arr, name) {
        let result = false;
        for (let plane in arr) {
            if (arr[plane].name == name) result = true;
        }
        return result;
    }

    function checkForAirport(arr, name) {
        let result = false;
        for (let airport in arr) {
            if (arr[airport].name == name) result = true;
        }
        return result;
    }

    function getAirport(arr, name) {
        let result;
        for (let airport in arr) {
            if (arr[airport].name == name) result = arr[airport];
        }
        return result;
    }

    function replaceAirport(arr, name, newAirport) {
        for (let airport in arr) {
            if (arr[airport].name == name) arr[airport] = newAirport;
        }
    }

    function replacePlane(arr, name, newPlane) {
        for (let plane in arr) {
            if (arr[plane].name == name) arr[plane] = newPlane;
        }
    }
}

solve([
    "Boeing474 Madrid 300 land",
    "AirForceOne WashingtonDC 178 land",
    "Airbus London 265 depart",
    "ATR72 WashingtonDC 272 land",
    "ATR72 Madrid 135 depart"
]);
console.log('--------------------------------');
solve([
    "Airbus Paris 356 land",
    "Airbus London 321 land",
    "Airbus Paris 213 depart",
    "Airbus Ljubljana 250 land"
]);
console.log('-------------------------------');
solve([
    'Airbus London 100 land',
    'Airbus Paris 200 depart',
    'Airbus Madrid 130 depart',
    'Airbus Lisbon 403 depart',
    'Airbus Moscow 505 depart',
    'Airbus Sofia 16 depart'
]);