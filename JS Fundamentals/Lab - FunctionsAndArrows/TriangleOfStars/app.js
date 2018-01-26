function draw(input) {
    function stars(count) {
        console.log('*'.repeat(count));
    }
    for (let i = 1; i <= input; i++)
        stars(i);
    for (let i = input - 1; i > 0; i--)
        stars(i);
}

draw(1);
draw(5);