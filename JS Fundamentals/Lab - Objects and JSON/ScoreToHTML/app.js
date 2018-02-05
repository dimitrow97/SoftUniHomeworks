function scoreToHtml(inputJsonString) {
    let input = JSON.parse(inputJsonString);

    let output = '<table>\n';
    output += '  <tr>';
    for (let key of Object.keys(input[0])) {
        output += `<th>${escaping(key)}</th>`
    }
    output += '</tr>\n';


    for (let obj of input) {
        output += '  <tr>';
        for (let key of Object.keys(obj)) {
            output += `<td>${escaping(obj[key].toString())}</td>`;
        }
        output += '</tr>\n';
    }
    output += '</table>';

    console.log(output);

    function escaping(line) {
        return line.replace(/&/g, '&amp;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/</g, '&lt;')
            .replace(/'/g, '&#39;');
    }
}