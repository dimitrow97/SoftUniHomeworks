function modifyAverage(number) {
    function getAverage(number) {
        let sum = 0, count = 0;
        while (number) {
            let digit = number % 10;
            number = Math.floor(number / 10);
            sum += digit;
            count++;
        }

        return sum / count;
    }

    let average = getAverage(number);

    let addNine = x => x + "9";

    while (average <= 5) {
        number = addNine(number);
        average = getAverage(number);
    }

    console.log(number);
}

modifyAverage(101);