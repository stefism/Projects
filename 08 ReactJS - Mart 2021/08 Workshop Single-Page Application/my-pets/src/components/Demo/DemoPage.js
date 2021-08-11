import { useState } from "react";

const DemoPage = () => {
    const [count, setCount] = useState(0);
    const [step, setStep] = useState(1);

    const onCounterButtonClickHandler = () => {
        // setCount(count + 1); Не е добре да се прави така. Ще има проблем с race conditions после. Прави се с функция.
        setCount(oldState => oldState + step); // Така е правилно.
    }

    const onStepSelectChangeHandler = (e) => {
        const stepValue = Number(e.target.value);

        setStep(stepValue); // В случая не ни интересува какъв е бил стария стейт и затова го пишем направо така.
    }

    return (
        <div>
            <h1>Counter</h1>
            <h3>{count}</h3>
            <button onClick={onCounterButtonClickHandler}>Increase</button>
            <label htmlFor="step"> Step </label>
            <select name="step" id="step" onChange={onStepSelectChangeHandler}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
            </select>       
        </div>
    )
}

export default DemoPage;