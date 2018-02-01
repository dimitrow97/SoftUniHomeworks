function extractSubsequence(input) {
    let currentBiggestNum = Number.NEGATIVE_INFINITY;
    let arrayLength = input.length;

    for (let i = 0; i < arrayLength; i++) {
        let currentNumber = input.shift();
        if (currentNumber >= currentBiggestNum) {
            currentBiggestNum = currentNumber;
            console.log(currentNumber);
        }
    }
}

extractSubsequence([20, 3, 2, 15, 6, 1]);