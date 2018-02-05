function startsWith(string, subStr) {
    let result = string.startsWith(subStr);
    console.log(result);
}

startsWith('Marketing Fundamentals, starting 19/10/2016', 'Marketing Fundamentals, sta');
startsWith('Marketing Fundamentals, starting 19/10/2016', 'marketing Fundamentals, sta');