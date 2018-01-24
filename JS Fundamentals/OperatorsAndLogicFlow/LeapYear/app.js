function check(year) {
    let leap = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    console.log(leap ? "yes" : "no");    
}

check(2000);