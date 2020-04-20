function solve() {
    let searchBtn = document.getElementById('searchBtn')
    searchBtn.addEventListener('click', selectFoundedRow)

    let searchField = document.getElementById('searchField')

    function selectFoundedRow() {
        clearSelectFromTableRow()

        let searchedString = searchField.value

        for (let tableRow = 1; tableRow <= 5; tableRow++) {
            let currentTableRow = document.querySelector(`body > table > tbody > tr:nth-child(${tableRow})`)

            for (let tableItem = 1; tableItem <= 3; tableItem++) {
                let currentTableItem = document.querySelector(`body > table > tbody > tr:nth-child(${tableRow}) > td:nth-child(${tableItem})`)

                if(currentTableItem.innerHTML.includes(searchedString)){
                    currentTableRow.classList.add('select')
                    break
                }
            }
        }

        searchField.value = ''
    }

    function clearSelectFromTableRow() {
        for (let tableRow = 1; tableRow <= 5; tableRow++) {
            let currentTableRow = document.querySelector(`body > table > tbody > tr:nth-child(${tableRow})`)
            currentTableRow.classList.remove('select')
        }
    }
}