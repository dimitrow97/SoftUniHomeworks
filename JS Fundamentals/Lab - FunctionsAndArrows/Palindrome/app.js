function check(input) {
    function reverse(s) {
        return s.split("").reverse().join("");
    }
    let reversedWord = reverse(input);
    if (reversedWord === input)
        console.log("true");
    else console.log("false");
}

check("haha");
check("racecar");