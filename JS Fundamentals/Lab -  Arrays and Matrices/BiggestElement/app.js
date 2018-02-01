function solve(arr) {
    var largest = Number.NEGATIVE_INFINITY;
    for (var i = 0; i < arr.length; i++)
        for (var j = 0; j < arr[i].length; j++)
            if (largest < arr[i][j])
                largest = arr[i][j];


    return largest;
}