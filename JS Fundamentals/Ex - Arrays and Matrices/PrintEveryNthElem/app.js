function printNthElem(input) {
    let step = Number(input.pop());

    input.filter((element, index) => index % step == 0).forEach(element => console.log(element));
}
printNthElem([5, 20, 31, 4, 20, 2]);