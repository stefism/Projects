import React from 'react';
import ReactDOM from 'react-dom';

import Calendar from 'react-calendar';
import 'react-calendar/dist/Calendar.css';

class App extends React.Component {
  // const [value, onChange] = useState(new Date());
  constructor(props) {
    super(props);
    this.daysRef = React.createRef();
    this.state = {
      daysRef: this.daysRef = React.createRef()
    }
  }

  componentDidMount() {
    let calendarElement = this.updateCalendarElement();

    console.log(calendarElement);

    let nextMont = ReactDOM
      .findDOMNode(this.daysRef.current)
      .getElementsByClassName('react-calendar__navigation__next-button')[0];

      console.log(nextMont)

      nextMont.addEventListener('click', this.updateCalendarElement)
  }

  updateCalendarElement() {
    let calendarElement = ReactDOM
      .findDOMNode(this.daysRef.current)
      .getElementsByClassName('react-calendar__month-view__days__day');

    for (let i = 0; i < calendarElement.length; i++) {
      const element = calendarElement[i];
      let div = document.createElement('div');
      div.innerHTML = 'Price: ';
      element.appendChild(div);
    }
    return calendarElement;
  }

  render() {
    return (
      <div>
        <Calendar ref={this.daysRef}
        // onChange={this.updateCalendarElement}
        // value={value}
        />
      </div>
    )
  }
}

export default App;
