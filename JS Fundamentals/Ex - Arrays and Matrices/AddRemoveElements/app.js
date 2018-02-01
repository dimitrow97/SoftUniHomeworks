function addAndRemoveElementsFromArray(input) {
    let result = [];

    for (let number = 1; number <= input.length; number++) {
        if (input[number-1] == 'add') {
            result.push(number);
        } else {
            result.pop();
        }        
    }

    if (result.length == 0) {
        console.log('Empty');
    } else {
        result.forEach(element => console.log(element));
    }
}

addAndRemoveElementsFromArray(['add', 'add', 'remove', 'add', 'add']);