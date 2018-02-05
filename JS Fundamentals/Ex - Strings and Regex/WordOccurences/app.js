function find(input, word) {
    let count = 0;
    let regex = new RegExp("\\b" + word + "\\b", "gi");
    let match = regex.exec(input);

    while (match) {
        count++;
        match = regex.exec(input);
    }

    console.log(count)
}

find('The waterfall was so high, that the child couldn’t see its peak.', 'the');
find('How do you plan on achieving that? How? How can you even think of that?', 'how');