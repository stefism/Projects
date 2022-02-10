function solve() {
  let modules = document.querySelector('.modules');
  let addButton = document.querySelector('.form-control button');
  let module = document.querySelector('select[name="lecture-module"]');

  modules.addEventListener('click', (e) => {
    if(e.target.tagName.toLowerCase() == 'button') {
      let currLecture = e.target.parentNode;
      
      // let moduleDiv = currLecture.parentNode.parentNode;
      let moduleDiv = currLecture.closest('.module'); //За да не пишем parentNode.parentNode няколко пъти, .closest обикаля на горе по дървото и търси първото с указания селектор. В случая първото е div тага, който има клас .module. Върши същата работа като горното.
      let moduleUl = moduleDiv.querySelectorAll(`ul li`);

      if(moduleUl.length == 1) {
        moduleDiv.remove();
      }

      currLecture.remove();
    }
  });

  addButton.addEventListener('click', (e) => {
    e.preventDefault();

    let lectureName = document.querySelector('input[name="lecture-name"]');
    let date = document.querySelector('input[name="lecture-date"]');

    if (date.value != '' && lectureName.value != '' && module.value != 'Select module') {
      let moduleDiv = document.getElementById(module.value);

      if (moduleDiv == null) {
        moduleDiv = createModuleDiv(moduleDiv, module);
      }

      appendLectureToModule(date, lectureName, module);

      reorderListItemsByDate(moduleDiv);
    }
  });

  function reorderListItemsByDate(moduleDiv) {
    let ul = moduleDiv.querySelector(`#${moduleDiv.id} ul`);
    let listItems = Array.from(moduleDiv.querySelectorAll('#unsortedList li'));

    listItems = listItems.sort((a, b) => {
      return a.firstChild.textContent.split(' - ')[1].localeCompare(b.firstChild.textContent.split(' - ')[1]);
    });

    listItems.forEach(i => ul.appendChild(i));
  }

  function createModuleDiv(moduleDiv, module) {
    moduleDiv = document.createElement('div');
    moduleDiv.classList.add('module');
    moduleDiv.id = module.value;

    let moduleHeader = document.createElement('h3');
    moduleHeader.textContent = module.value.toUpperCase() + '-MODULE';

    let lecturesUnsortedList = document.createElement('ul');
    lecturesUnsortedList.classList.add('unsortedList');

    moduleDiv.appendChild(moduleHeader);
    moduleDiv.appendChild(lecturesUnsortedList);

    modules.appendChild(moduleDiv);
    
    return moduleDiv;
  }

  function appendLectureToModule(date, lectureName, module) {
    let lecturesListItem = document.createElement('li');
    lecturesListItem.classList.add('flex');

    let lectureDescription = document.createElement('h4');

    let [currDate, currTime] = date.value.split('T');
    currDate = currDate.replaceAll('-', '/');
    //currDate = currDate.replace(/-/g, '/'); //Мега хитро. Еквивалент на горното но с регекс.

    lectureDescription.textContent = `${lectureName.value.toUpperCase()} - ${currDate} - ${currTime}`;

    let delButton = document.createElement('button');
    delButton.classList.add('red');
    delButton.textContent = 'Del';
    
    lecturesListItem.appendChild(lectureDescription);
    lecturesListItem.appendChild(delButton);

    let lecturesUnsortedList = document.querySelector(`#${module.value} ul`);

    lecturesUnsortedList.appendChild(lecturesListItem);
  }
}