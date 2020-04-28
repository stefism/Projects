function deleteByEmail() {
    let tableBody = document.getElementsByTagName('tbody')[0]
    let inputField = document.getElementsByTagName('input')[0]
    let result = document.getElementById('result')
    //debugger
    for (let tableRow = 0; tableRow < tableBody.rows.length; tableRow++) {
        let currentRow = tableBody.rows[tableRow]

        if(currentRow.cells[1].innerText === inputField.value){
            result.innerText = 'Deleted.'
            currentRow.remove()
        } else {
            result.innerText = 'Not found.'
        }
        //debugger
    }


    console.log('TODO:...');
}