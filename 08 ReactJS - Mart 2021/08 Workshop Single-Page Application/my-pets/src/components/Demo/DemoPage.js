import { useEffect, useState } from "react";
import useFetch from "../Hooks/useFetch";

const DemoPage = () => {
    const [count, setCount] = useState(0);
    const [step, setStep] = useState(1);
    // const [character, setCharacter] = useState({name: 'Nobody'});
    const [character2, isCharacterLoading] = useFetch(`https://swapi.dev/api/people/${step}`);

    // useEffect(() => {
    //     fetch(`https://swapi.dev/api/people/1`)
    //     .then(res => res.json())
    //     .then(result => setCharacter(result));
    // }, []); //[] dependency array. Ако го няма, кода ще се изпълнява всеки път, когато нещо се промени в DOM. В случая даже ще завърти безкраен цикъл.

    // useEffect(() => {
    //     fetch(`https://swapi.dev/api/people/${step}`)
    //     .then(res => res.json())
    //     .then(result => setCharacter(result));
    // }, [step]); // Това е равносилно на ComponentDidUpdate в class компонентите. В случая ще се изпълнява всеки път когато (ако) step се промени.

    useEffect(() => {
        return () => {
            console.log('ComponentWillUnmount'); // Трябва да върнем друга функция и това, което е в ретърна ще се изпълни при WillUnmount. ComponentWillUnmount - примерно когато напуснем страницата.
        }
    }, []);

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
            <h1>{!isCharacterLoading ? character2?.name : "Loading..."} Counter</h1>
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