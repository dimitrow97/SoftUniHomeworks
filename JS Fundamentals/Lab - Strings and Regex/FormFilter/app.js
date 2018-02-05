function formFiller(username, email, phone, input) {
    for (let line of input) {
        console.log(line.replace(/<![A-Za-z]+!>/g, username).replace(/<@[A-Za-z]+@>/g, email).replace(/<\+[A-Za-z]+\+>/g, phone));
    }
}