function conRev(input) {
    let result = '';
    for (let i = input.length - 1; i >= 0; i--) {
        let temp = input[i].split('').reverse().join('');
        result += temp;
    }
    console.log(result);
}

conRev(['I', 'am', 'student']);