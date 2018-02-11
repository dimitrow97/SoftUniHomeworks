function solve(input) {
    let pattern = /(?:(?:(?:<svg>\s*<cat>\s*<text>)(?:.+))(?:\s*\[\s*)(.+)(?:\s*]\s*)(?:(?:\s*<\/text>\s*<\/cat>))(?:\s*(?:<cat>)(?:.+)<\/cat>\s*<\/svg>))/g;
    let numbersRegex = /(?:\s*<g>\s*<val>\s*(-\d+|\d+)+\s*<\/val>\s*(-\d+|\d+)+\s*<\/g>)\s*/g;
    let svgCheck = /<svg>\s*[^.]+<\/svg>/g;
    let patterCheck = /(?:(?:(?:<svg>\s*<cat>\s*<text>)(?:.+))(?:\s*\[\s*)(.+)(?:\s*]\s*)(?:(?:\s*<\/text>\s*<\/cat>))(?:\s*(?:<cat>)(?:.+)<\/cat>\s*<\/svg>))/g;
    let surveyFound = 0;
    let ratings = [];

    if (svgCheck.exec(input)) {
        if (pattern.exec(input)) {
            let match = patterCheck.exec(input);    
            let survey = match[1];

            let matchNumbers = numbersRegex.exec(input);
            let rating = {
                rating: Number(matchNumbers[1]), count: Number(matchNumbers[2])
            };
            ratings.push(rating);
            while (matchNumbers) {
                matchNumbers = numbersRegex.exec(input);
                if (matchNumbers != null) {
                    if ((matchNumbers[1] >= 1 && matchNumbers[1] <= 10) && matchNumbers[2] >= 0) {
                        rating = { rating: Number(matchNumbers[1]), count: Number(matchNumbers[2]) };
                        ratings.push(rating);
                    }
                }
            }

            let finalRating = 0.0;
            let totalCount = 0;
            for (let r in ratings) {
                finalRating += (ratings[r].rating * ratings[r].count);
                totalCount += ratings[r].count;
            }

            finalRating /= totalCount;

            if (surveyFound == 0) console.log(survey.trim() + ': ' + Math.round(finalRating * 100) / 100);
        }
        else console.log('Invalid format');
    }
    else console.log('No survey found');
}

solve('<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>3</g><g><val>4</val>10</g><g><val>5</val>7</g></cat></svg> <p>Some more random text</p>');
solve('<svg><cat><text>Which is your favourite meal from our selection?</text></cat><cat><g><val>Fish</val>15</g><g><val>Prawns</val>31</g><g><val>Crab Langoon</val>12</g><g><val>Calamari</val>17</g></cat></svg>');
solve('<p>How do you suggest we improve our service?</p><p>More tacos.</p><p>It\'s great, don\'t mess with it!</p><p>I\'d like to have the option for delivery</p>');
solve('<svg><cat><text>How do you rate the special menu? [Food - Special]</text></cat><cat><g><val>1</val>5</g><g><val>5</val>13</g><g><val>10</val>22</g></cat></svg>');
solve('<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>-1</g><g><val>15</val>10</g><g><val>5</val>7</g></cat></svg> <p>Some more random text</p>');