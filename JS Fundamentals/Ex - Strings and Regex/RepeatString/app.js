function repeat(string, n) {
    let result = '';
    for (let i = 0; i < n; i++)
        result += string;
    console.log(result);
}

repeat('repeat', 5);