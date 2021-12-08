function generateReport() {
    const headersCheckboxes = document.querySelectorAll('input');
    const tableRows = document.querySelectorAll('tbody tr');

    console.log(tableRows);
    let checkedIndexes = [];

    headersCheckboxes.forEach((h, i) => {
        if (h.checked) {
            checkedIndexes.push(i);
        }
        console.log(h, h.checked, i);
    });

    let result = [];

    for(const row of tableRows){
        const currTableData = row.querySelectorAll('td');
        let rowObject = {};

        currTableData.forEach((data, index) => {
            if(checkedIndexes.includes(index)){
                rowObject[[headersCheckboxes[index].name]] = data.textContent;
            }
        });
        
        result.push(rowObject);
    }

    let stringResult = JSON.stringify(result);

    let output = document.getElementById('output');
    
    output.textContent = stringResult;

    console.log(stringResult);
}   