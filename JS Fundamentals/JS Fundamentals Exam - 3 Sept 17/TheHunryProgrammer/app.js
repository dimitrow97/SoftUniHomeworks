function solve(food, commands) {
    let mealsEaten = 0;
    for (let c in commands) {
        if (commands[c].startsWith('Add')) {
            let command = commands[c].split(' ');
            if (command.length != 2) continue;
            food.unshift(command[1]);
        }
        else if (commands[c].startsWith('Shift')) {
            let command = commands[c].split(' ');
            if (command.length != 3) continue;
            if (parseInt(command[1]) < 0 || parseInt(command[1]) > (food.length - 1) || parseInt(command[2]) < 0 || parseInt(command[2]) > (food.length - 1) || parseInt(command[1]) == parseInt(command[2])) continue;
            let temp = food[parseInt(command[1])];
            food[parseInt(command[1])] = food[parseInt(command[2])];
            food[parseInt(command[2])] = temp;
        }
        else if (commands[c].startsWith('Consume')) {
            let command = commands[c].split(' ');
            if (command.length != 3) continue;
            if (parseInt(command[1]) < 0 || parseInt(command[1]) >= (food.length - 1) || parseInt(command[1]) > parseInt(command[2]) || parseInt(command[2]) <= 0 || parseInt(command[2]) > (food.length - 1) || parseInt(command[1]) == parseInt(command[2])) continue;
            let temp = [];
            for (let i = 0; i < food.length; i++) {
                if (i < parseInt(command[1]) || i > parseInt(command[2]))
                    temp.push(food[i]);
                else mealsEaten++;
            }
            food = temp;
            console.log('Burp!');
        }
        else if (commands[c] == 'Serve') {
            if(food.length != 0)
                console.log(food.pop() + ' served!');
        }
        else if (commands[c] == 'Eat') {
            if (food.length != 0) {
                console.log(food.shift() + ' eaten');
                mealsEaten++;
            }
        }
        else if (commands[c] == 'End') break;
        else continue;
    }

    console.log(food.length > 0 ? 'Meals left: ' + food.join(', ') : 'The food is gone');
    console.log('Meals eaten: ' + mealsEaten);
}

solve(['fries', 'fish', 'beer', 'chicken',
    'beer', 'eggs'],
    ['Add spaghetti',
        'Shift 0 1',
        'Consume 1 4',
        'End']);console.log('--------------------------');solve(['chicken', 'steak', 'eggs'],
    ['Serve',
        'Eat',
        'End',
        'Consume 0 1']);console.log('--------------------------');solve(['carrots', 'apple', 'beet'],
    ['Consume 0 2',
        'End']);