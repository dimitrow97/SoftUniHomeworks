function draw(input) {
    function stars(count) {
        console.log('* '.repeat(count));
    }
    for (let i = 1; i <= input; i++)        
        stars(input);    
}

draw(5);
draw(1);