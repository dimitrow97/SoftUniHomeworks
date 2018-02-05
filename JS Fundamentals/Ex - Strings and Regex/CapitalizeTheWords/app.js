function capitalizeWords(string) {
    let splitInput = string.split(' ');
    let result = [];
    for (let elem in splitInput) {
        let temp = splitInput[elem].charAt(0).toUpperCase() + splitInput[elem].substring(1).toLowerCase();
        result.push(temp);
    }
    console.log(result = result.join(' '));
}

capitalizeWords('Was that Easy? tRY thIs onE for SiZe!')