function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let tableData = Array.from(document.querySelectorAll('.container tbody td'));
      let searchText = document.getElementById('searchField');

      tableData.forEach(cell => {
         let currRow = cell.parentElement;
         currRow.classList.remove('select');
      });

      tableData.map(cell => {
         let currRow = cell.parentElement;

         if (cell.textContent.includes(searchText.value)) {
            currRow.classList.add('select');
         }
      });

      searchText.value = '';
   }
}