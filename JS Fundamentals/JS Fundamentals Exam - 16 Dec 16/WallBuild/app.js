function solve(input) {
    let concrete = [];

    while (checkProgress(input)) {
        let concretePerDay = 0;
        let tempNum = checkProgress(input);
        input = addFeet(input);
        concretePerDay = tempNum * 195;
        concrete.push(concretePerDay);
    }

    console.log(concrete.join(', '));
    console.log((sumArray(concrete) * 1900) + ' pesos');

    function sumArray(arr) {
        let sum = 0;
        for (let num in arr)
            sum += arr[num];
        return sum;
    }

    function addFeet(arr) {
        for (let i = 0; i < arr.length; i++)
            if (arr[i] != 30) arr[i]++;
        return arr;
    }

    function checkProgress(arr) {
        let result = 0;
        for (let i = 0; i < arr.length; i++)
            if (arr[i] != 30) result++;
        return result;
    }
}

solve([21, 25, 28]);
