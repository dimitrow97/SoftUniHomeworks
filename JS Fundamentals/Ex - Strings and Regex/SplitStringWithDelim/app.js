function splitString(string, delim) {
    let result = string.split(delim);
    for (let elem in result)
        console.log(result[elem]);
}

splitString('http://platform.softuni.bg', '.');