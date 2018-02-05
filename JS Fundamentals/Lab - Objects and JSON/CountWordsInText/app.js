function countWords(input) {
    let text = input.join('\n');
    let words = text.split(/[^A-Za-z0-9_]+/)
        .filter(w => w != '');
    let wordsCount = {};
    for (let w of words)
        wordsCount[w] ? wordsCount[w]++ :
            wordsCount[w] = 1;
    return JSON.stringify(wordsCount);
}

console.log(countWords(['JS devs use Node.js for server- side JS.-- JS for devs']));
