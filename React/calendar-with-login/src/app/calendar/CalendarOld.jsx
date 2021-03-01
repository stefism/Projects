import React, { useState, useEffect } from "react";
import moment from "moment";
import Header from "./header";
import "./styles.css";

export default function Calendar({ value, onChange }) {
  const [calendar, setCalendar] = useState([]);
  const [nonWorkDay, setNonWorkDay] = useState(0);

  useEffect(() => {
    setCalendar(buildCalendar(value));
  }, [value]);

  function buildCalendar(date) {
    const calendarBody = [];

    const startDay = date.clone().startOf("month").startOf("week");
    const endDay = date.clone().endOf("month").endOf("week");

    const _date = startDay.clone().subtract(1, "day");

    let prices = {};

    getPricesFromApi()
      .then((result) => {
        console.log(result.prices);
        setNonWorkDay(result.prices.nonWorkDay)

        console.log(result.prices.nonWorkDay);
        prices = result.prices;
        
      })

    // let nonWorkDay = prices.nonWorkDay;
    console.log('Nonworkday: ' + nonWorkDay)

    while (_date.isBefore(endDay, "day")) {
      calendarBody.push(
        Array(7)
          .fill(0)
          .map(() => _date.add(1, "day").clone())
      );
    }
    return calendarBody;
  }

  function isSelected(day) {
    // console.log('function isSelected: ' + day)
    return value.isSame(day, "day");
  }

  function beforeToday(day) {
    return moment(day).isBefore(new Date(), "day");
  }

  function isToday(day) {
    // console.log('function isToday = ' + day);
    return moment(new Date()).isSame(day, "day");
  }

  function dayStyles(day) {
    if (beforeToday(day)) return "before";
    if (isSelected(day)) return "selected";
    if (isToday(day)) return "today";
    return "";
  }

  function currMonthName() {
    return value.format("MMMM");
  }

  function currYear() {
    return value.format("YYYY");
  }

  async function getPricesFromApi() {
    const endpoint = 'https://localhost:44324/Data/GetReservedDates';

    const result = await fetch(endpoint, {
      mode: 'cors',
      method: 'GET',
      headers: {
        'Accept': '*/*',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': '*'
      }
    })
      .then(response => response.json())
      .then((result) => {
        return result;
      }, (e) => {
        window.alert(e);
      })

    return result;
  }

  return (
    <div className="calendar">
      <Header value={value} onChange={onChange} />

      <div className="body">
        <div className="day-names">
          {["s", "m", "t", "w", "t", "f", "s"].map((d) => (
            <div className="week">{d}</div>
          ))}
        </div>
        {calendar.map((week, wi) => (
          <div key={wi}>
            {week.map((day, di) => (
              <div
                key={di}
                className="day"
                onClick={() => {

                  // Changes on click the day.
                  if (day < moment(new Date()).startOf("day")) return;
                  onChange(day);
                  console.log('Day is: ' + day.format("D").toString())
                }}
              >
                <div className={dayStyles(day)}>
                  {day.format("D").toString()}
                  {/* <p>Price: 4.20</p> */}
                </div>

                <p>Price: 4.20</p>
                <hr />
              </div>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
}
