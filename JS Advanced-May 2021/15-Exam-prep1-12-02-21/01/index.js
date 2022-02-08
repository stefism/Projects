function solve() {
  let modules = document.querySelector(".modules");
  let addButton = document.querySelector(".form-control button");
  let module = document.querySelector(".form-control select");

  modules.addEventListener('click', (e) => {
    if(e.target.tagName.toLowerCase() == 'button') {
      let currLecture = e.target.parentNode;
      currLecture.remove();

      let moduleDiv = document.getElementById(module.value);
      let moduleUl = moduleDiv.querySelectorAll(`ul li`);

      if(moduleUl.length == 0) {
        moduleDiv.remove();
      }
    }
  });

  addButton.addEventListener("click", (e) => {
    e.preventDefault();

    let lectureName = document.querySelectorAll(".form-control input")[0];
    let date = document.querySelectorAll(".form-control input")[1];

    if (date.value != "" && lectureName.value != "" && module.value != "Select module") {
      let moduleDiv = document.getElementById(module.value);

      if (moduleDiv == null) {
        moduleDiv = CreateModuleDiv(moduleDiv, module);
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

  function CreateModuleDiv(moduleDiv, module) {
    moduleDiv = document.createElement("div");
    moduleDiv.classList.add("module");
    moduleDiv.id = module.value;

    let moduleHeader = document.createElement("h3");
    moduleHeader.textContent = module.value.toUpperCase() + "-MODULE";

    let lecturesUnsortedList = document.createElement("ul");
    lecturesUnsortedList.id = 'unsortedList';

    moduleDiv.appendChild(moduleHeader);
    moduleDiv.appendChild(lecturesUnsortedList);

    modules.appendChild(moduleDiv);
    
    return moduleDiv;
  }

  function appendLectureToModule(date, lectureName, module) {
    let lecturesListItem = document.createElement("li");
    lecturesListItem.classList.add("flex");

    let lectureDescription = document.createElement("h4");

    let [currDate, currTime] = date.value.split('T');
    let [year, month, day] = currDate.split('-');

    let formatedDateWithDash = `${year}/${month}/${day}`;

    lectureDescription.textContent = `${lectureName.value.toUpperCase()} - ${formatedDateWithDash} - ${currTime}`;

    let delButton = document.createElement("button");
    delButton.classList.add("red");
    delButton.textContent = "Del";
    

    lecturesListItem.appendChild(lectureDescription);
    lecturesListItem.appendChild(delButton);

    let lecturesUnsortedList = document.querySelector(`#${module.value} ul`);

    lecturesUnsortedList.appendChild(lecturesListItem);
  }
}