function find(input) {
    let variables = [];
    let regex = /\b_([a-zA-Z0-9]+)\b/g;
    let match = regex.exec(input);

    while (match) {
        variables.push(match[1]);
        match = regex.exec(input);
    }

    console.log(variables.join(","));
}

find('The _id and _age variables are both integers.');
find('Calculate the _area of the _perfectRectangle object.');
find('__invalidVariable _evenMoreInvalidVariable_ _validVariable');