import React, { useState, useEffect } from "react";
import moment from "moment";
import Header from "./header";
import "./styles.css";
import { render } from "@testing-library/react";

export default function Calendar({ value, onChange }) {
  const [calendar, setCalendar] = useState([]);
  const [prices, setPrices] = useState({});
  const [reservedDates, setReservedDates] = useState([]);
  const [currentYear, setCurrYear] = useState();
  const [currMonth, setCurrMonth] = useState();

  useEffect(() => {
    setCalendar(buildCalendar(value));
  }, [value]);

  console.log('date from state: ' + value.format('YYYY-MM-DD'));

  function buildCalendar(date) {
    setCurrYear(parseFloat(value.format('YYYY-MM-DD').toString().split('-')[0]));
    setCurrMonth(parseFloat(value.format('YYYY-MM-DD').toString().split('-')[1]));

    const calendarBody = [];

    const startDay = date.clone().startOf("month").startOf("week");
    const endDay = date.clone().endOf("month").endOf("week");

    const _date = startDay.clone().subtract(1, "day");

    getPricesFromApi(currentYear, currMonth).then((result) => {
      setPrices(result.prices);
      result.reservedDays.map(d =>
        setReservedDates((prev) =>
          [...prev, d.reservedDate.split('T')[0]]));
    });

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

  async function getPricesFromApi(year = 2021, month = 3) {
    const endpoint = `https://localhost:44324/Data/GetReservedDates?year=${year}&month=${month}`;

    const result = await fetch(endpoint, {
      mode: 'cors',
      method: 'GET',
      headers: {
        'Accept': '*/*',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': '*'
      },
    })
      .then(response => response.json())
      .then((result) => {
        return result;
      }, (e) => {
        window.alert(e);
      })

    return result;
  }

  function GetPrice(day) {
    var price = "";

    if (day.day() == 0 || day.day() == 6) {
      price = prices.nonWorkDay
    }
    else {
      price = prices.workDay
    }

    //В случей че price е undefined, toFixed няма да работи и ще гръмне за това правя тука такава проверка
    return price ? price.toFixed(2) : price
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
            {week.map((date, di) => (
              <div
                key={di}
                // className="day"
                className={reservedDates.includes(date.format('YYYY-MM-DD').toString()) ? 'day reserved' : 'day'}
                onClick={() => {

                  // Changes on click the day.
                  if (date < moment(new Date()).startOf("day")) return;
                  onChange(date);
                  console.log('Day is: ' + date.format("D").toString()
                    + ' notformated: ' + date + ' day-day: ' + date.format('YYYY-MM-DD'))
                }}
              >
                <div className={dayStyles(date)}>
                  {date.format("D").toString()}
                  {/* <p>Price: 4.20</p> */}
                </div>

                <p>Price: {GetPrice(date)}</p>
                <hr />
              </div>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
}